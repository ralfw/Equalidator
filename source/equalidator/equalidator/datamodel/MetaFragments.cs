namespace equalidator.datamodel
{
    internal class OpeningFragment
    {
        internal readonly string _data;
        public OpeningFragment(string data) { _data = data; }

        public override bool Equals(object obj)
        {
            var that = obj as OpeningFragment;
            if (that == null) return false;

            return _data == that._data;
        }
    }


    internal class ClosingFragment
    {
        public override bool Equals(object obj)
        {
            var that = obj as ClosingFragment;
            return that != null;
        }
    }

    
    internal class NullFragment
    {
        public override bool Equals(object obj)
        {
            var that = obj as NullFragment;
            return that != null;
        }
    }


    internal class ObjectReferenceFragment
    {
        internal readonly long _id;
        public ObjectReferenceFragment(long id) { _id = id; }

        public override bool Equals(object obj)
        {
            var that = obj as ObjectReferenceFragment;
            if (that == null) return false;

            return _id == that._id;
        }
    }
}