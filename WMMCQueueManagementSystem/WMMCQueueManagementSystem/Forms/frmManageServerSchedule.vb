Public Class frmManageServerSchedule
    Sub New()
        InitializeComponent()

    End Sub

    Private Sub AddNewSched_BTN_Click(sender As Object, e As EventArgs) Handles AddNewSched_BTN.Click
        Dim schedAddEdit = New frmSchedulesAddEdit()
        If schedAddEdit.ShowDialog() = DialogResult.OK Then

        End If
    End Sub
End Class