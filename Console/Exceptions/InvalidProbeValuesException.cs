using System;
using System.Runtime.Serialization;

namespace Console.Exceptions
{
    public class InvalidProbeValuesException : Exception
    {
        public InvalidProbeValuesException()
        {
        }

        public InvalidProbeValuesException(string message) : base(message)
        {
        }

        public InvalidProbeValuesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProbeValuesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
