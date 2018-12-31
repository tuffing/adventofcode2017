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
            var sol = new Day05.Day05( @"inputs.part01.test01.txt");
            Assert.AreEqual(5, sol.PartOne());
        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day05.Day05( @"inputs.part01.test01.txt");
            Assert.AreEqual(10, sol.PartTwo());
        }
    }
}