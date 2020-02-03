namespace EFCore.RepositoryPattern.Generics.Abstractions.Domain
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
