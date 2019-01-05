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
            var sol = new Day13.Day13(@"inputs.part01.test01.txt");
            Assert.AreEqual(24, sol.PartOne());
        }
        
        
        [Test]
        public void Part2Test1()
        {
            var sol = new Day13.Day13(@"inputs.part01.test01.txt");
            Assert.AreEqual(10, sol.PartTwo());
        }
    }
}