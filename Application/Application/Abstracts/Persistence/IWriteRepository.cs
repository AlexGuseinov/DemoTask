using Domain.Entities.Common;

namespace Application.Abstractions.Persistence.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        T Add(T model);
        List<T> AddRange(List<T> entities);
        T Update(T model);
        T SoftDelete(int id);
        T HardDelete(int id);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SoftDeleteAsync(int id);
        Task<T> HardDeleteAsync(int id);
    }
}
