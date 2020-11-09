using System;
using NUnit.Framework;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using KataSolutions.BestTravel;

namespace UnitTests
{
    [TestFixture]
    public class BestTravelTest
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            List<int> ts = new List<int> { 50, 55, 56, 57, 58 };
            int? n = BestTravelKata.ChooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            ts = new List<int> { 50 };
            n = BestTravelKata.ChooseBestSum(163, 3, ts);
            Assert.AreEqual(null, n);

            ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            n = BestTravelKata.ChooseBestSum(230, 3, ts);
            Assert.AreEqual(228, n);
        }
    }
}
