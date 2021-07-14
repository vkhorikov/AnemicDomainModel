using FluentNHibernate.Mapping;
using Logic.Entities;
using System;

namespace Logic.Mappings
{
    public class PurchasedMovieMap : ClassMap<PurchasedMovie>
    {
        public PurchasedMovieMap()
        {
            Id(x => x.Id);

            Map(x => x.Price).CustomType<decimal>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.PurchaseDate);
            Map(x => x.ExpirationDate).Nullable().CustomType<DateTime?>().Access.CamelCaseField(Prefix.Underscore).Nullable();
            Map(x => x.MovieId);
            Map(x => x.CustomerId);

            References(x => x.Movie).LazyLoad(Laziness.False).ReadOnly();
        }
    }
}
