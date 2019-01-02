using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var sol = new Day08.Day08( @"inputs.part01.test01.txt");
            Assert.AreEqual(1, sol.PartOne());
        }
    }
}