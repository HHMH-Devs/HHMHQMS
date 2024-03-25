Public Class frmConsent
    Private Sub frmConsent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnTransafer_Click(sender As Object, e As EventArgs) Handles btnTransafer.Click
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class