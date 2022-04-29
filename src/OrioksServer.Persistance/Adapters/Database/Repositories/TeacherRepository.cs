using OrioksServer.Abstractions.Entities;
using OrioksServer.Abstractions.Ports.Repositories;

namespace OrioksServer.Persistance.Adapters.Database.Repositories
{
    internal class TeacherRepository : Repository<TeacherEntity>, ITeacherRepository
    {
        private readonly AppDbContext _db;

        public TeacherRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<bool> ContainsAsync(TeacherEntity entity, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync(x => x.Name == entity.Name) != default;
        }
    }
}
