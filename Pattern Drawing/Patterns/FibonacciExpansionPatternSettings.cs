using System.Collections.Generic;
using System.Linq;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class FibonacciExpansionPatternSettings
{
    private readonly Settings _settings;

    public FibonacciExpansionPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public IEnumerable<FibonacciLevel> Levels
    {
        get
        {
            var levels = new List<FibonacciLevel>();

            if (_settings.ShowFirstFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FirstFibonacciExpansionPercent,
                    LineColor = _settings.FirstFibonacciExpansionColor,
                    Style = _settings.FirstFibonacciExpansionStyle,
                    Thickness = _settings.FirstFibonacciExpansionThickness,
                    FillColor = _settings.FirstFibonacciExpansionColor,
                    IsFilled = _settings.FillFirstFibonacciExpansion,
                    ExtendToInfinity = _settings.FirstFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowSecondFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SecondFibonacciExpansionPercent,
                    LineColor = _settings.SecondFibonacciExpansionColor,
                    Style = _settings.SecondFibonacciExpansionStyle,
                    Thickness = _settings.SecondFibonacciExpansionThickness,
                    FillColor = _settings.SecondFibonacciExpansionColor,
                    IsFilled = _settings.FillSecondFibonacciExpansion,
                    ExtendToInfinity = _settings.SecondFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowThirdFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.ThirdFibonacciExpansionPercent,
                    LineColor = _settings.ThirdFibonacciExpansionColor,
                    Style = _settings.ThirdFibonacciExpansionStyle,
                    Thickness = _settings.ThirdFibonacciExpansionThickness,
                    FillColor = _settings.ThirdFibonacciExpansionColor,
                    IsFilled = _settings.FillThirdFibonacciExpansion,
                    ExtendToInfinity = _settings.ThirdFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowFourthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FourthFibonacciExpansionPercent,
                    LineColor = _settings.FourthFibonacciExpansionColor,
                    Style = _settings.FourthFibonacciExpansionStyle,
                    Thickness = _settings.FourthFibonacciExpansionThickness,
                    FillColor = _settings.FourthFibonacciExpansionColor,
                    IsFilled = _settings.FillFourthFibonacciExpansion,
                    ExtendToInfinity = _settings.FourthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowFifthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FifthFibonacciExpansionPercent,
                    LineColor = _settings.FifthFibonacciExpansionColor,
                    Style = _settings.FifthFibonacciExpansionStyle,
                    Thickness = _settings.FifthFibonacciExpansionThickness,
                    FillColor = _settings.FifthFibonacciExpansionColor,
                    IsFilled = _settings.FillFifthFibonacciExpansion,
                    ExtendToInfinity = _settings.FifthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowSixthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SixthFibonacciExpansionPercent,
                    LineColor = _settings.SixthFibonacciExpansionColor,
                    Style = _settings.SixthFibonacciExpansionStyle,
                    Thickness = _settings.SixthFibonacciExpansionThickness,
                    FillColor = _settings.SixthFibonacciExpansionColor,
                    IsFilled = _settings.FillSixthFibonacciExpansion,
                    ExtendToInfinity = _settings.SixthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowSeventhFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SeventhFibonacciExpansionPercent,
                    LineColor = _settings.SeventhFibonacciExpansionColor,
                    Style = _settings.SeventhFibonacciExpansionStyle,
                    Thickness = _settings.SeventhFibonacciExpansionThickness,
                    FillColor = _settings.SeventhFibonacciExpansionColor,
                    IsFilled = _settings.FillSeventhFibonacciExpansion,
                    ExtendToInfinity = _settings.SeventhFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowEighthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.EighthFibonacciExpansionPercent,
                    LineColor = _settings.EighthFibonacciExpansionColor,
                    Style = _settings.EighthFibonacciExpansionStyle,
                    Thickness = _settings.EighthFibonacciExpansionThickness,
                    FillColor = _settings.EighthFibonacciExpansionColor,
                    IsFilled = _settings.FillEighthFibonacciExpansion,
                    ExtendToInfinity = _settings.EighthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowNinthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.NinthFibonacciExpansionPercent,
                    LineColor = _settings.NinthFibonacciExpansionColor,
                    Style = _settings.NinthFibonacciExpansionStyle,
                    Thickness = _settings.NinthFibonacciExpansionThickness,
                    FillColor = _settings.NinthFibonacciExpansionColor,
                    IsFilled = _settings.FillNinthFibonacciExpansion,
                    ExtendToInfinity = _settings.NinthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowTenthFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.TenthFibonacciExpansionPercent,
                    LineColor = _settings.TenthFibonacciExpansionColor,
                    Style = _settings.TenthFibonacciExpansionStyle,
                    Thickness = _settings.TenthFibonacciExpansionThickness,
                    FillColor = _settings.TenthFibonacciExpansionColor,
                    IsFilled = _settings.FillTenthFibonacciExpansion,
                    ExtendToInfinity = _settings.TenthFibonacciExpansionExtendToInfinity
                });

            if (_settings.ShowEleventhFibonacciExpansion)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.EleventhFibonacciExpansionPercent,
                    LineColor = _settings.EleventhFibonacciExpansionColor,
                    Style = _settings.EleventhFibonacciExpansionStyle,
                    Thickness = _settings.EleventhFibonacciExpansionThickness,
                    FillColor = _settings.EleventhFibonacciExpansionColor,
                    IsFilled = _settings.FillEleventhFibonacciExpansion,
                    ExtendToInfinity = _settings.EleventhFibonacciExpansionExtendToInfinity
                });

            return levels.OrderByDescending(iLevel => iLevel.Percent);
            ;
        }
    }
}