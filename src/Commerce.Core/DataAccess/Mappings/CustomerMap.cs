using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.Name);
        }
    }
}