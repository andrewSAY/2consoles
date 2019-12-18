using System;

namespace Domain.Exceptions
{
    public class FailToCallRemoteServerCalculatorException : Exception
    {
        public FailToCallRemoteServerCalculatorException(string details, Exception innerException) : base(details, innerException)
        { }
    }
}
