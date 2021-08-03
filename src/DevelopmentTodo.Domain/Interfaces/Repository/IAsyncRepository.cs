using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.Entities.Common;

namespace DevelopmentTodo.Domain.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);
    }
}
