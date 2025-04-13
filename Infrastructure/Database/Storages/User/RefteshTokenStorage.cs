using Application.UseCase.User.RefreshToken.Interfaces;
using Application.UseCase.User.RefreshToken.Models;
using Infrastructure.Database.DbContext;
using Infrastructure.Database.Extensions.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.User;

public class RefteshTokenStorage(AppDbContext dbContext) : IRefreshTokenStorage
{
    public async Task<UserModel?> GetUser(Guid userId, string refreshToken)
    {
        return await (from user in dbContext.Users.IgnoreQueryFilters().GetByGuidId(userId)
            let token = user.UserTokens.FirstOrDefault(x => x.RefreshToken == refreshToken)
            select new UserModel
            {
                UserId = user.Id,
                SystemRole = user.SystemRole,
                Login = user.Login,
                RefreshTokenFromDb = token == null ? null : token.RefreshToken,
                RefreshTokenExpires = token == null ? null : token.ExpirationDate,
            }).FirstOrDefaultAsync();
    }
}