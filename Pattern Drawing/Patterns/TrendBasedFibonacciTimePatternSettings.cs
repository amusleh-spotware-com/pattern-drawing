using System.Collections.Generic;
using cAlgo.Plugins;

namespace cAlgo.Patterns;

public class TrendBasedFibonacciTimePatternSettings
{
    private readonly Settings _settings;

    public TrendBasedFibonacciTimePatternSettings(Settings settings)
    {
        _settings = settings;
    }

    public IEnumerable<FibonacciLevel> Levels
    {
        get
        {
            var result = new List<FibonacciLevel>();

            if (_settings.ShowFirstTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FirstTrendBasedFibonacciTimePercent,
                    Style = _settings.FirstTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.FirstTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.FirstTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowSecondTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SecondTrendBasedFibonacciTimePercent,
                    Style = _settings.SecondTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.SecondTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.SecondTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowThirdTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.ThirdTrendBasedFibonacciTimePercent,
                    Style = _settings.ThirdTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.ThirdTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.ThirdTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowFourthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FourthTrendBasedFibonacciTimePercent,
                    Style = _settings.FourthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.FourthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.FourthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowFifthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.FifthTrendBasedFibonacciTimePercent,
                    Style = _settings.FifthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.FifthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.FifthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowSixthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SixthTrendBasedFibonacciTimePercent,
                    Style = _settings.SixthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.SixthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.SixthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowSeventhTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.SeventhTrendBasedFibonacciTimePercent,
                    Style = _settings.SeventhTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.SeventhTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.SeventhTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowEighthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EighthTrendBasedFibonacciTimePercent,
                    Style = _settings.EighthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.EighthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.EighthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowNinthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.NinthTrendBasedFibonacciTimePercent,
                    Style = _settings.NinthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.NinthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.NinthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowTenthTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.TenthTrendBasedFibonacciTimePercent,
                    Style = _settings.TenthTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.TenthTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.TenthTrendBasedFibonacciTimeColor
                });

            if (_settings.ShowEleventhTrendBasedFibonacciTime)
                result.Add(new FibonacciLevel
                {
                    Percent = _settings.EleventhTrendBasedFibonacciTimePercent,
                    Style = _settings.EleventhTrendBasedFibonacciTimeStyle,
                    Thickness = _settings.EleventhTrendBasedFibonacciTimeThickness,
                    LineColor = _settings.EleventhTrendBasedFibonacciTimeColor
                });

            return result;
        }
    }
}