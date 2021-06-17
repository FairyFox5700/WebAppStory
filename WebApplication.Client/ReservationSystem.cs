using System;
using WebApplication.Client;
using WebApplication.Client.EventsAndDelegates;
using WebApplication.Entities;

namespace WebApplication.Client
{
    public class ReservationSystem
    {
        private  IReservationSystemService _reservationSystemService;
        private Person _client;
        public ReservationSystem()
        {
            Console.WriteLine($"{nameof(ReservationSystem)} was called ");
        }

        public void Start()
        {
            var keyboard = new Keyboard();
            Console.WriteLine("Write your name");
            var name = Console.ReadLine();      
            Console.WriteLine("Write your phone");
            var phone = Console.ReadLine();
            _client = new Customer(name,phone);
            var args = new KeyboadEventArgs("Start",this);
            Console.WriteLine($"AVAILABLE COMMANDS:  SUM_TO_PAY, EXIT, GUIDES, TRIPS, START");
            keyboard.Start(args);
        }

        public Person GetClient()
        {
            //uppercast
            return this._client;
        }

        public IReservationSystemService GetReservationService()
        {
            if (_reservationSystemService == null)
            {
                _reservationSystemService = new ReservationSystemService();
            }

            return _reservationSystemService;
        }
    }
}