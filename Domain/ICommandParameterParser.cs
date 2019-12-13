using System;

namespace Domain
{
    public interface ICommandParameterParser
    {
        (int Value, OperationType OperationType) Parse();
    }
}
