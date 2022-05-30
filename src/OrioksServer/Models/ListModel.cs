using System.Text.Json.Serialization;

namespace OrioksServer.Models
{
    /// <summary>
    ///     Список
    /// </summary>
    public class ListModel<T>
    {
        /// <summary>
        ///     Массив элементов
        /// </summary>
        [JsonPropertyName("items")]
        public T?[] Items { get; set; } = Array.Empty<T>();

        /// <summary>
        ///     Количество элементов
        /// </summary>

        [JsonPropertyName("total")]
        public int TotalCount { get; set; }
    }
}
