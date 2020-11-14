using KataSolutions.ParseIntReloaded;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    class ParseIntReloadedTests
    {
        [Test]
        public void FixedTests()
        {
            Assert.AreEqual(1, ParseIntReloadedKata.ParseInt("one"));
            Assert.AreEqual(20, ParseIntReloadedKata.ParseInt("twenty"));
            Assert.AreEqual(246, ParseIntReloadedKata.ParseInt("two hundred forty-six"));
            Assert.AreEqual(1337, ParseIntReloadedKata.ParseInt("one thousand three hundred and thirty seven"));

        }
    }
}
