namespace Domain.ValueTypes
{
    public record CustomerId (string Value)
    {
        public static CustomerId From(string value)
        {
            return new CustomerId(value);
        }
    }
}
