﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Watchlist : BaseEntity
    {
        //name of the film, rating, poster and short description from Wikipedia
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public List<WatchlistStatus> WatchlistStatuses { get; set; }

    }
}