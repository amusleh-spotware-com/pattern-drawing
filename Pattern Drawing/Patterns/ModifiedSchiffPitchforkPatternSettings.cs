using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class ModifiedSchiffPitchforkPatternSettings
{
    private readonly Settings _settings;

    public ModifiedSchiffPitchforkPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public LineSettings MedianLine => new()
    {
        LineColor = _settings.ModifiedSchiffPitchforkMedianColor,
        Style = _settings.ModifiedSchiffPitchforkMedianStyle,
        Thickness = _settings.ModifiedSchiffPitchforkMedianThickness
    };

    public IReadOnlyDictionary<double, PercentLineSettings> Levels
    {
        get
        {
            var levels = new Dictionary<double, PercentLineSettings>();

            if (_settings.ShowFirstModifiedSchiffPitchfork)
                levels.Add(_settings.FirstModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FirstModifiedSchiffPitchforkPercent,
                    LineColor = _settings.FirstModifiedSchiffPitchforkColor,
                    Style = _settings.FirstModifiedSchiffPitchforkStyle,
                    Thickness = _settings.FirstModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowSecondModifiedSchiffPitchfork)
                levels.Add(_settings.SecondModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SecondModifiedSchiffPitchforkPercent,
                    LineColor = _settings.SecondModifiedSchiffPitchforkColor,
                    Style = _settings.SecondModifiedSchiffPitchforkStyle,
                    Thickness = _settings.SecondModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowThirdModifiedSchiffPitchfork)
                levels.Add(_settings.ThirdModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.ThirdModifiedSchiffPitchforkPercent,
                    LineColor = _settings.ThirdModifiedSchiffPitchforkColor,
                    Style = _settings.ThirdModifiedSchiffPitchforkStyle,
                    Thickness = _settings.ThirdModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowFourthModifiedSchiffPitchfork)
                levels.Add(_settings.FourthModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FourthModifiedSchiffPitchforkPercent,
                    LineColor = _settings.FourthModifiedSchiffPitchforkColor,
                    Style = _settings.FourthModifiedSchiffPitchforkStyle,
                    Thickness = _settings.FourthModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowFifthModifiedSchiffPitchfork)
                levels.Add(_settings.FifthModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FifthModifiedSchiffPitchforkPercent,
                    LineColor = _settings.FifthModifiedSchiffPitchforkColor,
                    Style = _settings.FifthModifiedSchiffPitchforkStyle,
                    Thickness = _settings.FifthModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowSixthModifiedSchiffPitchfork)
                levels.Add(_settings.SixthModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SixthModifiedSchiffPitchforkPercent,
                    LineColor = _settings.SixthModifiedSchiffPitchforkColor,
                    Style = _settings.SixthModifiedSchiffPitchforkStyle,
                    Thickness = _settings.SixthModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowSeventhModifiedSchiffPitchfork)
                levels.Add(_settings.SeventhModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SeventhModifiedSchiffPitchforkPercent,
                    LineColor = _settings.SeventhModifiedSchiffPitchforkColor,
                    Style = _settings.SeventhModifiedSchiffPitchforkStyle,
                    Thickness = _settings.SeventhModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowEighthModifiedSchiffPitchfork)
                levels.Add(_settings.EighthModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.EighthModifiedSchiffPitchforkPercent,
                    LineColor = _settings.EighthModifiedSchiffPitchforkColor,
                    Style = _settings.EighthModifiedSchiffPitchforkStyle,
                    Thickness = _settings.EighthModifiedSchiffPitchforkThickness
                });

            if (_settings.ShowNinthModifiedSchiffPitchfork)
                levels.Add(_settings.NinthModifiedSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.NinthModifiedSchiffPitchforkPercent,
                    LineColor = _settings.NinthModifiedSchiffPitchforkColor,
                    Style = _settings.NinthModifiedSchiffPitchforkStyle,
                    Thickness = _settings.NinthModifiedSchiffPitchforkThickness
                });

            return levels;
        }
    }
}