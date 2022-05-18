namespace Domain.ValueTypes
{
    public readonly struct CustomerId
    {
        public string Value { get; init; }

        private CustomerId(string value)
        {
            Value = value;
        }

        public static CustomerId From(string value)
        {
            return new CustomerId(value);
        }
    }
}
