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

        public override void Add(ScheduleEntity entity)
        {
            var all = GetAll();
            entity.Id = (all != null) ? all.Select(x => x.Id).Max() + 1 : 1;
            base.Add(entity);
        }
    }
}
