using System;
using System.Collections.Generic;
using System.Diagnostics;
using equalidator.exceptions;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_different_types_of_collections
    {
        [Test]
        public void Compare_array_and_list()
        {
            var a = new[] {42, 99};
            var l = new List<int>() {42, 99};

            Assert.Throws<NotEqualDueToDifferentStructures>(() => Equalidator.AreEqual(a, l));

            a.ShouldEqual(l, true);
        }


        [Test]
        public void Compare_differing_hierarchies()
        {
            var p1 = new Parent { Elements = new[] { 42, 99 } };
            var p2 = new Parent { Elements = new List<int>() {42, 99} };

            p1.ShouldEqual(p2, true);
        }


        [Test]
        public void Compare_iterators()
        {
            var i1 = Iterate(2);
            var i2 = Iterate(2);

            i1.ShouldEqual(i2);
        }


        [Test]
        public void Compare_iterator_to_array()
        {
            var i1 = Iterate(2);
            var i2 = new[] {2, 1};

            i1.ShouldEqual(i2, true);
        }


        private static IEnumerable<int> Iterate(int n)
        {
            while (n > 0) yield return n--;
        }
    }


    public class Parent
    {
        public IEnumerable<int> Elements;
    }
}