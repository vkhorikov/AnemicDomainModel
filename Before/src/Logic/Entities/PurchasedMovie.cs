using System;
using Newtonsoft.Json;

namespace Logic.Entities
{
    public class PurchasedMovie : Entity
    {
        [JsonIgnore]
        public virtual long MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [JsonIgnore]
        public virtual long CustomerId { get; set; }

        public virtual decimal Price { get; set; }

        public virtual DateTime PurchaseDate { get; set; }

        public virtual DateTime? ExpirationDate { get; set; }
    }
}
