using System;

namespace cAlgo.Patterns
{
    public interface IPattern
    {
        string Name { get; }

        bool IsDrawing { get; }
        event Action<IPattern> DrawingStarted;

        event Action<IPattern> DrawingStopped;

        void Initialize();

        void StartDrawing();

        void StopDrawing();
    }
}