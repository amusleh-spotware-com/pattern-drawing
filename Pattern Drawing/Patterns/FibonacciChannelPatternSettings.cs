using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class FibonacciChannelPatternSettings
{
    private readonly Settings _settings;

    public FibonacciChannelPatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public IEnumerable<FibonacciLevel> Levels
    {
        get
        {
            var result = new List<FibonacciLevel>();

            if (_settings.ShowFirstFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FirstFibonacciChannelPercent,
                    Style = _settings.FirstFibonacciChannelStyle,
                    Thickness = _settings.FirstFibonacciChannelThickness,
                    LineColor = _settings.FirstFibonacciChannelColor,
                    IsFilled = _settings.FillFirstFibonacciChannel
                });

            if (_settings.ShowSecondFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SecondFibonacciChannelPercent,
                    Style = _settings.SecondFibonacciChannelStyle,
                    Thickness = _settings.SecondFibonacciChannelThickness,
                    LineColor = _settings.SecondFibonacciChannelColor,
                    IsFilled = _settings.FillSecondFibonacciChannel
                });

            if (_settings.ShowThirdFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.ThirdFibonacciChannelPercent,
                    Style = _settings.ThirdFibonacciChannelStyle,
                    Thickness = _settings.ThirdFibonacciChannelThickness,
                    LineColor = _settings.ThirdFibonacciChannelColor,
                    IsFilled = _settings.FillThirdFibonacciChannel
                });

            if (_settings.ShowFourthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FourthFibonacciChannelPercent,
                    Style = _settings.FourthFibonacciChannelStyle,
                    Thickness = _settings.FourthFibonacciChannelThickness,
                    LineColor = _settings.FourthFibonacciChannelColor,
                    IsFilled = _settings.FillFourthFibonacciChannel
                });

            if (_settings.ShowFifthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FifthFibonacciChannelPercent,
                    Style = _settings.FifthFibonacciChannelStyle,
                    Thickness = _settings.FifthFibonacciChannelThickness,
                    LineColor = _settings.FifthFibonacciChannelColor,
                    IsFilled = _settings.FillFifthFibonacciChannel
                });

            if (_settings.ShowSixthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SixthFibonacciChannelPercent,
                    Style = _settings.SixthFibonacciChannelStyle,
                    Thickness = _settings.SixthFibonacciChannelThickness,
                    LineColor = _settings.SixthFibonacciChannelColor,
                    IsFilled = _settings.FillSixthFibonacciChannel
                });

            if (_settings.ShowSeventhFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SeventhFibonacciChannelPercent,
                    Style = _settings.SeventhFibonacciChannelStyle,
                    Thickness = _settings.SeventhFibonacciChannelThickness,
                    LineColor = _settings.SeventhFibonacciChannelColor,
                    IsFilled = _settings.FillSeventhFibonacciChannel
                });

            if (_settings.ShowEighthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EighthFibonacciChannelPercent,
                    Style = _settings.EighthFibonacciChannelStyle,
                    Thickness = _settings.EighthFibonacciChannelThickness,
                    LineColor = _settings.EighthFibonacciChannelColor,
                    IsFilled = _settings.FillEighthFibonacciChannel
                });

            if (_settings.ShowNinthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.NinthFibonacciChannelPercent,
                    Style = _settings.NinthFibonacciChannelStyle,
                    Thickness = _settings.NinthFibonacciChannelThickness,
                    LineColor = _settings.NinthFibonacciChannelColor,
                    IsFilled = _settings.FillNinthFibonacciChannel
                });

            if (_settings.ShowTenthFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.TenthFibonacciChannelPercent,
                    Style = _settings.TenthFibonacciChannelStyle,
                    Thickness = _settings.TenthFibonacciChannelThickness,
                    LineColor = _settings.TenthFibonacciChannelColor,
                    IsFilled = _settings.FillTenthFibonacciChannel
                });

            if (_settings.ShowEleventhFibonacciChannel)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EleventhFibonacciChannelPercent,
                    Style = _settings.EleventhFibonacciChannelStyle,
                    Thickness = _settings.EleventhFibonacciChannelThickness,
                    LineColor = _settings.EleventhFibonacciChannelColor,
                    IsFilled = _settings.FillEleventhFibonacciChannel
                });

            return result;
        }
    }
}