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

        public override bool Contains(TeacherEntity entity)
        {
            return FirstOrDefault(x => x.Name == entity.Name) != default;
        }
    }
}
