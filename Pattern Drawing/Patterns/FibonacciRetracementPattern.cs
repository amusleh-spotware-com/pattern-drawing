using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class FibonacciRetracementPattern : PatternBase
    {
        private readonly Dictionary<double, ChartTrendLine> _levelLines = new();
        private readonly FibonacciRetracementSettings _settings;

        private ChartTrendLine _mainLine;

        public FibonacciRetracementPattern(PatternConfig config, FibonacciRetracementSettings settings) : base(
            "Fibonacci Retracement", config)
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
                    iObject.Name.EndsWith("MainLine", StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine mainLine) return;

            var levelLines = patternObjects
                .Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine && iObject != mainLine)
                .Cast<ChartTrendLine>()
                .ToDictionary(trendLine => double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture))
                .OrderBy(iLevelLine => iLevelLine.Key);

            if (levelLines == null || !levelLines.Any()) return;

            var levelRectangles = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.Rectangle)
                .Cast<ChartRectangle>()
                .ToDictionary(trendLine =>
                    double.Parse(trendLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            if (levelRectangles == null) return;

            UpdatePattern(mainLine, levelLines, levelRectangles, updatedChartObject);
        }

        private void UpdatePattern(ChartTrendLine mainLine,
            IOrderedEnumerable<KeyValuePair<double, ChartTrendLine>> levelLines,
            Dictionary<double, ChartRectangle> levelRectangles, ChartObject updatedChartObject)
        {
            var verticalDelta = mainLine.GetPriceDelta();

            var previousLevelPrice = double.NaN;

            FibonacciLevel previousLevel = null;

            var startTime = mainLine.GetStartTime();
            var endTime = mainLine.GetEndTime();

            foreach (var levelLine in levelLines)
            {
                var percent = levelLine.Key;

                var level = _settings.Levels.FirstOrDefault(iLevel => iLevel.Percent == percent);

                if (level == null) continue;

                var levelAmount = percent == 0 ? 0 : verticalDelta * percent;

                var price = mainLine.Y2 > mainLine.Y1 ? mainLine.Y2 - levelAmount : mainLine.Y2 + levelAmount;

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
            _mainLine = null;

            _levelLines.Clear();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2)
            {
                FinishDrawing();

                return;
            }

            if (_mainLine == null)
            {
                var name = GetObjectName("MainLine");

                _mainLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue, Color, 1,
                    LineStyle.Dots);

                _mainLine.IsInteractive = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber > 1 || _mainLine == null) return;

            _mainLine.Time2 = obj.TimeValue;
            _mainLine.Y2 = obj.YValue;

            DrawLevels(obj.Chart, _mainLine);
        }

        private void DrawLevels(Chart chart, ChartTrendLine mainLine)
        {
            var verticalDelta = mainLine.GetPriceDelta();

            var previousLevelPrice = double.NaN;

            FibonacciLevel previousLevel = null;

            var startTime = mainLine.GetStartTime();
            var endTime = mainLine.GetEndTime();

            foreach (var level in _settings.Levels)
            {
                var levelAmount = level.Percent == 0 ? 0 : verticalDelta * level.Percent;

                var levelLineName = GetObjectName($"LevelLine_{level.Percent}");

                var price = mainLine.Y2 > mainLine.Y1 ? mainLine.Y2 - levelAmount : mainLine.Y2 + levelAmount;

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

        protected override void DrawLabels(Chart chart) => DrawLabels(chart, _levelLines, Id);

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
            var levelLines = patternObjects.Where(iObject =>
                    iObject.ObjectType == ChartObjectType.TrendLine &&
                    !iObject.Name.EndsWith("MainLine", StringComparison.OrdinalIgnoreCase))
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
            return new ChartObject[] {_mainLine};
        }
    }
}