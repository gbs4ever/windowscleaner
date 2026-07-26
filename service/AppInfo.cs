namespace WindowsCleanup.CLI.Services;
using System.Reflection;
public static class AppInfo
{
    public static string Name =>
           Assembly.GetExecutingAssembly()
           .GetName()
           .Name ?? "WindowsCleanup";


    public static string Version =>
        Assembly.GetExecutingAssembly()
        .GetName()
        .Version?
        .ToString() ?? "Unknown";


    public static void ShowVersion()
    {
        ConsoleLogger.Info($"{Name} v{Version}");
    }
}