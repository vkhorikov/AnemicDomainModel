using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ExpirationDate : ValueObject<ExpirationDate>
    {
        public DateTime? Date { get; }

        public static readonly ExpirationDate Infinite = new ExpirationDate(null);  //Instead of using a null value for an expiration date that never expires: We create this field, that better conveys the meaning.

        public bool IsExpired => this != Infinite && Date < DateTime.UtcNow;  //This enables us to prevent duplication of domain knowledge.
        private ExpirationDate(DateTime? date)
        {
            Date = date;
        }

        public static Result<ExpirationDate> Create(DateTime date)
        {
            return Result.Ok(new ExpirationDate(date));
        }
        protected override bool EqualsCore(ExpirationDate other)
        {
            return Date == other.Date;
        }

        protected override int GetHashCodeCore()
        {
            return Date.GetHashCode();
        }

        public static explicit operator ExpirationDate(DateTime? date)
        {
            if (date.HasValue)
                return Create(date.Value).value;

            return Infinite;
        }
        public static implicit operator DateTime? (ExpirationDate date)
        {
            return date.Date;
        }
    }
}
