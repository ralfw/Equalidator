using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using equalidator.datamodel;

namespace equalidator.flowmodel
{
    public class Flatten_non_scalar_field_by_field
    {
        public void Process(object objectToFlatten)
        {
            this.MetaObject(new OpeningFragment(objectToFlatten.GetType().ToString()));

            foreach (var f in Collect_fields(objectToFlatten))
                this.FieldValue(f.GetValue(objectToFlatten));

            this.MetaObject(new ClosingFragment());
        }


        internal static IEnumerable<FieldInfo> Collect_fields(object objectToFlatten)
        {
            return Collect_type_hierarchy(objectToFlatten.GetType())
                  .SelectMany(Collect_fields_of_declaring_type);
        }

        private static IEnumerable<FieldInfo> Collect_fields_of_declaring_type(Type t)
        {
            return t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(f => f.DeclaringType == t);
        }


        internal static IEnumerable<Type> Collect_type_hierarchy(Type type)
        {
            yield return type;
            while (type.BaseType != null)
            {
                type = type.BaseType;
                yield return type;
            }
        }

        
        public event Action<object> MetaObject;
        public event Action<object> FieldValue;
    }
}