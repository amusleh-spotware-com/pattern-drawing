using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class OriginalPitchforkPatternSettings
{
    private readonly Settings _settings;

    public OriginalPitchforkPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public LineSettings MedianLine => new()
    {
        LineColor = _settings.OriginalPitchforkMedianColor,
        Style = _settings.OriginalPitchforkMedianStyle,
        Thickness = _settings.OriginalPitchforkMedianThickness
    };

    public IReadOnlyDictionary<double, PercentLineSettings> Levels
    {
        get
        {
            var levels = new Dictionary<double, PercentLineSettings>();

            if (_settings.ShowFirstOriginalPitchfork)
                levels.Add(_settings.FirstOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FirstOriginalPitchforkPercent,
                    LineColor = _settings.FirstOriginalPitchforkColor,
                    Style = _settings.FirstOriginalPitchforkStyle,
                    Thickness = _settings.FirstOriginalPitchforkThickness
                });

            if (_settings.ShowSecondOriginalPitchfork)
                levels.Add(_settings.SecondOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SecondOriginalPitchforkPercent,
                    LineColor = _settings.SecondOriginalPitchforkColor,
                    Style = _settings.SecondOriginalPitchforkStyle,
                    Thickness = _settings.SecondOriginalPitchforkThickness
                });

            if (_settings.ShowThirdOriginalPitchfork)
                levels.Add(_settings.ThirdOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.ThirdOriginalPitchforkPercent,
                    LineColor = _settings.ThirdOriginalPitchforkColor,
                    Style = _settings.ThirdOriginalPitchforkStyle,
                    Thickness = _settings.ThirdOriginalPitchforkThickness
                });

            if (_settings.ShowFourthOriginalPitchfork)
                levels.Add(_settings.FourthOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FourthOriginalPitchforkPercent,
                    LineColor = _settings.FourthOriginalPitchforkColor,
                    Style = _settings.FourthOriginalPitchforkStyle,
                    Thickness = _settings.FourthOriginalPitchforkThickness
                });

            if (_settings.ShowFifthOriginalPitchfork)
                levels.Add(_settings.FifthOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FifthOriginalPitchforkPercent,
                    LineColor = _settings.FifthOriginalPitchforkColor,
                    Style = _settings.FifthOriginalPitchforkStyle,
                    Thickness = _settings.FifthOriginalPitchforkThickness
                });

            if (_settings.ShowSixthOriginalPitchfork)
                levels.Add(_settings.SixthOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SixthOriginalPitchforkPercent,
                    LineColor = _settings.SixthOriginalPitchforkColor,
                    Style = _settings.SixthOriginalPitchforkStyle,
                    Thickness = _settings.SixthOriginalPitchforkThickness
                });

            if (_settings.ShowSeventhOriginalPitchfork)
                levels.Add(_settings.SeventhOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SeventhOriginalPitchforkPercent,
                    LineColor = _settings.SeventhOriginalPitchforkColor,
                    Style = _settings.SeventhOriginalPitchforkStyle,
                    Thickness = _settings.SeventhOriginalPitchforkThickness
                });

            if (_settings.ShowEighthOriginalPitchfork)
                levels.Add(_settings.EighthOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.EighthOriginalPitchforkPercent,
                    LineColor = _settings.EighthOriginalPitchforkColor,
                    Style = _settings.EighthOriginalPitchforkStyle,
                    Thickness = _settings.EighthOriginalPitchforkThickness
                });

            if (_settings.ShowNinthOriginalPitchfork)
                levels.Add(_settings.NinthOriginalPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.NinthOriginalPitchforkPercent,
                    LineColor = _settings.NinthOriginalPitchforkColor,
                    Style = _settings.NinthOriginalPitchforkStyle,
                    Thickness = _settings.NinthOriginalPitchforkThickness
                });

            return levels;
        }
    }
}