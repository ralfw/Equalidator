using System;

namespace equalidator.exceptions
{
    public class EqualidatorException : Exception
    {
        public EqualidatorException(string message)
            : base(message) {
        }
    }

    public class NotEqualDueToDifferentStructures : EqualidatorException
    {
        public NotEqualDueToDifferentStructures(int expectedLength, int actualLength)
            : base($"\nThe length of the structures (including private properties etc.) are different:\n  Expected: {expectedLength}\n  But was:  {actualLength}") {
        }
    }

    public class NotEqualDueToDifferentTypes : EqualidatorException
    {
        public NotEqualDueToDifferentTypes(Type expectedType, Type actualType)
            : base($"\nThe following types are different:\n  Expected: {expectedType}\n  But was:  {actualType}") {
        }
    }

    public class NotEqualDueToDifferentValues : EqualidatorException
    {
        public NotEqualDueToDifferentValues(object expected, object actual)
            : base($"\nThe following values are different:\n  Expected: {expected}\n  But was:  {actual}") {
        }
    }
}