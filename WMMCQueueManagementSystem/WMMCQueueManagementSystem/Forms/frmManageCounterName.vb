Public Class frmManageCounterName
    Private _CounterName As String = Nothing
    Private tmpCounterBoards As List(Of CounterBoard)
    Private _selectedCounterBoard As CounterBoard = Nothing


    Public Property SelectedCounterBoard As CounterBoard
        Get
            Return _selectedCounterBoard
        End Get
        Private Set(value As CounterBoard)
            _selectedCounterBoard = value
        End Set
    End Property

    Public Property CounterName As String
        Get
            Return _CounterName
        End Get
        Private Set(value As String)
            _CounterName = value
        End Set
    End Property

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        txtCounterCode.DropDownStyle = ComboBoxStyle.DropDown
        btnConfirmCounterBoard.Hide()
        btnconfirm.Show()
    End Sub

    Sub New(counterName As String)
        InitializeComponent()
        txtCounterCode.DropDownStyle = ComboBoxStyle.DropDown
        Me.CounterName = counterName
        For i As Integer = 1 To 5
            txtCounterCode.Items.Add(counterName.ToUpper + " 0" + i.ToString)
        Next
        If txtCounterCode.Items.Count > 0 Then
            txtCounterCode.SelectedIndex = 0
        End If
        btnConfirmCounterBoard.Hide()
        btnconfirm.Show()
    End Sub

    Sub New(counter As Counter)
        InitializeComponent()
        Dim counterController As New CounterController
        txtCounterCode.DropDownStyle = ComboBoxStyle.DropDown
        tmpCounterBoards = counterController.GetCertainCounterPreDefineCounterLabels(counter.Counter_ID)
        If Not IsNothing(tmpCounterBoards) Then
            For Each ctrItem As CounterBoard In tmpCounterBoards
                txtCounterCode.Items.Add(ctrItem.DisplayedName.ToUpper)
            Next
            btnconfirm.Hide()
            btnConfirmCounterBoard.Show()
        End If
        If txtCounterCode.Items.Count > 0 Then
            txtCounterCode.SelectedIndex = 0
        End If
    End Sub

    Sub New(counterBoards As List(Of CounterBoard))
        InitializeComponent()
        txtCounterCode.DropDownStyle = ComboBoxStyle.DropDownList
        If Not IsNothing(counterBoards) Then
            tmpCounterBoards = counterBoards
            For Each ctrItem As CounterBoard In tmpCounterBoards
                txtCounterCode.Items.Add(ctrItem.DisplayedName.ToUpper)
            Next
            btnconfirm.Hide()
            btnConfirmCounterBoard.Show()
        End If
        If txtCounterCode.Items.Count > 0 Then
            txtCounterCode.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        If txtCounterCode.Text.Count > 0 Then
            CounterName = txtCounterCode.Text.ToUpper
            Me.DialogResult = DialogResult.Yes
        Else
            MessageBox.Show("Counter name is a required field", "Empty Counter Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub frmManageCounterName_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnConfirmCounterBoard_Click(sender As Object, e As EventArgs) Handles btnConfirmCounterBoard.Click
        SelectedCounterBoard = tmpCounterBoards(txtCounterCode.SelectedIndex)
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class