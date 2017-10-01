using System;
using System.Collections.Generic;

namespace Logic.Entities
{
    public class Customer : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual CustomerStatus Status { get; set; }
        public virtual DateTime? StatusExpirationDate { get; set; }
        public virtual decimal MoneySpent { get; set; }
        public virtual IList<PurchasedMovie> PurchasedMovies { get; set; }
    }
}
