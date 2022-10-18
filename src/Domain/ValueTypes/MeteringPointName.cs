namespace Domain.ValueTypes
{
    public record MeteringPointName (string Value)
    {
        public static MeteringPointName From(string value)
        {
            return new MeteringPointName(value);
        }
    }
}
