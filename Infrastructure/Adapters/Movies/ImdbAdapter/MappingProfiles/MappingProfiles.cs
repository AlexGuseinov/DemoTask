using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using AutoMapper;
using Infrastructure.Adapters.Movies.ImdbAdapter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Movies.ImdbAdapter.MappingProfiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<FindResponse, MovieModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.TitleResults.Results.FirstOrDefault().Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.TitleResults.Results.FirstOrDefault().TitleNameText))
                .ForMember(d => d.Poster, opt => opt.MapFrom(s => s.TitleResults.Results.FirstOrDefault().TitlePosterImageModel.Url));
        }
    }
}
