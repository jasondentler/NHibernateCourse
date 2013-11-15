using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class ProductMap : ClassMap<Product>
    {

        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.HiLo("100");
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.ImageUrl).CustomType(typeof(UriType));
        }

    }
}