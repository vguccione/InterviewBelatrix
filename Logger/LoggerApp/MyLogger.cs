using LoggerApp.Logging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerApp
{
    public static class MyLogger
    {
        private static IList<ILogger> _loggers = new List<ILogger>();

        static MyLogger()
        {
            var registeredTypes = DependencyFactory.Container.Registrations;

            foreach (var registerType in registeredTypes)
            {
                if (registerType.RegisteredType.Name.Equals("ILogger"))
                {
                    ILogger logger = DependencyFactory.Resolve<ILogger>(registerType.Name);
                    _loggers.Add(logger);
                }
            }

        }

        public static void LogError(string message)
        {
            //Log in all registered destinations
            foreach (ILogger logger in _loggers)
            {
                logger.LogError(message);
            }
        }

        public static void LogWarning(string message)
        {
            //Log in all registered destinations
            foreach (ILogger logger in _loggers)
            {
                logger.LogWarning(message);
            }
        }

        public static void LogInfo(string message)
        {
            //Log in all registered destinations
            foreach (ILogger logger in _loggers)
            {
                logger.LogInfo(message);
            }
        }
    }
}
