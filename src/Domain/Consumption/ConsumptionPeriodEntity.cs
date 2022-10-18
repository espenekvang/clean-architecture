using Domain.ValueTypes;

namespace Domain.Consumption
{
    internal record ConsumptionPeriodEntity(Period Period, double Value, UnitOfMeasurement UnitOfMeasurement);
}
