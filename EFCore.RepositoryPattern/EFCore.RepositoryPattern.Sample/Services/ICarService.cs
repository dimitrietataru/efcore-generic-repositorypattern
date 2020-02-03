using EFCore.RepositoryPattern.Generics.Abstractions.Repository;
using EFCore.RepositoryPattern.Sample.Data.Entities;

namespace EFCore.RepositoryPattern.Sample.Services
{
    public interface ICarService : IRepositoryBase<Car>
    {
    }
}
