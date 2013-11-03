using System;
using equalidator.flowmodel;

// How to create a NuGet package: http://blog.tomasjansson.com/creating-a-nuget-package

namespace equalidator
{
    public static class Equalidator
    {
        public static void AreEqual(object a, object b) { AreEqual(a, b, false); }
        public static void AreEqual(object a, object b, bool treatAllIEnumerablesAlike)
        {
            var flow = new EqualidatorFlow(treatAllIEnumerablesAlike);
            flow.Process(new Tuple<object, object>(a,b));
        }
    }
}
