using System;

namespace WebApplication.Entities
{
    public class Guide : Person
    {
        public Guide(string name, string phoneName,  string positionName) 
            : base(name, phoneName)
        {
            PositionName = positionName;
            
            Console.WriteLine("Guide constructor was called");
        }

        public  string PositionName { get; set; }

        public Guide(string name, string phoneName) : base(name, phoneName)
        {
            this.CreateEmailAddress();
        }

        public sealed override void CreateEmailAddress()
        {
            this.EmailAddress = $"{this.Name}@guide.com";
        }
    }
}