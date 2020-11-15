using System;
using KataSolutions.BecomeImmortal;
using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
	class BecomeImmortalTests
    {
		[Test]
		public void example()
		{
            //Assert.AreEqual((long)5, BecomeImmortalKata.ElderAge(8, 5, 1, 100));
            //         Assert.AreEqual((long)224, BecomeImmortalKata.ElderAge(8, 8, 0, 100007));
            //         Assert.AreEqual((long)11925, BecomeImmortalKata.ElderAge(25, 31, 0, 100007));
            //         Assert.AreEqual((long)4323, BecomeImmortalKata.ElderAge(5, 45, 3, 1000007));
            //         Assert.AreEqual((long)1586, BecomeImmortalKata.ElderAge(31, 39, 7, 2345));
            //Assert.AreEqual((long)808451, BecomeImmortalKata.ElderAge(545, 435, 342, 1000007));
            // You need to run this test very quickly before attempting the actual tests :)
            Assert.AreEqual((long)5456283, BecomeImmortalKata.ElderAge(28827050410L, 35165045587L, 7109602, 13719506));
        }
	}
}
