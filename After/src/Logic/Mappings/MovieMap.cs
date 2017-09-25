using FluentNHibernate.Mapping;
using Logic.Entities;

namespace Logic.Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.LicensingModel).CustomType<int>();
        }
    }
}
