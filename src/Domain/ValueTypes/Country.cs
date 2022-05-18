namespace Domain.ValueTypes
{
    public readonly struct Country
    {
        public string Name { get; init; }

        public Country(string name)
        {
            Name = name;
        }
    }
}
