namespace ContentConsole
{
    public class DataStore : IDataStore
    {
        private string[] _negativeWords;
        private bool _obfuscate;

        public bool SetNegativeWords(string[] negativeWords)
        {
            _negativeWords = negativeWords;
            return true;
        }

        public string[] GetNegativeWords()
        {
            return _negativeWords;
        }

        public bool SetWordObfuscation(bool obfuscate)
        {
           return  _obfuscate = obfuscate;
        }

        public bool GetWordObfuscation()
        {
            return _obfuscate;
        }
    }
}