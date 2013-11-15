using System;
using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class CustomerInformationMap
    {

        public static Action<ComponentPart<CustomerInformation>> Map()
        {
            return WithColumnPrefix("Customer");
        }

        public static Action<ComponentPart<CustomerInformation>> WithColumnPrefix(string columnPrefix)
        {
            return a =>
                {
                    a.Map(x => x.CustomerId, columnPrefix + "Id");
                    a.Map(x => x.Name, columnPrefix + "Name");
                };
        }

    }
}