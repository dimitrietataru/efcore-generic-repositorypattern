using EFCore.RepositoryPattern.Generics.Abstractions.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore.RepositoryPattern.Generics.Extensions
{
    public static class DbContextExtension
    {
        public static void UseSoftDelete(this DbContext dbContext)
        {
            dbContext.ChangeTracker.DetectChanges();

            var entitiesToDelete = dbContext
                .ChangeTracker
                .Entries()
                .Where(entry => entry.State.Equals(EntityState.Deleted));

            foreach (var entry in entitiesToDelete)
            {
                if (entry.Entity is IDeletable entity)
                {
                    entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }
        }

        public static void UseTrackingOnCreate(this DbContext dbContext)
        {
            dbContext.ChangeTracker.DetectChanges();

            var entriesToCreate = dbContext
                .ChangeTracker
                .Entries()
                .Where(entry => entry.State.Equals(EntityState.Added));

            foreach (var entry in entriesToCreate)
            {
                if (entry.Entity is ITimeTraceable entity)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        public static void UseTrackingOnUpdate(this DbContext dbContext)
        {
            dbContext.ChangeTracker.DetectChanges();

            var entriesToUpdate = dbContext
                .ChangeTracker
                .Entries()
                .Where(entry => entry.State.Equals(EntityState.Modified));

            foreach (var entry in entriesToUpdate)
            {
                if (entry.Entity is ITimeTraceable entity)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
