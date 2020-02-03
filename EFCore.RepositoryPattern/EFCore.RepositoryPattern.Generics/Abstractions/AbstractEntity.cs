using EFCore.RepositoryPattern.Generics.Abstractions.Domain;
using System;

namespace EFCore.RepositoryPattern.Generics.Abstractions
{
    public abstract class AbstractEntity<TId> :
        IIdentifiable<TId>, IDeletable, ITimeTraceable, IEquatable<AbstractEntity<TId>>
        where TId : struct
    {
        public virtual TId Id { get; set; }

        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }

        public bool Equals(AbstractEntity<TId> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals(obj as AbstractEntity<TId>);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = Id.GetHashCode();
                hash = (hash * 397) ^ CreatedAt.GetHashCode();
                hash = (hash * 397) ^ UpdatedAt.GetHashCode();

                return hash;
            }
        }
    }
}
