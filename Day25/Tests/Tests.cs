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
            var sol = new Day25.Day25( @"inputs.part01.test01.txt");
            Assert.AreEqual(3, sol.PartOne());
        }
    }
}