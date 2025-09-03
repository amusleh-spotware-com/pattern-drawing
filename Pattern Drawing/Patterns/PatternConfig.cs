using System.Linq;
using cAlgo.API;
using cAlgo.Helpers;
using cAlgo.Plugins;

namespace cAlgo.Patterns
{
    public class PatternConfig
    {
        private readonly Application _application;

        public PatternConfig(ChartManager chartManager, Application application, Settings settings, ILogger logger)
        {
            _application = application;
            ChartManager = chartManager;
            Settings = settings;
            Logger = logger;
        }

        public ChartManager ChartManager { get; }
        
        public Chart[] Charts => ChartManager.OfType<ChartFrame>().Select(f => f.Chart).ToArray();

        public Settings Settings { get; }

        public Color Color => _application.DrawingColor;

        public ILogger Logger { get; private set; }
    }
}