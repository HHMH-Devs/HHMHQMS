Public Class frmSelectQiosk
    Private _selectedQueueCounter As Counter = Nothing
    Private SoloCounters As List(Of Counter) = Nothing
    Public Property SelecedQueueCounter As Counter
        Get
            Return _selectedQueueCounter
        End Get
        Private Set(value As Counter)
            _selectedQueueCounter = value
        End Set
    End Property

    Private Sub GetAllSoloCounter()
        Dim counterController As New CounterController
        SoloCounters = counterController.GetAllSoloCounter()
        ListView1.Items.Clear()
        ListView1.LargeImageList = CounterImageIconsLg
        ListView1.View = View.LargeIcon
        ListView1.LargeImageList = CounterImageIconsLg
        If Not IsNothing(SoloCounters) Then
            For Each soloCounter In SoloCounters
                ListView1.Items.Add("", If(soloCounter.Icon > CounterImageIconsLg.Images.Count, 0, soloCounter.Icon))
            Next
        End If
    End Sub

    Private Sub SelectLoginSelection()
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0).ToString
            SelecedQueueCounter = SoloCounters(index)
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub frmSelectQiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAllSoloCounter()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        SelectLoginSelection()
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = Keys.Enter Then
            SelectLoginSelection()
        End If
    End Sub
End Class