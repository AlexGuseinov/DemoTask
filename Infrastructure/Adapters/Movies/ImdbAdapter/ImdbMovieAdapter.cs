using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using AutoMapper;
using Infrastructure.Adapters.Movies.ImdbAdapter.Models;
using Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Adapters.Movies.ImdbAdapter
{
    //https://imdb146.p.rapidapi.com/v1/find/?query=The%20last%20of%20us
    //https://online-movie-database.p.rapidapi.com/title/v2/get-plot?tconst=tt3581920
    //https://online-movie-database.p.rapidapi.com/title/v2/get-ratings?tconst=tt3581920
    public class ImdbMovieAdapter : BaseAdapter, IMovieAdapter
    {
        private IMDBConfig _imdbConfig;
        private OnlineMovieDBConfig _onlineMovieDBConfig;
        private IHttpClientFactory _httpClientFactory;
        private IMapper _mapper;
        public ImdbMovieAdapter(IOptions<IMDBConfig> imdbConfig, IOptions<OnlineMovieDBConfig> onlineMovieDBConfig, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _imdbConfig = imdbConfig.Value;
            _onlineMovieDBConfig = onlineMovieDBConfig.Value;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }


        public async Task<MovieModel> GetByName(string name)
        {
            MovieModel movieModel;

            string url = $"{_imdbConfig.BaseUrl}/v1/find/?query={HttpUtility.UrlEncode(name)}";
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _imdbConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _imdbConfig.XRapidAPIHost);

            var httpResponse = await client.GetAsync(url);

            FindResponse response = HandleHttpResponse<FindResponse>(httpResponse,"IMDB Service");

            movieModel = _mapper.Map<MovieModel>(response);

            return movieModel;
        }


    }
}
