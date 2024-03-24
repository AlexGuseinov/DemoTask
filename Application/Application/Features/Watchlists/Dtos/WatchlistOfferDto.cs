using Application.Features.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Dtos
{
    public class WatchlistOfferDto
    {
        public string Email { get; set; }
        public MovieDto Movie { get; set; }
    }
}
