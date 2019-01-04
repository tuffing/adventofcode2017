using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part1Test1()
        {
            var sol = new Day12.Day12(@"inputs.part01.test01.txt");
            Assert.AreEqual(6, sol.PartOne());
        }
    }

}