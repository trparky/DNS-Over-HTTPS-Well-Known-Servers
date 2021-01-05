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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListServers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAddServer = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtIPAddress = New System.Windows.Forms.TextBox()
        Me.TxtURL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDeviceName = New System.Windows.Forms.TextBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnCheckForUpdates = New System.Windows.Forms.Button()
        Me.ChkFlags = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BtnExportServers = New System.Windows.Forms.Button()
        Me.BtnImportServers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DNS Over HTTPS Well Known Servers"
        '
        'ListServers
        '
        Me.ListServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListServers.HideSelection = False
        Me.ListServers.Location = New System.Drawing.Point(10, 23)
        Me.ListServers.Name = "ListServers"
        Me.ListServers.Size = New System.Drawing.Size(264, 332)
        Me.ListServers.TabIndex = 2
        Me.ListServers.UseCompatibleStateImageBehavior = False
        Me.ListServers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Server IP Address"
        Me.ColumnHeader1.Width = 260
        '
        'BtnAddServer
        '
        Me.BtnAddServer.Enabled = False
        Me.BtnAddServer.Location = New System.Drawing.Point(279, 164)
        Me.BtnAddServer.Name = "BtnAddServer"
        Me.BtnAddServer.Size = New System.Drawing.Size(107, 23)
        Me.BtnAddServer.TabIndex = 3
        Me.BtnAddServer.Text = "Add DOH Server"
        Me.BtnAddServer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(279, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "IP Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(279, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "URL"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Location = New System.Drawing.Point(279, 39)
        Me.TxtIPAddress.Name = "TxtIPAddress"
        Me.TxtIPAddress.Size = New System.Drawing.Size(237, 20)
        Me.TxtIPAddress.TabIndex = 6
        '
        'TxtURL
        '
        Me.TxtURL.Location = New System.Drawing.Point(279, 77)
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.Size = New System.Drawing.Size(237, 20)
        Me.TxtURL.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(279, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Device Name (Optional)"
        '
        'TxtDeviceName
        '
        Me.TxtDeviceName.Location = New System.Drawing.Point(279, 115)
        Me.TxtDeviceName.Name = "TxtDeviceName"
        Me.TxtDeviceName.Size = New System.Drawing.Size(236, 20)
        Me.TxtDeviceName.TabIndex = 9
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Location = New System.Drawing.Point(10, 360)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(130, 23)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Enabled = False
        Me.BtnEdit.Location = New System.Drawing.Point(146, 360)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(130, 23)
        Me.BtnEdit.TabIndex = 11
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'BtnCheckForUpdates
        '
        Me.BtnCheckForUpdates.Location = New System.Drawing.Point(369, 355)
        Me.BtnCheckForUpdates.Name = "BtnCheckForUpdates"
        Me.BtnCheckForUpdates.Size = New System.Drawing.Size(144, 23)
        Me.BtnCheckForUpdates.TabIndex = 12
        Me.BtnCheckForUpdates.Text = "Check for Updates"
        Me.BtnCheckForUpdates.UseVisualStyleBackColor = True
        '
        'ChkFlags
        '
        Me.ChkFlags.AutoSize = True
        Me.ChkFlags.Location = New System.Drawing.Point(279, 141)
        Me.ChkFlags.Name = "ChkFlags"
        Me.ChkFlags.Size = New System.Drawing.Size(154, 17)
        Me.ChkFlags.TabIndex = 14
        Me.ChkFlags.Text = "Add Flags (Recommended)"
        Me.ChkFlags.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'BtnExportServers
        '
        Me.BtnExportServers.Location = New System.Drawing.Point(319, 282)
        Me.BtnExportServers.Name = "BtnExportServers"
        Me.BtnExportServers.Size = New System.Drawing.Size(94, 23)
        Me.BtnExportServers.TabIndex = 15
        Me.BtnExportServers.Text = "Export Servers"
        Me.BtnExportServers.UseVisualStyleBackColor = True
        '
        'BtnImportServers
        '
        Me.BtnImportServers.Location = New System.Drawing.Point(419, 282)
        Me.BtnImportServers.Name = "BtnImportServers"
        Me.BtnImportServers.Size = New System.Drawing.Size(94, 23)
        Me.BtnImportServers.TabIndex = 16
        Me.BtnImportServers.Text = "Import Servers"
        Me.BtnImportServers.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 390)
        Me.Controls.Add(Me.BtnImportServers)
        Me.Controls.Add(Me.BtnExportServers)
        Me.Controls.Add(Me.ChkFlags)
        Me.Controls.Add(Me.BtnCheckForUpdates)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.TxtDeviceName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtURL)
        Me.Controls.Add(Me.TxtIPAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnAddServer)
        Me.Controls.Add(Me.ListServers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "DNS Over HTTPS Well Known Servers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ListServers As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents BtnAddServer As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtIPAddress As TextBox
    Friend WithEvents TxtURL As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDeviceName As TextBox
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnCheckForUpdates As Button
    Friend WithEvents ChkFlags As CheckBox
    Friend WithEvents SaveFileDialog As Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog As Windows.Forms.OpenFileDialog
    Friend WithEvents BtnExportServers As Button
    Friend WithEvents BtnImportServers As Button
End Class
