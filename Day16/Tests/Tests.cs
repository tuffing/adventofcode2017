using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var sol = new Day16.Day16( @"inputs.part01.test01.txt", "abcde".ToCharArray().ToList());
            Assert.AreEqual("baedc", sol.PartOne());
        }
    }
}