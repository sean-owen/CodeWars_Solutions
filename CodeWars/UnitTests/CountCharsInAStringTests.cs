using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using KataSolutions;
using KataSolutions.CountCharsInAString;

namespace UnitTests
{
    [TestFixture]
    public class CountCharsInAStringTests
    {
        [Test]
        public static void FixedTest_aaaa()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 4);
            Assert.AreEqual(d, CountCharsInAStringKata.Count("aaaa"));
        }

        [Test]
        public static void FixedTest_aabb()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 2);
            d.Add('b', 2);
            Assert.AreEqual(d, CountCharsInAStringKata.Count("aabb"));
        }
    }
}
