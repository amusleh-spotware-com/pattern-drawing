using System;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using cAlgo.API;

namespace cAlgo.Patterns
{
    public abstract class PatternBase : IPattern
    {
        private Chart _lastSubscribedActiveChart;

        protected PatternBase(string name, PatternConfig config, string objectName = null)
        {
            Name = name;
            Config = config;

            ObjectName = string.IsNullOrWhiteSpace(objectName)
                ? $"Pattern_{Name.Replace(" ", "").Replace("_", "")}"
                : objectName;
        }

        protected PatternConfig Config { get; }

        private Chart DrawingChart { get; set; }

        private Chart ActiveChart => (Config.ChartManager.ActiveFrame as ChartFrame)?.Chart;

        protected int MouseUpNumber { get; private set; }

        protected bool IsMouseDown { get; private set; }

        protected Color Color => Config.Color;

        private Color LabelsColor => Config.Settings.PatternsLabelColor;

        private bool ShowLabels => Config.Settings.PatternsLabelShow;

        protected string ObjectName { get; }

        protected long Id { get; private set; }

        public string Name { get; }

        public bool IsDrawing { get; private set; }

        public event Action<IPattern> DrawingStarted;

        public event Action<IPattern> DrawingStopped;

        public void Initialize()
        {
            ExecuteInTryCatch(() =>
            {
                OnInitialize();

                ReloadAllChartsPatterns();

                SubscribeToActiveChartChanged();
                
                SubscribeToActiveChart();

                OnInitialized();
            });
        }

        private void SubscribeToActiveChartChanged()
        {
            SubscribeToActiveChart();
            
            Config.ChartManager.ActiveFrameChanged += OnActiveFrameChanged;
        }

        private void ReloadAllChartsPatterns()
        {
            foreach (var chart in Config.Charts)
                ReloadPatterns(chart, chart.Objects.ToArray());
        }

        private void SubscribeToActiveChart()
        {
            if (ActiveChart is null || ActiveChart == _lastSubscribedActiveChart)
                return;

            _lastSubscribedActiveChart = ActiveChart;
            
            ActiveChart.ObjectsRemoved += OnChartObjectsRemoved;
            
            SubscribeToChartObjectsUpdatedEvent();
        }

        private void UnsubscribeFromLastActiveChart()
        {
            if (_lastSubscribedActiveChart is null)
                return;

            _lastSubscribedActiveChart.ObjectsRemoved -= OnChartObjectsRemoved;

            UnsubscribeFromChartObjectsUpdatedEvent();

            _lastSubscribedActiveChart = null;
        }
        
        private void OnActiveFrameChanged(ActiveFrameChangedEventArgs obj)
        {
            UnsubscribeFromLastActiveChart();

            if (IsDrawing)
                StopDrawing();
            
            SubscribeToActiveChart();
        }

        public void StartDrawing()
        {
            if (IsDrawing) return;

            IsDrawing = true;
            DrawingChart = ActiveChart;
            
            ExecuteInTryCatch(() =>
            {
                UnsubscribeFromChartObjectsUpdatedEvent();

                Id = DateTime.Now.Ticks;

                DrawingChart.MouseDown += OnChartMouseDown;
                DrawingChart.MouseMove += OnChartMouseMove;
                DrawingChart.MouseUp += OnChartMouseUp;

                DrawingChart.IsScrollingEnabled = false;

                OnDrawingStarted();

                var drawingStarted = DrawingStarted;

                drawingStarted?.Invoke(this);
            });
        }

        public void StopDrawing()
        {
            if (!IsDrawing) return;

            IsDrawing = false;

            ExecuteInTryCatch(() =>
            {
                if (ShowLabels) DrawLabels(DrawingChart);

                DrawingChart.MouseDown -= OnChartMouseDown;
                DrawingChart.MouseMove -= OnChartMouseMove;
                DrawingChart.MouseUp -= OnChartMouseUp;

                DrawingChart.IsScrollingEnabled = true;

                MouseUpNumber = 0;

                Id = 0;

                SetFrontObjectsZIndex();

                OnDrawingStopped();

                var drawingStopped = DrawingStopped;

                drawingStopped?.Invoke(this);

                SubscribeToChartObjectsUpdatedEvent();
                
                DrawingChart = null;
            });
        }

        protected virtual void OnInitialize()
        {
        }

        protected virtual void OnInitialized()
        {
        }

        protected void FinishDrawing() => StopDrawing();

        private void SetFrontObjectsZIndex()
        {
            var frontObjects = GetFrontObjects();

            if (frontObjects == null || DrawingChart is null) return;

            var objectsCount = DrawingChart.Objects.Count - 1;

            for (var i = 0; i < frontObjects.Length; i++)
            {
                var chartObject = frontObjects[i];

                if (chartObject == null) continue;

                chartObject.ZIndex = objectsCount - i;
            }
        }

        protected virtual ChartObject[] GetFrontObjects() => Array.Empty<ChartObject>();

        protected virtual void OnDrawingStopped()
        {
        }

        protected virtual void OnDrawingStarted()
        {
        }

        private void OnChartMouseMove(ChartMouseEventArgs obj) => ExecuteInTryCatch(() => OnMouseMove(obj));

        private void OnChartMouseDown(ChartMouseEventArgs obj)
        {
            IsMouseDown = true;

            ExecuteInTryCatch(() => OnMouseDown(obj));
        }

        private void OnChartMouseUp(ChartMouseEventArgs obj)
        {
            IsMouseDown = false;

            MouseUpNumber++;

            ExecuteInTryCatch(() => OnMouseUp(obj));
        }

        private void OnChartObjectsRemoved(ChartObjectsRemovedEventArgs obj)
        {
            var removedPatternObjects = obj.ChartObjects.Where(iRemovedObject => iRemovedObject.Name.StartsWith(
                ObjectName,
                StringComparison.OrdinalIgnoreCase)).ToArray();

            if (removedPatternObjects.Length == 0) return;

            obj.Chart.ObjectsRemoved -= OnChartObjectsRemoved;

            try
            {
                foreach (var chartObject in removedPatternObjects)
                {
                    if (chartObject.ObjectType == ChartObjectType.Text) continue;

                    if (!TryGetChartObjectPatternId(chartObject.Name, out var id)) continue;

                    RemoveObjects(obj.Chart, id);
                }
            }
            finally
            {
                obj.Chart.ObjectsRemoved += OnChartObjectsRemoved;
            }
        }

        private void OnChartObjectsUpdated(ChartObjectsUpdatedEventArgs obj)
        {
            if (IsDrawing) return;

            UnsubscribeFromChartObjectsUpdatedEvent();

            try
            {
                ExecuteInTryCatch(() => ReloadPatterns(obj.Chart, obj.ChartObjects.ToArray()));
            }
            finally
            {
                SubscribeToChartObjectsUpdatedEvent();
            }
        }

        private void RemoveObjects(Chart chart, long id)
        {
            var patternObjectNames = $"{ObjectName}_{id}";

            var chartObjects = chart.Objects.ToArray();

            foreach (var chartObject in chartObjects)
                if (chartObject.Name.StartsWith(patternObjectNames, StringComparison.OrdinalIgnoreCase))
                    chart.RemoveObject(chartObject.Name);
        }

        protected virtual void OnMouseMove(ChartMouseEventArgs obj)
        {
        }

        protected virtual void OnMouseDown(ChartMouseEventArgs obj)
        {
        }

        protected virtual void OnMouseUp(ChartMouseEventArgs obj)
        {
        }

        protected bool TryGetChartObjectPatternId(string chartObjectName, out long id)
        {
            var objectNameSplit = chartObjectName.Split('_');

            if (objectNameSplit.Length < 3
                || !long.TryParse(objectNameSplit[2], NumberStyles.Any, CultureInfo.InvariantCulture, out id))
            {
                id = 0;

                return false;
            }

            return true;
        }

        protected virtual void OnPatternChartObjectsUpdated(Chart chart, long id, ChartObject updatedChartObject,
            ChartObject[] patternObjects)
        {
        }

        protected virtual void DrawLabels(Chart chart)
        {
        }

        protected virtual void UpdateLabels(Chart chart, long id, ChartObject updatedObject, ChartText[] labels,
            ChartObject[] patternObjects)
        {
        }

        protected ChartText DrawLabelText(Chart chart, string text, DateTime time, double y, long id, bool isBold = false,
            double fontSize = 0, string objectNameKey = null, Color color = null)
        {
            var name = string.IsNullOrWhiteSpace(objectNameKey)
                ? $"{ObjectName}_{id}_Label_{text}"
                : $"{ObjectName}_{id}_Label_{objectNameKey}";

            if (color == null) color = LabelsColor;

            var chartText = chart.DrawText(name, text, time, y, color);

            chartText.IsInteractive = true;
            chartText.IsLocked = Config.Settings.PatternsLabelLocked;
            chartText.IsBold = isBold;

            if (fontSize != 0) chartText.FontSize = fontSize;

            return chartText;
        }

        protected string GetObjectName(string data = null, long? id = null)
        {
            data ??= string.Empty;

            return $"{ObjectName}_{id.GetValueOrDefault(Id)}_{data}";
        }

        private void ReloadPatterns(Chart chart, ChartObject[] updatedChartObjects)
        {
            var updatedPatternObjects = updatedChartObjects.Where(iObject => iObject.Name.StartsWith(ObjectName,
                StringComparison.OrdinalIgnoreCase)).ToArray();

            if (updatedPatternObjects.Length == 0) return;

            var chartObjects = chart.Objects.ToArray();

            foreach (var chartObject in updatedPatternObjects)
            {
                if (!TryGetChartObjectPatternId(chartObject.Name, out var id)) continue;

                var updatedPatternName = $"{ObjectName}_{id}";

                var labelObjects = chartObjects.Where(iObject => iObject.Name.StartsWith(updatedPatternName,
                        StringComparison.OrdinalIgnoreCase) && iObject is ChartText)
                    .Select(iObject => iObject as ChartText).ToArray();

                if (chartObject is ChartText text)
                {
                    if (Config.Settings.PatternsLabelLinkStyle && ShowLabels)
                        UpdateLabelsStyle(labelObjects, text);

                    continue;
                }

                var patternObjects = chartObjects.Where(iObject => iObject.Name.StartsWith(updatedPatternName,
                        StringComparison.OrdinalIgnoreCase) && iObject.ObjectType != ChartObjectType.Text)
                    .ToArray();

                OnPatternChartObjectsUpdated(chart, id, chartObject, patternObjects);

                if (ShowLabels && !patternObjects.All(iObject => iObject.IsHidden))
                    UpdateLabels(chart, id, chartObject, labelObjects, patternObjects);
            }
        }

        protected virtual void UpdateLabelsStyle(ChartText[] labels, ChartText updatedLabel)
        {
            foreach (var label in labels)
            {
                label.Color = updatedLabel.Color;
                label.FontSize = updatedLabel.FontSize;
                label.IsBold = updatedLabel.IsBold;
                label.IsItalic = updatedLabel.IsItalic;
                label.IsLocked = updatedLabel.IsLocked;
                label.IsUnderlined = updatedLabel.IsUnderlined;
                label.HorizontalAlignment = updatedLabel.HorizontalAlignment;
                label.VerticalAlignment = updatedLabel.VerticalAlignment;
            }
        }

        private void ExecuteInTryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Config.Logger.Fatal(ex);

                throw;
            }
        }

        private void SubscribeToChartObjectsUpdatedEvent() => ActiveChart.ObjectsUpdated += OnChartObjectsUpdated;

        private void UnsubscribeFromChartObjectsUpdatedEvent()
        {
            if (_lastSubscribedActiveChart is null) return;
            
            _lastSubscribedActiveChart.ObjectsUpdated -= OnChartObjectsUpdated;
        }
    }
}