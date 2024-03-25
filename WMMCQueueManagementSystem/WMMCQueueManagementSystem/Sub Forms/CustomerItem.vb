Public Class CustomerItem
    Private _customerAssignCounter As CustomerAssignCounter

    Public Property QueuedPatient As CustomerAssignCounter
        Get
            Return _customerAssignCounter
        End Get
        Private Set(value As CustomerAssignCounter)
            _customerAssignCounter = value
        End Set
    End Property

    Sub New(customerAssignCounters As CustomerAssignCounter)
        ' This call is required by the designer.
        InitializeComponent()
        QueuedPatient = customerAssignCounters
        SetInformationView()
    End Sub

    Private Function CalculateCustomerSatisfaction(allowedTime As Long, datequeued As Date) As Long
        Dim elapseTime As Long = DateDiff(DateInterval.Minute, datequeued, Now)
        If elapseTime >= allowedTime Then
            Return 3
        ElseIf elapseTime >= (allowedTime / 2) Then
            Return 2
        Else
            Return 1
        End If
    End Function

    Private Sub SendMyCustomerInfo()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Then
            If Me.ParentForm.Name = frmServiceCounter.Name Then
                Dim frm As frmServiceCounter = Me.ParentForm
                frm.SetSelectedCustomerNumber(Me)
            End If
        End If
    End Sub

    Private Sub ServeMe()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Then
            If Me.ParentForm.Name = frmServiceCounter.Name Then
                Dim frm As frmServiceCounter = Me.ParentForm
                frm.ServedDoubleClickedCustomer(Me)
            End If
        End If
    End Sub

    Private Sub SetInformationView()
        Dim customerName As String = ""
        Dim customerAge As String = 0
        Dim customerSex As String = ""
        Dim queueDept As String = ""
        If IsNothing(QueuedPatient.Customer.CustomerInfo.FirstName) And IsNothing(QueuedPatient.Customer.CustomerInfo.Lastname) Then
            customerName = "N/A"
        ElseIf (Not QueuedPatient.Customer.CustomerInfo.FirstName.Trim.Length > 0) And (Not QueuedPatient.Customer.CustomerInfo.Lastname.Trim.Length > 0) Then
            customerName = "N/A"
        Else
            customerName = QueuedPatient.Customer.CustomerInfo.Lastname.ToUpper & ", " & QueuedPatient.Customer.CustomerInfo.FirstName & " " & QueuedPatient.Customer.CustomerInfo.Middlename
        End If
        If IsNothing(QueuedPatient.Customer.CustomerInfo.Sex) Then
            customerSex = "N/A"
        ElseIf Not QueuedPatient.Customer.CustomerInfo.Sex.Trim.Length > 0 Then
            customerSex = "N/A"
        Else
            customerSex = QueuedPatient.Customer.CustomerInfo.Sex
        End If
        customerAge = DateDiff(DateInterval.Year, QueuedPatient.Customer.CustomerInfo.BirthDate, QueuedPatient.Customer.DateOfVisit).ToString
        lblCustomerInfo.Text = customerName & Environment.NewLine & customerAge & "|" & customerSex
        lblGeneratedNumber.Text = QueuedPatient.ProcessedQueueNumber
        Me.BackColor = If(QueuedPatient.Priority > 0, Color.Maroon, Color.FromArgb(13, 52, 145))
        If QueuedPatient.ForHelee Then
            pbStatus.Image = imgList.Images(3)
        Else
            If CalculateCustomerSatisfaction(QueuedPatient.Counter.allowedTurnaroundTime, QueuedPatient.DateTimeQueued) >= 3 Then
                pbStatus.Image = imgList.Images(2)
            ElseIf CalculateCustomerSatisfaction(QueuedPatient.Counter.allowedTurnaroundTime, QueuedPatient.DateTimeQueued) >= 2 Then
                pbStatus.Image = imgList.Images(1)
            Else
                pbStatus.Image = imgList.Images(0)
            End If
        End If
    End Sub

    Private Sub pbDepartment_Click(sender As Object, e As EventArgs)
        SendMyCustomerInfo()
    End Sub

    Private Sub lblCustomerInfo_Click(sender As Object, e As EventArgs) Handles lblCustomerInfo.Click
        SendMyCustomerInfo()
    End Sub

    Private Sub lblGeneratedNumber_Click(sender As Object, e As EventArgs) Handles lblGeneratedNumber.Click
        SendMyCustomerInfo()
    End Sub

    Private Sub pbLabResult_Click(sender As Object, e As EventArgs)
        SendMyCustomerInfo()
    End Sub

    Private Sub pbStatus_Click(sender As Object, e As EventArgs) Handles pbStatus.Click
        SendMyCustomerInfo()
    End Sub
    Private Sub CustomerItem_Click(sender As Object, e As EventArgs) Handles Me.Click
        SendMyCustomerInfo()
    End Sub

    Private Sub CustomerItem_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        ServeMe()
    End Sub

    Private Sub pbDepartment_DoubleClick(sender As Object, e As EventArgs)
        ServeMe()
    End Sub

    Private Sub lblCustomerInfo_DoubleClick(sender As Object, e As EventArgs) Handles lblCustomerInfo.DoubleClick
        ServeMe()
    End Sub

    Private Sub lblGeneratedNumber_DoubleClick(sender As Object, e As EventArgs) Handles lblGeneratedNumber.DoubleClick
        ServeMe()
    End Sub

    Private Sub pbLabResult_DoubleClick(sender As Object, e As EventArgs)
        ServeMe()
    End Sub

    Private Sub pbStatus_DoubleClick(sender As Object, e As EventArgs) Handles pbStatus.DoubleClick
        ServeMe()
    End Sub

    Private Sub CustomerItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If QueuedPatient.Priority = 1 Then
            MessageBox.Show("This is a Priority Number: Must be serve immediately", "Priority Queue", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf QueuedPatient.Priority = 2 Then
            MessageBox.Show("This is a Silent Number: Serving this will not alarm the queuing board.", "Silent Queue", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("This is a Normal Number: Just a normal number", "Normal Queue", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
