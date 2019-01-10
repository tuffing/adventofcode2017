using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part2Example1ReturnsCorrectNumber()
        {
            var sol = new Day21.Day21( @"inputs.part01.test01.txt");
            Assert.AreEqual(12, sol.PartOne(2));

        }
    }
}