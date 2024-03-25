Public Class frmSelectCounterLogin
    Private _counter As Counter

    Public Property SelectedCounter As Counter
        Get
            Return _counter
        End Get
        Private Set(value As Counter)
            _counter = value
        End Set
    End Property

    Sub New(counter As Counter)
        InitializeComponent()
        Me.SelectedCounter = counter
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmSelectCounterLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        If txtCounterName.Text = Me.SelectedCounter.CounterCode.ToString Then
            Me.DialogResult = DialogResult.Yes
        Else
            MessageBox.Show("Incorrect code. Please try again", "Counter Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCounterName.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class