using System.Collections.Generic;
using System.Linq;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class PitchfanPatternSettings
{
    private readonly Settings _settings;

    public PitchfanPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public FanSettings MainFanSettings => new()
    {
        Color = _settings.PitchfanMedianColor,
        Style = _settings.PitchfanMedianStyle,
        Thickness = _settings.PitchfanMedianThickness
    };

    public SideFanSettings[] SideFanSettings
    {
        get
        {
            var result = new List<SideFanSettings>();

            if (_settings.ShowFirstPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.FirstPitchfanPercent,
                    Color = _settings.FirstPitchfanColor,
                    Style = _settings.FirstPitchfanStyle,
                    Thickness = _settings.FirstPitchfanThickness
                });

            if (_settings.ShowSecondPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.SecondPitchfanPercent,
                    Color = _settings.SecondPitchfanColor,
                    Style = _settings.SecondPitchfanStyle,
                    Thickness = _settings.SecondPitchfanThickness
                });

            if (_settings.ShowThirdPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.ThirdPitchfanPercent,
                    Color = _settings.ThirdPitchfanColor,
                    Style = _settings.ThirdPitchfanStyle,
                    Thickness = _settings.ThirdPitchfanThickness
                });

            if (_settings.ShowFourthPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.FourthPitchfanPercent,
                    Color = _settings.FourthPitchfanColor,
                    Style = _settings.FourthPitchfanStyle,
                    Thickness = _settings.FourthPitchfanThickness
                });

            if (_settings.ShowFifthPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.FifthPitchfanPercent,
                    Color = _settings.FifthPitchfanColor,
                    Style = _settings.FifthPitchfanStyle,
                    Thickness = _settings.FifthPitchfanThickness
                });

            if (_settings.ShowSixthPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.SixthPitchfanPercent,
                    Color = _settings.SixthPitchfanColor,
                    Style = _settings.SixthPitchfanStyle,
                    Thickness = _settings.SixthPitchfanThickness
                });

            if (_settings.ShowSeventhPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.SeventhPitchfanPercent,
                    Color = _settings.SeventhPitchfanColor,
                    Style = _settings.SeventhPitchfanStyle,
                    Thickness = _settings.SeventhPitchfanThickness
                });

            if (_settings.ShowEighthPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.EighthPitchfanPercent,
                    Color = _settings.EighthPitchfanColor,
                    Style = _settings.EighthPitchfanStyle,
                    Thickness = _settings.EighthPitchfanThickness
                });

            if (_settings.ShowNinthPitchfan)
                result.Add(new SideFanSettings
                {
                    Percent = _settings.NinthPitchfanPercent,
                    Color = _settings.NinthPitchfanColor,
                    Style = _settings.NinthPitchfanStyle,
                    Thickness = _settings.NinthPitchfanThickness
                });

            result.ToList().ForEach(iSettings => result.Add(new SideFanSettings
            {
                Percent = -iSettings.Percent,
                Color = iSettings.Color,
                Style = iSettings.Style,
                Thickness = iSettings.Thickness
            }));

            return result.ToArray();
        }
    }
}