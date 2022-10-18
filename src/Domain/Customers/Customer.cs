
using Domain.MeteringPoint;
using Domain.ValueTypes;

namespace Domain.Customers
{
    public class Customer
    {
        private readonly CustomerEntity _customerEntity;
        private readonly IList<MeteringPointEntity> _meteringPoints;

        public CustomerId Id => _customerEntity.CustomerId;
        public CustomerName Name => _customerEntity.Name;
        public Country Country => _customerEntity.Country;

        public Customer(CustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
            _meteringPoints = new List<MeteringPointEntity>();
        }

        public Customer(string name, string customerId, string country) : this(new CustomerEntity(name, customerId, country))
        {

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
