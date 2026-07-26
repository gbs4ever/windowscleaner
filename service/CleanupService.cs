namespace WindowsCleanup.CLI.Services;

public class CleanupService
{
    public void CleanUserTemp()
    {
        ConsoleLogger.Info("Cleaning user temp files...");
        var path = Path.GetTempPath();

        CleanDirectory(path);

        ConsoleLogger.Success("User temp cleanup completed.");
    }


    public void CleanWindowsTemp()
    {
        ConsoleLogger.Info("Cleaning Windows temp files...");

        var path = @"C:\Windows\Temp";

        CleanDirectory(path);

        ConsoleLogger.Success("Windows temp cleanup completed.");
    }


    public void CleanWindowsUpdate()
    {
        ConsoleLogger.Info("Cleaning Windows Update cache...");
        var windowsUpdate = new WindowsUpdateService();
        windowsUpdate.Clean();
    }


    public void CleanAll()
    {
        CleanUserTemp();
        CleanWindowsTemp();
        CleanWindowsUpdate();
    }


    private void CleanDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Directory not found: {path}");
            return;
        }


        var files = Directory.GetFiles(
            path,
            "*",
            SearchOption.AllDirectories
        );


        foreach (var file in files)
        {
            try
            {
                File.SetAttributes(
                    file,
                    FileAttributes.Normal
                );

                File.Delete(file);

                Console.WriteLine($"Deleted: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Skipped: {file} - {ex.Message}"
                );
            }
        }
    }
}