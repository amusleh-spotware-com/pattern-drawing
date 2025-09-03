using cAlgo.API;
using cAlgo.Plugins;

namespace cAlgo.Patterns
{
    public class MeasureSettings
    {
        private readonly Settings _settings;

        public MeasureSettings(Settings settings)
        {
            _settings = settings;
        }

        public int Thickness => _settings.MeasureThickness;

        public LineStyle Style => _settings.MeasureStyle;

        public Color UpColor => _settings.MeasureUpColor;

        public Color DownColor => _settings.MeasureDownColor;

        public Color TextColor => _settings.MeasureTextColor;

        public bool IsFilled => _settings.MeasureIsFilled;

        public int FontSize => _settings.MeasureFontSize;

        public bool IsTextBold => _settings.MeasureIsTextBold;
    }
}