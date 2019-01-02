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
            var sol = new Day07.Day07( @"inputs.part01.test01.txt");
            Assert.AreEqual("tknk", sol.PartOne());
        }
        
        [Test]
        public void Test2()
        {
            var sol = new Day07.Day07( @"inputs.part01.test01.txt");
            Assert.AreEqual(60, sol.PartTwo());
        }
    }
}