using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using codaT.WordProcessorTest;

namespace codaT.WordProcessorTest.UnitTests
{
    [TestClass]
    public class DictionaryExt_Tests
    {
        const string __keyYellow = "Yellow";
        const string __keyGreen = "Green";

        [TestMethod]
        public void DictionaryExt_Test001_AddOneUnique()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.AddOrIncrement(__keyYellow);

            Assert.AreEqual<int>(1, dictionary[__keyYellow]);
        }

        [TestMethod]
        public void DictionaryExt_Test002_AddTwoUnique()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.AddOrIncrement(__keyYellow);
            dictionary.AddOrIncrement(__keyGreen);

            Assert.AreEqual<int>(1, dictionary[__keyYellow]);
            Assert.AreEqual<int>(1, dictionary[__keyGreen]);
        }

        [TestMethod]
        public void DictionaryExt_Test003_AddTwoDuplicate()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.AddOrIncrement(__keyYellow);
            dictionary.AddOrIncrement(__keyYellow);

            Assert.AreEqual<int>(2, dictionary[__keyYellow]);
        }

        [TestMethod]
        public void DictionaryExt_Test004_AddTwoDuplicateDifferenctCase()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            dictionary.AddOrIncrement(__keyYellow);
            dictionary.AddOrIncrement(__keyYellow.ToLower());

            Assert.AreEqual<int>(1, dictionary[__keyYellow]);
            Assert.AreEqual<int>(1, dictionary[__keyYellow.ToLower()]);
        }

        [TestMethod]
        public void DictionaryExt_Test005_AddTwoDuplicateDifferenctCase_CaseInsensitiveDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            dictionary.AddOrIncrement(__keyYellow);
            dictionary.AddOrIncrement(__keyYellow.ToLower());

            Assert.AreEqual<int>(2, dictionary[__keyYellow]);
        }


    }
}
