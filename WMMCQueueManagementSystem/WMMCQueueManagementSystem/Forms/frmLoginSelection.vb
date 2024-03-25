Public Class frmLoginSelection
    Private _serverTransaction As ServerTransaction
    Private _loggedServer As Server

    Public Property ServerTransaction() As ServerTransaction
        Get
            Return _serverTransaction
        End Get
        Private Set(value As ServerTransaction)
            _serverTransaction = value
        End Set
    End Property

    Sub New(server As Server)
        InitializeComponent()
        Me._loggedServer = server
    End Sub

    '    Private Sub SelectLoginSelection()
    '        If ListView1.SelectedItems.Count > 0 Then
    '            Dim index As Integer = ListView1.SelectedIndices(0).ToString
    '            If Me._loggedServer.ServerAssignCounter(index).Counter.CounterCode.Replace(" ", "") = "" Then
    '                GoTo openCounter
    '            End If
    '            Dim frm As New frmSelectCounterLogin(Me._loggedServer.ServerAssignCounter(index).Counter)
    '            frm.ShowDialog(Me)
    '            If frm.DialogResult = DialogResult.Yes Then
    'openCounter:
    '                Dim frmSelectCounterName As New frmManageCounterName(Me._loggedServer.ServerAssignCounter(index).Counter)
    '                frmSelectCounterName.ShowDialog()
    '                If frmSelectCounterName.DialogResult = DialogResult.Yes Then
    '                    Dim serverTransactionController As New ServerTransactionController
    '                    Dim serverTransaction As New ServerTransaction
    '                    serverTransaction = serverTransactionController.NewServerTransaction(Me._loggedServer.ServerAssignCounter(index))
    '                    If Not IsNothing(serverTransaction) Then
    '                        serverTransaction.ServerAssignCounter = Me._loggedServer.ServerAssignCounter(index)
    '                        Me.ServerTransaction = serverTransaction
    '                        Me.DialogResult = DialogResult.Yes
    '                    Else
    '                        MessageBox.Show("Failed to login on this counter", "Counter Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End Sub

    Private Sub SelectLoginSelection()
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Integer = ListView1.SelectedIndices(0).ToString
            Dim tmpCounterBoardID As Long = 0
            Dim tmpCounterID As Long = 0
            Dim tmpCounterName As String = ""
            Dim isProceed As Boolean = False
            'If SavedCounterBoard.Counter_ID = Me._loggedServer.ServerAssignCounter(index).Counter.Counter_ID Then 'Change Counter Logged
            '    tmpCounterBoardID = SavedCounterBoard.CounterBoard_ID
            '    tmpCounterID = SavedCounterBoard.Counter_ID
            '    tmpCounterName = SavedCounterBoard.DisplayedName
            '    isProceed = True
            'Else
            Dim counterController As New CounterController
            Dim counterBoards As List(Of CounterBoard) = counterController.GetCertainCounterPreDefineCounterLabels(Me._loggedServer.ServerAssignCounter(index).Counter.Counter_ID)
            Dim frmSelectCounterName As frmManageCounterName
            If IsNothing(counterBoards) Then
                frmSelectCounterName = New frmManageCounterName(Me._loggedServer.ServerAssignCounter(index).Counter.ServiceDescription)
                frmSelectCounterName.ShowDialog(Me)
                If frmSelectCounterName.DialogResult = DialogResult.Yes Then
                    tmpCounterBoardID = 0
                    tmpCounterID = Me._loggedServer.ServerAssignCounter(index).Counter.Counter_ID
                    tmpCounterName = frmSelectCounterName.CounterName.ToUpper.Trim
                    isProceed = True
                End If
            ElseIf Not counterBoards.Count > 0 Then
                frmSelectCounterName = New frmManageCounterName(Me._loggedServer.ServerAssignCounter(index).Counter.ServiceDescription)
                frmSelectCounterName.ShowDialog(Me)
                If frmSelectCounterName.DialogResult = DialogResult.Yes Then
                    tmpCounterBoardID = 0
                    tmpCounterID = Me._loggedServer.ServerAssignCounter(index).Counter.Counter_ID
                    tmpCounterName = frmSelectCounterName.CounterName.ToUpper.Trim
                    isProceed = True
                End If
            Else
                frmSelectCounterName = New frmManageCounterName(counterBoards)
                frmSelectCounterName.ShowDialog(Me)
                If frmSelectCounterName.DialogResult = DialogResult.Yes Then
                    tmpCounterBoardID = frmSelectCounterName.SelectedCounterBoard.CounterBoard_ID
                    tmpCounterID = Me._loggedServer.ServerAssignCounter(index).Counter.Counter_ID
                    tmpCounterName = frmSelectCounterName.SelectedCounterBoard.DisplayedName.ToUpper.Trim
                    isProceed = True
                End If
            End If
            ''End If
            If isProceed Then
                Dim serverTransactionController As New ServerTransactionController
                ''Dim serverTransaction As New ServerTransaction
                Dim serverTransaction = serverTransactionController.NewServerTransaction(Me._loggedServer.ServerAssignCounter(index))
                If Not IsNothing(serverTransaction) Then
                    serverTransaction.ServerAssignCounter = Me._loggedServer.ServerAssignCounter(index)
                    Me.ServerTransaction = serverTransaction
                    Dim cbTransaction As New CounterBoardTransaction With {
                        .CounterBoard_ID = tmpCounterBoardID,
                        .Counter_ID = tmpCounterID,
                        .ServerTransaction_ID = serverTransaction.ServerTransaction_ID
                    }
                    If serverTransactionController.NewBoardTrasaction(cbTransaction) Then
                        Dim _newSavedCounterBoard As New CounterBoard With {
                            .CounterBoard_ID = tmpCounterBoardID,
                            .Counter_ID = tmpCounterID,
                            .DisplayedName = tmpCounterName
                        }
                        SavedCounterBoard = _newSavedCounterBoard
                        Me.DialogResult = DialogResult.Yes
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub AutoLoginClinic(clinicCounter As ServerAssignCounter)
        If clinicCounter.Counter.CounterCode.Replace(" ", "") = "" Then
            GoTo openCounter
        End If
        Dim frm As New frmSelectCounterLogin(clinicCounter.Counter)
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
openCounter:
            Dim serverTransaction As New ServerTransaction
            Dim serverTransactionController As New ServerTransactionController
            serverTransaction = serverTransactionController.NewServerTransaction(clinicCounter)
            If Not IsNothing(serverTransaction) Then
                serverTransaction.ServerAssignCounter = clinicCounter
                Me.ServerTransaction = serverTransaction
                Me.DialogResult = DialogResult.Yes
            Else
                MessageBox.Show("Failed to login on this counter", "Counter Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub frmLoginSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLoggedUserName.Text = Me._loggedServer.FullName
        If Me._loggedServer.AccountType = 1 Then
            txtSelectedDept.Text = "Please select the clinic to login"
            If Me._loggedServer.ServerAssignCounter.Count > 1 Then
                Dim imgs As New ImageList
                imgs.Images.Add(CustomImageIconsLg.Images(4)) '0) PCC CLINIC
                imgs.Images.Add(CustomImageIconsLg.Images(5)) '1) MAB CLINIC
                imgs.Images.Add(CustomImageIconsLg.Images(6)) '2) MAB HYBRID CLINIC
                imgs.Images.Add(CustomImageIconsLg.Images(9)) '3) MAB HYBRID CLINIC
                imgs.Images.Add(CustomImageIconsLg.Images(10)) '4) MAB HYBRID CLINIC
                imgs.ColorDepth = CounterImageIconsLg.ColorDepth
                imgs.ImageSize = New Size(CounterImageIconsLg.ImageSize)
                ListView1.LargeImageList = imgs
                ListView1.View = View.LargeIcon
                If Not IsNothing(Me._loggedServer.ServerAssignCounter) Then
                    For Each serverAssingCounter In Me._loggedServer.ServerAssignCounter
                        Dim ico As Integer = 0
                        If serverAssingCounter.Counter.CounterType = 1 Then
                            ico = 1
                        ElseIf serverAssingCounter.Counter.CounterType = 2 Then
                            ico = 0
                        ElseIf serverAssingCounter.Counter.CounterType = 3 Then
                            ico = 2
                        ElseIf serverAssingCounter.Counter.CounterType = 4 Then
                            ico = 3
                        ElseIf serverAssingCounter.Counter.CounterType = 5 Then
                            ico = 4
                        End If
                        ListView1.Items.Add(serverAssingCounter.Counter.Department, ico)
                    Next
                End If
            Else
                For Each assignCounter As ServerAssignCounter In Me._loggedServer.ServerAssignCounter
                    If assignCounter.Counter.CounterType > 0 Then
                        AutoLoginClinic(assignCounter)
                        Exit For
                    End If
                Next
            End If
        ElseIf Me._loggedServer.AccountType = 0 Then
            txtSelectedDept.Text = "Please select the department to login"
            ListView1.LargeImageList = CounterImageIconsLg
            ListView1.View = View.LargeIcon
            ListView1.LargeImageList = CounterImageIconsLg
            If Not IsNothing(Me._loggedServer.ServerAssignCounter) Then
                For Each serverAssingCounter In Me._loggedServer.ServerAssignCounter
                    ListView1.Items.Add("", If(serverAssingCounter.Counter.Icon > CounterImageIconsLg.Images.Count, 0, serverAssingCounter.Counter.Icon))
                Next
            End If
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        SelectLoginSelection()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to close this program?", "Close Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Abort
        End If
    End Sub

    Private Sub frmLoginSelection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogoutUser()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectLoginSelection()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If Me._loggedServer.AccountType = 1 Then
            If ListView1.SelectedItems.Count > 0 Then
                Dim index As Integer = ListView1.SelectedIndices(0)
                txtSelectedDept.Text = Me._loggedServer.ServerAssignCounter(index).Counter.ServiceDescription & " (" & Me._loggedServer.ServerAssignCounter(index).Counter.Section & ")"
            Else
                txtSelectedDept.Text = "Please select the clinic to login"
            End If
        ElseIf Me._loggedServer.AccountType = 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                Dim index As Integer = ListView1.SelectedIndices(0)
                txtSelectedDept.Text = Me._loggedServer.ServerAssignCounter(index).Counter.Section
            Else
                txtSelectedDept.Text = "Please select the department to login"
            End If
        End If
    End Sub

    Private Sub txtSelectedDept_Click(sender As Object, e As EventArgs) Handles txtSelectedDept.Click

    End Sub
End Class