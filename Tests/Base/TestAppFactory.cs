using System.Net.Http.Json;
using System.Text.Json;
using Application.Constants.Test;
using Application.Enums;
using Application.Exception.Base;
using Application.JsonSerialization;
using Application.UseCase.User.Login.Models;
using Infrastructure.Database.DbContext;
using Infrastructure.Database.Initializers.Default;
using Infrastructure.Database.Initializers.Seeders;
using Infrastructure.Database.Tables.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using Tests.Mocks;
using WeddingApi.Models;
using LoginRequest = Application.UseCase.User.Login.Models.LoginRequest;

namespace Tests.Base;

public partial class TestAppFactory: WebApplicationFactory<WeddingApi.Api.Program>, IAsyncLifetime
{
    private PostgreSqlContainer Container { get; } = new PostgreSqlBuilder()
        .WithImage("postgres:16-alpine3.18")
        .WithCleanUp(true)
        .Build();

    private string TesterToken { get; set; } = string.Empty;
    private string NoPermissionToken { get; set; } = string.Empty;
    private HttpClient? Client { get; set; }
    private DataSeeder? Seeder { get; set; }
    
    public User UserData { get; private set; } = default!;
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // builder.ConfigureTestServices(services =>
        // {
        //     services.AddTestLabelRequestService();
        //     services.AddTestNomenclatorService();
        //     services.ReplaceAndMigrateDbContexts(Container.GetConnectionString());
        // });
    }

    public new async Task DisposeAsync() => await Container.StopAsync();
    
    public async Task InitializeAsync()
    {
        await Container.StartAsync();
        Client = CreateClient();

        var scope = Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

        await scope.ServiceProvider.InitializeDatabase();

        await CreateTestUsersAndSetTokens(seeder);

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        UserData = await dbContext.Users.IgnoreQueryFilters().SingleOrDefaultAsync(u => u.Login == SystemUserConstants.TesterLogin) ?? default!;

        // await SeedTestData(seeder);

        scope.Dispose();
    }

    public IServiceScope GetScope()
    {
        var scope = Services.CreateScope();
        return scope;
    }
    
    public AppDbContext GetAppDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(Container.GetConnectionString(), o => o.MigrationsAssembly(typeof(AppDbContext).Assembly.ToString()).MigrationsHistoryTable("__EFMigrationsHistory", "public"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

        var userContextProvider = new TestUserContextProvider(new()
        {
            Id = UserData.Id,
            Login = UserData.Login,
        });

        return new(options.Options, userContextProvider);
    }
    
    private async Task<string> GetTokens(TestUserEnum user)
    {
        var authData = user switch
        {
            TestUserEnum.Tester => new LoginRequest(SystemUserConstants.TesterLogin, SystemUserConstants.TesterPassword),
            TestUserEnum.NoPermissionTester => new(SystemUserConstants.TesterWithoutPermissionsLogin, SystemUserConstants.TesterWithoutPermissionsPassword),
            _ => throw new ArgumentException("Not supported user")
        };

        var content = JsonContent.Create(authData);

        var response = await Client.PostAsync("/api/auth/login", content);
        string token = JsonSerializer
            .Deserialize<BaseApiResponseModel<LoginResponse>>(
                await response.Content.ReadAsStringAsync(),
                JsonSerializationOptions.GetDefault())?.Data.AccessToken ?? throw new InternalServerException("Авторизация прошла неудачно");

        return token;
    }
    
    private async Task CreateTestUsersAndSetTokens(DataSeeder seeder)
    {
        await seeder.CreateTestUser(SystemUserConstants.TesterLogin, SystemUserConstants.TesterPassword, SystemRole.Admin);
        await seeder.CreateTestUser(SystemUserConstants.TesterWithoutPermissionsLogin, SystemUserConstants.TesterWithoutPermissionsPassword, SystemRole.Couple);

        TesterToken = await GetTokens(TestUserEnum.Tester);
        NoPermissionToken = await GetTokens(TestUserEnum.NoPermissionTester);
        Client.DefaultRequestHeaders.Authorization = new("Bearer", TesterToken);
    }
    
    
    // private async Task SeedTestData(DataSeeder seeder)
    // {
    //     await GenerateOwners(5);
    //
    //     if (seeder == null)
    //         throw new InternalServerException("Отсутствует сервис создания тестовых данных");
    //
    //     var ttmfTenantId = await seeder.CreateTenantByInn(TtmfConstants.TtmfTenantName, TtmfConstants.TtmfInn, TtmfConstants.TtmfKpp);
    //     await seeder.CreateDefaultRoleTemplates();
    //     await seeder.CreateDefaultWorkPrograms();
    //     await seeder.CreateTestUser("ttnfUserLogin", "ttmfUserPassword", SystemRole.TenantMaintainer, tenantId: ttmfTenantId.Value);
    //     
    // }
}