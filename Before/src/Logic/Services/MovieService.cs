using System;
using Logic.Entities;

namespace Logic.Services
{
    public class MovieService
    {
        public ExpirationDate GetExpirationDate(LicensingModel licensingModel)
        {
            ExpirationDate result;

            switch (licensingModel)
            {
                case LicensingModel.TwoDays:
                    result = (ExpirationDate)DateTime.UtcNow.AddDays(2);
                    break;

                case LicensingModel.LifeLong:
                    result = ExpirationDate.Infinite;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }
    }
}
