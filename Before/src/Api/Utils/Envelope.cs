using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Envelope<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }
        //Can add more fields to this class.

        protected internal Envelope(T restult, string errorMessage)
        {
            Result = restult;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public class Envelope : Envelope<string>
    {
        protected Envelope (string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}
