using System;
using Commerce.Core.Extensions;

namespace Commerce.Core.Entities
{
    public class CustomerInformation : IValueObject<CustomerInformation>
    {
        private readonly long _customerId;
        private readonly string _name;

        public long CustomerId { get { return _customerId; }}
        public string Name { get { return _name; }}

        public CustomerInformation(long customerId, string name)
        {
            _customerId = customerId;
            _name = name;
        }

        public CustomerInformation(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException("customer");
            _customerId = customer.Id;
            _name = customer.Name;
        }

        public bool Equals(CustomerInformation other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;

            return Equals(CustomerId, other.CustomerId) &&
                   Equals(Name, other.Name);

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CustomerInformation);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CustomerId.GetHashCode();
                hashCode = (hashCode*397) ^ Name.GetHashCodeSafely();
                return hashCode;
            }
        }

        public static implicit operator CustomerInformation(Customer customer)
        {
            if (customer == null) return null;
            return new CustomerInformation(customer);
        }

        public static bool operator ==(CustomerInformation a, CustomerInformation b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(CustomerInformation a, CustomerInformation b)
        {
            return !(a == b);
        }
    }
}
