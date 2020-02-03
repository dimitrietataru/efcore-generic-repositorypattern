namespace EFCore.RepositoryPattern.Generics.Abstractions.Domain
{
    public interface IIdentifiable<TId>
        where TId : struct
    {
        TId Id { get; set; }
    }
}
