using Application.Exception.Base;
using Application.UseCase.User.GenerateToken.Interfaces;
using Application.UseCase.User.GenerateToken.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Token;

public class GenerateUserTokenStorage(AppDbContext dbContext) : IGenerateTokenStorage
{

    public async Task SaveUserRefreshToken(SaveUserTokenRequest request)
    {
        var user = await dbContext.Users
            .AsTracking()
            .IgnoreQueryFilters()
            .Where(x => x.Id == request.UserId)
            .Include(x => x.UserTokens)
            .FirstOrDefaultAsync();

        if (user == null)
            throw new InternalServerException("Пользователь не найден");

        if (user.UserTokens.Count > request.MaxSessionsPerUser - 1)
        {
            var tokens = user.UserTokens
                .OrderByDescending(x => x.Id)
                .Take(request.MaxSessionsPerUser - 1)
                .ToList();

            dbContext.UserTokens.RemoveRange(user.UserTokens.Except(tokens));
        }

        dbContext.UserTokens.Add(new()
        {
            UserId = request.UserId,
            ExpirationDate = request.TokenExpirationDate,
            RefreshToken = request.RefreshToken

        });

        await dbContext.SaveChangesAsync();
    }
}
