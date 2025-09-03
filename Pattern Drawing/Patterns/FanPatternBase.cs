using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public abstract class FanPatternBase : PatternBase
    {
        protected FanPatternBase(string name, PatternConfig config) : base(name, config)
        {
        }

        protected Dictionary<double, ChartTrendLine> SideFanLines { get; } = new();

        protected ChartTrendLine MainFanLine { get; private set; }

        protected abstract SideFanSettings[] SideFanSettings { get; }

        protected abstract FanSettings MainFanSettings { get; }

        protected bool CallStopDrawing { get; set; } = true;

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.TrendLine) return;

            var trendLines = patternObjects.Where(iObject => iObject.ObjectType == ChartObjectType.TrendLine)
                .Cast<ChartTrendLine>().ToArray();

            var mainFan = trendLines.First(iLine =>
                iLine.Name.IndexOf("MainFan", StringComparison.OrdinalIgnoreCase) > -1);

            var sideFans = trendLines
                .Where(iLine => iLine.Name.IndexOf("SideFan", StringComparison.OrdinalIgnoreCase) > -1)
                .ToDictionary(iLine => double.Parse(iLine.Name.Split('_').Last(), CultureInfo.InvariantCulture));

            UpdateSideFans(chart, mainFan, sideFans);
        }

        protected virtual void UpdateSideFans(Chart chart, ChartTrendLine mainFan, Dictionary<double, ChartTrendLine> sideFans)
        {
            var startBarIndex = mainFan.GetStartBarIndex(chart.Bars, chart.Symbol);
            var endBarIndex = mainFan.GetEndBarIndex(chart.Bars, chart.Symbol);

            var barsNumber = mainFan.GetBarsNumber(chart.Bars, chart.Symbol);

            var mainFanPriceDelta = mainFan.GetPriceDelta();

            for (var iFan = 0; iFan < SideFanSettings.Length; iFan++)
            {
                var fanSettings = SideFanSettings[iFan];

                double y2;
                DateTime time2;

                if (fanSettings.Percent < 0)
                {
                    var yAmount = mainFanPriceDelta * Math.Abs(fanSettings.Percent);

                    y2 = mainFan.Y2 > mainFan.Y1 ? mainFan.Y2 - yAmount : mainFan.Y2 + yAmount;

                    time2 = mainFan.Time2;
                }
                else
                {
                    y2 = mainFan.Y2;

                    var barsPercent = barsNumber * fanSettings.Percent;

                    var barIndex = mainFan.Time2 > mainFan.Time1
                        ? endBarIndex - barsPercent
                        : startBarIndex + barsPercent;

                    time2 = chart.Bars.GetOpenTime(barIndex, chart.Symbol);
                }


                if (!sideFans.TryGetValue(fanSettings.Percent, out var fanLine)) continue;

                fanLine.Time1 = mainFan.Time1;
                fanLine.Time2 = time2;

                fanLine.Y1 = mainFan.Y1;
                fanLine.Y2 = y2;
            }
        }

        protected override void OnDrawingStopped()
        {
            MainFanLine = null;

            SideFanLines.Clear();
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2)
            {
                if (CallStopDrawing) FinishDrawing();

                return;
            }

            if (MainFanLine == null)
            {
                var name = GetObjectName("MainFan");

                MainFanLine = obj.Chart.DrawTrendLine(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                    MainFanSettings.Color, MainFanSettings.Thickness, MainFanSettings.Style);

                MainFanLine.IsInteractive = true;
                MainFanLine.ExtendToInfinity = true;
            }
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MainFanLine == null) return;

            MainFanLine.Time2 = obj.TimeValue;
            MainFanLine.Y2 = obj.YValue;

            DrawSideFans(obj.Chart, MainFanLine);
        }

        protected virtual void DrawSideFans(Chart chart, ChartTrendLine mainFan)
        {
            var startBarIndex = mainFan.GetStartBarIndex(chart.Bars, chart.Symbol);
            var endBarIndex = mainFan.GetEndBarIndex(chart.Bars, chart.Symbol);

            var barsNumber = mainFan.GetBarsNumber(chart.Bars, chart.Symbol);

            var mainFanPriceDelta = mainFan.GetPriceDelta();

            for (var iFan = 0; iFan < SideFanSettings.Length; iFan++)
            {
                var fanSettings = SideFanSettings[iFan];

                double y2;
                DateTime time2;

                if (fanSettings.Percent < 0)
                {
                    var yAmount = mainFanPriceDelta * Math.Abs(fanSettings.Percent);

                    y2 = mainFan.Y2 > mainFan.Y1 ? mainFan.Y2 - yAmount : mainFan.Y2 + yAmount;

                    time2 = mainFan.Time2;
                }
                else
                {
                    y2 = mainFan.Y2;

                    var barsPercent = barsNumber * fanSettings.Percent;

                    var barIndex = mainFan.Time2 > mainFan.Time1
                        ? endBarIndex - barsPercent
                        : startBarIndex + barsPercent;

                    time2 = chart.Bars.GetOpenTime(barIndex, chart.Symbol);
                }

                var objectName = GetObjectName($"SideFan_{fanSettings.Percent}");

                var trendLine = chart.DrawTrendLine(objectName, mainFan.Time1, mainFan.Y1, time2, y2, fanSettings.Color,
                    fanSettings.Thickness, fanSettings.Style);

                trendLine.IsInteractive = true;
                trendLine.IsLocked = true;
                trendLine.ExtendToInfinity = true;

                SideFanLines[fanSettings.Percent] = trendLine;
            }
        }

        protected override ChartObject[] GetFrontObjects()
        {
            return new ChartObject[] {MainFanLine};
        }
    }
}