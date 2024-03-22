using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public List<Watchlist> Watchlists { get; set; }
        public string HashCode { get; set; }
    }
}
