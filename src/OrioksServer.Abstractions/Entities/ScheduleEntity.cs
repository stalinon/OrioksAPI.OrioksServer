using System.ComponentModel.DataAnnotations;

namespace OrioksServer.Abstractions.Entities
{
    /// <summary>
    ///     Доменная модель расписания для группы
    /// </summary>
    public sealed class ScheduleEntity
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        ///     Семестр
        /// </summary>
        public string Semester { get; set; } = default!;

        /// <summary>
        ///     День недели
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        ///     Определяет день
        ///     по числителю-знаменателю
        /// </summary>
        public int DayNumber { get; set; }

        /// <summary>
        ///     Аудитория
        /// </summary>
        public string Auditory { get; set; } = default!;

        /// <summary>
        ///     Со скольки
        /// </summary>
        public DateTime TimeFrom { get; set; }

        /// <summary>
        ///     До скольки
        /// </summary>
        public DateTime TimeTo { get; set; }

        /// <summary>
        ///     Пара
        /// </summary>
        public string Time { get; set; } = default!;

        /// <summary>
        ///     Название дисциплины
        /// </summary>
        public string ClassName { get; set; } = default!;

        /// <summary>
        ///     Имя преподавателя
        /// </summary>
        public string TeacherName { get; set; } = default!;

        /// <summary>
        ///     Ключ группы
        /// </summary>
        public string GroupKey { get; set; } = default!;
    }
}
