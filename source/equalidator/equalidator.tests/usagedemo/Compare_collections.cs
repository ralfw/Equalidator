using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_collections
    {
        [Test]
        public void List()
        {
            Equalidator.AreEqual(new List<int> {1, 2, 3}, new List<int> {1, 2, 3});
        }


        [Test]
        public void Dictionary()
        {
            Equalidator.AreEqual(new Dictionary<string, int> { { "a", 1 }, { "b", 2 } }, new Dictionary<string, int> { { "a", 1 }, { "b", 2 } });
        }


        [Test]
        public void IEnumarable_vs_array()
        {
            var ieInt = new List<int> {1, 2} as IEnumerable<int>;
            Equalidator.AreEqual(new[] {1, 2}, ieInt.ToArray());
        }
    }
}