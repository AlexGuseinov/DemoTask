using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<WatchlistStatus> WatchlistStatuses { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            AddTimestampsAndInitDatas();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestampsAndInitDatas();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void AddTimestampsAndInitDatas()
        {
            var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));


            var currentDate = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreateDate = currentDate;
                    ((BaseEntity)entry.Entity).IsDeleted = false;

                }
                else if (entry.State == EntityState.Modified)
                    ((BaseEntity)entry.Entity).UpdateDate = currentDate;
            }
        }
    }
}
