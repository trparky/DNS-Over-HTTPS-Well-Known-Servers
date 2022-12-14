Imports System.Security.Principal
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If Application.CommandLineArgs.Count = 1 Then
                Dim commandLineArgument As String = Application.CommandLineArgs(0).Trim
                If commandLineArgument.Equals("-update", StringComparison.OrdinalIgnoreCase) Then DoUpdateAtStartup()
            End If

            If Not AreWeAnAdministrator() Then
                MsgBox("This program requires administrator privileges to function, please make sure that this program is ran with administrator privileges.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
                e.Cancel = True
                Exit Sub
            End If
        End Sub

        Private Function AreWeAnAdministrator() As Boolean
            Try
                Dim principal As New WindowsPrincipal(WindowsIdentity.GetCurrent())
                Return principal.IsInRole(WindowsBuiltInRole.Administrator)
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class
End Namespace
