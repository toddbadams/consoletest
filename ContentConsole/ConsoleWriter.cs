using System;

namespace ContentConsole
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}