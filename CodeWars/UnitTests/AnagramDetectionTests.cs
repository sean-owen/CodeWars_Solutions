using KataSolutions.AnagramDetection;
using NUnit.Framework;
using System;


namespace UnitTests
{
    [TestFixture] // AnagramDetectionTests
    public class AnagramDetectionTests
    {
        [Test]
        [TestCase("foefet", "toffee", ExpectedResult = true)]
        [TestCase("Buckethead", "DeathCubeK", ExpectedResult = true)]
        [TestCase("Twoo", "Woot", ExpectedResult = true)]
        [TestCase("apple", "pale", ExpectedResult = false)]
        public static bool FixedTest(string test, string original)
        {
            return AnagramDetectionKata.IsAnagram(test, original);
        }
    }
}