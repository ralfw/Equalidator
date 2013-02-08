using System;

namespace equalidator.exceptions
{
    public class EqualidatorException : Exception
    {
        public EqualidatorException(string message) : base(message) {}
    }

    public class NotEqualDueToDifferentStructures : EqualidatorException
    {
        public NotEqualDueToDifferentStructures() : base("Objects to compare are not equal! The structures of their object trees differ.") { }
    }

    public class NotEqualDueToDifferentTypes : EqualidatorException
    {
        public NotEqualDueToDifferentTypes() : base("Objects to compare are not equal! The types of some object in the object trees differ.") { }
    }

    public class NotEqualDueToDifferentValues : EqualidatorException
    {
        public NotEqualDueToDifferentValues() : base("Objects to compare are not equal! The values of some fields in the object trees differ.") { }
    }
}