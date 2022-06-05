namespace OrioksServer.Helpers;

internal static class DotEnv
{
    public static void Load(string filePath = ConfigKeys.ENV_PATH)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            var variable = parts.First();
            var value = string.Join("=", parts.Skip(1));
            Environment.SetEnvironmentVariable(variable, value);
        }
    }
}
