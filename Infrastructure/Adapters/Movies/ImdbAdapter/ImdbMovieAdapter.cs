using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Movies.ImdbAdapter
{
    //https://imdb146.p.rapidapi.com/v1/find/?query=The%20last%20of%20us
    //https://online-movie-database.p.rapidapi.com/title/v2/get-plot?tconst=tt3581920
    //https://online-movie-database.p.rapidapi.com/title/v2/get-ratings?tconst=tt3581920
    public class ImdbMovieAdapter : IMovieAdapter
    {

        public MovieModel GetByName(string name)
        {
            
        }
    }
}
