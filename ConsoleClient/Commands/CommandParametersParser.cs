using System;
using Domain;
using Domain.Exceptions;

namespace ConsoleClient.Commands
{
    public class CommandParametersParser : ICommandParameterParser
    {
        private string[] _arrayToParse;

        public CommandParametersParser(string[] arrayToParse)
        {
            _arrayToParse = arrayToParse ?? throw new ArgumentNullException(nameof(arrayToParse));
        }

        public (int Value, OperationType OperationType) Parse()
        {
            if (_arrayToParse.Length < 2)
            {
                throw new TooMuchShortArgumentsListException(_arrayToParse, 2);
            }

            var value = GetIntegerValue();
            var operationType = GetOperationType();

            return (value, operationType);
        }

        private int GetIntegerValue()
        {
            var valueString = _arrayToParse[0];

            if(!int.TryParse(valueString, out var value))
            {
                throw new NoIntegerArgumentException();
            }

            return value;
        }

        private OperationType GetOperationType()
        {
            var operationName = GetOperationName();

            if(!Enum.TryParse(typeof(OperationType), operationName, out var operationType))
            {
                throw new NoExpectedOperationsInArgumentsException();
            }

            return (OperationType)operationType;
        }

        private string GetOperationName()
        {
            var operationName = _arrayToParse[1];

            if (string.IsNullOrWhiteSpace(operationName))
            {
                throw new NoExpectedOperationsInArgumentsException();
            }

            var operationNameInLower = operationName.ToLowerInvariant();
            var startCharacter = operationNameInLower[0].ToString().ToUpperInvariant();
            operationName = startCharacter + operationNameInLower.Remove(0, 1);

            return operationName;
        }
    }
}
