namespace Domain
{
    public class CommandParameters
    {
        public int Value { get; protected set; }
        public OperationType OperationType { get; protected set; }

        public CommandParameters(int value, OperationType operationType)
        {
            Value = value;
            OperationType = operationType;
        }
    }
}
