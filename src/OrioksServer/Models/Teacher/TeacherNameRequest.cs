using Microsoft.AspNetCore.Mvc;

namespace OrioksServer.Models.Teacher
{
    /// <summary>
    ///     Параметры запроса преподавателя
    /// </summary>
    public sealed class TeacherNameRequest
    {
        /// <summary>
        ///     Имя преподавателя
        /// </summary>
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
    }
}
