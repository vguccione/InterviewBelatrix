using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LoggerApp.Logging
{
    public abstract class Logger
    {
        public bool WarningEnabled { get; private set; }
        public bool ErrorEnabled { get; private set;}
        public bool InfoEnabled { get; private set; }

        public Logger()
        {
            WarningEnabled = Boolean.Parse(ConfigurationManager.AppSettings["WarningEnbled"]);
            ErrorEnabled = Boolean.Parse(ConfigurationManager.AppSettings["ErrorEnabled"]);
            InfoEnabled = Boolean.Parse(ConfigurationManager.AppSettings["InfoEnabled"]);
        }
    }
}
