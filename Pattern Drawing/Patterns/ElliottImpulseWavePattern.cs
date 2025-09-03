using System;
using System.Linq;
using cAlgo.API;

namespace cAlgo.Patterns
{
    public class ElliottImpulseWavePattern : ElliottWavePatternBase
    {
        public ElliottImpulseWavePattern(PatternConfig config, ElliottWaveDegree degree) : base("EW 12345", config, 5,
            degree)
        {
        }

        protected override void DrawLabels(Chart chart)
        {
            if (FirstLine == null || SecondLine == null || ThirdLine == null || FourthLine == null ||
                FifthLine == null) return;

            DrawLabels(chart, FirstLine, SecondLine, ThirdLine, FourthLine, FifthLine, Id);
        }

        private void DrawLabels(Chart chart, ChartTrendLine firstLine, ChartTrendLine secondLine, ChartTrendLine thirdLine,
            ChartTrendLine fourthLine, ChartTrendLine fifthLine, long id)
        {
            switch (Degree)
            {
                case ElliottWaveDegree.SuperMellennium:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((1))", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((2))", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((3))", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((4))", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((5))", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Mellennium:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(1)", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(2)", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(3)", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(4)", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(5)", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.SubMellennium:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "1", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "2", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "3", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "4", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "5", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.GrandSuperCycle:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((I))", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((II))", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((III))", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((IV))", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "((V))", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.SuperCycle:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(I)", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(II)", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(III)", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(IV)", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "(V)", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Cycle:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "I", secondLine.Time1, secondLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "II", thirdLine.Time1, thirdLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "III", fourthLine.Time1, fourthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "IV", fifthLine.Time1, fifthLine.Y1, id, isBold: true);
                    DrawLabelText(chart, "V", fifthLine.Time2, fifthLine.Y2, id, isBold: true);
                    break;

                case ElliottWaveDegree.Primary:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((1))", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((2))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((3))", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((4))", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((5))", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Intermediate:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(1)", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(2)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(3)", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(4)", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(5)", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minor:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "1", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "2", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "3", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "4", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "5", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minute:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((i))", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((ii))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((iii))", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((iv))", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "((v))", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Minuette:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(i)", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(ii)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(iii)", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(iv)", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "(v)", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.SubMinuette:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "i", secondLine.Time1, secondLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "ii", thirdLine.Time1, thirdLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "iii", fourthLine.Time1, fourthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "iv", fifthLine.Time1, fifthLine.Y1, id, fontSize: 10);
                    DrawLabelText(chart, "v", fifthLine.Time2, fifthLine.Y2, id, fontSize: 10);
                    break;

                case ElliottWaveDegree.Micro:
                    DrawLabelText(chart, "((0))", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((1))", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((2))", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((3))", fourthLine.Time1, fourthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((4))", fifthLine.Time1, fifthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "((5))", fifthLine.Time2, fifthLine.Y2, id, fontSize: 7);
                    break;

                case ElliottWaveDegree.SubMicro:
                    DrawLabelText(chart, "(0)", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(1)", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(2)", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(3)", fourthLine.Time1, fourthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(4)", fifthLine.Time1, fifthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "(5)", fifthLine.Time2, fifthLine.Y2, id, fontSize: 7);
                    break;

                case ElliottWaveDegree.Minuscule:
                    DrawLabelText(chart, "0", firstLine.Time1, firstLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "1", secondLine.Time1, secondLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "2", thirdLine.Time1, thirdLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "3", fourthLine.Time1, fourthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "4", fifthLine.Time1, fifthLine.Y1, id, fontSize: 7);
                    DrawLabelText(chart, "5", fifthLine.Time2, fifthLine.Y2, id, fontSize: 7);
                    break;
            }
        }

        protected override void UpdateLabels(Chart chart, long id, ChartObject chartObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
            if (patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FirstLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine firstLine || patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("SecondLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine secondLine || patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("ThirdLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine thirdLine || patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FourthLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine fourthLine ||
                patternObjects.FirstOrDefault(iObject => iObject.Name.EndsWith("FifthLine",
                    StringComparison.OrdinalIgnoreCase)) is not ChartTrendLine fifthLine) return;

            if (labels.Length == 0)
            {
                DrawLabels(chart, firstLine, secondLine, thirdLine, fourthLine, fifthLine, id);

                return;
            }

            string firstLabelText;
            string secondLabelText;
            string thirdLabelText;
            string fourthLabelText;
            string fifthLabelText;
            string sixthLabelText;

            switch (Degree)
            {
                case ElliottWaveDegree.SuperMellennium:
                case ElliottWaveDegree.Primary:
                case ElliottWaveDegree.Micro:
                    firstLabelText = "((0))";
                    secondLabelText = "((1))";
                    thirdLabelText = "((2))";
                    fourthLabelText = "((3))";
                    fifthLabelText = "((4))";
                    sixthLabelText = "((5))";
                    break;

                case ElliottWaveDegree.Mellennium:
                case ElliottWaveDegree.Intermediate:
                case ElliottWaveDegree.SubMicro:
                    firstLabelText = "(0)";
                    secondLabelText = "(1)";
                    thirdLabelText = "(2)";
                    fourthLabelText = "(3)";
                    fifthLabelText = "(4)";
                    sixthLabelText = "(5)";
                    break;

                case ElliottWaveDegree.SubMellennium:
                case ElliottWaveDegree.Minor:
                case ElliottWaveDegree.Minuscule:
                    firstLabelText = "0";
                    secondLabelText = "1";
                    thirdLabelText = "2";
                    fourthLabelText = "3";
                    fifthLabelText = "4";
                    sixthLabelText = "5";
                    break;

                case ElliottWaveDegree.GrandSuperCycle:
                    firstLabelText = "((0))";
                    secondLabelText = "((I))";
                    thirdLabelText = "((II))";
                    fourthLabelText = "((III))";
                    fifthLabelText = "((IV))";
                    sixthLabelText = "((V))";
                    break;

                case ElliottWaveDegree.SuperCycle:
                    firstLabelText = "(0)";
                    secondLabelText = "(I)";
                    thirdLabelText = "(II)";
                    fourthLabelText = "(III)";
                    fifthLabelText = "(IV)";
                    sixthLabelText = "(V)";
                    break;

                case ElliottWaveDegree.Cycle:
                    firstLabelText = "0";
                    secondLabelText = "I";
                    thirdLabelText = "II";
                    fourthLabelText = "III";
                    fifthLabelText = "IV";
                    sixthLabelText = "V";
                    break;

                case ElliottWaveDegree.Minute:
                    firstLabelText = "((0))";
                    secondLabelText = "((i))";
                    thirdLabelText = "((ii))";
                    fourthLabelText = "((iii))";
                    fifthLabelText = "((iv))";
                    sixthLabelText = "((v))";
                    break;

                case ElliottWaveDegree.Minuette:
                    firstLabelText = "(0)";
                    secondLabelText = "(i)";
                    thirdLabelText = "(ii)";
                    fourthLabelText = "(iii)";
                    fifthLabelText = "(iv)";
                    sixthLabelText = "(v)";
                    break;

                case ElliottWaveDegree.SubMinuette:
                    firstLabelText = "0";
                    secondLabelText = "i";
                    thirdLabelText = "ii";
                    fourthLabelText = "iii";
                    fifthLabelText = "iv";
                    sixthLabelText = "v";
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
                    label.Time = fourthLine.Time1;
                    label.Y = fourthLine.Y1;
                }
                else if (label.Text.Equals(fifthLabelText, StringComparison.Ordinal))
                {
                    label.Time = fifthLine.Time1;
                    label.Y = fifthLine.Y1;
                }
                else if (label.Text.Equals(sixthLabelText, StringComparison.Ordinal))
                {
                    label.Time = fifthLine.Time2;
                    label.Y = fifthLine.Y2;
                }
        }
    }
}