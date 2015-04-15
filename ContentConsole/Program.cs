namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var consoleWriter = new ConsoleWriter();
            var phraseAnalyser = new PhraseAnalyser(consoleWriter);
            phraseAnalyser.Analyse("The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.");
            
        }
    }

}
