Public Class frmSelectBDayForTouch
    Private _selectedMonth As Integer = 0
    Private _selectedDay As Integer = 0
    Private _selectedYear As Integer = 0

    Public Property SelectedMonth As Integer
        Get
            Return _selectedMonth
        End Get
        Private Set(value As Integer)
            _selectedMonth = value
        End Set
    End Property

    Public Property SelectedDay As Integer
        Get
            Return _selectedDay
        End Get
        Private Set(value As Integer)
            _selectedDay = value
        End Set
    End Property

    Public Property SelectedYear As Integer
        Get
            Return _selectedYear
        End Get
        Private Set(value As Integer)
            _selectedYear = value
        End Set
    End Property

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Try
            SelectedMonth = cbMonth.SelectedIndex + 1
            SelectedDay = cbDay.SelectedIndex + 1
            SelectedYear = nubYear.Value
            Dim birthdate As New Date(SelectedYear, SelectedMonth, SelectedDay)
            Me.DialogResult = DialogResult.Yes
        Catch ex As Exception
            MessageBox.Show("Please enter your birthday correctly", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonth.SelectedIndexChanged

    End Sub
End Class