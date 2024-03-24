using Application.Abstracts.Persistence.Repositories.Movies;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.Movies
{
    public class MovieWriteRepository : EfWriteRepository<Movie, ApplicationContext>, IMovieWriteRepository
    {
        public MovieWriteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
