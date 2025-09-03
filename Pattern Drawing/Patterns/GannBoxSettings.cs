using cAlgo.API;
using cAlgo.Plugins;

namespace cAlgo.Patterns
{
    public class GannBoxSettings
    {
        private readonly Settings _settings;

        public GannBoxSettings(Settings settings)
        {
            _settings = settings;
        }

        public int RectangleThickness => _settings.GannBoxRectangleThickness;

        public LineStyle RectangleStyle => _settings.GannBoxRectangleStyle;

        public Color RectangleColor => _settings.GannBoxRectangleColor;

        public int PriceLevelsThickness => _settings.GannBoxPriceLevelsThickness;

        public LineStyle PriceLevelsStyle => _settings.GannBoxPriceLevelsStyle;

        public Color PriceLevelsColor => _settings.GannBoxPriceLevelsColor;

        public int TimeLevelsThickness => _settings.GannBoxTimeLevelsThickness;

        public LineStyle TimeLevelsStyle => _settings.GannBoxTimeLevelsStyle;

        public Color TimeLevelsColor => _settings.GannBoxTimeLevelsColor;
    }
}