using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Infrastructure;
using Infrastructure.Database.DbContext;
using Infrastructure.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnectionString"));
    });

await builder.Services.RegisterWeddingModule(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerBuilder(builder.Environment);


using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await dbContext.Database.EnsureCreatedAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace WeddingApi.Api
{
    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty")]
    public class Program;
}