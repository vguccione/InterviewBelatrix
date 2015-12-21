using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerApp.Logging
{
    public class ConsoleLogger : Logger, ILogger
    {
        public ConsoleLogger() : base()
        {

        }

        public  void LogError(string message)
        {
            if (!this.ErrorEnabled)
                return;

            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(EventType.Error.ToString() + " - " + DateTime.Now.ToShortDateString() + message); 
        }

        public  void LogInfo(string message)
        {
            if (!this.InfoEnabled)
                return;

            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine(EventType.Info.ToString() + " - " + DateTime.Now.ToShortDateString() + message); 
        }

        public  void LogWarning(string message)
        {
            if (!this.WarningEnabled)
                return;

            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine(EventType.Warning.ToString() + " - " + DateTime.Now.ToShortDateString() + message); 
        }
    }
}
