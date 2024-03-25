Public Class frmManageMainCounterOrder
    Private QueueuingCounter As List(Of Counter) = Nothing

    Public Sub GetQueueingCounter()
        Dim counterController As New CounterController
        Me.QueueuingCounter = counterController.GetAllPCCQueuingCounters()
        If Not IsNothing(Me.QueueuingCounter) Then
            ListView1.LargeImageList = CounterImageIconsLg
            ListView1.View = View.LargeIcon
            ListView1.LargeImageList = CounterImageIconsLg
            ListView1.Items.Clear()
            For Each queuecounter In Me.QueueuingCounter
                ListView1.Items.Add("", If(queuecounter.Icon > CounterImageIconsLg.Images.Count, 0, queuecounter.Icon))
            Next
        End If
    End Sub

    Private Sub frmManageMainCounterOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetQueueingCounter()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Do you want to save this order?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For i As Integer = 0 To Me.QueueuingCounter.Count - 1
                Me.QueueuingCounter(i).MainCounterCTR = (i + 1)
            Next
            Dim counterController As New CounterController
            If counterController.UpdateMainCounterOrder(Me.QueueuingCounter) Then
                MessageBox.Show("Order successfully saveda", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.Yes
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0)
            Dim tmp As New Counter
            tmp = QueueuingCounter(index)
            If index = 0 Then
                For i As Integer = 0 To Me.QueueuingCounter.Count - 1
                    If i = Me.QueueuingCounter.Count - 1 Then
                        QueueuingCounter(i) = tmp
                    Else
                        QueueuingCounter(i) = QueueuingCounter(i + 1)
                    End If
                Next
            Else
                QueueuingCounter(index) = QueueuingCounter(index - 1)
                QueueuingCounter(index - 1) = tmp
            End If
            ListView1.Items.Clear()
            For Each queuecounter In Me.QueueuingCounter
                ListView1.Items.Add("", If(queuecounter.Icon > CounterImageIconsLg.Images.Count, 0, queuecounter.Icon))
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0)
            Dim tmp As New Counter
            tmp = QueueuingCounter(index)
            If index = (QueueuingCounter.Count - 1) Then
                For i As Integer = -(Me.QueueuingCounter.Count - 1) To 0
                    If Not i = 0 Then
                        QueueuingCounter(Math.Abs(i)) = QueueuingCounter(Math.Abs(i) - 1)
                    End If
                Next
                QueueuingCounter(0) = tmp
            Else
                QueueuingCounter(index) = QueueuingCounter(index + 1)
                QueueuingCounter(index + 1) = tmp
            End If
            ListView1.Items.Clear()
            For Each queuecounter In Me.QueueuingCounter
                ListView1.Items.Add("", If(queuecounter.Icon > CounterImageIconsLg.Images.Count, 0, queuecounter.Icon))
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0)
            Dim counter As Counter = QueueuingCounter(index)
            txtDepartment.Text = counter.Department.Trim.ToUpper
            txtSection.Text = counter.Section.Trim.ToUpper
            txtCounterName1.Text = counter.ServiceDescription.Trim.ToUpper
            txtCounterName2.Text = counter.ServiceDescription2.Trim.ToUpper
        End If
    End Sub
End Class