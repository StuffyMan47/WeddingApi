using Infrastructure.Database.Tables.Users;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Database.Extensions.Users;

public static class Extensions
{
    [SuppressMessage("Performance", "CA1862:Use the \'StringComparison\' method overloads to perform case-insensitive string comparisons")]
    [SuppressMessage("ReSharper", "SpecifyStringComparison")]
    public static IQueryable<User> GetByLogin(this IQueryable<User> query, string login) =>
    query.Where(x => x.Login.ToLower() == login.ToLower());
}
