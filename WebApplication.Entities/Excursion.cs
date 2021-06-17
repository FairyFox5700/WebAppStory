using System;
using WebApplication.Entities.Exceptions;

namespace WebApplication.Entities
{
    public class Excursion
    {
        private static int _counter = 0;
        public Excursion(string tripStart,  Guide guide, int sum, int maxPeopleCount)
        {
            ExcursionId = _counter++;
            TripStart = tripStart;
            GuideId = guide.Id;
            Guide = guide;
            TripSum = sum;
            MaxPeopleCount = maxPeopleCount;
            Console.WriteLine("Excursion constructor was called");
        }


        public int GuideId
        {
            get => _guideId;
            set => _guideId = value;
        }

        public string TripStart
        {
            get => _tripStart;
            set => _tripStart = value;
        }

        public int ExcursionId { get; set; }
        private string _tripStart;
        private int _guideId;
        private Guide Guide { get; set; }
        private  int _tripSum { get; set; }

        public int TripSum
        {
            get=>_tripSum;
            set
            {
                if (value > 0)
                {
                    _tripSum = value;
                }
                else
                {
                    throw new ExcursionInvalidSum();
                }
            }
        }
        private int MaxPeopleCount { get; set; }
    }
}