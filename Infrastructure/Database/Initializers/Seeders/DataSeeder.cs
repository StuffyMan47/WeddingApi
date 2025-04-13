using Application.UseCase.Tenants.CreateTenant;
using Application.UseCase.Tenants.GetTenant;
using Application.UseCase.User.CreateUser;

namespace Infrastructure.Database.Initializers.Seeders;

public partial class DataSeeder(
    CreateTenantUseCase createTenant,
    GetTenantsUseCase getTenants,
    CreateUserUseCase createUser
);