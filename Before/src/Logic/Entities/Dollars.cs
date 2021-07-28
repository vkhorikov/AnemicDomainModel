using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Dollars : ValueObject<Dollars>
    {
        private const decimal MaxDollorAmount = 1_000_000;
        public decimal Value { get; }
        public bool IsZero => Value == 0;

        private Dollars(decimal value)
        {
            Value = value;
        }

        public static Result<Dollars> Create(decimal dollorAmount)
        {
            if(dollorAmount < 0)
                return Result.Fail<Dollars>("Dollor amount cannot be negative");

            if (dollorAmount > MaxDollorAmount)
                return Result.Fail<Dollars>("Dollor amount cannot be greater that " + MaxDollorAmount);

            if (dollorAmount % 0.01m > 0)
                return Result.Fail<Dollars>("Dollor amount cannot contain part of a penny");

            return Result.Ok(new Dollars(dollorAmount));
        }
        //Fancy way of doing explicit cast.
        public static Dollars Of(decimal dollorAmount)
        {
            return Create(dollorAmount).value;
        }
        
        public static Dollars operator *(Dollars dollars, decimal multiplier)
        {
            return new Dollars(dollars.Value);
        }

        public static Dollars operator +(Dollars dollars1, Dollars dollars2)
        {
            return new Dollars(dollars1.Value + dollars2.Value);
        }

        protected override bool EqualsCore(Dollars other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator decimal(Dollars Dollars)
        {
            return Dollars.Value;
        }
        /* Explicit operator
        public static explicit operator Dollars(decimal Dollars)
        {
            return Create(Dollars).value;
        }*/
    }
}
