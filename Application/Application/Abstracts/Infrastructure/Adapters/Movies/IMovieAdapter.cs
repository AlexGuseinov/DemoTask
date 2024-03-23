using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Infrastructure.Adapters.Movies
{
    public interface IMovieAdapter
    {
        Task<MovieModel> GetByName(string name);
        Task<MovieModel> GetById(string id);
    }
}
