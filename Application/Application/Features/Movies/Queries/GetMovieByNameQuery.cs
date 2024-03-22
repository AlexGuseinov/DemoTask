using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using Application.Features.Movies.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Queries
{
    public class GetMovieByNameQuery : IRequest<GetByMovieByNameQueryResponse>
    {
        public string Name { get; set; }

        public class GetMovieByNameQueryHandler : IRequestHandler<GetMovieByNameQuery, GetByMovieByNameQueryResponse>
        {
            private readonly IMovieAdapter _movieAdapter;
            private readonly IMapper _mapper;

            public GetMovieByNameQueryHandler(IMovieAdapter movieAdapter, IMapper mapper)
            {
                _movieAdapter = movieAdapter;
                _mapper = mapper;
            }

            public Task<GetByMovieByNameQueryResponse> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
            {
                MovieModel movieModel = _movieAdapter.GetByName(request.Name);

                GetByMovieByNameQueryResponse response = new();

                response.Movie = _mapper.Map<MovieDto>(movieModel);

                return Task.FromResult(response);
            }
        }
    }


}
