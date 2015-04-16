using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var dataStore = new DataStore();
            // prime with default negative words and obfucation
            dataStore.SetNegativeWords(new[] { "swine", "bad", "nasty", "horrible" });
            dataStore.SetWordObfuscation(true);
            var phraseAnalyzer = new PhraseAnalyser(dataStore);
            var contentApp = new ContentApp(dataStore, phraseAnalyzer);

            Console.Write(contentApp.Run(args));
            Console.ReadLine();
        }
    }

}
