using System;
using SOLIDexercise.Layouts;
using SOLIDexercise.ReportLevel;

namespace SOLIDexercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
           
        }
        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);
            Console.WriteLine(appendMessage);
        }
    }
}