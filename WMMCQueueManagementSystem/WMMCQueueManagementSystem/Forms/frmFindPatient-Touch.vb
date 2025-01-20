Public Class frmFindPatient_Touch
    Private _matchedData As List(Of CustomerInfo) = Nothing
    Private _tempData As CustomerInfo = Nothing
    Private _selectedMonth As Integer = 0
    Private _selectedDay As Integer = 0
    Private _selectedYear As Integer = 0
    Private selectedBday As Nullable(Of Date) = Nothing
    Dim longMonth() As String = {"JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property TemporaryData As CustomerInfo
        Get
            Return _tempData
        End Get
        Private Set(value As CustomerInfo)
            _tempData = value
        End Set
    End Property

    Public Property MatchedData As List(Of CustomerInfo)
        Get
            Return _matchedData
        End Get
        Private Set(value As List(Of CustomerInfo))
            _matchedData = value
        End Set
    End Property

    Private Sub roundCorners(obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None
        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()
        'top left corner
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)
        'top right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)
        'buttom right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
        'buttom left corner
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        DGP.CloseFigure()
        obj.Region = New Region(DGP)
    End Sub

    Private Sub FindPatientWithBday()
        Dim apiController As New APIController
        Dim searchText As String = txtFName.Text.Trim & " " & txtMName.Text.Trim & " " & txtLName.Text.Trim.Trim
        Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, selectedBday)
        If IsNothing(matchedInfo) Then
            lblWarning.Text = "Oops, sorry there is no record matching the name and birth date you entered. Do you want to register instead?"
            pnlRegisterAlert.Show()
        ElseIf matchedInfo.Count <= 0 Then
            lblWarning.Text = "Oops, sorry there is no record matching the name and birth date you entered. Do you want to register instead?"
            pnlRegisterAlert.Show()
        Else
            MatchedData = Nothing
            Dim tmpdt As New CustomerInfo
            tmpdt.FirstName = txtFName.Text.Trim.ToUpper
            tmpdt.Middlename = txtMName.Text.Trim.ToUpper
            tmpdt.Lastname = txtLName.Text.Trim.ToUpper
            tmpdt.BirthDate = selectedBday.Value
            TemporaryData = tmpdt
            MatchedData = matchedInfo
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtFName.Click
        OpenOnScreenKeyboard()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnConfirmSelection_Click(sender As Object, e As EventArgs) Handles btnConfirmSelection.Click
        CloseOnScreenKeyboard()
        Try
            _selectedMonth = cbMonth.SelectedIndex + 1
            _selectedDay = cbDay.SelectedIndex + 1
            _selectedYear = nubYear.Value
            selectedBday = New Date(_selectedYear, _selectedMonth, _selectedDay)
        Catch ex As Exception
            selectedBday = Nothing
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your birth date here", Me.cbMonth)
            End With
        End Try
        If txtFName.TextLength > 0 And txtLName.TextLength > 0 And Not IsNothing(selectedBday) Then
            FindPatientWithBday()
        ElseIf txtFName.TextLength <= 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your first name here", Me.txtFName)
            End With
        ElseIf txtLName.TextLength <= 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your last name here", Me.txtLName)
            End With
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MatchedData = Nothing
        Dim tmpdt As New CustomerInfo
        tmpdt.FirstName = txtFName.Text.Trim.ToUpper
        tmpdt.Middlename = txtMName.Text.Trim.ToUpper
        tmpdt.Lastname = txtLName.Text.Trim.ToUpper
        tmpdt.BirthDate = selectedBday.Value
        TemporaryData = tmpdt
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        pnlRegisterAlert.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New frmConsent
        frm.ShowDialog()
        If Not frm.DialogResult = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMonth.SelectedIndexChanged

    End Sub

    Private Sub frmFindPatient_Touch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class