using System.Collections.Generic;
using System.Linq;
using Logic.Common;
using Logic.Utils;

namespace Logic.Movies
{
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IReadOnlyList<Movie> GetList()
        {
            return _unitOfWork.Query<Movie>().ToList();
        }
    }
}
