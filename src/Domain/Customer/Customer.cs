
using Domain.MeteringPoint;
using Domain.ValueTypes;

namespace Domain.Customer
{
    public class Customer
    {
        private readonly CustomerEntity _customerEntity;
        private readonly IList<MeteringPointEntity> _meteringPoints;

        public CustomerId Id => _customerEntity.CustomerId;

        public Customer(CustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
            _meteringPoints = new List<MeteringPointEntity>();
        }

        public void AddMeteringPoint(MeteringPointEntity meteringPoint)
        {
            _meteringPoints.Add(meteringPoint);
        }

        public void RemoveMeteringPoint(MeteringPointEntity meteringPoint)
        {
            _meteringPoints.Remove(meteringPoint);
        }
    }
}
