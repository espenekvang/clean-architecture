namespace Domain.ValueTypes
{
    public record Country (string Name)
    {
        public static Country From(string value)
        {
            return new Country(value);
        }
    }
}
