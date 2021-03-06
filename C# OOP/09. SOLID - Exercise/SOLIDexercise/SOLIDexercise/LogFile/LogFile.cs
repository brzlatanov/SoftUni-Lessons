using System.Linq;
using System.Text;

namespace SOLIDexercise.LogFile
{
    public class LogFile : ILogFile
    {
        private StringBuilder stringBuilder;

        public LogFile()
        {
            this.stringBuilder = new StringBuilder();
        }
        public int Size => stringBuilder.ToString().Where(c=> char.IsLetter(c)).Sum(c => c);
        public void Write(string message) => stringBuilder.Append(message);
    }
}