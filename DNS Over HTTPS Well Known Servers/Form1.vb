Imports System.Text.RegularExpressions
Imports DNS_Over_HTTPS_Well_Known_Servers.Form1

Public Class Form1
    Private ReadOnly servers As New Dictionary(Of String, String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServers()
    End Sub

    Private Sub LoadServers()
        ListServers.Items.Clear()
        servers.Clear()

        Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", False)
            If RegistryKey IsNot Nothing Then
                For Each StrServerIP As String In RegistryKey.GetSubKeyNames()
                    servers.Add(StrServerIP, RegistryKey.OpenSubKey(StrServerIP).GetValue("Template"))
                    ListServers.Items.Add(New ListViewItem(StrServerIP))
                Next
            Else
                MsgBox("Error loading known DNS Over HTTPS Well Known Servers from Registry.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
            End If
        End Using
    End Sub

    Private Sub DeleteDNSServer(ip As String)
        Using process As New Process With {
            .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = "netsh",
                    .Arguments = $"dns delete encryption {ip}"
                }
            }
            process.Start()
        End Using
    End Sub

    Private Sub AddDNSServer(ip As String, url As String)
        Using process As New Process With {
            .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = "netsh",
                    .Arguments = $"dns add encryption {ip} {url}"
                }
            }
            process.Start()
        End Using
    End Sub

    Private Sub AddDNSServer(exportedData As ExportedData)
        Using process As New Process With {
            .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = "netsh",
                    .Arguments = $"dns add encryption {exportedData.IP} {exportedData.URL}"
                }
            }
            process.Start()
        End Using
    End Sub

    Private Sub AddOrUpdateDNSServer(ip As String, url As String)
        If DoesDNSServerExist(ip) Then
            DeleteDNSServer(ip)
            AddDNSServer(ip, url)
        Else
            AddDNSServer(ip, url)
        End If
    End Sub

    Private Function DoesDNSServerExist(ip As String) As Boolean
        Dim KeyValuePair As KeyValuePair(Of String, String) = servers.FirstOrDefault(Function(item As KeyValuePair(Of String, String)) item.Key.Trim.Equals(ip, StringComparison.OrdinalIgnoreCase))
        Return KeyValuePair.Value IsNot Nothing
    End Function

    Private Sub BtnAddServer_Click(sender As Object, e As EventArgs) Handles BtnAddServer.Click
        Try
            AddOrUpdateDNSServer(TxtIPAddress.Text, TxtURL.Text)

            If BtnAddServer.Text.Equals("Add DOH Server", StringComparison.OrdinalIgnoreCase) Then
                MsgBox("DNS Over HTTPS Server added successfully.", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
            Else
                TxtIPAddress.Enabled = True
                MsgBox("DNS Over HTTPS Server edited successfully.", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
            End If

            TxtIPAddress.Text = Nothing
            TxtURL.Text = Nothing
            BtnAddServer.Text = "Add DOH Server"

            LoadServers()
        Catch ex As Exception
            MsgBox("There was an error adding the DNS Over HTTPS server. Make sure you have Administrative access.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteDNSServer(ListServers.SelectedItems(0).Text)
        LoadServers()
    End Sub

    Private Sub TxtIPAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtIPAddress.TextChanged
        ActivateAddServerButton()
    End Sub

    Private Sub TxtURL_TextChanged(sender As Object, e As EventArgs) Handles TxtURL.TextChanged
        ActivateAddServerButton()
    End Sub

    Private Sub TxtDeviceName_TextChanged(sender As Object, e As EventArgs)
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
        TxtIPAddress.Text = Nothing
        TxtIPAddress.Enabled = True
        BtnAddServer.Text = "Add DOH Server"
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        TxtURL.Text = Nothing
        TxtIPAddress.Text = Nothing

        TxtIPAddress.Text = ListServers.SelectedItems(0).Text
        TxtURL.Text = servers(TxtIPAddress.Text)
        BtnAddServer.Text = "Edit DOH Server"
    End Sub

    Private Sub BtnCheckForUpdates_Click(sender As Object, e As EventArgs) Handles BtnCheckForUpdates.Click
        Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                   Dim checkForUpdatesClassObject As New Check_for_Update_Stuff(Me)
                                                   checkForUpdatesClassObject.CheckForUpdates()
                                               End Sub)
    End Sub

    Public Structure ExportedData
        Public IP, URL As String
    End Structure

    Private Sub BtnExportServers_Click(sender As Object, e As EventArgs) Handles BtnExportServers.Click
        Dim DohServers As New List(Of ExportedData)
        Dim ExportedData As ExportedData

        For Each item As KeyValuePair(Of String, String) In servers
            ExportedData = New ExportedData() With {
                .IP = item.Key,
                .URL = item.Value
            }
            DohServers.Add(ExportedData)
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
    End Sub

    Private Sub BtnImportServers_Click(sender As Object, e As EventArgs) Handles BtnImportServers.Click
        With OpenFileDialog
            .Filter = "XML File|*.xml"
            .Title = "Import DoH Servers from XML File"
            .FileName = Nothing
        End With

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            Dim importedDoHServers As New List(Of ExportedData)

            Using streamReader As New IO.StreamReader(OpenFileDialog.FileName)
                Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(importedDoHServers.GetType)
                importedDoHServers = xmlSerializerObject.Deserialize(streamReader)
            End Using

            If importedDoHServers.Count <> 0 Then
                For Each item As KeyValuePair(Of String, String) In servers
                    DeleteDNSServer(item.Key)
                Next

                For Each item As ExportedData In importedDoHServers
                    AddDNSServer(item)
                Next
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

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        BtnDelete.PerformClick()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        BtnEdit.PerformClick()
    End Sub
End Class