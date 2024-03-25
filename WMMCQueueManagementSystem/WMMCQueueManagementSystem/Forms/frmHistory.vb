Public Class frmHistory
    Private Sub LoadQueuingHistoryMain(filter As CustomerAssignCounter)
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim listQueueHistory As New List(Of GetCustomerQueuingHistoryAll)
        listQueueHistory = customerAssignCounterController.GetQueueHistoryForMain(filter)
        If Not IsNothing(listQueueHistory) Then
            dvgHistory.Rows.Clear()
            Dim ctr As Long = 1
            For Each data As GetCustomerQueuingHistoryAll In listQueueHistory
                If data.OffDate Then
                    If Not IsNothing(data.ServedBy) Then
                        dvgHistory.Rows.Add(ctr, data.ServedBy, data.CustomerAssignCounter.ProcessedQueueNumber, imgList.Images.Item(If(data.CustomerAssignCounter.Priority > 0, 1, 0)), data.CustomerAssignCounter.DateTimeQueued.ToLongDateString, data.CustomerAssignCounter.Counter.Section, If(data.timeInterval > 0, data.timeInterval.ToString + " Mins", "Less than a Minute"))
                    Else
                        dvgHistory.Rows.Add(ctr, "In Queue", data.CustomerAssignCounter.ProcessedQueueNumber, imgList.Images.Item(If(data.CustomerAssignCounter.Priority > 0, 1, 0)), data.CustomerAssignCounter.DateTimeQueued.ToLongDateString, data.CustomerAssignCounter.Counter.Section, "Waiting")
                    End If
                Else
                    If Not IsNothing(data.ServedBy) Then
                        dvgHistory.Rows.Add(ctr, data.ServedBy, data.CustomerAssignCounter.ProcessedQueueNumber, imgList.Images.Item(If(data.CustomerAssignCounter.Priority > 0, 1, 0)), data.CustomerAssignCounter.DateTimeQueued.ToLongDateString, data.CustomerAssignCounter.Counter.Section, If(data.timeInterval > 0, data.timeInterval.ToString + " Mins", "Less than a Minute"))
                    Else
                        dvgHistory.Rows.Add(ctr, "Unserved", data.CustomerAssignCounter.ProcessedQueueNumber, imgList.Images.Item(If(data.CustomerAssignCounter.Priority > 0, 1, 0)), data.CustomerAssignCounter.DateTimeQueued.ToLongDateString, data.CustomerAssignCounter.Counter.Section, "Unserved")
                    End If
                End If
                ctr += 1
            Next
        End If
    End Sub

    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadQueuingHistoryMain(Nothing)
    End Sub

    Private Sub txtTextFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTextFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dvgHistory.Rows.Count - 1
                If dvgHistory.Rows(x).Cells("generatedNumber").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Or dvgHistory.Rows(x).Cells("assignDepartment").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Or dvgHistory.Rows(x).Cells("dateTimeQueue").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Or dvgHistory.Rows(x).Cells("counterName").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Then
                    dvgHistory.Rows(x).Visible = True
                Else
                    dvgHistory.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub txtTextFilter_TextChanged(sender As Object, e As EventArgs) Handles txtTextFilter.TextChanged

    End Sub
End Class