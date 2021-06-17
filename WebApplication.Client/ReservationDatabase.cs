using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Client
{
    public class ReservationDatabase
    {
        private static ReservationDatabase _instance;
 
        protected ReservationDatabase()
        {
            var guide1 = new Guide("Name1", "121212");
            var guide2 = new Guide("Name2", "121214");
            this.Guides = new List<Guide>()
            {
                guide1, guide2,
            };
            var excursion1 = new Excursion("Monday", guide1, 34, 2);
            var excursion2 = new Excursion("Thusday", guide2, 500, 2);
            this.Excursions = new List<Excursion>()
            {
                excursion1,excursion2,
            };
            var person1 = new Customer("Dima", "121213", false);
            var person2 = new Customer("Stas", "125214", true);
            this.Reservations = new List<Reservation>();
            this.Persons = new List<Customer>()
            {
                person1, person2
            };
        }
 
        public static ReservationDatabase GetDatabase()
        {
            return _instance ??= new ReservationDatabase();
        }
    
        public  List<Excursion> Excursions { get; set; }
        public  List<Guide> Guides { get; set; }
        public  List<Customer> Persons { get; set; }
        public  List<Reservation> Reservations { get; set; }
    }
}