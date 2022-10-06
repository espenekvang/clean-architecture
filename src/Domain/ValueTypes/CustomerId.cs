namespace Domain.ValueTypes
{
    public record CustomerId
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
