using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class OriginalPitchforkPattern : PatternBase
    {
        private readonly Dictionary<double, ChartTrendLine> _horizontalTrendLines = new();
        private readonly OriginalPitchforkPatternSettings _settings;
        private readonly Dictionary<double, ChartTrendLine> _verticalTrendLines = new();

        private ChartTrendLine _handleLine;
        private ChartTrendLine _medianLine;

        public OriginalPitchforkPattern(PatternConfig config, OriginalPitchforkPatternSettings settings) : base(
            "Original Pitchfork", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            var trendLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine)
                .Cast<ChartTrendLine>().ToArray();

            var medianLine = trendLines.FirstOrDefault(iObject =>
                iObject.Name.Split('_').Last().Equals("MedianLine", StringComparison.InvariantCultureIgnoreCase));

            if (medianLine == null) return;

            var handleLine = trendLines.FirstOrDefault(iObject =>
                iObject.Name.Split('_').Last().Equals("HandleLine", StringComparison.InvariantCultureIgnoreCase));

            if (handleLine == null) return;

            if (updatedChartObject != medianLine && updatedChartObject != handleLine) return;

            UpdateMedianLine(chart, medianLine, handleLine);

            DrawPercentLevels(chart, medianLine, handleLine, id);
        }

        protected override void OnDrawingStopped()
        {
            _medianLine = null;
            _handleLine = null;

            _horizontalTrendLines.Clear();
            _verticalTrendLines.Clear();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 3)
            {
                FinishDrawing();

                return;
            }

            if (_medianLine == null)
            {
                var name = GetObjectName("MedianLine");

                _medianLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    _settings.MedianLine.LineColor, _settings.MedianLine.Thickness, _settings.MedianLine.Style);

                _medianLine.IsInteractive = true;
                _medianLine.ExtendToInfinity = true;
            }
            else if (_handleLine == null)
            {
                var name = GetObjectName("HandleLine");

                _handleLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    _settings.MedianLine.LineColor, _settings.MedianLine.Thickness, _settings.MedianLine.Style);

                _handleLine.IsInteractive = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (_medianLine == null) return;

            if (_handleLine == null)
            {
                _medianLine.Time2 = obj.TimeValue;
                _medianLine.Y2 = obj.YValue;
            }
            else
            {
                _handleLine.Time2 = obj.TimeValue;
                _handleLine.Y2 = obj.YValue;

                UpdateMedianLine(obj.Chart, _medianLine, _handleLine);

                DrawPercentLevels(obj.Chart, _medianLine, _handleLine, Id);
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_medianLine, _handleLine};
        }

        private void DrawPercentLevels(Chart chart, ChartTrendLine medianLine, ChartTrendLine handleLine, long id)
        {
            var medianLineSecondBarIndex = chart.Bars.GetBarIndex(medianLine.Time2, chart.Symbol);
            var handleLineFirstBarIndex = chart.Bars.GetBarIndex(handleLine.Time1, chart.Symbol);

            var barsDelta = Math.Abs(medianLineSecondBarIndex - handleLineFirstBarIndex);
            var lengthInMinutes = Math.Abs((medianLine.Time2 - handleLine.Time1).TotalMinutes) * 2;
            var priceDelta = handleLine.GetPriceDelta() / 2;

            var handleLineSlope = handleLine.GetSlope();

            foreach (var levelSettings in _settings.Levels)
            {
                DrawLevel(chart, medianLine, medianLineSecondBarIndex, barsDelta, lengthInMinutes, priceDelta, handleLineSlope,
                    levelSettings.Value.Percent, levelSettings.Value.LineColor, id);
                DrawLevel(chart, medianLine, medianLineSecondBarIndex, barsDelta, lengthInMinutes, priceDelta, handleLineSlope,
                    -levelSettings.Value.Percent, levelSettings.Value.LineColor, id);
            }
        }

        private void DrawLevel(Chart chart, ChartTrendLine medianLine, double medianLineSecondBarIndex, double barsDelta,
            double lengthInMinutes, double priceDelta, double handleLineSlope, double percent, Color lineColor, long id)
        {
            var barsPercent = barsDelta * percent;

            var firstBarIndex = handleLineSlope > 0
                ? medianLineSecondBarIndex + barsPercent
                : medianLineSecondBarIndex - barsPercent;
            var firstTime = chart.Bars.GetOpenTime(firstBarIndex, chart.Symbol);
            var firstPrice = medianLine.Y2 + priceDelta * percent;

            var secondTime = medianLine.Time1 > medianLine.Time2
                ? firstTime.AddMinutes(-lengthInMinutes)
                : firstTime.AddMinutes(lengthInMinutes);

            var priceDistanceWithMediumLine =
                Math.Abs(medianLine.CalculateY(firstTime) - medianLine.CalculateY(secondTime));

            var secondPrice = medianLine.Y2 > medianLine.Y1
                ? firstPrice + priceDistanceWithMediumLine
                : firstPrice - priceDistanceWithMediumLine;

            var name = GetObjectName($"Level_{percent.ToString(CultureInfo.InvariantCulture)}", id: id);

            var line = chart.DrawTrendLine(name, firstTime, firstPrice, secondTime, secondPrice, lineColor);

            line.ExtendToInfinity = true;
            line.IsInteractive = true;
            line.IsLocked = true;
        }

        private void UpdateMedianLine(Chart chart, ChartTrendLine medianLine, ChartTrendLine handleLine)
        {
            var handleLineStartBarIndex = handleLine.GetStartBarIndex(chart.Bars, chart.Symbol);
            var handleLineBarsNumber = handleLine.GetBarsNumber(chart.Bars, chart.Symbol);

            medianLine.Time2 = chart.Bars.GetOpenTime(handleLineStartBarIndex + handleLineBarsNumber / 2, chart.Symbol);
            medianLine.Y2 = handleLine.GetBottomPrice() + handleLine.GetPriceDelta() / 2;
        }
    }
}