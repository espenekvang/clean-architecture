namespace Domain.ValueTypes
{
    public record Address
    {
        public string StreetName { get; init; }
        public int ZipCode { get; init; }
        public int StreetNumber { get; init; }
        public string? StreetLetter { get; init; }

        public Address(string streetName, int zipCode, int streetNumber, string? streetLetter = default(string))
        {
            StreetName = streetName;
            ZipCode = zipCode;
            StreetNumber = streetNumber;
            StreetLetter = streetLetter;
        }
    }
}
