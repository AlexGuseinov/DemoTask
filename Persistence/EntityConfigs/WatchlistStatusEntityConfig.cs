using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class WatchlistStatusEntityConfig : IEntityTypeConfiguration<WatchlistStatus>
    {
        public void Configure(EntityTypeBuilder<WatchlistStatus> builder)
        {
            builder.ToTable("WatchlistStatuses");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasOne(x => x.Watchlist).WithMany(wl => wl.WatchlistStatuses).HasForeignKey(fr => fr.WatchlistId);
            builder.HasOne(x => x.status).WithMany(wl => wl.WatchlistStatuses).HasForeignKey(fr => fr.StatusId);
        }
    }

}
