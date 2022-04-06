﻿namespace OrioksServer.Abstractions.Entities
{
    /// <summary>
    ///     Доменная модель преподавателя
    /// </summary>
    public sealed class TeacherEntity
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Полное имя
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        ///     Степень
        /// </summary>
        public string Degree { get; set; } = default!;

        /// <summary>
        ///     Глава
        /// </summary>
        public string Chapter { get; set; } = default!;

        /// <summary>
        ///     Должность
        /// </summary>
        public string Position { get; set; } = default!;

        /// <summary>
        ///     Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; } = default!;

        /// <summary>
        ///     Почта
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        ///     Аудитория
        /// </summary>
        public string Auditory { get; set; } = default!;

        /// <summary>
        ///     URL изображения
        /// </summary>
        public string ImageUrl { get; set; } = default!;

        /// <summary>
        ///     Биография
        /// </summary>
        public string Biography { get; set; } = default!;

        /// <summary>
        ///     Курсы
        /// </summary>
        public string Courses { get; set; } = default!;

        /// <summary>
        ///     Наука
        /// </summary>
        public string Science { get; set; } = default!;
    }
}
