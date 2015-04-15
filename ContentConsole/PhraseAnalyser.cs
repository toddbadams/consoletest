namespace ContentConsole
{
    public class PhraseAnalyser
    {
        private readonly IConsoleWriter _consoleWriter;

        public PhraseAnalyser(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Analyse(string content)
        {
            string bannedWord1 = "swine";
            string bannedWord2 = "bad";
            string bannedWord3 = "nasty";
            string bannedWord4 = "horrible";

            
            int badWords = 0;
            if (content.Contains(bannedWord1))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord2))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord3))
            {
                badWords = badWords + 1;
            }
            if (content.Contains(bannedWord4))
            {
                badWords = badWords + 1;
            }

            _consoleWriter.WriteLine("Scanned the text:");
            _consoleWriter.WriteLine(content);
            _consoleWriter.WriteLine("Total Number of negative words: " + badWords);

            _consoleWriter.WriteLine("Press ANY key to exit.");
            _consoleWriter.ReadKey();
        }
    }
}