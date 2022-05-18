using Domain.ValueTypes;

namespace Domain.MeteringPoint
{
    public class MeteringPointEntity
    {
        public MeteringPointId MeteringPointId { get; }
        public Name Name { get; }
        public Address Address { get; }
        public PowerZone PowerZone { get; }

        public MeteringPointEntity(MeteringPointId meteringPointId, Name name, Address address, PowerZone powerZone)
        {
            MeteringPointId = meteringPointId;
            Name = name;
            Address = address;
            PowerZone = powerZone;
        }
    }
}
