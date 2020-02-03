using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Generics.Abstractions.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task CreateAsync(TEntity entity);
        Task CreateBulkAsync(ICollection<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateBulkAsync(ICollection<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteBulkAsync(ICollection<TEntity> entities);
    }
}
