using System;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{
    [TestFixture]
    public class PhraseAnalyserTest
    {
        private const string TestPhrase =
            "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
        private const string OfuscatedTestPhrase =
            "The weather in Manchester in winter is b#d. It rains all the time - it must be h######e for people visiting.";
        private PhraseAnalyser _phraseAnalyser;
        private DataStore _dataStore;

        [SetUp]
        public void SetUp()
        {
            _dataStore = new DataStore();
            _dataStore.SetNegativeWords(new[] {"swine", "bad", "nasty", "horrible"});
            _phraseAnalyser = new PhraseAnalyser(_dataStore);
        }

        [Test]
        public void Should_output_total_negative_words()
        {
            // arrange
            var expected = "Total Number of negative words: " + "2" + Environment.NewLine;

            // act
            var results = _phraseAnalyser.Analyse(TestPhrase);

            // assert
            Assert.IsTrue(results.Contains(expected));
        }

        [Test]
        public void Should_output_the_NonObfuscated_phrase_analysed()
        {
            // arrange

            // act
            var results = _phraseAnalyser.Analyse(TestPhrase);

            // assert
            Assert.IsTrue(results.Contains(TestPhrase));
        }

        [Test]
        public void Should_output_the_Obfuscated_phrase_analysed()
        {
            // arrange
            _dataStore.SetWordObfuscation(true);

            // act
            var results = _phraseAnalyser.Analyse(TestPhrase);

            // assert
            Assert.IsTrue(results.Contains(OfuscatedTestPhrase));
        }

        [Test]
        public void Should_Output_NonObfuscated_As_Expected()
        {
            // arrange

            // act
            var results = _phraseAnalyser.Analyse(TestPhrase);

            // assert
            Assert.AreEqual(ExpectedOutput(TestPhrase), results);
        }


        [Test]
        public void Should_Output_Obfuscated_As_Expected()
        {
            // arrange
            _dataStore.SetWordObfuscation(true);

            // act
            var results = _phraseAnalyser.Analyse(TestPhrase);

            // assert
            Assert.AreEqual(ExpectedOutput(OfuscatedTestPhrase), results);
        }

        private static string ExpectedOutput(string phrase)
        {
            var expected = "Scanned the text:" + Environment.NewLine
                           + phrase + Environment.NewLine
                           + "Total Number of negative words: " + "2" + Environment.NewLine
                           + "Press ANY key to exit.";
            return expected;
        }
    }
}
