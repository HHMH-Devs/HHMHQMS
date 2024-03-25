Public Class frmDatePicker2
    Private _selectedDate As Date = Nothing

    Public Property SelectedDate As Date
        Get
            Return _selectedDate
        End Get
        Private Set(value As Date)
            _selectedDate = value
        End Set
    End Property

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        SelectedDate = dtpDate.Value
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class