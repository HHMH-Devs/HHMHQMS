Public Class frmSelectDoleNonDole
    Private Sub btnDolePatient_Click(sender As Object, e As EventArgs) Handles btnDolePatient.Click
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnNonDolePatient_Click(sender As Object, e As EventArgs) Handles btnNonDolePatient.Click
        Me.DialogResult = DialogResult.No
    End Sub

    Private Sub btnRecallPatient_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class