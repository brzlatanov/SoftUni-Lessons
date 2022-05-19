using System;
using SOLIDexercise.Appenders;
using SOLIDexercise.Layouts;
using SOLIDexercise.Logger;
using SOLIDexercise.LogFile;
namespace SOLIDexercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var file = new LogFile.LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);

            var logger = new Logger.Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
