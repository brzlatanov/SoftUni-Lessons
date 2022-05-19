using SOLIDexercise.Layouts;
using SOLIDexercise.ReportLevel;

namespace SOLIDexercise.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        void Append(string datetime, LogLevel reportLevel, string message);
    }
}