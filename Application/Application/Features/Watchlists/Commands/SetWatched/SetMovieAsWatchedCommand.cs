using Application.Abstracts.Persistence.Repositories.Watchlists;
using Application.CrossCuttingConcerns.Exceptions.Types;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Commands.SetWatched
{
    public class SetMovieAsWatchedCommand :IRequest<SetMovieAsWatchedCommandResponse>
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public class SetMovieAsWatchedCommandHandler : IRequestHandler<SetMovieAsWatchedCommand, SetMovieAsWatchedCommandResponse>
        {
            private readonly IWatchlistWriteRepository _watchlistWriteRepository;
            private readonly IWatchlistReadRepository _watchlistReadRepository;
            public SetMovieAsWatchedCommandHandler(IWatchlistWriteRepository watchlistWriteRepository, IWatchlistReadRepository watchlistReadRepository)
            {
                _watchlistWriteRepository = watchlistWriteRepository;
                _watchlistReadRepository = watchlistReadRepository;
            }

            public Task<SetMovieAsWatchedCommandResponse> Handle(SetMovieAsWatchedCommand request, CancellationToken cancellationToken)
            {
                var movie = _watchlistReadRepository.GetAll()
                    .FirstOrDefault(c => c.UserId == request.UserId && c.Movie.ImdbId == request.MovieId);

                if (movie is null)
                    throw new BusinessException("No such movie in watchlist");

                if (movie.StatusId == (int)StatusEnum.Watched)
                    throw new BusinessException($"Movie already marked as '{StatusEnum.Watched.ToString()}'");

                movie.StatusId =(int) StatusEnum.Watched;
                _watchlistWriteRepository.Update(movie);
    
                return Task.FromResult(new SetMovieAsWatchedCommandResponse());
            }
        }
    }
}
