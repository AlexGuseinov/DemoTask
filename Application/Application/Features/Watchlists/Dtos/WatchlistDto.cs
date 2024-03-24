using Application.Features.Movies.Dtos;
using Application.Features.Statuses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Watchlists.Dtos
{
    public class WatchlistDto
    {
        public int Id { get; set; }
        public MovieDto Movie { get; set; }
        public StatusDto Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
