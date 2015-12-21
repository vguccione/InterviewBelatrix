using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoggerApp.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.IO;

namespace TestLogger
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void TestDBLogger()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, DBLogger>();
            
            ILogger logger = container.Resolve<ILogger>();
            Assert.IsNotNull(logger);
            Assert.IsNotNull(logger as Logger);
            Assert.IsNotNull(logger as DBLogger);

            logger.LogWarning("Warning message test");
        }

        [TestMethod]
        public void TestTextFileLogger()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, TextFileLogger>();

            ILogger logger = container.Resolve<ILogger>();
            Assert.IsNotNull(logger);
            Assert.IsNotNull(logger as Logger);
            Assert.IsNotNull(logger as TextFileLogger);

            logger.LogWarning("Warning message test");

            string path = ConfigurationManager.AppSettings["LoggerTextFile"];
            string[] lines = File.ReadAllLines(path + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt");
            Assert.IsTrue(lines[lines.Length - 1].Contains("Warning message test"));


        }

        [TestMethod]
        public void TestConsoleLogger()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ILogger, ConsoleLogger>();

            ILogger logger = container.Resolve<ILogger>();
            Assert.IsNotNull(logger);
            Assert.IsNotNull(logger as Logger);
            Assert.IsNotNull(logger as ConsoleLogger);

            logger.LogWarning("Warning message test");
        }

    }
}
