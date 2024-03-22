using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public List<WatchlistStatus> WatchlistStatuses { get; set; }

    }
}
