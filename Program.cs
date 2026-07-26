using System.Security.Principal;
using WindowsCleanup.CLI.Services;

var cleanup = new CleanupService();
const string TempCommand = "--temp";
const string WindowsTempCommand = "--windows-temp";
const string UpdateCommand = "--update-cache";
const string AllCommand = "--all";
if (args.Length == 0|| args.Length > 1)
{
    Console.WriteLine("Only one command is supported at a time.");
    ShowHelp();
    return;
}



switch (args[0].ToLower())
{
    case TempCommand:
        cleanup.CleanUserTemp();
        break;

    case WindowsTempCommand:
        if (!IsRunningAsAdmin()) { ConsoleLogger.Error("This command requires administrator privileges. Run as admin and try again."); return; }
        cleanup.CleanWindowsTemp();
        break;

    case UpdateCommand:
        if (!IsRunningAsAdmin()) { ConsoleLogger.Error("This command requires administrator privileges. Run as admin and try again."); return; }
        cleanup.CleanWindowsUpdate();
        break;

    case AllCommand:
        if (!IsRunningAsAdmin()) { ConsoleLogger.Error("This command requires administrator privileges. Run as admin and try again."); return; }
        cleanup.CleanAll();
        break;
    case "--help":
    case "-h":
        ShowHelp();
        break;

    default:
        Console.WriteLine("Unknown command");
        ShowHelp();
        break;
}





static bool IsRunningAsAdmin()
{
    using var identity = WindowsIdentity.GetCurrent();
    var principal = new WindowsPrincipal(identity);
    return principal.IsInRole(WindowsBuiltInRole.Administrator);
}

static void ShowHelp()
{
    Console.WriteLine("""
    Windows Cleanup Utility

    Usage:

      WindowsCleanup.exe [command]

    Commands:

      --temp              Clean user temp files
      --windows-temp      Clean Windows temp files
      --update-cache      Clean Windows Update cache
      --all               Run all cleanup tasks
      --help              Show help

    """);
}