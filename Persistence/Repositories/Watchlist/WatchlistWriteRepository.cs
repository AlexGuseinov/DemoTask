using Application.Abstracts.Persistence.Repositories.Watchlists;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WatchlistWriteRepository : EfWriteRepository<Watchlist, ApplicationContext>, IWatchlistWriteRepository
    {
        public WatchlistWriteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
