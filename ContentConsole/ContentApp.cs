using System;
using System.IO;
using NDesk.Options;

namespace ContentConsole
{
    public class ContentApp
    {
        private const char Separator = ',';
        private readonly IDataStore _dataStore;
        private readonly IPhraseAnalyser _phraseAnalyser;

        public ContentApp(IDataStore dataStore, IPhraseAnalyser phraseAnalyser)
        {
            _dataStore = dataStore;
            _phraseAnalyser = phraseAnalyser;
        }

        public string Run(string[] args)
        {
            string negativeWords = null;
            string text = null;
            var showHelp = false;
            var obfuscate = true;
            var p = new OptionSet()
            {
                {"w=", "A comma separated list of {negative words} (no spaces, default is swine,bad,nasty,horrible)", w => negativeWords = w},
                {"t=", "A {text phrase} to check for negative words (required)", t => text = t},
                {"o=", "true/false {obfuscation} to on returned phrase (default true)", o => obfuscate = bool.Parse(o)},
                {"h|help", "show this message and exit", v => showHelp = v != null},
            };
            p.Parse(args);

            if (showHelp)
            {
                var sw = new StringWriter();
                sw.Write("Determine the number of negative words in a text input." + Environment.NewLine
                         + "Options:" + Environment.NewLine);

                p.WriteOptionDescriptions(sw);
                return sw.ToString();
            }

            if (!String.IsNullOrEmpty(negativeWords))
            {
                _dataStore.SetNegativeWords(negativeWords.Split(Separator));
            }

            _dataStore.SetWordObfuscation(obfuscate);

            return String.IsNullOrEmpty(text) ? "Please enter a text phrase to analyze." : _phraseAnalyser.Analyse(text);
        }
    }
}
