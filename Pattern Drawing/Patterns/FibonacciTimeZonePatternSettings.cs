using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class FibonacciTimeZonePatternSettings
{
    private readonly Settings _settings;

    public FibonacciTimeZonePatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public IEnumerable<FibonacciLevel> Levels
    {
        get
        {
            var result = new List<FibonacciLevel>();

            if (_settings.ShowFirstFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FirstFibonacciTimeZonePercent,
                    Style = _settings.FirstFibonacciTimeZoneStyle,
                    Thickness = _settings.FirstFibonacciTimeZoneThickness,
                    LineColor = _settings.FirstFibonacciTimeZoneColor
                });

            if (_settings.ShowSecondFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SecondFibonacciTimeZonePercent,
                    Style = _settings.SecondFibonacciTimeZoneStyle,
                    Thickness = _settings.SecondFibonacciTimeZoneThickness,
                    LineColor = _settings.SecondFibonacciTimeZoneColor
                });

            if (_settings.ShowThirdFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.ThirdFibonacciTimeZonePercent,
                    Style = _settings.ThirdFibonacciTimeZoneStyle,
                    Thickness = _settings.ThirdFibonacciTimeZoneThickness,
                    LineColor = _settings.ThirdFibonacciTimeZoneColor
                });

            if (_settings.ShowFourthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FourthFibonacciTimeZonePercent,
                    Style = _settings.FourthFibonacciTimeZoneStyle,
                    Thickness = _settings.FourthFibonacciTimeZoneThickness,
                    LineColor = _settings.FourthFibonacciTimeZoneColor
                });

            if (_settings.ShowFifthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FifthFibonacciTimeZonePercent,
                    Style = _settings.FifthFibonacciTimeZoneStyle,
                    Thickness = _settings.FifthFibonacciTimeZoneThickness,
                    LineColor = _settings.FifthFibonacciTimeZoneColor
                });

            if (_settings.ShowSixthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SixthFibonacciTimeZonePercent,
                    Style = _settings.SixthFibonacciTimeZoneStyle,
                    Thickness = _settings.SixthFibonacciTimeZoneThickness,
                    LineColor = _settings.SixthFibonacciTimeZoneColor
                });

            if (_settings.ShowSeventhFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SeventhFibonacciTimeZonePercent,
                    Style = _settings.SeventhFibonacciTimeZoneStyle,
                    Thickness = _settings.SeventhFibonacciTimeZoneThickness,
                    LineColor = _settings.SeventhFibonacciTimeZoneColor
                });

            if (_settings.ShowEighthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EighthFibonacciTimeZonePercent,
                    Style = _settings.EighthFibonacciTimeZoneStyle,
                    Thickness = _settings.EighthFibonacciTimeZoneThickness,
                    LineColor = _settings.EighthFibonacciTimeZoneColor
                });

            if (_settings.ShowNinthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.NinthFibonacciTimeZonePercent,
                    Style = _settings.NinthFibonacciTimeZoneStyle,
                    Thickness = _settings.NinthFibonacciTimeZoneThickness,
                    LineColor = _settings.NinthFibonacciTimeZoneColor
                });

            if (_settings.ShowTenthFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.TenthFibonacciTimeZonePercent,
                    Style = _settings.TenthFibonacciTimeZoneStyle,
                    Thickness = _settings.TenthFibonacciTimeZoneThickness,
                    LineColor = _settings.TenthFibonacciTimeZoneColor
                });

            if (_settings.ShowEleventhFibonacciTimeZone)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EleventhFibonacciTimeZonePercent,
                    Style = _settings.EleventhFibonacciTimeZoneStyle,
                    Thickness = _settings.EleventhFibonacciTimeZoneThickness,
                    LineColor = _settings.EleventhFibonacciTimeZoneColor
                });

            return result;
        }
    }
}