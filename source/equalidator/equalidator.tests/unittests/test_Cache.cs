using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Cache
    {
        private Cache _sut;
        private object _hit;
        private object _miss;

        [SetUp]
        public void Initialize()
        {
            _sut = new Cache();
            _sut.CacheHit += _ => _hit = _;
            _sut.CacheMiss += _ => _miss = _;
            _hit = null;
            _miss = null;
        }


        [Test]
        public void Pass_on_value_type()
        {
            _sut.Process(1);

            Assert.AreEqual(0, _sut._cache.Count);
            Assert.AreEqual(1, _miss);
            Assert.IsNull(_hit);
        }


        [Test]
        public void Cache_missing_object_and_pass_on()
        {
            _sut.Process("a");

            Assert.IsTrue(_sut._cache.ContainsKey("a"));
            Assert.AreEqual(_miss, "a");
            Assert.IsNull(_hit);
        }


        [Test]
        public void Assign_id_to_cached_object()
        {
            _sut.Process("a");
            Assert.AreEqual(1, _sut._cache["a"]);
            _sut.Process("b");
            Assert.AreEqual(2, _sut._cache["b"]);
        }


        [Test]
        public void Cache_hit_results_in_ref_fragment()
        {
            _sut.Process("a");
            _miss = null;
            _sut.Process("a");
            
            Assert.IsTrue(new ObjectReferenceFragment(1).Equals(_hit));
            Assert.IsNull(_miss);
        }

    }
}