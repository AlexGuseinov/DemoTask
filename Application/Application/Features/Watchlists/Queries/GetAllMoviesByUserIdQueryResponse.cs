using Application.Features.Watchlists.Dtos;

namespace Application.Features.Watchlists.Queries
{
    public class GetAllMoviesByUserIdQueryResponse
    {
        public List<WatchlistDto> Watchlists { get; set; }
    }
}
