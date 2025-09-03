using System.Reflection;
using cAlgo.API;

namespace cAlgo.Plugins;

public class Settings
{
    private static Settings _default;

    public static Settings Default => _default ??= CreateDefault();

    #region Cycles parameters

    [Parameter("Number", DefaultValue = 100, MinValue = 1, Group = "Cycles")]
    public int CyclesNumber { get; set; } = 100;

    #endregion Cycles parameters

    private static Settings CreateDefault()
    {
        var settings = new Settings();

        foreach (var property in settings.GetType().GetProperties())
        {
            if (property.GetCustomAttribute<ParameterAttribute>() is not { } parameterAttribute)
                continue;

            property.SetValue(settings, parameterAttribute.DefaultValue);
        }

        return settings;
    }

    #region Patterns Label parameters

    [Parameter("Show", DefaultValue = true, Group = "Patterns Label")]
    public bool PatternsLabelShow { get; set; } = true;

    [Parameter("Color", DefaultValue = "Yellow", Group = "Patterns Label")]
    public string PatternsLabelColor { get; set; }

    [Parameter("Locked", DefaultValue = true, Group = "Patterns Label")]
    public bool PatternsLabelLocked { get; set; } = true;

    [Parameter("Link Style", DefaultValue = true, Group = "Patterns Label")]
    public bool PatternsLabelLinkStyle { get; set; } = true;

    #endregion Patterns Label parameters

    #region Gann Box parameters

    [Parameter("Rectangle Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Box")]
    public int GannBoxRectangleThickness { get; set; } = 1;

    [Parameter("Rectangle Style", DefaultValue = LineStyle.Solid, Group = "Gann Box")]
    public LineStyle GannBoxRectangleStyle { get; set; } = LineStyle.Solid;

    [Parameter("Rectangle Color", DefaultValue = "FF0000FF", Group = "Gann Box")]
    public string GannBoxRectangleColor { get; set; }

    [Parameter("Price Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Box")]
    public int GannBoxPriceLevelsThickness { get; set; } = 1;

    [Parameter("Price Levels Style", DefaultValue = LineStyle.Solid, Group = "Gann Box")]
    public LineStyle GannBoxPriceLevelsStyle { get; set; } = LineStyle.Solid;

    [Parameter("Price Levels Color", DefaultValue = "FFFF00FF", Group = "Gann Box")]
    public string GannBoxPriceLevelsColor { get; set; }

    [Parameter("Time Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Box")]
    public int GannBoxTimeLevelsThickness { get; set; } = 1;

    [Parameter("Time Levels Style", DefaultValue = LineStyle.Solid, Group = "Gann Box")]
    public LineStyle GannBoxTimeLevelsStyle { get; set; } = LineStyle.Solid;

    [Parameter("Time Levels Color", DefaultValue = "FFFF0000", Group = "Gann Box")]
    public string GannBoxTimeLevelsColor { get; set; }

    #endregion Gann Box parameters

    #region Gann Square parameters

    [Parameter("Rectangle Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Square")]
    public int GannSquareRectangleThickness { get; set; } = 1;

    [Parameter("Rectangle Style", DefaultValue = LineStyle.Solid, Group = "Gann Square")]
    public LineStyle GannSquareRectangleStyle { get; set; } = LineStyle.Solid;

    [Parameter("Rectangle Color", DefaultValue = "FF0000FF", Group = "Gann Square")]
    public string GannSquareRectangleColor { get; set; }

    [Parameter("Price Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Square")]
    public int GannSquarePriceLevelsThickness { get; set; } = 1;

    [Parameter("Price Levels Style", DefaultValue = LineStyle.Solid, Group = "Gann Square")]
    public LineStyle GannSquarePriceLevelsStyle { get; set; } = LineStyle.Solid;

    [Parameter("Price Levels Color", DefaultValue = "FFFF00FF", Group = "Gann Square")]
    public string GannSquarePriceLevelsColor { get; set; }

    [Parameter("Time Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Square")]
    public int GannSquareTimeLevelsThickness { get; set; } = 1;

    [Parameter("Time Levels Style", DefaultValue = LineStyle.Solid, Group = "Gann Square")]
    public LineStyle GannSquareTimeLevelsStyle { get; set; } = LineStyle.Solid;

    [Parameter("Time Levels Color", DefaultValue = "FFFF0000", Group = "Gann Square")]
    public string GannSquareTimeLevelsColor { get; set; }

    [Parameter("Fans Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Square")]
    public int GannSquareFansThickness { get; set; } = 1;

    [Parameter("Fans Style", DefaultValue = LineStyle.Solid, Group = "Gann Square")]
    public LineStyle GannSquareFansStyle { get; set; } = LineStyle.Solid;

    [Parameter("Fans Color", DefaultValue = "FFA52A2A", Group = "Gann Square")]
    public string GannSquareFansColor { get; set; }

    #endregion Gann Square parameters

    #region Gann Fan parameters

    [Parameter("1/1 Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Fan")]
    public int GannFanOneThickness { get; set; } = 1;

    [Parameter("1/1 Style", DefaultValue = LineStyle.Solid, Group = "Gann Fan")]
    public LineStyle GannFanOneStyle { get; set; } = LineStyle.Solid;

    [Parameter("1/1 Color", DefaultValue = "FFFF0000", Group = "Gann Fan")]
    public string GannFanOneColor { get; set; }

    [Parameter("1/2 and 2/1 Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Fan")]
    public int GannFanTwoThickness { get; set; } = 1;

    [Parameter("1/2 and 2/1 Style", DefaultValue = LineStyle.Solid, Group = "Gann Fan")]
    public LineStyle GannFanTwoStyle { get; set; } = LineStyle.Solid;

    [Parameter("1/2 and 2/1 Color", DefaultValue = "FFA52A2A", Group = "Gann Fan")]
    public string GannFanTwoColor { get; set; }

    [Parameter("1/3 and 3/1 Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Fan")]
    public int GannFanThreeThickness { get; set; } = 1;

    [Parameter("1/3 and 3/1 Style", DefaultValue = LineStyle.Solid, Group = "Gann Fan")]
    public LineStyle GannFanThreeStyle { get; set; } = LineStyle.Solid;

    [Parameter("1/3 and 3/1 Color", DefaultValue = "FF00FF00", Group = "Gann Fan")]
    public string GannFanThreeColor { get; set; }

    [Parameter("1/4 and 4/1 Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Fan")]
    public int GannFanFourThickness { get; set; } = 1;

    [Parameter("1/4 and 4/1 Style", DefaultValue = LineStyle.Solid, Group = "Gann Fan")]
    public LineStyle GannFanFourStyle { get; set; } = LineStyle.Solid;

    [Parameter("1/4 and 4/1 Color", DefaultValue = "FFFF00FF", Group = "Gann Fan")]
    public string GannFanFourColor { get; set; }

    [Parameter("1/8 and 8/1 Thickness", DefaultValue = 1, MinValue = 1, Group = "Gann Fan")]
    public int GannFanEightThickness { get; set; } = 1;

    [Parameter("1/8 and 8/1 Style", DefaultValue = LineStyle.Solid, Group = "Gann Fan")]
    public LineStyle GannFanEightStyle { get; set; } = LineStyle.Solid;

    [Parameter("1/8 and 8/1 Color", DefaultValue = "FF0000FF", Group = "Gann Fan")]
    public string GannFanEightColor { get; set; }

    #endregion Gann Fan parameters

    #region Fibonacci Retracement parameters

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowFirstFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 1st Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillFirstFibonacciRetracement { get; set; } = true;

    [Parameter("1st Level Percent", DefaultValue = 0, Group = "Fibonacci Retracement")]
    public double FirstFibonacciRetracementPercent { get; set; } = 0;

    [Parameter("1st Level Color", DefaultValue = "40808080", Group = "Fibonacci Retracement")]
    public string FirstFibonacciRetracementColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int FirstFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle FirstFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("1st Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool FirstFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowSecondFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 2nd Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillSecondFibonacciRetracement { get; set; } = true;

    [Parameter("2nd Level Percent", DefaultValue = 0.236, Group = "Fibonacci Retracement")]
    public double SecondFibonacciRetracementPercent { get; set; } = 0.236;

    [Parameter("2nd Level Color", DefaultValue = "40FF0000", Group = "Fibonacci Retracement")]
    public string SecondFibonacciRetracementColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int SecondFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle SecondFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("2nd Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool SecondFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowThirdFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 3rd Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillThirdFibonacciRetracement { get; set; } = true;

    [Parameter("3rd Level Percent", DefaultValue = 0.382, Group = "Fibonacci Retracement")]
    public double ThirdFibonacciRetracementPercent { get; set; } = 0.382;

    [Parameter("3rd Level Color", DefaultValue = "40ADFF2F", Group = "Fibonacci Retracement")]
    public string ThirdFibonacciRetracementColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int ThirdFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle ThirdFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("3rd Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool ThirdFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowFourthFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 4th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillFourthFibonacciRetracement { get; set; } = true;

    [Parameter("4th Level Percent", DefaultValue = 0.5, Group = "Fibonacci Retracement")]
    public double FourthFibonacciRetracementPercent { get; set; } = 0.5;

    [Parameter("4th Level Color", DefaultValue = "40006400", Group = "Fibonacci Retracement")]
    public string FourthFibonacciRetracementColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int FourthFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle FourthFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("4th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool FourthFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowFifthFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 5th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillFifthFibonacciRetracement { get; set; } = true;

    [Parameter("5th Level Percent", DefaultValue = 0.618, Group = "Fibonacci Retracement")]
    public double FifthFibonacciRetracementPercent { get; set; } = 0.618;

    [Parameter("5th Level Color", DefaultValue = "408A2BE2", Group = "Fibonacci Retracement")]
    public string FifthFibonacciRetracementColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int FifthFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle FifthFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("5th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool FifthFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowSixthFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 6th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillSixthFibonacciRetracement { get; set; } = true;

    [Parameter("6th Level Percent", DefaultValue = 0.786, Group = "Fibonacci Retracement")]
    public double SixthFibonacciRetracementPercent { get; set; } = 0.786;

    [Parameter("6th Level Color", DefaultValue = "40F0F8FF", Group = "Fibonacci Retracement")]
    public string SixthFibonacciRetracementColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int SixthFibonacciRetracementThickness { get; set; } = 1;

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle SixthFibonacciRetracementStyle { get; set; } = LineStyle.Solid;

    [Parameter("6th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool SixthFibonacciRetracementExtendToInfinity { get; set; } = false;

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowSeventhFibonacciRetracement { get; set; } = true;

    [Parameter("Fill 7th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillSeventhFibonacciRetracement { get; set; } = true;

    [Parameter("7th Level Percent", DefaultValue = 1, Group = "Fibonacci Retracement")]
    public double SeventhFibonacciRetracementPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "40FFE4C4", Group = "Fibonacci Retracement")]
    public string SeventhFibonacciRetracementColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int SeventhFibonacciRetracementThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle SeventhFibonacciRetracementStyle { get; set; }

    [Parameter("7th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool SeventhFibonacciRetracementExtendToInfinity { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowEighthFibonacciRetracement { get; set; }

    [Parameter("Fill 8th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillEighthFibonacciRetracement { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.618, Group = "Fibonacci Retracement")]
    public double EighthFibonacciRetracementPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "40F0FFFF", Group = "Fibonacci Retracement")]
    public string EighthFibonacciRetracementColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int EighthFibonacciRetracementThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle EighthFibonacciRetracementStyle { get; set; }

    [Parameter("8th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool EighthFibonacciRetracementExtendToInfinity { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowNinthFibonacciRetracement { get; set; }

    [Parameter("Fill 9th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillNinthFibonacciRetracement { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2.618, Group = "Fibonacci Retracement")]
    public double NinthFibonacciRetracementPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "4000FFFF", Group = "Fibonacci Retracement")]
    public string NinthFibonacciRetracementColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int NinthFibonacciRetracementThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle NinthFibonacciRetracementStyle { get; set; }

    [Parameter("9th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool NinthFibonacciRetracementExtendToInfinity { get; set; }

    [Parameter("Show 10th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowTenthFibonacciRetracement { get; set; }

    [Parameter("Fill 10th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillTenthFibonacciRetracement { get; set; }

    [Parameter("10th Level Percent", DefaultValue = 3.618, Group = "Fibonacci Retracement")]
    public double TenthFibonacciRetracementPercent { get; set; }

    [Parameter("10th Level Color", DefaultValue = "407FFFD4", Group = "Fibonacci Retracement")]
    public string TenthFibonacciRetracementColor { get; set; }

    [Parameter("10th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int TenthFibonacciRetracementThickness { get; set; }

    [Parameter("10th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle TenthFibonacciRetracementStyle { get; set; }

    [Parameter("10th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool TenthFibonacciRetracementExtendToInfinity { get; set; }

    [Parameter("Show 11th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool ShowEleventhFibonacciRetracement { get; set; }

    [Parameter("Fill 11th Level", DefaultValue = true, Group = "Fibonacci Retracement")]
    public bool FillEleventhFibonacciRetracement { get; set; }

    [Parameter("11th Level Percent", DefaultValue = 4.236, Group = "Fibonacci Retracement")]
    public double EleventhFibonacciRetracementPercent { get; set; }

    [Parameter("11th Level Color", DefaultValue = "40D2691E", Group = "Fibonacci Retracement")]
    public string EleventhFibonacciRetracementColor { get; set; }

    [Parameter("11th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Retracement")]
    public int EleventhFibonacciRetracementThickness { get; set; }

    [Parameter("11th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Retracement")]
    public LineStyle EleventhFibonacciRetracementStyle { get; set; }

    [Parameter("11th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Retracement")]
    public bool EleventhFibonacciRetracementExtendToInfinity { get; set; }

    #endregion Fibonacci Retracement parameters

    #region Fibonacci Expansion parameters

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowFirstFibonacciExpansion { get; set; }

    [Parameter("Fill 1st Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillFirstFibonacciExpansion { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0, Group = "Fibonacci Expansion")]
    public double FirstFibonacciExpansionPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "40808080", Group = "Fibonacci Expansion")]
    public string FirstFibonacciExpansionColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int FirstFibonacciExpansionThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle FirstFibonacciExpansionStyle { get; set; }

    [Parameter("1st Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool FirstFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowSecondFibonacciExpansion { get; set; }

    [Parameter("Fill 2nd Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillSecondFibonacciExpansion { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.236, Group = "Fibonacci Expansion")]
    public double SecondFibonacciExpansionPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "40FF0000", Group = "Fibonacci Expansion")]
    public string SecondFibonacciExpansionColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int SecondFibonacciExpansionThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle SecondFibonacciExpansionStyle { get; set; }

    [Parameter("2nd Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool SecondFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowThirdFibonacciExpansion { get; set; }

    [Parameter("Fill 3rd Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillThirdFibonacciExpansion { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.382, Group = "Fibonacci Expansion")]
    public double ThirdFibonacciExpansionPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "40ADFF2F", Group = "Fibonacci Expansion")]
    public string ThirdFibonacciExpansionColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int ThirdFibonacciExpansionThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle ThirdFibonacciExpansionStyle { get; set; }

    [Parameter("3rd Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool ThirdFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowFourthFibonacciExpansion { get; set; }

    [Parameter("Fill 4th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillFourthFibonacciExpansion { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.5, Group = "Fibonacci Expansion")]
    public double FourthFibonacciExpansionPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "40006400", Group = "Fibonacci Expansion")]
    public string FourthFibonacciExpansionColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int FourthFibonacciExpansionThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle FourthFibonacciExpansionStyle { get; set; }

    [Parameter("4th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool FourthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowFifthFibonacciExpansion { get; set; }

    [Parameter("Fill 5th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillFifthFibonacciExpansion { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.618, Group = "Fibonacci Expansion")]
    public double FifthFibonacciExpansionPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "408A2BE2", Group = "Fibonacci Expansion")]
    public string FifthFibonacciExpansionColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int FifthFibonacciExpansionThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle FifthFibonacciExpansionStyle { get; set; }

    [Parameter("5th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool FifthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowSixthFibonacciExpansion { get; set; }

    [Parameter("Fill 6th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillSixthFibonacciExpansion { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 0.786, Group = "Fibonacci Expansion")]
    public double SixthFibonacciExpansionPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "40F0F8FF", Group = "Fibonacci Expansion")]
    public string SixthFibonacciExpansionColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int SixthFibonacciExpansionThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle SixthFibonacciExpansionStyle { get; set; }

    [Parameter("6th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool SixthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowSeventhFibonacciExpansion { get; set; }

    [Parameter("Fill 7th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillSeventhFibonacciExpansion { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1, Group = "Fibonacci Expansion")]
    public double SeventhFibonacciExpansionPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "40FFE4C4", Group = "Fibonacci Expansion")]
    public string SeventhFibonacciExpansionColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int SeventhFibonacciExpansionThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle SeventhFibonacciExpansionStyle { get; set; }

    [Parameter("7th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool SeventhFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowEighthFibonacciExpansion { get; set; }

    [Parameter("Fill 8th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillEighthFibonacciExpansion { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.618, Group = "Fibonacci Expansion")]
    public double EighthFibonacciExpansionPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "40F0FFFF", Group = "Fibonacci Expansion")]
    public string EighthFibonacciExpansionColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int EighthFibonacciExpansionThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle EighthFibonacciExpansionStyle { get; set; }

    [Parameter("8th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool EighthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowNinthFibonacciExpansion { get; set; }

    [Parameter("Fill 9th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillNinthFibonacciExpansion { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2.618, Group = "Fibonacci Expansion")]
    public double NinthFibonacciExpansionPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "4000FFFF", Group = "Fibonacci Expansion")]
    public string NinthFibonacciExpansionColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int NinthFibonacciExpansionThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle NinthFibonacciExpansionStyle { get; set; }

    [Parameter("9th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool NinthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 10th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowTenthFibonacciExpansion { get; set; }

    [Parameter("Fill 10th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillTenthFibonacciExpansion { get; set; }

    [Parameter("10th Level Percent", DefaultValue = 3.618, Group = "Fibonacci Expansion")]
    public double TenthFibonacciExpansionPercent { get; set; }

    [Parameter("10th Level Color", DefaultValue = "407FFFD4", Group = "Fibonacci Expansion")]
    public string TenthFibonacciExpansionColor { get; set; }

    [Parameter("10th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int TenthFibonacciExpansionThickness { get; set; }

    [Parameter("10th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle TenthFibonacciExpansionStyle { get; set; }

    [Parameter("10th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool TenthFibonacciExpansionExtendToInfinity { get; set; }

    [Parameter("Show 11th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool ShowEleventhFibonacciExpansion { get; set; }

    [Parameter("Fill 11th Level", DefaultValue = true, Group = "Fibonacci Expansion")]
    public bool FillEleventhFibonacciExpansion { get; set; }

    [Parameter("11th Level Percent", DefaultValue = 4.236, Group = "Fibonacci Expansion")]
    public double EleventhFibonacciExpansionPercent { get; set; }

    [Parameter("11th Level Color", DefaultValue = "40D2691E", Group = "Fibonacci Expansion")]
    public string EleventhFibonacciExpansionColor { get; set; }

    [Parameter("11th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Expansion")]
    public int EleventhFibonacciExpansionThickness { get; set; }

    [Parameter("11th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Expansion")]
    public LineStyle EleventhFibonacciExpansionStyle { get; set; }

    [Parameter("11th Level Extend To Infinity", DefaultValue = false, Group = "Fibonacci Expansion")]
    public bool EleventhFibonacciExpansionExtendToInfinity { get; set; }

    #endregion Fibonacci Expansion parameters

    #region Fibonacci Speed Resistance Fan parameters

    [Parameter("Rectangle Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanRectangleThickness { get; set; }

    [Parameter("Rectangle Style", DefaultValue = LineStyle.Dots, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanRectangleStyle { get; set; }

    [Parameter("Rectangle Color", DefaultValue = "FF0000FF", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanRectangleColor { get; set; }

    [Parameter("Extended Lines Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanExtendedLinesThickness { get; set; }

    [Parameter("Extended Lines Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanExtendedLinesStyle { get; set; }

    [Parameter("Extended Lines Color", DefaultValue = "FF0000FF", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanExtendedLinesColor { get; set; }

    [Parameter("Show Price Levels", DefaultValue = true, Group = "Fibonacci Speed Resistance Fan")]
    public bool FibonacciSpeedResistanceFanShowPriceLevels { get; set; }

    [Parameter("Price Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanPriceLevelsThickness { get; set; }

    [Parameter("Price Levels Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanPriceLevelsStyle { get; set; }

    [Parameter("Price Levels Color", DefaultValue = "FFFF00FF", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanPriceLevelsColor { get; set; }

    [Parameter("Show Time Levels", DefaultValue = true, Group = "Fibonacci Speed Resistance Fan")]
    public bool FibonacciSpeedResistanceFanShowTimeLevels { get; set; }

    [Parameter("Time Levels Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanTimeLevelsThickness { get; set; }

    [Parameter("Time Levels Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanTimeLevelsStyle { get; set; }

    [Parameter("Time Levels Color", DefaultValue = "FFFF0000", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanTimeLevelsColor { get; set; }

    [Parameter("Main Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanMainFanThickness { get; set; }

    [Parameter("Main Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanMainFanStyle { get; set; }

    [Parameter("Main Fan Color", DefaultValue = "FFFF0000", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanMainFanColor { get; set; }

    [Parameter("1st Fan Percent", DefaultValue = 0.25, Group = "Fibonacci Speed Resistance Fan")]
    public double FibonacciSpeedResistanceFanFirstFanPercent { get; set; }

    [Parameter("1st Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanFirstFanThickness { get; set; }

    [Parameter("1st Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanFirstFanStyle { get; set; }

    [Parameter("1st Fan Color", DefaultValue = "FFFF0000", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanFirstFanColor { get; set; }

    [Parameter("2nd Fan Percent", DefaultValue = 0.382, Group = "Fibonacci Speed Resistance Fan")]
    public double FibonacciSpeedResistanceFanSecondFanPercent { get; set; }

    [Parameter("2nd Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanSecondFanThickness { get; set; }

    [Parameter("2nd Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanSecondFanStyle { get; set; }

    [Parameter("2nd Fan Color", DefaultValue = "FFA52A2A", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanSecondFanColor { get; set; }

    [Parameter("3rd Fan Percent", DefaultValue = 0.5, Group = "Fibonacci Speed Resistance Fan")]
    public double FibonacciSpeedResistanceFanThirdFanPercent { get; set; }

    [Parameter("3rd Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanThirdFanThickness { get; set; }

    [Parameter("3rd Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanThirdFanStyle { get; set; }

    [Parameter("3rd Fan Color", DefaultValue = "FF00FF00", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanThirdFanColor { get; set; }

    [Parameter("4th Fan Percent", DefaultValue = 0.618, Group = "Fibonacci Speed Resistance Fan")]
    public double FibonacciSpeedResistanceFanFourthFanPercent { get; set; }

    [Parameter("4th Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanFourthFanThickness { get; set; }

    [Parameter("4th Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanFourthFanStyle { get; set; }

    [Parameter("4th Fan Color", DefaultValue = "FFFF00FF", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanFourthFanColor { get; set; }

    [Parameter("5th Fan Percent", DefaultValue = 0.75, Group = "Fibonacci Speed Resistance Fan")]
    public double FibonacciSpeedResistanceFanFifthFanPercent { get; set; }

    [Parameter("5th Fan Thickness", DefaultValue = 1, MinValue = 1, Group = "Fibonacci Speed Resistance Fan")]
    public int FibonacciSpeedResistanceFanFifthFanThickness { get; set; }

    [Parameter("5th Fan Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Speed Resistance Fan")]
    public LineStyle FibonacciSpeedResistanceFanFifthFanStyle { get; set; }

    [Parameter("5th Fan Color", DefaultValue = "FF0000FF", Group = "Fibonacci Speed Resistance Fan")]
    public string FibonacciSpeedResistanceFanFifthFanColor { get; set; }

    #endregion Fibonacci Speed Resistance Fan parameters

    #region Fibonacci Time Zone parameters

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowFirstFibonacciTimeZone { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0, Group = "Fibonacci Time Zone")]
    public double FirstFibonacciTimeZonePercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Fibonacci Time Zone")]
    public string FirstFibonacciTimeZoneColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int FirstFibonacciTimeZoneThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle FirstFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowSecondFibonacciTimeZone { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 1, Group = "Fibonacci Time Zone")]
    public double SecondFibonacciTimeZonePercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Fibonacci Time Zone")]
    public string SecondFibonacciTimeZoneColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int SecondFibonacciTimeZoneThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle SecondFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowThirdFibonacciTimeZone { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 2, Group = "Fibonacci Time Zone")]
    public double ThirdFibonacciTimeZonePercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Fibonacci Time Zone")]
    public string ThirdFibonacciTimeZoneColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int ThirdFibonacciTimeZoneThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle ThirdFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowFourthFibonacciTimeZone { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 3, Group = "Fibonacci Time Zone")]
    public double FourthFibonacciTimeZonePercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Fibonacci Time Zone")]
    public string FourthFibonacciTimeZoneColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int FourthFibonacciTimeZoneThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle FourthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowFifthFibonacciTimeZone { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 5, Group = "Fibonacci Time Zone")]
    public double FifthFibonacciTimeZonePercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Fibonacci Time Zone")]
    public string FifthFibonacciTimeZoneColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int FifthFibonacciTimeZoneThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle FifthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowSixthFibonacciTimeZone { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 8, Group = "Fibonacci Time Zone")]
    public double SixthFibonacciTimeZonePercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Fibonacci Time Zone")]
    public string SixthFibonacciTimeZoneColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int SixthFibonacciTimeZoneThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle SixthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowSeventhFibonacciTimeZone { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 13, Group = "Fibonacci Time Zone")]
    public double SeventhFibonacciTimeZonePercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Fibonacci Time Zone")]
    public string SeventhFibonacciTimeZoneColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int SeventhFibonacciTimeZoneThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle SeventhFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowEighthFibonacciTimeZone { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 21, Group = "Fibonacci Time Zone")]
    public double EighthFibonacciTimeZonePercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Fibonacci Time Zone")]
    public string EighthFibonacciTimeZoneColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int EighthFibonacciTimeZoneThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle EighthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowNinthFibonacciTimeZone { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 34, Group = "Fibonacci Time Zone")]
    public double NinthFibonacciTimeZonePercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Fibonacci Time Zone")]
    public string NinthFibonacciTimeZoneColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int NinthFibonacciTimeZoneThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle NinthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 10th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowTenthFibonacciTimeZone { get; set; }

    [Parameter("10th Level Percent", DefaultValue = 55, Group = "Fibonacci Time Zone")]
    public double TenthFibonacciTimeZonePercent { get; set; }

    [Parameter("10th Level Color", DefaultValue = "FF7FFFD4", Group = "Fibonacci Time Zone")]
    public string TenthFibonacciTimeZoneColor { get; set; }

    [Parameter("10th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int TenthFibonacciTimeZoneThickness { get; set; }

    [Parameter("10th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle TenthFibonacciTimeZoneStyle { get; set; }

    [Parameter("Show 11th Level", DefaultValue = true, Group = "Fibonacci Time Zone")]
    public bool ShowEleventhFibonacciTimeZone { get; set; }

    [Parameter("11th Level Percent", DefaultValue = 89, Group = "Fibonacci Time Zone")]
    public double EleventhFibonacciTimeZonePercent { get; set; }

    [Parameter("11th Level Color", DefaultValue = "FFD2691E", Group = "Fibonacci Time Zone")]
    public string EleventhFibonacciTimeZoneColor { get; set; }

    [Parameter("11th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Time Zone")]
    public int EleventhFibonacciTimeZoneThickness { get; set; }

    [Parameter("11th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Time Zone")]
    public LineStyle EleventhFibonacciTimeZoneStyle { get; set; }

    #endregion Fibonacci Time Zone parameters

    #region Trend Based Fibonacci Time Parameters

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowFirstTrendBasedFibonacciTime { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0, Group = "Trend Based Fibonacci Time")]
    public double FirstTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Trend Based Fibonacci Time")]
    public string FirstTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int FirstTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle FirstTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowSecondTrendBasedFibonacciTime { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.382, Group = "Trend Based Fibonacci Time")]
    public double SecondTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Trend Based Fibonacci Time")]
    public string SecondTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int SecondTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle SecondTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowThirdTrendBasedFibonacciTime { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.5, Group = "Trend Based Fibonacci Time")]
    public double ThirdTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Trend Based Fibonacci Time")]
    public string ThirdTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int ThirdTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle ThirdTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowFourthTrendBasedFibonacciTime { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.618, Group = "Trend Based Fibonacci Time")]
    public double FourthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Trend Based Fibonacci Time")]
    public string FourthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int FourthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle FourthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowFifthTrendBasedFibonacciTime { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 1, Group = "Trend Based Fibonacci Time")]
    public double FifthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Trend Based Fibonacci Time")]
    public string FifthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int FifthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle FifthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowSixthTrendBasedFibonacciTime { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 1.382, Group = "Trend Based Fibonacci Time")]
    public double SixthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Trend Based Fibonacci Time")]
    public string SixthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int SixthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle SixthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowSeventhTrendBasedFibonacciTime { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1.618, Group = "Trend Based Fibonacci Time")]
    public double SeventhTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Trend Based Fibonacci Time")]
    public string SeventhTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int SeventhTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle SeventhTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowEighthTrendBasedFibonacciTime { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 2, Group = "Trend Based Fibonacci Time")]
    public double EighthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Trend Based Fibonacci Time")]
    public string EighthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int EighthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle EighthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowNinthTrendBasedFibonacciTime { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2.382, Group = "Trend Based Fibonacci Time")]
    public double NinthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Trend Based Fibonacci Time")]
    public string NinthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int NinthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle NinthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 10th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowTenthTrendBasedFibonacciTime { get; set; }

    [Parameter("10th Level Percent", DefaultValue = 2.618, Group = "Trend Based Fibonacci Time")]
    public double TenthTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("10th Level Color", DefaultValue = "FF7FFFD4", Group = "Trend Based Fibonacci Time")]
    public string TenthTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("10th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int TenthTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("10th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle TenthTrendBasedFibonacciTimeStyle { get; set; }

    [Parameter("Show 11th Level", DefaultValue = true, Group = "Trend Based Fibonacci Time")]
    public bool ShowEleventhTrendBasedFibonacciTime { get; set; }

    [Parameter("11th Level Percent", DefaultValue = 3, Group = "Trend Based Fibonacci Time")]
    public double EleventhTrendBasedFibonacciTimePercent { get; set; }

    [Parameter("11th Level Color", DefaultValue = "FFD2691E", Group = "Trend Based Fibonacci Time")]
    public string EleventhTrendBasedFibonacciTimeColor { get; set; }

    [Parameter("11th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Trend Based Fibonacci Time")]
    public int EleventhTrendBasedFibonacciTimeThickness { get; set; }

    [Parameter("11th Level Style", DefaultValue = LineStyle.Solid, Group = "Trend Based Fibonacci Time")]
    public LineStyle EleventhTrendBasedFibonacciTimeStyle { get; set; }

    #endregion Trend Based Fibonacci Time Parameters

    #region Fibonacci Channel parameters

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowFirstFibonacciChannel { get; set; }

    [Parameter("Fill 1st Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillFirstFibonacciChannel { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0, Group = "Fibonacci Channel")]
    public double FirstFibonacciChannelPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Fibonacci Channel")]
    public string FirstFibonacciChannelColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int FirstFibonacciChannelThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle FirstFibonacciChannelStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowSecondFibonacciChannel { get; set; }

    [Parameter("Fill 2nd Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillSecondFibonacciChannel { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.236, Group = "Fibonacci Channel")]
    public double SecondFibonacciChannelPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Fibonacci Channel")]
    public string SecondFibonacciChannelColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int SecondFibonacciChannelThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle SecondFibonacciChannelStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowThirdFibonacciChannel { get; set; }

    [Parameter("Fill 3rd Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillThirdFibonacciChannel { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.382, Group = "Fibonacci Channel")]
    public double ThirdFibonacciChannelPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Fibonacci Channel")]
    public string ThirdFibonacciChannelColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int ThirdFibonacciChannelThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle ThirdFibonacciChannelStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowFourthFibonacciChannel { get; set; }

    [Parameter("Fill 4th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillFourthFibonacciChannel { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.5, Group = "Fibonacci Channel")]
    public double FourthFibonacciChannelPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Fibonacci Channel")]
    public string FourthFibonacciChannelColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int FourthFibonacciChannelThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle FourthFibonacciChannelStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowFifthFibonacciChannel { get; set; }

    [Parameter("Fill 5th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillFifthFibonacciChannel { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.618, Group = "Fibonacci Channel")]
    public double FifthFibonacciChannelPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Fibonacci Channel")]
    public string FifthFibonacciChannelColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int FifthFibonacciChannelThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle FifthFibonacciChannelStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowSixthFibonacciChannel { get; set; }

    [Parameter("Fill 6th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillSixthFibonacciChannel { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 0.786, Group = "Fibonacci Channel")]
    public double SixthFibonacciChannelPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Fibonacci Channel")]
    public string SixthFibonacciChannelColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int SixthFibonacciChannelThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle SixthFibonacciChannelStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowSeventhFibonacciChannel { get; set; }

    [Parameter("Fill 7th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillSeventhFibonacciChannel { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1, Group = "Fibonacci Channel")]
    public double SeventhFibonacciChannelPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Fibonacci Channel")]
    public string SeventhFibonacciChannelColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int SeventhFibonacciChannelThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle SeventhFibonacciChannelStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowEighthFibonacciChannel { get; set; }

    [Parameter("Fill 8th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillEighthFibonacciChannel { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.618, Group = "Fibonacci Channel")]
    public double EighthFibonacciChannelPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Fibonacci Channel")]
    public string EighthFibonacciChannelColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int EighthFibonacciChannelThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle EighthFibonacciChannelStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowNinthFibonacciChannel { get; set; }

    [Parameter("Fill 9th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillNinthFibonacciChannel { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2.618, Group = "Fibonacci Channel")]
    public double NinthFibonacciChannelPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Fibonacci Channel")]
    public string NinthFibonacciChannelColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int NinthFibonacciChannelThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle NinthFibonacciChannelStyle { get; set; }

    [Parameter("Show 10th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowTenthFibonacciChannel { get; set; }

    [Parameter("Fill 10th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillTenthFibonacciChannel { get; set; }

    [Parameter("10th Level Percent", DefaultValue = 3.618, Group = "Fibonacci Channel")]
    public double TenthFibonacciChannelPercent { get; set; }

    [Parameter("10th Level Color", DefaultValue = "FF7FFFD4", Group = "Fibonacci Channel")]
    public string TenthFibonacciChannelColor { get; set; }

    [Parameter("10th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int TenthFibonacciChannelThickness { get; set; }

    [Parameter("10th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle TenthFibonacciChannelStyle { get; set; }

    [Parameter("Show 11th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool ShowEleventhFibonacciChannel { get; set; }

    [Parameter("Fill 11th Level", DefaultValue = true, Group = "Fibonacci Channel")]
    public bool FillEleventhFibonacciChannel { get; set; }

    [Parameter("11th Level Percent", DefaultValue = 4.236, Group = "Fibonacci Channel")]
    public double EleventhFibonacciChannelPercent { get; set; }

    [Parameter("11th Level Color", DefaultValue = "FFD2691E", Group = "Fibonacci Channel")]
    public string EleventhFibonacciChannelColor { get; set; }

    [Parameter("11th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Fibonacci Channel")]
    public int EleventhFibonacciChannelThickness { get; set; }

    [Parameter("11th Level Style", DefaultValue = LineStyle.Solid, Group = "Fibonacci Channel")]
    public LineStyle EleventhFibonacciChannelStyle { get; set; }

    #endregion Fibonacci Channel parameters

    #region Original Pitchfork parameters

    [Parameter("Median Thickness", DefaultValue = 1, MinValue = 1, Group = "Original Pitchfork")]
    public int OriginalPitchforkMedianThickness { get; set; }

    [Parameter("Median Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle OriginalPitchforkMedianStyle { get; set; }

    [Parameter("Median Color", DefaultValue = "FF0000FF", Group = "Original Pitchfork")]
    public string OriginalPitchforkMedianColor { get; set; }

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowFirstOriginalPitchfork { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0.25, Group = "Original Pitchfork")]
    public double FirstOriginalPitchforkPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Original Pitchfork")]
    public string FirstOriginalPitchforkColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int FirstOriginalPitchforkThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle FirstOriginalPitchforkStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowSecondOriginalPitchfork { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.382, Group = "Original Pitchfork")]
    public double SecondOriginalPitchforkPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Original Pitchfork")]
    public string SecondOriginalPitchforkColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int SecondOriginalPitchforkThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle SecondOriginalPitchforkStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowThirdOriginalPitchfork { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.5, Group = "Original Pitchfork")]
    public double ThirdOriginalPitchforkPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Original Pitchfork")]
    public string ThirdOriginalPitchforkColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int ThirdOriginalPitchforkThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle ThirdOriginalPitchforkStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowFourthOriginalPitchfork { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.618, Group = "Original Pitchfork")]
    public double FourthOriginalPitchforkPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Original Pitchfork")]
    public string FourthOriginalPitchforkColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int FourthOriginalPitchforkThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle FourthOriginalPitchforkStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowFifthOriginalPitchfork { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.75, Group = "Original Pitchfork")]
    public double FifthOriginalPitchforkPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Original Pitchfork")]
    public string FifthOriginalPitchforkColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int FifthOriginalPitchforkThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle FifthOriginalPitchforkStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowSixthOriginalPitchfork { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 1, Group = "Original Pitchfork")]
    public double SixthOriginalPitchforkPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Original Pitchfork")]
    public string SixthOriginalPitchforkColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int SixthOriginalPitchforkThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle SixthOriginalPitchforkStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowSeventhOriginalPitchfork { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1.5, Group = "Original Pitchfork")]
    public double SeventhOriginalPitchforkPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Original Pitchfork")]
    public string SeventhOriginalPitchforkColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int SeventhOriginalPitchforkThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle SeventhOriginalPitchforkStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowEighthOriginalPitchfork { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.75, Group = "Original Pitchfork")]
    public double EighthOriginalPitchforkPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Original Pitchfork")]
    public string EighthOriginalPitchforkColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int EighthOriginalPitchforkThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle EighthOriginalPitchforkStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Original Pitchfork")]
    public bool ShowNinthOriginalPitchfork { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2, Group = "Original Pitchfork")]
    public double NinthOriginalPitchforkPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Original Pitchfork")]
    public string NinthOriginalPitchforkColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Original Pitchfork")]
    public int NinthOriginalPitchforkThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Original Pitchfork")]
    public LineStyle NinthOriginalPitchforkStyle { get; set; }

    #endregion Original Pitchfork parameters

    #region Schiff Pitchfork parameters

    [Parameter("Median Thickness", DefaultValue = 1, MinValue = 1, Group = "Schiff Pitchfork")]
    public int SchiffPitchforkMedianThickness { get; set; }

    [Parameter("Median Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle SchiffPitchforkMedianStyle { get; set; }

    [Parameter("Median Color", DefaultValue = "FF0000FF", Group = "Schiff Pitchfork")]
    public string SchiffPitchforkMedianColor { get; set; }

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowFirstSchiffPitchfork { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0.25, Group = "Schiff Pitchfork")]
    public double FirstSchiffPitchforkPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Schiff Pitchfork")]
    public string FirstSchiffPitchforkColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int FirstSchiffPitchforkThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle FirstSchiffPitchforkStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowSecondSchiffPitchfork { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.382, Group = "Schiff Pitchfork")]
    public double SecondSchiffPitchforkPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Schiff Pitchfork")]
    public string SecondSchiffPitchforkColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int SecondSchiffPitchforkThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle SecondSchiffPitchforkStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowThirdSchiffPitchfork { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.5, Group = "Schiff Pitchfork")]
    public double ThirdSchiffPitchforkPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Schiff Pitchfork")]
    public string ThirdSchiffPitchforkColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int ThirdSchiffPitchforkThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle ThirdSchiffPitchforkStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowFourthSchiffPitchfork { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.618, Group = "Schiff Pitchfork")]
    public double FourthSchiffPitchforkPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Schiff Pitchfork")]
    public string FourthSchiffPitchforkColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int FourthSchiffPitchforkThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle FourthSchiffPitchforkStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowFifthSchiffPitchfork { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.75, Group = "Schiff Pitchfork")]
    public double FifthSchiffPitchforkPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Schiff Pitchfork")]
    public string FifthSchiffPitchforkColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int FifthSchiffPitchforkThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle FifthSchiffPitchforkStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowSixthSchiffPitchfork { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 1, Group = "Schiff Pitchfork")]
    public double SixthSchiffPitchforkPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Schiff Pitchfork")]
    public string SixthSchiffPitchforkColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int SixthSchiffPitchforkThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle SixthSchiffPitchforkStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowSeventhSchiffPitchfork { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1.5, Group = "Schiff Pitchfork")]
    public double SeventhSchiffPitchforkPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Schiff Pitchfork")]
    public string SeventhSchiffPitchforkColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int SeventhSchiffPitchforkThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle SeventhSchiffPitchforkStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowEighthSchiffPitchfork { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.75, Group = "Schiff Pitchfork")]
    public double EighthSchiffPitchforkPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Schiff Pitchfork")]
    public string EighthSchiffPitchforkColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int EighthSchiffPitchforkThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle EighthSchiffPitchforkStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Schiff Pitchfork")]
    public bool ShowNinthSchiffPitchfork { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2, Group = "Schiff Pitchfork")]
    public double NinthSchiffPitchforkPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Schiff Pitchfork")]
    public string NinthSchiffPitchforkColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Schiff Pitchfork")]
    public int NinthSchiffPitchforkThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Schiff Pitchfork")]
    public LineStyle NinthSchiffPitchforkStyle { get; set; }

    #endregion Schiff Pitchfork parameters

    #region Modified Schiff Pitchfork parameters

    [Parameter("Median Thickness", DefaultValue = 1, MinValue = 1, Group = "Modified Schiff Pitchfork")]
    public int ModifiedSchiffPitchforkMedianThickness { get; set; }

    [Parameter("Median Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle ModifiedSchiffPitchforkMedianStyle { get; set; }

    [Parameter("Median Color", DefaultValue = "FF0000FF", Group = "Modified Schiff Pitchfork")]
    public string ModifiedSchiffPitchforkMedianColor { get; set; }

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowFirstModifiedSchiffPitchfork { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0.25, Group = "Modified Schiff Pitchfork")]
    public double FirstModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Modified Schiff Pitchfork")]
    public string FirstModifiedSchiffPitchforkColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int FirstModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle FirstModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowSecondModifiedSchiffPitchfork { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.382, Group = "Modified Schiff Pitchfork")]
    public double SecondModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Modified Schiff Pitchfork")]
    public string SecondModifiedSchiffPitchforkColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int SecondModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle SecondModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowThirdModifiedSchiffPitchfork { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.5, Group = "Modified Schiff Pitchfork")]
    public double ThirdModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Modified Schiff Pitchfork")]
    public string ThirdModifiedSchiffPitchforkColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int ThirdModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle ThirdModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowFourthModifiedSchiffPitchfork { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.618, Group = "Modified Schiff Pitchfork")]
    public double FourthModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Modified Schiff Pitchfork")]
    public string FourthModifiedSchiffPitchforkColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int FourthModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle FourthModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowFifthModifiedSchiffPitchfork { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.75, Group = "Modified Schiff Pitchfork")]
    public double FifthModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Modified Schiff Pitchfork")]
    public string FifthModifiedSchiffPitchforkColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int FifthModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle FifthModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowSixthModifiedSchiffPitchfork { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 1, Group = "Modified Schiff Pitchfork")]
    public double SixthModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Modified Schiff Pitchfork")]
    public string SixthModifiedSchiffPitchforkColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int SixthModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle SixthModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowSeventhModifiedSchiffPitchfork { get; set; }

    [Parameter("7th Level Percent", DefaultValue = 1.5, Group = "Modified Schiff Pitchfork")]
    public double SeventhModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Modified Schiff Pitchfork")]
    public string SeventhModifiedSchiffPitchforkColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int SeventhModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle SeventhModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowEighthModifiedSchiffPitchfork { get; set; }

    [Parameter("8th Level Percent", DefaultValue = 1.75, Group = "Modified Schiff Pitchfork")]
    public double EighthModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Modified Schiff Pitchfork")]
    public string EighthModifiedSchiffPitchforkColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int EighthModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle EighthModifiedSchiffPitchforkStyle { get; set; }

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Modified Schiff Pitchfork")]
    public bool ShowNinthModifiedSchiffPitchfork { get; set; }

    [Parameter("9th Level Percent", DefaultValue = 2, Group = "Modified Schiff Pitchfork")]
    public double NinthModifiedSchiffPitchforkPercent { get; set; }

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Modified Schiff Pitchfork")]
    public string NinthModifiedSchiffPitchforkColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Modified Schiff Pitchfork")]
    public int NinthModifiedSchiffPitchforkThickness { get; set; }

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Modified Schiff Pitchfork")]
    public LineStyle NinthModifiedSchiffPitchforkStyle { get; set; }

    #endregion Modified Schiff Pitchfork parameters

    #region Pitchfan parameters

    [Parameter("Median Thickness", DefaultValue = 1, MinValue = 1, Group = "Pitchfan")]
    public int PitchfanMedianThickness { get; set; }

    [Parameter("Median Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle PitchfanMedianStyle { get; set; }

    [Parameter("Median Color", DefaultValue = "FF0000FF", Group = "Pitchfan")]
    public string PitchfanMedianColor { get; set; }

    [Parameter("Show 1st Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowFirstPitchfan { get; set; }

    [Parameter("1st Level Percent", DefaultValue = 0.25, Group = "Pitchfan")]
    public double FirstPitchfanPercent { get; set; }

    [Parameter("1st Level Color", DefaultValue = "FF808080", Group = "Pitchfan")]
    public string FirstPitchfanColor { get; set; }

    [Parameter("1st Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int FirstPitchfanThickness { get; set; }

    [Parameter("1st Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle FirstPitchfanStyle { get; set; }

    [Parameter("Show 2nd Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowSecondPitchfan { get; set; }

    [Parameter("2nd Level Percent", DefaultValue = 0.382, Group = "Pitchfan")]
    public double SecondPitchfanPercent { get; set; }

    [Parameter("2nd Level Color", DefaultValue = "FFFF0000", Group = "Pitchfan")]
    public string SecondPitchfanColor { get; set; }

    [Parameter("2nd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int SecondPitchfanThickness { get; set; }

    [Parameter("2nd Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle SecondPitchfanStyle { get; set; }

    [Parameter("Show 3rd Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowThirdPitchfan { get; set; }

    [Parameter("3rd Level Percent", DefaultValue = 0.5, Group = "Pitchfan")]
    public double ThirdPitchfanPercent { get; set; }

    [Parameter("3rd Level Color", DefaultValue = "FFADFF2F", Group = "Pitchfan")]
    public string ThirdPitchfanColor { get; set; }

    [Parameter("3rd Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int ThirdPitchfanThickness { get; set; }

    [Parameter("3rd Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle ThirdPitchfanStyle { get; set; }

    [Parameter("Show 4th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowFourthPitchfan { get; set; }

    [Parameter("4th Level Percent", DefaultValue = 0.618, Group = "Pitchfan")]
    public double FourthPitchfanPercent { get; set; }

    [Parameter("4th Level Color", DefaultValue = "FF006400", Group = "Pitchfan")]
    public string FourthPitchfanColor { get; set; }

    [Parameter("4th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int FourthPitchfanThickness { get; set; }

    [Parameter("4th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle FourthPitchfanStyle { get; set; }

    [Parameter("Show 5th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowFifthPitchfan { get; set; }

    [Parameter("5th Level Percent", DefaultValue = 0.75, Group = "Pitchfan")]
    public double FifthPitchfanPercent { get; set; }

    [Parameter("5th Level Color", DefaultValue = "FF8A2BE2", Group = "Pitchfan")]
    public string FifthPitchfanColor { get; set; }

    [Parameter("5th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int FifthPitchfanThickness { get; set; }

    [Parameter("5th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle FifthPitchfanStyle { get; set; }

    [Parameter("Show 6th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowSixthPitchfan { get; set; }

    [Parameter("6th Level Percent", DefaultValue = 1, Group = "Pitchfan")]
    public double SixthPitchfanPercent { get; set; }

    [Parameter("6th Level Color", DefaultValue = "FFF0F8FF", Group = "Pitchfan")]
    public string SixthPitchfanColor { get; set; }

    [Parameter("6th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int SixthPitchfanThickness { get; set; }

    [Parameter("6th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle SixthPitchfanStyle { get; set; } = LineStyle.Solid;

    [Parameter("Show 7th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowSeventhPitchfan { get; set; } = true;

    [Parameter("7th Level Percent", DefaultValue = 1.5, Group = "Pitchfan")]
    public double SeventhPitchfanPercent { get; set; } = 1.5;

    [Parameter("7th Level Color", DefaultValue = "FFFFE4C4", Group = "Pitchfan")]
    public string SeventhPitchfanColor { get; set; }

    [Parameter("7th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int SeventhPitchfanThickness { get; set; } = 1;

    [Parameter("7th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle SeventhPitchfanStyle { get; set; } = LineStyle.Solid;

    [Parameter("Show 8th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowEighthPitchfan { get; set; } = true;

    [Parameter("8th Level Percent", DefaultValue = 1.75, Group = "Pitchfan")]
    public double EighthPitchfanPercent { get; set; } = 1.75;

    [Parameter("8th Level Color", DefaultValue = "FFF0FFFF", Group = "Pitchfan")]
    public string EighthPitchfanColor { get; set; }

    [Parameter("8th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int EighthPitchfanThickness { get; set; } = 1;

    [Parameter("8th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle EighthPitchfanStyle { get; set; } = LineStyle.Solid;

    [Parameter("Show 9th Level", DefaultValue = true, Group = "Pitchfan")]
    public bool ShowNinthPitchfan { get; set; } = true;

    [Parameter("9th Level Percent", DefaultValue = 2, Group = "Pitchfan")]
    public double NinthPitchfanPercent { get; set; } = 2;

    [Parameter("9th Level Color", DefaultValue = "FF00FFFF", Group = "Pitchfan")]
    public string NinthPitchfanColor { get; set; }

    [Parameter("9th Level Thickness", DefaultValue = 1, MinValue = 0, Group = "Pitchfan")]
    public int NinthPitchfanThickness { get; set; } = 1;

    [Parameter("9th Level Style", DefaultValue = LineStyle.Solid, Group = "Pitchfan")]
    public LineStyle NinthPitchfanStyle { get; set; } = LineStyle.Solid;

    #endregion Pitchfan parameters

    #region Measure parameters

    [Parameter("Up Color", DefaultValue = "700070C0", Group = "Measure")]
    public string MeasureUpColor { get; set; }

    [Parameter("Down Color", DefaultValue = "70FE0000", Group = "Measure")]
    public string MeasureDownColor { get; set; }

    [Parameter("Thickness", DefaultValue = 1, Group = "Measure")]
    public int MeasureThickness { get; set; } = 1;

    [Parameter("Style", DefaultValue = LineStyle.Solid, Group = "Measure")]
    public LineStyle MeasureStyle { get; set; } = LineStyle.Solid;

    [Parameter("Filled", DefaultValue = true, Group = "Measure")]
    public bool MeasureIsFilled { get; set; } = true;

    [Parameter("Text Color", DefaultValue = "FFFFFF00", Group = "Measure")]
    public string MeasureTextColor { get; set; }

    [Parameter("Font Size", DefaultValue = 10, Group = "Measure")]
    public int MeasureFontSize { get; set; } = 10;

    [Parameter("Text Bold", DefaultValue = true, Group = "Measure")]
    public bool MeasureIsTextBold { get; set; } = true;

    #endregion
}