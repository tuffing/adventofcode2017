using System;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var sol = new Day03.Day03(12);
            Assert.AreEqual(3,sol.PartOne());
        }
        
        
        [Test]
        public void Test2()
        {
            var sol = new Day03.Day03(23);
            Assert.AreEqual(2,sol.PartOne());
        }
        
        [Test]
        public void Test3()
        {
            var sol = new Day03.Day03(1024);
            Assert.AreEqual(31,sol.PartOne());
        }
        
        
        [Test]
        public void Test4()
        {
            var sol = new Day03.Day03(58);
            Assert.AreEqual(59,sol.PartTwo());
        }
        
        
        [Test]
        public void Test5()
        {
            var sol = new Day03.Day03(805);
            Assert.AreEqual(806,sol.PartTwo());
        }
    }
}