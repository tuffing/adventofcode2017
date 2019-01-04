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
            var sol = new Day11.Day11( @"inputs.part01.test01.txt");
            Assert.AreEqual(3, sol.PartOne());
        }
        
        [Test]
        public void Part1Test2()
        {
            var sol = new Day11.Day11( @"inputs.part01.test02.txt");
            Assert.AreEqual(0, sol.PartOne());
        }
        [Test]
        public void Part1Test3()
        {
            var sol = new Day11.Day11( @"inputs.part01.test03.txt");
            Assert.AreEqual(2, sol.PartOne());
        }
        
        [Test]
        public void Part1Test4()
        {
            var sol = new Day11.Day11( @"inputs.part01.test04.txt");
            Assert.AreEqual(3, sol.PartOne());
        }
    }
}