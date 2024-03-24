using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using AutoMapper;
using Infrastructure.Adapters.Movies.ImdbAdapter.Models.ImdbResponses;
using Infrastructure.Adapters.Movies.ImdbAdapter.Models.OnlineMovieRatingResponse;
using Infrastructure.Adapters.Movies.ImdbAdapter.Models.OnlneMovieResponses;
using Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Infrastructure.Adapters.Movies.ImdbAdapter
{
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
            movieModel.Description = await GetPlotById(response.TitleResults.Results[0].Id);
            movieModel.Rating = await GetRatingById(response.TitleResults.Results[0].Id);
            return movieModel;
        }

        public async Task<MovieModel> GetById(string id)
        {
            MovieModel movieModel = new()
            {
                Id = id,
                Name = await GetNameById(id),
                Description = await GetPlotById(id),
                Rating = await GetRatingById(id),
                Poster = await GetPosterById(id),
            };
            return movieModel;

        }

        private async Task<string> GetPlotById(string id)
        {

            string url = $"{_onlineMovieDBConfig.BaseUrl}/title/v2/get-plot?tconst={HttpUtility.UrlEncode(id)}";
            var client  = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _onlineMovieDBConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _onlineMovieDBConfig.XRapidAPIHost);

            var httpResponse = await client.GetAsync(url);

            OnlineMoviePlotModel response = HandleHttpResponse<OnlineMoviePlotModel>(httpResponse, "Online Movie Service");

            string result = response.data.title.plot.plotText.plainText;
            return result;
        }
        private async Task<double> GetRatingById(string id)
        {
            string url = $"{_onlineMovieDBConfig.BaseUrl}/title/v2/get-ratings?tconst={HttpUtility.UrlEncode(id)}";
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _onlineMovieDBConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _onlineMovieDBConfig.XRapidAPIHost);

            var httpResponse = await client.GetAsync(url);

            OnlineMovieRatingModel response = HandleHttpResponse<OnlineMovieRatingModel>(httpResponse, "Online Movie Service");
            double result = response.data.title.ratingsSummary.aggregateRating;
            return result;
        }
        private async Task<string> GetPosterById(string id)
        {
            string url = $"{_onlineMovieDBConfig.BaseUrl}/title/v2/get-ratings?tconst={HttpUtility.UrlEncode(id)}";
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _onlineMovieDBConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _onlineMovieDBConfig.XRapidAPIHost);

            var httpResponse = await client.GetAsync(url);

            OnlineMovieRatingModel response = HandleHttpResponse<OnlineMovieRatingModel>(httpResponse, "Online Movie Service");
            string result = response.data.title.primaryImage.url;
            return result;
        }
        private async Task<string> GetNameById(string id)
        {
            string url = $"{_onlineMovieDBConfig.BaseUrl}/title/v2/get-ratings?tconst={HttpUtility.UrlEncode(id)}";
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _onlineMovieDBConfig.XRapidAPIKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", _onlineMovieDBConfig.XRapidAPIHost);

            var httpResponse = await client.GetAsync(url);

            OnlineMovieRatingModel response = HandleHttpResponse<OnlineMovieRatingModel>(httpResponse, "Online Movie Service");
            string result = response.data.title.titleText.text;
            return result;
        }

        
   
    }
}
