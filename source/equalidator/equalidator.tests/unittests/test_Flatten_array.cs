using System.Collections.Generic;
using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Flatten_array
    {
        private Flatten_array _sut;
        private List<object> _fragments;

        [SetUp]
        public void Initialize()
        {
            _sut = new Flatten_array();

            _fragments = new List<object>();
        }


        [Test]
        public void Pass_on_non_array_object()
        {
            _sut.PassOn += _ => _fragments.Add(_);
            _sut.Process(42);

            Assert.AreEqual(1, _fragments.Count);
            Assert.AreEqual(42, _fragments[0]);
        }


        [Test]
        public void Enclose_array_elements_with_meta_fragments()
        {
            _sut.MetaObject += _ => _fragments.Add(_);
            _sut.Process(new int[0]);

            Assert.AreEqual(2, _fragments.Count);
            Assert.IsInstanceOf<OpeningFragment>(_fragments[0]);
            Assert.IsInstanceOf<ClosingFragment>(_fragments[1]);
        }


        [Test]
        public void Describe_array_in_opening_fragment()
        {
            _sut.MetaObject += _ => _fragments.Add(_);

            _sut.Issue_descriptive_opening_fragment(new int[0]);
            Assert.AreEqual("System.Int32[];1;0", ((OpeningFragment)_fragments[0])._data);
            _fragments.Clear();

            _sut.Issue_descriptive_opening_fragment(new[] {1, 2});
            Assert.AreEqual("System.Int32[];1;2", ((OpeningFragment)_fragments[0])._data);
            _fragments.Clear();

            _sut.Issue_descriptive_opening_fragment(new[,] { {1, 2}, {3, 4}, {5, 6} });
            Assert.AreEqual("System.Int32[,];2;3,2", ((OpeningFragment)_fragments[0])._data);
            _fragments.Clear();

            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new[] {1};
            jaggedArray[1] = new[] {2,3};
            _sut.Issue_descriptive_opening_fragment(jaggedArray);
            Assert.AreEqual("System.Int32[][];1;2", ((OpeningFragment)_fragments[0])._data);
        }


        [Test]
        public void Iterate_array_elements()
        {
            _sut.Element += _ => _fragments.Add(_);

            _sut.Iterate_array_elements_in_all_dimensions(new int[0], new List<int>());
            Assert.AreEqual(0, _fragments.Count);
            _fragments.Clear();

            _sut.Iterate_array_elements_in_all_dimensions(new[]{42, 99}, new List<int>());
            Assert.AreEqual(new[] {42, 99}, _fragments.ToArray());
            _fragments.Clear();

            _sut.Iterate_array_elements_in_all_dimensions(new[,] { {1,2}, {3,4}, {5,6} }, new List<int>());
            Assert.AreEqual(new[] { 1,2,3,4,5,6 }, _fragments.ToArray());
            _fragments.Clear();

            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new[] { 1 };
            jaggedArray[1] = new[] { 2, 3 };
            _sut.Iterate_array_elements_in_all_dimensions(jaggedArray, new List<int>());
            Assert.AreEqual(2, _fragments.Count);
            Assert.AreEqual(new[] {1}, _fragments[0]);
            Assert.AreEqual(new[] {2,3}, _fragments[1]);
            _fragments.Clear();
        }


        [Test]
        public void Flatten_array_itegration()
        {
            _sut.MetaObject += _ => _fragments.Add(_);
            _sut.Element += _ => _fragments.Add(_);
            _sut.Process(new[] {1, 2});

            Assert.AreEqual(4, _fragments.Count);
            Assert.IsInstanceOf<OpeningFragment>(_fragments[0]);
            Assert.AreEqual(1, _fragments[1]);
            Assert.AreEqual(2, _fragments[2]);
            Assert.IsInstanceOf<ClosingFragment>(_fragments[3]);
        }
    }
}