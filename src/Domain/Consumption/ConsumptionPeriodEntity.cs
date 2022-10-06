using Domain.ValueTypes;

namespace Domain.Consumption
{
    internal record ConsumptionPeriodEntity
    {
        public Period Period { get; }
        public double Value { get; }
        public UnitOfMeasurement UnitOfMeasurement { get; }

        public ConsumptionPeriodEntity(Period period, double value, UnitOfMeasurement unitOfMeasurement)
        {
            Period = period;
            Value = value;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
