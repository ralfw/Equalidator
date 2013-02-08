using System;
using System.Collections.Generic;
using equalidator.datamodel;

namespace equalidator.flowmodel
{
    public class Cache
    {
        internal readonly Dictionary<object, long> _cache = new Dictionary<object, long>();


        public void Process(object objectToFlatten)
        {
            if (objectToFlatten.GetType().IsValueType) { this.CacheMiss(objectToFlatten); return; }

            long id;
            if (_cache.TryGetValue(objectToFlatten, out id)) { this.CacheHit(new ObjectReferenceFragment(id)); return; }

            id = _cache.Count + 1;
            _cache.Add(objectToFlatten, id);

            this.CacheMiss(objectToFlatten);
        }


        public event Action<object> CacheHit;
        public event Action<object> CacheMiss;
    }
}