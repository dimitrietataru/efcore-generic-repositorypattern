using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Generics.Abstractions.Repository
{
    public interface IAbstractRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();
        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task CreateBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteBulkAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

        Task SaveAsync(CancellationToken cancellationToken = default);

        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default);
    }
}
