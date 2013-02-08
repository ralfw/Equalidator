using System.Collections.Generic;
using System.Linq;
using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Collect
    {
        private IEnumerable<object> _fragments;
        private Collect _sut;


        [SetUp]
        public void Initialize()
        {
            _sut = new Collect();
            _sut.Result += _ => _fragments = _;
            _fragments = null;
        }


        [Test]
        public void Just_a_single_non_meta_fragment()
        {
            _sut.Process(42);

            Assert.AreEqual(new[] {42}, _fragments);
        }


        [Test]
        public void Fragments_in_brackets()
        {
            _sut.Process(new OpeningFragment("a"));
            Assert.IsNull(_fragments);

            _sut.Process(42);
            Assert.IsNull(_fragments);

            _sut.Process(new ClosingFragment());

            var f = _fragments.ToArray();
            Assert.AreEqual(3, f.Length);
            Assert.AreEqual(new OpeningFragment("a"), f[0]);
            Assert.AreEqual(42, f[1]);
            Assert.AreEqual(new ClosingFragment(), f[2]);

        }
    }
}