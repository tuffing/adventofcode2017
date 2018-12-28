using System;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part1Example1ReturnsCorrectNumber()
        {
            var sol = new Day02.Day02(@"/home/logan/projects/adventofcode2017/Day02/inputs/part1/test01.txt");
            Assert.AreEqual(18, sol.PartOne());
        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day02.Day02(@"/home/logan/projects/adventofcode2017/Day02/inputs/part2/test01.txt");
            Assert.AreEqual(9, sol.PartTwo());
        }
    }
}