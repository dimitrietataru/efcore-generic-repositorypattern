using EFCore.RepositoryPattern.Generics;
using EFCore.RepositoryPattern.Sample.Data.Entities;
using System;

namespace EFCore.RepositoryPattern.Sample.Services
{
    public interface ICarService : IGenericRepository<Car, Guid>
    {
    }
}
