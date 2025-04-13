namespace Infrastructure.Database.Entities;

public abstract class BaseEntity<T>
{
    public T Id { get; init; } = default!;
}