namespace Domain.ValueTypes
{
    public readonly struct MeteringPointId
    {
        public readonly ulong Value;
        private const double RequiredNumberOfDigits = 16;

        private MeteringPointId(ulong value)
        {
            Value = value;
        }

        public static (bool successful, MeteringPointId measuringPointId) TryCreateMeasuringPointId(
            ulong measuringPointIdNumber)
        {
            var validMeasuringPointId = Math.Floor(
                Math.Log10(measuringPointIdNumber) + 1) == RequiredNumberOfDigits;

            return validMeasuringPointId ? (true, new MeteringPointId(measuringPointIdNumber)) : (false, default(MeteringPointId));
        }
    }
}
