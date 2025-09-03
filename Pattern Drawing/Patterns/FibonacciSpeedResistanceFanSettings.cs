using cAlgo.API;
using cAlgo.Plugins;

namespace cAlgo.Patterns
{
    public class FibonacciSpeedResistanceFanSettings
    {
        private readonly Settings _settings;

        public FibonacciSpeedResistanceFanSettings(Settings settings)
        {
            _settings = settings;
        }

        public int RectangleThickness => _settings.FibonacciSpeedResistanceFanRectangleThickness;

        public LineStyle RectangleStyle => _settings.FibonacciSpeedResistanceFanRectangleStyle;

        public Color RectangleColor => _settings.FibonacciSpeedResistanceFanRectangleColor;

        public int PriceLevelsThickness => _settings.FibonacciSpeedResistanceFanPriceLevelsThickness;

        public LineStyle PriceLevelsStyle => _settings.FibonacciSpeedResistanceFanPriceLevelsStyle;

        public Color PriceLevelsColor => _settings.FibonacciSpeedResistanceFanPriceLevelsColor;

        public int TimeLevelsThickness => _settings.FibonacciSpeedResistanceFanTimeLevelsThickness;

        public LineStyle TimeLevelsStyle => _settings.FibonacciSpeedResistanceFanTimeLevelsStyle;

        public Color TimeLevelsColor => _settings.FibonacciSpeedResistanceFanTimeLevelsColor;

        public int ExtendedLinesThickness => _settings.FibonacciSpeedResistanceFanExtendedLinesThickness;

        public LineStyle ExtendedLinesStyle => _settings.FibonacciSpeedResistanceFanExtendedLinesStyle;

        public Color ExtendedLinesColor => _settings.FibonacciSpeedResistanceFanExtendedLinesColor;

        public bool ShowPriceLevels => _settings.FibonacciSpeedResistanceFanShowPriceLevels;

        public bool ShowTimeLevels => _settings.FibonacciSpeedResistanceFanShowTimeLevels;

        public FanSettings MainFanSettings => new()
        {
            Color = _settings.FibonacciSpeedResistanceFanMainFanColor,
            Style = _settings.FibonacciSpeedResistanceFanMainFanStyle,
            Thickness = _settings.FibonacciSpeedResistanceFanMainFanThickness
        };

        public SideFanSettings[] SideFanSettings => new[]
        {
            new SideFanSettings
            {
                Name = "1x2",
                Percent = _settings.FibonacciSpeedResistanceFanFirstFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFirstFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFirstFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFirstFanThickness
            },
            new SideFanSettings
            {
                Name = "1x3",
                Percent = _settings.FibonacciSpeedResistanceFanSecondFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanSecondFanColor,
                Style = _settings.FibonacciSpeedResistanceFanSecondFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanSecondFanThickness
            },
            new SideFanSettings
            {
                Name = "1x4",
                Percent = _settings.FibonacciSpeedResistanceFanThirdFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanThirdFanColor,
                Style = _settings.FibonacciSpeedResistanceFanThirdFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanThirdFanThickness
            },
            new SideFanSettings
            {
                Name = "1x8",
                Percent = _settings.FibonacciSpeedResistanceFanFourthFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFourthFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFourthFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFourthFanThickness
            },
            new SideFanSettings
            {
                Name = "1x9",
                Percent = _settings.FibonacciSpeedResistanceFanFifthFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFifthFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFifthFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFifthFanThickness
            },
            new SideFanSettings
            {
                Name = "2x1",
                Percent = -_settings.FibonacciSpeedResistanceFanFirstFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFirstFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFirstFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFirstFanThickness
            },
            new SideFanSettings
            {
                Name = "3x1",
                Percent = -_settings.FibonacciSpeedResistanceFanSecondFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanSecondFanColor,
                Style = _settings.FibonacciSpeedResistanceFanSecondFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanSecondFanThickness
            },
            new SideFanSettings
            {
                Name = "4x1",
                Percent = -_settings.FibonacciSpeedResistanceFanThirdFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanThirdFanColor,
                Style = _settings.FibonacciSpeedResistanceFanThirdFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanThirdFanThickness
            },
            new SideFanSettings
            {
                Name = "8x1",
                Percent = -_settings.FibonacciSpeedResistanceFanFourthFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFourthFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFourthFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFourthFanThickness
            },
            new SideFanSettings
            {
                Name = "9x1",
                Percent = -_settings.FibonacciSpeedResistanceFanFifthFanPercent,
                Color = _settings.FibonacciSpeedResistanceFanFifthFanColor,
                Style = _settings.FibonacciSpeedResistanceFanFifthFanStyle,
                Thickness = _settings.FibonacciSpeedResistanceFanFifthFanThickness
            }
        };
    }
}