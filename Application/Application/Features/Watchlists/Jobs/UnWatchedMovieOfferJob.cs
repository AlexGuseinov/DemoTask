using Application.Abstracts.Persistence.Services;
using MailService;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Jobs
{
    public class UnWatchedMovieOfferJob : IJob
    {
        private readonly IWatchlistService _watchlistService;
        private readonly IMailService _mailService;
        public UnWatchedMovieOfferJob(IWatchlistService watchlistService, IMailService mailService)
        {
            _watchlistService = watchlistService;
            _mailService = mailService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var offers = _watchlistService.GetOffers();

            string bodyPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "offer-body.html");
            string bodyTemplate = File.ReadAllText(bodyPath);

            foreach (var offer in offers)
            {
                string body = bodyTemplate;
                body = body.Replace("{{name}}", offer.Movie.Name);
                body = body.Replace("{{img}}", offer.Movie.Poster);
                body = body.Replace("{{rating}}", offer.Movie.Rating.ToString());
                body = body.Replace("{{desc}}", offer.Movie.Description);

                _mailService.Send(
                    title: "Movie offer",
                    body: body,
                    tos: new List<string>() { offer.Email }
                    );
            }

            return Task.CompletedTask;

        }
    }
}
