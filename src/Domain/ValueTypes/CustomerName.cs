namespace Domain.ValueTypes
{
    public readonly struct CustomerName
    {
        public string Value { get; init; }

        public CustomerName(string value)
        {
            Value = value;
        }
    }
}
