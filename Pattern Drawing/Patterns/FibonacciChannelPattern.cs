using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class FibonacciChannelPattern : PatternBase
    {
        private readonly Dictionary<double, ChartTrendLine> _otherLevelLines = new();
        private readonly FibonacciChannelPatternSettings _settings;

        private ChartTrendLine _zeroLine, _onePercentLine;

        public FibonacciChannelPattern(PatternConfig config, FibonacciChannelPatternSettings settings) :
            base("Fibonacci Channel", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            if (patternObjects.FirstOrDefault(iLine =>
                    iLine.Name.LastIndexOf("ZeroLine", StringComparison.OrdinalIgnoreCase) >= 0) is not ChartTrendLine zeroLine || patternObjects.FirstOrDefault(iLine =>
                    iLine.Name.LastIndexOf("OnePercentLine", StringComparison.OrdinalIgnoreCase) >= 0) is not ChartTrendLine onePercentLine ||
                (updatedChartObject != zeroLine && updatedChartObject != onePercentLine)) return;

            UpdateLines(chart, zeroLine, onePercentLine, updatedChartObject as ChartTrendLine, id);
        }

        protected override void OnDrawingStopped()
        {
            _zeroLine = null;

            _onePercentLine = null;

            _otherLevelLines.Clear();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 1)
            {
                var zeroLineName = GetObjectName("ZeroLine");

                _zeroLine = obj.Chart.DrawTrendLine(zeroLineName, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    Color, 1, LineStyle.Dots);

                _zeroLine.IsInteractive = true;
            }
            else if (MouseUpNumber == 3)
            {
                FinishDrawing();
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 1)
            {
                _zeroLine.Time2 = obj.TimeValue;
                _zeroLine.Y2 = obj.YValue;
            }
            else if (MouseUpNumber == 2 && _zeroLine != null)
            {
                var onePercentLineName = GetObjectName("OnePercentLine");

                var onePercentFirstBarIndex = obj.Chart.Bars.GetBarIndex(obj.TimeValue, obj.Chart.Symbol);

                var zeroLineBarsDelta = _zeroLine.GetBarsNumber(obj.Chart.Bars, obj.Chart.Symbol);
                var zeroLinePriceDelta = _zeroLine.GetPriceDelta();

                var zeroLineSlope = _zeroLine.GetSlope();

                double secondBarIndex, secondPrice;

                if (_zeroLine.Time1 < _zeroLine.Time2)
                {
                    secondBarIndex = onePercentFirstBarIndex + zeroLineBarsDelta;
                    secondPrice = zeroLineSlope > 0 ? obj.YValue + zeroLinePriceDelta : obj.YValue - zeroLinePriceDelta;
                }
                else
                {
                    secondBarIndex = onePercentFirstBarIndex - zeroLineBarsDelta;
                    secondPrice = zeroLineSlope > 0 ? obj.YValue - zeroLinePriceDelta : obj.YValue + zeroLinePriceDelta;
                }

                _onePercentLine = obj.Chart.DrawTrendLine(onePercentLineName, obj.TimeValue, obj.YValue,
                    obj.Chart.Bars.GetOpenTime(secondBarIndex, obj.Chart.Symbol), secondPrice, Color, 1, LineStyle.Dots);

                _onePercentLine.IsInteractive = true;

                var levellines = DrawFibonacciLevels(obj.Chart, _zeroLine, _onePercentLine, zeroLineSlope, Id);

                foreach (var levelLine in levellines) _otherLevelLines[levelLine.Key] = levelLine.Value;
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_zeroLine, _onePercentLine};
        }

        protected override void DrawLabels(Chart chart)
        {
            if (_zeroLine == null || _onePercentLine == null || _otherLevelLines == null) return;

            DrawLabels(chart, _zeroLine, _onePercentLine, _otherLevelLines, Id);
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject updatedObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            var trendLines = patternObjects.Where(iObject => iObject is ChartTrendLine).Cast<ChartTrendLine>()
                .ToArray();

            var zeroLine = trendLines.FirstOrDefault(iLine =>
                iLine.Name.LastIndexOf("ZeroLine", StringComparison.OrdinalIgnoreCase) >= 0);

            if (zeroLine == null) return;

            var zeroLineLabel = labels.FirstOrDefault(iLabel =>
                iLabel.Name.Split('_').Last().Equals("0", StringComparison.OrdinalIgnoreCase));

            if (zeroLineLabel != null)
            {
                zeroLineLabel.Text = $"0 ({Math.Round(zeroLine.Y1, chart.Symbol.Digits)})";
                zeroLineLabel.Time = zeroLine.Time1;
                zeroLineLabel.Y = zeroLine.Y1;
                zeroLineLabel.Color = zeroLine.Color;
            }

            var onePercentLine = trendLines.FirstOrDefault(iLine =>
                iLine.Name.LastIndexOf("OnePercentLine", StringComparison.OrdinalIgnoreCase) >= 0);

            if (onePercentLine == null) return;

            var onePercentLineLabel = labels.FirstOrDefault(iLabel =>
                iLabel.Name.Split('_').Last().Equals("1", StringComparison.OrdinalIgnoreCase));

            if (onePercentLineLabel != null)
            {
                onePercentLineLabel.Text = $"1 ({Math.Round(onePercentLine.Y1, chart.Symbol.Digits)})";
                onePercentLineLabel.Time = onePercentLine.Time1;
                onePercentLineLabel.Y = onePercentLine.Y1;
                onePercentLineLabel.Color = onePercentLine.Color;
            }

            var otherLevelLines = trendLines.Where(iObject => iObject != zeroLine && iObject != onePercentLine)
                .ToDictionary(trendLine =>
                    double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            if (otherLevelLines == null || otherLevelLines.Count == 0) return;

            if (labels.Length == 0)
                //DrawLabels(zeroLine, onePercentLine, otherLevelLines, id);
                return;

            foreach (var label in labels)
            {
                var percent = double.Parse(label.Name.Split('_').Last(), CultureInfo.InvariantCulture);

                if (percent == 0 || percent == 1) continue;


                if (!otherLevelLines.TryGetValue(percent, out var levelLine)) continue;

                label.Text = $"{percent} ({Math.Round(levelLine.Y1, chart.Symbol.Digits)})";
                label.Time = levelLine.Time1;
                label.Y = levelLine.Y1;
                label.Color = levelLine.Color;
            }
        }

        protected override void UpdateLabelsStyle(ChartText[] labels, ChartText updatedLabel)
        {
            foreach (var label in labels)
            {
                label.FontSize = updatedLabel.FontSize;
                label.IsBold = updatedLabel.IsBold;
                label.IsItalic = updatedLabel.IsItalic;
                label.IsLocked = updatedLabel.IsLocked;
                label.IsUnderlined = updatedLabel.IsUnderlined;
                label.HorizontalAlignment = updatedLabel.HorizontalAlignment;
                label.VerticalAlignment = updatedLabel.VerticalAlignment;
            }
        }

        private void DrawLabels(Chart chart, ChartTrendLine zeroLine, ChartTrendLine onePercentLine,
            Dictionary<double, ChartTrendLine> otherLevelsLines, long id)
        {
            if (_settings.Levels.Any(iLevel => iLevel.Percent == 0))
            {
                var zeroText = $"0 ({Math.Round(zeroLine.Y1, chart.Symbol.Digits)})";

                DrawLabelText(chart, zeroText, zeroLine.Time1, zeroLine.Y1, id, objectNameKey: "0", color: zeroLine.Color,
                    fontSize: 9);
            }

            if (_settings.Levels.Any(iLevel => iLevel.Percent == 1))
            {
                var onePercentText = $"1 ({Math.Round(onePercentLine.Y1, chart.Symbol.Digits)})";

                DrawLabelText(chart, onePercentText, onePercentLine.Time1, onePercentLine.Y1, id, objectNameKey: "1",
                    color: onePercentLine.Color, fontSize: 9);
            }

            foreach (var levelLine in otherLevelsLines)
            {
                var text = $"{levelLine.Key} ({Math.Round(onePercentLine.Y1, chart.Symbol.Digits)})";

                DrawLabelText(chart, text, levelLine.Value.Time1, levelLine.Value.Y1, id,
                    objectNameKey: levelLine.Key.ToString(CultureInfo.InvariantCulture), color: levelLine.Value.Color,
                    fontSize: 9);
            }
        }

        private void UpdateLines(Chart chart, ChartTrendLine zeroLine, ChartTrendLine onePercentLine, ChartTrendLine updatedLine,
            long id)
        {
            if (updatedLine == zeroLine)
                zeroLine.RefelectOnOtherLine(onePercentLine, chart.Bars, chart.Symbol);
            else
                onePercentLine.RefelectOnOtherLine(zeroLine, chart.Bars, chart.Symbol);

            DrawFibonacciLevels(chart, zeroLine, onePercentLine, zeroLine.GetSlope(), id, updateMainLineStlyes: false);
        }

        private Dictionary<double, ChartTrendLine> DrawFibonacciLevels(Chart chart, ChartTrendLine zeroLine,
            ChartTrendLine onePercentLine, double zeroLineSlope, long id, bool updateMainLineStlyes = true)
        {
            var zeroFirstBarIndex = chart.Bars.GetBarIndex(zeroLine.Time1, chart.Symbol);
            chart.Bars.GetBarIndex(zeroLine.Time2, chart.Symbol);

            var onePercentFirstBarIndex = chart.Bars.GetBarIndex(onePercentLine.Time1, chart.Symbol);

            var barsDelta = Math.Abs(zeroFirstBarIndex - onePercentFirstBarIndex);
            var priceDelta = Math.Abs(zeroLine.Y1 - onePercentLine.Y1);

            var zeroLineBarsDelta = zeroLine.GetBarsNumber(chart.Bars, chart.Symbol);
            var zeroLinePriceDelta = zeroLine.GetPriceDelta();

            var result = new Dictionary<double, ChartTrendLine>();

            foreach (var level in _settings.Levels)
                if (level.Percent == 0 && updateMainLineStlyes)
                {
                    zeroLine.Color = level.LineColor;
                    zeroLine.Thickness = level.Thickness;
                    zeroLine.LineStyle = level.Style;
                }
                else if (level.Percent == 1 && updateMainLineStlyes)
                {
                    onePercentLine.Color = level.LineColor;
                    onePercentLine.Thickness = level.Thickness;
                    onePercentLine.LineStyle = level.Style;
                }
                else
                {
                    var levelName = GetObjectName($"Level_{level.Percent.ToString(CultureInfo.InvariantCulture)}", id);

                    var barsAmount = barsDelta * level.Percent;
                    var priceAmount = priceDelta * level.Percent;

                    double firstBarIndex, secondBarIndex, firstPrice, secondPrice;

                    if (onePercentLine.Time1 < zeroLine.Time1)
                    {
                        firstPrice = onePercentLine.Y1 > zeroLine.Y1
                            ? zeroLine.Y1 + priceAmount
                            : zeroLine.Y1 - priceAmount;

                        if (zeroLine.Time1 < zeroLine.Time2)
                        {
                            firstBarIndex = zeroFirstBarIndex - barsAmount;
                            secondBarIndex = firstBarIndex + zeroLineBarsDelta;

                            secondPrice = zeroLineSlope > 0
                                ? firstPrice + zeroLinePriceDelta
                                : firstPrice - zeroLinePriceDelta;
                        }
                        else
                        {
                            firstBarIndex = zeroFirstBarIndex - barsAmount;
                            secondBarIndex = firstBarIndex - zeroLineBarsDelta;

                            secondPrice = zeroLineSlope > 0
                                ? firstPrice - zeroLinePriceDelta
                                : firstPrice + zeroLinePriceDelta;
                        }
                    }
                    else
                    {
                        firstPrice = onePercentLine.Y1 > zeroLine.Y1
                            ? zeroLine.Y1 + priceAmount
                            : zeroLine.Y1 - priceAmount;

                        if (zeroLine.Time1 < zeroLine.Time2)
                        {
                            firstBarIndex = zeroFirstBarIndex + barsAmount;
                            secondBarIndex = firstBarIndex + zeroLineBarsDelta;

                            secondPrice = zeroLineSlope > 0
                                ? firstPrice + zeroLinePriceDelta
                                : firstPrice - zeroLinePriceDelta;
                        }
                        else
                        {
                            firstBarIndex = zeroFirstBarIndex + barsAmount;
                            secondBarIndex = firstBarIndex - zeroLineBarsDelta;

                            secondPrice = zeroLineSlope > 0
                                ? firstPrice - zeroLinePriceDelta
                                : firstPrice + zeroLinePriceDelta;
                        }
                    }

                    var firstTime = chart.Bars.GetOpenTime(firstBarIndex, chart.Symbol);
                    var secondTime = chart.Bars.GetOpenTime(secondBarIndex, chart.Symbol);

                    if (chart.Objects.FirstOrDefault(iObject =>
                            iObject.Name.Equals(levelName, StringComparison.OrdinalIgnoreCase)) is ChartTrendLine levelLine)
                    {
                        levelLine.Time1 = firstTime;
                        levelLine.Time2 = secondTime;

                        levelLine.Y1 = firstPrice;
                        levelLine.Y2 = secondPrice;
                    }
                    else
                    {
                        levelLine = chart.DrawTrendLine(levelName, firstTime, firstPrice, secondTime, secondPrice,
                            level.LineColor, level.Thickness, level.Style);
                    }

                    levelLine.IsInteractive = true;
                    levelLine.IsLocked = true;

                    result.Add(level.Percent, levelLine);
                }

            return result;
        }
    }
}