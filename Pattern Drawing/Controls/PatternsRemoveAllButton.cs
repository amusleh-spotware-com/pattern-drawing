using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;
using Button = cAlgo.API.Button;
using MessageBox = cAlgo.API.MessageBox;

namespace cAlgo.Controls
{
    public class PatternsRemoveAllButton : Button
    {
        private readonly ChartManager _chartManager;

        public PatternsRemoveAllButton(ChartManager chartManager)
        {
            _chartManager = chartManager;

            Text = "Remove All";

            Click += OnClick;
        }

        private void OnClick(ButtonClickEventArgs obj)
        {
            if (_chartManager.ActiveFrame is not ChartFrame {Chart: var chart})
                return;

            var dialogResult = MessageBox.Show("Are you sure you want to remove all patterns from this chart?",
                "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (dialogResult != MessageBoxResult.OK) return;

            var chartObjects = chart.Objects.ToArray();

            foreach (var chartObject in chartObjects)
            {
                if (!chartObject.IsPattern() || chartObject.IsHidden) continue;

                chart.RemoveObject(chartObject.Name);
            }
        }
    }
}