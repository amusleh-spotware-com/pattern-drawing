using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class PitchfanPattern : FanPatternBase
    {
        private readonly PitchfanPatternSettings _settings;
        private ChartTrendLine _handleLine;

        public PitchfanPattern(PatternConfig config, PitchfanPatternSettings settings) :
            base("Pitchfan", config)
        {
            _settings = settings;
            CallStopDrawing = false;
        }

        protected override SideFanSettings[] SideFanSettings => _settings.SideFanSettings;
        protected override FanSettings MainFanSettings => _settings.MainFanSettings;

        protected override void OnDrawingStopped()
        {
            _handleLine = null;

            base.OnDrawingStopped();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber < 2)
            {
                base.OnMouseUp(obj);

                return;
            }

            if (MouseUpNumber == 2)
            {
                var name = GetObjectName("HandleLine");

                _handleLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    MainFanSettings.Color, MainFanSettings.Thickness, MainFanSettings.Style);

                _handleLine.IsInteractive = true;

                base.OnMouseUp(obj);
            }
            else
            {
                FinishDrawing();
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber < 2 || _handleLine == null)
            {
                base.OnMouseMove(obj);

                return;
            }

            _handleLine.Time2 = obj.TimeValue;
            _handleLine.Y2 = obj.YValue;

            var handleLineBarsNumber = _handleLine.GetBarsNumber(obj.Chart.Bars, obj.Chart.Symbol);

            var mainFanLineSecondBarIndex =
                _handleLine.GetStartBarIndex(obj.Chart.Bars, obj.Chart.Symbol) + handleLineBarsNumber / 2;

            MainFanLine.Time2 = obj.Chart.Bars.GetOpenTime(mainFanLineSecondBarIndex, obj.Chart.Symbol);
            MainFanLine.Y2 = _handleLine.GetBottomPrice() + _handleLine.GetPriceDelta() / 2;

            DrawSideFans(obj.Chart, MainFanLine);
        }

        protected override void DrawSideFans(Chart chart, ChartTrendLine mainFan)
        {
            if (MouseUpNumber < 2) return;

            var endBarIndex = chart.Bars.GetBarIndex(mainFan.Time2, chart.Symbol);

            var barsDelta = _handleLine.GetBarsNumber(chart.Bars, chart.Symbol) / 2;
            var priceDelta = _handleLine.GetPriceDelta() / 2;

            var slope = _handleLine.GetSlope();

            for (var iFan = 0; iFan < SideFanSettings.Length; iFan++)
            {
                var fanSettings = SideFanSettings[iFan];

                var secondBarIndex = slope > 0
                    ? endBarIndex + barsDelta * fanSettings.Percent
                    : endBarIndex - barsDelta * fanSettings.Percent;

                var secondTime = chart.Bars.GetOpenTime(secondBarIndex, chart.Symbol);

                var secondPrice = mainFan.Y2 + priceDelta * fanSettings.Percent;

                var objectName = GetObjectName($"SideFan_{fanSettings.Percent}");

                var trendLine = chart.DrawTrendLine(objectName, mainFan.Time1, mainFan.Y1, secondTime, secondPrice,
                    fanSettings.Color, fanSettings.Thickness, fanSettings.Style);

                trendLine.IsInteractive = true;
                trendLine.IsLocked = true;
                trendLine.ExtendToInfinity = true;

                SideFanLines[fanSettings.Percent] = trendLine;
            }
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            var trendLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine)
                .Cast<ChartTrendLine>().ToArray();

            var mainFan = trendLines.FirstOrDefault(iLine =>
                iLine.Name.IndexOf("MainFan", StringComparison.OrdinalIgnoreCase) > -1);

            var handleLine = trendLines.FirstOrDefault(iLine =>
                iLine.Name.IndexOf("HandleLine", StringComparison.OrdinalIgnoreCase) > -1);

            if (mainFan is null || handleLine is null || (updatedChartObject != mainFan && updatedChartObject != handleLine)) return;

            if (updatedChartObject == mainFan)
                UpdateHandleLine(chart, handleLine, mainFan);
            else if (updatedChartObject == handleLine) UpdateMainFan(chart, handleLine, mainFan);

            var fans = trendLines.Where(iLine => iLine.Name.IndexOf("SideFan", StringComparison.OrdinalIgnoreCase) > -1)
                .ToDictionary(iLine => double.Parse(iLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            if (fans.Count > 0) UpdateFans(chart, mainFan, handleLine, fans);
        }

        private void UpdateHandleLine(Chart chart, ChartTrendLine handleLine, ChartTrendLine mainFan)
        {
            var mainFanSecondBarIndex = chart.Bars.GetBarIndex(mainFan.Time2, chart.Symbol);
            var handleLineHalfBarsNumber = handleLine.GetBarsNumber(chart.Bars, chart.Symbol) / 2;

            var firstBarIndex = mainFanSecondBarIndex - handleLineHalfBarsNumber;
            var secondBarIndex = mainFanSecondBarIndex + handleLineHalfBarsNumber;

            handleLine.Time1 = chart.Bars.GetOpenTime(firstBarIndex, chart.Symbol);
            handleLine.Time2 = chart.Bars.GetOpenTime(secondBarIndex, chart.Symbol);

            var handleLineHalfPriceDelta = handleLine.GetPriceDelta() / 2;

            var handleLineSlope = handleLine.GetSlope();

            handleLine.Y1 = handleLineSlope > 0
                ? mainFan.Y2 - handleLineHalfPriceDelta
                : mainFan.Y2 + handleLineHalfPriceDelta;
            handleLine.Y2 = handleLineSlope > 0
                ? mainFan.Y2 + handleLineHalfPriceDelta
                : mainFan.Y2 - handleLineHalfPriceDelta;
        }

        private void UpdateMainFan(Chart chart, ChartTrendLine handleLine, ChartTrendLine mainFan)
        {
            var handleLineBarsNumber = handleLine.GetBarsNumber(chart.Bars, chart.Symbol);

            var mainFanLineSecondBarIndex =
                handleLine.GetStartBarIndex(chart.Bars, chart.Symbol) + handleLineBarsNumber / 2;

            mainFan.Time2 = chart.Bars.GetOpenTime(mainFanLineSecondBarIndex, chart.Symbol);
            mainFan.Y2 = handleLine.GetBottomPrice() + handleLine.GetPriceDelta() / 2;
        }

        private void UpdateFans(Chart chart, ChartTrendLine mainFan, ChartTrendLine handleLine,
            Dictionary<double, ChartTrendLine> fans)
        {
            var endBarIndex = chart.Bars.GetBarIndex(mainFan.Time2, chart.Symbol);

            var barsDelta = handleLine.GetBarsNumber(chart.Bars, chart.Symbol) / 2;
            var priceDelta = handleLine.GetPriceDelta() / 2;

            var slope = handleLine.GetSlope();

            foreach (var fan in fans)
            {
                var fanSettings = SideFanSettings.FirstOrDefault(iSettings => iSettings.Percent == fan.Key);

                if (fanSettings == null) continue;

                var secondBarIndex = slope > 0
                    ? endBarIndex + barsDelta * fanSettings.Percent
                    : endBarIndex - barsDelta * fanSettings.Percent;

                var secondTime = chart.Bars.GetOpenTime(secondBarIndex, chart.Symbol);

                var secondPrice = mainFan.Y2 + priceDelta * fanSettings.Percent;

                var fanLine = fan.Value;

                fanLine.Time1 = mainFan.Time1;
                fanLine.Time2 = secondTime;

                fanLine.Y1 = mainFan.Y1;
                fanLine.Y2 = secondPrice;
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {MainFanLine, _handleLine};
        }
    }
}