namespace Domain.ValueTypes
{
    public record CustomerName
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
