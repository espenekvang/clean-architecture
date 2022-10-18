
using Domain.MeteringPoint;
using Domain.ValueTypes;

namespace Domain.Customers
{
    public class Customer
    {
        private readonly CustomerEntity _customerEntity;

        public CustomerId Id => _customerEntity.CustomerId;
        public CustomerName Name => _customerEntity.Name;
        public Country Country => _customerEntity.Country;
        public List<MeteringPointEntity> MeteringPoints { get; init; }

        public Customer(CustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
            MeteringPoints = new List<MeteringPointEntity>();
        }

        public Customer(string name, string customerId, string country) : this(new CustomerEntity(name, customerId, country))
        {

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
