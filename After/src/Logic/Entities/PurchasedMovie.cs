using System;
using Newtonsoft.Json;

namespace Logic.Entities
{
    public class PurchasedMovie : Entity
    {
        public virtual Movie Movie { get; protected set; }
        public virtual Customer Customer { get; protected set; }

        private decimal _price;
        public virtual Dollars Price
        {
            get => Dollars.Of(_price);
            protected set => _price = value;
        }

        public virtual DateTime PurchaseDate { get; protected set; }

        private DateTime? _expirationDate;
        public virtual ExpirationDate ExpirationDate
        {
            get => (ExpirationDate)_expirationDate;
            protected set => _expirationDate = value;
        }

        protected PurchasedMovie()
        {
        }

        internal PurchasedMovie(Movie movie, Customer customer, Dollars price, ExpirationDate expirationDate)
        {
            if (price == null || price.IsZero)
                throw new ArgumentException(nameof(price));
            if (expirationDate == null || expirationDate.IsExpired)
                throw new ArgumentException(nameof(expirationDate));

            Movie = movie ?? throw new ArgumentNullException(nameof(movie));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Price = price;
            ExpirationDate = expirationDate;
            PurchaseDate = DateTime.UtcNow;
        }
    }
}
