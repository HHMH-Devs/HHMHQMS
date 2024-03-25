Imports Spire.PdfViewer
Public Class frmPDFResultViewer
    Private pdfFileLinks As List(Of String)
    Private currentItem As Integer = 0

    Sub New(pdfLink As List(Of String))
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pdfFileLinks = pdfLink
    End Sub

    Private Sub frmPDFResultViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pdfViewer.LoadFromFile(pdfFileLinks(currentItem))
            ShowPageNo()
        Catch ex As Exception
            MessageBox.Show("Failed to open the result. The file maybe doesn't exist or the file is corrupted.", "Cannot View Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If pdfFileLinks.Count > 1 Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub ShowPageNo()
        lblPage.Text = "PAGE: " & (currentItem + 1) & " of " & pdfFileLinks.Count
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentItem = (pdfFileLinks.Count - 1) Then
            currentItem = 0
        Else
            currentItem += 1
        End If
        Try
            pdfViewer.LoadFromFile(pdfFileLinks(currentItem))
            ShowPageNo()
        Catch ex As Exception
            MessageBox.Show("Failed to open the result. The file maybe doesn't exist or the file is corrupted.", "Cannot View Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class