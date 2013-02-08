using System;
using System.Collections.Generic;
using equalidator.exceptions;
using equalidator.flowmodel;
using NUnit.Framework;

namespace equalidator.tests.unittests
{
    [TestFixture]
    public class test_Check_equality
    {
        [Test]
        public void Flattened_objects_are_equal()
        {
            var sut = new Check_equality();
            sut.Process(new Tuple<IEnumerable<object>, IEnumerable<object>>(new object[] { 1, 2 }, new object[] { 1, 2 }));
        }


        [Test]
        public void Flattened_objects_of_different_length()
        {
            var sut = new Check_equality();
            Assert.Throws<NotEqualDueToDifferentStructures>(() => sut.Process(new Tuple<IEnumerable<object>, IEnumerable<object>>(new object[] { 1 }, new object[] { 1, 2 })));
        }

        
        [Test]
        public void Flattened_objects_are_not_of_equal_type()
        {
            var sut = new Check_equality();
            Assert.Throws<NotEqualDueToDifferentTypes>(() => sut.Process(new Tuple<IEnumerable<object>, IEnumerable<object>>(new object[] { 1, 2 }, new object[] { 1, "2" })));
        }

        
        [Test]
        public void Flattened_objects_are_not_of_equal_value()
        {
            var sut = new Check_equality();
            Assert.Throws<NotEqualDueToDifferentValues>(() => sut.Process(new Tuple<IEnumerable<object>, IEnumerable<object>>(new object[] { 1, 2 }, new object[] { 1, 3 })));
        }
    }
}