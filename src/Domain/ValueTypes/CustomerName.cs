namespace Domain.ValueTypes
{
    public readonly struct CustomerName
    {
        public string Value { get; init; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static CustomerName From(string value)
        {
            return new CustomerName(value);
        }
    }
}
