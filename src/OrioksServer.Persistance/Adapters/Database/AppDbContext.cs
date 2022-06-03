using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Persistance.Adapters.Database;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ScheduleEntity> Schedules { get; set; } = default!;
    public DbSet<TeacherEntity> Teachers { get; set; } = default!;

}
