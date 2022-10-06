namespace Domain.ValueTypes
{
    public record PowerZone
    {
        public string Code { get; init; }
        private static readonly List<string> ValidCodes = new() { "NO1", "NO2", "NO3", "NO4", "NO5" };

        private PowerZone(string code)
        {
            Code = code;
        }

        public static (bool successful, PowerZone powerZone) TryCreatePowerZone(string powerZone)
        {
            return ValidCodes.Contains(powerZone, StringComparer.InvariantCultureIgnoreCase)
                ? (true, new PowerZone(powerZone.ToUpper()))
                : (false, default);
        }
    }
}
