using System;

namespace WebApplication.Entities
{
    public class Reservation
    {
        private static  int _counter =0;

        public Reservation()
        {
            ReservationId = _counter++;
            Console.WriteLine("Reservation was created");
        }
        public Reservation( DateTime reservationDate,  int tripSum,Customer client):this()
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            ReservationDate = reservationDate;
            ReservationSum = CalculateReservationSum(tripSum);
            ClientId = client.Id;
            Client = client;
            Console.WriteLine("Reservation was created");
        }

        private int CalculateReservationSum(int sum)
        {
            var method =ReservationSumCalculation.GetReservationSumFormula(this.Client);
            return method(sum);
        }
        #region oprators_overloading
        public static Reservation operator +(Reservation c)
        {
            Reservation temp = new Reservation();
            temp.ReservationSum = +c.ReservationSum;
            return temp;
        }
        public static Reservation operator -(Reservation c)
        {
            Reservation temp = new Reservation();
            temp.ReservationSum = -c.ReservationSum;
            return temp;
        }
        public static Reservation operator +(Reservation c1, Reservation c2)
        {
            Reservation  temp = new Reservation();
            temp.ReservationSum = c1.ReservationSum + c2.ReservationSum;
            return temp;
        }
        public static Reservation operator -(Reservation c1, Reservation c2)
        {
            Reservation  temp = new Reservation();
            temp.ReservationSum = c1.ReservationSum- c2.ReservationSum;
            return temp;
        }
        #endregion

        public int  ReservationId { get; set; }
        private DateTime ReservationDate { get; set; }
        public int ReservationSum { get; set; }
        public  int ClientId { get; set; }
        private Customer Client { get; set; }
        private Excursion Excursion{ get; set; }
    }
}