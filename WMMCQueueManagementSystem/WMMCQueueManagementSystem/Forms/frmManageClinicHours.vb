Public Class frmManageClinicHours

    Dim server As New ServerController()
    Dim prcNumber As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(prc As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        prcNumber = prc
        For Each item As ListViewItem In lvSchedule.Items
            item.SubItems(1).Text = ""
        Next
        Dim sched = server.GetDoctorSchedule(prc)
        If sched Is Nothing Then
            btnSaveSched.Text = "SAVE SCHEDULE"
        Else
            Me.Tag = sched.FirstOrDefault().ServerID
            btnSaveSched.Text = "UPDATE SCHEDULE"
            For Each day In sched
                Select Case day.Day
                    Case "MONDAY"
                        lvSchedule.Items(0).SubItems(1).Text = day.Time
                        lvSchedule.Items(0).Tag = day.SchedID
                    Case "TUESDAY"
                        lvSchedule.Items(1).SubItems(1).Text = day.Time
                        lvSchedule.Items(1).Tag = day.SchedID
                    Case "WEDNESDAY"
                        lvSchedule.Items(2).SubItems(1).Text = day.Time
                        lvSchedule.Items(2).Tag = day.SchedID
                    Case "THURSDAY"
                        lvSchedule.Items(3).SubItems(1).Text = day.Time
                        lvSchedule.Items(3).Tag = day.SchedID
                    Case "FRIDAY"
                        lvSchedule.Items(4).SubItems(1).Text = day.Time
                        lvSchedule.Items(4).Tag = day.SchedID
                    Case "SATURDAY"
                        lvSchedule.Items(5).SubItems(1).Text = day.Time
                        lvSchedule.Items(5).Tag = day.SchedID
                    Case "SUNDAY"
                        lvSchedule.Items(6).SubItems(1).Text = day.Time
                        lvSchedule.Items(6).Tag = day.SchedID
                End Select
            Next
        End If
    End Sub

    Private Sub ClearFields()
        SchedDay_CMB.Text = ""
        From_CMB.Text = ""
        To_CMB.Text = ""
    End Sub

    Private Sub btnSaveSched_Click(sender As Object, e As EventArgs) Handles btnSaveSched.Click
        If btnSaveSched.Text = "SAVE SCHEDULE" Then
            Dim newSched As New List(Of DoctorSchedule)
            For Each item As ListViewItem In lvSchedule.Items
                newSched.Add(New DoctorSchedule With {
                    .ServerID = Me.Tag,
                    .Day = item.Text,
                    .Time = item.SubItems(1).Text
                })
            Next
            Dim res = server.NewDoctorSchedule(prcNumber, newSched)
            If Not res Then
                MessageBox.Show("Unable to save schedule, an error occurred while processing your request." & vbCrLf & "Please call your Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Schedule successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf btnSaveSched.Text = "UPDATE SCHEDULE" Then
            Dim sched As New List(Of DoctorSchedule)
            For Each item As ListViewItem In lvSchedule.Items
                sched.Add(New DoctorSchedule With {
                    .SchedID = item.Tag,
                    .ServerID = Me.Tag,
                    .Day = item.Text,
                    .Time = item.SubItems(1).Text
                })
            Next
            Dim res = server.UpdateSchedule(sched)
            If Not res Then
                MessageBox.Show("Unable to update schedule, an error occurred while processing your request." & vbCrLf & "Please call your Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Schedule successfully updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnClearSched_Click(sender As Object, e As EventArgs) Handles btnClearSched.Click
        Dim diagResult = MessageBox.Show("Do you want to clear all schedules?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        If diagResult = DialogResult.OK Then
            Dim sched As New List(Of DoctorSchedule)
            For Each item As ListViewItem In lvSchedule.Items
                item.SubItems(1).Text = ""
                sched.Add(New DoctorSchedule With {
                    .SchedID = item.Tag,
                    .ServerID = Me.Tag,
                    .Day = item.Text,
                    .Time = item.SubItems(1).Text
                })
            Next
            Dim res = server.UpdateSchedule(sched)
            If res Then
                MessageBox.Show("Schedule successfully cleared.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Unable to update schedule, an error occurred while processing your request." & vbCrLf & "Please call your Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub lvSchedule_DoubleClick(sender As Object, e As EventArgs) Handles lvSchedule.DoubleClick
        SchedDay_CMB.Text = lvSchedule.FocusedItem.Text
        Dim extractedTime = lvSchedule.FocusedItem.SubItems(1).Text.Split(New Char() {"-"}, StringSplitOptions.RemoveEmptyEntries)
        If extractedTime.Length > 0 Then
            From_CMB.Text = extractedTime(0).Trim()
            To_CMB.Text = extractedTime(1).Trim()
        Else
            From_CMB.Text = ""
            To_CMB.Text = ""
        End If
        If Not String.IsNullOrEmpty(lvSchedule.FocusedItem.SubItems(1).Text) Then
            btnAddSched.Text = "UPDATE"
        Else
            btnAddSched.Text = "ADD"
        End If
    End Sub

    Private Sub btnAddSched_Click(sender As Object, e As EventArgs) Handles btnAddSched.Click
        For Each item As ListViewItem In lvSchedule.Items
            If SchedDay_CMB.Text = item.Text Then
                item.SubItems(1).Text = From_CMB.Text & " - " & To_CMB.Text
            End If
        Next
    End Sub
End Class