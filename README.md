# Windows Cleanup Utility

A lightweight Windows command-line cleanup tool built with **C# and .NET 9**.

Windows Cleanup Utility helps remove unnecessary temporary files and maintenance data to recover disk space and keep Windows systems clean.

## Built With

- C#
- .NET 9
- .NET CLI
- Windows APIs
- System.ServiceProcess.ServiceController

## Features

### Temporary File Cleanup

Removes:

- User temporary files
- Windows temporary files

### Windows Update Cleanup

Cleans:

- Windows Update download cache
- Background Intelligent Transfer Service (BITS) cache

### Safe Execution

- Handles locked files gracefully
- Reports skipped files
- Requires administrator privileges for protected locations

## Getting Started

Clone the repository:

```powershell
git clone <repository-url>
cd WindowsCleanup
```

Restore dependencies:

```powershell
dotnet restore
```

## Development

Run the application from source:

```powershell
dotnet run -- --help
```

### Show Version

```powershell
dotnet run -- --version
```

### Clean User Temporary Files

```powershell
dotnet run -- --temp
```

### Clean Windows Temporary Files

Requires Administrator privileges.

```powershell
dotnet run -- --windows-temp
```

### Clean Windows Update Cache

Requires Administrator privileges.

```powershell
dotnet run -- --update-cache
```

### Run All Cleanup Tasks

Requires Administrator privileges.

```powershell
dotnet run -- --all
```

## Publishing

Create a standalone Windows executable:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

The executable will be generated here:

```
bin\Release\net9.0-windows\win-x64\publish\WindowsCleanup.exe
```

The published application is self-contained and does not require the .NET runtime to be installed.

## Running the Published Application

Navigate to the publish directory:

```powershell
cd bin\Release\net9.0-windows\win-x64\publish
```

Run:

```powershell
.\WindowsCleanup.exe --help
```

Example:

```powershell
.\WindowsCleanup.exe --all
```

## Project Structure

```
WindowsCleanup.CLI
│
├── Program.cs
│
└── Services
    ├── CleanupService.cs
    ├── WindowsUpdateService.cs
    ├── ConsoleLogger.cs
    ├── AdminService.cs
    └── AppInfo.cs
```

## Roadmap

Future improvements:

- [ ] Disk space analysis
- [ ] Before/after cleanup report
- [ ] Dry-run mode
- [ ] Browser cache cleanup
- [ ] Recycle Bin cleanup
- [ ] Windows repair tools
- [ ] Scheduled cleanup
- [ ] GUI application

## License

MIT License