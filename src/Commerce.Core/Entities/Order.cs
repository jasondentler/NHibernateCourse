using System;
using System.Collections.Generic;

namespace Commerce.Core.Entities
{
    public class Order : AggregateRoot<Order, long>
    {

        public Order(Customer customer, Address shippingAddress, Address billingAddress) : this((CustomerInformation) customer, shippingAddress, billingAddress)
        {
        }

        public Order(CustomerInformation customer, Address shippingAddress, Address billingAddress) : this()
        {
            if (customer == null) throw new ArgumentNullException("customer");
            if (shippingAddress == null) throw new ArgumentNullException("shippingAddress");
            if (billingAddress == null) throw new ArgumentNullException("billingAddress");
            Customer = customer;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAddress;
        }

        protected Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; protected set; }
        public CustomerInformation Customer { get; protected set; }
        public ISet<OrderItem> OrderItems { get; protected set; }
        public DateTime Placed { get; protected set; }
        public Address ShippingAddress { get; protected set; }
        public Address BillingAddress { get; protected set; }
    }
}