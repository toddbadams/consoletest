using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ContentConsole
{
    public class PhraseAnalyser : IPhraseAnalyser
    {
        private readonly IDataStore _dataStore;

        public PhraseAnalyser(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public string Analyse(string content)
        {
            var bannedWords = _dataStore.GetNegativeWords();
            var obfuscate = _dataStore.GetWordObfuscation();

            var badWords = 0;

            foreach (var bw in bannedWords)
            {
                var r = Replacement(bw);
                var rgx = new Regex(bw);
                badWords += rgx.Matches(content).Count;
                if (obfuscate)
                {
                    content = rgx.Replace(content, r);
                }
            }

            return "Scanned the text:" + Environment.NewLine
                         + content + Environment.NewLine
                         + "Total Number of negative words: " + badWords + Environment.NewLine
                         + "Press ANY key to exit.";
        }

        private static string Replacement(string word)
        {
            if (String.IsNullOrEmpty(word) || word.Length < 3) return word;
            var l = word.Length - 2;
            var replacement = word[0].ToString(CultureInfo.InvariantCulture);
            for (var i = 0; i < l; i++)
            {
                replacement += "#";
            }
            replacement += word[word.Length - 1];
            return replacement;

        }
    }
}