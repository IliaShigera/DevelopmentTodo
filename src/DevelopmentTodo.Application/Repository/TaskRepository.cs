using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.DAL.EF;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentTodo.Application.Repository
{
    public class TaskRepository : EFBaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public async Task<IList<TaskEntity>> ListAllByProviderIdAsync(int providerId, CancellationToken cancellationToken = default)
        {
            var query = _context.Tasks;

            await query.AsNoTracking().FirstOrDefaultAsync(t => t.ProviderId.Equals(providerId), cancellationToken);

            var taskEntityList = await query.ToListAsync(cancellationToken);
            return taskEntityList;
        }

        public async Task<IList<TaskEntity>> ListAllByDeveloperIdAsync(int developerId, CancellationToken cancellationToken = default)
        {
            var query = _context.Tasks;

            await query.AsNoTracking().FirstOrDefaultAsync(t => t.ProviderId.Equals(developerId), cancellationToken);

            var taskEntityList = await query.ToListAsync(cancellationToken);
            return taskEntityList;
        }

        public async Task<TaskEntity> FindByIdAsync(int taskId, CancellationToken cancellationToken = default)
        {
            var taskEntity = await _context.Tasks.FirstOrDefaultAsync(t => t.Id.Equals(taskId), cancellationToken);
            return taskEntity;
        }
    }
}
