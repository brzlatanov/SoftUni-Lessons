using SOLIDexercise.Layouts;
using SOLIDexercise.ReportLevel;

namespace SOLIDexercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }
        public abstract void Append(string datetime, LogLevel reportLevel, string message);
    }
}