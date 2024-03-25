Public Class frmAllQueueBoard_Static
    Private callString As String = "", highlightNumber As String = ""
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0, id7 As Long = 0, id8 As Long = 0, id9 As Long = 0, id10 As Long = 0, id11 As Long = 0, id12 As Long = 0, id13 As Long = 0, id14 As Long = 0, id15 As Long = 0, id16 As Long = 0, id17 As Long = 0, id18 As Long = 0, id19 As Long = 0, id20 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = "", counter7 As String = "", counter8 As String = "", counter9 As String = "", counter10 As String = "", counter11 As String = "", counter12 As String = "", counter13 As String = "", counter14 As String = "", counter15 As String = "", counter16 As String = "", counter17 As String = "", counter18 As String = "", counter19 As String = "", counter20 As String = ""
    Private LatestDate As Date = Today
    Private QueueListTimer As Timer = Nothing

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If lblHighlightServing.BackColor = Color.FromArgb(13, 52, 145) Then
            lblHighlightServing.BackColor = Color.Aqua
        ElseIf lblHighlightServing.BackColor = Color.Aqua Then
            lblHighlightServing.BackColor = Color.FromArgb(13, 52, 145)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pnlHighlightServing.Hide()
        Timer1.Stop()
        Timer2.Stop()
    End Sub

    Private Sub CallNumber()
        Try
            lblHighlightServing.Text = highlightNumber.Trim.ToUpper
            pnlHighlightServing.Show()
            Timer1.Start()
            Timer2.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAllQueueBoard_Static_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNothing(QueueListTimer) Then
            QueueListTimer = New Timer()
            QueueListTimer.Interval = 10000
            AddHandler QueueListTimer.Tick, AddressOf QueueListTimer_Tick
            QueueListTimer.Start()
        Else
            RemoveHandler QueueListTimer.Tick, AddressOf QueueListTimer_Tick
            QueueListTimer = Nothing
            QueueListTimer = New Timer()
            QueueListTimer.Interval = 10000
            AddHandler QueueListTimer.Tick, AddressOf QueueListTimer_Tick
            QueueListTimer.Start()
        End If
    End Sub

    Private Sub frmAllQueueBoard_Static_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
                Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Else
                Me.WindowState = FormWindowState.Maximized
                Me.FormBorderStyle = FormBorderStyle.None
            End If
        End If
    End Sub

    Private Sub CheckIfServingChange(tmpServingCustomerOfServers As AllDeparmentCustomerInQueue)
        If id1 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter1.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id2 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter2.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id3 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter3.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id4 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter4.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id5 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter5.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id6 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter6.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id7 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter7.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id8 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter8.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id9 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter9.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id10 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter10.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id11 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter11.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id12 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter12.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id13 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter13.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id14 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter14.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id15 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter15.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id16 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter16.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        End If
        If id17 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter17.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        ElseIf id18 = tmpServingCustomerOfServers.CounterBoard_ID Then
            If counter18.ToLower <> tmpServingCustomerOfServers.ProcessQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.ProcessQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.ProcessQueueNumber
            End If
        End If
    End Sub

    Private Sub QueueListTimer_Tick(sender As Object, e As EventArgs)
        Dim apiCOntroller As New APIController
        Dim dtToday As Date = apiCOntroller.GetCurrentServerDate_qms
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As New List(Of AllDeparmentCustomerInQueue)
        If Not (LatestDate.Date = dtToday.Date) Then
            LatestDate = dtToday
            tmpServingCustomerOfServers = servedCustomerController.GetAllDepartmentResetQueue()
        Else
            tmpServingCustomerOfServers = servedCustomerController.GetAllDepartmentServingQueue2()
        End If
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                If Not id1 = tmpServingCustomerOfServers(0).CounterBoard_ID Then
                    lbserving1.Text = tmpServingCustomerOfServers(0).ProcessQueueNumber.ToUpper.Trim
                End If
                id1 = tmpServingCustomerOfServers(0).CounterBoard_ID
                lblCounter1.Text = tmpServingCustomerOfServers(0).DisplayName
                If tmpServingCustomerOfServers(0).withNumber Then
                    lbserving1.Text = tmpServingCustomerOfServers(0).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(0))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 1 Then
                If Not id2 = tmpServingCustomerOfServers(1).CounterBoard_ID Then
                    lbserving2.Text = tmpServingCustomerOfServers(1).ProcessQueueNumber.ToUpper.Trim
                End If
                id2 = tmpServingCustomerOfServers(1).CounterBoard_ID
                lblCounter2.Text = tmpServingCustomerOfServers(1).DisplayName
                If tmpServingCustomerOfServers(1).withNumber Then
                    lbserving2.Text = tmpServingCustomerOfServers(1).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(1))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 2 Then
                If Not id3 = tmpServingCustomerOfServers(2).CounterBoard_ID Then
                    lbserving3.Text = tmpServingCustomerOfServers(2).ProcessQueueNumber.ToUpper.Trim
                End If
                id3 = tmpServingCustomerOfServers(2).CounterBoard_ID
                lblCounter3.Text = tmpServingCustomerOfServers(2).DisplayName
                lbserving3.Text = tmpServingCustomerOfServers(2).ProcessQueueNumber.ToUpper.Trim
                If tmpServingCustomerOfServers(2).withNumber Then
                    lbserving3.Text = tmpServingCustomerOfServers(2).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(2))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 3 Then
                If Not id4 = tmpServingCustomerOfServers(3).CounterBoard_ID Then
                    lbserving4.Text = tmpServingCustomerOfServers(3).ProcessQueueNumber.ToUpper.Trim
                End If
                id4 = tmpServingCustomerOfServers(3).CounterBoard_ID
                lblCounter4.Text = tmpServingCustomerOfServers(3).DisplayName
                If tmpServingCustomerOfServers(3).withNumber Then
                    lbserving4.Text = tmpServingCustomerOfServers(3).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(3))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 4 Then
                If Not id5 = tmpServingCustomerOfServers(4).CounterBoard_ID Then
                    lbserving5.Text = tmpServingCustomerOfServers(4).ProcessQueueNumber.ToUpper.Trim
                End If
                id5 = tmpServingCustomerOfServers(4).CounterBoard_ID
                lblCounter5.Text = tmpServingCustomerOfServers(4).DisplayName
                If tmpServingCustomerOfServers(4).withNumber Then
                    lbserving5.Text = tmpServingCustomerOfServers(4).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(4))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 5 Then
                If Not id6 = tmpServingCustomerOfServers(5).CounterBoard_ID Then
                    lbserving6.Text = tmpServingCustomerOfServers(5).ProcessQueueNumber.ToUpper.Trim
                End If
                id6 = tmpServingCustomerOfServers(5).CounterBoard_ID
                lblCounter6.Text = tmpServingCustomerOfServers(5).DisplayName
                If tmpServingCustomerOfServers(5).withNumber Then
                    lbserving6.Text = tmpServingCustomerOfServers(5).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(5))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 6 Then
                If Not id7 = tmpServingCustomerOfServers(6).CounterBoard_ID Then
                    lbserving7.Text = tmpServingCustomerOfServers(6).ProcessQueueNumber.ToUpper.Trim
                End If
                id7 = tmpServingCustomerOfServers(6).CounterBoard_ID
                lblCounter7.Text = tmpServingCustomerOfServers(6).DisplayName
                If tmpServingCustomerOfServers(6).withNumber Then
                    lbserving7.Text = tmpServingCustomerOfServers(6).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(6))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 7 Then
                If Not id8 = tmpServingCustomerOfServers(7).CounterBoard_ID Then
                    lbserving8.Text = tmpServingCustomerOfServers(7).ProcessQueueNumber.ToUpper.Trim
                End If
                id8 = tmpServingCustomerOfServers(7).CounterBoard_ID
                lblCounter8.Text = tmpServingCustomerOfServers(7).DisplayName
                If tmpServingCustomerOfServers(7).withNumber Then
                    lbserving8.Text = tmpServingCustomerOfServers(7).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(7))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 8 Then
                If Not id9 = tmpServingCustomerOfServers(8).CounterBoard_ID Then
                    lbserving9.Text = tmpServingCustomerOfServers(8).ProcessQueueNumber.ToUpper.Trim
                End If
                id9 = tmpServingCustomerOfServers(8).CounterBoard_ID
                lblCounter9.Text = tmpServingCustomerOfServers(8).DisplayName
                If tmpServingCustomerOfServers(8).withNumber Then
                    lbserving9.Text = tmpServingCustomerOfServers(8).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(8))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 9 Then
                If Not id10 = tmpServingCustomerOfServers(9).CounterBoard_ID Then
                    lbserving10.Text = tmpServingCustomerOfServers(9).ProcessQueueNumber.ToUpper.Trim
                End If
                id10 = tmpServingCustomerOfServers(9).CounterBoard_ID
                lblCounter10.Text = tmpServingCustomerOfServers(9).DisplayName
                If tmpServingCustomerOfServers(9).withNumber Then
                    lbserving10.Text = tmpServingCustomerOfServers(9).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(9))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 10 Then
                If Not id11 = tmpServingCustomerOfServers(10).CounterBoard_ID Then
                    lbserving11.Text = tmpServingCustomerOfServers(10).ProcessQueueNumber.ToUpper.Trim
                End If
                id11 = tmpServingCustomerOfServers(10).CounterBoard_ID
                lblCounter11.Text = tmpServingCustomerOfServers(10).DisplayName
                If tmpServingCustomerOfServers(10).withNumber Then
                    lbserving11.Text = tmpServingCustomerOfServers(10).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(10))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 11 Then
                If Not id12 = tmpServingCustomerOfServers(11).CounterBoard_ID Then
                    lbserving12.Text = tmpServingCustomerOfServers(11).ProcessQueueNumber.ToUpper.Trim
                End If
                id12 = tmpServingCustomerOfServers(11).CounterBoard_ID
                lblCounter12.Text = tmpServingCustomerOfServers(11).DisplayName
                If tmpServingCustomerOfServers(11).withNumber Then
                    lbserving12.Text = tmpServingCustomerOfServers(11).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(11))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 12 Then
                If Not id13 = tmpServingCustomerOfServers(12).CounterBoard_ID Then
                    lbserving13.Text = tmpServingCustomerOfServers(12).ProcessQueueNumber.ToUpper.Trim
                End If
                id13 = tmpServingCustomerOfServers(12).CounterBoard_ID
                lblCounter13.Text = tmpServingCustomerOfServers(12).DisplayName
                If tmpServingCustomerOfServers(12).withNumber Then
                    lbserving13.Text = tmpServingCustomerOfServers(12).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(12))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 13 Then
                If Not id14 = tmpServingCustomerOfServers(13).CounterBoard_ID Then
                    lbserving14.Text = tmpServingCustomerOfServers(13).ProcessQueueNumber.ToUpper.Trim
                End If
                id14 = tmpServingCustomerOfServers(13).CounterBoard_ID
                lblCounter14.Text = tmpServingCustomerOfServers(13).DisplayName
                If tmpServingCustomerOfServers(13).withNumber Then
                    lbserving14.Text = tmpServingCustomerOfServers(13).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(13))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 14 Then
                If Not id15 = tmpServingCustomerOfServers(14).CounterBoard_ID Then
                    lbserving15.Text = tmpServingCustomerOfServers(14).ProcessQueueNumber.ToUpper.Trim
                End If
                id15 = tmpServingCustomerOfServers(14).CounterBoard_ID
                lblCounter15.Text = tmpServingCustomerOfServers(14).DisplayName
                If tmpServingCustomerOfServers(14).withNumber Then
                    lbserving15.Text = tmpServingCustomerOfServers(14).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(14))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 15 Then
                If Not id16 = tmpServingCustomerOfServers(15).CounterBoard_ID Then
                    lbserving16.Text = tmpServingCustomerOfServers(15).ProcessQueueNumber.ToUpper.Trim
                End If
                id16 = tmpServingCustomerOfServers(15).CounterBoard_ID
                lblCounter16.Text = tmpServingCustomerOfServers(15).DisplayName
                If tmpServingCustomerOfServers(15).withNumber Then
                    lbserving16.Text = tmpServingCustomerOfServers(15).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(15))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 16 Then
                If Not id17 = tmpServingCustomerOfServers(16).CounterBoard_ID Then
                    lbserving17.Text = tmpServingCustomerOfServers(16).ProcessQueueNumber.ToUpper.Trim
                End If
                id17 = tmpServingCustomerOfServers(16).CounterBoard_ID
                lblCounter17.Text = tmpServingCustomerOfServers(16).DisplayName
                If tmpServingCustomerOfServers(16).withNumber Then
                    lbserving17.Text = tmpServingCustomerOfServers(16).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(16))
                End If
            End If
            If tmpServingCustomerOfServers.Count > 17 Then
                If Not id18 = tmpServingCustomerOfServers(17).CounterBoard_ID Then
                    lbserving18.Text = tmpServingCustomerOfServers(17).ProcessQueueNumber.ToUpper.Trim
                End If
                id18 = tmpServingCustomerOfServers(17).CounterBoard_ID
                lblCounter18.Text = tmpServingCustomerOfServers(17).DisplayName
                If tmpServingCustomerOfServers(17).withNumber Then
                    lbserving18.Text = tmpServingCustomerOfServers(17).ProcessQueueNumber.ToUpper.Trim
                    CheckIfServingChange(tmpServingCustomerOfServers(17))
                End If
            End If
        End If
        counter1 = If(tmpServingCustomerOfServers.Count > 0, If(Not IsNothing(tmpServingCustomerOfServers(0).ProcessQueueNumber), tmpServingCustomerOfServers(0).ProcessQueueNumber, ""), "")
        counter2 = If(tmpServingCustomerOfServers.Count > 1, If(Not IsNothing(tmpServingCustomerOfServers(1).ProcessQueueNumber), tmpServingCustomerOfServers(1).ProcessQueueNumber, ""), "")
        counter3 = If(tmpServingCustomerOfServers.Count > 2, If(Not IsNothing(tmpServingCustomerOfServers(2).ProcessQueueNumber), tmpServingCustomerOfServers(2).ProcessQueueNumber, ""), "")
        counter4 = If(tmpServingCustomerOfServers.Count > 3, If(Not IsNothing(tmpServingCustomerOfServers(3).ProcessQueueNumber), tmpServingCustomerOfServers(3).ProcessQueueNumber, ""), "")
        counter5 = If(tmpServingCustomerOfServers.Count > 4, If(Not IsNothing(tmpServingCustomerOfServers(4).ProcessQueueNumber), tmpServingCustomerOfServers(4).ProcessQueueNumber, ""), "")
        counter6 = If(tmpServingCustomerOfServers.Count > 5, If(Not IsNothing(tmpServingCustomerOfServers(5).ProcessQueueNumber), tmpServingCustomerOfServers(5).ProcessQueueNumber, ""), "")
        counter7 = If(tmpServingCustomerOfServers.Count > 6, If(Not IsNothing(tmpServingCustomerOfServers(6).ProcessQueueNumber), tmpServingCustomerOfServers(6).ProcessQueueNumber, ""), "")
        counter8 = If(tmpServingCustomerOfServers.Count > 7, If(Not IsNothing(tmpServingCustomerOfServers(7).ProcessQueueNumber), tmpServingCustomerOfServers(7).ProcessQueueNumber, ""), "")
        counter9 = If(tmpServingCustomerOfServers.Count > 8, If(Not IsNothing(tmpServingCustomerOfServers(8).ProcessQueueNumber), tmpServingCustomerOfServers(8).ProcessQueueNumber, ""), "")
        counter10 = If(tmpServingCustomerOfServers.Count > 9, If(Not IsNothing(tmpServingCustomerOfServers(9).ProcessQueueNumber), tmpServingCustomerOfServers(9).ProcessQueueNumber, ""), "")
        counter11 = If(tmpServingCustomerOfServers.Count > 10, If(Not IsNothing(tmpServingCustomerOfServers(10).ProcessQueueNumber), tmpServingCustomerOfServers(10).ProcessQueueNumber, ""), "")
        counter12 = If(tmpServingCustomerOfServers.Count > 11, If(Not IsNothing(tmpServingCustomerOfServers(11).ProcessQueueNumber), tmpServingCustomerOfServers(11).ProcessQueueNumber, ""), "")
        counter13 = If(tmpServingCustomerOfServers.Count > 12, If(Not IsNothing(tmpServingCustomerOfServers(12).ProcessQueueNumber), tmpServingCustomerOfServers(12).ProcessQueueNumber, ""), "")
        counter14 = If(tmpServingCustomerOfServers.Count > 13, If(Not IsNothing(tmpServingCustomerOfServers(13).ProcessQueueNumber), tmpServingCustomerOfServers(13).ProcessQueueNumber, ""), "")
        counter15 = If(tmpServingCustomerOfServers.Count > 14, If(Not IsNothing(tmpServingCustomerOfServers(14).ProcessQueueNumber), tmpServingCustomerOfServers(14).ProcessQueueNumber, ""), "")
        counter16 = If(tmpServingCustomerOfServers.Count > 15, If(Not IsNothing(tmpServingCustomerOfServers(15).ProcessQueueNumber), tmpServingCustomerOfServers(15).ProcessQueueNumber, ""), "")
        counter17 = If(tmpServingCustomerOfServers.Count > 16, If(Not IsNothing(tmpServingCustomerOfServers(16).ProcessQueueNumber), tmpServingCustomerOfServers(16).ProcessQueueNumber, ""), "")
        counter18 = If(tmpServingCustomerOfServers.Count > 17, If(Not IsNothing(tmpServingCustomerOfServers(17).ProcessQueueNumber), tmpServingCustomerOfServers(17).ProcessQueueNumber, ""), "")
        If callString.Count > 0 Then
            CallNumber()
            callString = ""
        End If
    End Sub

    Private Sub frmAllQueueBoard_Static_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        QueueListTimer.Stop()
    End Sub
End Class