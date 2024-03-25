Public Class frmConnection
    Private IsLive As Boolean
    Private Sub SelectDatabase(_isLive As Boolean)
        IsLive = _isLive
        If IsLive Then
            Panel2.BackColor = Color.LimeGreen
            Label2.BackColor = Color.LimeGreen

            Panel3.BackColor = Color.LightGray
            Label3.BackColor = Color.LightGray
        Else
            Panel2.BackColor = Color.LightGray
            Label2.BackColor = Color.LightGray

            Panel3.BackColor = Color.LimeGreen
            Label3.BackColor = Color.LimeGreen
        End If
    End Sub

    Private Sub frmConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsLive = SystemIsLive
        If IsLive Then
            SelectDatabase(True)
        Else
            SelectDatabase(False)
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        SelectDatabase(True)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        SelectDatabase(False)
    End Sub

    Private Sub btnLoginAdmin_Click(sender As Object, e As EventArgs) Handles btnLoginAdmin.Click
        SystemIsLive = IsLive
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class