using System;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class TrendBasedFibonacciTimePattern : PatternBase
    {
        private readonly TrendBasedFibonacciTimePatternSettings _settings;

        private ChartTrendLine _mainLine, _distanceLine;

        public TrendBasedFibonacciTimePattern(PatternConfig config, TrendBasedFibonacciTimePatternSettings settings) :
            base("Trend Based Fibonacci Time", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            if (patternObjects.FirstOrDefault(iLine =>
                    iLine.Name.LastIndexOf("MainLine", StringComparison.OrdinalIgnoreCase) >= 0) is not ChartTrendLine mainLine || patternObjects.FirstOrDefault(iLine =>
                    iLine.Name.LastIndexOf("DistanceLine", StringComparison.OrdinalIgnoreCase) >= 0) is not ChartTrendLine distanceLine) return;

            if (updatedChartObject == mainLine)
            {
                distanceLine.Time1 = mainLine.Time2;
                distanceLine.Y1 = mainLine.Y2;
            }
            else if (updatedChartObject == distanceLine)
            {
                mainLine.Time2 = distanceLine.Time1;
                mainLine.Y2 = distanceLine.Y1;
            }

            var verticalLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.VerticalLine)
                .Cast<ChartVerticalLine>().ToArray();

            UpdateFibonacciLevels(chart, mainLine, distanceLine, verticalLines);
        }

        protected override void OnDrawingStopped()
        {
            _mainLine = null;
            _distanceLine = null;
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 1)
            {
                var mainLineName = GetObjectName("MainLine");

                _mainLine = obj.Chart.DrawTrendLine(mainLineName, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    Color, 1, LineStyle.Dots);

                _mainLine.IsInteractive = true;
            }
            else if (MouseUpNumber == 2 && _mainLine != null)
            {
                var distanceLineName = GetObjectName("DistanceLine");

                _distanceLine = obj.Chart.DrawTrendLine(distanceLineName, _mainLine.Time2, _mainLine.Y2, obj.TimeValue,
                    obj.YValue, Color, 1, LineStyle.Dots);

                _distanceLine.IsInteractive = true;
            }
            else
            {
                DrawFibonacciLevels(obj.Chart);

                FinishDrawing();
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            ChartTrendLine line = null;

            if (MouseUpNumber == 1)
                line = _mainLine;
            else if (MouseUpNumber == 2) line = _distanceLine;

            if (line == null) return;

            line.Time2 = obj.TimeValue;
            line.Y2 = obj.YValue;
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_mainLine, _distanceLine};
        }

        private void DrawFibonacciLevels(Chart chart)
        {
            var startBarIndex = chart.Bars.GetBarIndex(_distanceLine.Time2, chart.Symbol);

            var barsNumber = _mainLine.GetBarsNumber(chart.Bars, chart.Symbol);

            foreach (var level in _settings.Levels)
            {
                var levelLineName = GetObjectName($"Level_{level.Percent.ToString(CultureInfo.InvariantCulture)}");

                var barsAmount = barsNumber * level.Percent;

                var lineBarIndex = _mainLine.Time2 > _mainLine.Time1
                    ? startBarIndex + barsAmount
                    : startBarIndex - barsAmount;

                var lineTime = chart.Bars.GetOpenTime(lineBarIndex, chart.Symbol);

                var levelLine = chart.DrawVerticalLine(levelLineName, lineTime, level.LineColor, level.Thickness,
                    level.Style);

                levelLine.IsInteractive = true;

                levelLine.IsLocked = true;
            }
        }

        private void UpdateFibonacciLevels(Chart chart, ChartTrendLine mainLine, ChartTrendLine distanceLine,
            ChartVerticalLine[] verticalLines)
        {
            var startBarIndex = chart.Bars.GetBarIndex(distanceLine.Time2, chart.Symbol);

            var barsNumber = mainLine.GetBarsNumber(chart.Bars, chart.Symbol);

            foreach (var verticalLine in verticalLines)
            {
                if (!double.TryParse(verticalLine.Name.Split('_').Last(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out var lineLevelPercent)) continue;

                var level = _settings.Levels.FirstOrDefault(iLevel => iLevel.Percent == lineLevelPercent);

                if (level == null) continue;

                var barsAmount = barsNumber * level.Percent;

                var lineBarIndex = mainLine.Time2 > mainLine.Time1
                    ? startBarIndex + barsAmount
                    : startBarIndex - barsAmount;

                verticalLine.Time = chart.Bars.GetOpenTime(lineBarIndex, chart.Symbol);
            }
        }
    }
}