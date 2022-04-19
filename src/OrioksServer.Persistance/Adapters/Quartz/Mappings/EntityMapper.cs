using OrioksDecorator.Models.ScheduleNoApi;
using OrioksServer.Abstractions.Entities;

namespace OrioksServer.Persistance.Adapters.Quartz.Mappings
{
    /// <summary>
    ///     Маппинг к сущностям
    /// </summary>
    internal static class EntityMapper
    {
        /// <summary>
        ///     Маппинг расписаний
        /// </summary>
        internal static ScheduleEntity[] MapSchedule(DisciplineSchedule schedule)
        {
            var entities = new List<ScheduleEntity>();

            foreach (var data in schedule.Data)
            {
                entities.Add(new ScheduleEntity
                {
                    TimeFrom = DateTime.Parse(data.Time.TimeFrom),
                    TeacherName = data.Class.TeacherFull,
                    Auditory = data.Room.Name,
                    Day = data.Day,
                    DayNumber = data.DayNumber,
                    ClassName = data.Class.Name,
                    GroupKey = data.Group.Name,
                    Semester = schedule.Semestr,
                    Time = data.Time.Time,
                    TimeTo = DateTime.Parse(data.Time.TimeTo)
                });
            }

            return entities.ToArray();
        }
    }
}
