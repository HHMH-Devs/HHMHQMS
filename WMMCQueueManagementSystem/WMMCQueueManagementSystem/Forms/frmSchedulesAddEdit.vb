Public Class frmSchedulesAddEdit
    Public Property DayOfTheWeek() As String
    Public Property From() As String
    Public Property [To]() As String

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(str As String)
        InitializeComponent()
    End Sub

    Private Sub SaveAvailability_BTN_Click(sender As Object, e As EventArgs) Handles SaveAvailability_BTN.Click
        DayOfTheWeek = DayoftheWeek_CB.SelectedItem
        From = From_CB.SelectedItem
        [To] = To_CB.SelectedItem
    End Sub
End Class