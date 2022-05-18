namespace Domain.ValueTypes
{
    public readonly struct Name
    {
        public string Value { get; init; }

        public Name(string value)
        {
            Value = value;
        }
    }
}
