using FluentNHibernate.Mapping;
using Logic.Entities;

namespace Logic.Mappings;

public class PurchasedMovieMap : ClassMap<PurchasedMovie>
{
    public PurchasedMovieMap()
    {
        Id(x => x.Id);

        Map(x => x.Price);
        Map(x => x.PurchaseDate);
        Map(x => x.ExpirationDate).Nullable();
        Map(x => x.MovieId);
        Map(x => x.CustomerId);

        References(x => x.Movie).LazyLoad(Laziness.False).ReadOnly();
    }
}
