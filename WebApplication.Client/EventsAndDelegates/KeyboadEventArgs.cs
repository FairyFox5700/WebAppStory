using WebApplication.Entities;

namespace WebApplication.Client.EventsAndDelegates
{
    public class KeyboadEventArgs
    {   
        public KeyboadEventArgs(string message,  ReservationSystem system)
        {
            Message = message;
            ReservationSystem = system;
        }
        public  string Message{get;}
        public ReservationSystem ReservationSystem { get; set; }
        
    }
}