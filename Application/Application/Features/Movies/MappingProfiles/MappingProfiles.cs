using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using Application.Features.Movies.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.MappingProfiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie,MovieDto>().ReverseMap();
            CreateMap<MovieModel, MovieDto>().ReverseMap();
        }
    }
}
