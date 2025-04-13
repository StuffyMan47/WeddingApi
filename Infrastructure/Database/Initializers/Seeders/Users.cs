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
            tenant.Value.Id,
            SystemRole.System);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(SystemConstants.SystemLogin).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateTenantSuperAdmin(int tenantId, string login, string password)
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
            tenantId,
            SystemRole.Admin);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateTestUser(
        string login,
        string password,
        SystemRole systemRole,
        int? tenantId = null)
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
            tenantId ?? tenant.Value.Id,
            systemRole);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }

    public async Task<Result> CreateImportUser(
        string login,
        string password,
        int? tenantId = null)
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
            },
            tenantId ?? tenant.Value.Id);

        return result.IsSuccess || result.Message == ErrorProvider.Users.LoginAlreadyTaken(login).Message
            ? Result.Success()
            : result;
    }
}