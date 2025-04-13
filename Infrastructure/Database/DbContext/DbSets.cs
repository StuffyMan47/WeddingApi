using Infrastructure.Database.Tables.Event;
using Infrastructure.Database.Tables.Guest;
using Infrastructure.Database.Tables.Schedule;
using Infrastructure.Database.Tables.Photo;
using Infrastructure.Database.Tables.Users;
using Infrastructure.Database.Tables.Place;
using Infrastructure.Database.Tables.Owner;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DbContext;

public partial class AppDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Photo> Photos => Set<Photo>();
    public DbSet<Place> Places => Set<Place>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();
}