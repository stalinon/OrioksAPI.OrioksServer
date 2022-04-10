using OrioksServer.Abstractions.Ports.Repositories;

namespace OrioksServer.Abstractions.Ports
{
    /// <summary>
    ///     Unit Of Work для <inheritdoc cref="IRepository{T}"/>
    /// </summary>
    public interface IUnitOfWork
    {
        /// <inheritdoc cref="IScheduleRepository"/>
        public IScheduleRepository Schedules { get; set; }


        /// <inheritdoc cref="ITeacherRepository"/>
        public ITeacherRepository Teachers { get; set; }
    }
}
