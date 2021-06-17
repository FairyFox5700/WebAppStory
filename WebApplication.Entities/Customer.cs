using System;

namespace WebApplication.Entities
{
    public class Customer : Person
    {
        public bool? HasPrivilage { get; private set; }

        public Customer(string name, string phoneName) : base(name, phoneName)
        {
            HasPrivilage = new Random().Next(0, 1) != 0;
            this.CreateEmailAddress();
            Console.WriteLine("Customer constructor was called");
        }

        public Customer(string name, string phoneName,  bool hasPrivilage) : base(name, phoneName)
        {
            HasPrivilage = hasPrivilage;
            this.CreateEmailAddress();
            Console.WriteLine("Customer constructor was called");
        }

        public sealed override void CreateEmailAddress()
        {
            this.EmailAddress = $"{this.Name}@client.com";
        }

        public string Display()
        {
            return this.Name + " " + this.EmailAddress;
        }
    }
}