using KataSolutions.WhereMyAnagramsAt;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    class WmaaTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new List<string> { "a" }, WmaaKata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
            Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, WmaaKata.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));           
        }

    }
}
