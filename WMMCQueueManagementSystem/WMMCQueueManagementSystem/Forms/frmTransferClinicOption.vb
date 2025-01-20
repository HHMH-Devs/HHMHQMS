Public Class frmTransferClinicOption

    Public isTranferHold As Integer

    Sub New()
        InitializeComponent()
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnTranferToClinic_Click(sender As Object, e As EventArgs) Handles btnTranferToClinic.Click
        isTranferHold = 0
    End Sub

    Private Sub btnTranferAndHold_Click(sender As Object, e As EventArgs) Handles btnTranferAndHold.Click
        isTranferHold = 1
    End Sub
End Class