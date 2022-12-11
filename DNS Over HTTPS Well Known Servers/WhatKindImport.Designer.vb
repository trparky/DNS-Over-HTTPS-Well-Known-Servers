<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhatKindImport
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
        Me.BtnFullImport = New System.Windows.Forms.Button()
        Me.BtnPartialImport = New System.Windows.Forms.Button()
        Me.BtnCancelImport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "What kind of import do you want to do?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The recommended option is to use the pa" &
    "rtial import process."
        '
        'BtnFullImport
        '
        Me.BtnFullImport.Location = New System.Drawing.Point(12, 51)
        Me.BtnFullImport.Name = "BtnFullImport"
        Me.BtnFullImport.Size = New System.Drawing.Size(233, 23)
        Me.BtnFullImport.TabIndex = 3
        Me.BtnFullImport.Text = "Full Import (Overwrites all existing settings)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnFullImport.UseVisualStyleBackColor = True
        '
        'BtnPartialImport
        '
        Me.BtnPartialImport.Location = New System.Drawing.Point(251, 51)
        Me.BtnPartialImport.Name = "BtnPartialImport"
        Me.BtnPartialImport.Size = New System.Drawing.Size(317, 23)
        Me.BtnPartialImport.TabIndex = 1
        Me.BtnPartialImport.Text = "Partial Import (Only overwrites what is in the chosen XML file)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnPartialImport.UseVisualStyleBackColor = True
        '
        'BtnCancelImport
        '
        Me.BtnCancelImport.Location = New System.Drawing.Point(12, 80)
        Me.BtnCancelImport.Name = "BtnCancelImport"
        Me.BtnCancelImport.Size = New System.Drawing.Size(556, 23)
        Me.BtnCancelImport.TabIndex = 2
        Me.BtnCancelImport.Text = "Cancel Import"
        Me.BtnCancelImport.UseVisualStyleBackColor = True
        '
        'WhatKindImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 114)
        Me.Controls.Add(Me.BtnCancelImport)
        Me.Controls.Add(Me.BtnPartialImport)
        Me.Controls.Add(Me.BtnFullImport)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WhatKindImport"
        Me.Text = "What kind of import do you want to do?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFullImport As Button
    Friend WithEvents BtnPartialImport As Button
    Friend WithEvents BtnCancelImport As Button
End Class
