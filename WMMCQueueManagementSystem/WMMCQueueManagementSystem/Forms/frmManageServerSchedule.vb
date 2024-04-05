Public Class frmManageServerSchedule
    Public Property ServerID As Integer
    Public Property PhysicianName As String
    Public Property Schedules As List(Of DoctorSchedule)
    Dim serverController As New ServerController

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(ServerID As Integer)
        InitializeComponent()
        Schedules = serverController.GetServerSchedules(ServerID)
        If Schedules.Count > 0 Then
            Dim i = 0
            For Each item In Schedules
                dgvSchedule.Rows.Add(item.Day, item.Availability)
                dgvSchedule.Rows(i).Tag = item.ID
                i += 1
            Next
        End If
    End Sub

    Private Sub AddNewSched_BTN_Click(sender As Object, e As EventArgs) Handles AddNewSched_BTN.Click
        Dim schedAddEdit = New frmSchedulesAddEdit()
        If schedAddEdit.ShowDialog() = DialogResult.OK Then

        End If
    End Sub
End Class