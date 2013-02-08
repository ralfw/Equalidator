using System.Collections.Generic;
using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.integration
{
    [TestFixture]
    public class test_Flatten
    {
        private Flatten _sut;
        private List<object> _fragments;

        [SetUp]
        public void Initialize()
        {
            _sut = new Flatten();
            _sut.Result += _ => _fragments = new List<object>(_);

            _fragments = new List<object>();
        }


        [Test]
        public void Scalar()
        {
            _sut.Process(42);

            Assert.AreEqual(new[]{42}, _fragments);
        }


        [Test]
        public void Simple_array()
        {
            _sut.Process(new[]{42});

            Assert.AreEqual(3, _fragments.Count);
            Assert.AreEqual(42, _fragments[1]);
        }


        [Test]
        public void Non_scalar()
        {
            _sut.Process(new Non_scalar {i = 42, s = "hello"});

            Assert.AreEqual(4, _fragments.Count);
            Assert.AreEqual(42, _fragments[1]);
        }


        [Test]
        public void Multiple_refs_to_same_obj()
        {
            var c = new Child {s = "a"};
            var p = new Parent {left = c, right = c};
            _sut.Process(p);

            Assert.AreEqual(7, _fragments.Count);
            Assert.AreEqual(new OpeningFragment(c.GetType().ToString()), _fragments[1]);
            Assert.AreEqual("a", _fragments[2]);
            Assert.AreEqual(new ObjectReferenceFragment(2), _fragments[4]);
        }

        
        [Test]
        public void Recursive_object_tree()
        {
            var p = new Parent();
            p.grandParent = p;
            _sut.Process(p);

            Assert.AreEqual(5, _fragments.Count);
            Assert.AreEqual(new ObjectReferenceFragment(1), _fragments[3]);
        }
    }


    class Non_scalar
    {
        public int i;
        public string s;
    }


    class Child
    {
        public string s;
    }

    class Parent
    {
        public Child left, right;
        public Parent grandParent;
    }
}