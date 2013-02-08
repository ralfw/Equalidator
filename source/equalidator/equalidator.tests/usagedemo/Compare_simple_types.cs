using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_simple_types
    {
        [Test]
        public void Date_and_time()
        {
            Equalidator.AreEqual(new DateTime(2011, 4, 27), new DateTime(2011, 4, 27));
            Equalidator.AreEqual(new TimeSpan(1, 10, 50), new TimeSpan(1, 10, 50));
        }

        [Test]
        public void Internet_address()
        {
            Equalidator.AreEqual(new Uri("http://www.test.com"), new Uri("http://www.test.com"));
        }
    }
}