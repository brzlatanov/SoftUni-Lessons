namespace SOLIDexercise.LogFile
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string message);
    }
}