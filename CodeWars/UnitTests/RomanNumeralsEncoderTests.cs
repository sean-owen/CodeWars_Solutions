using System;
using KataSolutions.RomanNumeralsEncoder;
using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
	public class RomanConvertTests
	{
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(2014, "MMXIV")]
        public void Test(int value, string expected)
		{
			Assert.AreEqual(expected, RomanNumeralsEncoderKata.Solution(value));
		}

        [TestCase()]
        public void DummyTest()
        {
            var x = RomanNumeralsEncoderKata.FindNumeralByAddition(2);
            Assert.AreEqual("CD", x);
        }
    }
}
