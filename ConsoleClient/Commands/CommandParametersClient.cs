using System;
using Domain;

namespace ConsoleClient.Commands
{
    public class CommandParametersClient : CommandParameters
    {
        private string[] Args;
        private ICommandParameterParser CommandParser => new CommandParametersParser(Args);
        protected CommandParametersValidatorBase CommandParametersValidator => new CommandParametersValidator(Value, OperationType);

        public CommandParametersClient(string[] args) :  base(0, OperationType.Cube)
        {
            Args = args ?? throw new ArgumentNullException(nameof(args));
            ParseAndSetResult();
            CommandParametersValidator.Check();
        }

        private void ParseAndSetResult()
        {
            var parsingResult = CommandParser.Parse();
            Value = parsingResult.Value;
            OperationType = parsingResult.OperationType;
        }
    }
}
