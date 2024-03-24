using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using Application.Abstracts.Persistence.Repositories.Watchlists;
using Application.Abstracts.Persistence.Services;
using Application.CrossCuttingConcerns.Exceptions.Types;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Commands.AddToWatchlist
{
    public class AddToWatchlistCommand : IRequest<AddToWatchlistCommandResponse>
    {
        public string MovieId { get; set; }
        public int UserId { get; set; }


        public class AddToWatchListCommandHandler : IRequestHandler<AddToWatchlistCommand, AddToWatchlistCommandResponse>
        {
            private readonly IMovieAdapter _movieAdapter;
            private readonly IMapper _mapper;
            private readonly IMovieService _movieService;
            private readonly IWatchlistWriteRepository _watchlistWriteRepository;
            private readonly IWatchlistReadRepository _watchlistReadRepository;

            public AddToWatchListCommandHandler(IMovieAdapter movieAdapter, IMapper mapper, IMovieService movieService, IWatchlistWriteRepository watchlistWriteRepository, IWatchlistReadRepository watchlistReadRepository)
            {
                _movieAdapter = movieAdapter;
                _mapper = mapper;
                _movieService = movieService;
                _watchlistWriteRepository = watchlistWriteRepository;
                _watchlistReadRepository = watchlistReadRepository;
            }

            public async Task<AddToWatchlistCommandResponse> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
            {
                MovieModel movieModel = await _movieAdapter.GetById(request.MovieId);
                Movie movie = _movieService.UpdateMovieIfHaveChanges(movieModel);

                //TODO if exists film in users watchlist

                var movieInWatchlist = _watchlistReadRepository.GetAll()
                    .FirstOrDefault(a => a.UserId == request.UserId
                                && a.Movie.ImdbId == request.MovieId
                                && a.StatusId == (int)StatusEnum.UnWatched);

                if (movieInWatchlist != null)
                    throw new BusinessException("This movie already exists in user's watchlist");

                Watchlist watchlist = new Watchlist();
                watchlist.StatusId = (int)StatusEnum.UnWatched;
                watchlist.MovieId = movie.Id;
                watchlist.UserId = request.UserId;

                _watchlistWriteRepository.Add(watchlist);

                return new();
            }
        }
    }
}
