using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Diagnostics;

namespace CleanArchitectureFullApplication.Loggers
{
    public class DebugStatusLogger : IApplicationStatusLogger
    {
        public void Log(string message)
        {
            Debug.WriteLine($"*** Application Log: {message}");
        }
    }
}
