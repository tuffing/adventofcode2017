using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        /*[Test]
        public void Test1()
        {
            var sol = new Day15.Day15( 65, 8921);
            Assert.AreEqual(588, sol.PartOne());
        }*/
        
        [Test]
        public void Test2()
        {
            var sol = new Day15.Day15( 65, 8921);
            Assert.AreEqual(309, sol.PartTwo());
        }
    }
}