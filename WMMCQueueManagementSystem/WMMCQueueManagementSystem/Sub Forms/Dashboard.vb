Public Class Dashboard
    Dim monthCtr As Integer = 0


    Private Sub showPanelBoardSelection(flag As Boolean)
        pnlQueueBoardSelection.Visible = flag
    End Sub


    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblThisPcCounterName.Text = SavedCounterName.ToUpper.Trim
        LoadDoctorSchedules()
    End Sub

    Private Sub LoadDoctorSchedules()
        Dim server = New ServerController()
        Dim scheds = server.GetDoctorSchedule()
        If scheds.Rows.Count > 0 Then
            DoctorSheds_lv.BeginUpdate()
            DoctorSheds_lv.Items.Clear()
            For Each rw As DataRow In scheds.Rows
                Dim dr = DoctorSheds_lv.Items.Find(rw.Item("prc"), False)
                If dr.Length > 0 Then
                    If Not IsDBNull(rw.Item("Day")) Then
                        Select Case rw.Item("Day")
                            Case "MONDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "TUESDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "WEDNESDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "THURSDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "FRIDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "SATURDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                            Case "SUNDAY"
                                If Not IsDBNull(rw.Item("Availability")) Then
                                    dr(0).SubItems.Add(rw.Item("Availability"))
                                Else
                                    dr(0).SubItems.Add("")
                                End If
                        End Select
                    Else
                        dr(0).SubItems.Add("")
                    End If
                Else
                    Dim lvItem As ListViewItem = DoctorSheds_lv.Items.Add(rw.Item("fullname"))
                    lvItem.Name = rw.Item("prc")
                    If Not IsDBNull(rw.Item("Availability")) Then
                        lvItem.SubItems.Add(rw.Item("Availability"))
                    Else
                        lvItem.SubItems.Add("")
                    End If
                End If
            Next
            DoctorSheds_lv.EndUpdate()
        End If
    End Sub

    Private Sub btnShowCertainQueueBoard_Click(sender As Object, e As EventArgs) Handles btnShowQueueHistory.Click
        Dim frm As New frmHistory
        frm.ShowDialog()
    End Sub

    Private Sub btnShowAllQueueBoard_Click(sender As Object, e As EventArgs) Handles btnShowAllQueueBoard.Click
        If pnlQueueBoardSelection.Visible Then
            showPanelBoardSelection(False)
        Else
            showPanelBoardSelection(True)
        End If

    End Sub

    Private Sub getSummaryTimer_Tick(sender As Object, e As EventArgs)
    End Sub

    Private Sub btnNormalQueueBoard_Click(sender As Object, e As EventArgs) Handles btnNormalQueueBoard.Click
        If Not Application.OpenForms().OfType(Of frmAllQueueBoard_Test).Any Then
            frmAllQueueBoard_Test.Show()
        End If
    End Sub

    Private Sub btnStatnaloneQueueBoard_Click(sender As Object, e As EventArgs) Handles btnStatnaloneQueueBoard.Click
        If Not Application.OpenForms().OfType(Of frmAllQueueBoardStandalone).Any Then
            frmAllQueueBoardStandalone.Show()
        End If
    End Sub

    Private Sub Panel18_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel20_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New frmManageCounterName("COUNTER")
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes And Not IsNothing(frm.CounterName) Then
            SavedCounterName = frm.CounterName.ToUpper.Trim
            lblThisPcCounterName.Text = SavedCounterName.Trim
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
