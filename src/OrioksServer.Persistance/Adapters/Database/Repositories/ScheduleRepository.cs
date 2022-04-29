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

        public override async Task<bool> ContainsAsync(ScheduleEntity entity, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync(x => x.TeacherName == entity.TeacherName && x.Auditory == entity.Auditory 
                                && x.ClassName == entity.ClassName && x.Day == entity.Day && x.DayNumber == entity.DayNumber
                                && x.GroupKey == entity.GroupKey) != default;
        }
    }
}
