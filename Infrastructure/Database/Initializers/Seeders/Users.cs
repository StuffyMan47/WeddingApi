using Application.Constants;
using Application.Enums;
using Application.Errors;
using Application.Extensions.ActionResult;
using Application.UseCase.Tenants.GetTenant.Models;
using Application.UseCase.User.CreateUser.Models;

namespace Infrastructure.Database.Initializers.Seeders;

public partial class DataSeeder
{
    public enum PermissionSetEnum
    {
        NoPermissions = 0,
        FullPermissions = 1
    }

    public async Task<Result> CreateSystemUser()
    {
        var tenant = await getTenants.GetTenantByName(BaseConstants.RootTenantName);
        if (tenant.IsFailure)
            return tenant;

        var result = await createUser.CreateUser(new()
            {
                Password = SystemConstants.SystemPassword,
                Login = SystemConstants.SystemLogin,
                Name = "system",
                Surname = "system",
                FatherName = "system",
                Gender = null,
                BirthDate = null,
            },
            SystemRole.System);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(SystemConstants.SystemLogin).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateTenantSuperAdmin(string login, string password)
    {
        var result = await createUser.CreateUser(new()
            {
                Password = password,
                Login = login,
                Name = login,
                Surname = login,
                FatherName = null,
                Gender = null,
                BirthDate = null,
            },
            SystemRole.Admin);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateTestUser(
        string login,
        string password,
        SystemRole systemRole
        )
    {

        var tenant = await getTenants.GetTenantByName(BaseConstants.RootTenantName);
        if (tenant.IsFailure)
            return tenant;

        var result = await createUser.CreateUser(new()
            {
                Password = password,
                Login = login,
                Name = login,
                Surname = login,
                FatherName = null,
                Gender = null,
                BirthDate = null,
            },
            systemRole);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateImportUser(
        string login,
        string password
        )
    {
        Result<TenantModel> tenant = await getTenants.GetTenantByName(BaseConstants.RootTenantName);
        if (tenant.IsFailure)
            return tenant;

        Result<Guid> result = await createUser.CreateUser(new CreateUserRequest
            {
                Password = password,
                Login = login,
                Name = login,
                Surname = login,
                FatherName = null,
                Gender = null,
                BirthDate = null,
            });

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }
}