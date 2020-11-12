using KataSolutions.SumStringsAsNumbers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class SumStringsAsIntsTests
    {
        [Test]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("579", SumStringsAsIntsKata.sumStrings("123", "456"));
        }
    }
}
