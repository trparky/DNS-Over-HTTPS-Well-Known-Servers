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
                If Not String.IsNullOrWhiteSpace(TxtDeviceName.Text) Then RegistryKey.SetValue("DeviceID", TxtDeviceName.Text, RegistryValueKind.String)
                RegistryKey.SetValue("URL", TxtURL.Text, RegistryValueKind.String)
                If ChkFlags.Checked Then RegistryKey.SetValue("Flags", 0, RegistryValueKind.DWord)
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
        BtnAddServer.Enabled = Not String.IsNullOrWhiteSpace(TxtURL.Text) And Not String.IsNullOrWhiteSpace(TxtIPAddress.Text)
    End Sub

    Private Sub ListServers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListServers.SelectedIndexChanged
        If ListServers.SelectedItems.Count = 0 Then
            BtnDelete.Enabled = False
            BtnEdit.Enabled = False
        Else
            BtnDelete.Enabled = True
            BtnEdit.Enabled = True
        End If

        TxtURL.Text = Nothing
        TxtDeviceName.Text = Nothing
        TxtIPAddress.Text = Nothing
        TxtIPAddress.Enabled = True
        ChkFlags.Checked = False
        BtnAddServer.Text = "Add DOH Server"
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        TxtURL.Text = Nothing
        TxtDeviceName.Text = Nothing
        TxtIPAddress.Text = Nothing
        ChkFlags.Checked = False

        Try
            Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers\" & ListServers.SelectedItems(0).Text, True)
                Dim StrTemplate As String = RegistryKey.GetValue("Template", Nothing)

                If Not String.IsNullOrWhiteSpace(StrTemplate) Then
                    Dim StrURL As String = RegistryKey.GetValue("URL", Nothing)
                    Dim StrDeviceID As String = RegistryKey.GetValue("DeviceID", Nothing)

                    If RegistryKey.GetValue("Flags", Nothing) IsNot Nothing Then ChkFlags.Checked = True

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

    Private Sub BtnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles BtnCheckForUpdates.Click
        Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                   Dim checkForUpdatesClassObject As New Check_for_Update_Stuff(Me)
                                                   checkForUpdatesClassObject.CheckForUpdates()
                                               End Sub)
    End Sub

    Public Structure ExportedData
        Public Template, DeviceID, URL, IPAddress As String
        Public Flags As Integer
    End Structure

    Private Sub BtnExportServers_Click(sender As Object, e As EventArgs) Handles BtnExportServers.Click
        Dim DohServers As New List(Of ExportedData)
        Dim ExportedData As ExportedData
        Dim Template, DeviceID, URL As String
        Dim Flags As Integer

        Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", False)
            If RegistryKey IsNot Nothing Then
                For Each StrServerIP As String In RegistryKey.GetSubKeyNames()
                    Using RegistryKey2 As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers\" & StrServerIP, False)
                        Template = RegistryKey2.GetValue("Template", Nothing)
                        DeviceID = RegistryKey2.GetValue("DeviceID", Nothing)
                        URL = RegistryKey2.GetValue("URL", Nothing)
                        Flags = RegistryKey2.GetValue("Flags", -1)

                        If Not String.IsNullOrWhiteSpace(Template) Then
                            ExportedData = New ExportedData() With {
                                .Template = Template,
                                .DeviceID = If(String.IsNullOrWhiteSpace(DeviceID), "", DeviceID),
                                .URL = If(String.IsNullOrWhiteSpace(URL), "", URL),
                                .Flags = Flags,
                                .IPAddress = StrServerIP
                            }
                            DohServers.Add(ExportedData)
                        End If
                    End Using
                Next

                With SaveFileDialog
                    .Filter = "XML File|*.xml"
                    .Title = "Save DoH Servers to XML File"
                    .FileName = Nothing
                End With

                If SaveFileDialog.ShowDialog = DialogResult.OK Then
                    Using memoryStream As New IO.MemoryStream
                        Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(DohServers.GetType)
                        xmlSerializerObject.Serialize(memoryStream, DohServers)

                        Using fileStream As New IO.FileStream(SaveFileDialog.FileName, IO.FileMode.Create, IO.FileAccess.ReadWrite)
                            memoryStream.WriteTo(fileStream)
                        End Using

                        MsgBox("Export complete!", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
                    End Using
                End If
            Else
                MsgBox("Error loading known DNS Over HTTPS Well Known Servers from Registry.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
            End If
        End Using
    End Sub

    Private Sub BtnImportServers_Click(sender As Object, e As EventArgs) Handles BtnImportServers.Click
        Dim RegistryKey2 As RegistryKey

        With OpenFileDialog
            .Filter = "XML File|*.xml"
            .Title = "Import DoH Servers from XML File"
            .FileName = Nothing
        End With

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            Dim DohServers As New List(Of ExportedData)

            Using streamReader As New IO.StreamReader(OpenFileDialog.FileName)
                Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(DohServers.GetType)
                DohServers = xmlSerializerObject.Deserialize(streamReader)
            End Using

            If DohServers.Count <> 0 Then
                Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", True)
                    For Each SubKeyName As String In RegistryKey.GetSubKeyNames()
                        RegistryKey.DeleteSubKeyTree(SubKeyName)
                    Next

                    For Each DohServer As ExportedData In DohServers
                        RegistryKey2 = RegistryKey.CreateSubKey(DohServer.IPAddress)
                        RegistryKey2.SetValue("Template", DohServer.Template, RegistryValueKind.String)
                        If Not String.IsNullOrWhiteSpace(DohServer.DeviceID) Then RegistryKey2.SetValue("DeviceID", DohServer.DeviceID, RegistryValueKind.String)
                        If Not String.IsNullOrWhiteSpace(DohServer.URL) Then RegistryKey2.SetValue("URL", DohServer.URL, RegistryValueKind.String)
                        If DohServer.Flags <> -1 Then RegistryKey2.SetValue("Flags", DohServer.Flags, RegistryValueKind.DWord)
                    Next
                End Using
            End If
        End If

        LoadServers()
    End Sub

    Private Sub RefreshServersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshServersToolStripMenuItem.Click
        LoadServers()
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then LoadServers()
    End Sub
End Class