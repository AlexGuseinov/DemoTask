using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstracts.Persistence.Repositories.Watchlists;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class WatchlistReadRepository : EfReadRepository<Watchlist, ApplicationContext>, IWatchlistReadRepository
    {
        public WatchlistReadRepository(ApplicationContext context) : base(context)
        {
        }

        public List<Watchlist> GetByUserIdWithInclude(int id)
        {
            return Query().Where(w => w.UserId == id)
                        .Include(w => w.Status)
                        .Include(w => w.Movie)
                        .ToList();
        }

        public List<Watchlist?> GetMostRatedRecordEachUser()
        {
            return Query()
                    .Include(w => w.Movie)
                    .Where(w => w.StatusId == (int)StatusEnum.UnWatched)
                    .GroupBy(w => w.UserId)
                    .Where(grp => grp.Count() >= 2)
                    .Select(grp => grp.OrderByDescending(w => w.Movie.Rating).FirstOrDefault())
                    .ToList();
        }
    }
}
