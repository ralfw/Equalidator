using System;
using System.Collections.Generic;
using System.Linq;
using equalidator.exceptions;

namespace equalidator.flowmodel
{
    internal class Check_equality
    {
        public void Process(Tuple<IEnumerable<object>, IEnumerable<object>> flattenedObjects)
        {
            var a = flattenedObjects.Item1.ToArray();
            var b = flattenedObjects.Item2.ToArray();

            if (a.Length != b.Length) throw new NotEqualDueToDifferentStructures(a.Length, b.Length);

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i].GetType() != b[i].GetType()) throw new NotEqualDueToDifferentTypes(a[i].GetType(), b[i].GetType());
                if (!a[i].Equals(b[i])) throw new NotEqualDueToDifferentValues(a[i], b[i]);
            }
        }
    }
}