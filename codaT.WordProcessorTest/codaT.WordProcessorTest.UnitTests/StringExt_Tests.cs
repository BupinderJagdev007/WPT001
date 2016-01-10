using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest.UnitTests
{
    [TestClass]
    public class StringExt_Tests
    {
        const string __value1SimplePre =    "Hello, World.";
        const string __value1SimplePost =   "Hello  World ";

        const string __value1ComplexPre =   "Hello, World. @ How are you today! ;->";
        const string __value1ComplexPost =  "Hello  World    How are you today     ";

        [TestMethod]
        public void StringExt_Test001_SimplePunctuationReplacement()
        {
            string res = __value1SimplePre.RemovePunctuation();

            Assert.AreEqual(__value1SimplePost, res, "Simple removal of puctuation failing");

        }

        [TestMethod]
        public void StringExt_Test002_ComplexPunctuationReplacement()
        {
            string res = __value1ComplexPre.RemovePunctuation(StringExt.COMPLEX_ALL);

            Assert.AreEqual(__value1ComplexPost, res, "Complex removal of puctuation failing");
        }

        [TestMethod]
        public void StringExt_Test003_SimplePunctuationReplacementWithCOmplexText_Fail()
        {
            string res = __value1ComplexPre.RemovePunctuation();

            Assert.AreNotEqual(__value1ComplexPost, res, "Simple case should not be able to process additional punctuation");

        }




    }
}
