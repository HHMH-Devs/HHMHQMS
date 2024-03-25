Public Class Dashboard
    Dim monthCtr As Integer = 0


    Private Sub showPanelBoardSelection(flag As Boolean)
        pnlQueueBoardSelection.Visible = flag
    End Sub


    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblThisPcCounterName.Text = SavedCounterName.ToUpper.Trim
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

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

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
