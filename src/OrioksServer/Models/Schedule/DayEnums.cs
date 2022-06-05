using System.Text.Json.Serialization;

namespace OrioksServer.Models.Schedule;

/// <summary>
///     Типы дней
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DayType
{
    /// <summary>
    ///     Первый числитель
    /// </summary>
    FIRST_NUMIRATOR = 0,

    /// <summary>
    ///     Второй числитель
    /// </summary>
    SECOND_NUMIRATOR,

    /// <summary>
    ///     Первый знаменатель
    /// </summary>
    FIRST_DENOMINATOR,

    /// <summary>
    ///     Второй знаменатель
    /// </summary>
    SECOND_DENOMINATOR
}

/// <summary>
///   Дни недели
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DayOfWeek
{
    /// <summary>
    ///     Воскресенье
    /// </summary>
    SUNDAY,

    /// <summary>
    ///     Понедельник
    /// </summary>
    MONDAY,

    /// <summary>
    ///     Вторник
    /// </summary>
    TUESDAY,

    /// <summary>
    ///     Среда
    /// </summary>
    WEDNESDAY,

    /// <summary>
    ///     Четверг
    /// </summary>
    THURSDAY,

    /// <summary>
    ///     Пятница
    /// </summary>
    FRIDAY,

    /// <summary>
    ///     Суббота
    /// </summary>
    SATURDAY
}
