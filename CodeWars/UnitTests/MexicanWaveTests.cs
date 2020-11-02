using System;
using System.Collections.Generic;
using KataSolutions.MexicanWave;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class MexicanWaveKataClass
    {
        [TestCase]
        public void BasicTest1()
        {
            MexicanWaveKata kata = new MexicanWaveKata();
            List<string> result = new List<string> { "Hello", "hEllo", "heLlo", "helLo", "hellO" };
            Assert.AreEqual(result, kata.Wave("hello"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest2()
        {
            MexicanWaveKata kata = new MexicanWaveKata();
            List<string> result = new List<string> { "Codewars", "cOdewars", "coDewars", "codEwars", "codeWars", "codewArs", "codewaRs", "codewarS" };
            Assert.AreEqual(result, kata.Wave("codewars"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest3()
        {
            MexicanWaveKata kata = new MexicanWaveKata();
            List<string> result = new List<string> { };
            Assert.AreEqual(result, kata.Wave(""), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest4()
        {
            MexicanWaveKata kata = new MexicanWaveKata();
            List<string> result = new List<string> { "Two words", "tWo words", "twO words", "two Words", "two wOrds", "two woRds", "two worDs", "two wordS" };
            Assert.AreEqual(result, kata.Wave("two words"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest5()
        {
            MexicanWaveKata kata = new MexicanWaveKata();
            List<string> result = new List<string> { " Gap ", " gAp ", " gaP " };
            Assert.AreEqual(result, kata.Wave(" gap "), "it should return '" + result + "'");
        }

    }
}
