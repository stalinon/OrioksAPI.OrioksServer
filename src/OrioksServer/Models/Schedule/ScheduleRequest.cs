using Microsoft.AspNetCore.Mvc;

namespace OrioksServer.Models.Schedule
{
    /// <summary>
    ///     Параметры запроса расписания
    /// </summary>
    public sealed class ScheduleRequest
    {
        /// <summary>
        ///     Название предмета
        /// </summary>
        [FromQuery(Name = "name")]
        public string? Name { get; set; }

        /// <summary>
        ///     Дата
        /// </summary>
        [FromQuery(Name = "date")]
        public string? Date { get; set; }

        /// <summary>
        ///     Имя преподавателя
        /// </summary>
        [FromQuery(Name = "teacherName")]
        public string? TeacherName { get; set; }
    }
}
