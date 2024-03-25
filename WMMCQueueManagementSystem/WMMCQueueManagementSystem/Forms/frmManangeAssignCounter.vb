Public Class frmManageServerAssignCounter
    Private AssignedCounters As List(Of ServerAssignCounter)
    Private AvailableCounters As List(Of Counter)
    Private Server As Server
    Private edited As Boolean = False

    Sub New(server As Server)
        InitializeComponent()
        Me.Server = server
    End Sub

    Private Sub LoadCounters()
        Dim counterController As New CounterController
        Dim counters = counterController.GetCertainServerUnassignCounter(Me.Server.Server_ID)
        lstCounters.Clear()
        If Not IsNothing(counters) Then
            Me.AvailableCounters = counters
            For Each counter As Counter In counters
                lstCounters.Items.Add("", If(counter.Icon > CounterImageIconsLg.Images.Count, 0, counter.Icon))
            Next
        End If

        Dim serverAssignCounterController As New ServerAssignCounterController
        Dim serverAssignCounters = serverAssignCounterController.GetCertainServerAssignCounter(Me.Server.Server_ID)
        lstAssignedCounters.Clear()
        If Not IsNothing(serverAssignCounters) Then
            Me.AssignedCounters = serverAssignCounters
            For Each serverAssignCounter As ServerAssignCounter In serverAssignCounters
                lstAssignedCounters.Items.Add("", If(serverAssignCounter.Counter.Icon > CounterImageIconsLg.Images.Count, 0, serverAssignCounter.Counter.Icon))
            Next
        End If
    End Sub

    Private Sub AssignCounter()
        If lstCounters.SelectedItems.Count > 0 Then
            If MessageBox.Show("Do you want to assign to these counters?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim serverAssignCounters As New List(Of ServerAssignCounter)
                Dim serverAssignCounterController As New ServerAssignCounterController
                For i As Integer = 0 To lstCounters.SelectedIndices.Count - 1
                    Dim serverAssignCounter As New ServerAssignCounter
                    Dim index As Integer = lstCounters.SelectedIndices(i)
                    serverAssignCounter.Counter_ID = AvailableCounters(index).Counter_ID
                    serverAssignCounter.Server_ID = Server.Server_ID
                    serverAssignCounter.isMain = If(Not (AvailableCounters(index).isQueueingCounter > 0), True, False)
                    serverAssignCounters.Add(serverAssignCounter)
                Next
                If serverAssignCounterController.AddServerAssignCounter(serverAssignCounters) Then
                    LoadCounters()
                    edited = True
                    MessageBox.Show("Counters added successfuly", "Assign Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong during the process", "Assign Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a counter you want to assign", "No Counter Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UnassignCounter()
        If lstAssignedCounters.SelectedItems.Count > 0 Then
            If MessageBox.Show("Do you want to Unassign these counters?", "Unassign Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim ids As New List(Of Long)
                Dim serverAssignCounterController As New ServerAssignCounterController
                For i As Integer = 0 To lstAssignedCounters.SelectedIndices.Count - 1
                    Dim index As Integer = lstAssignedCounters.SelectedIndices(i).ToString
                    ids.Add(AssignedCounters(index).ServerAssignCounter_ID)
                Next
                If serverAssignCounterController.DeleteServerAssignCounter(ids) Then
                    LoadCounters()
                    edited = True
                    MessageBox.Show("Counters removed successfuly", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong during the process", "Assign Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select an assign counter you want to remove", "No Counter Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmManangeAssignCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstCounters.LargeImageList = CounterImageIconsLg
        lstAssignedCounters.LargeImageList = CounterImageIconsLg
        LoadCounters()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        AssignCounter()
    End Sub

    Private Sub btnUnassign_Click(sender As Object, e As EventArgs) Handles btnUnassign.Click
        UnassignCounter()
    End Sub

    Private Sub lstCounters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCounters.SelectedIndexChanged
        If lstCounters.SelectedItems.Count > 0 Then
            Dim index As Integer = lstCounters.SelectedIndices(0).ToString
            lblCounterName.Text = AvailableCounters(index).Section
        Else
            lblCounterName.Text = "NO SELECTED COUNTER"
        End If
    End Sub

    Private Sub lstCounters_KeyDown(sender As Object, e As KeyEventArgs) Handles lstCounters.KeyDown
        If e.KeyCode = Keys.Enter Then
            AssignCounter()
        End If
    End Sub

    Private Sub lstAssignedCounters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAssignedCounters.SelectedIndexChanged
        If lstAssignedCounters.SelectedItems.Count > 0 Then
            Dim index As Integer = lstAssignedCounters.SelectedIndices(0).ToString
            lblCounterName.Text = AssignedCounters(index).Counter.Section
        Else
            lblCounterName.Text = "NO SELECTED COUNTER"
        End If
    End Sub

    Private Sub lstAssignedCounters_KeyDown(sender As Object, e As KeyEventArgs) Handles lstAssignedCounters.KeyDown
        If e.KeyCode = Keys.Delete Then
            UnassignCounter()
        End If
    End Sub

    Private Sub frmManageServerAssignCounter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If edited Then
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub lstCounters_DoubleClick(sender As Object, e As EventArgs) Handles lstCounters.DoubleClick
        AssignCounter()
    End Sub

    Private Sub lstAssignedCounters_DoubleClick(sender As Object, e As EventArgs) Handles lstAssignedCounters.DoubleClick
        UnassignCounter()
    End Sub
End Class