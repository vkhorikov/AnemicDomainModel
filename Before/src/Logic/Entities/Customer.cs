using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Logic.Entities
{
    public class Customer : Entity
    {
        private string _name;
        public virtual CustomerName Name
        {
            get => (CustomerName)_name; //explicit conversion used here
            set => _name = value;   //implicit conversion used here

        }
        private string _email;
        public virtual Email Email 
        {
            get => (Email)_email;
            set => _email = value;
        }
        public virtual CustomerStatus Status { get; set; }
        public ExpirationDate _statusExpirationDate;
        public virtual ExpirationDate StatusExpirationDate
        {
            get => (ExpirationDate)_statusExpirationDate;
            set => _statusExpirationDate = value;
        }
        private decimal _moneySpent;
        public virtual Dollars MoneySpent
        {
            get => Dollars.Of(_moneySpent);
            set => _moneySpent = value;
        }
        private readonly IList<PurchasedMovie> _purchasedMovies;
        public virtual IReadOnlyList<PurchasedMovie> PurchasedMovies => _purchasedMovies.ToList();

        //ORMs require a parameterless contructor on all mapped classes. Client code does not use this constuctor.
        protected Customer()
        {
            _purchasedMovies = new List<PurchasedMovie>();
        }

        public Customer(CustomerName name, Email email) : this()
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _email = email ?? throw new ArgumentNullException(nameof(email));

            MoneySpent = Dollars.Of(0);
            Status = CustomerStatus.Regular;
            StatusExpirationDate = null;
        }

        //Here is how the client can add movies. This is better than breaking encapsulation by exposing the collection.
        //Always introduce a raed-only public collection, in top of a private mutable one.
        public virtual void AddPurchasedMovie(Movie movie, ExpirationDate expirationDate, Dollars price)
        {
            var purchasedMovie = new PurchasedMovie
            {
                MovieId = movie.Id,
                CustomerId = Id,
                ExpirationDate = expirationDate,
                Price = price,
                PurchaseDate = DateTime.UtcNow
            };
            _purchasedMovies.Add(purchasedMovie);
            MoneySpent += price;
        }
    }
}
