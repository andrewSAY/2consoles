using System;

namespace Domain.Exceptions
{
    public class TooMuchShortArgumentsListException : Exception
    {
        public TooMuchShortArgumentsListException(object[] argumentsList, int expectedCount)
            : base($"Expected {expectedCount} arguments, but {argumentsList.Length} was passed.")
        { }
    }
}
