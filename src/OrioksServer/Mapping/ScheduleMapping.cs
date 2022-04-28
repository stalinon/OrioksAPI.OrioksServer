using OrioksServer.Abstractions.Entities;
using OrioksServer.Models.Schedule;

namespace OrioksServer.Mapping
{
    /// <summary>
    ///     Мэппинг для <see cref="ScheduleModel"/>
    /// </summary>
    internal static class ScheduleMapping
    {
        public static ScheduleModel? Map(ScheduleEntity? entity)
        {
            if (entity == null) return default;

            var model = new ScheduleModel
            {
                Auditory = entity.Auditory,
                ClassName = entity.ClassName,
                GroupKey = entity.GroupKey,
                Id = entity.Id,
                Semester = entity.Semester,
                TeacherName = entity.TeacherName,
                Time = entity.Time,
                TimeFrom = TimeOnly.FromDateTime(entity.TimeFrom).ToString(),
                TimeTo = TimeOnly.FromDateTime(entity.TimeTo).ToString(),
                DayType = MapDayType(entity.DayNumber),
                WeekDay = MapDayOfWeek(entity.Day)
            };

            return model;
        }

        public static ScheduleListModel? Map(IEnumerable<ScheduleEntity>? entities)
        {
            if (entities == null) return default;

            var model = new ScheduleListModel
            {
                Items = entities.Select(Map).ToArray(),
                TotalCount = entities.Count()
            };

            return model;
        }


        public static DayType MapDayType(int dayType) =>
            dayType switch
            {
                0 => DayType.FIRST_NUMIRATOR,
                1 => DayType.SECOND_NUMIRATOR,
                2 => DayType.FIRST_DENOMINATOR,
                3 => DayType.SECOND_DENOMINATOR,
                _ => throw new ArgumentOutOfRangeException(nameof(dayType)),
            };

        public static DayOfWeek MapDayOfWeek(int dayOfWeek) =>
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
}
