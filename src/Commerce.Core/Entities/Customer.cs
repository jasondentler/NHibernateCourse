using System;

namespace Commerce.Core.Entities
{

    public class Customer  : AggregateRoot<Customer, long>
    {

        public Customer(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public string Name { get; set; } 
    }
}