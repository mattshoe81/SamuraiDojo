using System;

namespace SamuraiDojo.IoC.Interfaces
{
    public interface ILog
    {
        void Error(string message);
        void Exception(Exception ex, string message = null);
        void Info(string message);
        void Warning(string message);
    }
}