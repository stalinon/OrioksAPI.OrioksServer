using Microsoft.EntityFrameworkCore;
using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Persistance.Adapters.Database
{
    internal sealed class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<ScheduleEntity> Schedules { get; set; } = default!;
        public DbSet<TeacherEntity> Teachers { get; set; } = default!;

    }
}
