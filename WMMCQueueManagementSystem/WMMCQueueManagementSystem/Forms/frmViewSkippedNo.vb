Public Class frmViewSkippedNo
    Private SkippedCustomers As List(Of ServedCustomer)
    Private _selectedCustomer As ServedCustomer

    Private Counter As Counter

    Public Property SelectedCustomer As ServedCustomer
        Get
            Return _selectedCustomer
        End Get
        Private Set(value As ServedCustomer)
            _selectedCustomer = value
        End Set
    End Property

    Sub New(counter As Counter)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Counter = counter
    End Sub

    Private Sub LoadSkippedCustomer()
        Dim skippedCustomer As New List(Of ServedCustomer)
        Dim servedCustomerController As New ServedCustomerController
        skippedCustomer = servedCustomerController.GetSkippedCustomerByCounter(Counter.Counter_ID)
        Me.SkippedCustomers = skippedCustomer
        ListView1.Clear()
        For Each customer As ServedCustomer In SkippedCustomers
            ListView1.Items.Add(customer.CustomerAssignCounter.ProcessedQueueNumber, customer.CustomerAssignCounter.Priority)
        Next
    End Sub

    Private Sub ViewQueueInfo()
        Me.lblQueueNo.Text = ""
        Me.lblPatientName.Text = ""
        Me.lblTimePrinted.Text = ""
        Me.lblHoldTime.Text = ""
        If (Me.ListView1.SelectedItems.Count > 0) Then
            Dim num As Long = Me.ListView1.SelectedIndices(0)
            Dim expression As New ServedCustomer
            expression = Me.SkippedCustomers(CInt(num))
            If Not Information.IsNothing(expression) Then
                Dim num2 As Long = DateAndTime.DateDiff(DateInterval.Minute, expression.CustomerAssignCounter.DateTimeQueued, DateAndTime.Now)
                Me.lblQueueNo.Text = expression.CustomerAssignCounter.ProcessedQueueNumber.Trim.ToUpper
                Me.lblPatientName.Text = expression.CustomerAssignCounter.Customer.FullName.Trim.ToUpper
                Me.lblTimePrinted.Text = Strings.Format(expression.CustomerAssignCounter.DateTimeQueued, "MMM dd, yyyy h:mm tt")
                Me.lblHoldTime.Text = (num2.ToString.ToUpper & " Min/s")
            End If
        End If
    End Sub




    Private Sub frmViewSkippedNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSkippedCustomer()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        selectSkippedCustomer()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            selectSkippedCustomer()
        End If
    End Sub

    Private Sub selectSkippedCustomer()
        If ListView1.SelectedItems.Count > 0 Then
            Dim index As Long = ListView1.SelectedIndices(0)
            If MessageBox.Show("Do you want to try serving this patient again?", "Serve Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                SkippedCustomers(index).ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                If servedCustomerController.UpdateSkippedCustomeraServetimeStart(SkippedCustomers(index)) Then
                    SelectedCustomer = SkippedCustomers(index)
                    Me.DialogResult = DialogResult.Yes
                End If
            End If
        End If
    End Sub

    Private Sub btnserve_Click_1(sender As Object, e As EventArgs) Handles btnserve.Click
        selectSkippedCustomer()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Me.ViewQueueInfo()
    End Sub
End Class