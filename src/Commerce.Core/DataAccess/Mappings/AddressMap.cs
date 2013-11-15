using System;
using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class AddressMap
    {

        public static Action<ComponentPart<Address>> Map()
        {
            return WithColumnPrefix("Address");
        }


        public static Action<ComponentPart<Address>> WithColumnPrefix(string columnPrefix)
        {
            return a =>
                {
                    a.Map(x => x.StreetAddress1, columnPrefix + "StreetAddress1");
                    a.Map(x => x.StreetAddress2, columnPrefix + "StreetAddress2");
                    a.Map(x => x.City, columnPrefix + "City");
                    a.Map(x => x.State, columnPrefix + "State");
                    a.Map(x => x.PostalCode, columnPrefix + "PostalCode");
                };
        }

    }
}
