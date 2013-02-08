using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Flatten_IEnums_all_alike
    {
        [Test]
        public void Not_an_IEnum()
        {
            var sut = new Flatten_IEnumerables_all_alike();
            var passedOn = 0;
            sut.PassOn += _ => passedOn = (int)_;

            sut.Process(42);
            Assert.AreEqual(42, passedOn);

            sut.Configure("True");

            sut.Process(99);
            Assert.AreEqual(99, passedOn);
        }


        [Test]
        public void An_IEnum()
        {
            var sut = new Flatten_IEnumerables_all_alike();
            var passedOn = new int[0];
            sut.PassOn += _ => passedOn = (int[])_;

            sut.Process(new[]{42});
            Assert.AreEqual(new[]{42}, passedOn);

            passedOn = null;
            sut.MetaObject += delegate { };
            sut.Element += delegate { };
            sut.Configure("True");

            sut.Process(new[]{99});
            Assert.IsNull(passedOn);
        }


        [Test]
        public void MetaObjects_and_elements_for_IEnum()
        {
            var sut = new Flatten_IEnumerables_all_alike();
            sut.Configure("True");

            var fragments = new List<object>();
            sut.MetaObject += fragments.Add;
            sut.Element += fragments.Add;

            sut.Process(new[] { 42 });

            Assert.AreEqual(3, fragments.Count);
            Assert.IsInstanceOf<OpeningFragment>(fragments[0]);
            Assert.AreEqual(42, fragments[1]);
            Assert.IsInstanceOf<ClosingFragment>(fragments[2]);
        }
    }
}