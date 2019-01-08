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
            var sol = new Day19App.Day19( @"inputs.part01.test01.txt", 5, 0);
            Assert.AreEqual("ABCDEF", sol.PartOne(out var count));
            Assert.AreEqual(38, count);

        }
    }
}