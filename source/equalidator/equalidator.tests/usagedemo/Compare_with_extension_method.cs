using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_with_extension_method
    {
        [Test]
        public void Use_ShouldEqual()
        {
            1.ShouldEqual(1);
        }
    }
}