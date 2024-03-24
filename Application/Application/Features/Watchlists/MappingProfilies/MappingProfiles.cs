using Application.Features.Watchlists.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.MappingProfilies
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Watchlist, WatchlistDto>();
        }
    }
}
