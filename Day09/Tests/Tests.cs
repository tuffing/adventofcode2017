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
            var sol = new Day09.Day09( @"inputs.part01.test1.txt");
            Assert.AreEqual(1, sol.PartOne());
        }
        
        [Test]
        public void Test2()
        {
            var sol = new Day09.Day09( @"inputs.part01.test2.txt");
            Assert.AreEqual(6, sol.PartOne());
        }
        
        [Test]
        public void Test3()
        {
            var sol = new Day09.Day09( @"inputs.part01.test3.txt");
            Assert.AreEqual(5, sol.PartOne());
        }
        
        [Test]
        public void Test4()
        {
            var sol = new Day09.Day09( @"inputs.part01.test4.txt");
            Assert.AreEqual(16, sol.PartOne());
        }
        
        [Test]
        public void Test5()
        {
            var sol = new Day09.Day09( @"inputs.part01.test5.txt");
            Assert.AreEqual(1, sol.PartOne());
        }
        
        [Test]
        public void Test6()
        {
            var sol = new Day09.Day09( @"inputs.part01.test6.txt");
            Assert.AreEqual(9, sol.PartOne());
        }
        
        [Test]
        public void Test7()
        {
            var sol = new Day09.Day09( @"inputs.part01.test7.txt");
            Assert.AreEqual(9, sol.PartOne());
        }
        
        [Test]
        public void Test8()
        {
            var sol = new Day09.Day09( @"inputs.part01.test8.txt");
            Assert.AreEqual(3, sol.PartOne());
        }
        
    }
}