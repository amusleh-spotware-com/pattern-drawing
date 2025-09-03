using System;
using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;

namespace cAlgo.Patterns
{
    public class MeasurePattern : PatternBase
    {
        private readonly MeasureSettings _settings;
        private ChartRectangle _rectangle;

        public MeasurePattern(PatternConfig config, MeasureSettings settings) : base("Measure", config) =>
            _settings = settings;

        protected override void OnDrawingStopped()
        {
            _rectangle = null;
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject.ObjectType != ChartObjectType.Rectangle) return;

            var rectangle = updatedChartObject as ChartRectangle;

            if (rectangle.Y1 > rectangle.Y2)
                rectangle.Color = _settings.DownColor;
            else
                rectangle.Color = _settings.UpColor;
        }

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2)
            {
                FinishDrawing();

                return;
            }

            if (_rectangle != null) return;
            
            var name = GetObjectName("Rectangle");

            _rectangle = obj.Chart.DrawRectangle(name, obj.TimeValue, obj.YValue, obj.TimeValue, obj.YValue,
                _settings.UpColor, _settings.Thickness, _settings.Style);

            _rectangle.IsInteractive = true;
            _rectangle.IsFilled = _settings.IsFilled;
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber > 1 || _rectangle == null) return;

            _rectangle.Time2 = obj.TimeValue;
            _rectangle.Y2 = obj.YValue;

            if (_rectangle.Y1 > _rectangle.Y2)
                _rectangle.Color = _settings.DownColor;
            else
                _rectangle.Color = _settings.UpColor;
        }

        protected override void DrawLabels(Chart chart)
        {
            if (_rectangle == null) return;

            DrawLabels(chart, _rectangle, Id);
        }

        private void DrawLabels(Chart chart, ChartRectangle rectangle, long id)
        {
            var label = DrawLabelText(chart, string.Empty, DateTime.UtcNow, 0, id, objectNameKey: "Measure",
                fontSize: _settings.FontSize, isBold: _settings.IsTextBold, color: _settings.TextColor);

            SetLabelText(chart, label, rectangle);
        }

        private void SetLabelText(Chart chart, ChartText label, ChartRectangle rectangle)
        {
            var priceDelta = rectangle.GetPriceDelta();
            var pricePercent = priceDelta / rectangle.Y1 * 100;

            if (rectangle.Y1 > rectangle.Y2)
            {
                label.Y = rectangle.GetBottomPrice();

                priceDelta *= -1;
                pricePercent *= -1;
            }
            else
            {
                var distance = priceDelta * 0.04;

                label.Y = rectangle.GetTopPrice() + distance;
            }

            var volume = rectangle.GetVolume(chart.Bars, chart.Symbol);

            var barsDelta = rectangle.GetBarsNumber(chart.Bars, chart.Symbol);

            var barIndex = rectangle.GetStartBarIndex(chart.Bars, chart.Symbol) + barsDelta / 3;

            var time = chart.Bars.GetOpenTime(barIndex, chart.Symbol);

            label.Text =
                $"Bars: {(int) barsDelta} | Time: {rectangle.GetTimeDelta()}\nPrice Delta: {Math.Round(priceDelta, chart.Symbol.Digits)} ({Math.Round(pricePercent, 2)}%)\nVolume: {volume}";
            label.Time = time;
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject chartObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            if (patternObjects.FirstOrDefault(iObject => iObject is ChartRectangle) is not ChartRectangle rectangle) return;

            var measureLabel =
                labels.FirstOrDefault(label => label.Name.EndsWith("Measure", StringComparison.OrdinalIgnoreCase));

            if (measureLabel == null)
                DrawLabels(chart, rectangle, id);
            else
                SetLabelText(chart, measureLabel, rectangle);
        }

        protected override ChartObject[] GetFrontObjects() => new ChartObject[] {_rectangle};
    }
}