using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.DAL.EF;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentTodo.Application.Repository
{
    public class UserRepository : EFBaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<UserEntity> FindByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);
            return userEntity;
        }
    }
}
