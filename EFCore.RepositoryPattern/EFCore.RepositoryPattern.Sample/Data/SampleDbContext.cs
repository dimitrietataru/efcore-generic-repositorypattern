using EFCore.RepositoryPattern.Generics;
using EFCore.RepositoryPattern.Sample.Data.Configurations;
using EFCore.RepositoryPattern.Sample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EFCore.RepositoryPattern.Sample.Data
{
    public class SampleDbContext : TrackerDbContext
    {
        public SampleDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CarConfiguration());
        }
    }
}
