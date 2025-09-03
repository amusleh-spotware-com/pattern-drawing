using System;
using System.Collections.Generic;
using cAlgo.API;
using cAlgo.Controls;
using cAlgo.Helpers;
using cAlgo.Patterns;
using ToggleButton = cAlgo.Controls.ToggleButton;
using VerticalAlignment = cAlgo.API.VerticalAlignment;

namespace cAlgo.Plugins
{
    [Plugin(AccessRights = AccessRights.None)]
    public class PatternDrawing : Plugin
    {
        private const string CommandSvgIcon =
            "<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools --><svg height=\"800px\" width=\"800px\" version=\"1.1\" id=\"Layer_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" \t viewBox=\"0 0 512 512\" xml:space=\"preserve\"><polygon style=\"fill:#E65A5B;\" points=\"355.609,25.551 199.218,275.634 355.609,344.82 409.661,193.474 \"/><polygon style=\"fill:#FF6465;\" points=\"355.609,25.553 355.609,344.82 512,275.634 \"/><polygon style=\"fill:#A6E7FF;\" points=\"160.463,102.733 0,174.644 43.011,264.285 111.338,290.69 234.6,227.44 271.801,174.644 \"/><polygon style=\"fill:#6AB2CC;\" points=\"111.338,246.556 0,174.644 0,346.399 111.338,418.31 159.477,317.278 \"/><polygon style=\"fill:#7DD2F0;\" points=\"271.801,346.399 271.801,174.644 111.338,246.556 111.338,418.31 \"/><circle style=\"fill:#FFD782;\" cx=\"309.816\" cy=\"355.558\" r=\"130.891\"/><path style=\"opacity:0.1;enable-background:new    ;\" d=\"M202.552,379.187c0-72.292,58.604-130.896,130.896-130.896\tc30.123,0,57.863,10.181,79.982,27.281c-23.939-30.967-61.446-50.914-103.615-50.914c-72.292,0-130.896,58.604-130.896,130.896\tc0,42.169,19.946,79.676,50.914,103.615C212.733,437.049,202.552,409.309,202.552,379.187z\"/></svg>";

        private Style _buttonsStyle;
        private Settings _settings;
        private Window _settingsWindow;
        private PatternConfig _patternConfig;

        private TrianglePattern _trianglePattern;
        private CyclesPattern _cyclesPattern;
        private HeadAndShouldersPattern _headAndShouldersPattern;
        private CypherPattern _cypherPattern;
        private AbcdPattern _abcdPattern;
        private ThreeDrivesPattern _threeDrivesPattern;
        private MeasurePattern _measurePattern;
        private IPattern[] _gannPatterns;
        private IPattern[] _fibonacciPatterns;
        private IPattern[] _pitchforkPatterns;
        private IPattern[] _elliottCorrectionWavePatterns;
        private IPattern[] _elliottImpulseWavePatterns;
        private IPattern[] _elliottTriangleWavePatterns;
        private IPattern[] _elliottTripleComboWavePatterns;
        private IPattern[] _elliottDoubleComboWavePatterns;

        #region Overridden methods

        protected override void OnStart()
        {
            _settings = LocalStorage.GetObject<Settings>("Settings", LocalStorageScope.Type) ?? Settings.Default;

            _buttonsStyle = new Style();

            _buttonsStyle.Set(ControlProperty.Margin, 3);
            _buttonsStyle.Set(ControlProperty.HorizontalContentAlignment, HorizontalAlignment.Center);
            _buttonsStyle.Set(ControlProperty.VerticalContentAlignment, VerticalAlignment.Center);
            
            _patternConfig =
                new PatternConfig(ChartManager, Application, _settings, new Logger(Print));
            
            _trianglePattern = new TrianglePattern(_patternConfig);
            
            _trianglePattern.Initialize();

            _cyclesPattern = new CyclesPattern(_patternConfig);

            _cyclesPattern.Initialize();

            _headAndShouldersPattern = new HeadAndShouldersPattern(_patternConfig);
            
            _headAndShouldersPattern.Initialize();

            _cypherPattern = new CypherPattern(_patternConfig);

            _cypherPattern.Initialize();

            _abcdPattern = new AbcdPattern(_patternConfig);

            _abcdPattern.Initialize();

            _threeDrivesPattern = new ThreeDrivesPattern(_patternConfig);
            
            _threeDrivesPattern.Initialize();

            _measurePattern = new MeasurePattern(_patternConfig, new MeasureSettings(_settings));
            
            _measurePattern.Initialize();
            
            _gannPatterns = new IPattern[]
            {
                new GannBoxPattern(_patternConfig, new GannBoxSettings(_settings)),
                new GannSquarePattern(_patternConfig, new GannSquareSettings(_settings)),
                new GannFanPattern(_patternConfig, new GannFanPatternSettings(_settings))
            };
            
            InitializePatterns(_gannPatterns);

            _fibonacciPatterns = new IPattern[]
            {
                new FibonacciRetracementPattern(_patternConfig, new FibonacciRetracementSettings(_settings)),
                new FibonacciExpansionPattern(_patternConfig, new FibonacciExpansionPatternSettings(_settings)),
                new FibonacciSpeedResistanceFanPattern(_patternConfig,
                    new FibonacciSpeedResistanceFanSettings(_settings)),
                new FibonacciTimeZonePattern(_patternConfig, new FibonacciTimeZonePatternSettings(_settings)),
                new TrendBasedFibonacciTimePattern(_patternConfig,
                    new TrendBasedFibonacciTimePatternSettings(_settings)),
                new FibonacciChannelPattern(_patternConfig, new FibonacciChannelPatternSettings(_settings))
            };
            
            InitializePatterns(_fibonacciPatterns);

            _pitchforkPatterns = new IPattern[]
            {
                new OriginalPitchforkPattern(_patternConfig, new OriginalPitchforkPatternSettings(_settings)),
                new SchiffPitchforkPattern(_patternConfig, new SchiffPitchforkPatternSettings(_settings)),
                new ModifiedSchiffPitchforkPattern(_patternConfig,
                    new ModifiedSchiffPitchforkPatternSettings(_settings)),
                new PitchfanPattern(_patternConfig, new PitchfanPatternSettings(_settings))
            };
            
            InitializePatterns(_pitchforkPatterns);

            _elliottCorrectionWavePatterns = new IPattern[]
            {
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.SuperMellennium),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Mellennium),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.SubMellennium),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.GrandSuperCycle),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.SuperCycle),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Cycle),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Primary),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Intermediate),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Minor),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Minute),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Minuette),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.SubMinuette),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Micro),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.SubMicro),
                new ElliottCorrectionWavePattern(_patternConfig, ElliottWaveDegree.Minuscule)
            };

            InitializePatterns(_elliottCorrectionWavePatterns);

            _elliottImpulseWavePatterns = new IPattern[]
            {
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.SuperMellennium),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Mellennium),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.SubMellennium),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.GrandSuperCycle),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.SuperCycle),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Cycle),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Primary),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Intermediate),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Minor),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Minute),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Minuette),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.SubMinuette),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Micro),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.SubMicro),
                new ElliottImpulseWavePattern(_patternConfig, ElliottWaveDegree.Minuscule)
            };
            
            InitializePatterns(_elliottImpulseWavePatterns);

            _elliottTriangleWavePatterns = new IPattern[]
            {
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.SuperMellennium),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Mellennium),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.SubMellennium),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.GrandSuperCycle),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.SuperCycle),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Cycle),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Primary),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Intermediate),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Minor),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Minute),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Minuette),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.SubMinuette),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Micro),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.SubMicro),
                new ElliottTriangleWavePattern(_patternConfig, ElliottWaveDegree.Minuscule)
            };

            InitializePatterns(_elliottTriangleWavePatterns);

            _elliottTripleComboWavePatterns = new IPattern[]
            {
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.SuperMellennium),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Mellennium),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMellennium),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.GrandSuperCycle),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.SuperCycle),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Cycle),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Primary),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Intermediate),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Minor),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Minute),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Minuette),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMinuette),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Micro),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMicro),
                new ElliottTripleComboWavePattern(_patternConfig, ElliottWaveDegree.Minuscule)
            };

            InitializePatterns(_elliottTripleComboWavePatterns);

            _elliottDoubleComboWavePatterns = new IPattern[]
            {
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.SuperMellennium),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Mellennium),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMellennium),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.GrandSuperCycle),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.SuperCycle),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Cycle),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Primary),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Intermediate),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Minor),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Minute),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Minuette),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMinuette),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Micro),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.SubMicro),
                new ElliottDoubleComboWavePattern(_patternConfig, ElliottWaveDegree.Minuscule)
            };
            
            InitializePatterns(_elliottDoubleComboWavePatterns);
            
            Commands.Add(CommandType.ChartContainerToolbar, CommandHandler, new SvgIcon(CommandSvgIcon));
        }

        #endregion Overridden methods

        private ControlBase GetControlsPanel()
        {
            var mainPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
            };

            var mainButtonsPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = 5
            };

            var settingsButton = new Button {Text = "Settings", Style = _buttonsStyle};

            settingsButton.Click += _ => ShowSettingsWindow();

            mainButtonsPanel.AddChild(settingsButton);

            mainPanel.AddChild(mainButtonsPanel);

            var groupButtonsPanel = new ButtonsPanel
            {
                Orientation = Orientation.Vertical,
                Margin = 5,
                IsVisible = false
            };

            var backFromGroupButton = new Button {Text = "Back", Style = _buttonsStyle};

            backFromGroupButton.Click += _ =>
            {
                groupButtonsPanel.IsVisible = false;
                mainButtonsPanel.IsVisible = true;
            };

            groupButtonsPanel.AddChild(backFromGroupButton);

            mainPanel.AddChild(groupButtonsPanel);

            AddPatternButton(_trianglePattern, mainButtonsPanel);
            AddPatternButton(_cyclesPattern, mainButtonsPanel);
            AddPatternButton(_headAndShouldersPattern, mainButtonsPanel);
            AddPatternButton(_cypherPattern, mainButtonsPanel);
            AddPatternButton(_abcdPattern, mainButtonsPanel);
            AddPatternButton(_threeDrivesPattern, mainButtonsPanel);
            AddGannPatterns(mainButtonsPanel, groupButtonsPanel);
            AddFibonacciPatterns(mainButtonsPanel, groupButtonsPanel);
            AddPitchforkPatterns(mainButtonsPanel, groupButtonsPanel);
            AddElliottCorrectionWavePattern(mainButtonsPanel, groupButtonsPanel);
            AddElliottImpulseWavePattern(mainButtonsPanel, groupButtonsPanel);
            AddElliottTriangleWavePattern(mainButtonsPanel, groupButtonsPanel);
            AddElliottTripleComboWavePattern(mainButtonsPanel, groupButtonsPanel);
            AddElliottDoubleComboWavePattern(mainButtonsPanel, groupButtonsPanel);
            AddPatternButton(_measurePattern, mainButtonsPanel);

            var showHideButton = new ToggleButton
            {
                Style = _buttonsStyle,
                Text = "Hide",
                IsVisible = true
            };

            showHideButton.TurnedOn += OnShowHideButtonTurnedOn;
            showHideButton.TurnedOff += OnShowHideButtonTurnedOff;

            mainButtonsPanel.AddChild(showHideButton);

            var saveButton = new PatternsSaveButton(ChartManager)
            {
                Style = _buttonsStyle,
                IsVisible = true
            };

            mainButtonsPanel.AddChild(saveButton);

            var loadButton = new PatternsLoadButton(ChartManager)
            {
                Style = _buttonsStyle,
                IsVisible = true
            };

            mainButtonsPanel.AddChild(loadButton);

            var removeAllButton = new PatternsRemoveAllButton(ChartManager)
            {
                Style = _buttonsStyle,
                IsVisible = true
            };

            mainButtonsPanel.AddChild(removeAllButton);

            var scrollViewer = new ScrollViewer
            {
                Content = mainPanel,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
            };

            return scrollViewer;
        }

        private void ShowSettingsWindow()
        {
            _settingsWindow = new Window
            {
                Child = new SettingsPanel(_settings, OnSettingsSave), Height = 650, Width = 850,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            _settingsWindow.Show();
        }

        private void OnSettingsSave()
        {
            LocalStorage.SetObject("Settings", _settings, LocalStorageScope.Type);
            _settingsWindow?.Close();
        }

        private CommandResult CommandHandler(CommandArgs args) => new(GetControlsPanel());

        private void OnShowHideButtonTurnedOff(ToggleButton obj)
        {
            if (ChartManager.ActiveFrame is not ChartFrame {Chart: var chart})
                return;

            chart.ChangePatternsVisibility(false);

            obj.Text = "Hide";
        }

        private void OnShowHideButtonTurnedOn(ToggleButton obj)
        {
            if (ChartManager.ActiveFrame is not ChartFrame {Chart: var chart})
                return;

            chart.ChangePatternsVisibility(true);

            obj.Text = "Show";
        }

        private void AddPatternButton(IPattern pattern, Panel panel)
        {
            var button = new PatternButton(pattern)
            {
                Style = _buttonsStyle,
                IsVisible = true
            };

            panel.AddChild(button);
        }

        private PatternGroupButton AddPatternGroupButton(string text, Panel mainButtonsPanel,
            ButtonsPanel groupButtonsPanel)
        {
            var groupButton = new PatternGroupButton(groupButtonsPanel, mainButtonsPanel)
            {
                Text = text,
                Style = _buttonsStyle,
                IsVisible = true
            };

            mainButtonsPanel.AddChild(groupButton);

            return groupButton;
        }

        private void InitializePatterns(IEnumerable<IPattern> patterns)
        {
            foreach (var pattern in patterns) pattern.Initialize();
        }

        private void AddGannPatterns(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var gannPatternsGroupButton = AddPatternGroupButton("Gann", mainButtonsPanel, groupButtonsPanel);

            gannPatternsGroupButton.Patterns = _gannPatterns;
        }

        private void AddFibonacciPatterns(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var patternsGroupButton = AddPatternGroupButton("Fibonacci", mainButtonsPanel, groupButtonsPanel);

            patternsGroupButton.Patterns = _fibonacciPatterns;
        }

        private void AddPitchforkPatterns(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var patternsGroupButton = AddPatternGroupButton("Pitchfork", mainButtonsPanel, groupButtonsPanel);

            patternsGroupButton.Patterns = _pitchforkPatterns;
        }

        private void AddElliottImpulseWavePattern(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var elliottImpulseWavePatternGroupButton =
                AddPatternGroupButton("EW 12345", mainButtonsPanel, groupButtonsPanel);

            elliottImpulseWavePatternGroupButton.Patterns = _elliottImpulseWavePatterns;
        }

        private void AddElliottCorrectionWavePattern(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var elliottCorrectionWavePatternGroupButton =
                AddPatternGroupButton("EW ABC", mainButtonsPanel, groupButtonsPanel);

            elliottCorrectionWavePatternGroupButton.Patterns = _elliottCorrectionWavePatterns;
        }

        private void AddElliottTriangleWavePattern(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var elliottTriangleWavePatternGroupButton =
                AddPatternGroupButton("EW ABCDE", mainButtonsPanel, groupButtonsPanel);

            elliottTriangleWavePatternGroupButton.Patterns = _elliottTriangleWavePatterns;
        }

        private void AddElliottTripleComboWavePattern(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var elliottTripleComboWavePatternGroupButton =
                AddPatternGroupButton("EW WXYXZ", mainButtonsPanel, groupButtonsPanel);

            elliottTripleComboWavePatternGroupButton.Patterns = _elliottTripleComboWavePatterns;
        }

        private void AddElliottDoubleComboWavePattern(Panel mainButtonsPanel, ButtonsPanel groupButtonsPanel)
        {
            var elliottDoubleComboWavePatternGroupButton =
                AddPatternGroupButton("EW WXY", mainButtonsPanel, groupButtonsPanel);

            elliottDoubleComboWavePatternGroupButton.Patterns = _elliottDoubleComboWavePatterns;
        }
    }
}