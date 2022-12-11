Public Class WhatKindImport
    Public importType As ImportTypeEnum = ImportTypeEnum.null

    Public Enum ImportTypeEnum As Byte
        fullImport
        partialImport
        null
    End Enum

    Private Sub WhatKindImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnFullImport_Click(sender As Object, e As EventArgs) Handles BtnFullImport.Click
        importType = ImportTypeEnum.fullImport
        Close()
    End Sub

    Private Sub BtnPartialImport_Click(sender As Object, e As EventArgs) Handles BtnPartialImport.Click
        importType = ImportTypeEnum.partialImport
        Close()
    End Sub

    Private Sub BtnCancelImport_Click(sender As Object, e As EventArgs) Handles BtnCancelImport.Click
        Close()
    End Sub
End Class