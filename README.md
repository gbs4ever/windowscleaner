# Windows Cleanup Utility

A lightweight Windows command-line cleanup tool built with **C# and .NET 8**.

Windows Cleanup Utility helps remove unnecessary temporary files and maintenance data to recover disk space and keep Windows systems clean.

## Built With

- C#
- .NET 8
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

## Usage

Run the application:

```powershell
WindowsCleanup.exe --help
```

### Clean User Temp Files

```powershell
WindowsCleanup.exe --temp
```

### Clean Windows Temp Files

```powershell
WindowsCleanup.exe --windows-temp
```

### Clean Windows Update Cache

```powershell
WindowsCleanup.exe --update-cache
```

### Run All Cleanup Tasks

```powershell
WindowsCleanup.exe --all
```

## Development

### Requirements

- Windows 10/11
- .NET 8 SDK
- Visual Studio 2022 or VS Code

Check .NET installation:

```powershell
dotnet --version
```

## Build

Clone the repository:

```powershell
git clone <repository-url>
cd WindowsCleanup
```

Restore dependencies:

```powershell
dotnet restore
```

Build:

```powershell
dotnet build
```

Run:

```powershell
dotnet run -- --temp
```

## Publish Standalone EXE

Create a Windows executable:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

Output:

```
bin\Release\net8.0-windows\win-x64\publish\
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
    └── AdminService.cs
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