using Moq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    /// <summary>
    /// As a user 
    /// I want see the number of negative words in a text input 
    /// So that we can track the amount of negative content
    /// </summary>
    [TestFixture]
    public class PhraseAnalyserTest
    {
        private const string testPhrase =
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

        private IConsoleWriter _consoleWriter;
        private Mock<IConsoleWriter> _mockConsoleWriter;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleWriter = new Mock<IConsoleWriter>();
            _consoleWriter = _mockConsoleWriter.Object;
        }

        [Test]
        public void Should_output_total_negative_words()
        {
            // arrange
            var phraseAnalyser = new PhraseAnalyser(_consoleWriter);

            // act
            phraseAnalyser.Analyse(testPhrase);

            // assert
            _mockConsoleWriter.Verify(m => m.WriteLine(It.IsAny<string>()));

        }

        //[Test]
        //public void Should_output_the_phrase_analysed()
        //{

        //}

        
    }
}
