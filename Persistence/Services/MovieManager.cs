
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using Application.Abstracts.Persistence.Repositories.Movies;
using Application.Abstracts.Persistence.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieReadRepository _movieReadRepository;
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly IMapper _mapper;
        public MovieManager(IMovieReadRepository movieReadRepository, IMovieWriteRepository movieWriteRepository, IMapper mapper)
        {
            _movieReadRepository = movieReadRepository;
            _movieWriteRepository = movieWriteRepository;
            _mapper = mapper;
        }

        public Movie UpdateMovieIfHaveChanges(MovieModel movieModel)
        {
            Movie finded = _movieReadRepository.GetWhere(m => m.ImdbId == movieModel.Id).FirstOrDefault();

            if (finded is null)
            {
                Movie movieToAdd = _mapper.Map<Movie>(movieModel);
                movieToAdd.HashCode = movieModel.GenerateHash();
                Movie added = _movieWriteRepository.Add(movieToAdd);
                return added;
            }

            if (finded.HashCode != movieModel.GenerateHash())
            {
                finded = _mapper.Map<MovieModel, Movie>(movieModel, finded);
                finded.HashCode = movieModel.GenerateHash();
                Movie updated = _movieWriteRepository.Update(finded);
                return updated;
            }

            return finded;


        }
    }
}
