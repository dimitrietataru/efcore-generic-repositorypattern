using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.RepositoryPattern.Sample.Data.Factories
{
    public sealed class DesignTimeContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
        {
            string databaseConnectionString = @"Data Source=TATARU\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True";

            var contextBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            contextBuilder.UseSqlServer(databaseConnectionString);

            return new SampleDbContext(contextBuilder.Options);
        }
    }
}
