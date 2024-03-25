Public Class frmCounterQueuingBoardQueueList
    Private Counter As Counter
    Sub New(counter As Counter)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Counter = counter
    End Sub

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function
    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GetQueueList()
        If Not IsNothing(LoggedServer) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim queueList = customerAssignCounterController.GetListOfCustomerInQueueByCounter(LoggedServer.ServerAssignCounter.Counter)
            Dim hasQueueList As Boolean = False
            lstQueueList.Clear()
            For Each customer As CustomerAssignCounter In queueList
                hasQueueList = True
                Dim custStatus As String = ""
                If Not IsNothing(customer.Customer.FullName) Then
                    If customer.Customer.FullName.Trim.Length > 0 Then
                        custStatus = custStatus & " | " & customer.Customer.FullName
                    End If
                End If
                If customer.Priority > 0 Then
                    If CalculateCustomerSatisfaction(customer.Counter.allowedTurnaroundTime, customer.DateTimeQueued) >= 3 Then
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 7)
                    ElseIf CalculateCustomerSatisfaction(customer.Counter.allowedTurnaroundTime, customer.DateTimeQueued) >= 2 Then
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 8)
                    Else
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 9)
                    End If
                Else
                    If CalculateCustomerSatisfaction(customer.Counter.allowedTurnaroundTime, customer.DateTimeQueued) >= 3 Then
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 4)
                    ElseIf CalculateCustomerSatisfaction(customer.Counter.allowedTurnaroundTime, customer.DateTimeQueued) >= 2 Then
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 5)
                    Else
                        lstQueueList.Items.Add(customer.ProcessedQueueNumber & custStatus, 6)
                    End If
                End If
            Next
            If hasQueueList Then
                Panel4.Visible = False
            Else
                Panel4.Visible = True
            End If
        Else
            Panel4.Visible = True
        End If
    End Sub

    Private Function CalculateCustomerSatisfaction(allowedTime As Long, datequeued As Date) As Long
        Dim elapseTime As Long = DateDiff(DateInterval.Minute, datequeued, Now)
        If elapseTime >= allowedTime Then
            Return 3
        ElseIf elapseTime >= (allowedTime / 2) Then
            Return 2
        Else
            Return 1
        End If
    End Function

    Private Sub frmCounterQueuingBoardQueueList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCounterName.Text = "LIST OF PATIENT IN QUEUE FOR: " + Me.Counter.Section.ToUpper + "            "
        refreshDataIntertval.Start()
        showHelp()
    End Sub

    Private Sub label0_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub

    Private Sub lblCounterName_Click(sender As Object, e As EventArgs) Handles lblCounterName.Click

    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        GetQueueList()
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl1.ForeColor = Color.DimGray
                servingLbl1.Text = ""

                servingLbl2.ForeColor = Color.DimGray
                servingLbl2.Text = ""

                servingLbl3.ForeColor = Color.DimGray
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                servingLbl5.Text = ""

                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 1 Then
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl2.ForeColor = Color.DimGray
                servingLbl2.Text = ""

                servingLbl3.ForeColor = Color.DimGray
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                servingLbl5.Text = ""

                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 2 Then
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl3.ForeColor = Color.DimGray
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                servingLbl5.Text = ""

                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 3 Then
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl4.ForeColor = Color.DimGray
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                servingLbl5.Text = ""

                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 4 Then
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                servingLbl5.Text = ""

                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 5 Then
                If Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter) Then
                    servingLbl6.Text = tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(5).customerAssigncounter.Priority > 0 Then
                        servingLbl6.ForeColor = Color.IndianRed
                    Else
                        servingLbl6.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl6.ForeColor = Color.DimGray
                servingLbl6.Text = ""
            End If
        End If
SKIP:
    End Sub

    Private Sub frmCounterQueuingBoardQueueList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmCounterQueuingBoardQueueList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class