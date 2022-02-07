using System;
using System.Collections.Generic;

namespace ConsoleAppToGenerateLog
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static bool keepRunning = true;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            Console.WriteLine("Press ctrl-c to finish");

            while (Program.keepRunning)
            {
                Console.WriteLine("Write something to be written in log as an ERROR");
                string message = Console.ReadLine();
                message = message + " " + GetLucasKey();
                log.Error(message);
                Console.WriteLine("This message was written in log: " + message);
            }
            Console.WriteLine("exited gracefully");
        }

        static string GetLucasKey()
        {
            var list = new List<string> { "bunny_cdn", "scanner", "emailservice" };
            int index = new Random().Next(list.Count);
            return list[index];
        }
    }
}
