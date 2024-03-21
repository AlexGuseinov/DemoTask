using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



namespace Application.Abstractions.Persistence.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, Func<IQueryable<T>, IQueryable<T>> include = null);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        T? GetById(int id);
        DbSet<T> Query();

    }
}
