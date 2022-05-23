using Domain.ValueTypes;

namespace Domain.MeteringPoint
{
    public class MeteringPointEntity
    {
        public MeteringPointId MeteringPointId { get; }
        public CustomerName Name { get; }
        public Address Address { get; }
        public PowerZone PowerZone { get; }

        public MeteringPointEntity(MeteringPointId meteringPointId, CustomerName name, Address address, PowerZone powerZone)
        {
            MeteringPointId = meteringPointId;
            Name = name;
            Address = address;
            PowerZone = powerZone;
        }
    }
}
