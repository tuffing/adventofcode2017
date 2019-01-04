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
            var sol = new Day10.Day10( @"Inputs.Part01.test01.txt", 5);
            Assert.AreEqual(12, sol.PartOne());
        }
        
        [Test]
        public void Part2Test1()
        {
            var sol = new Day10.Day10( @"Inputs.Part02.test01.txt", 256);
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", sol.PartTwo());
        }
        
        [Test]
        public void Part2Test2()
        {
            var sol = new Day10.Day10( @"Inputs.Part02.test02.txt", 256);
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", sol.PartTwo());
        }
    }
}