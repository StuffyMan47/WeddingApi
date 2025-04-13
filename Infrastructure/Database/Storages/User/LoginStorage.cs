using Application.UseCase.User.CreateUser.Interfaces;
using Application.UseCase.User.Login.Interfaces;
using Application.UseCase.User.Login.Models;
using Infrastructure.Database.DbContext;
using Infrastructure.Database.Extensions.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.User;

public class LoginStorage(AppDbContext dbContext) : ILoginStorage
{
    public async Task<UserModel?> GetUser(string login)
    {
        return await (from user in dbContext.Users.IgnoreQueryFilters().GetByLogin(login)
                      select new UserModel
                      {
                          UserId = user.Id,
                          SystemRole = user.SystemRole,
                          Login = user.Login,
                          PasswordHash = user.PasswordHash,
                          PasswordSalt = user.PasswordSalt
                      }).FirstOrDefaultAsync();
    }
}