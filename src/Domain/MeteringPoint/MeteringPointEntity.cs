using Domain.ValueTypes;

namespace Domain.MeteringPoint
{
    public record MeteringPointEntity
    {
        public MeteringPointId MeteringPointId { get; }
        public MeteringPointName Name { get; }
        public Address Address { get; }
        public PowerZone PowerZone { get; }

        public MeteringPointEntity(MeteringPointId meteringPointId, MeteringPointName name, Address address, PowerZone powerZone)
        {
            MeteringPointId = meteringPointId;
            Name = name;
            Address = address;
            PowerZone = powerZone;
        }
    }
}
