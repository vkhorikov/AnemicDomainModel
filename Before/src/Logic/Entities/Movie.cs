using Newtonsoft.Json;
using System;

namespace Logic.Entities
{
    public class Movie : Entity
    {
        public virtual string Name { get; protected set; }

        public virtual LicensingModel LicensingModel { get; protected set; }

        public virtual ExpirationDate GetExpirationDate()
        {
            switch (LicensingModel)
            {
                case LicensingModel.TwoDays:
                    return (ExpirationDate)DateTime.UtcNow.AddDays(2);

                case LicensingModel.LifeLong:
                    return ExpirationDate.Infinite;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public virtual Dollars CalculatePrice(CustomerStatus status)
        {
            decimal modifier = 1 -status.GetDiscount();
            switch (LicensingModel)
            {
                case LicensingModel.TwoDays:
                    return Dollars.Of(4) * modifier;

                case LicensingModel.LifeLong:
                    return Dollars.Of(8) * modifier;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
