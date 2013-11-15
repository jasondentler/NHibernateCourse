using System;
using Commerce.Core.Extensions;

namespace Commerce.Core.Entities
{
    public class ProductInformation : IValueObject<ProductInformation>
    {

        private readonly long _productId;
        private readonly string _title;
        private readonly decimal _price;

        public ProductInformation(long productId, string title, decimal price) 
        {
            _productId = productId;
            _title = title;
            _price = price;
        }

        public ProductInformation(Product product)
        {
            if (product == null) throw new ArgumentNullException("product");
            _productId = product.Id;
            _title = product.Title;
            _price = product.Price;
        }

        public long ProductId { get { return _productId; } }
        public string Title { get { return _title; } }
        public decimal Price { get { return _price; } }

        public bool Equals(ProductInformation other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;

            return Equals(ProductId, other.ProductId) &&
                   Equals(Title, other.Title) &&
                   Equals(Price, other.Price);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProductInformation);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ProductId.GetHashCode();
                hashCode = (hashCode*397) ^ Title.GetHashCodeSafely();
                hashCode = (hashCode*397) ^ Price.GetHashCode();
                return hashCode;
            }
        }

        public static implicit operator ProductInformation(Product product)
        {
            if (product == null) return null;
            return new ProductInformation(product);
        }

    }
}