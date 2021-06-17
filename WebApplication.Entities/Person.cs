using System;
using System.Collections.Generic;
using System.Data;

namespace WebApplication.Entities
{
    public abstract class Person
    {
        private static  int _counter =0;
        protected Person(string name, string phoneName)
        {
            Id = _counter++;
            Name = name;
            PhoneName = phoneName;
            Console.WriteLine("Person constructor was called");
        }

        public int Id { get; set; }
        protected string Name { get; set; }
        protected string PhoneName   { get; set; }
        protected string EmailAddress { get; set; }
        public abstract void CreateEmailAddress();

    }

  

 



 



  
    

  
}