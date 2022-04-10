using OrioksServer.Abstractions.Ports;

namespace OrioksServer.Domain.IServices
{
    /// <summary>
    ///     Доменный сервис приложения
    /// </summary>
    public interface IDomainServiceFactory
    {
        /// <inheritdoc cref="ITeacherService"/>
        ITeacherService CreateTeacherService(IUnitOfWork unitOfWork);

        /// <inheritdoc cref="IScheduleService"/>
        IScheduleService CreateScheduleService(IUnitOfWork unitOfWork);

    }
}
