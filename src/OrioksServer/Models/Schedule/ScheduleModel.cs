using System.Text.Json.Serialization;

namespace OrioksServer.Models.Schedule
{
    /// <summary>
    ///     Контракт расписания для группы
    /// </summary>
    public sealed class ScheduleModel
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Семестр
        /// </summary>
        [JsonPropertyName("semester")]
        public string Semester { get; set; } = default!;

        /// <summary>
        ///     День недели
        /// </summary>
        [JsonPropertyName("weekDay")]
        public DayOfWeek WeekDay { get; set; }

        /// <summary>
        ///     Определяет день
        ///     по числителю-знаменателю
        /// </summary>
        [JsonPropertyName("dayType")]
        public DayType DayType { get; set; }

        /// <summary>
        ///     Аудитория
        /// </summary>
        [JsonPropertyName("auditory")]
        public string Auditory { get; set; } = default!;

        /// <summary>
        ///     Со скольки
        /// </summary>
        [JsonPropertyName("from")]
        public TimeOnly TimeFrom { get; set; }

        /// <summary>
        ///     До скольки
        /// </summary>
        [JsonPropertyName("to")]
        public TimeOnly TimeTo { get; set; }

        /// <summary>
        ///     Пара
        /// </summary>
        [JsonPropertyName("time")]
        public string Time { get; set; } = default!;

        /// <summary>
        ///     Название дисциплины
        /// </summary>
        [JsonPropertyName("discipline")]
        public string ClassName { get; set; } = default!;

        /// <summary>
        ///     Имя преподавателя
        /// </summary>
        [JsonPropertyName("teacherName")]
        public string TeacherName { get; set; } = default!;

        /// <summary>
        ///     Ключ группы
        /// </summary>
        [JsonPropertyName("group")]
        public string GroupKey { get; set; } = default!;
    }
}
