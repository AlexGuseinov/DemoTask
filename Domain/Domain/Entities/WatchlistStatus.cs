using Domain.Entities.Common;

namespace Domain.Entities
{
    public class WatchlistStatus : BaseEntity
    {
        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }
        public int StatusId { get; set; }
        public Status status { get; set; }
    }
}
