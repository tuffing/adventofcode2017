using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part1Example1ReturnsCorrectNumber()
        {
            var sol = new Day18.Day18( @"inputs.part01.test01.txt");
            Assert.AreEqual(4, sol.PartOne());
        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day18.Day18( @"inputs.part02.test01.txt");
            Assert.AreEqual(3, sol.PartTwo());
        }
    }
}