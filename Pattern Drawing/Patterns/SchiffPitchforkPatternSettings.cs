using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class SchiffPitchforkPatternSettings
{
    private readonly Settings _settings;

    public SchiffPitchforkPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public LineSettings MedianLine => new()
    {
        LineColor = _settings.SchiffPitchforkMedianColor,
        Style = _settings.SchiffPitchforkMedianStyle,
        Thickness = _settings.SchiffPitchforkMedianThickness
    };

    public IReadOnlyDictionary<double, PercentLineSettings> Levels
    {
        get
        {
            var levels = new Dictionary<double, PercentLineSettings>();

            if (_settings.ShowFirstSchiffPitchfork)
                levels.Add(_settings.FirstSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FirstSchiffPitchforkPercent,
                    LineColor = _settings.FirstSchiffPitchforkColor,
                    Style = _settings.FirstSchiffPitchforkStyle,
                    Thickness = _settings.FirstSchiffPitchforkThickness
                });

            if (_settings.ShowSecondSchiffPitchfork)
                levels.Add(_settings.SecondSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SecondSchiffPitchforkPercent,
                    LineColor = _settings.SecondSchiffPitchforkColor,
                    Style = _settings.SecondSchiffPitchforkStyle,
                    Thickness = _settings.SecondSchiffPitchforkThickness
                });

            if (_settings.ShowThirdSchiffPitchfork)
                levels.Add(_settings.ThirdSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.ThirdSchiffPitchforkPercent,
                    LineColor = _settings.ThirdSchiffPitchforkColor,
                    Style = _settings.ThirdSchiffPitchforkStyle,
                    Thickness = _settings.ThirdSchiffPitchforkThickness
                });

            if (_settings.ShowFourthSchiffPitchfork)
                levels.Add(_settings.FourthSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FourthSchiffPitchforkPercent,
                    LineColor = _settings.FourthSchiffPitchforkColor,
                    Style = _settings.FourthSchiffPitchforkStyle,
                    Thickness = _settings.FourthSchiffPitchforkThickness
                });

            if (_settings.ShowFifthSchiffPitchfork)
                levels.Add(_settings.FifthSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.FifthSchiffPitchforkPercent,
                    LineColor = _settings.FifthSchiffPitchforkColor,
                    Style = _settings.FifthSchiffPitchforkStyle,
                    Thickness = _settings.FifthSchiffPitchforkThickness
                });

            if (_settings.ShowSixthSchiffPitchfork)
                levels.Add(_settings.SixthSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SixthSchiffPitchforkPercent,
                    LineColor = _settings.SixthSchiffPitchforkColor,
                    Style = _settings.SixthSchiffPitchforkStyle,
                    Thickness = _settings.SixthSchiffPitchforkThickness
                });

            if (_settings.ShowSeventhSchiffPitchfork)
                levels.Add(_settings.SeventhSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.SeventhSchiffPitchforkPercent,
                    LineColor = _settings.SeventhSchiffPitchforkColor,
                    Style = _settings.SeventhSchiffPitchforkStyle,
                    Thickness = _settings.SeventhSchiffPitchforkThickness
                });

            if (_settings.ShowEighthSchiffPitchfork)
                levels.Add(_settings.EighthSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.EighthSchiffPitchforkPercent,
                    LineColor = _settings.EighthSchiffPitchforkColor,
                    Style = _settings.EighthSchiffPitchforkStyle,
                    Thickness = _settings.EighthSchiffPitchforkThickness
                });

            if (_settings.ShowNinthSchiffPitchfork)
                levels.Add(_settings.NinthSchiffPitchforkPercent, new PercentLineSettings
                {
                    Percent = _settings.NinthSchiffPitchforkPercent,
                    LineColor = _settings.NinthSchiffPitchforkColor,
                    Style = _settings.NinthSchiffPitchforkStyle,
                    Thickness = _settings.NinthSchiffPitchforkThickness
                });

            return levels;
        }
    }
}