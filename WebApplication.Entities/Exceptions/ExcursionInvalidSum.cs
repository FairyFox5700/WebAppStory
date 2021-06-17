using System;
using System.Runtime.Serialization;

namespace WebApplication.Entities.Exceptions
{
    
    [Serializable]
    public class ExcursionInvalidSum:Exception
    {
        private static string _message = "Invalid excursion sum";
        public ExcursionInvalidSum()
        {
            
        }

        protected ExcursionInvalidSum(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ExcursionInvalidSum(string? message) : base(_message)
        {
        }

        public ExcursionInvalidSum(string? message, Exception? innerException) : base(_message, innerException)
        {
        }
    }
}