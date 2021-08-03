using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.Entities;

namespace DevelopmentTodo.Domain.Interfaces.Repository
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
        Task<UserEntity> FindByIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}
