using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using cAlgo.API;
using cAlgo.Plugins;

namespace cAlgo.Controls;

public class SettingsPanel : Grid
{
    private readonly Dictionary<string, List<SettingsProperty>> _groupedPropertySettings = new();
    private readonly StackPanel _mainPanel;
    private readonly Action _onSave;
    private readonly Settings _settings;

    public SettingsPanel(Settings settings, Action onSave)
    {
        _settings = settings;
        _onSave = onSave;
        _mainPanel = new StackPanel();

        Populate();

        AddRows(2);

        Rows[0].SetHeightInStars(1);
        Rows[1].SetHeightToAuto();

        AddChild(new ScrollViewer {Content = _mainPanel}, 0, 0);

        var saveButton = new Button
        {
            Text = "Save",
            FontSize = 14,
            FontWeight = FontWeight.Bold,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = 3
        };

        saveButton.Click += OnSave;

        AddChild(saveButton, 1, 0);
    }

    private void OnSave(ButtonClickEventArgs obj)
    {
        foreach (var settingsProperty in _groupedPropertySettings.Values.SelectMany(p => p))
        {
            object value;

            var property = settingsProperty.PropertyInfo;

            if (property.PropertyType == typeof(string) && property.Name.EndsWith("Color", StringComparison.Ordinal))
                value = (settingsProperty.Control as ColorPicker)?.SelectedColor?.ToHexString();
            else if (property.PropertyType == typeof(int))
                value = int.TryParse((settingsProperty.Control as TextBox)?.Text, out var intValue) ? intValue : 0;
            else if (property.PropertyType == typeof(double))
                value = double.TryParse((settingsProperty.Control as TextBox)?.Text, out var doubleValue)
                    ? doubleValue
                    : 0;
            else if (property.PropertyType.IsEnum)
                value = Enum.TryParse(property.PropertyType, (settingsProperty.Control as ComboBox)?.SelectedItem,
                    out var enumValue)
                    ? enumValue
                    : null;
            else if (property.PropertyType == typeof(bool))
                value = (settingsProperty.Control as CheckBox)?.IsChecked;
            else
                throw new InvalidOperationException($"Invalid property type {property.PropertyType}");

            property.SetValue(_settings, value);
        }

        _onSave();
    }

    private void Populate()
    {
        var groupedProperties = new Dictionary<string, List<PropertyInfo>>();

        foreach (var property in _settings.GetType().GetProperties())
        {
            if (property.GetCustomAttribute<ParameterAttribute>() is not { } parameterAttribute)
                continue;

            var group = parameterAttribute.Group ?? "Others";

            if (!groupedProperties.TryGetValue(group, out var properties))
            {
                properties = new List<PropertyInfo>();

                groupedProperties.Add(group, properties);
            }

            properties.Add(property);
        }

        foreach (var (group, properties) in groupedProperties)
            AddGroup(group, properties);
    }

    private void AddGroup(string group, IReadOnlyCollection<PropertyInfo> properties)
    {
        var groupPropertiesPanel = new Grid(properties.Count, 2) {Margin = 1};

        groupPropertiesPanel.Columns[0].SetWidthInStars(0.3);
        groupPropertiesPanel.Columns[1].SetWidthInStars(1);

        var propertySettings = new List<SettingsProperty>(properties.Count);

        var rowCounter = 0;

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<ParameterAttribute>() is not { } parameterAttribute)
                continue;

            ControlBase control;

            var textBlock = new TextBlock
            {
                Text = parameterAttribute.Name ?? property.Name, FontWeight = FontWeight.Bold, FontSize = 14, Margin = 3
            };

            groupPropertiesPanel.AddChild(textBlock, rowCounter, 0);

            if (property.PropertyType == typeof(string) && property.Name.EndsWith("Color", StringComparison.Ordinal))
            {
                control = new ColorPicker
                {
                    SelectedColor = (property.GetValue(_settings) ?? parameterAttribute.DefaultValue).ToString(),
                    Margin = 3,
                    IsStretched = true,
                };
            }
            else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(double))
            {
                control = new TextBox
                    {Text = (property.GetValue(_settings) ?? parameterAttribute.DefaultValue).ToString(), Margin = 3};
            }
            else if (property.PropertyType.IsEnum)
            {
                var enumValues = Enum.GetNames(property.PropertyType);

                var comboBox = new ComboBox {Margin = 3};

                foreach (var enumValue in enumValues) comboBox.AddItem(enumValue);

                comboBox.SelectedItem = (property.GetValue(_settings) ?? parameterAttribute.DefaultValue).ToString();

                control = comboBox;
            }
            else if (property.PropertyType == typeof(bool))
            {
                control = new CheckBox
                    {IsChecked = (bool) (property.GetValue(_settings) ?? parameterAttribute.DefaultValue), Margin = 3};
            }
            else
            {
                throw new InvalidOperationException($"Invalid property type {property.PropertyType}");
            }

            groupPropertiesPanel.AddChild(control, rowCounter, 1);

            propertySettings.Add(new SettingsProperty(property, control));
            rowCounter++;
        }

        _groupedPropertySettings.Add(group, propertySettings);

        var groupPropertiesPanelBorder = new Border {BorderThickness = 1, Child = groupPropertiesPanel};

        var groupPanel = new StackPanel {Orientation = Orientation.Vertical, Margin = 3};

        groupPanel.AddChild(new TextBlock
        {
            Text = group, HorizontalAlignment = HorizontalAlignment.Center, FontWeight = FontWeight.Bold, FontSize = 16
        });
        groupPanel.AddChild(groupPropertiesPanelBorder);

        _mainPanel.AddChild(groupPanel);
    }

    private record SettingsProperty(PropertyInfo PropertyInfo, ControlBase Control);
}