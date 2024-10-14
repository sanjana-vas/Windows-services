Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.ServiceProcess

Public Class ProjectInstaller
    Inherits Installer

    Private serviceProcessInstaller As ServiceProcessInstaller
    Private serviceInstaller As ServiceInstaller

    Public Sub New()
        MyBase.New()

        ' Initialize the ServiceProcessInstaller
        serviceProcessInstaller = New ServiceProcessInstaller()
        serviceInstaller = New ServiceInstaller()

        ' Set the account type that the service will run under
        serviceProcessInstaller.Account = ServiceAccount.LocalSystem

        ' Set properties on the serviceInstaller
        serviceInstaller.ServiceName = "MyNewService"
        serviceInstaller.DisplayName = "My New Service"
        serviceInstaller.Description = "A sample Windows Service"
        serviceInstaller.StartType = ServiceStartMode.Automatic

        ' Add the installers to the Installer collection
        Installers.Add(serviceProcessInstaller)
        Installers.Add(serviceInstaller)
    End Sub

    Private Sub ServiceInstaller1_AfterInstall(sender As Object, e As InstallEventArgs) Handles ServiceInstaller1.AfterInstall

    End Sub
End Class
