using System;
using WebApplication.Entities;

namespace WebApplication.Entities
{
    public class ReservationSumCalculation
    {

        public delegate int CalculateReservationSum(int sum);

        public static int HighReservationSum(int sum)
        {
            CheckSumIsValid(sum);
            return Convert.ToInt32(10 * sum / 100);
        }

        private static void CheckSumIsValid(int sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sum));
            }
        }
        public static int LowReservationSum(int sum)
        { CheckSumIsValid(sum);
            return Convert.ToInt32(5 * sum / 100);
        }

        public static int MidReservationSum(int sum)
        { CheckSumIsValid(sum);
            return Convert.ToInt32(7 * sum / 100);
        }

        public static CalculateReservationSum GetReservationSumFormula(Customer client)
        {
            return client.HasPrivilage switch
            {
                true => ReservationSumCalculation.LowReservationSum,
                false => ReservationSumCalculation.HighReservationSum,
                _ => ReservationSumCalculation.MidReservationSum
            };
        }
    }
}
