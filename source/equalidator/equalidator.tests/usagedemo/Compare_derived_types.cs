using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using equalidator.exceptions;
using NUnit.Framework;

namespace equalidator.tests.usagedemo
{
    [TestFixture]
    public class Compare_derived_types
    {
        [Test]
        public void Type_hierarchy()
        {
            var d1 = new DerivedType(1, 2, 3) { publicField = 4, publicFieldDerived = 5 };
            var d2 = new DerivedType(99, 2, 3) { publicField = 4, publicFieldDerived = 5 };

            Assert.Throws<NotEqualDueToDifferentValues>(() => Equalidator.AreEqual(d1, d2));
        }
    }

    class BaseType
    {
        private int _privateField;
        protected int _protectedField;
        public int publicField;

        public BaseType(int privateField, int protectedField)
        {
            _privateField = privateField;
            _protectedField = protectedField;
        }
    }

    class DerivedType : BaseType
    {
        private int _privateFieldDerived;
        public int publicFieldDerived;

        public DerivedType(int privateField, int protectedField, int privateFieldDerived) : base(privateField, protectedField)
        {
            _privateFieldDerived = privateFieldDerived;
        }
    }
}