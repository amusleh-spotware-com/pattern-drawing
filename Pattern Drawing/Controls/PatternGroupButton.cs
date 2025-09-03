using System;
using System.Collections.Generic;
using cAlgo.API;
using cAlgo.Patterns;

namespace cAlgo.Controls
{
    public class PatternGroupButton : Button
    {
        private readonly ButtonsPanel _groupButtonsPanel;
        private readonly Panel _mainButtonsPanel;

        public PatternGroupButton(ButtonsPanel groupButtonsPanel, Panel mainButtonsPanel)
        {
            _mainButtonsPanel = mainButtonsPanel ?? throw new ArgumentNullException(nameof(mainButtonsPanel));
            _groupButtonsPanel = groupButtonsPanel ?? throw new ArgumentNullException(nameof(groupButtonsPanel));

            Click += OnClick;
        }

        public IEnumerable<IPattern> Patterns { get; set; }

        private void OnClick(ButtonClickEventArgs obj)
        {
            _groupButtonsPanel.RemoveAllButtons();

            if (Patterns == null) return;

            foreach (var pattern in Patterns)
            {
                var button = new PatternButton(pattern)
                {
                    Style = Style
                };

                _groupButtonsPanel.AddButton(button);
            }

            _groupButtonsPanel.IsVisible = true;
            _mainButtonsPanel.IsVisible = false;
        }
    }
}