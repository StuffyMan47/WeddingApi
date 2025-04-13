using Application.Constants;
using Application.UseCase.User.CreateUser.Interfaces;
using Application.UseCase.User.CreateUser.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.User;

public class CreateUserStorage(AppDbContext dbContext) : ICreateUserStorage
{
    public async Task<bool> IsLoginAlreadyTaken(string login)
    {
        return await dbContext.Users
            .IgnoreQueryFilters()
            .AnyAsync(x => x.Login.ToLower() == login.ToLower());
    }

    public async Task<Guid> SaveUser(UserCreateModel user)
    {
        var u = new Tables.Users.User
        {
            Login = user.Login,
            PasswordHash = user.PasswordHash,
            SystemRole = user.SystemRole,
            PasswordSalt = user.PasswordSalt,
            // UserClaims = user.UserClaims.Select(c => new UserClaim
            // {
            //     ClaimType = BaseConstants.PermissionClaimKey,
            //     ClaimValue = c.Claim,
            //     HubId = c.HubId,
            // }).ToList(),
        };


        dbContext.Add(u);
        await dbContext.SaveChangesAsync();
        return u.Id;
    }
}