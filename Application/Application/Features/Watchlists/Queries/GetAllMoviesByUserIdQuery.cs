using Application.Abstracts.Persistence.Repositories.Movies;
using Application.Abstracts.Persistence.Repositories.Watchlists;
using Application.Features.Watchlists.Dtos;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Queries
{
    public class GetAllMoviesByUserIdQuery : IRequest<GetAllMoviesByUserIdQueryResponse>
    {
        public int UserId { get; set; }
        public class GetAllMoviesByUserIdQueryHandle : IRequestHandler<GetAllMoviesByUserIdQuery, GetAllMoviesByUserIdQueryResponse>
        {
            private readonly IWatchlistReadRepository _watchlistReadRepository;
            private readonly IMapper _mapper;
            public GetAllMoviesByUserIdQueryHandle(IWatchlistReadRepository watchlistReadRepository, IMapper mapper)
            {
                _watchlistReadRepository = watchlistReadRepository;
                _mapper = mapper;
            }

            public  Task<GetAllMoviesByUserIdQueryResponse> Handle(GetAllMoviesByUserIdQuery request, CancellationToken cancellationToken)
            {

                List<Watchlist> watchlists = _watchlistReadRepository.GetByUserIdWithInclude(request.UserId);

                GetAllMoviesByUserIdQueryResponse result = new();
                result.Watchlists=_mapper.Map<List<WatchlistDto>>(watchlists);

                return Task.FromResult(result);
            }
        }
    }
}
