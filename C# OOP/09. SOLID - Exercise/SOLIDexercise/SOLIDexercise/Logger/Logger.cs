using System.Collections.Generic;
using SOLIDexercise.Appenders;
using SOLIDexercise.ReportLevel;

namespace SOLIDexercise.Logger
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = new List<IAppender>();
            this.Appenders.AddRange(appenders);
        }
        public List<IAppender> Appenders { get; }
        public IAppender Appender { get; }
        public void Info(string dateTime, string message)
        {
            Log(dateTime, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Fatal, message);
        }

        private void Log(string dateTime, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, LogLevel.Info, message);
            }
        }
    }
}