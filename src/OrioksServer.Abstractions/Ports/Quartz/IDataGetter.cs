using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Abstractions.Ports.Quartz
{
    /// <summary>
    ///     Получение данных
    /// </summary>
    public interface IDataGetter
    {
        /// <summary>
        ///     Получить расписания
        /// </summary>
        public Task<IEnumerable<ScheduleEntity>> GetSchedules();

        /// <summary>
        ///     Получить преподавателей
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TeacherEntity>> GetTeachers();
    }
}
