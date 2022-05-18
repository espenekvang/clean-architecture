namespace Domain.ValueTypes
{
    internal readonly struct Period
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }

        public Period(DateTime @from, DateTime to)
        {
            From = @from;
            To = to;
        }
    }
}
