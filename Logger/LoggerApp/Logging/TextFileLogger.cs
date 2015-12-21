using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerApp.Logging
{
    public class TextFileLogger : Logger, ILogger
    {
        private string _logFile;

        public TextFileLogger() : base()
        {
            _logFile = ConfigurationManager.AppSettings["LoggerTextFile"];
        }

        public void LogError(string message)
        {
            if (!this.ErrorEnabled)
                return;

            string msg = EventType.Error.ToString() + " - " + DateTime.Now.ToString() + " - " + message;
            List<string> contents = new List<string>();
            contents.Add(msg);
            File.AppendAllLines(GetFileName(), contents);
        }

        public void LogInfo(string message)
        {
            if (!this.InfoEnabled)
                return;

            string msg = EventType.Info.ToString() + " - " + DateTime.Now.ToString() + " - " + message;
            List<string> contents = new List<string>();
            contents.Add(msg);
            File.AppendAllLines(GetFileName(), contents);
        }

        public void LogWarning(string message)
        {
            if (!this.WarningEnabled)
                return;

            string msg = EventType.Warning.ToString() + " - " + DateTime.Now.ToString() + " - " + message;
            List<string> contents = new List<string>();
            contents.Add(msg);
            File.AppendAllLines(GetFileName(), contents);
        }
        
        private string GetFileName()
        {
            string name = _logFile + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
            return name;
        }
    }
}
