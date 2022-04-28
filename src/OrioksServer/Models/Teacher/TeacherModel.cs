using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrioksServer.Models.Teacher
{
    /// <summary>
    ///     Контракт преподавателя
    /// </summary>
    public sealed class TeacherModel
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Полное имя
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///     Степень
        /// </summary>
        [JsonPropertyName("degree")]
        public string Degree { get; set; } = default!;

        /// <summary>
        ///     Глава
        /// </summary>
        [JsonPropertyName("chapter")]
        public string Chapter { get; set; } = default!;

        /// <summary>
        ///     Должность
        /// </summary>
        [JsonPropertyName("position")]
        public string Position { get; set; } = default!;

        /// <summary>
        ///     Номер телефона
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        ///     Почта
        /// </summary>
        [JsonPropertyName("email")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }

        /// <summary>
        ///     Аудитория
        /// </summary>
        [JsonPropertyName("auditory")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Auditory { get; set; }

        /// <summary>
        ///     URL изображения
        /// </summary>
        [JsonPropertyName("imageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }

        /// <summary>
        ///     Биография
        /// </summary>
        [JsonPropertyName("biography")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Biography { get; set; }

        /// <summary>
        ///     Курсы
        /// </summary>
        [JsonPropertyName("courses")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Courses { get; set; }

        /// <summary>
        ///     Наука
        /// </summary>
        [JsonPropertyName("science")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Science { get; set; }
    }
}
