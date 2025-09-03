using cAlgo.API;

namespace cAlgo.Patterns
{
    public class CyclesPattern : PatternBase
    {
        private int? _mouseDownBarIndex;

        public CyclesPattern(PatternConfig config) : base("Cycles", config)
        {
        }

        protected override void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
            if (updatedChartObject is not ChartVerticalLine updatedLine) return;
            
            foreach (var patternObject in patternObjects)
            {
                if (patternObject.ObjectType != ChartObjectType.VerticalLine ||
                    patternObject == updatedChartObject) continue;
                
                var verticalLine = patternObject as ChartVerticalLine;

                verticalLine.Color = updatedLine.Color;
                verticalLine.LineStyle = updatedLine.LineStyle;
                verticalLine.Thickness = updatedLine.Thickness;
            }
        }

        protected override void OnDrawingStopped() => _mouseDownBarIndex = null;

        protected override void OnMouseUp(ChartMouseEventArgs obj)
        {
            if (MouseUpNumber == 2) FinishDrawing();
        }

        protected override void OnMouseMove(ChartMouseEventArgs obj)
        {
            if (!_mouseDownBarIndex.HasValue) return;

            var mouseMoveBarIndex = (int) obj.BarIndex;

            var diff = mouseMoveBarIndex - _mouseDownBarIndex.Value;

            for (var i = 0; i < Config.Settings.CyclesNumber; i++)
            {
                var name = GetObjectName(i.ToString());

                var lineIndex = _mouseDownBarIndex.Value + diff * i;

                var verticalLine = obj.Chart.DrawVerticalLine(name, lineIndex, Color);

                verticalLine.IsInteractive = true;
            }
        }

        protected override void OnMouseDown(ChartMouseEventArgs obj)
        {
            if (_mouseDownBarIndex.HasValue) return;

            _mouseDownBarIndex = (int) obj.BarIndex;
        }
    }
}