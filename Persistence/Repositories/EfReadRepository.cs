using Application.Abstractions.Persistence.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;


namespace Persistence.Repositories
{
    public class EfReadRepository<T, TContext> : IReadRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        public EfReadRepository(TContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.Where(x => x.IsDeleted == false).ToListAsync();
        }
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public T? GetById(int id)
         => Table.Where(e => e.Id == id && e.IsDeleted == false).FirstOrDefault();
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            var query = Table.Where(e => e.IsDeleted == false).AsQueryable();

            if (include is not null)
                query = include(query);

            if (!tracking)
                query = Table.AsNoTracking();
            return await query.Where(method).FirstOrDefaultAsync();
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method).Where(e => e.IsDeleted == false);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public DbSet<T> Query()
            => Table;

    }
}
