namespace Domain.ValueTypes
{
    public record CustomerName (string Value)
    {
        public static CustomerName From(string value)
        {
            return new CustomerName(value);
        }
    }
}
