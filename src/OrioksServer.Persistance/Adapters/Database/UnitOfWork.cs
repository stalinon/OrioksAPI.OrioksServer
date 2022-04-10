using OrioksServer.Abstractions.Ports;
using OrioksServer.Abstractions.Ports.Repositories;

namespace OrioksServer.Persistance.Adapters.Database
{
    /// <inheritdoc cref="IUnitOfWork"/>
    internal class UnitOfWork : IUnitOfWork
    {
        /// <inheritdoc/>
        public IScheduleRepository Schedules { get; set; } = default!;

        /// <inheritdoc/>
        public ITeacherRepository Teachers { get; set; } = default!;
    }
}
