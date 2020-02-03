using EFCore.RepositoryPattern.Generics.Abstractions;
using EFCore.RepositoryPattern.Sample.Data;
using EFCore.RepositoryPattern.Sample.Data.Entities;

namespace EFCore.RepositoryPattern.Sample.Services
{
    public sealed class CarService : AbstractRepository<Car>, ICarService
    {
        private readonly SampleDbContext context;

        public CarService(SampleDbContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
