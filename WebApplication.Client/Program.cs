using System;

namespace WebApplication.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new ReservationSystem();
            system.Start();
        }
    }
}