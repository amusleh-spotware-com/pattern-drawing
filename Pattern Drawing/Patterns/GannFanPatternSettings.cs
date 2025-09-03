using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class GannFanPatternSettings
{
    private readonly Settings _settings;

    public GannFanPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public FanSettings MainFanSettings => new()
    {
        Color = _settings.GannFanOneColor,
        Thickness = _settings.GannFanOneThickness,
        Style = _settings.GannFanOneStyle,
    };

    public SideFanSettings[] SideFanSettings => new[]
    {
        new SideFanSettings
        {
            Name = "1x2",
            Percent = 0.416,
            Color = _settings.GannFanTwoColor,
            Style = _settings.GannFanTwoStyle,
            Thickness = _settings.GannFanTwoThickness
        },
        new SideFanSettings
        {
            Name = "1x3",
            Percent = 0.583,
            Color = _settings.GannFanThreeColor,
            Style = _settings.GannFanThreeStyle,
            Thickness = _settings.GannFanThreeThickness
        },
        new SideFanSettings
        {
            Name = "1x4",
            Percent = 0.666,
            Color = _settings.GannFanFourColor,
            Style = _settings.GannFanFourStyle,
            Thickness = _settings.GannFanFourThickness
        },
        new SideFanSettings
        {
            Name = "1x8",
            Percent = 0.833,
            Color = _settings.GannFanEightColor,
            Style = _settings.GannFanEightStyle,
            Thickness = _settings.GannFanEightThickness
        },
        new SideFanSettings
        {
            Name = "2x1",
            Percent = -0.416,
            Color = _settings.GannFanTwoColor,
            Style = _settings.GannFanTwoStyle,
            Thickness = _settings.GannFanTwoThickness
        },
        new SideFanSettings
        {
            Name = "3x1",
            Percent = -0.583,
            Color = _settings.GannFanThreeColor,
            Style = _settings.GannFanThreeStyle,
            Thickness = _settings.GannFanThreeThickness
        },
        new SideFanSettings
        {
            Name = "4x1",
            Percent = -0.666,
            Color = _settings.GannFanFourColor,
            Style = _settings.GannFanFourStyle,
            Thickness = _settings.GannFanFourThickness
        },
        new SideFanSettings
        {
            Name = "8x1",
            Percent = -0.833,
            Color = _settings.GannFanEightColor,
            Style = _settings.GannFanEightStyle,
            Thickness = _settings.GannFanEightThickness
        }
    };
}