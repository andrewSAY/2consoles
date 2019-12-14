using System;
using Domain;

namespace ConsoleClient.Commands
{
    public class CommandParametersValidator : CommandParametersValidatorBase
    {
        public CommandParametersValidator(int value, OperationType operationType) : base(value, operationType)
        {
        }

        public override void Check()
        {
            if (Value > 100 || Value < 1)
            {
                throw new ArgumentOutOfRangeException($"The value must be between 1 and 100, but was {Value}");
            }
        }
    }
}
