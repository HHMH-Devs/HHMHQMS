Public Class frmFindDoctor
    Private findDoctor As Server = Nothing

    Public Property FoundDoctor As Server
        Private Set(value As Server)
            findDoctor = value
        End Set
        Get
            Return findDoctor
        End Get
    End Property

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtPass.Text.Trim.Length > 0 Then
            Dim apiController As New APIController
            Dim doctorInfo As Server = apiController.FindDoctor(txtPass.Text)
            If Not IsNothing(doctorInfo) Then
                FoundDoctor = doctorInfo
                Me.DialogResult = DialogResult.Yes
            Else
                MessageBox.Show("No matching information found for this PRC number", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please enter the doctor's prc number.", "PRC Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class