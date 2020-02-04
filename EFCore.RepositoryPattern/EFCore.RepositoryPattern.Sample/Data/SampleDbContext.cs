using EFCore.RepositoryPattern.Generics.Extensions;
using EFCore.RepositoryPattern.Sample.Data.Configurations;
using EFCore.RepositoryPattern.Sample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Sample.Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.UseSoftDelete();
            this.UseTrackingOnCreate();
            this.UseTrackingOnUpdate();

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CarConfiguration());
        }
    }
}
