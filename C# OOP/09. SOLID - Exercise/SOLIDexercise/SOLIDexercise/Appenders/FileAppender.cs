using System.IO;
using SOLIDexercise.Layouts;
using SOLIDexercise.LogFile;
using SOLIDexercise.ReportLevel;

namespace SOLIDexercise.Appenders
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";
        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            LogFile = logFile;
        }
        public ILogFile LogFile { get; }
        public override void Append(string datetime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, datetime, reportLevel, message);

            LogFile.Write(appendMessage);

            File.AppendAllText(FilePath, appendMessage);
        }
    }
}