using Application.Abstractions.Persistence.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EfWriteRepository<T, TContext> : IWriteRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        public EfWriteRepository(TContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }
        public List<T> AddRange(List<T> entities)
        {    
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
         
            return entities;
        }
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }



        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public T HardDelete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
            return entity;
        }



        public async Task<T> HardDeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public T SoftDelete(int id)
        {
            T entity = _context.Set<T>().Where(e => e.IsDeleted == false).FirstOrDefault();
            entity.IsDeleted = true;
            return Update(entity);
        }

        public async Task<T> SoftDeleteAsync(int id)
        {
            T entity = await _context.Set<T>().Where(e => e.IsDeleted == false).FirstOrDefaultAsync();
            entity.IsDeleted = true;
            return await UpdateAsync(entity);
        }


    }
}
