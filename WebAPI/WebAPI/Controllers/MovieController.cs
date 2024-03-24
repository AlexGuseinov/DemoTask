using Application.Features.Movies.Queries.GetByName;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class MovieController:BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] GetMovieByNameQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
