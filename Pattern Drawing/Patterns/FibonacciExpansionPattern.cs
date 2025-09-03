using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class FibonacciExpansionPattern : PatternBase
    {
        private readonly Dictionary<double, ChartTrendLine> _levelLines = new();
        private readonly FibonacciExpansionPatternSettings _settings;

        private ChartTrendLine _firstWaveLine, _secondWaveLine;

        public FibonacciExpansionPattern(PatternConfig config, FibonacciExpansionPatternSettings settings) : base(
            "Fibonacci Expansion", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine &&
                updatedChartObject.ObjectType != ChartObjectType.Rectangle) return;

            if (patternObjects.FirstOrDefault(iObject =>
                    iObject.ObjectType == ChartObjectType.TrendLine &&
                    iObject.Name.EndsWith("FirstWaveLine", StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine firstWaveLine) return;

            if (patternObjects.FirstOrDefault(iObject =>
                    iObject.ObjectType == ChartObjectType.TrendLine &&
                    iObject.Name.EndsWith("SecondWaveLine", StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine secondWaveLine) return;

            if (updatedChartObject == firstWaveLine)
            {
                secondWaveLine.Time1 = firstWaveLine.Time2;
                secondWaveLine.Y1 = firstWaveLine.Y2;
            }
            else if (updatedChartObject == secondWaveLine)
            {
                firstWaveLine.Time2 = secondWaveLine.Time1;
                firstWaveLine.Y2 = secondWaveLine.Y1;
            }

            var levelLines = patternObjects.Where(iObject =>
                    iObject.ObjectType == ChartObjectType.TrendLine && iObject != firstWaveLine &&
                    iObject != secondWaveLine)
                .Cast<ChartTrendLine>()
                .ToDictionary(trendLine => double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture))
                .OrderBy(iLevelLine => iLevelLine.Key);

            if (levelLines == null || !levelLines.Any()) return;

            var levelRectangles = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.Rectangle)
                .Cast<ChartRectangle>()
                .ToDictionary(trendLine =>
                    double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            if (levelRectangles == null) return;

            UpdatePattern(firstWaveLine, secondWaveLine, levelLines, levelRectangles, updatedChartObject);
        }

        private void UpdatePattern(ChartTrendLine firstWaveLine, ChartTrendLine secondWaveLine,
            IOrderedEnumerable<KeyValuePair<double, ChartTrendLine>> levelLines,
            Dictionary<double, ChartRectangle> levelRectangles, ChartObject updatedChartObject)
        {
            var verticalDelta = firstWaveLine.GetPriceDelta();

            var previousLevelPrice = double.NaN;

            FibonacciLevel previousLevel = null;

            var startTime = firstWaveLine.Time1;
            var endTime = secondWaveLine.Time2;

            foreach (var levelLine in levelLines)
            {
                var percent = levelLine.Key;

                var level = _settings.Levels.FirstOrDefault(iLevel => iLevel.Percent == percent);

                if (level == null) continue;

                var levelAmount = percent == 0 ? 0 : verticalDelta * percent;

                var price = secondWaveLine.Y2 > secondWaveLine.Y1
                    ? secondWaveLine.Y2 - levelAmount
                    : secondWaveLine.Y2 + levelAmount;

                levelLine.Value.Time1 = startTime;
                levelLine.Value.Time2 = endTime;

                levelLine.Value.Y1 = price;
                levelLine.Value.Y2 = price;

                if (previousLevel == null)
                {
                    previousLevelPrice = price;

                    previousLevel = level;

                    continue;
                }


                if (levelRectangles.TryGetValue(level.Percent, out var levelRectangle))
                {
                    if (levelLine.Value == updatedChartObject)
                        levelRectangle.Color = Color.FromArgb(level.FillColor.A, levelLine.Value.Color);
                    else if (levelRectangle == updatedChartObject)
                        levelLine.Value.Color = Color.FromArgb(level.LineColor.A, levelRectangle.Color);
                }


                if (!levelRectangles.TryGetValue(previousLevel.Percent, out var previousLevelRectangle)) continue;

                previousLevelRectangle.Time1 = startTime;

                previousLevelRectangle.Time2 = previousLevel.ExtendToInfinity ? endTime.AddMonths(100) : endTime;

                previousLevelRectangle.Y1 = previousLevelPrice;
                previousLevelRectangle.Y2 = price;

                previousLevelPrice = price;
                previousLevel = level;
            }
        }

        protected override void OnDrawingStopped()
        {
            _firstWaveLine = null;
            _secondWaveLine = null;

            _levelLines.Clear();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 3)
            {
                FinishDrawing();

                return;
            }

            if (_firstWaveLine == null)
            {
                var name = GetObjectName("FirstWaveLine");

                _firstWaveLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue, Color,
                    1, LineStyle.Dots);

                _firstWaveLine.IsInteractive = true;
            }
            else if (_secondWaveLine == null)
            {
                var name = GetObjectName("SecondWaveLine");

                _secondWaveLine = obj.Chart.DrawTrendLine(name, _firstWaveLine.Time2, _firstWaveLine.Y2, obj.TimeValue,
                    obj.YValue, Color, 1, LineStyle.Dots);

                _secondWaveLine.IsInteractive = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (_firstWaveLine != null && _secondWaveLine == null)
            {
                _firstWaveLine.Time2 = obj.TimeValue;
                _firstWaveLine.Y2 = obj.YValue;
            }
            else if (_firstWaveLine != null && _secondWaveLine != null)
            {
                _secondWaveLine.Time2 = obj.TimeValue;
                _secondWaveLine.Y2 = obj.YValue;

                DrawLevels(obj.Chart, _firstWaveLine, _secondWaveLine);
            }
        }

        private void DrawLevels(Chart chart, ChartTrendLine firstWaveLine, ChartTrendLine secondWaveLine)
        {
            var verticalDelta = firstWaveLine.GetPriceDelta();

            var previousLevelPrice = double.NaN;

            FibonacciLevel previousLevel = null;

            var startTime = firstWaveLine.Time1;
            var endTime = secondWaveLine.Time2;

            foreach (var level in _settings.Levels)
            {
                var levelAmount = level.Percent == 0 ? 0 : verticalDelta * level.Percent;

                var levelLineName = GetObjectName($"LevelLine_{level.Percent}");

                var price = secondWaveLine.Y2 > secondWaveLine.Y1
                    ? secondWaveLine.Y2 - levelAmount
                    : secondWaveLine.Y2 + levelAmount;

                var lineColor = level.IsFilled ? level.LineColor : level.FillColor;

                var levelLine = chart.DrawTrendLine(levelLineName, startTime, price, endTime, price, lineColor,
                    level.Thickness, level.Style);

                levelLine.IsInteractive = true;
                levelLine.IsLocked = true;
                levelLine.ExtendToInfinity = level.ExtendToInfinity;

                _levelLines[level.Percent] = levelLine;

                if (previousLevel == null)
                {
                    previousLevelPrice = price;

                    previousLevel = level;

                    continue;
                }

                var levelRectangleName = GetObjectName($"LevelRectangle_{level.Percent}");

                var rectangle = chart.DrawRectangle(levelRectangleName, startTime, previousLevelPrice, endTime, price,
                    level.FillColor, 0);

                rectangle.IsFilled = level.IsFilled;

                rectangle.IsInteractive = true;
                rectangle.IsLocked = true;

                if (level.ExtendToInfinity) rectangle.Time2 = rectangle.Time2.AddMonths(100);

                previousLevelPrice = price;
                previousLevel = level;
            }
        }

        protected override void DrawLabels(Chart chart)
        {
            DrawLabels(chart, _levelLines, Id);
        }

        private void DrawLabels(Chart chart, Dictionary<double, ChartTrendLine> levelLines, long id)
        {
            foreach (var levelLine in levelLines)
            {
                var text = $"{levelLine.Key} ({Math.Round(levelLine.Value.Y1, chart.Symbol.Digits)})";

                DrawLabelText(chart, text, levelLine.Value.GetStartTime(), levelLine.Value.Y1, id,
                    objectNameKey: levelLine.Key.ToString(CultureInfo.InvariantCulture));
            }
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject chartObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            var levelLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine
                                                             && !iObject.Name.EndsWith("FirstWaveLine",
                                                                 StringComparison.OrdinalIgnoreCase)
                                                             && !iObject.Name.EndsWith("SecondWaveLine",
                                                                 StringComparison.OrdinalIgnoreCase))
                .Cast<ChartTrendLine>()
                .ToDictionary(trendLine =>
                    double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            if (levelLines.Count == 0) return;

            if (labels.Length == 0)
            {
                DrawLabels(chart, levelLines, id);

                return;
            }

            foreach (var label in labels)
            {
                var percent = double.Parse(label.Name.Split('_').Last(), CultureInfo.InvariantCulture);


                if (!levelLines.TryGetValue(percent, out var levelLine)) continue;

                label.Text = $"{percent} ({Math.Round(levelLine.Y1, chart.Symbol.Digits)})";
                label.Time = levelLine.GetStartTime();
                label.Y = levelLine.Y1;
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_firstWaveLine, _secondWaveLine};
        }
    }
}