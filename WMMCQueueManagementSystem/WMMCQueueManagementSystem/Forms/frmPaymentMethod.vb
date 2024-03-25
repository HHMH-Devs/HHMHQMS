Public Class frmPaymentMethod
    Private _paymentMethod As Long = 0
    Private _notes As String = ""
    Private _department As String = ""
    Private _section As String = ""

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        cbPaymentMethod.SelectedIndex = 0
    End Sub

    Public Property PaymentMethod As Long
        Get
            Return _paymentMethod
        End Get
        Private Set(value As Long)
            _paymentMethod = value
        End Set
    End Property

    Public Property PaymentDepartment As String
        Get
            Return _department
        End Get
        Private Set(value As String)
            _department = value
        End Set
    End Property
    Public Property PaymentSection As String
        Get
            Return _section
        End Get
        Private Set(value As String)
            _section = value
        End Set
    End Property
    Public Property NotesAndRemaks As String
        Get
            Return _notes
        End Get
        Private Set(value As String)
            _notes = value
        End Set
    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbPaymentMethod.SelectedIndex >= 0 Then
            NotesAndRemaks = txtNotesAndRemarks.Text.Trim
            PaymentMethod = (cbPaymentMethod.SelectedIndex + 1)
            Me.DialogResult = DialogResult.Yes
        Else
            MessageBox.Show("Please select a payment method for this transaction", "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class