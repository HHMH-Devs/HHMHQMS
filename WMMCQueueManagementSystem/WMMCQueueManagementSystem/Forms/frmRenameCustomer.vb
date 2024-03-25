Public Class frmRenameCustomer
    Private _customer As Customer = Nothing
    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Private Set(value As Customer)
            _customer = value
        End Set
    End Property
    Sub New(customer As Customer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Customer = customer
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnconfirm_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        Dim customerController As New CustomerController
        Customer.FullName = txtCounterName.Text.Trim
        If customerController.RenameCustomer(Customer) Then
            Me.Customer = customerController.GetCertainCustomer(Me.Customer.Customer_ID)
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub frmRenameCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class