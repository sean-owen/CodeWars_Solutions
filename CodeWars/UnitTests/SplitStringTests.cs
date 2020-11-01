using System;
using System.Collections.Generic;
using System.Text;
using KataSolutions.SplitStrings;
using NUnit.Framework;

namespace UnitTests
{    
    [TestFixture]
    public class SplitStringTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new string[] { "ab", "c_" }, SplitStringsKata.Solution("abc"));
            Assert.AreEqual(new string[] { "ab", "cd", "ef" }, SplitStringsKata.Solution("abcdef"));
        }
    }
}
