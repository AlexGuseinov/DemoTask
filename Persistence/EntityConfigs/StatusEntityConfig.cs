using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs
{
    public class StatusEntityConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Statuses");
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasData(StatusSeeder.GetSeeders());
        }
    }

}
