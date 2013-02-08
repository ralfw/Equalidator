using System;
using System.Collections.Generic;

namespace equalidator.flowmodel
{
    internal class Flatten
    {
        public Flatten() : this(false) {}
        public Flatten(bool treatAllIEnumerablesAlike)
        {
            // Build
            var handleNull = new Flatten_null();
            var scalar = new Flatten_scalar();
            var cache = new Cache();
            var ienum = new Flatten_IEnumerables_all_alike();
            var array = new Flatten_array();
            var nonScalar = new Flatten_non_scalar_field_by_field();
            var collect = new Collect();

            // Bind
            _process = handleNull.Process;

            handleNull.Null += collect.Process;
            handleNull.PassOn += scalar.Process;

            scalar.Scalar += collect.Process;
            scalar.PassOn += cache.Process;

            cache.CacheHit += collect.Process;
            cache.CacheMiss += ienum.Process;

            ienum.MetaObject += collect.Process;
            ienum.Element += handleNull.Process; // recursion for IEnum elements
            ienum.PassOn += array.Process;

            array.MetaObject += collect.Process;
            array.Element += handleNull.Process; // recursion for array elements
            array.PassOn += nonScalar.Process;

            nonScalar.MetaObject += collect.Process;
            nonScalar.FieldValue += _process; // recursion for field values

            collect.Result += _ => this.Result(_);

            // Config
            ienum.Configure(treatAllIEnumerablesAlike.ToString());
        }


        private readonly Action<object> _process;
        public void Process(object objectToFlatten)
        {
            _process(objectToFlatten);
        }

        public event Action<IEnumerable<object>> Result;
    }
}