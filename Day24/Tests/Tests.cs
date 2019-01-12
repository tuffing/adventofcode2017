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
            var sol = new Day24.Day24( @"inputs.part01.test01.txt");
            Assert.AreEqual(31, sol.PartOne(out var longestStrength));
            Assert.AreEqual(19, longestStrength);
        }
    }
}