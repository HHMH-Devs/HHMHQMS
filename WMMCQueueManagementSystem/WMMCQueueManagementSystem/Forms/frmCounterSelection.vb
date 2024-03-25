Public Class frmCounterSelection
    Private _selectedCounters As List(Of Counter)
    Private selectionLimit As Integer = 5
    Private CounterList As List(Of Counter)
    Private isPCCClinicSelected As Boolean = False
    Private isMABClinicSelected As Boolean = False


    Public Property SelectedCounter As List(Of Counter)
        Get
            Return _selectedCounters
        End Get
        Private Set(value As List(Of Counter))
            _selectedCounters = value
        End Set
    End Property

    Public Property MABSelected As Boolean
        Get
            Return isMABClinicSelected
        End Get
        Private Set(value As Boolean)
            isMABClinicSelected = value
        End Set
    End Property

    Public Property PCCSelected As Boolean
        Get
            Return isPCCClinicSelected
        End Get
        Private Set(value As Boolean)
            isPCCClinicSelected = value
        End Set
    End Property

    Private Sub GetCounters()
        Dim counterController As New CounterController
        Me.CounterList = counterController.GetAllQueuingCountersForTransferring
        If Not IsNothing(Me.CounterList) Then
            For Each counter As Counter In Me.CounterList
                ListView1.Items.Add("", counter.Icon)
            Next
        End If
        ListView1.Items.Add("", ListView1.LargeImageList.Images.Count - 2)
        ListView1.Items.Add("", ListView1.LargeImageList.Images.Count - 1)
    End Sub

    Private Sub frmCounterSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imgs As New ImageList
        For Each img As Image In CounterImageIconsLg.Images
            imgs.Images.Add(img)
        Next
        imgs.Images.Add(CustomImageIconsLg.Images(4))
        imgs.Images.Add(CustomImageIconsLg.Images(5))
        imgs.ColorDepth = CounterImageIconsLg.ColorDepth
        imgs.ImageSize = New Size(CounterImageIconsLg.ImageSize)
        ListView1.LargeImageList = imgs
        GetCounters()
    End Sub

    Private Sub btnUnassign_Click(sender As Object, e As EventArgs) Handles btnUnassign.Click
        If ListView1.CheckedItems.Count > 10 Then
            MessageBox.Show("You can only select up to 10 counters to display on the board", "Counter Count Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ListView1.CheckedItems.Count <= 0 Then
            MessageBox.Show("You must select atleast 1 counter to display on the board", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim counter As New List(Of Counter)
            For i As Integer = 0 To ListView1.CheckedIndices.Count - 1
                Dim index As Integer = ListView1.CheckedIndices(i)
                If index = ListView1.Items.Count - 2 Then
                    PCCSelected = True
                ElseIf index = ListView1.Items.Count - 1 Then
                    MABSelected = True
                Else
                    counter.Add(CounterList(index))
                End If
            Next
            SelectedCounter = counter
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Dim ctr As Integer = ListView1.CheckedIndices.Count
        If ctr > 10 Then
            lblSelectableCounter.Text = 0
            If e.Item.Checked Then
                e.Item.Checked = False
                MessageBox.Show("You can only select up to 4 counters to display on the board", "Counter Count Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            lblSelectableCounter.Text = (10 - ListView1.CheckedIndices.Count)
        End If
    End Sub
End Class