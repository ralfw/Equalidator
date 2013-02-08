using System;
using System.Collections.Generic;
using equalidator.datamodel;

namespace equalidator.flowmodel
{
    public class Flatten_array
    {
        public void Process(object objectToFlatten)
        {
            if (objectToFlatten.GetType().IsArray)
            {
                Issue_descriptive_opening_fragment(objectToFlatten);
                Iterate_array_elements_in_all_dimensions((Array)objectToFlatten, new List<int>());
                Issue_closing_fragment();
            }
            else
                this.PassOn(objectToFlatten);
        }


        internal void Issue_descriptive_opening_fragment(object objectToFlatten)
        {
            var t = objectToFlatten.GetType();

            var dimensionLengths = "";
            for(var d = 0; d < t.GetArrayRank(); d++)
            {
                if (d>0) dimensionLengths += ",";
                dimensionLengths += ((Array)objectToFlatten).GetLength(d);
            }
            
            this.MetaObject(new OpeningFragment(string.Format("{0};{1};{2}", t, t.GetArrayRank(), dimensionLengths)));
        }


        internal void Iterate_array_elements_in_all_dimensions(Array objectToFlatten, List<int> indexes)
        {
            var t = objectToFlatten.GetType();
            if (t.GetArrayRank() > indexes.Count)
                for (var i = 0; i < objectToFlatten.GetLength(indexes.Count); i++)
                {
                    indexes.Add(i);
                    Iterate_array_elements_in_all_dimensions(objectToFlatten, indexes);
                    indexes.RemoveAt(indexes.Count - 1);
                }
            else
                this.Element(objectToFlatten.GetValue(indexes.ToArray()));
        }


        private void Issue_closing_fragment()
        {
            this.MetaObject(new ClosingFragment());
        }


        public event Action<object> MetaObject;
        public event Action<object> Element;
        public event Action<object> PassOn;
    }
}