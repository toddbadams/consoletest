using System.Linq;
using NUnit.Framework;

namespace ContentConsole.Test.Unit
{

    [TestFixture]
    public class DataStoreTest
    {
        private IDataStore _dataStore;
        [SetUp]
        public void SetUp()
        {
            _dataStore = new DataStore();
        }

        [Test]
        public void Should_Retrieve_NegativeWords_From_DataStore()
        {
            // arrange
            var expected = new string[] { "swine", "bad", "nasty", "horrible" };
            _dataStore.SetNegativeWords(expected);

            // act
            var results = _dataStore.GetNegativeWords();

            // assert
            Assert.AreEqual(expected.Length, results.Length);
            foreach (var s in expected)
            {
                Assert.IsTrue(results.Any(x => x.Contains(s)));
            }

        }

        [Test]
        public void Should_Retrieve_Obfuscation_From_DataStore()
        {
            // arrange
            _dataStore.SetWordObfuscation(true);

            // act
            var results = _dataStore.GetWordObfuscation();

            // assert
            Assert.IsTrue(results);
        }

        [Test]
        public void Should_Default_To_False_Obfuscation_From_DataStore()
        {
            // arrange

            // act
            var results = _dataStore.GetWordObfuscation();

            // assert
            Assert.IsFalse(results);
        }
    }
}
