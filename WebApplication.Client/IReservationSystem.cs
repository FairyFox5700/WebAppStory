using System;
using System.Linq;
using ConsoleTables;
using WebApplication.Entities;

namespace WebApplication.Client
{
    public interface IReservationSystemService
    {
        void DisplayAllClients();
        void DisplayAllExcursions();
        void DisplayAllGuides();
        void DisplayReservationSum(Customer client);
        void ChooseTrip(int tripId, Customer person);
    }

    public class ReservationSystemService : IReservationSystemService
    {
          private ReservationDatabase _reservationDatabase;

            public ReservationSystemService()
            {
                _reservationDatabase= ReservationDatabase.GetDatabase();
            }
            
            public void DisplayAllClients()
            {
                var rows = _reservationDatabase.Persons;
                ConsoleTable.From<Customer>(rows)
                         .Write();
            }
            
            public void DisplayAllExcursions()
            {
                var rows = _reservationDatabase.Excursions;
                ConsoleTable.From<Excursion>(rows)
                    .Write();
            }
            
            public void DisplayAllGuides()
            {
                var rows = _reservationDatabase.Guides;
                ConsoleTable.From<Guide>(rows)
                    .Write();
            }
            
            public void DisplayReservationSum(Customer client)
            {
                var reservations = _reservationDatabase.Reservations.Where(e => e.ClientId == client.Id);
                var totalReservation = new Reservation();
                foreach (var reservation in reservations)
                {
                    totalReservation += reservation;
                }
                Console.WriteLine($"ReservationSum is {totalReservation.ReservationSum}");
            }

            public void ChooseTrip(int tripId, Customer person)
            {
                var trip = _reservationDatabase.Excursions
                    .FirstOrDefault(e => e.ExcursionId == tripId);
                var reservation = new Reservation(DateTime.Now, trip.TripSum, person);
                _reservationDatabase.Reservations.Add(reservation);
            }
        }
}