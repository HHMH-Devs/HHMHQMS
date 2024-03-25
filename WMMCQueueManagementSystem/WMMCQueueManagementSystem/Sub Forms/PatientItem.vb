Public Class PatientItem
    Private _patientInQueue As CustomerAssignCounter
    Private _incomingPatient As CustomerInfo
    Private _isPatientReady As Boolean = False


    Public Property QueuedPatient As CustomerAssignCounter
        Get
            Return _patientInQueue
        End Get
        Private Set(value As CustomerAssignCounter)
            _patientInQueue = value
        End Set
    End Property

    Public Property IncomingPatient As CustomerInfo
        Get
            Return _incomingPatient
        End Get
        Private Set(value As CustomerInfo)
            _incomingPatient = value
        End Set
    End Property

    Sub New(customerAssignCounters As CustomerAssignCounter)
        ' This call is required by the designer.
        InitializeComponent()
        QueuedPatient = customerAssignCounters
        _isPatientReady = True
        SetInformationView()
    End Sub

    Sub New(incomingPatient As CustomerInfo)
        ' This call is required by the designer.
        InitializeComponent()
        Me.IncomingPatient = incomingPatient
        _isPatientReady = False
        SetTemporaryInformationView()
    End Sub

    Private Sub roundCorners(obj As UserControl)
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

    Private Sub ServeMe()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Or Application.OpenForms().OfType(Of frmServiceCounter_Clinic).Any Then
            If Me.ParentForm.Name = frmServiceCounter_Clinic.Name Then
                Dim frm As frmServiceCounter_Clinic = Me.ParentForm
                frm.ServedDoubleClickedCustomer(Me)
            End If
        End If
    End Sub

    Private Sub ShowPatientInfo()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Or Application.OpenForms().OfType(Of frmServiceCounter_Clinic).Any Then
            If Me.ParentForm.Name = frmServiceCounter_Clinic.Name Then
                Dim frm As frmServiceCounter_Clinic = Me.ParentForm
                frm.SelectedPatient(Me)
            End If
        End If
    End Sub

    Private Sub ShowPatientInfoTemp()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Or Application.OpenForms().OfType(Of frmServiceCounter_Clinic).Any Then
            If Me.ParentForm.Name = frmServiceCounter_Clinic.Name Then
                Dim frm As frmServiceCounter_Clinic = Me.ParentForm
                frm.ViewPatientInfo(Me)
            End If
        End If
    End Sub

    Private Sub ConsultThisPatient()
        If Application.OpenForms().OfType(Of frmServiceCounter).Any Or Application.OpenForms().OfType(Of frmServiceCounter_Clinic).Any Then
            If Application.OpenForms().OfType(Of frmServiceCounter_Clinic).Any Then
                Dim frm As frmServiceCounter_Clinic = Me.ParentForm
            End If
        End If
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

    Private Sub SetTemporaryInformationView()
        Dim customerName As String = ""
        Dim customerAge As String = 0
        Dim customerSex As String = ""
        If IsNothing(IncomingPatient.FirstName) And IsNothing(IncomingPatient.Lastname) Then
            customerName = "N/A"
        ElseIf (Not IncomingPatient.FirstName.Trim.Length > 0) And (Not IncomingPatient.Lastname.Trim.Length > 0) Then
            customerName = "N/A"
        Else
            customerName = IncomingPatient.Lastname.ToUpper & ", " & IncomingPatient.FirstName & " " & IncomingPatient.Middlename
        End If
        If IsNothing(IncomingPatient.Sex) Then
            customerSex = "N/A"
        ElseIf Not IncomingPatient.Sex.Trim.Length > 0 Then
            customerSex = "N/A"
        Else
            customerSex = IncomingPatient.Sex
        End If
        customerAge = DateDiff(DateInterval.Year, IncomingPatient.BirthDate, Today).ToString
        lblCustomerInfo.Text = customerName & Environment.NewLine & customerAge & "|" & customerSex
        lblCustomerInfo.ForeColor = Color.DimGray
        lblGeneratedNumber.Text = "INCOMNG PATIENT"
        lblGeneratedNumber.ForeColor = Color.DimGray
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
        If IsNothing(QueuedPatient.ServedCustomer) Then
            lblGeneratedNumber.Text = lblGeneratedNumber.Text
            If QueuedPatient.ForHelee Then
                pbDepartment.Image = imgList.Images(5)
            Else
                pbDepartment.Image = imgList.Images(2)
            End If
        ElseIf Not IsNothing(QueuedPatient.ServedCustomer.DateTimeEnd) Then
            pbDepartment.Image = imgList.Images(4)
        ElseIf Not IsNothing(QueuedPatient.ServedCustomer.DateTimeStart) Then
            pbDepartment.Image = imgList.Images(3)
        ElseIf IsNothing(QueuedPatient.ServedCustomer.DateTimeStart) Then
            If QueuedPatient.ForHelee Then
                pbDepartment.Image = imgList.Images(5)
            Else
                pbDepartment.Image = imgList.Images(2)
            End If
        End If
    End Sub

    Private Sub PatientItem_Click(sender As Object, e As EventArgs) Handles Me.Click
        If _isPatientReady Then
            ShowPatientInfo()
        Else
            ShowPatientInfoTemp()
        End If
    End Sub

    Private Sub lblCustomerInfo_Click_1(sender As Object, e As EventArgs) Handles lblCustomerInfo.Click
        If _isPatientReady Then
            ShowPatientInfo()
        Else
            ShowPatientInfoTemp()
        End If
    End Sub

    Private Sub lblGeneratedNumber_Click_1(sender As Object, e As EventArgs) Handles lblGeneratedNumber.Click
        If _isPatientReady Then
            ShowPatientInfo()
        Else
            ShowPatientInfoTemp()
        End If
    End Sub

    Private Sub pbDepartment_Click_1(sender As Object, e As EventArgs) Handles pbDepartment.Click
        If _isPatientReady Then
            ShowPatientInfo()
        Else
            ShowPatientInfoTemp()
        End If
    End Sub

    Private Sub PatientItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblCustomerInfo_DoubleClick(sender As Object, e As EventArgs) Handles lblCustomerInfo.DoubleClick
        ServeMe()
    End Sub

    Private Sub PatientItem_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        ServeMe()
    End Sub

    Private Sub lblGeneratedNumber_DoubleClick(sender As Object, e As EventArgs) Handles lblGeneratedNumber.DoubleClick
        ServeMe()
    End Sub

    Private Sub pbDepartment_DoubleClick(sender As Object, e As EventArgs) Handles pbDepartment.DoubleClick
        ServeMe()
    End Sub
End Class
