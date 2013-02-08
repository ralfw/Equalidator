using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using equalidator.datamodel;
using equalidator.infrastructure;

namespace equalidator.flowmodel
{
    public class Flatten_IEnumerables_all_alike : IConfigurable
    {
        private bool _treat_all_enums_alike;

        public void Configure(params string[] args)
        {
            _treat_all_enums_alike = bool.Parse(args[0]);
        }


        public void Process(object objectToFlatten)
        {
            var enumerable = objectToFlatten as IEnumerable;
            if (enumerable != null && _treat_all_enums_alike)
            {
                MetaObject(new OpeningFragment("IEnumerable"));
                foreach (var e in enumerable)
                    Element(e);
                MetaObject(new ClosingFragment());
            }
            else
                PassOn(objectToFlatten);
        }


        public event Action<object> MetaObject;
        public event Action<object> Element;
        public event Action<object> PassOn;
    }
}