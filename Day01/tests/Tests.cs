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
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part1/test01.txt");
            Assert.AreEqual(3, sol.PartOne());
        }
        
        [Test]
        public void Part1Example2ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part1/test02.txt");
            Assert.AreEqual(4, sol.PartOne());
        }
        
        [Test]
        public void Part1Example3ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part1/test03.txt");
            Assert.AreEqual(0, sol.PartOne());
        }
        
        [Test]
        public void Part1Example4ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part1/test04.txt");
            Assert.AreEqual(9, sol.PartOne());
        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part2/test01.txt");
            Assert.AreEqual(6, sol.PartTwo());
        }
        
        [Test]
        public void Part2Example2ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part2/test02.txt");
            Assert.AreEqual(0, sol.PartTwo());
        }
        
        [Test]
        public void Part2Example3ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part2/test03.txt");
            Assert.AreEqual(4, sol.PartTwo());
        }
        
        [Test]
        public void Part2Example4ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part2/test04.txt");
            Assert.AreEqual(12, sol.PartTwo());
        }  
        
        [Test]
        public void Part2Example5ReturnsCorrectNumber()
        {
            var sol = new Day01.Day01(@"/home/logan/projects/adventofcode2017/Day01/inputs/part2/test05.txt");
            Assert.AreEqual(4, sol.PartTwo());
        }
    }
}