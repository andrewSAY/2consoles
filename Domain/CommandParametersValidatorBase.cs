namespace Domain
{
    public abstract class CommandParametersValidatorBase
    {
        protected int Value { get; private set; }
        protected OperationType OperationType { get; private set; }

        public CommandParametersValidatorBase(int value, OperationType operationType)
        {
            Value = value;
            OperationType = operationType;
        }

        public abstract void Check();
    }
}
