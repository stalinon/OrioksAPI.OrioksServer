using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports.Repositories;

namespace OrioksServer.Persistance.Adapters.Database.Repositories
{
    internal sealed class ScheduleRepository : Repository<ScheduleEntity>, IScheduleRepository
    {
        private readonly AppDbContext _db;

        public ScheduleRepository(AppDbContext db) : base(db)
        {
            _db = db; 
        }
    }
}
