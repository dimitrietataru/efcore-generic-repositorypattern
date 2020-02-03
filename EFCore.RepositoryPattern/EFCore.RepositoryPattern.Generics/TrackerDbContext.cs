using EFCore.RepositoryPattern.Generics.Abstractions.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore.RepositoryPattern.Generics
{
    public abstract class TrackerDbContext : DbContext
    {
        public TrackerDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public virtual Task<int> TrackSaveChangesAsync(CancellationToken cancellationToken = default)
        {
            WaterfallEntityTrack();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void WaterfallEntityTrack()
        {
            ChangeTracker.DetectChanges();

            var entriesToCreate = GetTrackedEntriesWhen(state: EntityState.Added);
            foreach (var entry in entriesToCreate)
            {
                if (entry.Entity is ITimeTraceable entity)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }

            var entriesToDelete = GetTrackedEntriesWhen(state: EntityState.Deleted);
            foreach (var entry in entriesToDelete)
            {
                if (entry.Entity is IDeletable entity)
                {
                    entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }

            var entriesToUpdate = GetTrackedEntriesWhen(state: EntityState.Modified);
            foreach (var entry in entriesToUpdate)
            {
                if (entry.Entity is ITimeTraceable entity)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            IEnumerable<EntityEntry> GetTrackedEntriesWhen(EntityState state) =>
                ChangeTracker.Entries().Where(entry => entry.State.Equals(state));
        }
    }
}
