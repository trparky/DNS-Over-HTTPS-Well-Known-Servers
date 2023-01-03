Imports System.Net
Imports System.Text.RegularExpressions

Public Class Form1
    Private ReadOnly servers As New Dictionary(Of String, String)
    Private boolDoneLoading As Boolean = False
    Private oldSplitterDistance As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServers()
        ColumnHeader1.Width = My.Settings.ipColumnSize
        ColumnHeader2.Width = My.Settings.urlColumnSize
        Size = My.Settings.windowSize
        If My.Settings.splitterDistance < 506 Then My.Settings.splitterDistance = 506
        SplitContainer2.SplitterDistance = My.Settings.splitterDistance
        ChkLockWindowSplitter.Checked = My.Settings.lockWindowSplitter
        boolDoneLoading = True
    End Sub

    Private Function ValidateURL(url As String) As Boolean
        Return Regex.IsMatch(url, "\A(?:\bhttps://[.0-9a-z-]+[]!""#$%&'()*+,./0-9:;<=>?@[\\_`a-z{|}~^-]*/[]!""#$%&'()*+,.0-9:;<=>?@[\\_`a-z{|}~^-]+)\Z", RegexOptions.IgnoreCase)
    End Function

    Private Function ValidateIP(ip As String) As Boolean
        Dim ipaddress As IPAddress = Nothing
        Return IPAddress.TryParse(ip, ipaddress)
    End Function

    ''' <summary>
    ''' This function works very similar to the Invoke function that's already built into .NET. The only difference
    ''' is that this function checks to see if an invoke is required and only invokes the passed routine on the
    ''' main thread if it's required. If not, the passed routine is executed on the thread that the call
    ''' originated from. Also, if the program is closing the function aborts itself so as to prevent
    ''' System.InvalidOperationException upon program close.
    ''' </summary>
    ''' <param name="input"></param>
    Private Sub MyInvoke(input As [Delegate])
        If InvokeRequired() Then
            Invoke(input)
        Else
            input.DynamicInvoke()
        End If
    End Sub

    ''' <summary>
    ''' Loads the DNS over HTTPS servers from the system registry, it's much easier to do this than trying to parse the output of the netsh command.
    ''' Everything else is done via the netsh command since simply adding the appropriate registry entries appears to not be enough.
    ''' </summary>
    Private Sub LoadServers()
        ListServers.Items.Clear()
        servers.Clear()

        Dim url As String
        Dim listViewItem As ListViewItem

        Using RegistryKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers", False)
            If RegistryKey IsNot Nothing Then
                For Each StrServerIP As String In RegistryKey.GetSubKeyNames()
                    url = RegistryKey.OpenSubKey(StrServerIP).GetValue("Template", Nothing)

                    If Not String.IsNullOrWhiteSpace(url) Then
                        servers.Add(StrServerIP, url)

                        listViewItem = New ListViewItem(StrServerIP)
                        listViewItem.SubItems.Add(url)
                        ListServers.Items.Add(listViewItem)
                    End If
                Next
            Else
                MsgBox("Error loading known DNS Over HTTPS Well Known Servers from Registry.", MsgBoxStyle.Critical, "DNS Over HTTPS Well Known Servers")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Deletes an encrypted DNS over HTTPS server from the system.
    ''' </summary>
    ''' <param name="ip">The IP of the DNS server you want to delete.</param>
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
            process.WaitForExit()
        End Using
    End Sub

    ''' <summary>
    ''' Adds an encrypted DNS over HTTPS server to the system.
    ''' </summary>
    ''' <param name="ip">The IP of DNS server.</param>
    ''' <param name="url">The URL for the DNS over HTTPS Server.</param>
    Private Sub AddDNSServer(ip As String, url As String)
        Using process As New Process With {
            .StartInfo = New ProcessStartInfo With {
                    .UseShellExecute = False,
                    .CreateNoWindow = True,
                    .FileName = "netsh",
                    .Arguments = $"dns add encryption server={ip} dohtemplate={url} autoupgrade=yes udpfallback=no"
                }
            }
            process.Start()
            process.WaitForExit()
        End Using
    End Sub

    ''' <summary>
    ''' Adds or updates an existing DNS over HTTPS server.
    ''' </summary>
    ''' <param name="ip">The IP of DNS server.</param>
    ''' <param name="url">The URL for the DNS over HTTPS Server.</param>
    Private Sub AddOrUpdateDNSServer(ip As String, url As String)
        If DoesDNSServerExist(ip) Then
            DeleteDNSServer(ip)
            AddDNSServer(ip, url)
        Else
            AddDNSServer(ip, url)
        End If
    End Sub

    ''' <summary>
    ''' Checks to see if a DNS over HTTPS server exists on the system.
    ''' </summary>
    ''' <param name="ip">The IP of DNS server.</param>
    ''' <returns></returns>
    Private Function DoesDNSServerExist(ip As String) As Boolean
        Return Registry.LocalMachine.OpenSubKey($"SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers\{ip}", False) IsNot Nothing
    End Function

    Private Sub BtnAddServer_Click(sender As Object, e As EventArgs) Handles BtnAddServer.Click
        Try
            ' Does some validation of user input before passing data to a function that executes a command line.
            If Not ValidateIP(TxtIPAddress.Text) Then
                MsgBox("Invalid IP Address Input.", MsgBoxStyle.Critical, Text)
                Exit Sub
            End If
            If Not ValidateURL(TxtURL.Text) Then
                MsgBox("Invalid URL Input.", MsgBoxStyle.Critical, Text)
                Exit Sub
            End If
            ' Does some validation of user input before passing data to a function that executes a command line.

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
        If MsgBox($"Are you sure you want to delete the DNS Server Entry for ""{ListServers.SelectedItems(0).Text}""?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton2, Text) = MsgBoxResult.Yes Then
            DeleteDNSServer(ListServers.SelectedItems(0).Text)
            LoadServers()
            MsgBox($"The DNS Server Entry for ""{ListServers.SelectedItems(0).Text}"" has been deleted.", MsgBoxStyle.Information, Text)
        Else
            MsgBox($"The DNS Server Entry for ""{ListServers.SelectedItems(0).Text}"" has NOT been deleted.", MsgBoxStyle.Information, Text)
        End If
    End Sub

    Private Sub TxtIPAddress_TextChanged(sender As Object, e As EventArgs) Handles TxtIPAddress.TextChanged
        If String.IsNullOrWhiteSpace(TxtIPAddress.Text) Then
            ToolTip.SetToolTip(TxtIPAddress, Nothing)
            ToolTip.SetToolTip(IPPic, Nothing)
            IPPic.Image = Nothing
        Else
            If ValidateIP(TxtIPAddress.Text) Then
                ToolTip.SetToolTip(TxtIPAddress, "Valid IP")
                ToolTip.SetToolTip(IPPic, "Valid IP")
                IPPic.Image = My.Resources.ok
            Else
                ToolTip.SetToolTip(TxtIPAddress, "Invalid IP")
                ToolTip.SetToolTip(IPPic, "Invalid IP")
                IPPic.Image = My.Resources.bad
            End If
        End If
        ActivateAddServerButton()
    End Sub

    Private Sub TxtURL_TextChanged(sender As Object, e As EventArgs) Handles TxtURL.TextChanged
        If String.IsNullOrWhiteSpace(TxtURL.Text) Then
            ToolTip.SetToolTip(TxtURL, Nothing)
            ToolTip.SetToolTip(URLPic, Nothing)
            URLPic.Image = Nothing
        Else
            If ValidateURL(TxtURL.Text) Then
                ToolTip.SetToolTip(TxtURL, "Valid URL")
                ToolTip.SetToolTip(URLPic, "Valid URL")
                URLPic.Image = My.Resources.ok
            Else
                ToolTip.SetToolTip(TxtURL, "Invalid URL")
                ToolTip.SetToolTip(URLPic, "Invalid URL")
                URLPic.Image = My.Resources.bad
            End If
        End If
        ActivateAddServerButton()
    End Sub

    Private Sub ActivateAddServerButton()
        BtnAddServer.Enabled = Not String.IsNullOrWhiteSpace(TxtURL.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtIPAddress.Text) AndAlso ValidateIP(TxtIPAddress.Text) AndAlso ValidateURL(TxtURL.Text)
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
        Public boolPartialExport As Boolean
        Public DoHServers As List(Of DoHServer)
    End Structure

    Public Structure DoHServer
        Public IP, URL As String
    End Structure

    Private Sub BtnExportServers_Click(sender As Object, e As EventArgs) Handles BtnExportServers.Click
        If MsgBox($"This kind of export will be treated as a full export by this program and upon import will erase all existing DoH Servers on the system.{vbCrLf}{vbCrLf}Are you sure you want to do this kind of export?{vbCrLf}{vbCrLf}NOTE: Partial exports can be performed by selecting servers in the DoH Server list and right-clicking on the list. Partial exports will be treated differently by this program in which it will only overwrite the entries in the exported file.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Text) = MsgBoxResult.No Then Exit Sub

        Dim ExportedData As New ExportedData
        Dim DohServers As New List(Of DoHServer)
        Dim DoHServer As DoHServer

        For Each item As KeyValuePair(Of String, String) In servers
            DoHServer = New DoHServer() With {
                .IP = item.Key,
                .URL = item.Value
            }
            DohServers.Add(DoHServer)
        Next

        ExportedData.boolPartialExport = False
        ExportedData.DoHServers = DohServers

        With SaveFileDialog
            .Filter = "XML File|*.xml"
            .Title = "Save DoH Servers to XML File"
            .FileName = Nothing
        End With

        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            Using memoryStream As New IO.MemoryStream
                Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(ExportedData.GetType)
                xmlSerializerObject.Serialize(memoryStream, ExportedData)

                Using fileStream As New IO.FileStream(SaveFileDialog.FileName, IO.FileMode.Create, IO.FileAccess.ReadWrite)
                    memoryStream.WriteTo(fileStream)
                End Using

                MsgBox("Full Export complete!", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
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
            Dim thread As New Threading.Thread(Sub()
                                                   Dim ExportedData As New ExportedData

                                                   Using streamReader As New IO.StreamReader(OpenFileDialog.FileName)
                                                       Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(ExportedData.GetType)
                                                       ExportedData = xmlSerializerObject.Deserialize(streamReader)
                                                   End Using

                                                   If ExportedData.DoHServers.Count <> 0 Then
                                                       MyInvoke(Sub()
                                                                    ProgressBar.Visible = True
                                                                    ProgressBar.Value = 0
                                                                    ProgressBar.Maximum = ExportedData.DoHServers.Count * 2
                                                                End Sub)

                                                       If ExportedData.boolPartialExport Then
                                                           ' This erases only the DoH Servers that are mentioned in the imported XML file.
                                                           For Each item As DoHServer In ExportedData.DoHServers
                                                               ' Does some validation of user input before passing data to a function that executes a command line.
                                                               If ValidateIP(item.IP) Then DeleteDNSServer(item.IP)
                                                               MyInvoke(Sub() ProgressBar.Value += 1)
                                                           Next
                                                       Else
                                                           ' This erases all existing DoH Servers on the system.
                                                           For Each item As KeyValuePair(Of String, String) In servers
                                                               DeleteDNSServer(item.Key)
                                                               MyInvoke(Sub() ProgressBar.Value += 1)
                                                           Next
                                                       End If

                                                       For Each item As DoHServer In ExportedData.DoHServers
                                                           ' Does some validation of user input before passing data to a function that executes a command line.
                                                           If ValidateIP(item.IP) AndAlso ValidateURL(item.URL) Then AddDNSServer(item.IP, item.URL)
                                                           MyInvoke(Sub() ProgressBar.Value += 1)
                                                       Next
                                                   End If

                                                   MyInvoke(Sub()
                                                                ProgressBar.Visible = False
                                                                ProgressBar.Value = 0
                                                                ProgressBar.Maximum = 0
                                                                LoadServers()
                                                                MsgBox($"{If(ExportedData.boolPartialExport, "Partial", "Full")} Import complete!", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
                                                            End Sub)
                                               End Sub)
            thread.SetApartmentState(Threading.ApartmentState.STA)
            thread.Start()
        Else
            MsgBox("Import cancelled.", MsgBoxStyle.Information, Text)
            Exit Sub
        End If
    End Sub

    Private Sub RefreshServersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshServersToolStripMenuItem.Click
        LoadServers()
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            LoadServers()
        ElseIf e.KeyCode = Keys.Delete Then
            BtnDelete.PerformClick()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        BtnDelete.PerformClick()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        BtnEdit.PerformClick()
    End Sub

    Private Sub ListServers_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs) Handles ListServers.ColumnWidthChanged
        If boolDoneLoading Then
            My.Settings.ipColumnSize = ColumnHeader1.Width
            My.Settings.urlColumnSize = ColumnHeader2.Width
        End If
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If SplitContainer2.SplitterDistance < 506 Then SplitContainer2.SplitterDistance = 506
        If boolDoneLoading Then
            My.Settings.windowSize = Size
            My.Settings.splitterDistance = SplitContainer2.SplitterDistance
        End If
    End Sub

    Private Sub SplitContainer2_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer2.SplitterMoved
        If SplitContainer2.SplitterDistance < 506 Then SplitContainer2.SplitterDistance = 506
        If boolDoneLoading Then My.Settings.splitterDistance = SplitContainer2.SplitterDistance
    End Sub

    Private Sub ExportSelectedDNSServersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSelectedDNSServersToolStripMenuItem.Click
        Dim ExportedData As New ExportedData
        Dim DohServers As New List(Of DoHServer)
        Dim DoHServer As DoHServer

        For Each item As ListViewItem In ListServers.SelectedItems
            DoHServer = New DoHServer() With {
                .IP = item.SubItems(0).Text,
                .URL = item.SubItems(1).Text
            }
            DohServers.Add(DoHServer)
        Next

        ExportedData.boolPartialExport = True
        ExportedData.DoHServers = DohServers

        With SaveFileDialog
            .Filter = "XML File|*.xml"
            .Title = "Save DoH Servers to XML File"
            .FileName = Nothing
        End With

        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            Using memoryStream As New IO.MemoryStream
                Dim xmlSerializerObject As New Xml.Serialization.XmlSerializer(ExportedData.GetType)
                xmlSerializerObject.Serialize(memoryStream, ExportedData)

                Using fileStream As New IO.FileStream(SaveFileDialog.FileName, IO.FileMode.Create, IO.FileAccess.ReadWrite)
                    memoryStream.WriteTo(fileStream)
                End Using

                MsgBox("Partial Export complete!", MsgBoxStyle.Information, "DNS Over HTTPS Well Known Servers")
            End Using
        End If
    End Sub

    Private Sub ContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip.Opening
        If ListServers.SelectedItems.Count = 0 Then
            ExportSelectedDNSServersToolStripMenuItem.Visible = False
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
        Else
            ExportSelectedDNSServersToolStripMenuItem.Visible = True
            EditToolStripMenuItem.Visible = True
            DeleteToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles BtnAbout.Click
        Dim version() As String = Application.ProductVersion.Split(".".ToCharArray) ' Gets the program version
        Dim stringBuilder As New Text.StringBuilder

        With stringBuilder
            .AppendLine(Text)
            .AppendLine("Written By Tom Parkison")
            .AppendLine("Copyright Thomas Parkison 2012-2023.")
            .AppendLine()
            .AppendFormat("Version {0}.{1} Build {2}", version(0), version(1), version(2))
        End With

        MsgBox(stringBuilder.ToString.Trim, MsgBoxStyle.Information, $"About {Text}")
    End Sub

    Private Sub ListServers_DoubleClick(sender As Object, e As EventArgs) Handles ListServers.DoubleClick
        BtnEdit.PerformClick()
    End Sub

    Private Sub Form1_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        If ChkLockWindowSplitter.Checked Then oldSplitterDistance = SplitContainer2.SplitterDistance
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If ChkLockWindowSplitter.Checked Then SplitContainer2.SplitterDistance = oldSplitterDistance
    End Sub

    Private Sub ChkLockWindowSplitter_Click(sender As Object, e As EventArgs) Handles ChkLockWindowSplitter.Click
        My.Settings.lockWindowSplitter = ChkLockWindowSplitter.Checked
    End Sub

    Private Sub ListServers_KeyUp(sender As Object, e As KeyEventArgs) Handles ListServers.KeyUp
        If e.KeyCode = Keys.Enter Then BtnEdit.PerformClick()
    End Sub

    Private Sub TxtURL_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtURL.KeyUp
        If e.KeyCode = Keys.Enter Then BtnAddServer.PerformClick()
        e.Handled = True
    End Sub

    Private Sub TxtIPAddress_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtIPAddress.KeyUp
        If e.KeyCode = Keys.Enter Then BtnAddServer.PerformClick()
        e.Handled = True
    End Sub
End Class