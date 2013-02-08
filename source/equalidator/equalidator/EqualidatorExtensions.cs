namespace equalidator
{
    public static class EqualidatorExtensions
    {
        public static void ShouldEqual(this object someObject, object someOtherObject) { someObject.ShouldEqual(someOtherObject, false); }
        public static void ShouldEqual(this object someObject, object someOtherObject, bool treatAllIEnumerablesAlike)
        {
            Equalidator.AreEqual(someObject, someOtherObject, treatAllIEnumerablesAlike);
        }
    }
}