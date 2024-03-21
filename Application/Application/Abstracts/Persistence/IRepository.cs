
using Domain.Entities.Common;

namespace Application.Abstractions.Persistence.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
}
