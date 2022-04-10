using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Domain.IServices
{
    /// <summary>
    ///     Доменный сервис расписаний
    /// </summary>
    public interface IScheduleService : IDomainService<ScheduleEntity>
    {
        /// <summary>
        ///     Найти незанятые аудитории
        ///     на заданный день
        /// </summary>
        Task<ScheduleEntity> FindEmptyRooms(DateTime dateTime);
    }
}
