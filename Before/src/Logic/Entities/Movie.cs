using Newtonsoft.Json;
using System;

namespace Logic.Entities
{
    public abstract class Movie : Entity
    {
        public virtual string Name { get; protected set; }
        protected virtual LicensingModel LicensingModel { get; protected set; }

        public abstract ExpirationDate GetExpirationDate();
        public virtual Dollars CalculatePrice(CustomerStatus status)
        {
            decimal modifier = 1 -status.GetDiscount();
            return GetBasePrice() * modifier;
        }

        protected abstract Dollars GetBasePrice();
    }
    
    public class TwoDaysMovie : Movie
    {
        public override Dollars GetBasePrice()
        {
            return Dollars.Of(4);
        }

        public override ExpirationDate GetExpirationDate()
        {
            return (ExpirationDate)DateTime.UtcNow.AddDays(2);
        }
    }

    public class LifeLingMovie : Movie
    {
        public override Dollars GetBasePrice()
        {
            return Dollars.Of(8);
        }

        public override ExpirationDate GetExpirationDate()
        {
            return ExpirationDate.Infinite;
        }
    }
}
