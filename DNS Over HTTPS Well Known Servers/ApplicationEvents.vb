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
            If Environment.OSVersion.Version.Build <= 19042 Then
                ' This message will change when the version of Windows 10 that natively supports DoH is released publically.
                WPFCustomMessageBox.CustomMessageBox.ShowOK("This version of Windows 10 is not supported. Currently only versions in the Windows Insider Program are supported." & vbCrLf & vbCrLf & "This program will now close.", "DNS Over HTTPS Well Known Servers", strOK, Windows.MessageBoxImage.Error)
                e.Cancel = True
                Exit Sub
            End If

            If Application.CommandLineArgs.Count = 1 Then
                Dim commandLineArgument As String = Application.CommandLineArgs(0).Trim
                If commandLineArgument.Equals("-update", StringComparison.OrdinalIgnoreCase) Then DoUpdateAtStartup()
            End If
        End Sub
    End Class
End Namespace
