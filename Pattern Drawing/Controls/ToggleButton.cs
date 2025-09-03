using System;
using cAlgo.API;

namespace cAlgo.Controls
{
    public class ToggleButton : Button
    {
        private readonly Color _offColor;
        private readonly Color _onColor;

        public ToggleButton()
        {
            Click += _ =>
            {
                if (IsOn)
                    TurnOff();
                else
                    TurnOn();
            };

            _onColor = Color.FromHex("#3B3B3B");
            _offColor = Color.FromHex("#6B6B6B");
        }

        public bool IsOn { get; private set; }

        public event Action<ToggleButton> TurnedOn;

        public event Action<ToggleButton> TurnedOff;

        public void TurnOn()
        {
            IsOn = true;

            BackgroundColor = _onColor;

            var turnedOnEvent = TurnedOn;

            turnedOnEvent?.Invoke(this);

            OnTurnedOn();
        }

        public void TurnOff()
        {
            IsOn = false;

            BackgroundColor = _offColor;

            var turnedOffEvent = TurnedOff;

            turnedOffEvent?.Invoke(this);

            OnTurnedOff();
        }

        protected virtual void OnTurnedOn()
        {
        }

        protected virtual void OnTurnedOff()
        {
        }
    }
}