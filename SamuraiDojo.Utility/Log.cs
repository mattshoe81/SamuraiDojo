using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public class Log
    {
        public const string CATEGORY = "SAMURAI_DOJO";
        
        public static void Info(string message)
        {
            Write($"INFO: {message}");
        }

        public static void Warning(string message)
        {
            Write($"WARNING: {message}");
        }

        public static void Error(string message)
        {
            Write($"ERROR: {message}");
        }

        public static void Exception(Exception ex, string message = null)
        {
            if (message != null)
                Write($"EXCEPTION: {message}{Environment.NewLine}{ex.ToString()}");
            else
                Write($"EXCEPTION: {Environment.NewLine}{ex.ToString()}");
        }

        private static void Write(string message, object obj = null)
        {
            if (obj != null)
                message = obj.ToString();

            Trace.WriteLine($"{Environment.NewLine}\t{message}{Environment.NewLine}", CATEGORY);
        }
    }
}
