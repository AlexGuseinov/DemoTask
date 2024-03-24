using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Persistence.Services
{
    public interface IMovieService
    {
        Movie UpdateMovieIfHaveChanges(MovieModel movie);
    }
}
