using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Dtos
{
    public class MovieDto
    {
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
    }
}
