using System.Collections.Generic;
using System.Linq;
using equalidator.datamodel;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Flatten_non_scalar
    {
        private Flatten_non_scalar_field_by_field _sut;
        private List<object> _metaFragments;
        private List<object> _fragments;
        
        [SetUp]
        public void Initialize()
        {
            _sut = new Flatten_non_scalar_field_by_field();
            _sut.MetaObject += _ => _metaFragments.Add(_);
            _sut.FieldValue += _ => _fragments.Add(_);
            _metaFragments = new List<object>();
            _fragments = new List<object>();
        }


        [Test]
        public void Issue_opening_and_closing_fragments()
        {
            _sut.Process(new No_fields());

            Assert.AreEqual(2, _metaFragments.Count);
            Assert.AreEqual(typeof(No_fields).ToString(), ((OpeningFragment)_metaFragments[0])._data);
            Assert.IsInstanceOf<ClosingFragment>(_metaFragments[1]);
        }


        [Test]
        public void Collect_types_of_hierarchy()
        {
            var types = Flatten_non_scalar_field_by_field.Collect_type_hierarchy(typeof(Derived_with_different_visibilities));
            Assert.AreEqual(new[] { typeof(Derived_with_different_visibilities), typeof(Different_field_visibilities), typeof(object) },
                            types.ToArray());
        }


        [Test]
        public void Collect_fields_of_base_type()
        {
            var fields = Flatten_non_scalar_field_by_field.Collect_fields(new Different_field_visibilities());
            Assert.AreEqual(5, fields.Count());
        }


        [Test]
        public void Collect_fields_of_derived_type()
        {
            var fields = Flatten_non_scalar_field_by_field.Collect_fields(new Derived_with_different_visibilities());
            Assert.AreEqual(7, fields.Count());

        }

        
        [Test]
        public void Field_values_are_passed_on()
        {
            var o = new Different_field_visibilities {internalField = 1, protectedInternalField = 2, publicField = 3};
            
            _sut.Process(o);

            Assert.AreEqual(new[] {42, 1, 99, 2, 3}, _fragments);
        }
    }


    class No_fields {}

    class Different_field_visibilities
    {
        private int privateField=42;
        internal int internalField;
        protected int protectedField=99;
        protected internal int protectedInternalField;
        public int publicField;
    }

    class Derived_with_different_visibilities : Different_field_visibilities
    {
        private int derivedPrivateField;
        public int derivedPublicField;
    }
}