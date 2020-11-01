using KataSolutions.DuplicateEncoder;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class DuplicateEncoderTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("(((", DuplicateEncoderKata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", DuplicateEncoderKata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", DuplicateEncoderKata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", DuplicateEncoderKata.DuplicateEncode("(( @"));
        }
    }
}
