using System;
using System.Diagnostics;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Utility
{
    public class Log : ILog
    {
        public const string CATEGORY = "SAMURAI_DOJO";

        public void Info(string message)
        {
            Write($"INFO: {message}");
        }

        public void Warning(string message)
        {
            Write($"WARNING: {message}");
        }

        public void Error(string message)
        {
            Write($"ERROR: {message}");
        }

        public void Exception(Exception ex, string message = null)
        {
            if (message != null)
                Write($"EXCEPTION: {message}{Environment.NewLine}{ex.ToString()}");
            else
                Write($"EXCEPTION: {Environment.NewLine}{ex.ToString()}");
        }

        private void Write(string message, object obj = null)
        {
            if (obj != null)
                message = obj.ToString();

            Trace.WriteLine($"{Environment.NewLine}\t{message}{Environment.NewLine}", CATEGORY);
        }
    }
}
