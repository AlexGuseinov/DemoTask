using Application.Abstracts.Persistence.Services;
using Application.Features.Watchlists.Commands.AddToWatchlist;
using Application.Features.Watchlists.Commands.SetWatched;
using Application.Features.Watchlists.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddToWatchlistCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoivesByUserId([FromQuery] GetAllMoviesByUserIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SetMovieAsWatched([FromQuery] SetMovieAsWatchedCommand query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

    }
}
