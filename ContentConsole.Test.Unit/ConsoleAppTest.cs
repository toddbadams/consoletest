using System.Linq;
using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class ConsoleAppTest
    {
        private const string TestPhrase =
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        private Mock<IDataStore> _mockDatStore;
        private IDataStore _dataStore;
        private Mock<IPhraseAnalyser> _mockPhraseAnalyzer;
        private IPhraseAnalyser _phraseAnalyzer;
        private ContentApp _contentApp;
        private string[] _negativeWords;

        [SetUp]
        public void SetUp()
        {
            _mockDatStore = new Mock<IDataStore>();
            _dataStore = _mockDatStore.Object;
            _mockPhraseAnalyzer = new Mock<IPhraseAnalyser>();
            _phraseAnalyzer = _mockPhraseAnalyzer.Object;
            _contentApp = new ContentApp(_dataStore, _phraseAnalyzer);
            _negativeWords = new[] { "swine", "bad", "nasty" };
        }

        [Test]
        public void Should_SetNegativeWords()
        {
            // arrange
            var commandArguments = new[] { "-w=swine,bad,nasty" };
            _mockDatStore.Setup(d => d.GetNegativeWords()).Returns(_negativeWords);

            // act
            _contentApp.Run(commandArguments);

            // assert
            _mockDatStore.Verify(
                d => d.SetNegativeWords(It.Is<string[]>(r =>
                    _negativeWords.All(s => r.Any(x => x.Contains(s))))));
        }

        [Test]
        public void Should_Call_PhraseAnalyzer_With_TestPhrase()
        {
            // arrange
            var commandArguments = new[] { "-t=" + TestPhrase };
            _mockDatStore.Setup(d => d.GetNegativeWords()).Returns(_negativeWords);

            // act
            _contentApp.Run(commandArguments);

            // assert
            _mockPhraseAnalyzer.Verify(
                d => d.Analyse(It.Is<string>(r => r == TestPhrase)));
        }

        [Test]
        public void Should_Set_Obfuscation_True()
        {
            // arrange
            var commandArguments = new[] { "-o=true" };
            _mockDatStore.Setup(d => d.GetNegativeWords()).Returns(_negativeWords);

            // act
            _contentApp.Run(commandArguments);

            // assert
            _mockDatStore.Verify(d => d.SetWordObfuscation(It.Is<bool>(r => r)));
        }

        [Test]
        public void Should_Set_Obfuscation_False()
        {
            // arrange
            var commandArguments = new[] { "-o=false" };
            _mockDatStore.Setup(d => d.GetNegativeWords()).Returns(_negativeWords);

            // act
            _contentApp.Run(commandArguments);

            // assert
            _mockDatStore.Verify(d => d.SetWordObfuscation(It.Is<bool>(r => !r)));
        }
    }
}
