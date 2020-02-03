using System;

namespace EFCore.RepositoryPattern.Generics.Exceptions
{
    public sealed class EntityNotFoundException<TEntity> : Exception
        where TEntity : class
    {
        private readonly string message = string.Empty;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
            this.message = message;
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.message = message;
        }

        public sealed override string StackTrace => $"Entity of type '{ typeof(TEntity) }' was not found! { message }";

        public sealed override string Message => $"Entity of type '{ typeof(TEntity) }' was not found!";
    }
}
