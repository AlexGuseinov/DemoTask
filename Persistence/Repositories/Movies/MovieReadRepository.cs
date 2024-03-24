using Application.Abstracts.Persistence.Repositories.Movies;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Movies
{
    public class MovieReadRepository : EfReadRepository<Movie, ApplicationContext>, IMovieReadRepository
    {
        public MovieReadRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
