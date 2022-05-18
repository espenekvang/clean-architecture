namespace Domain.ValueTypes
{
    public readonly struct CustomerId
    {
        public string Value { get; init; }

        public CustomerId(string value)
        {
            Value = value;
        }
    }
}
