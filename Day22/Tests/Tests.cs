using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {   
        [Test]
        public void Part1Example1ReturnsCorrectNumber()
        {
            var sol = new Day22.Day22( @"inputs.part01.test01.txt");
            Assert.AreEqual(5, sol.PartOne(7));
        }
        
        [Test]
        public void Part1Example2ReturnsCorrectNumber()
        {
            var sol = new Day22.Day22( @"inputs.part01.test01.txt");
            Assert.AreEqual(41, sol.PartOne(70));
        }
        
        [Test]
        public void Part1Example3ReturnsCorrectNumber()
        {
            var sol = new Day22.Day22( @"inputs.part01.test01.txt");
            Assert.AreEqual(5587, sol.PartOne(10000));
        }
        
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day22.Day22( @"inputs.part01.test01.txt");
            Assert.AreEqual(26, sol.PartTwo(100));
        }
        
        [Test]
        public void Part2Example2ReturnsCorrectNumber()
        {
            var sol = new Day22.Day22( @"inputs.part01.test01.txt");
            Assert.AreEqual(2511944, sol.PartTwo(10000000));
        }
    }
}