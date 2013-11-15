using System;
using Commerce.Core.Entities;
using FluentNHibernate.Mapping;

namespace Commerce.Core.DataAccess.Mappings
{
    public class ProductInformationMap
    {

        public static Action<ComponentPart<ProductInformation>> Map()
        {
            return WithColumnPrefix("Product");
        }

        public static Action<ComponentPart<ProductInformation>> WithColumnPrefix(string columnPrefix)
        {
            return a =>
            {
                a.Map(x => x.ProductId, columnPrefix + "Id");
                a.Map(x => x.Title, columnPrefix + "Title");
                a.Map(x => x.Price, columnPrefix + "Price");
            };
        }

    }

}