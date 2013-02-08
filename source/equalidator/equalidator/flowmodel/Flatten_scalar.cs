using System;

namespace equalidator.flowmodel
{
    public class Flatten_scalar
    {
        public void Process(object objectToFlatten)
        {
            var t = objectToFlatten.GetType();

            if (t.IsPrimitive || t.IsEnum || IsSimpleType(t))
                this.Scalar(objectToFlatten);
            else
                this.PassOn(objectToFlatten);
        }


        private static bool IsSimpleType(Type objectType)
        {
            return objectType == typeof (string) ||
                   objectType == typeof (DateTime) ||
                   objectType == typeof (decimal) ||
                   objectType == typeof (float);
        }


        public event Action<object> Scalar;
        public event Action<object> PassOn;
    }
}