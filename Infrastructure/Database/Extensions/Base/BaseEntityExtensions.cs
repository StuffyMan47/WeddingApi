using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Extensions.Base;

public static class BaseEntityExtensions
{
    public static IQueryable<T> GetByIntId<T>(this IQueryable<T> query, int id) where T : BaseEntity<int> =>
        query.Where(x => x.Id == id);

    public static IQueryable<T> GetByLongId<T>(this IQueryable<T> query, long id) where T : BaseEntity<long> =>
        query.Where(x => x.Id == id);

    public static IQueryable<T> GetByGuidId<T>(this IQueryable<T> query, Guid id) where T : BaseEntity<Guid> =>
        query.Where(x => x.Id == id);
}