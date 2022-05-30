using OrioksServer.Models.Schedule;

namespace OrioksServer.Mapping;

/// <summary>
///     Маппинги перечислений
/// </summary>
public class EnumMappings
{
    /// <summary>
    ///     Маппинг <see cref="DayType"/>
    /// </summary>
    public static DayType MapDayType(int dayType) =>
        dayType switch
        {
            0 => DayType.FIRST_NUMIRATOR,
            1 => DayType.SECOND_NUMIRATOR,
            2 => DayType.FIRST_DENOMINATOR,
            3 => DayType.SECOND_DENOMINATOR,
            _ => throw new ArgumentOutOfRangeException(nameof(dayType)),
        };

    /// <summary>
    ///     Маппинг <see cref="DayOfWeek"/>
    /// </summary>
    public static Models.Schedule.DayOfWeek MapDayOfWeek(int dayOfWeek) =>
        dayOfWeek switch
        {
            1 => Models.Schedule.DayOfWeek.MONDAY,
            2 => Models.Schedule.DayOfWeek.TUESDAY,
            3 => Models.Schedule.DayOfWeek.WEDNESDAY,
            4 => Models.Schedule.DayOfWeek.THURSDAY,
            5 => Models.Schedule.DayOfWeek.FRIDAY,
            6 => Models.Schedule.DayOfWeek.SATURDAY,
            7 => Models.Schedule.DayOfWeek.SUNDAY,
            _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek)),
        };

    /// <summary>
    ///     Маппинг <see cref="DayOfWeek"/>
    /// </summary>
    public static Models.Schedule.DayOfWeek MapDayOfWeek(System.DayOfWeek dof) => 
        dof switch
        {
            System.DayOfWeek.Monday => Models.Schedule.DayOfWeek.MONDAY,
            System.DayOfWeek.Wednesday => Models.Schedule.DayOfWeek.WEDNESDAY,
            System.DayOfWeek.Thursday => Models.Schedule.DayOfWeek.THURSDAY,
            System.DayOfWeek.Friday => Models.Schedule.DayOfWeek.FRIDAY,
            System.DayOfWeek.Saturday => Models.Schedule.DayOfWeek.SATURDAY,
            System.DayOfWeek.Tuesday => Models.Schedule.DayOfWeek.TUESDAY,
            System.DayOfWeek.Sunday => Models.Schedule.DayOfWeek.SUNDAY,
            _ => Models.Schedule.DayOfWeek.SUNDAY,
        };


}
