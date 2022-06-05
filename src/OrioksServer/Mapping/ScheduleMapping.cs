using OrioksServer.Abstractions.Entities;
using OrioksServer.Models.Schedule;

namespace OrioksServer.Mapping;

/// <summary>
///     Мэппинг для <see cref="ScheduleModel"/>
/// </summary>
internal static class ScheduleMapping
{
    public static ScheduleModel? Map(ScheduleEntity? entity)
    {
        if (entity == null)
        {
            return default;
        }

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
            DayType = EnumMappings.MapDayType(entity.DayNumber),
            WeekDay = EnumMappings.MapDayOfWeek(entity.Day)
        };

        return model;
    }

    public static ScheduleListModel? Map(IEnumerable<ScheduleEntity>? entities)
    {
        if (entities == null)
        {
            return default;
        }

        var model = new ScheduleListModel
        {
            Items = entities.Select(Map).ToArray(),
            TotalCount = entities.Count()
        };

        return model;
    }
}

