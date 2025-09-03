using System.Collections.Generic;
using cAlgo.API;

namespace cAlgo.Controls;

public class ButtonsPanel : StackPanel
{
    private readonly List<ControlBase> _buttons = new();

    public ButtonsPanel()
    {
        Orientation = Orientation.Vertical;
    }

    public void AddButton(Button button)
    {
        _buttons.Add(button);
        AddChild(button);
    }

    public void RemoveAllButtons()
    {
        foreach (var button in _buttons) RemoveChild(button);

        _buttons.Clear();
    }
}