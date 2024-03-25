Public Class Counters
    Private QueuingCounters As List(Of Counter)

    Private Sub Counters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.LargeImageList = CounterImageIconsLg
        getAllCounters()
    End Sub

    Private Sub getAllCounters()
        Dim counterController As New CounterController
        QueuingCounters = counterController.GetAllCounters()

        ListView1.Items.Clear()
        For Each counter In QueuingCounters
            ListView1.Items.Add("", If(counter.Icon > CounterImageIconsLg.Images.Count, 0, counter.Icon))
        Next
    End Sub

    Private Sub NewCounter()
        Dim frm As New frmManageCounters
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            getAllCounters()
        End If
    End Sub

    Private Sub DeleteCounter()
        If ListView1.SelectedItems.Count > 0 Then
            MessageBox.Show("Deleting this counter will also delete the transaction data that uses this counter. (It includes history of the user's queuing transcation and etc.)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Are you sure to delete this counters?", "Delete Counters", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim counter As New Counter
                Dim counterController As New CounterController
                Dim index As Long = ListView1.SelectedIndices(0)
                If counterController.DeleteCounter(QueuingCounters(index)) Then
                    getAllCounters()
                    MessageBox.Show("Counter deleted successfuly", "Delete Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong during the process", "Delete Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            MessageBox.Show("Please select a counter you want to delete.", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UpdateCounter()
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Long = ListView1.SelectedIndices(0)
            Dim frm As New frmManageCounters(QueuingCounters(index))
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.Yes Then
                getAllCounters()
            End If
        Else
            MessageBox.Show("Please select a counter you want to update.", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateCounter()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0).ToString
            lblCounterName.Text = Me.QueuingCounters(index).Section
        Else
            lblCounterName.Text = "PLEASE SELECT A COUNTER TO MANAGE"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        NewCounter()
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        NewCounter()
    End Sub

    Private Sub UpdateCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateCounterToolStripMenuItem.Click
        UpdateCounter()
    End Sub

    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDown
        If e.Button = MouseButtons.Right Then
            CounterStrip.Show(MousePosition)
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        UpdateCounter()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteCounter()
    End Sub

    Private Sub DeleteCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteCounterToolStripMenuItem.Click
        DeleteCounter()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            UpdateCounter()
        ElseIf e.KeyCode = Keys.Delete Then
            DeleteCounter()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmManageMainCounterOrder
        frm.ShowDialog(Me)
    End Sub
End Class
