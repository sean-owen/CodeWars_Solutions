using KataSolutions.OnesAndZeros;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class OnesAndZerosTests
    {
        int[] Test1 = new int[] { 0, 0, 0, 0 };
        int[] Test2 = new int[] { 1, 1, 1, 1 };
        int[] Test3 = new int[] { 0, 1, 1, 0 };
        int[] Test4 = new int[] { 0, 1, 0, 1 };
        [Test]
        public void BasicTesting()
        {
            Assert.AreEqual(0, OnesAndZerosKata.binaryArrayToNumber(Test1));
            Assert.AreEqual(15, OnesAndZerosKata.binaryArrayToNumber(Test2));
            Assert.AreEqual(6, OnesAndZerosKata.binaryArrayToNumber(Test3));
            Assert.AreEqual(5, OnesAndZerosKata.binaryArrayToNumber(Test4));
        }
    }
}
