using Domain.ValueTypes;

namespace Domain.MeteringPoint
{
    public class MeteringPointEntity
    {
        public MeteringPointId MeteringPointId { get; }
        public CustomerName CustomerName { get; }
        public Address Address { get; }
        public PowerZone PowerZone { get; }

        public MeteringPointEntity(MeteringPointId meteringPointId, CustomerName customerName, Address address, PowerZone powerZone)
        {
            MeteringPointId = meteringPointId;
            CustomerName = customerName;
            Address = address;
            PowerZone = powerZone;
        }
    }
}
