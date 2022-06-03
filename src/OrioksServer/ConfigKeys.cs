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

        /// <summary>
        ///     Путь к .env файлу
        /// </summary>
        public const string ENV_PATH = "../../env/server.env";
    }
}
