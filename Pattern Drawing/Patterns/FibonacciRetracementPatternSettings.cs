using System.Collections.Generic;
using System.Linq;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class FibonacciRetracementSettings
{
    private readonly Settings _settings;

    public FibonacciRetracementSettings(Settings settings)
    {
        _settings = settings;
    }

    public IEnumerable<FibonacciLevel> Levels
    {
        get
        {
            var levels = new List<FibonacciLevel>();

            if (_settings.ShowFirstFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FirstFibonacciRetracementPercent,
                    LineColor = _settings.FirstFibonacciRetracementColor,
                    Style = _settings.FirstFibonacciRetracementStyle,
                    Thickness = _settings.FirstFibonacciRetracementThickness,
                    FillColor = _settings.FirstFibonacciRetracementColor,
                    IsFilled = _settings.FillFirstFibonacciRetracement,
                    ExtendToInfinity = _settings.FirstFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowSecondFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SecondFibonacciRetracementPercent,
                    LineColor = _settings.SecondFibonacciRetracementColor,
                    Style = _settings.SecondFibonacciRetracementStyle,
                    Thickness = _settings.SecondFibonacciRetracementThickness,
                    FillColor = _settings.SecondFibonacciRetracementColor,
                    IsFilled = _settings.FillSecondFibonacciRetracement,
                    ExtendToInfinity = _settings.SecondFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowThirdFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.ThirdFibonacciRetracementPercent,
                    LineColor = _settings.ThirdFibonacciRetracementColor,
                    Style = _settings.ThirdFibonacciRetracementStyle,
                    Thickness = _settings.ThirdFibonacciRetracementThickness,
                    FillColor = _settings.ThirdFibonacciRetracementColor,
                    IsFilled = _settings.FillThirdFibonacciRetracement,
                    ExtendToInfinity = _settings.ThirdFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowFourthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FourthFibonacciRetracementPercent,
                    LineColor = _settings.FourthFibonacciRetracementColor,
                    Style = _settings.FourthFibonacciRetracementStyle,
                    Thickness = _settings.FourthFibonacciRetracementThickness,
                    FillColor = _settings.FourthFibonacciRetracementColor,
                    IsFilled = _settings.FillFourthFibonacciRetracement,
                    ExtendToInfinity = _settings.FourthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowFifthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.FifthFibonacciRetracementPercent,
                    LineColor = _settings.FifthFibonacciRetracementColor,
                    Style = _settings.FifthFibonacciRetracementStyle,
                    Thickness = _settings.FifthFibonacciRetracementThickness,
                    FillColor = _settings.FifthFibonacciRetracementColor,
                    IsFilled = _settings.FillFifthFibonacciRetracement,
                    ExtendToInfinity = _settings.FifthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowSixthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SixthFibonacciRetracementPercent,
                    LineColor = _settings.SixthFibonacciRetracementColor,
                    Style = _settings.SixthFibonacciRetracementStyle,
                    Thickness = _settings.SixthFibonacciRetracementThickness,
                    FillColor = _settings.SixthFibonacciRetracementColor,
                    IsFilled = _settings.FillSixthFibonacciRetracement,
                    ExtendToInfinity = _settings.SixthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowSeventhFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.SeventhFibonacciRetracementPercent,
                    LineColor = _settings.SeventhFibonacciRetracementColor,
                    Style = _settings.SeventhFibonacciRetracementStyle,
                    Thickness = _settings.SeventhFibonacciRetracementThickness,
                    FillColor = _settings.SeventhFibonacciRetracementColor,
                    IsFilled = _settings.FillSeventhFibonacciRetracement,
                    ExtendToInfinity = _settings.SeventhFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowEighthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.EighthFibonacciRetracementPercent,
                    LineColor = _settings.EighthFibonacciRetracementColor,
                    Style = _settings.EighthFibonacciRetracementStyle,
                    Thickness = _settings.EighthFibonacciRetracementThickness,
                    FillColor = _settings.EighthFibonacciRetracementColor,
                    IsFilled = _settings.FillEighthFibonacciRetracement,
                    ExtendToInfinity = _settings.EighthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowNinthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.NinthFibonacciRetracementPercent,
                    LineColor = _settings.NinthFibonacciRetracementColor,
                    Style = _settings.NinthFibonacciRetracementStyle,
                    Thickness = _settings.NinthFibonacciRetracementThickness,
                    FillColor = _settings.NinthFibonacciRetracementColor,
                    IsFilled = _settings.FillNinthFibonacciRetracement,
                    ExtendToInfinity = _settings.NinthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowTenthFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.TenthFibonacciRetracementPercent,
                    LineColor = _settings.TenthFibonacciRetracementColor,
                    Style = _settings.TenthFibonacciRetracementStyle,
                    Thickness = _settings.TenthFibonacciRetracementThickness,
                    FillColor = _settings.TenthFibonacciRetracementColor,
                    IsFilled = _settings.FillTenthFibonacciRetracement,
                    ExtendToInfinity = _settings.TenthFibonacciRetracementExtendToInfinity
                });

            if (_settings.ShowEleventhFibonacciRetracement)
                levels.Add(new FibonacciLevel
                {
                    Percent = _settings.EleventhFibonacciRetracementPercent,
                    LineColor = _settings.EleventhFibonacciRetracementColor,
                    Style = _settings.EleventhFibonacciRetracementStyle,
                    Thickness = _settings.EleventhFibonacciRetracementThickness,
                    FillColor = _settings.EleventhFibonacciRetracementColor,
                    IsFilled = _settings.FillEleventhFibonacciRetracement,
                    ExtendToInfinity = _settings.EleventhFibonacciRetracementExtendToInfinity
                });

            return levels.OrderByDescending(iLevel => iLevel.Percent);
        }
    }
}