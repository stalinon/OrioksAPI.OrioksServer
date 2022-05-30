using System.Text.Json.Serialization;

namespace OrioksServer.Models.Schedule
{
    /// <summary>
    ///     Список пустых аудиторий
    /// </summary>
    public class EmptyAuditoriesListModel : ListModel<string>
    {
        /// <summary>
        ///     Пара
        /// </summary>
        [JsonPropertyName("pair")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Pair { get; set; }
    }
}
