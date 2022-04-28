using OrioksServer.Abstractions.Entities;
using OrioksServer.Models.Schedule;

namespace OrioksServer.Mapping
{
    /// <summary>
    ///     Мэппинг для <see cref="ScheduleModel"/>
    /// </summary>
    internal static class ScheduleMapping
    {
        public static ScheduleModel Map(ScheduleEntity entity)
        {
            var model = new ScheduleModel
            {
                Auditory = entity.Auditory,
                ClassName = entity.ClassName,
                GroupKey = entity.GroupKey,
                Id = entity.Id,
                Semester = entity.Semester,
                TeacherName = entity.TeacherName,
                Time = entity.Time,
                TimeFrom = TimeOnly.FromDateTime(entity.TimeFrom),
                TimeTo = TimeOnly.FromDateTime(entity.TimeTo),
                DayType = MapDayType(entity.DayNumber),
                WeekDay = MapDayOfWeek(entity.Day)
            };

            return model;

            static DayType MapDayType(int dayType) =>
                dayType switch
                {
                    0 => DayType.FIRST_NUMIRATOR,
                    1 => DayType.SECOND_NUMIRATOR,
                    2 => DayType.FIRST_DENOMINATOR,
                    3 => DayType.SECOND_DENOMINATOR,
                    _ => throw new ArgumentOutOfRangeException(nameof(dayType)),
                };

            static DayOfWeek MapDayOfWeek(int dayOfWeek) =>
                dayOfWeek switch
                {
                    1 => DayOfWeek.Monday,
                    2 => DayOfWeek.Tuesday,
                    3 => DayOfWeek.Wednesday,
                    4 => DayOfWeek.Thursday,
                    5 => DayOfWeek.Friday,
                    6 => DayOfWeek.Saturday,
                    7 => DayOfWeek.Sunday,
                    _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek)),
                };
        }

        public static ScheduleListModel Map(IEnumerable<ScheduleEntity> entities)
        {
            var model = new ScheduleListModel
            {
                Items = entities.Select(Map).ToArray(),
                TotalCount = entities.Count()
            };

            return model;
        }
    }
}
