MyWindowsService is a simple windows service application built using VB.NET. The service logs messages at regular intervals into both windows Event Viewer and a local log fike.
This service is intended to intended to demonstrate how to work with event logging, timers, and Windows Services using the .NET framework.

FEATURES:
- Automatic Logging: Logs messages into a file and the Windows Event Viewer.
- Timer Events:Triggers a logging event every 60 seconds.
- Windows Event Logging: Creates a source in the Windows Event Viewer under the "Application" log with event IDs.
- Log File:Maintains a log of timer-triggered events in a local file (`C:\Logs\MyServiceLog.txt`).

INSTALLATION AND SETUP:

Prerequisites:
- Visual Studio 2022 (or later) with .NET Framework development enabled.
- Windows operating system (to run the Windows Service).
- Administrator privileges (to install and start the service).

Steps to Install the Service:

1. Build the Service:
    - Open the project in **Visual Studio**.
    - Build the solution using `Build > Build Solution`.

2. Install the Service:
    - Open **Command Prompt** as Administrator.
    - Use the following command to install the service from Developers command prompt (VS):
    - IntsallUtil.exe MywindowsService.exe
     
     
3. Start the Service:
    - Start the service using the following command from Command Prompt;
    - net start MyNewService
      

4. Check Logs:
    - Check the **Event Viewer** (under `Windows Logs > Application`) for entries from `MyNewService`.
    - Also, check the log file located at `C:\Logs\MyServiceLog.txt` (or the path where you kept your log file in your computer)

 Uninstall the Service
To uninstall the service, stop and delete it using the following commands:
To stop from command prompt: net stop MyNewService
On Developers command prompt: IntsallUtil.exe /u MywindowsSerice.exe

## Event Logging Details
The service writes the following entries to the Windows Event Viewer:
- **Service Start:** Logs when the service starts.
- **Service Stop:** Logs when the service stops.
- **Timer Trigger:** Logs every minute, with an incrementing event ID.
