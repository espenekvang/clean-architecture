using Domain.ValueTypes;

namespace Domain.Consumption
{
    internal record Consumption (MeteringPointId MeteringPointId, Period Period, IList<ConsumptionPeriodEntity> ConsumptionPeriodEntities)
    {
        public double TotalConsumption
        {
            get { return ConsumptionPeriodEntities.Sum(entity => entity.Value); }
        }
    }
}
