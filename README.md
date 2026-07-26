# Windows Cleanup Utility

A lightweight Windows command-line cleanup tool built with **C# and .NET 9**.

Windows Cleanup Utility helps remove unnecessary temporary files and Windows maintenance data to recover disk space and keep Windows systems clean.

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

---

# Getting Started

## Requirements

- Windows 10 or Windows 11
- .NET 9 SDK
- PowerShell

Verify your .NET installation:

```powershell
dotnet --version
```

## Clone Repository

```powershell
git clone <repository-url>
cd WindowsCleanup
```

Restore dependencies:

```powershell
dotnet restore
```

---

# Development

Run the application from source:

```powershell
dotnet run -- --help
```

## Commands

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

---

# Publishing

The project includes a PowerShell publish script that creates a portable Windows executable.

Run:

```powershell
.\scripts\publish.ps1
```

The script will:

- Clean previous builds
- Build the application in Release mode
- Publish a self-contained Windows executable
- Create a portable output folder
- Copy the README with the executable

The output will be:

```
publish\
│
├── WindowsCleanup.exe
└── README.md
```

The published application is self-contained and does not require the .NET runtime to be installed.

---

# First Time PowerShell Script Warning

Windows may block PowerShell scripts by default.

If you receive:

```
running scripts is disabled on this system
```

enable locally created scripts by running:

```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

After confirming the change, close and reopen PowerShell.

This is a one-time setup for your development environment.

Then run:

```powershell
.\scripts\publish.ps1
```

---

# Running the Published Application

After publishing:

```powershell
cd .\publish
```

Display help:

```powershell
.\WindowsCleanup.exe --help
```

Show version:

```powershell
.\WindowsCleanup.exe --version
```
Run all cleanup tasks:

> Requires Administrator privileges.

```powershell
.\WindowsCleanup.exe --all
```

---

# Project Structure

```
WindowsCleanup.CLI
│
├── Program.cs
│
├── scripts
│   └── publish.ps1
│
└── Services
    ├── CleanupService.cs
    ├── WindowsUpdateService.cs
    ├── ConsoleLogger.cs
    ├── AdminService.cs
    └── AppInfo.cs
```

---

# Versioning

The application version is managed through the project file:
Display the current version:

```powershell
.\WindowsCleanup.exe --version
```

---

# Roadmap

Future improvements:

- [ ] Disk space analysis
- [ ] Before/after cleanup report
- [ ] Dry-run mode
- [ ] Browser cache cleanup
- [ ] Recycle Bin cleanup
- [ ] Windows repair tools
- [ ] Scheduled cleanup
- [ ] GUI application
- [ ] Windows installer package

---

# License

MIT License