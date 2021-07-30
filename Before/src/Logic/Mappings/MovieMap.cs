using FluentNHibernate.Mapping;
using Logic.Entities;

namespace Logic.Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id);

            DiscriminateSubClassesOnColumn("licensingModel");

            Map(x => x.Name);
            Map(Reveal.Member<Movie>("LicensingModel")).CustomType<int>();  //Reveal allows us to map the non-pulic fields and properties in a class.
        }
    }

    public class TwoDaysMovieMap : SubclassMap<TwoDaysMovie>
    {
        public TwoDaysMovieMap()
        {
            DiscriminatorValue(1);  //As you can see in the Enum, 1 is the value that represents the value in the TwoDaysMovie Licensing model. So when NHibernate sees a row in the movie table with the licencing model column set to one, it knows that it should instantiate a TwoDaysMovie class, and not the base class. (It would not be able to instantiate the base class anyway, as it is marked as abstract.)
        }
    }

    public class LifeLongMovieMap : SubClassPart<LifeLongMovieMap>
    {
        public LifeLongMovieMap()
        {
            DiscriminatorValue(2);
        }
    }
}
