using System;
using System.Runtime.Serialization;

namespace Console.Exceptions
{
    public class InvalidPlatformMaxPositionException : Exception
    {
        public InvalidPlatformMaxPositionException()
        {
        }

        public InvalidPlatformMaxPositionException(string message) : base(message)
        {
        }

        public InvalidPlatformMaxPositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPlatformMaxPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
