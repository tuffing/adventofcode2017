using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var sol = new Day17.Day17();
            Assert.AreEqual(638, sol.PartTwo(3, 2018));
        }
    }
}