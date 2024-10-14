Imports System.ServiceProcess
Imports System.Timers
Imports System.IO

Public Class MyNewService
    Inherits ServiceBase

    Private timer As Timer
    Private eventId As Integer = 1
    Private logFilePath As String = "C:\Logs\MyServiceLog.txt" ' Change this to the desired path

    Public Sub New()
        InitializeComponent()
        If Not EventLog.SourceExists("MyNewService") Then
            EventLog.CreateEventSource("MyNewService", "Application")
        End If

        ' Create log file directory if it doesn't exist
        If Not Directory.Exists(Path.GetDirectoryName(logFilePath)) Then
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath))
        End If
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Set up the timer
        timer = New Timer()
        timer.Interval = 60000 ' 60 seconds
        AddHandler timer.Elapsed, AddressOf Me.OnTimer ' Timer event handler
        timer.Start() ' Start the timer

        LogToFile("Service started.")
        EventLog.WriteEntry("MyNewService", "Service started successfully.", EventLogEntryType.Information, 1000) ' Unique Event ID
    End Sub

    Protected Overrides Sub OnStop()
        If timer IsNot Nothing Then
            timer.Stop()
            timer.Dispose()
        End If

        LogToFile("Service stopped.")
        EventLog.WriteEntry("MyNewService", "Service stopped successfully.", EventLogEntryType.Information, 1001) ' Unique Event ID
    End Sub

    Private Sub OnTimer(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        ' Log timer events to file and Event Viewer
        Dim message As String = $"Timer event triggered. Event ID: {eventId}. Timestamp: {DateTime.Now}."
        LogToFile(message)
        EventLog.WriteEntry("MyNewService", message, EventLogEntryType.Information, 1002 + eventId) ' Unique Event ID
        eventId += 1 ' Increment the event ID
    End Sub

    Private Sub LogToFile(ByVal message As String)
        Using writer As New StreamWriter(logFilePath, True)
            writer.WriteLine($"{DateTime.Now}: {message}")
        End Using
    End Sub
End Class
