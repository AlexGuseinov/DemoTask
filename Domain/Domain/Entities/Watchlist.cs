using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Watchlist : BaseEntity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }
}
