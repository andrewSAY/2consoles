using System;

namespace Domain.Exceptions
{
    public class OperationResultBiggerPossibleException : Exception
    {
        public OperationResultBiggerPossibleException(int value, string operationName)
            : base($"The result of operation '{operationName}' is no in possible range value from {int.MinValue} to {int.MaxValue}. Passed value {value}")
        { }
    }
}
