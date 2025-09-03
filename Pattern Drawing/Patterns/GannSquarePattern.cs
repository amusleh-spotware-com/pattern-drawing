using System;
using System.Collections.Generic;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class GannSquarePattern : PatternBase
    {
        private readonly GannSquareSettings _settings;

        private ChartTrendLine[] _horizontalTrendLines;
        private ChartRectangle _rectangle;
        private ChartTrendLine[] _verticalTrendLines;

        public GannSquarePattern(PatternConfig config, GannSquareSettings settings) : base("Gann Square", config) =>
            _settings = settings;

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.Rectangle) return;

            var rectangle = updatedChartObject as ChartRectangle;

            var trendLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine)
                .Cast<ChartTrendLine>()
                .ToArray();

            var horizontalLines = trendLines.Where(iTrendLine =>
                iTrendLine.Name.IndexOf("HorizontalLine", StringComparison.OrdinalIgnoreCase) > -1).ToArray();

            DrawOrUpdateHorizontalLines(chart, rectangle, horizontalLines);

            var verticalLines = trendLines.Where(iTrendLine =>
                iTrendLine.Name.IndexOf("VerticalLine", StringComparison.OrdinalIgnoreCase) > -1).ToArray();

            DrawOrUpdateVerticalLines(chart, rectangle, verticalLines);

            UpdateFans(chart, rectangle,
                trendLines.Where(iTrendLine =>
                        iTrendLine.Name.Split('_').Last().IndexOf("Fan", StringComparison.OrdinalIgnoreCase) > -1)
                    .ToArray());
        }

        private void UpdateFans(Chart chart, ChartRectangle rectangle, ChartTrendLine[] fans)
        {
            var startTime = rectangle.GetStartTime();
            var endTime = rectangle.GetEndTime();

            var topPrice = rectangle.GetTopPrice();
            var bottomPrice = rectangle.GetBottomPrice();

            var rectanglePriceDelta = rectangle.GetPriceDelta();
            var rectangleBarsNumber = rectangle.GetBarsNumber(chart.Bars, chart.Symbol);

            var startBarIndex = rectangle.GetStartBarIndex(chart.Bars, chart.Symbol);

            foreach (var fan in fans)
            {
                var fanName = fan.Name.Split('.').Last();

                fan.Time1 = startTime;
                fan.Y1 = bottomPrice;

                switch (fanName)
                {
                    case "1x1":
                        fan.Time2 = endTime;
                        fan.Y2 = topPrice;
                        break;

                    case "1x2":
                    case "1x3":
                    case "1x4":
                    case "1x5":
                    case "1x8":
                    {
                        fan.Y2 = topPrice;

                        switch (fanName)
                        {
                            case "1x2":
                                fan.Time2 = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 2,
                                    chart.Symbol);
                                break;

                            case "1x3":
                                fan.Time2 = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 3,
                                    chart.Symbol);
                                break;

                            case "1x4":
                                fan.Time2 = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 4,
                                    chart.Symbol);
                                break;

                            case "1x5":
                                fan.Time2 = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 5,
                                    chart.Symbol);
                                break;

                            case "1x8":
                                fan.Time2 = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 8,
                                    chart.Symbol);
                                break;
                        }

                        break;
                    }
                    case "2x1":
                    case "3x1":
                    case "4x1":
                    case "5x1":
                    case "8x1":
                    {
                        fan.Time2 = endTime;

                        switch (fanName)
                        {
                            case "2x1":
                                fan.Y2 = bottomPrice + rectanglePriceDelta / 2;
                                break;

                            case "3x1":
                                fan.Y2 = bottomPrice + rectanglePriceDelta / 3;
                                break;

                            case "4x1":
                                fan.Y2 = bottomPrice + rectanglePriceDelta / 4;
                                break;

                            case "5x1":
                                fan.Y2 = bottomPrice + rectanglePriceDelta / 5;
                                break;

                            case "8x1":
                                fan.Y2 = bottomPrice + rectanglePriceDelta / 8;
                                break;
                        }

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException("level", "The fan name is outside valid range");
                }
            }
        }

        protected override void OnDrawingStopped()
        {
            _rectangle = null;
            _horizontalTrendLines = null;
            _verticalTrendLines = null;
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2)
            {
                FinishDrawing();

                return;
            }

            if (_rectangle == null)
            {
                var name = GetObjectName("Rectangle");

                _rectangle = obj.Chart.DrawRectangle(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    _settings.RectangleColor, _settings.RectangleThickness, _settings.RectangleStyle);

                _rectangle.IsInteractive = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber > 1 || _rectangle == null) return;

            _rectangle.Time2 = obj.TimeValue;
            _rectangle.Y2 = obj.YValue;

            _horizontalTrendLines = new ChartTrendLine[4];

            DrawOrUpdateHorizontalLines(obj.Chart, _rectangle, _horizontalTrendLines);

            _verticalTrendLines = new ChartTrendLine[4];

            DrawOrUpdateVerticalLines(obj.Chart, _rectangle, _verticalTrendLines);

            DrawFans(obj.Chart, _rectangle);
        }

        private void DrawFans(Chart chart, ChartRectangle rectangle)
        {
            var startTime = rectangle.GetStartTime();
            var endTime = rectangle.GetEndTime();

            var topPrice = rectangle.GetTopPrice();
            var bottomPrice = rectangle.GetBottomPrice();

            var rectanglePriceDelta = rectangle.GetPriceDelta();
            var rectangleBarsNumber = rectangle.GetBarsNumber(chart.Bars, chart.Symbol);

            var startBarIndex = rectangle.GetStartBarIndex(chart.Bars, chart.Symbol);

            var levels = new[] {1, 2, 3, 4, 5, 8, -2, -3, -4, -5, -8};

            foreach (var level in levels)
            {
                string name;
                var secondTime = endTime;
                var secondPrice = topPrice;

                switch (level)
                {
                    case 1:
                        name = "1x1";
                        secondTime = endTime;
                        secondPrice = topPrice;
                        break;

                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 8:
                    {
                        name = $"1x{level}";
                        secondPrice = topPrice;

                        switch (level)
                        {
                            case 2:
                                secondTime = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 2,
                                    chart.Symbol);
                                break;

                            case 3:
                                secondTime = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 3,
                                    chart.Symbol);
                                break;

                            case 4:
                                secondTime = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 4,
                                    chart.Symbol);
                                break;

                            case 5:
                                secondTime = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 5,
                                    chart.Symbol);
                                break;

                            case 8:
                                secondTime = chart.Bars.GetOpenTime(startBarIndex + rectangleBarsNumber / 8,
                                    chart.Symbol);
                                break;
                        }

                        break;
                    }
                    case -2:
                    case -3:
                    case -4:
                    case -5:
                    case -8:
                    {
                        name = $"{Math.Abs(level)}x1";
                        secondTime = endTime;

                        switch (level)
                        {
                            case -2:
                                secondPrice = bottomPrice + rectanglePriceDelta / 2;
                                break;

                            case -3:
                                secondPrice = bottomPrice + rectanglePriceDelta / 3;
                                break;

                            case -4:
                                secondPrice = bottomPrice + rectanglePriceDelta / 4;
                                break;

                            case -5:
                                secondPrice = bottomPrice + rectanglePriceDelta / 5;
                                break;

                            case -8:
                                secondPrice = bottomPrice + rectanglePriceDelta / 8;
                                break;
                        }

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException("level", "The fan level is outside valid range");
                }

                if (string.IsNullOrWhiteSpace(name)) continue;

                var objectName = GetObjectName($"Fan.{name}");

                var trendLine = chart.DrawTrendLine(objectName, startTime, bottomPrice, secondTime, secondPrice,
                    _settings.FansColor, _settings.FansThickness, _settings.FansStyle);

                trendLine.IsInteractive = true;
                trendLine.IsLocked = true;
            }
        }

        private void DrawOrUpdateHorizontalLines(Chart chart, ChartRectangle rectangle, ChartTrendLine[] horizontalLines)
        {
            var startTime = rectangle.GetStartTime();
            var endTime = rectangle.GetEndTime();

            var verticalDelta = rectangle.GetPriceDelta();

            var lineLevels = new[]
            {
                verticalDelta * 0.2,
                verticalDelta * 0.4,
                verticalDelta * 0.6,
                verticalDelta * 0.8,
            };

            for (var i = 0; i < lineLevels.Length; i++)
            {
                var level = rectangle.Y2 > rectangle.Y1 ? rectangle.Y1 + lineLevels[i] : rectangle.Y1 - lineLevels[i];

                var horizontalLine = horizontalLines[i];

                if (horizontalLine == null)
                {
                    var objectName = GetObjectName($"HorizontalLine{i + 1}");

                    horizontalLines[i] = chart.DrawTrendLine(objectName, startTime, level, endTime, level,
                        _settings.PriceLevelsColor, _settings.PriceLevelsThickness, _settings.PriceLevelsStyle);

                    horizontalLines[i].IsInteractive = true;
                    horizontalLines[i].IsLocked = true;
                }
                else
                {
                    horizontalLine.Time1 = startTime;
                    horizontalLine.Time2 = endTime;

                    horizontalLine.Y1 = level;
                    horizontalLine.Y2 = level;
                }
            }
        }

        private void DrawOrUpdateVerticalLines(Chart chart, ChartRectangle rectangle, ChartTrendLine[] verticalLines)
        {
            var startBarIndex = rectangle.GetStartBarIndex(chart.Bars, chart.Symbol);

            var barsNumber = rectangle.GetBarsNumber(chart.Bars, chart.Symbol);

            var lineLevels = new[]
            {
                barsNumber * 0.2,
                barsNumber * 0.4,
                barsNumber * 0.6,
                barsNumber * 0.8,
            };

            var rectangleEndTime = rectangle.GetEndTime();

            for (var i = 0; i < lineLevels.Length; i++)
            {
                var barIndex = startBarIndex + lineLevels[i];

                var time = chart.Bars.GetOpenTime(barIndex, chart.Symbol);

                if (time > rectangleEndTime) time = rectangleEndTime;

                var verticalLine = verticalLines[i];

                if (verticalLine == null)
                {
                    var objectName = GetObjectName($"VerticalLine{i + 1}");

                    verticalLines[i] = chart.DrawTrendLine(objectName, time, rectangle.Y1, time, rectangle.Y2,
                        _settings.TimeLevelsColor, _settings.TimeLevelsThickness, _settings.TimeLevelsStyle);

                    verticalLines[i].IsInteractive = true;
                    verticalLines[i].IsLocked = true;
                }
                else
                {
                    verticalLine.Time1 = time;
                    verticalLine.Time2 = time;

                    verticalLine.Y1 = rectangle.Y1;
                    verticalLine.Y2 = rectangle.Y2;
                }
            }
        }

        protected override void DrawLabels(Chart chart)
        {
            if (_rectangle == null) return;

            DrawLabels(chart, _rectangle, Id);
        }

        private void DrawLabels(Chart chart, ChartRectangle rectangle, long id)
        {
            DrawLabelText(chart, Math.Round(rectangle.GetPriceDelta(), chart.Symbol.Digits).ToNonScientificString(),
                rectangle.GetStartTime(), rectangle.GetTopPrice(), id, objectNameKey: "Price", fontSize: 10);
            DrawLabelText(chart, rectangle.GetBarsNumber(chart.Bars, chart.Symbol).ToString(), rectangle.GetEndTime(),
                rectangle.GetBottomPrice(), id, objectNameKey: "BarsNumber", fontSize: 10);
            DrawLabelText(chart, rectangle.GetPriceToBarsRatio(chart.Bars, chart.Symbol).ToNonScientificString(),
                rectangle.GetEndTime(), rectangle.GetTopPrice(), id, objectNameKey: "PriceToBarsRatio", fontSize: 10);
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject chartObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            var rectangle = patternObjects.FirstOrDefault(iObject => iObject is ChartRectangle) as ChartRectangle;

            if (rectangle == null) return;

            if (labels.Length == 0)
            {
                DrawLabels(chart, rectangle, id);

                return;
            }

            foreach (var label in labels)
            {
                var labelKey = label.Name.Split('_').Last();

                switch (labelKey)
                {
                    case "Price":
                        label.Text = Math.Round(rectangle.GetPriceDelta(), chart.Symbol.Digits).ToNonScientificString();
                        label.Time = rectangle.GetStartTime();
                        label.Y = rectangle.GetTopPrice();
                        break;

                    case "BarsNumber":
                        label.Text = rectangle.GetBarsNumber(chart.Bars, chart.Symbol).ToString();
                        label.Time = rectangle.GetEndTime();
                        label.Y = rectangle.GetBottomPrice();
                        break;

                    case "PriceToBarsRatio":
                        label.Text = rectangle.GetPriceToBarsRatio(chart.Bars, chart.Symbol).ToNonScientificString();
                        label.Time = rectangle.GetEndTime();
                        label.Y = rectangle.GetTopPrice();
                        break;
                }
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_rectangle};
        }
    }
}