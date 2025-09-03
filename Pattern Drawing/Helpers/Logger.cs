using System;
using System.Text;

namespace cAlgo.Helpers
{
    public interface ILogger
    {
        void Fatal(Exception exception);

        void Log(string text);

        void Print(string text);

        void Print(string format, params object[] args);
    }

    public sealed class Logger : ILogger
    {
        private readonly Action<string> _print;

        public Logger(Action<string> print)
        {
            _print = print ?? throw new ArgumentException(null, nameof(print));
        }

        public void Fatal(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Local Time: {0:o} | UTC Time: {1:o}", DateTime.Now, DateTime.UtcNow);

            stringBuilder.AppendLine(exception.GetLog());

            Log(stringBuilder.ToString());
        }

        public void Log(string text)
        {
            Print(text);
        }

        public void Print(string text)
        {
            _print(text);
        }

        public void Print(string format, params object[] args)
        {
            Print(string.Format(format, args));
        }
    }
}