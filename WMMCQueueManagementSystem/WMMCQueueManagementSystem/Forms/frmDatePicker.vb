Public Class frmDatePicker
    Private _selectedDateFrom As Date = Nothing
    Private _selectedDateTo As Date = Nothing

    Public Property SelectedDateFrom As Date
        Get
            Return _selectedDateFrom
        End Get
        Private Set(value As Date)
            _selectedDateFrom = value
        End Set
    End Property
    Public Property SelectedDateTo As Date
        Get
            Return _selectedDateTo
        End Get
        Private Set(value As Date)
            _selectedDateTo = value
        End Set
    End Property

    Private Sub frmDatePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDateFrom.Value = Now
    End Sub

    Private Sub btnSelectDate_Click(sender As Object, e As EventArgs) Handles btnSelectDate.Click
        SelectedDateFrom = dtpDateFrom.Value
        SelectedDateTo = dtpDateTo.Value
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class