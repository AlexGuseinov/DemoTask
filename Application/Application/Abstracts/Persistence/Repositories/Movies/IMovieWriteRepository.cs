using Application.Abstractions.Persistence.Repositories;
using Domain.Entities;

namespace Application.Abstracts.Persistence.Repositories.Movies
{
    public interface IMovieWriteRepository : IWriteRepository<Movie>
    {
    }
}
