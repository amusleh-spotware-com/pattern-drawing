using System;
using System.Linq;
using cAlgo.API;

namespace cAlgo.Patterns
{
    public class ElliottDoubleComboWavePattern : ElliottWavePatternBase
    {
        public ElliottDoubleComboWavePattern(PatternConfig config, ElliottWaveDegree degree) : base("EW WXY", config, 3,
            degree)
        {
        }

        protected override void DrawLabels(Chart chart)
        {
            if (FirstLine == null || SecondLine == null || ThirdLine == null) return;

            DrawLabels(chart, FirstLine, SecondLine, ThirdLine, Id);
        }

        private void DrawLabels(Chart chart, ChartTrendLine firstLine, ChartTrendLine secondLine, ChartTrendLine thirdLine, long id)
        {
            switch (Degree)
            {
                case ElliottWaveDegree.SuperMellennium:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((W))", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((X))", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((Y))", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Mellennium:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(W)", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(X)", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(Y)", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.SubMellennium:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "W", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "X", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "Y", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.GrandSuperCycle:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((w))", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((x))", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((y))", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.SuperCycle:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(w)", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(x)", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(y)", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Cycle:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "w", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "x", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "y", thirdLine.Time2, thirdLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Primary:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((W))", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((X))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((Y))", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Intermediate:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(W)", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(X)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(Y)", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minor:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "W", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "X", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "Y", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minute:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((w))", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((x))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((y))", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minuette:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(w)", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(x)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(y)", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.SubMinuette:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "w", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "x", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "y", thirdLine.Time2, thirdLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Micro:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((W))", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((X))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((Y))", thirdLine.Time2, thirdLine.Y2, id, fontSize: 7);
                    break;

                case ElliottWaveDegree.SubMicro:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(W)", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(X)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(Y)", thirdLine.Time2, thirdLine.Y2, id, fontSize: 7);
                    break;

                case ElliottWaveDegree.Minuscule:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "W", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "X", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "Y", thirdLine.Time2, thirdLine.Y2, id, fontSize: 7);
                    break;
            }
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject chartObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            if (patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FirstLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine firstLine || patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("SecondLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine secondLine || patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("ThirdLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine thirdLine) return;

            if (labels.Length == 0)
            {
                DrawLabels(chart, firstLine, secondLine, thirdLine, id);

                return;
            }

            string firstLabelText;
            string secondLabelText;
            string thirdLabelText;
            string fourthLabelText;

            switch (Degree)
            {
                case ElliottWaveDegree.SuperMellennium:
                case ElliottWaveDegree.Primary:
                case ElliottWaveDegree.Micro:
                    firstLabelText = "((0))";
                    secondLabelText = "((W))";
                    thirdLabelText = "((X))";
                    fourthLabelText = "((Y))";
                    break;

                case ElliottWaveDegree.Mellennium:
                case ElliottWaveDegree.Intermediate:
                case ElliottWaveDegree.SubMicro:
                    firstLabelText = "(0)";
                    secondLabelText = "(W)";
                    thirdLabelText = "(X)";
                    fourthLabelText = "(Y)";
                    break;

                case ElliottWaveDegree.SubMellennium:
                case ElliottWaveDegree.Minor:
                case ElliottWaveDegree.Minuscule:
                    firstLabelText = "0";
                    secondLabelText = "W";
                    thirdLabelText = "X";
                    fourthLabelText = "Y";
                    break;

                case ElliottWaveDegree.GrandSuperCycle:
                case ElliottWaveDegree.Minute:
                    firstLabelText = "((0))";
                    secondLabelText = "((w))";
                    thirdLabelText = "((x))";
                    fourthLabelText = "((y))";
                    break;

                case ElliottWaveDegree.SuperCycle:
                case ElliottWaveDegree.Minuette:
                    firstLabelText = "(0)";
                    secondLabelText = "(w)";
                    thirdLabelText = "(x)";
                    fourthLabelText = "(y)";
                    break;

                case ElliottWaveDegree.Cycle:
                case ElliottWaveDegree.SubMinuette:
                    firstLabelText = "0";
                    secondLabelText = "w";
                    thirdLabelText = "x";
                    fourthLabelText = "y";
                    break;

                default:
                    throw new InvalidOperationException("Invalid degree");
            }

            foreach (var label in labels)
                if (label.Text.Equals(firstLabelText, StringComparison.Ordinal))
                {
                    label.Time = firstLine.Time1;
                    label.Y = firstLine.Y1;
                }
                else if (label.Text.Equals(secondLabelText, StringComparison.Ordinal))
                {
                    label.Time = secondLine.Time1;
                    label.Y = secondLine.Y1;
                }
                else if (label.Text.Equals(thirdLabelText, StringComparison.Ordinal))
                {
                    label.Time = thirdLine.Time1;
                    label.Y = thirdLine.Y1;
                }
                else if (label.Text.Equals(fourthLabelText, StringComparison.Ordinal))
                {
                    label.Time = thirdLine.Time2;
                    label.Y = thirdLine.Y2;
                }
        }
    }
}