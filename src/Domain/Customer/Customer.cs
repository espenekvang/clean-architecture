
using Domain.MeteringPoint;
using Domain.ValueTypes;

namespace Domain.Customer
{
    public class Customer
    {
        private readonly CustomerEntity _customerEntity;
        public IList<MeteringPointEntity> MeteringPoints { get; }

        public CustomerId Id => _customerEntity.CustomerId;

        public Customer(CustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
            MeteringPoints = new List<MeteringPointEntity>();
        }

        public void AddMeteringPoint(MeteringPointEntity meteringPoint)
        {
            MeteringPoints.Add(meteringPoint);
        }

        public void RemoveMeteringPoint(MeteringPointEntity meteringPoint)
        {
            MeteringPoints.Remove(meteringPoint);
        }
    }
}
