using System;

namespace Commerce.Core.Entities
{
    public class OrderItem : Entity<OrderItem, long>
    {

        public OrderItem(Order order, int quantity, ProductInformation product) : this()
        {
            if (order == null) throw new ArgumentNullException("order");
            if (product == null) throw new ArgumentNullException("product");
            Order = order;
            Quantity = quantity;
            Product = product;
        }

        protected OrderItem()
        {
        }

        public long Id { get; protected set; }
        public Order Order { get; protected set; }
        public int Quantity { get; set; }
        public ProductInformation Product { get; protected set; }
    }
}