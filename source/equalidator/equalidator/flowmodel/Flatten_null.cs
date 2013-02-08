using System;
using equalidator.datamodel;

namespace equalidator.flowmodel
{
    public class Flatten_null
    {
        public void Process(object objectToFlatten)
        {
            if (objectToFlatten == null)
                this.Null(new NullFragment());
            else
                this.PassOn(objectToFlatten);
        }


        public event Action<object> Null;
        public event Action<object> PassOn;
    }
}