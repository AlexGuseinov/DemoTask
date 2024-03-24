﻿using Application.Abstractions.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstracts.Persistence.Repositories.Watchlists
{
    public interface IWatchlistWriteRepository : IWriteRepository<Watchlist>
    {
    }
}
