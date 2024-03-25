Public Class frmCounterQueuingBoardQueueListSummary
    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function
    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub frmCounterQueuingBoardQueueListSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showHelp()
        refreshDataIntertval.Start()
    End Sub
    Private Function CalculateCustomerSatisfaction(allowedTime As Long, datequeued As Date, isPriority As Boolean) As Integer
        If Not IsNothing(datequeued) Then
            Dim elapseTime As Long = DateDiff(DateInterval.Minute, datequeued, Now)
            If isPriority Then
                If elapseTime >= allowedTime Then
                    Return 7
                ElseIf elapseTime >= (allowedTime / 2) Then
                    Return 8
                Else
                    Return 9
                End If
            Else
                If elapseTime >= allowedTime Then
                    Return 4
                ElseIf elapseTime >= (allowedTime / 2) Then
                    Return 5
                Else
                    Return 6
                End If
            End If
        Else
            Return 0
        End If
    End Function
    Private Sub frmCounterQueuingBoardQueueListSummary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Maximized
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            showHelp()
        End If
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim data As DataTable = customerAssignCounterController.GetAllDepartmentTurnAroundTimeStatus()
        If Not IsNothing(data) Then
            If data.Rows.Count > 0 Then
                lblCounter1.Text = data.Rows(0).Item("ServiceDescription").ToString.ToUpper
                lblCounter1.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal1.Text = data.Rows(0).Item("PendingNormalQueue")
                lbQueuedPriority1.Text = data.Rows(0).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(0).Item("NotServeNormalQueueDate")) Then
                    pbNormal1.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(0).Item("AllowedTurnAroundTime"), data.Rows(0).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(0).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal1.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")

                Else
                    pbNormal1.Image = imgList.Images(0)
                    lbWaitingNormal1.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(0).Item("NotServePriorityQueueDate")) Then
                    pbPriority1.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(0).Item("AllowedTurnAroundTime"), data.Rows(0).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(0).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority1.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority1.Image = imgList.Images(1)
                    lbWaitingPriority1.Text = "NO PATIENT"
                End If
            Else
                lblCounter1.ForeColor = Color.DimGray
                lblCounter1.Text = ""
                lbQueuedNormal1.Text = ""
                lbQueuedPriority1.Text = ""
                pbNormal1.Image = Nothing
                pbPriority1.Image = Nothing
                lbWaitingNormal1.Text = Nothing
                lbWaitingPriority1.Text = Nothing

                lblCounter2.ForeColor = Color.DimGray
                lblCounter2.Text = ""
                lbQueuedNormal2.Text = ""
                lbQueuedPriority2.Text = ""
                pbNormal2.Image = Nothing
                pbPriority2.Image = Nothing
                lbWaitingNormal2.Text = Nothing
                lbWaitingPriority2.Text = Nothing

                lblCounter3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbQueuedNormal3.Text = ""
                lbQueuedPriority3.Text = ""
                pbNormal3.Image = Nothing
                pbPriority3.Image = Nothing
                lbWaitingNormal3.Text = Nothing
                lbWaitingPriority3.Text = Nothing

                lblCounter4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbQueuedNormal4.Text = ""
                lbQueuedPriority4.Text = ""
                pbNormal4.Image = Nothing
                pbPriority4.Image = Nothing
                lbWaitingNormal4.Text = Nothing
                lbWaitingPriority4.Text = Nothing

                lblCounter5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbQueuedNormal5.Text = ""
                lbQueuedPriority5.Text = ""
                pbNormal5.Image = Nothing
                pbPriority5.Image = Nothing
                lbWaitingNormal5.Text = Nothing
                lbWaitingPriority5.Text = Nothing

                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 1 Then
                lblCounter2.Text = data.Rows(1).Item("ServiceDescription").ToString.ToUpper
                lblCounter2.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal2.Text = data.Rows(1).Item("PendingNormalQueue")
                lbQueuedPriority2.Text = data.Rows(1).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(1).Item("NotServeNormalQueueDate")) Then
                    pbNormal2.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(1).Item("AllowedTurnAroundTime"), data.Rows(1).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(1).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal2.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal2.Image = imgList.Images(0)
                    lbWaitingNormal2.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(1).Item("NotServePriorityQueueDate")) Then
                    pbPriority2.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(1).Item("AllowedTurnAroundTime"), data.Rows(1).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(1).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority2.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority2.Image = imgList.Images(1)
                    lbWaitingPriority2.Text = "NO PATIENT"
                End If
            Else
                lblCounter2.ForeColor = Color.DimGray
                lblCounter2.Text = ""
                lbQueuedNormal2.Text = ""
                lbQueuedPriority2.Text = ""
                pbNormal2.Image = Nothing
                pbPriority2.Image = Nothing
                lbWaitingNormal2.Text = Nothing
                lbWaitingPriority2.Text = Nothing

                lblCounter3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbQueuedNormal3.Text = ""
                lbQueuedPriority3.Text = ""
                pbNormal3.Image = Nothing
                pbPriority3.Image = Nothing
                lbWaitingNormal3.Text = Nothing
                lbWaitingPriority3.Text = Nothing

                lblCounter4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbQueuedNormal4.Text = ""
                lbQueuedPriority4.Text = ""
                pbNormal4.Image = Nothing
                pbPriority4.Image = Nothing
                lbWaitingNormal4.Text = Nothing
                lbWaitingPriority4.Text = Nothing

                lblCounter5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbQueuedNormal5.Text = ""
                lbQueuedPriority5.Text = ""
                pbNormal5.Image = Nothing
                pbPriority5.Image = Nothing
                lbWaitingNormal5.Text = Nothing
                lbWaitingPriority5.Text = Nothing

                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 2 Then
                lblCounter3.Text = data.Rows(2).Item("ServiceDescription").ToString.ToUpper
                lblCounter3.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal3.Text = data.Rows(2).Item("PendingNormalQueue")
                lbQueuedPriority3.Text = data.Rows(2).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(2).Item("NotServeNormalQueueDate")) Then
                    pbNormal3.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(2).Item("AllowedTurnAroundTime"), data.Rows(2).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(2).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal3.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal3.Image = imgList.Images(0)
                    lbWaitingNormal3.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(2).Item("NotServePriorityQueueDate")) Then
                    pbPriority3.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(2).Item("AllowedTurnAroundTime"), data.Rows(2).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(2).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority3.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority3.Image = imgList.Images(1)
                    lbWaitingPriority3.Text = "NO PATIENT"
                End If
            Else
                lblCounter3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbQueuedNormal3.Text = ""
                lbQueuedPriority3.Text = ""
                pbNormal3.Image = Nothing
                pbPriority3.Image = Nothing
                lbWaitingNormal3.Text = Nothing
                lbWaitingPriority3.Text = Nothing

                lblCounter4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbQueuedNormal4.Text = ""
                lbQueuedPriority4.Text = ""
                pbNormal4.Image = Nothing
                pbPriority4.Image = Nothing
                lbWaitingNormal4.Text = Nothing
                lbWaitingPriority4.Text = Nothing

                lblCounter5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbQueuedNormal5.Text = ""
                lbQueuedPriority5.Text = ""
                pbNormal5.Image = Nothing
                pbPriority5.Image = Nothing
                lbWaitingNormal5.Text = Nothing
                lbWaitingPriority5.Text = Nothing

                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 3 Then
                lblCounter4.Text = data.Rows(3).Item("ServiceDescription").ToString.ToUpper
                lblCounter4.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal4.Text = data.Rows(3).Item("PendingNormalQueue")
                lbQueuedPriority4.Text = data.Rows(3).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(3).Item("NotServeNormalQueueDate")) Then
                    pbNormal4.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(3).Item("AllowedTurnAroundTime"), data.Rows(3).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(3).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal4.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal4.Image = imgList.Images(0)
                    lbWaitingNormal4.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(3).Item("NotServePriorityQueueDate")) Then
                    pbPriority4.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(3).Item("AllowedTurnAroundTime"), data.Rows(3).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(3).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority4.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority4.Image = imgList.Images(1)
                    lbWaitingPriority4.Text = "NO PATIENT"
                End If
            Else
                lblCounter4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbQueuedNormal4.Text = ""
                lbQueuedPriority4.Text = ""
                pbNormal4.Image = Nothing
                pbPriority4.Image = Nothing
                lbWaitingNormal4.Text = Nothing
                lbWaitingPriority4.Text = Nothing

                lblCounter5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbQueuedNormal5.Text = ""
                lbQueuedPriority5.Text = ""
                pbNormal5.Image = Nothing
                pbPriority5.Image = Nothing
                lbWaitingNormal5.Text = Nothing
                lbWaitingPriority5.Text = Nothing

                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 4 Then
                lblCounter5.Text = data.Rows(4).Item("ServiceDescription").ToString.ToUpper
                lblCounter5.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal5.Text = data.Rows(4).Item("PendingNormalQueue")
                lbQueuedPriority5.Text = data.Rows(4).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(4).Item("NotServeNormalQueueDate")) Then
                    pbNormal5.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(4).Item("AllowedTurnAroundTime"), data.Rows(4).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(4).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal5.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal5.Image = imgList.Images(0)
                    lbWaitingNormal5.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(4).Item("NotServePriorityQueueDate")) Then
                    pbPriority5.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(4).Item("AllowedTurnAroundTime"), data.Rows(4).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(4).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority5.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority5.Image = imgList.Images(1)
                    lbWaitingPriority5.Text = "NO PATIENT"
                End If
            Else
                lblCounter5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbQueuedNormal5.Text = ""
                lbQueuedPriority5.Text = ""
                pbNormal5.Image = Nothing
                pbPriority5.Image = Nothing
                lbWaitingNormal5.Text = Nothing
                lbWaitingPriority5.Text = Nothing

                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 5 Then
                lblCounter6.Text = data.Rows(5).Item("ServiceDescription").ToString.ToUpper
                lblCounter6.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal6.Text = data.Rows(5).Item("PendingNormalQueue")
                lbQueuedPriority6.Text = data.Rows(5).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(5).Item("NotServeNormalQueueDate")) Then
                    pbNormal6.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(5).Item("AllowedTurnAroundTime"), data.Rows(5).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(5).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal6.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal6.Image = imgList.Images(0)
                    lbWaitingNormal6.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(5).Item("NotServePriorityQueueDate")) Then
                    pbPriority6.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(5).Item("AllowedTurnAroundTime"), data.Rows(5).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(5).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority6.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority6.Image = imgList.Images(1)
                    lbWaitingPriority6.Text = "NO PATIENT"
                End If
            Else
                lblCounter6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbQueuedNormal6.Text = ""
                lbQueuedPriority6.Text = ""
                pbNormal6.Image = Nothing
                pbPriority6.Image = Nothing
                lbWaitingNormal6.Text = Nothing
                lbWaitingPriority6.Text = Nothing

                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 6 Then
                lblCounter7.Text = data.Rows(6).Item("ServiceDescription").ToString.ToUpper
                lblCounter7.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal7.Text = data.Rows(6).Item("PendingNormalQueue")
                lbQueuedPriority7.Text = data.Rows(6).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(6).Item("NotServeNormalQueueDate")) Then
                    pbNormal7.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(6).Item("AllowedTurnAroundTime"), data.Rows(6).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(6).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal7.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal7.Image = imgList.Images(0)
                    lbWaitingNormal7.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(6).Item("NotServePriorityQueueDate")) Then
                    pbPriority7.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(6).Item("AllowedTurnAroundTime"), data.Rows(6).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(6).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority7.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority6.Image = imgList.Images(1)
                    lbWaitingPriority7.Text = "NO PATIENT"
                End If
            Else
                lblCounter7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbQueuedNormal7.Text = ""
                lbQueuedPriority7.Text = ""
                pbNormal7.Image = Nothing
                pbPriority7.Image = Nothing
                lbWaitingNormal7.Text = Nothing
                lbWaitingPriority7.Text = Nothing

                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 7 Then
                lblCounter8.Text = data.Rows(7).Item("ServiceDescription").ToString.ToUpper
                lblCounter8.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal8.Text = data.Rows(7).Item("PendingNormalQueue")
                lbQueuedPriority8.Text = data.Rows(7).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(7).Item("NotServeNormalQueueDate")) Then
                    pbNormal8.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(7).Item("AllowedTurnAroundTime"), data.Rows(7).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(7).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal8.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal8.Image = imgList.Images(0)
                    lbWaitingNormal8.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(7).Item("NotServePriorityQueueDate")) Then
                    pbPriority8.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(7).Item("AllowedTurnAroundTime"), data.Rows(7).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(7).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority8.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority8.Image = imgList.Images(1)
                    lbWaitingPriority8.Text = "NO PATIENT"
                End If
            Else
                lblCounter8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbQueuedNormal8.Text = ""
                lbQueuedPriority8.Text = ""
                pbNormal8.Image = Nothing
                pbPriority8.Image = Nothing
                lbWaitingNormal8.Text = Nothing
                lbWaitingPriority8.Text = Nothing

                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 8 Then
                lblCounter9.Text = data.Rows(8).Item("ServiceDescription").ToString.ToUpper
                lblCounter9.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal9.Text = data.Rows(8).Item("PendingNormalQueue")
                lbQueuedPriority9.Text = data.Rows(8).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(8).Item("NotServeNormalQueueDate")) Then
                    pbNormal9.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(8).Item("AllowedTurnAroundTime"), data.Rows(8).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(8).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal9.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal9.Image = imgList.Images(0)
                    lbWaitingNormal9.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(8).Item("NotServePriorityQueueDate")) Then
                    pbPriority9.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(8).Item("AllowedTurnAroundTime"), data.Rows(8).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(8).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority9.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority9.Image = imgList.Images(1)
                    lbWaitingPriority9.Text = "NO PATIENT"
                End If
            Else
                lblCounter9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbQueuedNormal9.Text = ""
                lbQueuedPriority9.Text = ""
                pbNormal9.Image = Nothing
                pbPriority9.Image = Nothing
                lbWaitingNormal9.Text = Nothing
                lbWaitingPriority9.Text = Nothing

                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
            If data.Rows.Count > 9 Then
                lblCounter10.Text = data.Rows(9).Item("ServiceDescription").ToString.ToUpper
                lblCounter10.ForeColor = Color.FromArgb(13, 52, 145)
                lbQueuedNormal10.Text = data.Rows(9).Item("PendingNormalQueue")
                lbQueuedPriority10.Text = data.Rows(9).Item("PendingPriorityQueue")
                If Not IsDBNull(data.Rows(9).Item("NotServeNormalQueueDate")) Then
                    pbNormal10.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(9).Item("AllowedTurnAroundTime"), data.Rows(9).Item("NotServeNormalQueueDate"), False))
                    Dim elapseTimeNormal As Long = DateDiff(DateInterval.Minute, data.Rows(9).Item("NotServeNormalQueueDate"), Now)
                    lbWaitingNormal10.Text = If(elapseTimeNormal > 0, If(elapseTimeNormal >= 60, Math.Floor(elapseTimeNormal / 60).ToString & " HOUR/s", elapseTimeNormal & " MIN/s"), "LESS 1 MIN")
                Else
                    pbNormal10.Image = imgList.Images(0)
                    lbWaitingNormal10.Text = "NO PATIENT"
                End If
                If Not IsDBNull(data.Rows(9).Item("NotServePriorityQueueDate")) Then
                    pbPriority10.Image = imgList.Images(CalculateCustomerSatisfaction(data.Rows(9).Item("AllowedTurnAroundTime"), data.Rows(9).Item("NotServePriorityQueueDate"), True))
                    Dim elapseTimePriority As Long = DateDiff(DateInterval.Minute, data.Rows(9).Item("NotServePriorityQueueDate"), Now)
                    lbWaitingPriority10.Text = If(elapseTimePriority > 0, If(elapseTimePriority >= 60, Math.Floor(elapseTimePriority / 60).ToString & " HOUR/s", elapseTimePriority & " MIN/s"), "LESS 1 MIN")
                Else
                    pbPriority10.Image = imgList.Images(1)
                    lbWaitingPriority10.Text = "NO PATIENT"
                End If
            Else
                lblCounter10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbQueuedNormal10.Text = ""
                lbQueuedPriority10.Text = ""
                pbNormal10.Image = Nothing
                pbPriority10.Image = Nothing
                lbWaitingNormal10.Text = Nothing
                lbWaitingPriority10.Text = Nothing
                GoTo SKIP
            End If
        End If

SKIP:
    End Sub

    Private Sub frmCounterQueuingBoardQueueListSummary_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class