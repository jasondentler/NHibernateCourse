using System;

namespace Commerce.Core.Entities
{

    public class Customer 
    {

        public Customer(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
        }

        public long Id { get; protected set; }
        public string Name { get; set; }
    }
}