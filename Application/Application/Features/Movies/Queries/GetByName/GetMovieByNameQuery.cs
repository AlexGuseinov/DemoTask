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

namespace Application.Features.Movies.Queries.GetByName
{
    public class GetMovieByNameQuery : IRequest<GetMovieByNameQueryResponse>
    {
        public string Name { get; set; }

        public class GetMovieByNameQueryHandler : IRequestHandler<GetMovieByNameQuery, GetMovieByNameQueryResponse>
        {
            private readonly IMovieAdapter _movieAdapter;
            private readonly IMapper _mapper;

            public GetMovieByNameQueryHandler(IMovieAdapter movieAdapter, IMapper mapper)
            {
                _movieAdapter = movieAdapter;
                _mapper = mapper;
            }

            public async Task<GetMovieByNameQueryResponse> Handle(GetMovieByNameQuery request, CancellationToken cancellationToken)
            {
                MovieModel movieModel = await _movieAdapter.GetByName(request.Name.ToUpper());
                GetMovieByNameQueryResponse response = new();

                response.Movie = _mapper.Map<MovieDto>(movieModel);
                return response;
            }
        }
    }


}
