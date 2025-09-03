using cAlgo.API;
using cAlgo.ChartObjectModels;
using Button = cAlgo.API.Button;
using MessageBox = cAlgo.API.MessageBox;
using SaveFileDialog = cAlgo.API.SaveFileDialog;

namespace cAlgo.Controls
{
    public class PatternsSaveButton : Button
    {
        private readonly ChartManager _chartManager;

        public PatternsSaveButton(ChartManager chartManager)
        {
            _chartManager = chartManager;

            Text = "Save";

            Click += OnClick;
        }

        private void OnClick(ButtonClickEventArgs obj)
        {
            if (_chartManager.ActiveFrame is not ChartFrame {Chart: var chart})
                return;

            var chartObjectModels = chart.GetObjectModels();

            if (chartObjectModels.Length == 0)
            {
                MessageBox.Show("There is no pattern object on your chart to save", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save Chart Patters",
                Filter = "pt Files (*.pt)|*.pt",
            };

            if (saveFileDialog.ShowDialog() != FileDialogResult.OK) return;

            ChartObjectsSerializer.Serialize(chartObjectModels, saveFileDialog);
        }
    }
}