using Commerce.Core.Entities;

namespace Commerce.Core
{
    public class AddressBuilder
    {

        private string _streetAddress1;
        private string _streetAddress2;
        private string _city;
        private string _state;
        private string _postalCode;

        public AddressBuilder StreetAddress1(string streetAddress1)
        {
            _streetAddress1 = streetAddress1;
            return this;
        }

        public AddressBuilder StreetAddress2(string streetAddress2)
        {
            _streetAddress2 = streetAddress2;
            return this;
        }

        public AddressBuilder City(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder State(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder PostalCode(string postalCode)
        {
            _postalCode = postalCode;
            return this;
        }

        public static implicit operator Address(AddressBuilder addressBuilder)
        {
            return new Address(addressBuilder._streetAddress1,
                               addressBuilder._streetAddress2,
                               addressBuilder._city,
                               addressBuilder._state,
                               addressBuilder._postalCode);
        }



    }
}