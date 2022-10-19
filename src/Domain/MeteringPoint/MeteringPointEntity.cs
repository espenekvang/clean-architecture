using Domain.ValueTypes;

namespace Domain.MeteringPoint
{
    public record MeteringPointEntity(
        MeteringPointId MeteringPointId,
        MeteringPointName Name,
        Address Address,
        PowerZone PowerZone)
    {
        public MeteringPointEntity(string meteringPointId, string name, string street, string zipCode, string powerZone) 
            : this(
                new MeteringPointId(meteringPointId), 
                new MeteringPointName(name), 
                new Address(street, zipCode),
                new PowerZone(powerZone)){}
    }
}
