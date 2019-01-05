using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part2Test1()
        {
            var sol = new Day14.Day14( "flqrgnkx");
            Assert.AreEqual(8108, sol.PartOne());
        }
        
        
        [Test]
        public void Part2Test2()
        {
            var sol = new Day14.Day14( "flqrgnkx");
            sol.PartOne();
            Assert.AreEqual(1242, sol.PartTwo());
        }
    }
}