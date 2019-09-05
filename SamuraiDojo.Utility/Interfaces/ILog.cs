using System;

namespace SamuraiDojo.Utility.Interfaces
{
    public interface ILog
    {
        void Error(string message);
        void Exception(Exception ex, string message = null);
        void Info(string message);
        void Warning(string message);
    }
}