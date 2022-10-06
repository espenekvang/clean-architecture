using Domain.ValueTypes;

namespace Domain.Consumption
{
    internal record Consumption
    {
        public MeteringPointId MeteringPointId { get; }
        public Period Period { get; }
        public IList<ConsumptionPeriodEntity> ConsumptionPeriodEntities { get; }

        public double TotalConsumption
        {
            get { return ConsumptionPeriodEntities.Sum(entity => entity.Value); }
        }

        public Consumption(MeteringPointId meteringPointId, Period period, IList<ConsumptionPeriodEntity> consumptionPeriodEntities)
        {
            MeteringPointId = meteringPointId;
            Period = period;
            ConsumptionPeriodEntities = consumptionPeriodEntities;
        }
    }
}
