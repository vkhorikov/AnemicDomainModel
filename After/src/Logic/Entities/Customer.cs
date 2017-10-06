using System;
using System.Collections.Generic;

namespace Logic.Entities
{
    public class Customer : Entity
    {
        private string _name;
        public virtual CustomerName Name
        {
            get => (CustomerName)_name;
            set => _name = value;
        }

        private string _email;
        public virtual Email Email
        {
            get => (Email)_email;
            set => _email = value;
        }

        public virtual CustomerStatus Status { get; set; }

        private DateTime? _statusExpirationDate;
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

        public virtual IList<PurchasedMovie> PurchasedMovies { get; set; }
    }
}
