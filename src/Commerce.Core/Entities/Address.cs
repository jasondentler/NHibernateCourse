using Commerce.Core.Extensions;

namespace Commerce.Core.Entities
{
    public class Address : IValueObject<Address>
    {
        private readonly string _streetAddress1;
        private readonly string _streetAddress2;
        private readonly string _city;
        private readonly string _state;
        private readonly string _postalCode;

        public Address(string streetAddress1, string streetAddress2, string city, string state, string postalCode)
        {
            _streetAddress1 = streetAddress1;
            _streetAddress2 = streetAddress2;
            _city = city;
            _state = state;
            _postalCode = postalCode;
        }

        public string StreetAddress1 { get { return _streetAddress1; } }
        public string StreetAddress2 { get { return _streetAddress2; } }
        public string City { get { return _city; } }
        public string State { get { return _state; } }
        public string PostalCode { get { return _postalCode; } }

        public bool Equals(Address other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return string.Equals(StreetAddress1, other.StreetAddress1) &&
                   string.Equals(StreetAddress2, other.StreetAddress2) &&
                   string.Equals(City, other.City) &&
                   string.Equals(State, other.State) &&
                   string.Equals(PostalCode, other.PostalCode);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StreetAddress1.GetHashCodeSafely();
                hashCode = (hashCode * 397) ^ StreetAddress2.GetHashCodeSafely();
                hashCode = (hashCode * 397) ^ City.GetHashCodeSafely();
                hashCode = (hashCode * 397) ^ State.GetHashCodeSafely();
                hashCode = (hashCode * 397) ^ PostalCode.GetHashCodeSafely();
                return hashCode;
            }
        }

        public static bool operator ==(Address a, Address b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return !(a == b);
        }
    }
}

