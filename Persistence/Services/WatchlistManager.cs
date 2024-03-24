using Application.Abstracts.Infrastructure.Adapters.Users;
using Application.Abstracts.Persistence.Repositories.Watchlists;
using Application.Abstracts.Persistence.Services;
using Application.Features.Movies.Dtos;
using Application.Features.Watchlists.Dtos;
using AutoMapper;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class WatchlistManager : IWatchlistService
    {
        private readonly IWatchlistReadRepository _watchlistReadRepository;
        private readonly IUserAdapter _userAdapter;
        private readonly IMapper _mapper;

        public WatchlistManager(IWatchlistReadRepository watchlistReadRepository, IUserAdapter userAdapter, IMapper mapper)
        {
            _watchlistReadRepository = watchlistReadRepository;
            _userAdapter = userAdapter;
            _mapper = mapper;
        }

        public List<WatchlistOfferDto> GetOffers()
        {
            List<WatchlistOfferDto> offers = new();

            var watchlists = _watchlistReadRepository.GetMostRatedRecordEachUser();

            foreach (var item in watchlists)
            {
                WatchlistOfferDto offerToAdd = new();
                offerToAdd.Email = _userAdapter.GetEmailById(item.UserId);
                offerToAdd.Movie = _mapper.Map<MovieDto>(item.Movie);

                offers.Add(offerToAdd);
            }
            return offers;
        }
    }
}
