using System.Text.Json.Serialization;

namespace OrioksServer.Models
{
    /// <summary>
    ///     Список
    /// </summary>
    public class ListModel<T>
    {
        [JsonPropertyName("items")]
        public T[] Items { get; set; } = Array.Empty<T>();

        [JsonPropertyName("total")]
        public int TotalCount { get; set; }
    }
}
