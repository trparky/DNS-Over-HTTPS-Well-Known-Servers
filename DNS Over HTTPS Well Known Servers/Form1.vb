Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServers()
    End Sub

    Private Sub LoadServers()
        ListServers.Items.Clear()

        Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", False)
            If RegistryKey IsNot Nothing Then
                For Each StrServerIP As String In RegistryKey.GetSubKeyNames()
                    ListServers.Items.Add(New ListViewItem(StrServerIP))
                Next
            Else
                MsgBox("Error loading known DNS Over HTTPS Well Known Servers from Registry.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
            End If
        End Using
    End Sub

    Private Sub BtnAddServer_Click(sender As Object, e As EventArgs) Handles BtnAddServer.Click
        Try
            Dim StrURL As String = TxtURL.Text
            If Not String.IsNullOrWhiteSpace(TxtDeviceName.Text) Then StrURL &= "/" & HttpUtility.UrlEncode(TxtDeviceName.Text)

            If BtnAddServer.Text.Equals("Add DOH Server", StringComparison.OrdinalIgnoreCase) Then
                Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", True)
                    RegistryKey.CreateSubKey(TxtIPAddress.Text)
                End Using
            End If

            Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers\" & TxtIPAddress.Text, True)
                RegistryKey.SetValue("Template", StrURL, RegistryValueKind.String)
                RegistryKey.SetValue("DeviceID", TxtDeviceName.Text, RegistryValueKind.String)
                RegistryKey.SetValue("URL", TxtURL.Text, RegistryValueKind.String)
            End Using

            If BtnAddServer.Text.Equals("Add DOH Server", StringComparison.OrdinalIgnoreCase) Then
                MsgBox("DNS Over HTTPS Server added successfully.", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
            Else
                TxtIPAddress.Enabled = True
                MsgBox("DNS Over HTTPS Server edited successfully.", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
            End If

            TxtDeviceName.Text = Nothing
            TxtIPAddress.Text = Nothing
            TxtURL.Text = Nothing
            BtnAddServer.Text = "Add DOH Server"

            LoadServers()
        Catch ex As Exception
            MsgBox("There was an error adding the DNS Over HTTPS server. Make sure you have Administrative access.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", True)
                RegistryKey.DeleteSubKeyTree(ListServers.SelectedItems(0).Text)
            End Using
        Catch ex As Exception
            MsgBox("There was an error deleting the DNS Over HTTPS server. Make sure you have Administrative access.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
        End Try
    End Sub

    Private Sub TxtIPAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtIPAddress.TextChanged
        ActivateAddServerButton()
    End Sub

    Private Sub TxtURL_TextChanged(sender As Object, e As EventArgs) Handles TxtURL.TextChanged
        ActivateAddServerButton()
    End Sub

    Private Sub TxtDeviceName_TextChanged(sender As Object, e As EventArgs) Handles TxtDeviceName.TextChanged
        ActivateAddServerButton()
    End Sub

    Private Sub ActivateAddServerButton()
        BtnAddServer.Enabled = Not String.IsNullOrWhiteSpace(TxtDeviceName.Text) And Not String.IsNullOrWhiteSpace(TxtURL.Text) And Not String.IsNullOrWhiteSpace(TxtDeviceName.Text)
    End Sub

    Private Sub ListServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListServers.SelectedIndexChanged
        If ListServers.SelectedItems.Count = 0 Then
            BtnDelete.Enabled = False
            BtnEdit.Enabled = False
        Else
            BtnDelete.Enabled = True
            BtnEdit.Enabled = True
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        TxtURL.Text = Nothing
        TxtDeviceName.Text = Nothing
        TxtIPAddress.Text = Nothing

        Try
            Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers\" & ListServers.SelectedItems(0).Text, True)
                Dim StrTemplate As String = RegistryKey.GetValue("Template", Nothing)

                If Not String.IsNullOrWhiteSpace(StrTemplate) Then
                    Dim StrURL As String = RegistryKey.GetValue("URL", Nothing)
                    Dim StrDeviceID As String = RegistryKey.GetValue("DeviceID", Nothing)

                    TxtIPAddress.Text = ListServers.SelectedItems(0).Text
                    TxtIPAddress.Enabled = False

                    If String.IsNullOrWhiteSpace(StrURL) Or String.IsNullOrWhiteSpace(StrDeviceID) Then
                        TxtURL.Text = HttpUtility.UrlDecode(StrTemplate)
                    Else
                        TxtURL.Text = StrURL
                        TxtDeviceName.Text = StrDeviceID
                    End If

                    BtnAddServer.Text = "Edit DOH Server"
                End If
            End Using
        Catch ex As Exception
            MsgBox("There was an error editing the DNS Over HTTPS server. Make sure you have Administrative access.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
        End Try
    End Sub
End Class