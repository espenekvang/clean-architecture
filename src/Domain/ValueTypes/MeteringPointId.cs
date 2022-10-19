namespace Domain.ValueTypes
{
    public record MeteringPointId (string Value)
    {
        private const double RequiredNumberOfDigits = 16;

        public static (bool successful, MeteringPointId measuringPointId) TryCreateMeasuringPointId(
            string measuringPointIdNumber)
        {
            var validMeasuringPointId = Math.Floor(
                Math.Log10(ulong.Parse(measuringPointIdNumber)) + 1) == RequiredNumberOfDigits;

            return validMeasuringPointId ? (true, new MeteringPointId(measuringPointIdNumber.ToString())) : (false, default(MeteringPointId));
        }
    }
}
