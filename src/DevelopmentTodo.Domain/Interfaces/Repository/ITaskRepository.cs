using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.Entities;

namespace DevelopmentTodo.Domain.Interfaces.Repository
{
    public interface ITaskRepository : IAsyncRepository<TaskEntity>
    {
        Task<IList<TaskEntity>> ListAllByProviderIdAsync(int providerId, CancellationToken cancellationToken = default);
        Task<IList<TaskEntity>> ListAllByDeveloperIdAsync(int developerId, CancellationToken cancellationToken = default);
        Task<TaskEntity> FindByIdAsync(int taskId, CancellationToken cancellationToken = default);
    }
}
