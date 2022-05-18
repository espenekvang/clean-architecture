namespace Domain.ValueTypes
{
    public readonly struct Country
    {
        public string Name { get; init; }

        private Country(string name)
        {
            Name = name;
        }

        public static Country From(string value)
        {
            return new Country(value);
        }
    }
}
