using OrioksServer.Abstractions.Ports;
using OrioksServer.Abstractions.Ports.Repositories;
using OrioksServer.Persistance.Adapters.Database.Repositories;

namespace OrioksServer.Persistance.Adapters.Database
{
    /// <inheritdoc cref="IUnitOfWork"/>
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Schedules = new ScheduleRepository(_appDbContext);
            Teachers = new TeacherRepository(_appDbContext);
        }

        /// <inheritdoc/>
        public IScheduleRepository Schedules { get; set; } = default!;

        /// <inheritdoc/>
        public ITeacherRepository Teachers { get; set; } = default!;
    }
}
