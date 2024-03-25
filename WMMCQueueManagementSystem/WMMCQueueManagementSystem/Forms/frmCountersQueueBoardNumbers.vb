Public Class frmCountersQueueBoardNumbers
    Private Counter As Counter

    Sub New(counter As Counter)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Counter = counter
    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [All informations viewed on the results are managable using the third party application called 'Hospital Result Management System']", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Private Sub frmServiceCounterPaging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtclock.Text = TimeOfDay.ToShortTimeString
        lblCounterName.Text = Counter.Section.ToUpper + "   "
        showHelp()
        refreshDataIntertval.Start()
        resultPerDeptList.Start()
        CLOCK.Start()
    End Sub

    Private Sub lblCounterName_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblCounterName_Click_1(sender As Object, e As EventArgs) Handles lblCounterName.Click

    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)

        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                counterlbl1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), If(tmpServingCustomerOfServers(0).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(0).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(0).serverTransaction.CounterName, tmpServingCustomerOfServers(0).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(0).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl1.ForeColor = Color.DimGray
                    servingLbl1.Text = "NONE"
                End If
            Else
                servingLbl1.ForeColor = Color.DimGray
                counterlbl1.Text = "NONE"
                servingLbl1.Text = "NONE"

                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = "NONE"
                servingLbl2.Text = "NONE"

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 1 Then
                counterlbl2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), If(tmpServingCustomerOfServers(1).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(1).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(1).serverTransaction.CounterName, tmpServingCustomerOfServers(1).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(1).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl2.ForeColor = Color.DimGray
                    servingLbl2.Text = "NONE"
                End If
            Else
                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = "NONE"
                servingLbl2.Text = "NONE"

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 2 Then
                counterlbl3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), If(tmpServingCustomerOfServers(2).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(2).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(2).serverTransaction.CounterName, tmpServingCustomerOfServers(2).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(2).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl3.ForeColor = Color.DimGray
                    servingLbl3.Text = "NONE"
                End If
            Else
                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 3 Then
                counterlbl4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), If(tmpServingCustomerOfServers(3).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(3).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(3).serverTransaction.CounterName, tmpServingCustomerOfServers(3).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(3).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl4.ForeColor = Color.DimGray
                    servingLbl4.Text = "NONE"
                End If
            Else
                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 4 Then
                counterlbl5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), If(tmpServingCustomerOfServers(4).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(4).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(4).serverTransaction.CounterName, tmpServingCustomerOfServers(4).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(4).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl5.ForeColor = Color.DimGray
                    servingLbl5.Text = "NONE"
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 5 Then
                counterlbl6.Text = If(Not IsNothing(tmpServingCustomerOfServers(5).serverTransaction), If(tmpServingCustomerOfServers(5).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(5).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(5).serverTransaction.CounterName, tmpServingCustomerOfServers(5).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(5).serverTransaction.CounterName), "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter) Then
                    servingLbl6.Text = tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(5).customerAssigncounter.Priority > 0 Then
                        servingLbl6.ForeColor = Color.IndianRed
                    Else
                        servingLbl6.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl6.ForeColor = Color.DimGray
                    servingLbl6.Text = "NONE"
                End If
            Else
                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
            End If
        End If
SKIP:
    End Sub

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lbwelcome.Text = marqueeText(lbwelcome.Text)
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub

    Private Sub frmCountersQueueBoardNumbers_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
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

    Private Sub resultPerDeptList_Tick(sender As Object, e As EventArgs) Handles resultPerDeptList.Tick
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim customerWithResults As New List(Of CustomerAssignCounter)
        customerWithResults = customerAssignCounterController.GetNumbersWithResults(Counter)
        lstResultList.Clear()
        If Not IsNothing(customerWithResults) Then
            For Each customer As CustomerAssignCounter In customerWithResults
                If customer.Priority > 0 Then
                    lstResultList.Items.Add(customer.ProcessedQueueNumber, 1)
                Else
                    lstResultList.Items.Add(customer.ProcessedQueueNumber, 0)
                End If
            Next
        End If
    End Sub

    Private Sub frmCountersQueueBoardNumbers_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class