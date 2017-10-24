using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Logic.Movies
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id);

            DiscriminateSubClassesOnColumn("LicensingModel");

            Map(x => x.Name);
            Map(Reveal.Member<Movie>("LicensingModel")).CustomType<int>();
        }
    }

    public class TwoDaysMovieMap : SubclassMap<TwoDaysMovie>
    {
        public TwoDaysMovieMap()
        {
            DiscriminatorValue(1);
        }
    }

    public class LifeLongMovieMap : SubclassMap<LifeLongMovie>
    {
        public LifeLongMovieMap()
        {
            DiscriminatorValue(2);
        }
    }
}
