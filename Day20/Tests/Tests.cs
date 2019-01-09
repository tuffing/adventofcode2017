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
            var sol = new Day20.Day20( @"inputs.part01.test01.txt");
            Assert.AreEqual(0, sol.PartOne());

        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day20.Day20( @"inputs.part02.test02.txt");
            Assert.AreEqual(1, sol.PartTwo());

        }
    }
}