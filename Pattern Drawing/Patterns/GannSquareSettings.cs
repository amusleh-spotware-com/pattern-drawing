using cAlgo.API;
using cAlgo.Plugins;

namespace cAlgo.Patterns
{
    public class GannSquareSettings
    {
        private readonly Settings _settings;

        public GannSquareSettings(Settings settings)
        {
            _settings = settings;
        }

        public int RectangleThickness => _settings.GannSquareRectangleThickness;

        public LineStyle RectangleStyle => _settings.GannSquareRectangleStyle;

        public Color RectangleColor => _settings.GannSquareRectangleColor;

        public int PriceLevelsThickness => _settings.GannSquarePriceLevelsThickness;

        public LineStyle PriceLevelsStyle => _settings.GannSquarePriceLevelsStyle;

        public Color PriceLevelsColor => _settings.GannSquarePriceLevelsColor;

        public int TimeLevelsThickness => _settings.GannSquareTimeLevelsThickness;

        public LineStyle TimeLevelsStyle => _settings.GannSquareTimeLevelsStyle;

        public Color TimeLevelsColor => _settings.GannSquareTimeLevelsColor;

        public int FansThickness => _settings.GannSquareFansThickness;

        public LineStyle FansStyle => _settings.GannSquareFansStyle;

        public Color FansColor => _settings.GannSquareFansColor;
    }
}