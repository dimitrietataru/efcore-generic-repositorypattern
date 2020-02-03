using EFCore.RepositoryPattern.Generics.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Generics.Abstractions
{
    public abstract class AbstractRepository<TEntity> : IAbstractRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext dbContext;

        public AbstractRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().Add(entity);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task CreateBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().AddRange(entities);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().Update(entity);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task UpdateBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().UpdateRange(entities);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task DeleteBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
            await SaveAsync(cancellationToken);
        }

        public virtual async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            _ = await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
