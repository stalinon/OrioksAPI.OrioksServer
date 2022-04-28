using OrioksServer.Abstractions.Ports;
using OrioksServer.Domain.IServices;

namespace OrioksServer.Domain.Services
{
    /// <inheritdoc cref="IDomainServiceFactory" />
    public sealed class DomainServiceFactory : IDomainServiceFactory
    {
        /// <inheritdoc />
        public IScheduleService CreateScheduleService(IUnitOfWork unitOfWork)
        {
            return new ScheduleService(unitOfWork);
        }

        /// <inheritdoc />
        public ITeacherService CreateTeacherService(IUnitOfWork unitOfWork)
        {
            return new TeacherService(unitOfWork);
        }
    }
}
