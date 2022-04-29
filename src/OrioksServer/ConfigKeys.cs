namespace OrioksServer
{
    /// <summary>
    ///     Ключи конфигурации
    /// </summary>
    internal static class ConfigKeys
    {
        /// <summary>
        ///     URL для прослушивания
        /// </summary>
        public const string ASPNETCORE_URLS = nameof(ASPNETCORE_URLS);

        /// <summary>
        ///     Строка подключения к БД
        /// </summary>
        public const string CONNECTION_STRING = nameof(CONNECTION_STRING);
    }
}
