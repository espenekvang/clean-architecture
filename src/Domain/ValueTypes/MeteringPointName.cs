namespace Domain.ValueTypes
{
    public class MeteringPointName
    {
        public string Value { get; init; }

        private MeteringPointName(string value)
        {
            Value = value;
        }

        public static MeteringPointName From(string value)
        {
            return new MeteringPointName(value);
        }
    }
}
