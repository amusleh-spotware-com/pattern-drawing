using System;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class SchiffPitchforkPattern : PatternBase
    {
        private readonly SchiffPitchforkPatternSettings _settings;

        private ChartTrendLine _handleLine;
        private ChartTrendLine _medianLine;
        private ChartTrendLine _schiffLine;

        public SchiffPitchforkPattern(PatternConfig config, SchiffPitchforkPatternSettings settings) : base(
            "Schiff Pitchfork", config)
        {
            _settings = settings;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            var trendLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine)
                .Cast<ChartTrendLine>().ToArray();

            var schiffLine = trendLines.FirstOrDefault(iObject =>
                iObject.Name.Split('_').Last().Equals("SchiffLine", StringComparison.InvariantCultureIgnoreCase));

            if (schiffLine == null) return;

            var handleLine = trendLines.FirstOrDefault(iObject =>
                iObject.Name.Split('_').Last().Equals("HandleLine", StringComparison.InvariantCultureIgnoreCase));

            if (handleLine == null) return;

            var medianLine = trendLines.FirstOrDefault(iObject =>
                iObject.Name.Split('_').Last().Equals("MedianLine", StringComparison.InvariantCultureIgnoreCase));

            if (medianLine == null) return;

            if (updatedChartObject != schiffLine && updatedChartObject != handleLine) return;

            if (updatedChartObject == schiffLine)
                UpdateHandleLine(handleLine, schiffLine);
            else if (updatedChartObject == handleLine) UpdateSchiffLine(handleLine, schiffLine);

            UpdateMedianLine(chart, medianLine, schiffLine, handleLine);

            DrawPercentLevels(chart, medianLine, handleLine, id);
        }

        protected override void OnDrawingStopped()
        {
            _medianLine = null;
            _handleLine = null;
            _schiffLine = null;
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 3)
            {
                FinishDrawing();

                return;
            }

            if (_schiffLine == null)
            {
                var name = GetObjectName("SchiffLine");

                _schiffLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    _settings.MedianLine.LineColor, _settings.MedianLine.Thickness, _settings.MedianLine.Style);

                _schiffLine.IsInteractive = true;
            }
            else if (_handleLine == null)
            {
                var name = GetObjectName("HandleLine");

                _handleLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    _settings.MedianLine.LineColor, _settings.MedianLine.Thickness, _settings.MedianLine.Style);

                _handleLine.IsInteractive = true;

                var medianLineName = GetObjectName("MedianLine");

                _medianLine = obj.Chart.DrawTrendLine(medianLineName, _schiffLine.Time1, _schiffLine.Y1, _schiffLine.Time2,
                    _handleLine.Y2, _settings.MedianLine.LineColor, _settings.MedianLine.Thickness,
                    _settings.MedianLine.Style);

                _medianLine.IsInteractive = true;
                _medianLine.IsLocked = true;
                _medianLine.ExtendToInfinity = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (_schiffLine == null) return;

            if (_handleLine == null)
            {
                _schiffLine.Time2 = obj.TimeValue;
                _schiffLine.Y2 = obj.YValue;
            }
            else
            {
                _handleLine.Time2 = obj.TimeValue;
                _handleLine.Y2 = obj.YValue;

                UpdateMedianLine(obj.Chart, _medianLine, _schiffLine, _handleLine);

                DrawPercentLevels(obj.Chart, _medianLine, _handleLine, Id);
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {_schiffLine, _handleLine};
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

        private void UpdateMedianLine(Chart chart, ChartTrendLine medianLine, ChartTrendLine schiffLine, ChartTrendLine handleLine)
        {
            medianLine.Time1 = schiffLine.Time1;
            medianLine.Y1 = schiffLine.GetBottomPrice() + schiffLine.GetPriceDelta() / 2;

            var handleLineStartBarIndex = handleLine.GetStartBarIndex(chart.Bars, chart.Symbol);
            var handleLineBarsNumber = handleLine.GetBarsNumber(chart.Bars, chart.Symbol);

            medianLine.Time2 = chart.Bars.GetOpenTime(handleLineStartBarIndex + handleLineBarsNumber / 2, chart.Symbol);
            medianLine.Y2 = handleLine.GetBottomPrice() + handleLine.GetPriceDelta() / 2;
        }

        private void UpdateHandleLine(ChartTrendLine handleLine, ChartTrendLine schiffLine)
        {
            handleLine.Time1 = schiffLine.Time2;
            handleLine.Y1 = schiffLine.Y2;
        }

        private void UpdateSchiffLine(ChartTrendLine handleLine, ChartTrendLine schiffLine)
        {
            schiffLine.Time2 = handleLine.Time1;
            schiffLine.Y2 = handleLine.Y1;
        }
    }
}