using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.DAL.EF;
using DevelopmentTodo.Domain.Entities.Common;
using DevelopmentTodo.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentTodo.Application.Repository
{
    public class EFBaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected DataContext _context;

        public EFBaseRepository(DataContext context) => _context = context;

        public async Task<IList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
