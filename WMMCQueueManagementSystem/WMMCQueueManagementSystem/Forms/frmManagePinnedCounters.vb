Public Class frmManagePinnedCounters
    Private PinnedCounters As List(Of SeverCounterShorcuts)
    Private AvailableCounters As List(Of Counter)
    Private Server As Server
    Private edited As Boolean = False

    Sub New(server As Server)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Server = server
    End Sub
    Private Sub lblTittle_Click(sender As Object, e As EventArgs) Handles lblTittle.Click

    End Sub

    Private Sub LoadCounters()
        Dim counterController As New CounterController
        Me.AvailableCounters = counterController.GetCertainServerUnpinCounters(Me.Server.Server_ID)
        lstCounters.Clear()
        If Not IsNothing(Me.AvailableCounters) Then
            For Each counter As Counter In AvailableCounters
                lstCounters.Items.Add("", If(counter.Icon > CounterImageIconsLg.Images.Count, 0, counter.Icon))
            Next
        End If

        Me.PinnedCounters = counterController.GetCertainServerCounterShorcuts(Me.Server.Server_ID)
        lstPinnedCounters.Clear()
        If Not IsNothing(Me.PinnedCounters) Then
            For Each pinnedCounter As SeverCounterShorcuts In PinnedCounters
                lstPinnedCounters.Items.Add("", If(pinnedCounter.Counter.Icon > CounterImageIconsLg.Images.Count, 0, pinnedCounter.Counter.Icon))
            Next
            lblPinCount.Text = 10 - Me.PinnedCounters.Count
        Else
            lblPinCount.Text = 10
        End If
    End Sub

    Private Sub PinnedSelectedCounters()
        If lstCounters.SelectedItems.Count > 0 Then
            If Not IsNothing(Me.PinnedCounters) Then
                If lstCounters.SelectedItems.Count > 10 Then
                    MessageBox.Show("Please select up to 10 counters top pin", "Pin Limit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo skip
                ElseIf Me.PinnedCounters.Count > 10 Then
                    MessageBox.Show("You can only pin up to 10 counters.", "Maximum Pinned Reached", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo skip
                ElseIf Me.PinnedCounters.Count + lstCounters.SelectedItems.Count > 10 Then
                    MessageBox.Show("You can only pin up to 10 counters.", "Maximum Pinned Reached", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo skip
                End If
            Else
                If lstCounters.SelectedItems.Count > 10 Then
                    MessageBox.Show("Please select up to 10 counters top pin", "Pin Limit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo skip
                End If
            End If
            Dim counterController As New CounterController
            Dim serverCounterShortcuts As New List(Of SeverCounterShorcuts)
            For i As Integer = 0 To lstCounters.SelectedIndices.Count - 1
                Dim index As Integer = lstCounters.SelectedIndices(i)
                Dim serverCounterShortcut As New SeverCounterShorcuts
                serverCounterShortcut.Server_ID = Me.Server.Server_ID
                serverCounterShortcut.Counter_ID = Me.AvailableCounters(index).Counter_ID
                serverCounterShortcuts.Add(serverCounterShortcut)
            Next
            If counterController.PinnedCounter(serverCounterShortcuts) Then
                LoadCounters()
                edited = True
                MessageBox.Show("Counters pinned succesfully", "Pinned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Something went wrong on the process", "Pinned Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
skip:
            Else
                MessageBox.Show("Please select some counter to pin", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub RemoveFromPinned()
        If lstPinnedCounters.SelectedItems.Count > 0 Then
            Dim counterController As New CounterController
            Dim serverCounterShortcuts As New List(Of SeverCounterShorcuts)
            For i As Integer = 0 To lstPinnedCounters.SelectedIndices.Count - 1

                Dim index As Integer = lstPinnedCounters.SelectedIndices(i)
                Dim serverCounterShortcut As New SeverCounterShorcuts
                serverCounterShortcut.ServerShorcut_ID = Me.PinnedCounters(index).ServerShorcut_ID
                serverCounterShortcuts.Add(serverCounterShortcut)
            Next

            If counterController.UnpinnedCounter(serverCounterShortcuts) Then
                LoadCounters()
                edited = True
                MessageBox.Show("Counters unpinned succesfully", "Unpinned", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Something went wrong on the process", "Unpinned Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub frmManagePinnedCounters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstCounters.LargeImageList = CounterImageIconsLg
        lstPinnedCounters.LargeImageList = CounterImageIconsLg
        LoadCounters()
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        PinnedSelectedCounters()
    End Sub

    Private Sub btnUnassign_Click(sender As Object, e As EventArgs) Handles btnUnassign.Click
        RemoveFromPinned()
    End Sub

    Private Sub frmManagePinnedCounters_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If edited Then
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub
End Class