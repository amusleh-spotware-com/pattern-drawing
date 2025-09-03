using System;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class FibonacciTimeZonePattern : PatternBase
    {
        private readonly FibonacciTimeZonePatternSettings _settings;

        private ChartTrendLine _controllerLine;

        public FibonacciTimeZonePattern(PatternConfig config, FibonacciTimeZonePatternSettings settings) :
            base("Fibonacci Time Zone", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject is not ChartTrendLine controllerLine ||
                controllerLine.Name.LastIndexOf("ControllerLine", StringComparison.OrdinalIgnoreCase) < 0) return;

            var startBarIndex = chart.Bars.GetBarIndex(controllerLine.Time1, chart.Symbol);

            var barsNumber = controllerLine.GetBarsNumber(chart.Bars, chart.Symbol);

            var verticalLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.VerticalLine)
                .Cast<ChartVerticalLine>().ToArray();

            foreach (var verticalLine in verticalLines)
            {
                if (!double.TryParse(verticalLine.Name.Split('_').Last(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out var lineLevelPercent)) continue;

                var level = _settings.Levels.FirstOrDefault(iLevel => iLevel.Percent == lineLevelPercent);

                if (level == null) continue;

                var barsAmount = barsNumber * level.Percent;

                var lineBarIndex = controllerLine.Time2 > controllerLine.Time1
                    ? startBarIndex + barsAmount
                    : startBarIndex - barsAmount;

                verticalLine.Time = chart.Bars.GetOpenTime(lineBarIndex, chart.Symbol);
            }
        }

        protected override void OnDrawingStopped()
        {
            _controllerLine = null;
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2)
            {
                FinishDrawing();

                return;
            }

            var controllerLineName = GetObjectName("ControllerLine");

            _controllerLine = obj.Chart.DrawTrendLine(controllerLineName, obj.TimeValue, obj.YValue, obj.TimeValue,
                obj.YValue, Color, 1, LineStyle.Dots);

            _controllerLine.IsInteractive = true;
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (_controllerLine == null) return;

            _controllerLine.Time2 = obj.TimeValue;
            _controllerLine.Y2 = obj.YValue;

            var startBarIndex = obj.Chart.Bars.GetBarIndex(_controllerLine.Time1, obj.Chart.Symbol);

            var barsNumber = _controllerLine.GetBarsNumber(obj.Chart.Bars, obj.Chart.Symbol);

            foreach (var level in _settings.Levels)
            {
                var levelLineName = GetObjectName($"Level_{level.Percent.ToString(CultureInfo.InvariantCulture)}");

                var barsAmount = barsNumber * level.Percent;

                var lineBarIndex = _controllerLine.Time2 > _controllerLine.Time1
                    ? startBarIndex + barsAmount
                    : startBarIndex - barsAmount;

                var lineTime = obj.Chart.Bars.GetOpenTime(lineBarIndex, obj.Chart.Symbol);

                var levelLine = obj.Chart.DrawVerticalLine(levelLineName, lineTime, level.LineColor, level.Thickness,
                    level.Style);

                levelLine.IsInteractive = true;

                levelLine.IsLocked = true;
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_controllerLine};
        }
    }
}