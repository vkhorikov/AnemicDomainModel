using System;

namespace Logic.Dtos
{
    public class PurchasedMovieDto
    {
        public MovieDto Movie { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}