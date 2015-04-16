namespace ContentConsole
{
    public interface IDataStore
    {
        bool SetNegativeWords(string[] negativeWords);
        string[] GetNegativeWords();

        bool SetWordObfuscation(bool obfuscate);
        bool GetWordObfuscation();
    }
}