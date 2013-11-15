using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class OrderMap : ClassMap<Order>
    {

        public OrderMap()
        {

            Table("Orders");
            Id(x => x.Id).GeneratedBy.HiLo("100");

            Component(o => o.Customer, CustomerInformationMap.Map());
            Component(o => o.BillingAddress, AddressMap.WithColumnPrefix("BillingAddress"));
            Component(o => o.ShippingAddress, AddressMap.WithColumnPrefix("ShippingAddress"));
            
            Map(x => x.Placed);

            HasMany(o => o.OrderItems)
                .AsSet()
                .Not.LazyLoad()
                .Inverse();
        }

    }
}
