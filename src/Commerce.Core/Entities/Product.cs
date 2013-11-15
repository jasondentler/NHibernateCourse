using System;

namespace Commerce.Core.Entities
{
    public class Product
    {

        public long Id { get; protected set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUrl { get; set; }

        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            if (title == null) throw new ArgumentNullException("title");
            if (description == null) throw new ArgumentNullException("description");
        }

        protected Product()
        {
        }

    }
}