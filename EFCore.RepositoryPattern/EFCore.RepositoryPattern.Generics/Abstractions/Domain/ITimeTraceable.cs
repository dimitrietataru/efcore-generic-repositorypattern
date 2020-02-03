using System;

namespace EFCore.RepositoryPattern.Generics.Abstractions.Domain
{
    public interface ITimeTraceable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
