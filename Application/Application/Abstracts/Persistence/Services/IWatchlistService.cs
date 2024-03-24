using Application.Features.Watchlists.Dtos;

namespace Application.Abstracts.Persistence.Services
{
    public interface IWatchlistService
    {
        List<WatchlistOfferDto> GetOffers();
    }
}
