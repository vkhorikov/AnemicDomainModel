using System;
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
        private readonly string _email;
        public virtual Email Email => (Email)_email;
        

        public virtual CustomerStatus Status { get; protected set; }
       
        private decimal _moneySpent;
        public virtual Dollars MoneySpent
        {
            get => Dollars.Of(_moneySpent);
            protected set => _moneySpent = value;
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
        }

        //Here is how the client can add movies. This is better than breaking encapsulation by exposing the collection.
        //Always introduce a raed-only public collection, in top of a private mutable one.
        
        //Good to seperate the check and the actual operation in seperate methods in the domain class, as is done here. 
        //That way you adhere to the Command-query seperation principle(CQS) => any method either returns a value, or mutates the state. Never both. This is not always possible to adhere to. For instance, when the operation must occur immediately after the check.
        public virtual bool HasPurchasedMovie(Movie movie)
        {
            return PurchasedMovies.Any(x => x.Movie == movie && !x.ExpirationDate.IsExpired);
        }
        public virtual void PurchasedMovie(Movie movie)
        {
            if (HasPurchasedMovie(movie))
                throw new Exception();

            ExpirationDate expirationDate = movie.GetExpirationDate();
            Dollars price = movie.CalculatePrice(Status);

            var purchasedMovie = new PurchasedMovie(movie, this, price, expirationDate);
            _purchasedMovies.Add(purchasedMovie);
            MoneySpent += price;
        }

        public virtual Result CanPromote()
        {
            if (Status.IsAdvanced)
                return Result.Fail("The customer already has the Advanced status");

            if (PurchasedMovies.Count(x =>
            x.ExpirationDate == ExpirationDate.Infinite || x.ExpirationDate.Date >= DateTime.UtcNow.AddDays(-30)) < 2)
                return Result.Fail("The customer has to have at least 2 active movies during the last 30 days");

            if (PurchasedMovies.Where(x => x.PurchaseDate > DateTime.UtcNow.AddYears(-1)).Sum(x => x.Price) < 100m)
                return Result.Fail("The customer has to have had at least 100 dollars spent during the last year");

            return Result.Ok();
        }

        public virtual void Promote()
        {
            if (CanPromote().IsFailure)
                throw new Exception();

            Status = Status.Promote();
        }
    }
}
