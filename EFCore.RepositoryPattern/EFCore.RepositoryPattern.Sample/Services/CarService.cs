using EFCore.RepositoryPattern.Generics;
using EFCore.RepositoryPattern.Sample.Data;
using EFCore.RepositoryPattern.Sample.Data.Entities;
using System;

namespace EFCore.RepositoryPattern.Sample.Services
{
    public sealed class CarService : GenericRepository<Car, Guid>, ICarService
    {
        private readonly SampleDbContext context;

        public CarService(SampleDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
