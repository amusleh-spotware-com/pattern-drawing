using cAlgo.API;
using cAlgo.ChartObjectModels;
using Button = cAlgo.API.Button;
using MessageBox = cAlgo.API.MessageBox;
using OpenFileDialog = cAlgo.API.OpenFileDialog;

namespace cAlgo.Controls
{
    public class PatternsLoadButton : Button
    {
        private readonly ChartManager _chartManager;

        public PatternsLoadButton(ChartManager chartManager)
        {
            _chartManager = chartManager;

            Text = "Load";

            Click += OnClick;
        }

        private void OnClick(ButtonClickEventArgs obj)
        {
            if (_chartManager.ActiveFrame is not ChartFrame {Chart: var chart})
                return;

            var openFileDialog = new OpenFileDialog
            {
                Title = "Load Chart Patters",
                Filter = "pt Files (*.pt)|*.pt",
            };

            if (openFileDialog.ShowDialog() != FileDialogResult.OK) return;

            var fileName = openFileDialog.FileName;

            if (string.IsNullOrEmpty(fileName)) return;

            var models = ChartObjectsSerializer.Deserialize(fileName);

            if (models.Length == 0)
            {
                MessageBox.Show("There is no pattern object inside your selected file", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            chart.DrawModels(models);
        }
    }
}