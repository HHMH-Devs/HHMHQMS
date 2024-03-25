Public Class frmSelectToGenerate
    Private _SelectedPriotiry As Integer = 0

    Public Property Priority As Integer
        Get
            Return _SelectedPriotiry
        End Get
        Private Set(value As Integer)
            _SelectedPriotiry = value
        End Set
    End Property

    Private Sub btnGenerateNormalNumber_Click(sender As Object, e As EventArgs) Handles btnGenerateNormalNumber.Click
        Priority = 0
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmSelectToGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbIncludeNotes_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnGeneratePriorityNumber_Click(sender As Object, e As EventArgs)
        Priority = 1
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnGenerateSilentNumber_Click(sender As Object, e As EventArgs) Handles btnGenerateSilentNumber.Click
        Priority = 2
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class