namespace ContentConsole
{
    public interface IConsoleWriter
    {
        void WriteLine(string format, params object[] args);
        void ReadKey();
    }
}