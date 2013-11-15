using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class OrderItemMap : ClassMap<OrderItem>
    {

        public OrderItemMap()
        {

            Table("OrderItems");
            
            Id(x => x.Id).GeneratedBy.HiLo("1000");

            Component(oi => oi.Product, ProductInformationMap.Map());
            
            Map(oi => oi.Quantity);

            HasOne(oi => oi.Order)
                .Cascade.All()
                .Not.LazyLoad();

        }

    }
}