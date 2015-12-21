using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerApp
{
    public class Program
    {
        
        public static void Main()
        {
            MyLogger.LogInfo("peprulo");
            MyLogger.LogError("error");
            MyLogger.LogWarning("error");

            Console.WriteLine("\n\ndone ");
            Console.ReadKey();
        }
    }
}
