using NUnit.Framework;
using System;
using KataSolutions.FakeBinary;

namespace UnitTests
{
    [TestFixture]
    public class FakeBinaryTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("01011110001100111", FakeBinaryKata.FakeBin("45385593107843568"));
            Assert.AreEqual("101000111101101", FakeBinaryKata.FakeBin("509321967506747"));
            Assert.AreEqual("011011110000101010000011011", FakeBinaryKata.FakeBin("366058562030849490134388085"));
        }
    }
}
