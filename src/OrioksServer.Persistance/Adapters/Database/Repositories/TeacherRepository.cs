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

        public override void Add(TeacherEntity entity)
        {
            var all = GetAll();
            entity.Id = (all != null) ? all.Select(x => x.Id).Max() + 1 : 1;
            base.Add(entity);
        }
    }
}
