using System.ServiceProcess;

namespace WindowsCleanup.CLI.Services;

public class WindowsUpdateService 
{
    public void Clean()
    {
        ConsoleLogger.Info(
            "Cleaning Windows Update cache..."
        );


        StopService("wuauserv");
        StopService("BITS");


        var path =
            @"C:\Windows\SoftwareDistribution\Download";


        CleanDirectory(path);


        StartService("BITS");
        StartService("wuauserv");


        ConsoleLogger.Success(
            "Windows Update cleanup completed."
        );
    }


    private void StopService(string name)
    {
        using var service =
            new ServiceController(name);


        if (service.Status != ServiceControllerStatus.Stopped)
        {
            ConsoleLogger.Info(
                $"Stopping {name}"
            );

            service.Stop();

            service.WaitForStatus(
                ServiceControllerStatus.Stopped,
                TimeSpan.FromSeconds(30)
            );
        }
    }


    private void StartService(string name)
    {
        using var service =
            new ServiceController(name);


        if (service.Status != ServiceControllerStatus.Running)
        {
            ConsoleLogger.Info(
                $"Starting {name}"
            );

            service.Start();

            service.WaitForStatus(
                ServiceControllerStatus.Running,
                TimeSpan.FromSeconds(30)
            );
        }
    }


    private void CleanDirectory(string path)
    {
        foreach (var file in Directory.GetFiles(
            path,
            "*",
            SearchOption.AllDirectories))
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                ConsoleLogger.Warning(
                    $"Skipped {file}: {ex.Message}"
                );
            }
        }
    }
}