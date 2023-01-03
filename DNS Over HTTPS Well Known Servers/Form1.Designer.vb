<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListServers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnAddServer = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtIPAddress = New System.Windows.Forms.TextBox()
        Me.TxtURL = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnCheckForUpdates = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BtnExportServers = New System.Windows.Forms.Button()
        Me.BtnImportServers = New System.Windows.Forms.Button()
        Me.ChkLockWindowSplitter = New System.Windows.Forms.CheckBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip.SuspendLayout()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.BtnAbout = New System.Windows.Forms.Button()
        Me.ExportSelectedDNSServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IPPic = New System.Windows.Forms.PictureBox()
        Me.URLPic = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.IPPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.URLPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DNS Over HTTPS Well Known Servers"
        '
        'ListServers
        '
        Me.ListServers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListServers.ContextMenuStrip = Me.ContextMenuStrip
        Me.ListServers.FullRowSelect = True
        Me.ListServers.HideSelection = False
        Me.ListServers.Location = New System.Drawing.Point(0, 16)
        Me.ListServers.Name = "ListServers"
        Me.ListServers.Size = New System.Drawing.Size(506, 390)
        Me.ListServers.TabIndex = 2
        Me.ListServers.UseCompatibleStateImageBehavior = False
        Me.ListServers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Server IP Address"
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "URL"
        Me.ColumnHeader2.Width = 119
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshServersToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.EditToolStripMenuItem, Me.ExportSelectedDNSServersToolStripMenuItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(222, 92)
        '
        'RefreshServersToolStripMenuItem
        '
        Me.RefreshServersToolStripMenuItem.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.refresh
        Me.RefreshServersToolStripMenuItem.Name = "RefreshServersToolStripMenuItem"
        Me.RefreshServersToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.RefreshServersToolStripMenuItem.Text = "&Refresh Servers (F5)"
        '
        'BtnAddServer
        '
        Me.BtnAddServer.Enabled = False
        Me.BtnAddServer.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.add
        Me.BtnAddServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAddServer.Location = New System.Drawing.Point(6, 81)
        Me.BtnAddServer.Name = "BtnAddServer"
        Me.BtnAddServer.Size = New System.Drawing.Size(112, 23)
        Me.BtnAddServer.TabIndex = 3
        Me.BtnAddServer.Text = "Add DOH Server"
        Me.BtnAddServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAddServer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "IP Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "URL"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIPAddress.Location = New System.Drawing.Point(0, 16)
        Me.TxtIPAddress.Name = "TxtIPAddress"
        Me.TxtIPAddress.Size = New System.Drawing.Size(205, 20)
        Me.TxtIPAddress.TabIndex = 6
        '
        'TxtURL
        '
        Me.TxtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtURL.Location = New System.Drawing.Point(0, 55)
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.Size = New System.Drawing.Size(205, 20)
        Me.TxtURL.TabIndex = 7
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.delete
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(0, 411)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(63, 23)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnEdit.Enabled = False
        Me.BtnEdit.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.edit
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.Location = New System.Drawing.Point(69, 412)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(51, 23)
        Me.BtnEdit.TabIndex = 11
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnCheckForUpdates
        '
        Me.BtnCheckForUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCheckForUpdates.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.refresh
        Me.BtnCheckForUpdates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCheckForUpdates.Location = New System.Drawing.Point(385, 412)
        Me.BtnCheckForUpdates.Name = "BtnCheckForUpdates"
        Me.BtnCheckForUpdates.Size = New System.Drawing.Size(121, 23)
        Me.BtnCheckForUpdates.TabIndex = 12
        Me.BtnCheckForUpdates.Text = "Check for Updates"
        Me.BtnCheckForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCheckForUpdates.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'BtnExportServers
        '
        Me.BtnExportServers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExportServers.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.save
        Me.BtnExportServers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportServers.Location = New System.Drawing.Point(-1, 412)
        Me.BtnExportServers.Name = "BtnExportServers"
        Me.BtnExportServers.Size = New System.Drawing.Size(100, 23)
        Me.BtnExportServers.TabIndex = 15
        Me.BtnExportServers.Text = "Export Servers"
        Me.BtnExportServers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExportServers.UseVisualStyleBackColor = True
        '
        'BtnImportServers
        '
        Me.BtnImportServers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImportServers.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.import1
        Me.BtnImportServers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImportServers.Location = New System.Drawing.Point(105, 412)
        Me.BtnImportServers.Name = "BtnImportServers"
        Me.BtnImportServers.Size = New System.Drawing.Size(100, 23)
        Me.BtnImportServers.TabIndex = 16
        Me.BtnImportServers.Text = "Import Servers"
        Me.BtnImportServers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImportServers.UseVisualStyleBackColor = True
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.delete
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.edit
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(0, 360)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(227, 23)
        Me.ProgressBar.TabIndex = 17
        Me.ProgressBar.Visible = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(5, 5)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnCheckForUpdates)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnEdit)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnDelete)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ListServers)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnAbout)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.URLPic)
        Me.SplitContainer2.Panel2.Controls.Add(Me.IPPic)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnImportServers)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnExportServers)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ProgressBar)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnAddServer)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtURL)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtIPAddress)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ChkLockWindowSplitter)
        Me.SplitContainer2.Size = New System.Drawing.Size(742, 437)
        Me.SplitContainer2.SplitterDistance = 506
        Me.SplitContainer2.SplitterWidth = 6
        Me.SplitContainer2.TabIndex = 18
        '
        'BtnAbout
        '
        Me.BtnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAbout.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.info_blue
        Me.BtnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAbout.Location = New System.Drawing.Point(321, 412)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(58, 23)
        Me.BtnAbout.TabIndex = 18
        Me.BtnAbout.Text = "About"
        Me.BtnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAbout.UseVisualStyleBackColor = True
        '
        'ExportSelectedDNSServersToolStripMenuItem
        '
        Me.ExportSelectedDNSServersToolStripMenuItem.Image = Global.DNS_Over_HTTPS_Well_Known_Servers.My.Resources.Resources.save
        Me.ExportSelectedDNSServersToolStripMenuItem.Name = "ExportSelectedDNSServersToolStripMenuItem"
        Me.ExportSelectedDNSServersToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ExportSelectedDNSServersToolStripMenuItem.Text = "Export Selected DNS Servers"
        '
        'ChkLockWindowSplitter
        '
        Me.ChkLockWindowSplitter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkLockWindowSplitter.AutoSize = True
        Me.ChkLockWindowSplitter.Location = New System.Drawing.Point(0, 389)
        Me.ChkLockWindowSplitter.Name = "ChkLockWindowSplitter"
        Me.ChkLockWindowSplitter.Size = New System.Drawing.Size(226, 17)
        Me.ChkLockWindowSplitter.TabIndex = 20
        Me.ChkLockWindowSplitter.Text = "Lock window splitter while resizing window"
        Me.ChkLockWindowSplitter.UseVisualStyleBackColor = True
        '
        'IPPic
        '
        Me.IPPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IPPic.Location = New System.Drawing.Point(211, 20)
        Me.IPPic.Name = "IPPic"
        Me.IPPic.Size = New System.Drawing.Size(16, 16)
        Me.IPPic.TabIndex = 21
        Me.IPPic.TabStop = False
        '
        'URLPic
        '
        Me.URLPic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.URLPic.Location = New System.Drawing.Point(211, 59)
        Me.URLPic.Name = "URLPic"
        Me.URLPic.Size = New System.Drawing.Size(16, 16)
        Me.URLPic.TabIndex = 22
        Me.URLPic.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 448)
        Me.Controls.Add(Me.SplitContainer2)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(763, 487)
        Me.Name = "Form1"
        Me.Text = "DNS Over HTTPS Well Known Servers"
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.IPPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.URLPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListServers As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents BtnAddServer As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtIPAddress As TextBox
    Friend WithEvents TxtURL As TextBox
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnCheckForUpdates As Button
    Friend WithEvents SaveFileDialog As Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As Windows.Forms.OpenFileDialog
    Friend WithEvents BtnExportServers As Button
    Friend WithEvents BtnImportServers As Button
    Shadows WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents RefreshServersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents ExportSelectedDNSServersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnAbout As Button
    Friend WithEvents ChkLockWindowSplitter As CheckBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents URLPic As PictureBox
    Friend WithEvents IPPic As PictureBox
End Class
