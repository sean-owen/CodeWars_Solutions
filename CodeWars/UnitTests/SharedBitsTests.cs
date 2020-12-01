using NUnit.Framework;
using System;
using KataSolutions.SharedBitCounter;

using static KataSolutions.SharedBitCounter.SharedBitCounterKata;

namespace UnitTests
{
    [TestFixture]
    class SharedBitsTests
    {
        [Test]
        public void SharedBits1()
        {
            //0 in common
            Assert.AreEqual(false, SharedBits(1, 2));
        }

        [Test]
        public void SharedBits2()
        {
            //0 in common
            Assert.AreEqual(false, SharedBits(16, 8));
        }
        [Test]
        public void SharedBits3()
        {
            //1 in common
            Assert.AreEqual(false, SharedBits(1, 1));
        }

        [Test]
        public void SharedBits4()
        {
            //1 in common
            Assert.AreEqual(false, SharedBits(2, 3));
        }

        [Test]
        public void SharedBits5()
        {
            //1 in common
            Assert.AreEqual(false, SharedBits(7, 10));
        }

        [Test]
        public void SharedBits6()
        {
            //2 in common
            Assert.AreEqual(true, SharedBits(43, 77));
        }

        [Test]
        public void SharedBits7()
        {
            //3 in common
            Assert.AreEqual(true, SharedBits(7, 15));
        }
        [Test]
        public void SharedBits8()
        {
            //3 in common
            Assert.AreEqual(true, SharedBits(23, 7));
        }

    }

}
