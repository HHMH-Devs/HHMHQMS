Imports System.Speech.Synthesis

Public Class frmServiceCounter
    Private tmpCounterName As String = "", tmpConsultationConsent1 As String = Nothing, tmpConsultationConsent2 As String = Nothing
    Private consultationAssignORD As ServerAssignCounter = Nothing, paymentAutoTransferCounter As ServerAssignCounter = Nothing, screeningAssignORD As ServerAssignCounter = Nothing
    Private consultationRefferingORD As ReferringConsultant = Nothing
    Private _loggedServer As Server
    Private servingTime As Long = 0
    Private ServingCustomer As ServedCustomer = Nothing
    Private tmpSelectedCustomer As CustomerItem = Nothing
    Private queueList As List(Of CustomerItem) = Nothing
    Private AutoRefereshQueueList As Boolean = False
    Private Mute As Boolean = False
    Private isVoice As Boolean = False
    Private chartMode As Boolean = True
    Private WithEvents frmX As New Form
    Private WithEvents frmY As New Form
    Private WithEvents frmZ As New Form
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private tmpSelectedConsultation As CustomerConsultation
    Private diagnosticResultList As List(Of Diagnostics)
    Private healthcheckHistory As List(Of HealthCheck)
    Private tmpSelectedhealthcheck As HealthCheck
    Private AutoRefreshListTimer As Timer
    Private forViewOnlyCustomer As CustomerInfo
    Private transferCounter_gcber As Counter = Nothing
    Private transferCounter_respier As Counter = Nothing
    Private transferCounter_payment_cash As Counter = Nothing
    Private transferCounter_payment_card As Counter = Nothing
    Private transferCounter_payment_hmo As Counter = Nothing
    Private transferCounter_payment_philhealth As Counter = Nothing
    Private bizboxRegistrationList As List(Of Bizbox_PatientDailyRegistration)
    Private tmpSelectedBizboxRegistration As Bizbox_PatientDailyRegistration
    Private forBizboxConsultation As Bizbox_Consultation
    Private autoTransferCounter As ServerAssignCounter
    Private bizboxRequisitions As List(Of PatientBixbox_PatRegisters)
    Private selectedBizboxRequisitions As PatientBixbox_PatRegisters
    Private latestbizboxRequests As PatientBixbox_PatRegisters
    Private ReadOnly doctorsHeaderLoc As String = WMMCQMSConfig.DoctorHeaderLocation()
    Private ReadOnly doctorsSignatureLoc As String = WMMCQMSConfig.DoctorSignatureLocation()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.AutoRefereshQueueList = AutoRefreshQueueList()
    End Sub
    Public Property Server As Server
        Get
            Return _loggedServer
        End Get
        Private Set(value As Server)
            _loggedServer = value
        End Set
    End Property

    Private Sub ShowHelp()
        frmHelp.ShowDialog()
    End Sub

    Private Sub ToogleChartMode(flag As Boolean)
        chartMode = flag
        pnlNoVitals.Hide()
        If chartMode Then
            btnSummaryModes.Text = "TABLE MODE"
            pnlTableMode.Hide()
            pnlCharMode.Show()
        Else
            btnSummaryModes.Text = "CHART MODE"
            pnlCharMode.Hide()
            pnlTableMode.Show()
        End If
    End Sub

    Private Sub ToogleDiagnosticConsent(flag As Boolean)
        If flag Then
            Me.btnMakeDeleteDiagnosticConsent.Text = "REMOVE CONSENT"
            Me.btnMakeDeleteDiagnosticConsent.BackColor = Color.Maroon
            Me.btnViewDiagnosticConsent.Show()
        Else
            Me.btnMakeDeleteDiagnosticConsent.Text = "ATTACH CONSENT"
            Me.btnMakeDeleteDiagnosticConsent.BackColor = Color.LimeGreen
            Me.btnViewDiagnosticConsent.Hide()
        End If
    End Sub

    Public Sub GotoDiagnosticResult(link As String)
        Try
            Dim urlLink = New Uri(link).LocalPath
            If System.IO.File.Exists(urlLink) Then
                Dim fileInfo As New IO.FileInfo(urlLink)
                Dim fileExtn As String = (fileInfo.Extension).ToUpper.Trim
                If fileExtn.Contains("PDF") Then
                    Dim resultURL As New List(Of String)
                    With resultURL
                        .Add(urlLink)
                    End With
                    Dim frm As New frmPDFResultViewer(resultURL)
                    frm.ShowDialog(Me)
                ElseIf MessageBox.Show("This type of result maybe unsafe to open. Do you want to continue?", "Open Unsafe File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(urlLink)
                End If
            ElseIf Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute) Then
                Process.Start(link)
            Else
                MessageBox.Show("Failed to open the result. The file maybe doesn't exist or the file is corrupted.", "Cannot View Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to open the result. The file maybe doesn't exist or the file is corrupted.", "Cannot View Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetSelectedCustomerNumber(customer As CustomerItem)
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("Cannot view other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNothing(customer) Then
            If Not IsNothing(Me.queueList) Then
                For Each customerItem As CustomerItem In queueList
                    Dim priorityColor As New Color
                    If customerItem.QueuedPatient.Priority = 1 Then
                        priorityColor = Color.MistyRose
                    ElseIf customerItem.QueuedPatient.Priority = 2 Then
                        priorityColor = Color.Gainsboro
                    Else
                        priorityColor = Color.Honeydew
                    End If
                    With customerItem
                        .BackColor = priorityColor
                    End With
                Next
            End If
            Dim selectedPriorityColor As New Color
            If customer.QueuedPatient.Priority = 1 Then
                selectedPriorityColor = Color.IndianRed
            ElseIf customer.QueuedPatient.Priority = 2 Then
                selectedPriorityColor = Color.DarkGray
            Else
                selectedPriorityColor = Color.PaleGreen
            End If
            customer.BackColor = selectedPriorityColor
            Me.tmpSelectedCustomer = customer
        End If
    End Sub

    Public Sub ServedDoubleClickedCustomer(customer As CustomerItem)
        tmpSelectedCustomer = customer
        ServeCertainNumber()
        GetServingCustomerPCCInfo()
    End Sub

    Private Function GetBizboxPatientLatestConsultation(ByVal customerInfo As CustomerInfo) As Bizbox_Consultation
        Dim controller As New CustomerConsultationController
        Return controller.GetBizboxLatestCustomerConsultation(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetBizboxPatientRegistrations(ByVal customerInfo As CustomerInfo) As List(Of Bizbox_PatientDailyRegistration)
        Dim xapi As New BizboxAPI
        Return xapi.GetPatientRegistrations2(customerInfo.FK_emdPatients)
    End Function

    Private Function GetBizboxPatientVitalSummary(ByVal customerInfo As CustomerInfo) As List(Of Bizbox_PatientDailyRegistration)
        Dim xapi As New BizboxAPI
        Return xapi.GetPatientVitalSummary(customerInfo.FK_emdPatients)
    End Function


    Private Function GetPatientLatestConsultation(customerInfo As CustomerInfo) As CustomerConsultation
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetLatestCustomerConsultation(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientConsultation(customerInfo As CustomerInfo) As List(Of CustomerConsultation)
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetAllCustomerConsultationHistory(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientAssignedORDScreening(customerInfo As CustomerInfo) As CustomerConsultation
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetCertianCustomerInitialConsultation(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientInitialConsultation(customerInfo As CustomerInfo) As CustomerConsultation
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetCertianCustomerInitialConsultation(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientLatestAssignConsultant(customerInfo As CustomerInfo) As CustomerConsultation
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetCertianCustomerInitialConsultation(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientLatestDiagnosis(customerInfo As CustomerInfo) As Diagnostics
        Dim diagnosticController As New DiagnosticsController
        Return diagnosticController.GetPatientLatestDiagnosticRequest(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetaPatientDiagnosisResults(customerInfo As CustomerInfo) As List(Of Diagnostics)
        Dim apiControler As New APIController
        Return apiControler.GetCertainPatientDiagnosticResults(customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientVitalSummary(customerInfo As CustomerInfo) As List(Of CustomerConsultation)
        Dim consultationController As New CustomerConsultationController
        Return consultationController.GetCustomerVitalSummary(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Function GetPatientPrescribedMeds(customerInfo As CustomerInfo) As List(Of Prescription)
        Dim serverID As Long = LoggedServer.ServerAssignCounter.Server.Server_ID
        Dim prescriptionController As New PrescriptionController
        Return prescriptionController.GetPatientPrescribeMeds(customerInfo.Info_ID, customerInfo.FK_emdPatients, serverID)
    End Function

    Private Function GetPatientPrescribedMeds(customerInfo As CustomerInfo, keyword As String, allItem As Boolean) As List(Of Prescription)
        Dim prescriptionController As New PrescriptionController
        Dim kword As String = keyword.Trim
        Dim serverID As Long = LoggedServer.ServerAssignCounter.Server.Server_ID
        If allItem Then
            serverID = 0
        End If
        Return prescriptionController.GetPatientPrescribeMeds(customerInfo.Info_ID, customerInfo.FK_emdPatients, kword, serverID)
    End Function

    Private Function GetPatientHealthChecks(customerInfo As CustomerInfo) As List(Of HealthCheck)
        Dim healthcheckController As New HealthcheckController
        Return healthcheckController.GetCertainPatientHealthcheckHistory(customerInfo.Info_ID)
    End Function

    Private Function GetPatientQueueHistory(customerInfo As CustomerInfo) As List(Of GetCustomerQueuingHistoryAll)
        Dim customerAssignCounterControl As New CustomerAssignCounterController
        Return customerAssignCounterControl.GetCertainCustomerQueueHistory(customerInfo.Info_ID, customerInfo.FK_emdPatients)
    End Function

    Private Sub FillInitialConsultationDetail()
        Me.lblInitialConsultation_AssignPhysician.Text = ""
        Me.lblInitialConsultation_ConsultationType.Text = ""
        Me.lblInitialConsultation_Height.Text = ""
        Me.lblInitialConsultation_Weight.Text = ""
        Me.lblInitialConsultation_Allergies.Text = ""
        Me.lblInitialConsultation_SignSymptoms.Text = ""
        Me.lblInitialConsultation_BP.Text = ""
        Me.lblInitialConsultation_PR.Text = ""
        Me.lblInitialConsultation_RR.Text = ""
        Me.lblInitialConsultation_Temperature.Text = ""
        Me.lblInitialConsultation_O2.Text = ""
        Me.lblInitialConsultation_ChiefComplaint.Text = ""
        Me.lblInitialConsultation_ConsultationType.Text = ""
        If Not Information.IsNothing(Me.forBizboxConsultation) Then
            Dim assignedPhysician As String = ""
            If Not Information.IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter) Then
                assignedPhysician = "DR. " & Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter.Server.FullName & " (" & Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter.Server.PRC & ")"
            End If
            Me.lblInitialConsultation_AssignPhysician.Text = String.Concat("DR. ", Me.forBizboxConsultation.BizboxRegistration.DoctorData.Lastname & ", " & Me.forBizboxConsultation.BizboxRegistration.DoctorData.Firstname & " " & Me.forBizboxConsultation.BizboxRegistration.DoctorData.MiddleName & " " & Me.forBizboxConsultation.BizboxRegistration.DoctorData.SuffixName & " (" & Me.forBizboxConsultation.BizboxRegistration.DoctorData.PRC, ")" & vbCrLf & Format(Me.forBizboxConsultation.BizboxRegistration.RegistrationDate, "MMM dd, yyyy @ h:mm tt") & vbCrLf & assignedPhysician).Trim.ToUpper
            Me.lblInitialConsultation_ConsultationType.Text = String.Concat(If(Not IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleEmpNo), Me.forBizboxConsultation.BizboxRegistration.DoleEmpNo, "N/A") & vbCrLf & If(Not IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleRefNO), Me.forBizboxConsultation.BizboxRegistration.DoleRefNO.Trim.ToUpper, "N/A") & vbCrLf & If(Not Information.IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleAppStat), Me.forBizboxConsultation.BizboxRegistration.DoleAppStat.Trim.ToUpper, "N/A"))
            Me.lblInitialConsultation_Height.Text = ((Me.forBizboxConsultation.BizboxRegistration.Height1) & " " & Me.forBizboxConsultation.BizboxRegistration.HeightUnit)
            Me.lblInitialConsultation_Weight.Text = ((Me.forBizboxConsultation.BizboxRegistration.Weight) & " " & Me.forBizboxConsultation.BizboxRegistration.WeightUnit)
            Me.lblInitialConsultation_Allergies.Text = ""
            Me.lblInitialConsultation_SignSymptoms.Text = ""
            Me.lblInitialConsultation_BP.Text = ((Me.forBizboxConsultation.BizboxRegistration.Systolic) & "/" & (Me.forBizboxConsultation.BizboxRegistration.Diastolic))
            Me.lblInitialConsultation_PR.Text = (Me.forBizboxConsultation.BizboxRegistration.PulseRate)
            Me.lblInitialConsultation_RR.Text = (Me.forBizboxConsultation.BizboxRegistration.RespiratoryRate)
            Me.lblInitialConsultation_Temperature.Text = (Me.forBizboxConsultation.BizboxRegistration.Temparature)
            Me.lblInitialConsultation_O2.Text = "0.0"
            Me.lblInitialConsultation_ChiefComplaint.Text = Me.forBizboxConsultation.BizboxRegistration.ChiefComplaint.Trim
            Me.tbPatientData.SelectedTab = Me.tpInitConsultation
            Me.pnlNoForConsultation.Hide()
        Else
            Me.pnlNoForConsultation.Show()
        End If
    End Sub

    Private Sub AutoTransferToConsulationClinic()
        Dim controller As New CustomerAssignCounterController
        Dim forTransferPatient As New CustomerAssignCounter With {
            .Counter = Me.autoTransferCounter.Counter,
            .Customer = Me.ServingCustomer.CustomerAssignCounter.Customer,
            .Priority = 0,
            .Notes = Nothing,
            .PaymentMethod = 0,
            .NoteDepartment = Nothing,
            .NoteSection = Nothing
        }
        Dim queueNumber As String = controller.TransferPatient(forTransferPatient)
        If (Not IsNothing(queueNumber) AndAlso (queueNumber.Trim.Length > 0)) Then
            Dim customer As Customer = Me.ServingCustomer.CustomerAssignCounter.Customer
            Dim fullName As String = forTransferPatient.Customer.FullName
            Dim counterName As String = ("PLEASE GO TO " & forTransferPatient.Counter.ServiceDescription).Trim.ToUpper
            Dim notes As String = "PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU".Trim.ToUpper
            Dim ticketNumber As String = queueNumber
            If (IsNothing(customer.CustomerInfo.FirstName) And IsNothing(customer.CustomerInfo.Lastname)) Then
                fullName = "NAME NOT INDICATED"
            ElseIf (Not (customer.CustomerInfo.FirstName.Trim.Length > 0) And Not (customer.CustomerInfo.Lastname.Trim.Length > 0)) Then
                fullName = "NAME NOT INDICATED"
            Else
                fullName = (customer.CustomerInfo.Lastname & ", " & customer.CustomerInfo.FirstName & " " & customer.CustomerInfo.Middlename).Trim.ToUpper
            End If
            Dim frm As New frmNoGenerated(ticketNumber, fullName, counterName, notes, customer.FK_emdPatients)
            frm.ShowDialog()
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

    Private Function SavePatientInitialConsultation_IfExist() As Boolean
        If Not IsNothing(Me.ServingCustomer) Then
            Dim flag As Boolean = False
            If Not IsNothing(Me.forBizboxConsultation) Then
                If (IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter) Or Not (Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter_ID > 0)) Then
                    MessageBox.Show("Unable to save for consultation Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    MessageBox.Show("Please assign an Queuing Physician or Cancel the ongoing consultation", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                If (Not (Me.forBizboxConsultation.OPDConsent1.Trim.Length > 0) Or Not (Me.forBizboxConsultation.OPDConsent2.Trim.Length > 0)) Then
                    MessageBox.Show("Unable to save for consultation Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    MessageBox.Show("Please attach the consent or Cancel the ongoing consultation.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                flag = True
            End If
            If flag Then
                Dim controller As New CustomerConsultationController
                If Not controller.SaveBizboxInitialConsultation(Me.forBizboxConsultation) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function




    Private Function DeletePatientCurrentQueueNumber()
        If Not IsNothing(Me.ServingCustomer) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            If customerAssignCounterController.RemoveCertainPatientCurrentQueuedNumber(Me.ServingCustomer.CustomerAssignCounter.CustomerAssignCounter_ID) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function DeletePatientUncalledQueueNumbers()
        If Not IsNothing(Me.ServingCustomer) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim isHealthcheckView As Boolean = LoggedServer.ServerAssignCounter.Counter.healthcheckView
            Dim isHealthcheckEdit As Boolean = LoggedServer.ServerAssignCounter.Counter.healthcheckAddEdit
            If isHealthcheckView Or isHealthcheckEdit Then 'If HealthCheck (Screening). Patient Current Queue Number is not Deleted
                If customerAssignCounterController.RemoveCertainPatientUnusedQueuedNumber(Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID) Then
                    Return True
                End If
            Else
                If customerAssignCounterController.RemoveCertainPatientUnusedAndCurrentQueuedNumber(Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID, Me.ServingCustomer.CustomerAssignCounter.CustomerAssignCounter_ID) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub CheckConsultationConsentExist()
        If Not IsNothing(tmpConsultationConsent1) And Not IsNothing(tmpConsultationConsent2) Then
            btnAssignPhysician.Show()
            btnInitialConsultation_ViewConsent.Text = "REMOVE CONSENT"
            btnInitialConsultation_ViewConsent.BackColor = Color.Maroon
        Else
            btnAssignPhysician.Hide()
            btnInitialConsultation_ViewConsent.Text = "ATTACH CONSENT"
            btnInitialConsultation_ViewConsent.BackColor = Color.RoyalBlue
        End If
    End Sub

    Private Sub GetServingCustomerPCCInfo()
        If Not IsNothing(Me.ServingCustomer) Then
            Me.AutoRefreshListTimer.Stop()
            Me.ToogleServingInfo(True)
            Me.lblRefNo.Text = Nothing
            Me.bizboxRegistrationList = Nothing
            Me.tmpSelectedBizboxRegistration = Nothing
            Me.forBizboxConsultation = Nothing
            Me.autoTransferCounter = Nothing
            Me.bizboxRequisitions = Nothing
            Me.latestbizboxRequests = Nothing
            Me.diagnosticResultList = Nothing
            Me.selectedBizboxRequisitions = Nothing
            Me.healthcheckHistory = Nothing
            Me.tmpSelectedConsultation = Nothing
            Me.tmpSelectedhealthcheck = Nothing
            Dim vitalGraph As List(Of Bizbox_PatientDailyRegistration) = Nothing
            Dim isConsultationView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.consultationView
            Dim isConsultationAddEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.consultationAddEdit
            Dim isDiagnosticView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.diagnosticView
            Dim isDiagnosticAddEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.diagnosticAddEdit
            Dim isEPrescriptionView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.eprescriptionView
            Dim isHealthcheckView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.healthcheckView
            Dim isHealthcheckEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.healthcheckAddEdit
            Dim canInitialConsultation As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.initialconsultation
            Dim isERTriage As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.erconsultation
            Dim canSyncFromBizbox As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.SyncDetail
            Dim customer As Customer = Me.ServingCustomer.CustomerAssignCounter.Customer
            Dim customerInfo As CustomerInfo = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo
            Dim hasNotes As Boolean = If(Me.ServingCustomer.CustomerAssignCounter.PaymentMethod > 0, True, False)
            Dim paymentDepartent As String = Me.ServingCustomer.CustomerAssignCounter.NoteDepartment
            Dim paymentSection As String = Me.ServingCustomer.CustomerAssignCounter.NoteSection
            Dim paymentMethod As Integer = Me.ServingCustomer.CustomerAssignCounter.PaymentMethod
            Dim notes As String = Me.ServingCustomer.CustomerAssignCounter.Notes
            Dim custName As String = customerInfo.Lastname.ToUpper & ", " & customerInfo.FirstName.ToUpper & " " & customerInfo.Middlename.ToUpper
            Dim custFName As String = customerInfo.FirstName.ToUpper
            Dim custMName As String = customerInfo.Middlename.ToUpper
            Dim custLName As String = customerInfo.Lastname.ToUpper
            Dim custAge As String = "AGE NOT INDICATED"
            Dim custBDay As String = Strings.Format(customerInfo.BirthDate, "MMM dd, yyyy")
            Dim custGender As String = customerInfo.Sex
            Dim custCivilStatus As String = customerInfo.CivilStatus
            Dim custCountry As String
            Dim custNationality As String = customerInfo.Nationality.Split("-")(0).Trim()
            Dim custEmail As String = customerInfo.Email
            Dim custContact As String = customerInfo.PhoneNumber
            Dim custStreet As String = customerInfo.StreetDrive
            Dim custBarangay As String = customerInfo.Barangay
            Dim custCity As String = customerInfo.CityMunicipality
            Dim custPicture As String = ""

            If customerInfo.Nationality.Length = 0 Then
                custCountry = ""
            Else
                If customerInfo.Nationality.Split("-").Length > 1 Then
                    custCountry = customerInfo.Nationality.Split("-")(1).Trim()
                Else
                    custCountry = ""
                End If
            End If
            If IsNothing(customerInfo.FirstName) And IsNothing(customerInfo.Lastname) Then
                custName = "NAME NOT INDICATED"
            ElseIf (Not customerInfo.FirstName.Trim.Length > 0) And (Not customerInfo.Lastname.Trim.Length > 0) Then
                custName = "NAME NOT INDICATED"
            End If
            Dim tmpAge = DateDiff(DateInterval.Year, customerInfo.BirthDate, customer.DateOfVisit).ToString
            custBDay = customerInfo.BirthDate.ToShortDateString.ToString.ToUpper
            If tmpAge > 0 Then
                custAge = tmpAge.ToString
            End If
            If IsNothing(customerInfo.Sex) Then
                custGender = "GENDER NOT INDICATED"
            ElseIf Not customerInfo.Sex.Trim.Length > 0 Then
                custGender = "GENDER NOT INDICATED"
            Else
                custGender = customerInfo.Sex.ToUpper
            End If
            If IsNothing(customerInfo.PhoneNumber) Then
                custContact = "CONTACT NOT INDICATED"
            ElseIf customerInfo.PhoneNumber.Length <= 0 Then
                custContact = "CONTACT NOT INDICATED"
            Else
                custContact = customerInfo.PhoneNumber.ToString
            End If
            custStreet = customerInfo.StreetDrive
            custBarangay = customerInfo.Barangay
            custCity = customerInfo.CityMunicipality
            custPicture = If(Not IsNothing(customerInfo.PatientPicture), customerInfo.PatientPicture.Trim, "")
            Dim apiControler As New APIController
            Dim diagnosticController As New DiagnosticsController
            If IsNothing(customerInfo.CivilStatus) Then
                custCivilStatus = "NOT INDICATED"
            ElseIf customerInfo.CivilStatus.Length <= 0 Then
                custCivilStatus = "NOT INDICATED"
            Else
                custCivilStatus = customerInfo.CivilStatus
            End If
            If IsNothing(customerInfo.Nationality) Then
                custNationality = "NOT INDICATED"
            ElseIf customerInfo.Nationality.Length <= 0 Then
                custNationality = "NOT INDICATED"
            Else
                custNationality = customerInfo.Nationality.Split("-")(0).Trim
            End If
            If IsNothing(customerInfo.Email) Then
                custEmail = "NOT INDICATED"
            ElseIf customerInfo.Email.Length <= 0 Then
                custEmail = "NOT INDICATED"
            Else
                custEmail = customerInfo.Email
            End If
            If isConsultationView Then
                If Not Me.tbPatientData.TabPages.Contains(Me.tpConsultationHistory) Then
                    Me.tbPatientData.TabPages.Add(Me.tpConsultationHistory)
                End If
                vitalGraph = Me.GetBizboxPatientVitalSummary(customerInfo)
                Me.bizboxRegistrationList = Me.GetBizboxPatientRegistrations(customerInfo)
            ElseIf Me.tbPatientData.TabPages.Contains(Me.tpConsultationHistory) Then
                Me.tbPatientData.TabPages.Remove(Me.tpConsultationHistory)
            End If
            If isConsultationAddEdit Then
                Me.btnGenerateMedicalCertificate.Show()
                Me.btnPreviewConsultationHistory.Show()
            Else
                Me.btnGenerateMedicalCertificate.Hide()
                Me.btnPreviewConsultationHistory.Hide()
            End If
            If isDiagnosticView Then
                If Not Me.tbPatientData.TabPages.Contains(Me.tpDiagnostics) Then
                    Me.tbPatientData.TabPages.Add(Me.tpDiagnostics)
                End If
                If Not Information.IsNothing(customerInfo.FK_emdPatients) Then
                    Me.bizboxRequisitions = apiControler.GetCertainPatientBizboxTrasactionHistory(customerInfo.FK_emdPatients)
                    Me.diagnosticResultList = apiControler.GetCertainPatientDiagnosticResults(customerInfo.FK_emdPatients)
                End If
            ElseIf Me.tbPatientData.TabPages.Contains(Me.tpDiagnostics) Then
                Me.tbPatientData.TabPages.Remove(Me.tpDiagnostics)
            End If
            If isDiagnosticAddEdit Then
                btnViewDiagnosticConsent.Show()
                btnMakeDeleteDiagnosticConsent.Show()
            Else
                btnViewDiagnosticConsent.Hide()
                btnMakeDeleteDiagnosticConsent.Hide()
            End If
            If isHealthcheckView Then
                If Not Me.tbPatientData.TabPages.Contains(Me.tbHealthCheck) Then
                    Me.tbPatientData.TabPages.Add(Me.tbHealthCheck)
                End If
                Me.healthcheckHistory = Me.GetPatientHealthChecks(customerInfo)
            ElseIf Me.tbPatientData.TabPages.Contains(Me.tbHealthCheck) Then
                Me.tbPatientData.TabPages.Remove(Me.tbHealthCheck)
            End If
            If isHealthcheckEdit Then
                Me.healthcheckHistory = Me.GetPatientHealthChecks(customerInfo)
            End If
            Me.forBizboxConsultation = Nothing
            If canInitialConsultation Then
                If Not Me.tbPatientData.TabPages.Contains(Me.tpInitConsultation) Then
                    Me.tbPatientData.TabPages.Add(Me.tpInitConsultation)
                End If
                Me.btnProccedForConsultation.Show()
                'Me.forBizboxConsultation = Me.GetBizboxPatientLatestConsultation(customerInfo)
            Else
                'Me.forBizboxConsultation = Nothing
                Me.btnProccedForConsultation.Hide()
                If Me.tbPatientData.TabPages.Contains(Me.tpInitConsultation) Then
                    Me.tbPatientData.TabPages.Remove(Me.tpInitConsultation)
                End If
            End If
            If canSyncFromBizbox Then
                Me.btnSync.Show()
                Me.btnEditProfile.Show()
            Else
                Me.btnSync.Hide()
                Me.btnEditProfile.Hide()
            End If
            If hasNotes Then
                If Not Me.tbPatientData.TabPages.Contains(Me.tbNotes) Then
                    Me.tbPatientData.TabPages.Add(Me.tbNotes)
                End If
                If Not Me.tbPatientData.TabPages.Contains(Me.tbNotes) Then
                    Me.tbPatientData.TabPages.Add(Me.tbNotes)
                End If
                Me.txtNotesRmarks.Text = notes
                If (paymentMethod = 1) Then
                    Me.lblNotesPayMethod.Text = "CASH OR PAYMAYA"
                ElseIf (paymentMethod = 2) Then
                    Me.lblNotesPayMethod.Text = "DEBIT OR CREDIT CARD"
                ElseIf (paymentMethod = 3) Then
                    Me.lblNotesPayMethod.Text = "HMO"
                ElseIf (paymentMethod = 4) Then
                    Me.lblNotesPayMethod.Text = "PHILHEALTH"
                Else
                    Me.lblNotesPayMethod.Text = "NONE"
                End If
                If Not Information.IsNothing(customerInfo.FK_emdPatients) Then
                    Me.latestbizboxRequests = apiControler.GetCertainPatientBizboxLatestTrasaction(customerInfo.FK_emdPatients)
                End If
                Me.dgvNotes_LatestTransactionItems.Rows.Clear()
                If Not IsNothing(Me.latestbizboxRequests) Then
                    Dim grandTotal As Double = 0.0
                    Dim totalQty As Integer = 0
                    If Not IsNothing(latestbizboxRequests.PatItems_Rendered) Then
                        For Each items As PatientBizbox_PatItems In latestbizboxRequests.PatItems_Rendered
                            If Not items.isRequestCancelled Then
                                Dim totalSubAmount As Double = (items.RequestPrice * items.RequestQTY)
                                grandTotal = grandTotal + totalSubAmount
                                totalQty = totalQty + items.RequestQTY
                                dgvNotes_LatestTransactionItems.Rows.Add(items.PK_psPatItems, items.ItemDescription, items.DepartmentOfService, items.RequestPrice.ToString("N"), items.RequestQTY, totalSubAmount.ToString("N"))
                                dgvNotes_LatestTransactionItems.Rows(dgvNotes_LatestTransactionItems.Rows.Count - 1).Height = 30
                            End If
                        Next
                        lblLatestTransactionSummary.Text = "DATE CREATED: " & latestbizboxRequests.RegistryDate.ToShortDateString & " " & latestbizboxRequests.RegistryDate.ToShortTimeString & vbCrLf & "TOTAL QTY: " & totalQty & vbCrLf & "GRAND TOTAL: " & grandTotal.ToString("N")
                    End If
                End If
                Dim showAutoTransfer As Boolean = False
                Dim bizboxPatientLatestConsultation As Bizbox_Consultation = Me.GetBizboxPatientLatestConsultation(customerInfo)
                If (Not Information.IsNothing(bizboxPatientLatestConsultation) AndAlso Not Information.IsNothing(bizboxPatientLatestConsultation.ForInitialConsultation_ServerAssignCounter)) Then
                    Me.autoTransferCounter = bizboxPatientLatestConsultation.ForInitialConsultation_ServerAssignCounter
                    Dim counter As Counter = bizboxPatientLatestConsultation.ForInitialConsultation_ServerAssignCounter.Counter
                    Dim server As Server = bizboxPatientLatestConsultation.ForInitialConsultation_ServerAssignCounter.Server
                    Me.lblAssignConsultant.Text = ("Consultant: " & server.FullName.ToUpper.Trim & ChrW(13) & ChrW(10) & "Clinic: " & counter.Department.ToUpper.Trim)
                    showAutoTransfer = True
                End If
                Me.pnlCashierAutoTransferBlocker.Visible = Not showAutoTransfer
            Else
                If Me.tbPatientData.TabPages.Contains(Me.tbNotes) Then
                    Me.tbPatientData.TabPages.Remove(Me.tbNotes)
                End If
                If Me.tbPatientData.TabPages.Contains(Me.tbNotes) Then
                    Me.tbPatientData.TabPages.Remove(Me.tbNotes)
                End If
            End If
            If (customerInfo.FK_emdPatients > 0) Then
                Me.lblRefNo.Text = (customerInfo.FK_emdPatients)
                Me.lblRefNo.BackColor = Color.SeaGreen
                Me.lblRefNo.ForeColor = Color.White
            Else
                Me.lblRefNo.Text = "PROFILE NOT SYNC YET"
                Me.lblRefNo.BackColor = Color.Gray
                Me.lblRefNo.ForeColor = Color.White
            End If
            profile_info1.Text = custLName & Environment.NewLine & custFName & Environment.NewLine & custMName & Environment.NewLine & custAge & Environment.NewLine & custBDay & Environment.NewLine & custContact
            profile_info2.Text = custGender & Environment.NewLine & custCivilStatus & Environment.NewLine & custCountry & Environment.NewLine & custNationality & Environment.NewLine & custEmail & Environment.NewLine & custStreet + " " + custBarangay + " " + custCity
            IDInfo_Label.Text = customerInfo.IdentificationInfo.ID_Type & Environment.NewLine & customerInfo.IdentificationInfo.ID_Number & Environment.NewLine & customerInfo.IdentificationInfo.ValidUntil
            If custPicture.Length > 0 Then
                Try
                    pbProfilePicture.Image = Image.FromFile(custPicture)
                Catch ex As Exception
                    pbProfilePicture.Image = Nothing
                End Try
            Else
                pbProfilePicture.Image = Nothing
            End If
            Me.chartbp.Series("Systolic").Points.Clear()
            Me.chartbp.Series("Diastolic").Points.Clear()
            Me.chartRates.Series("pr").Points.Clear()
            Me.chartRates.Series("rr").Points.Clear()
            Me.chartRates.Series("o2").Points.Clear()
            Me.chartTemp.Series("temp").Points.Clear()
            Me.dgvVitalSummary.Rows.Clear()
            If Not IsNothing(vitalGraph) Then
                Me.btnSummaryModes.Enabled = False
                Me.pnlCharMode.Hide()
                Me.pnlTableMode.Hide()
                Me.pnlNoVitals.Show()
                If vitalGraph.Count > 0 Then
                    Me.ToogleChartMode(Me.chartMode)
                    Me.btnSummaryModes.Enabled = True
                    For i As Integer = vitalGraph.Count - 1 To 0 Step -1
                        Dim vitalItem As Bizbox_PatientDailyRegistration = vitalGraph(i)
                        Dim dt As String = Format(vitalItem.RegistrationDate, "MMM dd")
                        chartbp.Series("Systolic").Points.AddXY(dt, vitalItem.Systolic)
                        chartbp.Series("Diastolic").Points.AddXY(dt, vitalItem.Diastolic)
                        chartRates.Series("pr").Points.AddXY(dt, vitalItem.PulseRate)
                        chartRates.Series("rr").Points.AddXY(dt, vitalItem.RespiratoryRate)
                        chartRates.Series("o2").Points.AddXY(dt, vitalItem.Oxygen)
                        chartTemp.Series("temp").Points.AddXY(dt, vitalItem.Temparature)
                    Next
                    For Each vitalItem As Bizbox_PatientDailyRegistration In vitalGraph
                        dgvVitalSummary.Rows.Add(Format(vitalItem.RegistrationDate, "MMM dd, yyyy @ h:mm tt"), vitalItem.Systolic & "/" & vitalItem.Diastolic, vitalItem.PulseRate, vitalItem.RespiratoryRate, vitalItem.Oxygen, vitalItem.Temparature)
                        dgvVitalSummary.Rows(dgvVitalSummary.Rows.Count - 1).Height = 30
                    Next
                End If
            End If
            Me.lblPhysicianNursingAttendantConsultDate.Text = ""
            Me.lblConsultationType.Text = ""
            Me.lbHeight.Text = ""
            Me.lbWeight.Text = ""
            Me.lblAllergies.Text = ""
            Me.lblSymptoms.Text = ""
            Me.lbBP.Text = ""
            Me.lbPR.Text = ""
            Me.lbO2.Text = ""
            Me.lbRR.Text = ""
            Me.lbTemp.Text = ""
            Me.lbO2.Text = ""
            Me.lblChiefComplaint.Text = ""
            Me.lblHistoryOfPresentIllness.Text = ""
            Me.lblPertinentPhysicalExam.Text = ""
            Me.lblWorkingDiagnosis.Text = ""
            Me.lbFinalDiagnosis.Text = ""
            Me.lbTreatment.Text = ""
            Me.txtImpression.Text = ""
            Me.dgvConsulationList.Rows.Clear()
            If Not IsNothing(Me.bizboxRegistrationList) Then
                For Each registry In Me.bizboxRegistrationList
                    Me.dgvConsulationList.Rows.Add(registry.ID, registry.DoctorData.ID, Format(registry.RegistrationDate, "MMM dd, yyyy @ h:mm tt"), ("DR. " & registry.DoctorData.Lastname & ", " & registry.DoctorData.Firstname & " " & registry.DoctorData.SuffixName))
                    Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).Height = 30
                    If Not IsNothing(registry.BizboxConsultation) Then
                        Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).DefaultCellStyle.BackColor = Color.ForestGreen
                        Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).DefaultCellStyle.ForeColor = Color.White
                    End If
                Next
                dgvConsulationList.ClearSelection()
            End If
            dgvDiagnosticRequestList.Rows.Clear()
            dgvDiagnosticRequestItems.Rows.Clear()
            If Not IsNothing(Me.bizboxRequisitions) Then
                Dim registers As PatientBixbox_PatRegisters
                For Each registers In Me.bizboxRequisitions
                    Dim consentStat As String = "N/A"
                    Dim dgvColor As Color = Color.Maroon
                    If ((Not IsNothing(registers.Diagnostics) AndAlso (Not IsNothing(registers.Diagnostics.OPDConsent1) And Not IsNothing(registers.Diagnostics.OPDConsent2))) AndAlso ((registers.Diagnostics.OPDConsent1.Trim.Length > 0) And (registers.Diagnostics.OPDConsent2.Trim.Length > 0))) Then
                        consentStat = "YES"
                        dgvColor = Color.Green
                    End If
                    dgvDiagnosticRequestList.Rows.Add(registers.PK_psPatRegisters, consentStat, Format(registers.RegistryDate, "MMM dd, yyyy @ h:mm tt"))
                    dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Height = 30
                    dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Cells("dgvDiagnosticRequestList_Consent").Style.ForeColor = Color.White
                    dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Cells("dgvDiagnosticRequestList_Consent").Style.BackColor = dgvColor
                Next
            End If
            Me.dgvDiagnosticResults.Rows.Clear()
            If Not IsNothing(Me.diagnosticResultList) Then
                Dim diagnostics As Diagnostics
                For Each diagnostics In Me.diagnosticResultList
                    Me.dgvDiagnosticResults.Rows.Add(diagnostics.PK_psExamResultMstr, diagnostics.Diagnostics, diagnostics.ItemDescription, If(Not Information.IsNothing(diagnostics.ResultReportLink), "AVAILABLE", "None"), diagnostics.ResultReportLink, Format(diagnostics.DiagnosticDate, "MMM dd, yyyy @ h:mm tt"), Format(diagnostics.ResultDate, "MMM dd, yyyy @ h:mm tt"))
                    Me.dgvDiagnosticResults.Rows((Me.dgvDiagnosticResults.Rows.Count - 1)).Height = 30
                Next
            End If
            Me.dgvHealthCheck_History.Rows.Clear()
            Me.cbHealthcheck_Fever.Checked = False
            Me.cbHealthcheck_Cough.Checked = False
            Me.cbHealthcheck_Sorethroat.Checked = False
            Me.cbHealthcheck_Diarrhea.Checked = False
            Me.cbHealthcheck_ShortnessOfBreathing.Checked = False
            Me.cbHealthcheck_Ageusia.Checked = False
            Me.cbHealthcheck_Anosmia.Checked = False
            Me.cbHealthcheck_Colds.Checked = False
            Me.cbHealthcheck_CloseContactConfirmed.Checked = False
            Me.cbHealthcheck_CloseContactExhibiting.Checked = False
            Me.lblHealthcheck_Case.Text = ""
            Me.lblHealthcheck_Date.Text = ""
            If Not IsNothing(healthcheckHistory) Then
                For Each healthcheckItem As HealthCheck In healthcheckHistory
                    Dim healthCase As String = "SAFE"
                    If healthcheckItem.Fever Or healthcheckItem.Cough Or healthcheckItem.Sorethroat Or healthcheckItem.Diarrhea Or healthcheckItem.Diarrhea Or healthcheckItem.ShortnessOfBreathing Or healthcheckItem.Ageusia Or healthcheckItem.Anosmia Or healthcheckItem.Colds Then
                        healthCase = "With Symptoms"
                    End If
                    dgvHealthCheck_History.Rows.Add(healthcheckItem.HealthCheck_ID, healthcheckItem.DateOfAssesment.ToLongDateString & " " & healthcheckItem.DateOfAssesment.ToShortTimeString, healthCase)
                    dgvHealthCheck_History.Rows(dgvHealthCheck_History.Rows.Count - 1).Height = 30
                Next
            End If
            Me.lblInitialConsultation_AssignPhysician.Text = ""
            Me.lblInitialConsultation_ConsultationType.Text = ""
            Me.lblInitialConsultation_Height.Text = ""
            Me.lblInitialConsultation_Weight.Text = ""
            Me.lblInitialConsultation_Allergies.Text = ""
            Me.lblInitialConsultation_SignSymptoms.Text = ""
            Me.lblInitialConsultation_BP.Text = ""
            Me.lblInitialConsultation_PR.Text = ""
            Me.lblInitialConsultation_RR.Text = ""
            Me.lblInitialConsultation_Temperature.Text = ""
            Me.lblInitialConsultation_O2.Text = ""
            Me.lblInitialConsultation_ChiefComplaint.Text = ""
            Me.pnlNoForConsultation.Show()
            If Not IsNothing(Me.forBizboxConsultation) Then
                Dim str22 As String = ""
                If Not IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter) Then
                    Dim textArray5 As String() = New String() {"DR. ", Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter.Server.FullName, " (", Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter.Server.PRC, ")"}
                    str22 = String.Concat(textArray5).Trim.ToUpper
                End If
                Dim textArray6 As String() = New String(5 - 1) {}
                Dim textArray7 As String() = New String() {"DR. ", Me.forBizboxConsultation.BizboxRegistration.DoctorData.Lastname, ", ", Me.forBizboxConsultation.BizboxRegistration.DoctorData.Firstname, " ", Me.forBizboxConsultation.BizboxRegistration.DoctorData.MiddleName, " ", Me.forBizboxConsultation.BizboxRegistration.DoctorData.SuffixName, " (", Me.forBizboxConsultation.BizboxRegistration.DoctorData.PRC, ")"}
                textArray6(0) = String.Concat(textArray7).Trim.ToUpper
                textArray6(1) = ChrW(13) & ChrW(10)
                textArray6(2) = Format(Me.forBizboxConsultation.BizboxRegistration.RegistrationDate, "MMM dd, yyyy @ h:mm tt")
                textArray6(3) = ChrW(13) & ChrW(10)
                textArray6(4) = str22
                Me.lblInitialConsultation_AssignPhysician.Text = String.Concat(textArray6)
                Dim costype As String() = New String() {If(Not Information.IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleEmpNo), Me.forBizboxConsultation.BizboxRegistration.DoleEmpNo, "N/A"), ChrW(13) & ChrW(10), If(Not Information.IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleRefNO), Me.forBizboxConsultation.BizboxRegistration.DoleRefNO.Trim.ToUpper, "N/A"), ChrW(13) & ChrW(10), If(Not Information.IsNothing(Me.forBizboxConsultation.BizboxRegistration.DoleAppStat), Me.forBizboxConsultation.BizboxRegistration.DoleAppStat.Trim.ToUpper, "N/A")}
                Me.lblInitialConsultation_ConsultationType.Text = String.Concat(costype)
                Me.lblInitialConsultation_Height.Text = ((Me.forBizboxConsultation.BizboxRegistration.Height1) & " " & Me.forBizboxConsultation.BizboxRegistration.HeightUnit)
                Me.lblInitialConsultation_Weight.Text = ((Me.forBizboxConsultation.BizboxRegistration.Weight) & " " & Me.forBizboxConsultation.BizboxRegistration.WeightUnit)
                Me.lblInitialConsultation_Allergies.Text = ""
                Me.lblInitialConsultation_SignSymptoms.Text = ""
                Me.lblInitialConsultation_BP.Text = ((Me.forBizboxConsultation.BizboxRegistration.Systolic) & "/" & (Me.forBizboxConsultation.BizboxRegistration.Diastolic))
                Me.lblInitialConsultation_PR.Text = (Me.forBizboxConsultation.BizboxRegistration.PulseRate)
                Me.lblInitialConsultation_RR.Text = (Me.forBizboxConsultation.BizboxRegistration.RespiratoryRate)
                Me.lblInitialConsultation_Temperature.Text = (Me.forBizboxConsultation.BizboxRegistration.Temparature)
                Me.lblInitialConsultation_O2.Text = "0.0"
                Me.lblInitialConsultation_ChiefComplaint.Text = Me.forBizboxConsultation.BizboxRegistration.ChiefComplaint.Trim
                Me.pnlNoForConsultation.Hide()
            Else
                Me.pnlNoForConsultation.Show()
            End If
        Else
            AutoRefreshListTimer.Start()
            ToogleServingInfo(False)
        End If
    End Sub

    Private Function CustomerLookup() As CustomerInfo
        Dim frmCustomerLookup As New frmFindPatient(False)
        frmCustomerLookup.ShowDialog(Me)
        If frmCustomerLookup.DialogResult = DialogResult.Yes Then
            Dim customerInfo As CustomerInfo = Nothing
            Dim frmProfiling As frmPatientProfiling = If(Not IsNothing(frmCustomerLookup.SelectedCustomer), New frmPatientProfiling(frmCustomerLookup.SelectedCustomer, True, False, False), New frmPatientProfiling(True, False))
            frmProfiling.ShowDialog(Me)
            If frmProfiling.DialogResult = DialogResult.Yes Then
                If Not IsNothing(frmProfiling.CustomerProfile) Then
                    customerInfo = frmProfiling.CustomerProfile
                End If
            End If
            Return customerInfo
        End If
        Return Nothing
    End Function

    Private Function SyncCustomerLookup() As CustomerInfo
        Dim frmCustomerLookup As New frmFindPatient(True)
        frmCustomerLookup.ShowDialog(Me)
        If frmCustomerLookup.DialogResult = DialogResult.Yes And Not IsNothing(frmCustomerLookup.SelectedCustomer) Then
            Dim customerInfo As CustomerInfo = Nothing
            Dim frmProfiling As frmPatientProfiling = If(Not IsNothing(frmCustomerLookup.SelectedCustomer), New frmPatientProfiling(frmCustomerLookup.SelectedCustomer, True, False, False), New frmPatientProfiling(True, False))
            frmProfiling.ShowDialog(Me)
            If frmProfiling.DialogResult = DialogResult.Yes Then
                If Not IsNothing(frmProfiling.CustomerProfile) Then
                    customerInfo = frmProfiling.CustomerProfile
                End If
            End If
            Return customerInfo
        End If
        Return Nothing
    End Function

    Private Sub GeneratePriorityNumber()
        If MessageBox.Show("Generate a PRIOTY NUMBER Now? [YES: Generate Priority Number] [NO: Do Nothing]", "Priority Queuing Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim customerInfo As CustomerInfo = CustomerLookup()
            If Not IsNothing(customerInfo) Then
                Dim customerAssignCounterController As New CustomerAssignCounterController
                Dim customerAssignCounter As New CustomerAssignCounter
                customerAssignCounter.Priority = 1
                customerAssignCounter.Counter = LoggedServer.ServerAssignCounter.Counter
                customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
                customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
                customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
                customerAssignCounter.Customer.CustomerInfo = customerInfo
                Dim generatedNumber As String = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
                If Not IsNothing(generatedNumber) Then
                    GetQueueList()
                    Dim frm As New frmNoGenerated(generatedNumber, "", "", "", customerAssignCounter.Customer.FK_emdPatients)
                    frm.ShowDialog(Me)
                Else
                    MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub renameCounter(toRaname As Boolean)
        Dim ctrName As String = ""
        If toRaname Then
            Dim frm As New frmManageCounterName(LoggedServer.ServerAssignCounter.Counter.ServiceDescription)
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.Yes And Not IsNothing(frm.CounterName) Then
                ctrName = frm.CounterName.ToUpper.Trim
            Else
                ctrName = LoggedServer.ServerAssignCounter.Counter.ServiceDescription.ToUpper.Trim
            End If
        Else
            If SavedCounterName.Trim.Length > 0 Then
                ctrName = SavedCounterName.ToUpper.Trim
            Else
                Dim frm As New frmManageCounterName(LoggedServer.ServerAssignCounter.Counter.ServiceDescription)
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.Yes And Not IsNothing(frm.CounterName) Then
                    ctrName = frm.CounterName.ToUpper.Trim
                Else
                    ctrName = LoggedServer.ServerAssignCounter.Counter.ServiceDescription.ToUpper.Trim
                End If
            End If
        End If
        Dim serverTransactionController As New ServerTransactionController
        Dim serverTransaction As New ServerTransaction
        serverTransaction = LoggedServer
        serverTransaction.CounterName = ctrName
        serverTransaction.DateTimeLogout = Nothing
        If (serverTransactionController.UpdateCertainServerTransactionC(serverTransaction)) Then
            tmpCounterName = ctrName
            lbcountername.Text = tmpCounterName
            LoggedServer.CounterName = ctrName
            SavedCounterName = ctrName.ToUpper.Trim
        Else
            MessageBox.Show("There was an error during the process. Please try again", "Rename Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub resetQueueTimer()
        servingTime = 0
        servingTimer.Stop()
        lblServingTimer.Text = "00:00:00"
        servingTimer.Start()
    End Sub

    Private Sub stopQueueTimer()
        servingTime = 0
        servingTimer.Stop()
        lblServingTimer.Text = "00:00:00"
    End Sub

    Private Sub startQueueTimer()
        lblServingTimer.Text = "00:00:00"
        servingTimer.Start()
    End Sub

    Private Sub ServeCertainNumber()
        If Not IsNothing(tmpSelectedCustomer) Then
            If Not IsNothing(Me.ServingCustomer) Then
                MessageBox.Show("You cannot serve another patient since you are still serving a patient", "Recall Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If MessageBox.Show("Do you want to serve " + tmpSelectedCustomer.QueuedPatient.ProcessedQueueNumber, "Serve Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim servedCustomer As New ServedCustomer
                    Dim customerAssignCounterController As New CustomerAssignCounterController
                    servedCustomer.ServerTransaction = LoggedServer
                    servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = tmpSelectedCustomer.QueuedPatient.CustomerAssignCounter_ID
                    servedCustomer.CustomerAssignCounter.Counter = tmpSelectedCustomer.QueuedPatient.Counter
                    servedCustomer = customerAssignCounterController.GetNextNumber(servedCustomer)
                    If Not IsNothing(servedCustomer) Then
                        If servedCustomer.ServedCustomer_ID > 0 Then
                            Me.ServingCustomer = servedCustomer
                            tmpSelectedCustomer = Nothing
                            btnTransafer.Visible = True
                            btnReissueQueueNumber.Visible = True
                            btnCancelQueueNumber.Visible = True
                            btnSkipServingPatient.Visible = True
                            btnPatientHistory.Visible = False
                            btnStartCompleteServing.Text = "COMPLETE TRANSACTION"
                            btnStartCompleteServing.BackColor = Color.Green
                            Dim otherStatus As String = ""
                            If servedCustomer.CustomerAssignCounter.ForHelee Then
                                otherStatus = " (MWELL CONSULTATION)"
                            End If
                            lbcountername.Text = tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber & otherStatus
                            CallNumber(servedCustomer.CustomerAssignCounter)
                            tbPatientData.SelectedTab = tpProfile
                            GetServingCustomerPCCInfo()
                            resetQueueTimer()
                        Else
                            MessageBox.Show("Patient not found on the queue. Please serve different patient.", "No Customer Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        GetQueueList()
                    Else
                        Me.ServingCustomer = Nothing
                        MessageBox.Show("There's an error occured during the process. Please try again", "Error Queuing Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            MessageBox.Show("Please select a patient to serve", "No Selected Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ServeNextPriorityNumber()
        Dim servedCustomer As New ServedCustomer
        Dim customerAssignCounterController As New CustomerAssignCounterController
        servedCustomer.ServerTransaction = LoggedServer
        servedCustomer.CustomerAssignCounter.Counter_ID = LoggedServer.ServerAssignCounter.Counter.Counter_ID
        servedCustomer.CustomerAssignCounter.Counter = LoggedServer.ServerAssignCounter.Counter
        servedCustomer.CustomerAssignCounter.Priority = 1
        servedCustomer = customerAssignCounterController.GetNextNumber(servedCustomer)
        If Not IsNothing(servedCustomer) Then
            If servedCustomer.ServedCustomer_ID > 0 Then
                Me.ServingCustomer = servedCustomer
                Dim otherStatus As String = ""
                If servedCustomer.CustomerAssignCounter.ForHelee Then
                    otherStatus = " (MWELL CONSULTATION)"
                End If
                lbcountername.Text = tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber & otherStatus
                CallNumber(servedCustomer.CustomerAssignCounter)
                resetQueueTimer()
            Else
                Me.ServingCustomer = Nothing
                lbcountername.Text = tmpCounterName
                btnTransafer.Enabled = False
                btnSkipServingPatient.Enabled = False
                stopQueueTimer()
                MessageBox.Show("No priority customer in queue for this counter", "Empty Queue", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Me.ServingCustomer = Nothing
            MessageBox.Show("There's an error occured during the process. Please try again", "Error Queuing Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CallNumber(generatedNumber As CustomerAssignCounter)
        Try
            If Not Mute Then
                If Not IsNothing(generatedNumber) Then
                    If isVoice Then
                        queuingSpeaker.SpeakAsyncCancelAll()
                        My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
                        If generatedNumber.Priority > 0 Then
                            queuingSpeaker.SpeakAsync(LoggedServer.ServerAssignCounter.Counter.ServiceDescription + " is now serving, priority number, " + generatedNumber.ProcessedQueueNumber + ", Please proceed to " + tmpCounterName + ".")
                        Else
                            queuingSpeaker.SpeakAsync(LoggedServer.ServerAssignCounter.Counter.ServiceDescription + " is now serving, number, " + generatedNumber.ProcessedQueueNumber + ", Please proceed to " + tmpCounterName + ".")
                        End If
                    Else
                        My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetPagingConfig()
        Dim voiceModel As VoiceModel = VoiceSetting
        If voiceModel.VoiceGenderMale Then
            queuingSpeaker.SelectVoiceByHints(VoiceGender.Male)
        Else
            queuingSpeaker.SelectVoiceByHints(VoiceGender.Female)
        End If
        Mute = voiceModel.Mute
        MuteToolStripMenuItem.Checked = voiceModel.Mute
        queuingSpeaker.Volume = If(voiceModel.VoiceVolume > 100 Or voiceModel.VoiceVolume < 0, 50, voiceModel.VoiceVolume)
        queuingSpeaker.Rate = voiceModel.VoiceSpeed
        SetPagingOption(BeepVoice)
    End Sub

    Private Sub SetPagingOption(flag As Boolean)
        BeepVoice = flag
        isVoice = BeepVoice
        BeepOnlyToolStripMenuItem.Checked = Not flag
    End Sub

    Private Sub ToogleServingInfo(flag As Boolean)
        If flag Then
            pnlNoInfo.Hide()
            gbServingDetail.Show()
        Else
            gbServingDetail.Hide()
            pnlNoInfo.Show()
        End If
    End Sub

    Private Sub AutoRefreshTimer_Tick(sender As Object, e As EventArgs)
        If AutoRefereshQueueList Then
            GetQueueList()
        End If
    End Sub

    Private Sub frmServiceCounter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNothing(AutoRefreshListTimer) Then
            AutoRefreshListTimer = New Timer()
            AutoRefreshListTimer.Interval = 15000
            AddHandler AutoRefreshListTimer.Tick, AddressOf AutoRefreshTimer_Tick
            AutoRefreshListTimer.Start()
        Else
            RemoveHandler AutoRefreshListTimer.Tick, AddressOf AutoRefreshTimer_Tick
            AutoRefreshListTimer = Nothing
            AutoRefreshListTimer = New Timer()
            AutoRefreshListTimer.Interval = 15000
            AddHandler AutoRefreshListTimer.Tick, AddressOf AutoRefreshTimer_Tick
            AutoRefreshListTimer.Start()
        End If
        renameCounter(False)
        SetPagingConfig()
        ToogleServingInfo(False)
        AutoRefershQueueListToolStripMenuItem.Checked = Me.AutoRefereshQueueList
        GetQueueList()
        tmpCounterName = LoggedServer.CounterName
        lbcountername.Text = tmpCounterName
        lblLoggedUserName.Text = LoggedServer.ServerAssignCounter.Server.FullName
        Dim counterController As New CounterController
        If LoggedServer.ServerAssignCounter.Counter.erconsultation Then
            transferCounter_gcber = CounterController.GetGCBERAutoTransfer()
            transferCounter_respier = CounterController.GetRespiERAutoTransfer()
        End If
        transferCounter_payment_cash = CounterController.GetPaymentAutoTransfer_Cash()
        transferCounter_payment_card = CounterController.GetPaymentAutoTransfer_Card()
        transferCounter_payment_hmo = CounterController.GetPaymentAutoTransfer_HMO()
        transferCounter_payment_philhealth = CounterController.GetPaymentAutoTransfer_PHIC()
    End Sub

    Private Sub frmServiceCounter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogoutUser()
        queuingSpeaker.SpeakAsyncCancelAll()
        frmX.Dispose()
        frmY.Dispose()
        frmZ.Dispose()
        AutoRefreshListTimer.Stop()
    End Sub

    Private Sub ChangeCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeCounterToolStripMenuItem.Click
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("You're still serving a customer", "Serving Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim result As DialogResult = MessageBox.Show("Mark the customer as serve before changing counter?", "Mark and Change Counter", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                    Dim serverController As New ServerController
                    Server = serverController.GetCertainServer(LoggedServer.ServerAssignCounter.Server.Server_ID)
                    Me.DialogResult = DialogResult.Retry
                Else
                    MessageBox.Show("Failed to mark the customer as served. Please try again", "Mark as Served", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf result = DialogResult.No Then
                Dim serverController As New ServerController
                Server = serverController.GetCertainServer(LoggedServer.ServerAssignCounter.Server.Server_ID)
                Me.DialogResult = DialogResult.Retry
            End If
        Else
            If MessageBox.Show("Are you sure to change the current counter you're logging in?", "Change Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim serverController As New ServerController
                Server = serverController.GetCertainServer(LoggedServer.ServerAssignCounter.Server.Server_ID)
                Me.DialogResult = DialogResult.Retry
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("You're still serving a customer", "Serving Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim result As DialogResult = MessageBox.Show("Mark the customer as serve before you logout?", "Mark and Change Counter", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                    Me.DialogResult = DialogResult.Abort
                Else
                    MessageBox.Show("Failed to mark the customer as served. Please try again", "Mark as Served", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf result = DialogResult.No Then
                Me.DialogResult = DialogResult.Abort
            End If
        Else
            If MessageBox.Show("Are you sure to close this program?", "Close Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Abort
            End If
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("You're still serving a customer", "Serving Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim result As DialogResult = MessageBox.Show("Mark the customer as serve before you logout?", "Mark and Change Counter", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                    Me.Close()
                Else
                    MessageBox.Show("Failed to mark the customer as served. Please try again", "Mark as Served", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf result = DialogResult.No Then
                Me.Close()
            End If
        Else
            If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub servingTimer_Tick(sender As Object, e As EventArgs) Handles servingTimer.Tick
        servingTime += 1
        Dim spanTM As New TimeSpan(TimeSpan.TicksPerSecond * servingTime)
        Dim TimeStr As String = spanTM.Hours.ToString("00") & ":" & spanTM.Minutes.ToString("00") & ":" & spanTM.Seconds.ToString("00")
        lblServingTimer.Text = TimeStr
    End Sub

    Private Sub btnTransafer_Click(sender As Object, e As EventArgs) Handles btnTransafer.Click
        If Not IsNothing(Me.ServingCustomer) Then
            If Not IsNothing(Me.ServingCustomer.CustomerAssignCounter.CustomerAssignCounter_ID) Then
                If SavePatientInitialConsultation_IfExist() Then
                    Dim frm As New frmTransferNo(Me.ServingCustomer.CustomerAssignCounter, 0)
                    frm.ShowDialog(Me)
                    If frm.DialogResult = DialogResult.Yes Then
                        Dim servedCustomerController As New ServedCustomerController
                        If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                            Me.ServingCustomer = Nothing
                            tmpSelectedCustomer = Nothing
                            btnTransafer.Visible = False
                            btnReissueQueueNumber.Visible = False
                            btnCancelQueueNumber.Visible = False
                            btnSkipServingPatient.Visible = False
                            btnPatientHistory.Visible = True
                            btnStartCompleteServing.Text = "SERVE PATIENT"
                            btnStartCompleteServing.BackColor = Color.LimeGreen
                            lbcountername.Text = tmpCounterName
                            GetServingCustomerPCCInfo()
                            stopQueueTimer()
                            GetQueueList()
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("There's no customer being serve to be transfer.", "Transfer Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function GetQueueList()
        If Not IsNothing(LoggedServer) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim custList As List(Of CustomerAssignCounter) = customerAssignCounterController.GetListOfCustomerInQueueByCounter(LoggedServer.ServerAssignCounter.Counter)
            flpPatientList.Controls.Clear()
            If Not IsNothing(custList) Then
                queueList = New List(Of CustomerItem)
                Dim ctr As Long = 0
                For Each customer As CustomerAssignCounter In custList
                    Dim custItem As New CustomerItem(customer)
                    Dim priorityColor As New Color
                    If customer.Priority = 1 Then
                        priorityColor = Color.MistyRose
                    ElseIf customer.Priority = 2 Then
                        priorityColor = Color.Gainsboro
                    Else
                        priorityColor = Color.Honeydew
                    End If
                    With custItem
                        .BackColor = priorityColor
                        .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                    End With
                    flpPatientList.Controls.Add(custItem)
                    queueList.Add(custItem)
                    ctr += 1
                Next
            End If
        End If
        Return True
    End Function

    Private Sub BeepOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeepOnlyToolStripMenuItem.Click
        If Me.isVoice Then
            SetPagingOption(False)
        Else
            SetPagingOption(True)
        End If
    End Sub

    Private Sub ShowThisDepartmentQueuingBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub QueueHistoryToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim frm As New frmHistory
        frm.ShowDialog()
    End Sub

    Private Sub VolumeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolumeToolStripMenuItem.Click
        Dim frm As New frmAudioSettings
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.Yes Then
            SetPagingConfig()
        End If
    End Sub

    Private Sub GeneratePriorityNumberToolStripMenuItem_Click(sender As Object, e As EventArgs)
        GeneratePriorityNumber()
    End Sub

    Private Sub MuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MuteToolStripMenuItem.Click
        Dim voiceModel As VoiceModel = VoiceSetting()
        voiceModel.Mute = Not voiceModel.Mute
        Mute = voiceModel.Mute
        MuteToolStripMenuItem.Checked = voiceModel.Mute
        VoiceSetting() = voiceModel
    End Sub

    Private Sub ShowSelectedDeparmentQueuingBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MessageBox.Show("This function is under construction. Please select other queuing board", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowSelectedDepartmentQueuingBoardStandAloneToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MessageBox.Show("This function is under construction. Please select other queuing board", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AutoRefershQueueListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoRefershQueueListToolStripMenuItem.Click
        Me.AutoRefereshQueueList = Not Me.AutoRefereshQueueList
        AutoRefreshQueueList() = Me.AutoRefereshQueueList
        AutoRefershQueueListToolStripMenuItem.Checked = Me.AutoRefereshQueueList
    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardADSToolStripMenuItem.Click
        If Not Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("This type of queuing board doesn't have sound and only rely on the audio from the counter.", "Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to unmute?", "Unmute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = False
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardADs).Any Then
            frmY.Close()
            frmY = New frmCounterQueuingBoardADs(LoggedServer.ServerAssignCounter.Counter)
            frmY.Show()
        End If
    End Sub

    Private Sub QueuingBoardALLDEPARTMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardALLDEPARTMENTToolStripMenuItem.Click
        If Not Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("This type of queuing board doesn't have sound and only rely on the audio from the counter.", "Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to unmute?", "Unmute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = False
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms().OfType(Of frmAllQueueBoard_Test).Any Then
            frmY.Close()
            frmY = New frmAllQueueBoard_Test
            frmY.Show()
        End If
    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QueuingBoardADSToolStripMenuItem1.Click
        If Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("Standalone queuing board has its own beep mechanism and may confict the beep mechanism of this queuing. It is `recommended to mute this queuing` so it won't conflict with the audio in standalone queuing board", "Standalone Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to mute?", "Mute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = True
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardADsStandalone).Any Then
            frmX.Close()
            frmX = New frmCounterQueuingBoardADsStandalone(LoggedServer.ServerAssignCounter.Counter)
            frmX.Show()
        End If
    End Sub

    Private Sub QueuingBoardALLDEPARTMENTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QueuingBoardALLDEPARTMENTToolStripMenuItem1.Click
        If Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("Standalone queuing board has its own beep mechanism and may confict the beep mechanism of this queuing. It is `recommended to mute this queuing` so it won't conflict with the audio in standalone queuing board", "Standalone Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If MessageBox.Show("Do you want to mute?", "Mute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = True
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms().OfType(Of frmAllQueueBoardStandalone).Any Then
            frmX.Close()
            frmX = New frmAllQueueBoardStandalone
            frmX.Show()
        End If
    End Sub

    Private Sub QueuingBoardSELECTEDCOUNTERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardSELECTEDCOUNTERSToolStripMenuItem.Click
        If Not Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("This type of queuing board doesn't have sound and only rely on the audio from the counter.", "Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to unmute?", "Unmute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = False
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If

showBoard:
        If Not Application.OpenForms().OfType(Of frmCounterQueuingBoardSelectedCounters).Any Then
            frmY.Close()
            frmY = New frmCounterQueuingBoardSelectedCounters()
            frmY.Show()
        End If
    End Sub

    Private Sub QueuingBoardSELECTEDDEPARTMENTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardSELECTEDDEPARTMENTSToolStripMenuItem.Click
        If Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("Standalone queuing board has its own beep mechanism and may confict the beep mechanism of this queuing. It is `recommended to mute this queuing` so it won't conflict with the audio in standalone queuing board", "Standalone Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            If MessageBox.Show("Do you want to mute?", "Mute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = True
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardSelectedCountersStandalone).Any Then
            frmX.Close()
            frmX = New frmCounterQueuingBoardSelectedCountersStandalone()
            frmX.Show()
        End If
    End Sub

    Private Sub ThisDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThisDepartmentToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueList).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueList(LoggedServer.ServerAssignCounter.Counter)
            frmZ.Show()
        End If
    End Sub

    Private Sub AllDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllDepartmentToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueListAll).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueListAll()
            frmZ.Show()
        End If
    End Sub

    Private Sub DepartmentSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentSummaryToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueListAll).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueListSummary()
            frmZ.Show()
        End If
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        If Not IsNothing(Me.ServingCustomer) Then
            Dim wantsync As Boolean = False
            If Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0 Then
                MessageBox.Show("This patient information was sync before and does not need to be sync unless informations are not match", "Sync Not Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Do you want to Re-Sync this patient's information?", "Sync Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    wantsync = True
                End If
            Else
                If MessageBox.Show("Do you want to Sync this patient's information?", "Sync Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    wantsync = True
                End If
            End If
            If wantsync Then
                Dim syncCustomerInfo As CustomerInfo = SyncCustomerLookup()
                If Not IsNothing(syncCustomerInfo) Then
                    Dim customerInfoController As New CustomerInfoController
                    Dim newServingCustomer As ServedCustomer = customerInfoController.SyncCustomerInfo(Me.ServingCustomer, syncCustomerInfo)
                    If Not IsNothing(newServingCustomer) Then
                        Me.ServingCustomer = newServingCustomer
                        lbcountername.Text = tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber
                        GetServingCustomerPCCInfo()
                        MessageBox.Show("Patient information sync successfully", "Information Sync", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Something went wrong during the process. Please try again later", "Sync Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            MessageBox.Show("There's no patient to sync.", "No Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnPrintConsultation_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Do you want to print this patient's consultation form?", "Print Consultation Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            MessageBox.Show("Printing not yet available", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSummaryModes_Click(sender As Object, e As EventArgs) Handles btnSummaryModes.Click
        ToogleChartMode(Not chartMode)
    End Sub

    Private Sub btnGeneratePriorityNumber_Click(sender As Object, e As EventArgs)
        GeneratePriorityNumber()
    End Sub

    Private Sub dgvDiagnosticResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If dgvDiagnosticResults.SelectedRows.Count > 0 Then
            Dim fileLink As String = dgvDiagnosticResults.SelectedRows(0).Cells("diagnosticResultLink").Value
            If IsNothing(fileLink) Then
                MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf fileLink.ToString.Trim.Length <= 0 Then
                MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                GotoDiagnosticResult(fileLink)
            End If
        End If
    End Sub

    Private Sub btnPrintRX_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Do you want to print this patient's diagnosis?", "Print Diagnosis Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            MessageBox.Show("Printing not yet available", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEditProfile_Click(sender As Object, e As EventArgs) Handles btnEditProfile.Click
        If Not IsNothing(Me.ServingCustomer) Then
            Dim wantEdit As Boolean = False
            If Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0 Then
                MessageBox.Show("This patient information was already sync before. Any modification will cause a difference of data.", "Edit Not Recommended", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Do you still want to edit this patient information?", "Edit Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    wantEdit = True
                End If
            Else
                wantEdit = True
            End If
            If wantEdit Then
                Dim frmProfiling As New frmPatientProfiling(Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo, True, False, False)
                frmProfiling.ShowDialog(Me)
                If frmProfiling.DialogResult = DialogResult.Yes Then
                    If Not IsNothing(frmProfiling.CustomerProfile) Then
                        Dim customerInfoController As New CustomerInfoController
                        Dim newServingCustomer As ServedCustomer = customerInfoController.EditCustomerInfo(Me.ServingCustomer, frmProfiling.CustomerProfile)
                        If Not IsNothing(newServingCustomer) Then
                            Me.ServingCustomer = newServingCustomer
                            lbcountername.Text = tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber
                            GetServingCustomerPCCInfo()
                            MessageBox.Show("Patient profile edited successfully", "Information Edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("There's no patient to sync.", "No Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnPreviewConsultationHistory_Click(sender As Object, e As EventArgs) Handles btnPreviewConsultationHistory.Click
        If (Me.dgvConsulationList.SelectedRows.Count > 0) Then
            If Me.pnlPrintForm.Visible Then
                Me.pnlPrintForm.Hide()
            Else
                Me.pnlPrintForm.Show()
            End If
        Else
            MessageBox.Show("Please select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnStartCompleteServing_Click(sender As Object, e As EventArgs) Handles btnStartCompleteServing.Click
        If Not IsNothing(Me.ServingCustomer) Then
            If ((MessageBox.Show("Are you sure to complete this serving patient?", "Complete Serving Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) AndAlso Me.SavePatientInitialConsultation_IfExist) Then
                Dim controller As New ServedCustomerController
                If controller.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                    If Not IsNothing(Me.autoTransferCounter) Then
                        Me.AutoTransferToConsulationClinic()
                    ElseIf ((WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.initialconsultation AndAlso Not IsNothing(Me.forBizboxConsultation)) AndAlso Not IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter)) Then
                        Me.autoTransferCounter = Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter
                        Me.AutoTransferToConsulationClinic()
                    End If
                    Me.ServingCustomer = Nothing
                    Me.tmpSelectedCustomer = Nothing
                    Me.btnTransafer.Visible = False
                    Me.btnReissueQueueNumber.Visible = False
                    Me.btnCancelQueueNumber.Visible = False
                    Me.btnSkipServingPatient.Visible = False
                    Me.btnPatientHistory.Visible = True
                    Me.btnStartCompleteServing.Text = "SERVE PATIENT"
                    Me.btnStartCompleteServing.BackColor = Color.LimeGreen
                    Me.lbcountername.Text = Me.tmpCounterName
                    Me.tbPatientData.SelectedTab = Me.tpProfile
                    Me.GetServingCustomerPCCInfo()
                    Me.stopQueueTimer()
                    Me.GetQueueList()
                Else
                    MessageBox.Show("Something went wrong on the process. Please try again", "Serving Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        ElseIf Not IsNothing(Me.tmpSelectedCustomer) Then
            If (MessageBox.Show(("Do you want to serve " & Me.tmpSelectedCustomer.QueuedPatient.ProcessedQueueNumber), "Serve Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim servedCustomer As New ServedCustomer
                Dim controller2 As New CustomerAssignCounterController
                servedCustomer.ServerTransaction = WMMCQMSConfig.LoggedServer
                servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = Me.tmpSelectedCustomer.QueuedPatient.CustomerAssignCounter_ID
                servedCustomer.CustomerAssignCounter.Counter = Me.tmpSelectedCustomer.QueuedPatient.Counter
                servedCustomer = controller2.GetNextNumber(servedCustomer)
                If Not IsNothing(servedCustomer) Then
                    If (servedCustomer.ServedCustomer_ID > 0) Then
                        Me.ServingCustomer = servedCustomer
                        Me.tmpSelectedCustomer = Nothing
                        Me.btnTransafer.Visible = True
                        Me.btnReissueQueueNumber.Visible = True
                        Me.btnCancelQueueNumber.Visible = True
                        Me.btnSkipServingPatient.Visible = True
                        Me.btnPatientHistory.Visible = False
                        Me.btnStartCompleteServing.Text = "COMPLETE TRANSACTION"
                        Me.btnStartCompleteServing.BackColor = Color.Green
                        Me.lbcountername.Text = (Me.tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber)
                        Me.CallNumber(servedCustomer.CustomerAssignCounter)
                        Me.tbPatientData.SelectedTab = Me.tpProfile
                        Me.GetServingCustomerPCCInfo()
                        Me.resetQueueTimer()
                    Else
                        MessageBox.Show("Patient not found on the queue. Please serve different patient.", "No Customer Found", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    Me.GetQueueList()
                Else
                    Me.ServingCustomer = Nothing
                    MessageBox.Show("There's an error occured during the process. Please try again", "Error Queuing Process", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        Else
            MessageBox.Show("Please select a patient to serve", "No Selected Patient", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnRegisterPatient_Click(sender As Object, e As EventArgs) Handles btnRegisterPatient.Click
        Dim customerInfo As CustomerInfo = CustomerLookup()
        If Not IsNothing(customerInfo) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim customerAssignCounter As New CustomerAssignCounter
            customerAssignCounter.Priority = 0
            customerAssignCounter.Counter = LoggedServer.ServerAssignCounter.Counter
            customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
            customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
            customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
            customerAssignCounter.Customer.CustomerInfo = customerInfo
            Dim generatedNumber As String = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
            If Not IsNothing(generatedNumber) Then
                GetQueueList()
                Dim patientName As String = customerAssignCounter.Customer.FullName
                Dim counter As String = ("PLEASE GO TO " & customerAssignCounter.Counter.ServiceDescription).Trim.ToUpper
                If customerAssignCounter.Counter.AutoTransfer_Payment = 1 Then
                    counter = "PLEASE GO TO CASHIER 1"
                End If
                Dim notes As String = ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper
                Dim frm As New frmNoGenerated(generatedNumber, patientName, counter, notes, customerAssignCounter.Customer.FK_emdPatients)
                frm.ShowDialog()
            Else
                MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnRecallPatient_Click(sender As Object, e As EventArgs) Handles btnRecallPatient.Click
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("You cannot serve another patient since you are still serving a patient", "Recall Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim frm As New frmViewSkippedNo(LoggedServer.ServerAssignCounter.Counter)
            frm.ShowDialog()
            If Not IsNothing(frm.SelectedCustomer) Then
                Me.ServingCustomer = frm.SelectedCustomer
                tmpSelectedCustomer = Nothing
                btnTransafer.Visible = True
                btnReissueQueueNumber.Visible = True
                btnCancelQueueNumber.Visible = True
                btnSkipServingPatient.Visible = True
                btnPatientHistory.Visible = False
                btnStartCompleteServing.Text = "COMPLETE TRANSACTION"
                btnStartCompleteServing.BackColor = Color.Green
                Dim otherStatus As String = ""
                If frm.SelectedCustomer.CustomerAssignCounter.ForHelee Then
                    otherStatus = " (MWELL CONSULTATION)"
                End If
                lbcountername.Text = tmpCounterName & " | SERVING: " & Me.ServingCustomer.CustomerAssignCounter.ProcessedQueueNumber & otherStatus
                tbPatientData.SelectedTab = tpProfile
                GetServingCustomerPCCInfo()
                CallNumber(frm.SelectedCustomer.CustomerAssignCounter)
                resetQueueTimer()
            End If
        End If
    End Sub

    Private Sub btnSkipServingPatient_Click(sender As Object, e As EventArgs) Handles btnSkipServingPatient.Click
        If Not IsNothing(Me.ServingCustomer) Then
            If MessageBox.Show("Put this patient on-hold?", "Put On-Hold", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Not IsNothing(Me.forBizboxConsultation) Then
                    If (IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter) Or (Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter_ID <= 0)) Then
                        Me.forBizboxConsultation = Nothing
                    ElseIf ((Me.forBizboxConsultation.OPDConsent1.Trim.Length <= 0) Or (Me.forBizboxConsultation.OPDConsent2.Trim.Length <= 0)) Then
                        Me.forBizboxConsultation = Nothing
                    End If
                End If
                If Me.SavePatientInitialConsultation_IfExist Then
                    Dim controller As New ServerTransactionController
                    If controller.UnserveAllCustomerOfCertainServerIfSkipped(WMMCQMSConfig.LoggedServer) Then
                        Me.ServingCustomer = Nothing
                        Me.tmpSelectedCustomer = Nothing
                        Me.btnTransafer.Visible = False
                        Me.btnReissueQueueNumber.Visible = False
                        Me.btnCancelQueueNumber.Visible = False
                        Me.btnSkipServingPatient.Visible = False
                        Me.btnPatientHistory.Visible = True
                        Me.btnStartCompleteServing.Text = "SERVE PATIENT"
                        Me.btnStartCompleteServing.BackColor = Color.LimeGreen
                        Me.lbcountername.Text = Me.tmpCounterName
                        Me.GetServingCustomerPCCInfo()
                        Me.stopQueueTimer()
                        Me.GetQueueList()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgvHealthCheck_History_SelectionChanged(sender As Object, e As EventArgs) Handles dgvHealthCheck_History.SelectionChanged
        If dgvHealthCheck_History.SelectedRows.Count > 0 Then
            Dim index As Long = dgvHealthCheck_History.SelectedRows(0).Cells("healthcheckhistory_id").Value
            tmpSelectedhealthcheck = Nothing
            For Each hc As HealthCheck In healthcheckHistory
                If hc.HealthCheck_ID = index Then
                    tmpSelectedhealthcheck = hc
                    Exit For
                End If
            Next
            If Not IsNothing(tmpSelectedhealthcheck) Then
                Dim withSymptoms As Boolean = False
                Dim withCloseContact As Boolean = False
                Dim hcCase As String = ""
                Dim healthCheckColor As Color = Color.Green
                If tmpSelectedhealthcheck.Fever Then
                    cbHealthcheck_Fever.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Fever.Checked = False
                End If
                If tmpSelectedhealthcheck.Cough Then
                    cbHealthcheck_Cough.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Cough.Checked = False
                End If
                If tmpSelectedhealthcheck.Sorethroat Then
                    cbHealthcheck_Sorethroat.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Sorethroat.Checked = False
                End If
                If tmpSelectedhealthcheck.Diarrhea Then
                    cbHealthcheck_Diarrhea.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Diarrhea.Checked = False
                End If
                If tmpSelectedhealthcheck.Diarrhea Then
                    cbHealthcheck_Diarrhea.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Diarrhea.Checked = False
                End If
                If tmpSelectedhealthcheck.ShortnessOfBreathing Then
                    cbHealthcheck_ShortnessOfBreathing.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_ShortnessOfBreathing.Checked = False
                End If
                If tmpSelectedhealthcheck.Ageusia Then
                    cbHealthcheck_Ageusia.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Ageusia.Checked = False
                End If
                If tmpSelectedhealthcheck.Anosmia Then
                    cbHealthcheck_Anosmia.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Anosmia.Checked = False
                End If
                If tmpSelectedhealthcheck.Anosmia Then
                    cbHealthcheck_Anosmia.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Anosmia.Checked = False
                End If
                If tmpSelectedhealthcheck.Colds Then
                    cbHealthcheck_Colds.Checked = True
                    withSymptoms = True
                Else
                    cbHealthcheck_Colds.Checked = False
                End If
                If tmpSelectedhealthcheck.CloseContactConfirmed Then
                    cbHealthcheck_CloseContactConfirmed.Checked = True
                    withCloseContact = True
                Else
                    cbHealthcheck_CloseContactConfirmed.Checked = False
                End If
                If tmpSelectedhealthcheck.CloseContactExhiting Then
                    cbHealthcheck_CloseContactExhibiting.Checked = True
                    withCloseContact = True
                Else
                    cbHealthcheck_CloseContactExhibiting.Checked = False
                End If
                If Not withSymptoms And Not withCloseContact Then
                    hcCase = hcCase & "| No Symptoms |"
                Else
                    healthCheckColor = Color.Maroon
                    If withSymptoms Then
                        hcCase = hcCase & "| With Symptoms |"
                    End If
                    If withCloseContact Then
                        hcCase = hcCase & "| With Close Contact |"
                    End If
                End If

                If Not tmpSelectedhealthcheck.isCurrent Then
                    lblHealthcheck_Eligible.Text = "NOT VALID"
                    lblHealthcheck_Eligible.BackColor = Color.Gray
                    lblHealthcheck_Eligible.ForeColor = Color.White
                ElseIf IsNothing(tmpSelectedhealthcheck.isEligible) Then
                    lblHealthcheck_Eligible.Text = "NOT SCREENED"
                    lblHealthcheck_Eligible.BackColor = Color.Yellow
                    lblHealthcheck_Eligible.ForeColor = Color.Black
                ElseIf tmpSelectedhealthcheck.isEligible Then
                    lblHealthcheck_Eligible.Text = "ELIGIBLE"
                    lblHealthcheck_Eligible.BackColor = Color.Green
                    lblHealthcheck_Eligible.ForeColor = Color.White
                ElseIf Not tmpSelectedhealthcheck.isEligible Then
                    lblHealthcheck_Eligible.Text = "NOT ELIGIBLE"
                    lblHealthcheck_Eligible.BackColor = Color.Maroon
                    lblHealthcheck_Eligible.ForeColor = Color.White
                End If
                lblHealthcheck_Case.Text = hcCase.ToUpper
                lblHealthcheck_Case.BackColor = healthCheckColor
                lblHealthcheck_Case.ForeColor = Color.White
                lblHealthcheck_Date.Text = tmpSelectedhealthcheck.DateOfAssesment.ToShortDateString & "" & tmpSelectedhealthcheck.DateOfAssesment.ToShortTimeString
                lblHealthcheck_Purpose.Text = tmpSelectedhealthcheck.PurposeOfVisit.ToUpper
            End If
            If dgvHealthCheck_History.SelectedRows(0).Index = 0 Then
                btnHealthcheck_EligibleToEnter.Show()
                btnHealthcheck_NotEligibleToEnter.Show()
            Else
                btnHealthcheck_EligibleToEnter.Hide()
                btnHealthcheck_NotEligibleToEnter.Hide()
            End If
        Else
            btnHealthcheck_EligibleToEnter.Hide()
            btnHealthcheck_NotEligibleToEnter.Hide()
        End If
    End Sub

    Private Sub btnHealthcheck_EligibleToEnter_Click(sender As Object, e As EventArgs) Handles btnHealthcheck_EligibleToEnter.Click
        If Not IsNothing(tmpSelectedhealthcheck) Then
            If MessageBox.Show("Allow this patient to enter the hospital?", "Eligible", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim hc As New HealthCheck
                hc.HealthCheck_ID = tmpSelectedhealthcheck.HealthCheck_ID
                hc.isEligible = 1
                hc.Info_ID = tmpSelectedhealthcheck.Info_ID
                Dim healthCheckController As New HealthcheckController
                If healthCheckController.MarkEligibilityOfPatient(hc) Then
                    tbPatientData.SelectedTab = tbHealthCheck
                    GetServingCustomerPCCInfo()
                    MessageBox.Show("You may now allow the patient to enter the hospital", "Eligible", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong during the process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btnHealthcheck_NotEligibleToEnter_Click(sender As Object, e As EventArgs) Handles btnHealthcheck_NotEligibleToEnter.Click
        If Not IsNothing(tmpSelectedhealthcheck) Then
            If MessageBox.Show("Are you sure you don't want this patient to enter the hospital?", "Not Eligible", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim hc As New HealthCheck
                hc.HealthCheck_ID = tmpSelectedhealthcheck.HealthCheck_ID
                hc.isEligible = 0
                hc.Info_ID = tmpSelectedhealthcheck.Info_ID
                Dim counterID As Long = Me.ServingCustomer.CustomerAssignCounter.Counter.Counter_ID
                Dim healthCheckController As New HealthcheckController
                If healthCheckController.MarkEligibilityOfPatient_WithCounterException(hc, counterID) Then
                    tbPatientData.SelectedTab = tbHealthCheck
                    GetServingCustomerPCCInfo()
                    MessageBox.Show("You may now transfer the patient to the emergency room - respiwing", "Not Eligible", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong during the process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub dgvConsulationList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsulationList.CellContentClick

    End Sub

    Private Sub dgvConsulationList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvConsulationList.SelectionChanged
        Me.dgvConsultation_DoctorsOrderPlans.Rows.Clear()
        If Not IsNothing(Me.bizboxRegistrationList) Then
            If dgvConsulationList.SelectedRows.Count > 0 Then
                Dim regID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListID").Value)
                Dim RODID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListRODID").Value)
                For Each registration As Bizbox_PatientDailyRegistration In Me.bizboxRegistrationList
                    If (registration.ID = regID) Then
                        If Not IsNothing(registration.DoctorData) Then
                            If (registration.DoctorData.ID = RODID) Then
                                Me.tmpSelectedBizboxRegistration = registration
                                Exit For
                            End If
                        End If
                    End If
                Next
                If Not IsNothing(Me.tmpSelectedBizboxRegistration) Then
                    Dim tmpSelectedBizboxRegistration As Bizbox_PatientDailyRegistration = Me.tmpSelectedBizboxRegistration
                    Dim bizboxConsultation As Bizbox_Consultation = tmpSelectedBizboxRegistration.BizboxConsultation
                    Dim consultationAttendingPhysician As String = " "
                    Dim consultationDate As String = " "
                    Dim queueStart As String = "NO START DATE"
                    Dim queueEnd As String = "NO END DATE"
                    If Not Information.IsNothing(bizboxConsultation) Then
                        If bizboxConsultation.ServedCustomer.ServerTransaction.ServerAssignCounter.Counter.CounterType > 0 Then
                            consultationAttendingPhysician = ("DR. " & bizboxConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.ToUpper)
                            consultationDate = Strings.Format(bizboxConsultation.DateCreated, "MMM dd, yyyy @ h:mm tt")
                            queueStart = If(Not IsNothing(bizboxConsultation.ServedCustomer) AndAlso Not IsNothing(bizboxConsultation.ServedCustomer.DateTimeStart), Strings.Format(bizboxConsultation.ServedCustomer.DateTimeStart.Value, "MMM dd, yyyy @ h:mm tt"), "NO START DATE")
                            queueEnd = If(Not IsNothing(bizboxConsultation.ServedCustomer) AndAlso Not IsNothing(bizboxConsultation.ServedCustomer.DateTimeEnd), Strings.Format(bizboxConsultation.ServedCustomer.DateTimeEnd.Value, "MMM dd, yyyy @ h:mm tt"), "NO END DATE")
                        End If
                    End If
                    lblPhysicianNursingAttendantConsultDate.Text = "DR. " & tmpSelectedBizboxRegistration.DoctorData.Lastname & ", " & tmpSelectedBizboxRegistration.DoctorData.Firstname & " " & tmpSelectedBizboxRegistration.DoctorData.SuffixName & vbCrLf &
                                                                    If(Not IsNothing(tmpSelectedBizboxRegistration.ConsultationIn), Format(tmpSelectedBizboxRegistration.ConsultationIn.Value, "MMM dd, yyyy @ h:mm tt"), "NO START DATE") & vbCrLf &
                                                                    If(Not IsNothing(tmpSelectedBizboxRegistration.ConsultationOut), Format(tmpSelectedBizboxRegistration.ConsultationOut.Value, "MMM dd, yyyy @ h:mm tt"), "NO END DATE") & vbCrLf &
                                                                    consultationAttendingPhysician & vbCrLf &
                                                                    consultationDate
                    lblConsultationType.Text = If(Not IsNothing(tmpSelectedBizboxRegistration.DoleEmpNo) AndAlso tmpSelectedBizboxRegistration.DoleEmpNo.Trim.Length > 0, tmpSelectedBizboxRegistration.DoleEmpNo, "NONE") & vbCrLf &
                                               If(Not IsNothing(tmpSelectedBizboxRegistration.DoleRefNO) AndAlso tmpSelectedBizboxRegistration.DoleRefNO.Trim.Length > 0, tmpSelectedBizboxRegistration.DoleRefNO.Trim.ToUpper, "NONE") & vbCrLf &
                                               If(Not IsNothing(tmpSelectedBizboxRegistration.DoleAppStat) AndAlso tmpSelectedBizboxRegistration.DoleAppStat.Trim.Length > 0, tmpSelectedBizboxRegistration.DoleAppStat.Trim.ToUpper, "NONE") & vbCrLf &
                                               queueStart & vbCrLf &
                                               queueEnd
                    Me.lbHeight.Text = ((tmpSelectedBizboxRegistration.Height1) & " " & tmpSelectedBizboxRegistration.HeightUnit)
                    Me.lbWeight.Text = ((tmpSelectedBizboxRegistration.Weight) & " " & tmpSelectedBizboxRegistration.WeightUnit)
                    Me.lblAllergies.Text = ""
                    Me.lblSymptoms.Text = ""
                    Me.lbBP.Text = ((tmpSelectedBizboxRegistration.Systolic) & "/" & (tmpSelectedBizboxRegistration.Diastolic))
                    Me.lbPR.Text = (tmpSelectedBizboxRegistration.PulseRate)
                    Me.lbRR.Text = (tmpSelectedBizboxRegistration.RespiratoryRate)
                    Me.lbTemp.Text = ((tmpSelectedBizboxRegistration.Temparature) & " °C")
                    Me.lbO2.Text = (CDbl(0))
                    Me.lblChiefComplaint.Text = tmpSelectedBizboxRegistration.ChiefComplaint.Trim
                    Me.lblHistoryOfPresentIllness.Text = tmpSelectedBizboxRegistration.HistoryOfPresentIllness.Trim
                    Me.lblPertinentPhysicalExam.Text = tmpSelectedBizboxRegistration.PertinentPhysicalExamination.Trim
                    Me.lblWorkingDiagnosis.Text = tmpSelectedBizboxRegistration.WorkingDiagnosis.Trim
                    Me.lbFinalDiagnosis.Text = tmpSelectedBizboxRegistration.FinalDiagnosis.Trim
                    Me.lbTreatment.Text = tmpSelectedBizboxRegistration.Treatment.Trim
                    Me.txtImpression.Text = tmpSelectedBizboxRegistration.Impression.Trim
                    Me.dgvConsultation_ICD10.Rows.Clear()
                    If Not IsNothing(tmpSelectedBizboxRegistration.FinalDiagnosisByICD10) Then
                        For Each sicd As Bizbox_FinalDiagnosisICD10 In tmpSelectedBizboxRegistration.FinalDiagnosisByICD10
                            Me.dgvConsultation_ICD10.Rows.Add(sicd.ID, sicd.ICD10MasterID, sicd.Description.Trim.ToUpper)
                            Me.dgvConsultation_ICD10.Rows((Me.dgvConsultation_ICD10.Rows.Count - 1)).Height = 30
                        Next
                    End If
                    Me.dgvConsultation_DoctorsOrderPlans.Rows.Clear()
                    If Not Information.IsNothing(tmpSelectedBizboxRegistration.Plans) Then
                        Dim plan As Bizbox_ConsultationPlan
                        For Each plan In tmpSelectedBizboxRegistration.Plans
                            Me.dgvConsultation_DoctorsOrderPlans.Rows.Add(plan.ID, plan.PlanGroup, plan.PlanGroupAbrev.Trim.ToUpper, plan.PlanDescription.Trim)
                            Me.dgvConsultation_DoctorsOrderPlans.Rows((Me.dgvConsultation_DoctorsOrderPlans.Rows.Count - 1)).Height = 30
                        Next
                    End If
                    Me.dgvConsultation_DoctorsOrderPlans.Rows.Clear()
                    If Not Information.IsNothing(tmpSelectedBizboxRegistration.Plans) Then
                        Dim plan As Bizbox_ConsultationPlan
                        For Each plan In tmpSelectedBizboxRegistration.Plans
                            Dim values As Object() = New Object() {plan.ID, plan.PlanGroup, plan.PlanGroupAbrev.Trim.ToUpper, plan.PlanDescription.Trim}
                            Me.dgvConsultation_DoctorsOrderPlans.Rows.Add(values)
                            Me.dgvConsultation_DoctorsOrderPlans.Rows((Me.dgvConsultation_DoctorsOrderPlans.Rows.Count - 1)).Height = 30
                        Next
                    End If
                    Me.dgvConsultation_SickLeave.Rows.Clear()
                    If Not Information.IsNothing(tmpSelectedBizboxRegistration.SickLeaves) Then
                        Dim leave As Bizbox_ConsultationSickLeave
                        For Each leave In tmpSelectedBizboxRegistration.SickLeaves
                            Me.dgvConsultation_SickLeave.Rows.Add(leave.ID, Format(leave.StartDate, "MMM dd, yyyy @ h:mm tt"), Format(leave.EndDate, "MMM dd, yyyy @ h:mm tt"), leave.ComputedDays)
                            Me.dgvConsultation_SickLeave.Rows((Me.dgvConsultation_SickLeave.Rows.Count - 1)).Height = 30
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnGoToDiagnosticResultLink_Click(sender As Object, e As EventArgs) Handles btnGoToDiagnosticResultLink.Click
        If dgvDiagnosticResults.SelectedRows.Count > 0 Then
            Dim fileLink As String = dgvDiagnosticResults.SelectedRows(0).Cells("diagnosticResultLink").Value
            If IsNothing(fileLink) Then
                MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf fileLink.ToString.Trim.Length <= 0 Then
                MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                GotoDiagnosticResult(fileLink)
            End If
        Else
            MessageBox.Show("Please select a result to view", "No Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnInitialConsultation_CancelConsultation_Click(sender As Object, e As EventArgs) Handles btnInitialConsultation_CancelConsultation.Click
        If (Not Information.IsNothing(Me.ServingCustomer) AndAlso Not Information.IsNothing(Me.forBizboxConsultation)) Then
            If Not Me.forBizboxConsultation.isServed Then
                If (MessageBox.Show("Are you sure do you want to cancel this consultation?", "Cancel Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Dim controller As New CustomerConsultationController
                    If controller.DeleteBizboxConsultation(Me.forBizboxConsultation.ID) Then
                        Me.forBizboxConsultation = Nothing
                        Me.GetServingCustomerPCCInfo()
                        MessageBox.Show("For consultation cancelled successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                End If
            Else
                MessageBox.Show("Cannot cancel since this consultation since the patient was already seen by the doctor", "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub dgvDiagnosticRequestList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnosticRequestList.CellContentClick

    End Sub

    Private Sub dgvDiagnosticRequestList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDiagnosticRequestList.SelectionChanged
        Me.dgvDiagnosticRequestItems.Rows.Clear()
        If (Me.dgvDiagnosticRequestList.SelectedRows.Count > 0) Then
            Dim index As Long = Me.dgvDiagnosticRequestList.SelectedRows(0).Cells("dgvDiagnosticRequestList_ID").Value
            Me.selectedBizboxRequisitions = Nothing
            For Each registers As PatientBixbox_PatRegisters In Me.bizboxRequisitions
                If (registers.PK_psPatRegisters = index) Then
                    Me.selectedBizboxRequisitions = registers
                    Exit For
                End If
            Next
            If Not IsNothing(Me.selectedBizboxRequisitions) Then
                Me.dgvDiagnosticTrasactionID.Text = Me.selectedBizboxRequisitions.RegistryNo
                If Not Information.IsNothing(Me.selectedBizboxRequisitions.PatItems_Rendered) Then
                    Dim grandTotal As Double = 0.0
                    Dim totalQty As Integer = 0
                    For Each items In Me.selectedBizboxRequisitions.PatItems_Rendered
                        If Not items.isRequestCancelled Then
                            Dim total As Double = (items.RenderPrice * items.RenderQTY)
                            grandTotal += items.RenderPrice * items.RenderQTY
                            totalQty += items.RenderQTY
                            Me.dgvDiagnosticRequestItems.Rows.Add(items.PK_psPatItems, items.ItemDescription, items.RenderPrice.ToString("N"), items.RenderQTY, total.ToString("N"))
                            Me.dgvDiagnosticRequestItems.Rows((Me.dgvDiagnosticRequestItems.Rows.Count - 1)).Height = 30
                        End If
                    Next
                    Me.lblDiagnosticRequestItems_Summary.Text = "DATE CREATED: " & Format(Me.selectedBizboxRequisitions.RegistryDate, "MMM dd, yyyy @ h:mm tt") & vbCrLf & "TOTAL QTY: " & (totalQty) & vbCrLf & "GRAND TOTAL: " & grandTotal.ToString("N")
                Else
                    Me.lblDiagnosticRequestItems_Summary.Text = "DATE CREATED:" & vbCrLf & "TOTAL QTY: " & vbCrLf & "GRAND TOTAL: "
                End If
                If LoggedServer.ServerAssignCounter.Counter.diagnosticAddEdit Then
                    If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics) Then
                        If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1) And Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2) Then
                            If (Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1.Trim.Length > 0) Or (Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2.Trim.Length > 0) Then
                                Me.ToogleDiagnosticConsent(True)
                            Else
                                Me.ToogleDiagnosticConsent(False)
                            End If
                        Else
                            Me.ToogleDiagnosticConsent(False)
                        End If
                    Else
                        Me.ToogleDiagnosticConsent(False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub pbProfilePicture_Click(sender As Object, e As EventArgs) Handles pbProfilePicture.Click
        If Not IsNothing(pbProfilePicture.Image) Then
            Dim frm As New frmViewPicture(pbProfilePicture.Image)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub btnMakeDeleteDiagnosticConsent_Click(sender As Object, e As EventArgs) Handles btnMakeDeleteDiagnosticConsent.Click
        If (Me.dgvDiagnosticRequestList.SelectedRows.Count > 0) Then
            Dim index As Long = (Me.dgvDiagnosticRequestList.SelectedRows(0).Cells("dgvDiagnosticRequestList_ID").Value)
            Me.selectedBizboxRequisitions = Nothing
            For Each registers As PatientBixbox_PatRegisters In Me.bizboxRequisitions
                If (registers.PK_psPatRegisters = index) Then
                    Me.selectedBizboxRequisitions = registers
                    Exit For
                End If
            Next
            If Not IsNothing(Me.selectedBizboxRequisitions) Then
                If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics) Then
                    If (Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1) Or Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2)) Then
                        MessageBox.Show("You will not be able to retrieve the consent once removed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If (MessageBox.Show("Are you sure to delete this consent?", "Delete Consent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            Dim controller As New DiagnosticsController
                            If controller.DeleteDiagnosticRequests(Me.selectedBizboxRequisitions.Diagnostics.Diagnostic_ID) Then
                                If IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1) Then
                                    Try
                                        If System.IO.File.Exists(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1) Then
                                            System.IO.File.Delete(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1)
                                        End If
                                    Catch exception1 As Exception

                                    End Try
                                End If
                                If Not Information.IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2) Then
                                    Try
                                        If System.IO.File.Exists(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2) Then
                                            System.IO.File.Delete(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2)
                                        End If
                                    Catch exception3 As Exception
                                    End Try
                                End If
                                Me.GetServingCustomerPCCInfo()
                                MessageBox.Show("Consent deleted successfully", "Consent Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                            End If
                        End If
                    Else
                        Dim controller As New DiagnosticsController
                        If controller.DeleteDiagnosticRequests(Me.selectedBizboxRequisitions.Diagnostics.Diagnostic_ID) Then
                            MessageBox.Show("The consent for this transaction was lost. Please attach a new consent", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            Dim consent As New frmGenerateConsent(1, Me.ServingCustomer.CustomerAssignCounter)
                            consent.ShowDialog(Me)
                            If (consent.DialogResult = DialogResult.Yes) Then
                                Dim diagnosticRequest As New Diagnostics With {
                                    .Diagnostics = "Diagnostics From Bizbox",
                                    .Remarks = "Diagnostics From Bizbox",
                                    .FK_emdPatients = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients,
                                    .ServerTransaction_ID = WMMCQMSConfig.LoggedServer.ServerTransaction_ID,
                                    .Info_ID = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID,
                                    .FK_psPatRegisters = Me.selectedBizboxRequisitions.PK_psPatRegisters,
                                    .OPDConsent1 = consent.ConsentFile1,
                                    .OPDConsent2 = consent.ConsentFile2
                                }
                                If controller.NewDiagnosticsFromBizbox(diagnosticRequest) Then
                                    MessageBox.Show("Consent added successfully", "Consent Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Me.tbPatientData.SelectedTab = Me.tpDiagnostics
                                    Me.GetServingCustomerPCCInfo()
                                End If
                            End If
                        End If
                    End If
                Else
                    Dim consent As New frmGenerateConsent(1, Me.ServingCustomer.CustomerAssignCounter)
                    consent.ShowDialog(Me)
                    If (consent.DialogResult = DialogResult.Yes) Then
                        Dim diagnosticRequest As New Diagnostics With {
                            .Diagnostics = "Diagnostics From Bizbox",
                            .Remarks = "Diagnostics From Bizbox",
                            .FK_emdPatients = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients,
                            .ServerTransaction_ID = WMMCQMSConfig.LoggedServer.ServerTransaction_ID,
                            .Info_ID = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID,
                            .FK_psPatRegisters = Me.selectedBizboxRequisitions.PK_psPatRegisters,
                            .OPDConsent1 = consent.ConsentFile1,
                            .OPDConsent2 = consent.ConsentFile2
                        }
                        Dim controller As New DiagnosticsController
                        If controller.NewDiagnosticsFromBizbox(diagnosticRequest) Then
                            MessageBox.Show("Consent added successfully", "Consent Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                            Me.tbPatientData.SelectedTab = Me.tpDiagnostics
                            Me.GetServingCustomerPCCInfo()
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("Please select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnViewDiagnosticConsent_Click(sender As Object, e As EventArgs) Handles btnViewDiagnosticConsent.Click
        If Me.dgvDiagnosticRequestList.SelectedRows.Count > 0 Then
            Dim index As Long = Me.dgvDiagnosticRequestList.SelectedRows(0).Cells("dgvDiagnosticRequestList_ID").Value
            Me.selectedBizboxRequisitions = Nothing
            For Each registers As PatientBixbox_PatRegisters In Me.bizboxRequisitions
                If (registers.PK_psPatRegisters = index) Then
                    Me.selectedBizboxRequisitions = registers
                    Exit For
                End If
            Next
            If Not IsNothing(Me.selectedBizboxRequisitions) Then
                If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics) Then
                    Dim diagnosticConsent As New List(Of String)
                    With diagnosticConsent
                        If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1) Then
                            If Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1.Trim.Length > 0 Then
                                .Add(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent1)
                            End If
                        End If
                        If Not IsNothing(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2) Then
                            If Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2.Trim.Length > 0 Then
                                .Add(Me.selectedBizboxRequisitions.Diagnostics.OPDConsent2)
                            End If
                        End If
                        If diagnosticConsent.Count > 0 Then
                            Dim frm As New frmPDFResultViewer(diagnosticConsent)
                            frm.ShowDialog()
                        End If
                    End With
                End If
            End If
        Else
            MessageBox.Show("Please select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub dgvHealthCheck_History_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHealthCheck_History.CellContentClick

    End Sub

    Private Sub btnViewConsultationConsent_Click(sender As Object, e As EventArgs) Handles btnViewConsultationConsent.Click
        If (Me.dgvConsulationList.SelectedRows.Count > 0) Then
            Dim regID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListID").Value)
            Dim RODID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListRODID").Value)
            For Each registration As Bizbox_PatientDailyRegistration In Me.bizboxRegistrationList
                If (registration.ID = regID) Then
                    If Not IsNothing(registration.DoctorData) Then
                        If (registration.DoctorData.ID = RODID) Then
                            Me.tmpSelectedBizboxRegistration = registration
                            Exit For
                        End If
                    End If
                End If
            Next
            If Not Information.IsNothing(Me.tmpSelectedBizboxRegistration) Then
                Dim pdfLink As New List(Of String)
                If (Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation) AndAlso (Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent1) Or Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent2))) Then
                    If (Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent1.Trim.Length > 0) Then
                        pdfLink.Add(Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent1)
                    End If
                    If (Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent2.Trim.Length > 0) Then
                        pdfLink.Add(Me.tmpSelectedBizboxRegistration.BizboxConsultation.OPDConsent2)
                    End If
                End If
                If (pdfLink.Count > 0) Then
                    Dim viewer As New frmPDFResultViewer(pdfLink)
                    viewer.ShowDialog(Me)
                    viewer.Dispose()
                Else
                    MessageBox.Show("No consent were attatched", "No Consent", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        Else
            MessageBox.Show("Please select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnReissueQueueNumber_Click(sender As Object, e As EventArgs) Handles btnReissueQueueNumber.Click
        If Not IsNothing(Me.ServingCustomer) Then
            If Not IsNothing(Me.ServingCustomer.CustomerAssignCounter.CustomerAssignCounter_ID) Then
                MessageBox.Show("All other queue numbers of the patient will be voided.", "Re-issue Queue Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Are you sure to re-issue a new queuing number?", "Re-issue Queue Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If DeletePatientUncalledQueueNumbers() Then
                        Dim frm As New frmTransferNo(Me.ServingCustomer.CustomerAssignCounter, 2)
                        frm.ShowDialog(Me)
                        If frm.DialogResult = DialogResult.Yes Then
                            Dim servedCustomerController As New ServedCustomerController
                            If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingCustomer) Then
                                Me.ServingCustomer = Nothing
                                tmpSelectedCustomer = Nothing
                                btnTransafer.Visible = False
                                btnReissueQueueNumber.Visible = False
                                btnCancelQueueNumber.Visible = False
                                btnSkipServingPatient.Visible = False
                                btnPatientHistory.Visible = True
                                btnStartCompleteServing.Text = "SERVE PATIENT"
                                btnStartCompleteServing.BackColor = Color.LimeGreen
                                lbcountername.Text = tmpCounterName
                                GetServingCustomerPCCInfo()
                                stopQueueTimer()
                                GetQueueList()
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("There's no customer being serve to be transfer.", "Transfer Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnCancelQueueNumber_Click(sender As Object, e As EventArgs) Handles btnCancelQueueNumber.Click
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("Note: This queuing number will be cancelled and remove from the list, and this action cannot be undone.", "Cancel Queuing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Are you sure to cancel this patient queue?", "Cancel Queuing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeletePatientCurrentQueueNumber() Then
                    Me.ServingCustomer = Nothing
                    tmpSelectedCustomer = Nothing
                    btnTransafer.Visible = False
                    btnReissueQueueNumber.Visible = False
                    btnCancelQueueNumber.Visible = False
                    btnSkipServingPatient.Visible = False
                    btnPatientHistory.Visible = True
                    btnStartCompleteServing.Text = "SERVE PATIENT"
                    btnStartCompleteServing.BackColor = Color.LimeGreen
                    lbcountername.Text = tmpCounterName
                    GetServingCustomerPCCInfo()
                    stopQueueTimer()
                    GetQueueList()
                End If
            End If
        End If
        If Not IsNothing(Me.ServingCustomer) Then
            MessageBox.Show("Note: This queuing number will be cancelled and remove from the list, and this action cannot be undone.", "Cancel Queuing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If (MessageBox.Show("Are you sure to cancel this patient queue?", "Cancel Queuing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If (Me.DeletePatientCurrentQueueNumber) Then
                    Me.ServingCustomer = Nothing
                    Me.tmpSelectedCustomer = Nothing
                    Me.btnTransafer.Visible = False
                    Me.btnReissueQueueNumber.Visible = False
                    Me.btnCancelQueueNumber.Visible = False
                    Me.btnSkipServingPatient.Visible = False
                    Me.btnPatientHistory.Visible = True
                    Me.btnStartCompleteServing.Text = "SERVE PATIENT"
                    Me.btnStartCompleteServing.BackColor = Color.LimeGreen
                    Me.lbcountername.Text = Me.tmpCounterName
                    Me.GetServingCustomerPCCInfo()
                    Me.stopQueueTimer()
                    Me.GetQueueList()
                Else
                    MessageBox.Show("Something went wrong on the process. Please try again", "Serving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub AllCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCounterToolStripMenuItem.Click
        If Not Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("This type of queuing board doesn't have sound and only rely on the audio from the counter.", "Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to unmute?", "Unmute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = False
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms().OfType(Of frmAllQueueBoard_Static).Any Then
            frmY.Close()
            frmY = New frmAllQueueBoard_Static
            frmY.Show()
        End If
    End Sub

    Private Sub AllCounterAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCounterAlertToolStripMenuItem.Click
        If Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("Standalone queuing board has its own beep mechanism and may confict the beep mechanism of this queuing. It is `recommended to mute this queuing` so it won't conflict with the audio in standalone queuing board", "Standalone Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to mute?", "Mute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = True
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms().OfType(Of frmAllQueueBoardStandalone_Static).Any Then
            frmX.Close()
            frmX = New frmAllQueueBoardStandalone_Static
            frmX.Show()
        End If
    End Sub


    Private Sub btnPatientHistory_Click(sender As Object, e As EventArgs) Handles btnPatientHistory.Click
        If IsNothing(Me.forViewOnlyCustomer) Then
            Dim frm As New frmMyPatients()
            frm.ShowDialog(Me)
            If ((frm.DialogResult = DialogResult.Yes) AndAlso Not Information.IsNothing(frm.SelectedCustomer)) Then
                Me.forViewOnlyCustomer = frm.SelectedCustomer
                Me.lblRefNo.Text = Nothing
                Me.bizboxRegistrationList = Nothing
                Me.tmpSelectedBizboxRegistration = Nothing
                Me.forBizboxConsultation = Nothing
                Me.autoTransferCounter = Nothing
                Me.bizboxRequisitions = Nothing
                Me.latestbizboxRequests = Nothing
                Me.diagnosticResultList = Nothing
                Me.selectedBizboxRequisitions = Nothing
                Me.healthcheckHistory = Nothing
                Me.tmpSelectedConsultation = Nothing
                Me.tmpSelectedhealthcheck = Nothing
                Dim vitalGraph As List(Of Bizbox_PatientDailyRegistration) = Nothing
                Dim consultationView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.consultationView
                Dim consultationAddEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.consultationAddEdit
                Dim diagnosticView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.diagnosticView
                Dim diagnosticAddEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.diagnosticAddEdit
                Dim eprescriptionView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.eprescriptionView
                Dim healthcheckView As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.healthcheckView
                Dim healthcheckAddEdit As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.healthcheckAddEdit
                Dim initialconsultation As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.initialconsultation
                Dim erconsultation As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.erconsultation
                Dim syncDetail As Boolean = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.SyncDetail
                Dim customerInfo As CustomerInfo = Me.forViewOnlyCustomer
                Dim custName As String = ""
                Dim custFName As String = ""
                Dim custMName As String = ""
                Dim custLName As String = ""
                Dim custAge As String = ""
                Dim custBDay As String = ""
                Dim custGender As String = ""
                Dim custCivilStatus As String = ""
                Dim custNationality As String = ""
                Dim custEmail As String = ""
                Dim custContact As String = ""
                Dim custStreet As String = ""
                Dim custBarangay As String = ""
                Dim custCity As String = ""
                Dim custPicture As String = ""
                If IsNothing(customerInfo.FirstName) And IsNothing(customerInfo.Lastname) Then
                    custName = "NAME NOT INDICATED"
                ElseIf (Not customerInfo.FirstName.Trim.Length > 0) And (Not customerInfo.Lastname.Trim.Length > 0) Then
                    custName = "NAME NOT INDICATED"
                Else
                    custName = customerInfo.Lastname.ToUpper & ", " & customerInfo.FirstName.ToUpper & " " & customerInfo.Middlename.ToUpper
                    custFName = customerInfo.FirstName.ToUpper
                    custMName = customerInfo.Middlename.ToUpper
                    custLName = customerInfo.Lastname.ToUpper
                End If
                Dim tmpAge = DateDiff(DateInterval.Year, customerInfo.BirthDate, Today).ToString
                custBDay = customerInfo.BirthDate.ToShortDateString.ToString.ToUpper
                If tmpAge > 0 Then
                    custAge = tmpAge.ToString
                Else
                    custAge = "AGE NOT INDICATED"
                End If
                If IsNothing(customerInfo.Sex) Then
                    custGender = "GENDER NOT INDICATED"
                ElseIf Not customerInfo.Sex.Trim.Length > 0 Then
                    custGender = "GENDER NOT INDICATED"
                Else
                    custGender = customerInfo.Sex.ToUpper
                End If
                If IsNothing(customerInfo.PhoneNumber) Then
                    custContact = "CONTACT NOT INDICATED"
                ElseIf customerInfo.PhoneNumber.Length <= 0 Then
                    custContact = "CONTACT NOT INDICATED"
                Else
                    custContact = customerInfo.PhoneNumber.ToString
                End If
                custStreet = customerInfo.StreetDrive
                custBarangay = customerInfo.Barangay
                custCity = customerInfo.CityMunicipality
                custPicture = If(Not IsNothing(customerInfo.PatientPicture), customerInfo.PatientPicture.Trim, "")
                Dim apiControler As New APIController
                Dim diagnosticController As New DiagnosticsController
                If IsNothing(customerInfo.CivilStatus) Then
                    custCivilStatus = "NOT INDICATED"
                ElseIf customerInfo.CivilStatus.Length <= 0 Then
                    custCivilStatus = "NOT INDICATED"
                Else
                    custCivilStatus = customerInfo.CivilStatus
                End If
                If IsNothing(customerInfo.Nationality) Then
                    custNationality = "NOT INDICATED"
                ElseIf customerInfo.Nationality.Length <= 0 Then
                    custNationality = "NOT INDICATED"
                Else
                    custNationality = customerInfo.Nationality
                End If
                If IsNothing(customerInfo.Email) Then
                    custEmail = "NOT INDICATED"
                ElseIf customerInfo.Email.Length <= 0 Then
                    custEmail = "NOT INDICATED"
                Else
                    custEmail = customerInfo.Email
                End If
                If consultationView Then
                    If Not Me.tbPatientData.TabPages.Contains(Me.tpConsultationHistory) Then
                        Me.tbPatientData.TabPages.Add(Me.tpConsultationHistory)
                    End If
                    vitalGraph = Me.GetBizboxPatientVitalSummary(forViewOnlyCustomer)
                    Me.bizboxRegistrationList = Me.GetBizboxPatientRegistrations(forViewOnlyCustomer)
                ElseIf Me.tbPatientData.TabPages.Contains(Me.tpConsultationHistory) Then
                    Me.tbPatientData.TabPages.Remove(Me.tpConsultationHistory)
                End If
                Me.btnProccedForConsultation.Hide()
                If diagnosticView Then
                    If Not Me.tbPatientData.TabPages.Contains(Me.tpDiagnostics) Then
                        Me.tbPatientData.TabPages.Add(Me.tpDiagnostics)
                    End If
                    If Not Information.IsNothing(forViewOnlyCustomer.FK_emdPatients) Then
                        Me.bizboxRequisitions = apiControler.GetCertainPatientBizboxTrasactionHistory(forViewOnlyCustomer.FK_emdPatients)
                        Me.diagnosticResultList = apiControler.GetCertainPatientDiagnosticResults(forViewOnlyCustomer.FK_emdPatients)
                    End If
                ElseIf Me.tbPatientData.TabPages.Contains(Me.tpDiagnostics) Then
                    Me.tbPatientData.TabPages.Remove(Me.tpDiagnostics)
                End If
                Me.btnViewDiagnosticConsent.Hide()
                Me.btnMakeDeleteDiagnosticConsent.Hide()
                If healthcheckView Then
                    If Not Me.tbPatientData.TabPages.Contains(Me.tbHealthCheck) Then
                        Me.tbPatientData.TabPages.Add(Me.tbHealthCheck)
                    End If
                    Me.healthcheckHistory = Me.GetPatientHealthChecks(forViewOnlyCustomer)
                ElseIf Me.tbPatientData.TabPages.Contains(Me.tbHealthCheck) Then
                    Me.tbPatientData.TabPages.Remove(Me.tbHealthCheck)
                End If
                If Me.tbPatientData.TabPages.Contains(Me.tbHealthCheck) Then
                    Me.tbPatientData.TabPages.Remove(Me.tbHealthCheck)
                End If
                If Me.tbPatientData.TabPages.Contains(Me.tpInitConsultation) Then
                    Me.tbPatientData.TabPages.Remove(Me.tpInitConsultation)
                End If
                If syncDetail Then
                    Me.btnSync.Show()
                    Me.btnEditProfile.Show()
                Else
                    Me.btnSync.Hide()
                    Me.btnEditProfile.Hide()
                End If
                If Me.tbPatientData.TabPages.Contains(Me.tbNotes) Then
                    Me.tbPatientData.TabPages.Remove(Me.tbNotes)
                End If
                If (forViewOnlyCustomer.FK_emdPatients > 0) Then
                    Me.lblRefNo.Text = forViewOnlyCustomer.FK_emdPatients
                    Me.lblRefNo.BackColor = Color.SeaGreen
                    Me.lblRefNo.ForeColor = Color.White
                Else
                    Me.lblRefNo.Text = "PROFILE NOT SYNC YET"
                    Me.lblRefNo.BackColor = Color.Gray
                    Me.lblRefNo.ForeColor = Color.White
                End If
                profile_info1.Text = custLName & Environment.NewLine & custFName & Environment.NewLine & custMName & Environment.NewLine & custAge & Environment.NewLine & custBDay
                profile_info2.Text = custGender & Environment.NewLine & custCivilStatus & Environment.NewLine & custNationality & Environment.NewLine & custEmail & Environment.NewLine & custStreet + " " + custBarangay + " " + custCity
                If custPicture.Length > 0 Then
                    Try
                        pbProfilePicture.Image = Image.FromFile(custPicture)
                    Catch ex As Exception
                        pbProfilePicture.Image = Nothing
                    End Try
                Else
                    pbProfilePicture.Image = Nothing
                End If
                Me.chartbp.Series("Systolic").Points.Clear()
                Me.chartbp.Series("Diastolic").Points.Clear()
                Me.chartRates.Series("pr").Points.Clear()
                Me.chartRates.Series("rr").Points.Clear()
                Me.chartRates.Series("o2").Points.Clear()
                Me.chartTemp.Series("temp").Points.Clear()
                Me.dgvVitalSummary.Rows.Clear()
                If Not Information.IsNothing(vitalGraph) Then
                    Me.btnSummaryModes.Enabled = False
                    Me.pnlCharMode.Hide()
                    Me.pnlTableMode.Hide()
                    Me.pnlNoVitals.Show()
                    If (vitalGraph.Count > 0) Then
                        Me.ToogleChartMode(Me.chartMode)
                        Me.btnSummaryModes.Enabled = True
                        Dim grandTotal As Integer = (vitalGraph.Count - 1)
                        Dim i As Integer = grandTotal
                        Do While (i >= 0)
                            Dim registration As Bizbox_PatientDailyRegistration = vitalGraph(i)
                            Dim xValue As String = Format(registration.RegistrationDate, "MMM dd")
                            Dim yValue As Object() = New Object() {registration.Systolic}
                            Me.chartbp.Series("Systolic").Points.AddXY(xValue, yValue)
                            Dim objArray2 As Object() = New Object() {registration.Diastolic}
                            Me.chartbp.Series("Diastolic").Points.AddXY(xValue, objArray2)
                            Dim objArray3 As Object() = New Object() {registration.PulseRate}
                            Me.chartRates.Series("pr").Points.AddXY(xValue, objArray3)
                            Dim objArray4 As Object() = New Object() {registration.RespiratoryRate}
                            Me.chartRates.Series("rr").Points.AddXY(xValue, objArray4)
                            Dim objArray5 As Object() = New Object() {registration.Temparature}
                            Me.chartTemp.Series("temp").Points.AddXY(xValue, objArray5)
                            i = (i + -1)
                        Loop
                        Dim registration2 As Bizbox_PatientDailyRegistration
                        For Each registration2 In vitalGraph
                            Dim values As Object() = New Object() {Format(registration2.RegistrationDate, "MMM dd, yyyy h:mm tt"), (registration2.Systolic & "/" & registration2.Diastolic), registration2.PulseRate, registration2.Oxygen, 0, registration2.Temparature}
                            Me.dgvVitalSummary.Rows.Add(values)
                            Me.dgvVitalSummary.Rows((Me.dgvVitalSummary.Rows.Count - 1)).Height = 30
                        Next
                    End If
                End If
                Me.lbHeight.Text = ""
                Me.lbWeight.Text = ""
                Me.lblAllergies.Text = ""
                Me.lblSymptoms.Text = ""
                Me.lbBP.Text = ""
                Me.lbPR.Text = ""
                Me.lbO2.Text = ""
                Me.lbRR.Text = ""
                Me.lbTemp.Text = ""
                Me.lbO2.Text = ""
                Me.lblPhysicianNursingAttendantConsultDate.Text = ""
                Me.lblConsultationType.Text = ""
                Me.lblChiefComplaint.Text = ""
                Me.lblHistoryOfPresentIllness.Text = ""
                Me.lblPertinentPhysicalExam.Text = ""
                Me.lblWorkingDiagnosis.Text = ""
                Me.lbFinalDiagnosis.Text = ""
                Me.lbTreatment.Text = ""
                Me.txtImpression.Text = ""
                Me.dgvConsulationList.Rows.Clear()
                If Not Information.IsNothing(Me.bizboxRegistrationList) Then
                    Dim registry As Bizbox_PatientDailyRegistration
                    For Each registry In Me.bizboxRegistrationList
                        Dim values As Object() = New Object(3 - 1) {}
                        values(0) = registry.ID
                        values(1) = Format(registry.RegistrationDate, "MMM dd, yyyy @ h:mm tt")
                        Dim textArray3 As String() = New String() {"DR. ", registry.DoctorData.Lastname, ", ", registry.DoctorData.Firstname, " ", registry.DoctorData.SuffixName}
                        values(2) = String.Concat(textArray3).Trim.ToUpper
                        Me.dgvConsulationList.Rows.Add(values)
                        Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).Height = 30
                        If Not Information.IsNothing(registry.BizboxConsultation) Then
                            Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).DefaultCellStyle.BackColor = Color.ForestGreen
                            Me.dgvConsulationList.Rows((Me.dgvConsulationList.Rows.Count - 1)).DefaultCellStyle.ForeColor = Color.White
                        End If
                    Next
                End If
                Me.dgvDiagnosticResults.Rows.Clear()
                If Not Information.IsNothing(Me.diagnosticResultList) Then
                    Dim diagnostics As Diagnostics
                    For Each diagnostics In Me.diagnosticResultList
                        Dim values As Object() = New Object() {diagnostics.PK_psExamResultMstr, diagnostics.Diagnostics, diagnostics.ItemDescription, If(Not Information.IsNothing(diagnostics.ResultReportLink), "AVAILABLE", "None"), diagnostics.ResultReportLink, Format(diagnostics.DiagnosticDate, "MMM dd, yyyy @ h:mm tt"), Format(diagnostics.ResultDate, "MMM dd, yyyy @ h:mm tt")}
                        Me.dgvDiagnosticResults.Rows.Add(values)
                        Me.dgvDiagnosticResults.Rows((Me.dgvDiagnosticResults.Rows.Count - 1)).Height = 30
                    Next
                End If
                Me.dgvDiagnosticRequestList.Rows.Clear()
                Me.dgvDiagnosticRequestItems.Rows.Clear()

                If Not Information.IsNothing(Me.bizboxRequisitions) Then
                    Dim registers As PatientBixbox_PatRegisters
                    For Each registers In Me.bizboxRequisitions
                        Dim str17 As String = "N/A"
                        Dim maroon As Color = Color.Maroon
                        If ((Not Information.IsNothing(registers.Diagnostics) AndAlso (Not Information.IsNothing(registers.Diagnostics.OPDConsent1) And Not Information.IsNothing(registers.Diagnostics.OPDConsent2))) AndAlso ((registers.Diagnostics.OPDConsent1.Trim.Length > 0) And (registers.Diagnostics.OPDConsent2.Trim.Length > 0))) Then
                            str17 = "YES"
                            maroon = Color.Green
                        End If
                        Dim values As Object() = New Object() {registers.PK_psPatRegisters, str17, Format(registers.RegistryDate, "MMM dd, yyyy @ h:mm tt")}
                        Me.dgvDiagnosticRequestList.Rows.Add(values)
                        Me.dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Height = 30
                        Me.dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Cells("dgvDiagnosticRequestList_Consent").Style.ForeColor = Color.White
                        Me.dgvDiagnosticRequestList.Rows((Me.dgvDiagnosticRequestList.Rows.Count - 1)).Cells("dgvDiagnosticRequestList_Consent").Style.BackColor = maroon
                    Next
                End If
                Me.dgvHealthCheck_History.Rows.Clear()
                Me.cbHealthcheck_Fever.Checked = False
                Me.cbHealthcheck_Cough.Checked = False
                Me.cbHealthcheck_Sorethroat.Checked = False
                Me.cbHealthcheck_Diarrhea.Checked = False
                Me.cbHealthcheck_ShortnessOfBreathing.Checked = False
                Me.cbHealthcheck_Ageusia.Checked = False
                Me.cbHealthcheck_Anosmia.Checked = False
                Me.cbHealthcheck_Colds.Checked = False
                Me.cbHealthcheck_CloseContactConfirmed.Checked = False
                Me.cbHealthcheck_CloseContactExhibiting.Checked = False
                Me.lblHealthcheck_Case.Text = ""
                Me.lblHealthcheck_Date.Text = ""
                If Not Information.IsNothing(Me.healthcheckHistory) Then
                    Dim check As HealthCheck
                    For Each check In Me.healthcheckHistory
                        Dim str18 As String = "SAFE"
                        If ((((((((check.Fever Or check.Cough) Or check.Sorethroat) Or check.Diarrhea) Or check.Diarrhea) Or check.ShortnessOfBreathing) Or check.Ageusia) Or check.Anosmia) Or check.Colds) Then
                            str18 = "With Symptoms"
                        End If
                        Dim values As Object() = New Object() {check.HealthCheck_ID, (check.DateOfAssesment.ToLongDateString & " " & check.DateOfAssesment.ToShortTimeString), str18}
                        Me.dgvHealthCheck_History.Rows.Add(values)
                        Me.dgvHealthCheck_History.Rows((Me.dgvHealthCheck_History.Rows.Count - 1)).Height = 30
                    Next
                End If
                Me.btnPatientHistory.BackColor = Color.Maroon
                Me.btnPatientHistory.Text = "CLOSE PATIENT HISTORY"
                Me.ToogleServingInfo(True)
            End If
        Else
            Me.forViewOnlyCustomer = Nothing
            Me.btnPatientHistory.BackColor = Color.LimeGreen
            Me.btnPatientHistory.Text = "VIEW PATIENT IN HISTORY"
            Me.ToogleServingInfo(False)
        End If
    End Sub

    Private Sub tpConsultationHistory_Click(sender As Object, e As EventArgs) Handles tpConsultationHistory.Click

    End Sub

    Private Sub btnGenerateMedicalCertificate_Click(sender As Object, e As EventArgs) Handles btnGenerateMedicalCertificate.Click
        If (Me.dgvConsulationList.SelectedRows.Count > 0) Then
            Dim regID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListID").Value)
            Dim RODID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListRODID").Value)
            For Each registration As Bizbox_PatientDailyRegistration In Me.bizboxRegistrationList
                If (registration.ID = regID) Then
                    If Not IsNothing(registration.DoctorData) Then
                        If (registration.DoctorData.ID = RODID) Then
                            Me.tmpSelectedBizboxRegistration = registration
                            Exit For
                        End If
                    End If
                End If
            Next
            If Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation) Then
                Dim certainPatientBizboxConsultation As Bizbox_Consultation = New CustomerConsultationController().GetCertainPatientBizboxConsultation2(Me.tmpSelectedBizboxRegistration.BizboxConsultation.ID, Me.tmpSelectedBizboxRegistration.DoctorData.ID)
                If Not Information.IsNothing(certainPatientBizboxConsultation) Then
                    Dim frm As New frmGenerateMedicalCertificate(certainPatientBizboxConsultation, True)
                    frm.ShowDialog(Me)
                    frm.Dispose()
                Else
                    MessageBox.Show("No consultation occured during this date", "No Consultation Record", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            Else
                Dim certainPatientRegistration As Bizbox_PatientDailyRegistration = New BizboxAPI().GetCertainPatientRegistration2(Me.tmpSelectedBizboxRegistration.ID, Me.tmpSelectedBizboxRegistration.DoctorData.ID)
                If Not Information.IsNothing(certainPatientRegistration) Then
                    Dim frm As New frmGenerateMedicalCertificate(certainPatientRegistration, True)
                    frm.ShowDialog(Me)
                    frm.Dispose()
                Else
                    MessageBox.Show("No consultation occured during this date", "No Consultation Record", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        Else
            MessageBox.Show("Please select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub pbRefreshList_Click(sender As Object, e As EventArgs) Handles pbRefreshList.Click
        GetQueueList()
        GetServingCustomerPCCInfo()
    End Sub

    Private Sub btnViewConsultationPrescription_Click(sender As Object, e As EventArgs) Handles btnViewConsultationPrescription.Click
        If dgvConsulationList.SelectedRows.Count > 0 Then
            Dim regID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListID").Value)
            Dim RODID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListRODID").Value)
            For Each registration As Bizbox_PatientDailyRegistration In Me.bizboxRegistrationList
                If (registration.ID = regID) Then
                    If Not IsNothing(registration.DoctorData) Then
                        If (registration.DoctorData.ID = RODID) Then
                            Me.tmpSelectedBizboxRegistration = registration
                            Exit For
                        End If
                    End If
                End If
            Next
            If Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation) Then
                Dim certainPatientBizboxConsultation As Bizbox_Consultation = New CustomerConsultationController().GetCertainPatientBizboxConsultation2(Me.tmpSelectedBizboxRegistration.BizboxConsultation.ID, Me.tmpSelectedBizboxRegistration.DoctorData.ID)
                If Not Information.IsNothing(certainPatientBizboxConsultation) Then
                    If (Not Information.IsNothing(certainPatientBizboxConsultation.BizboxRegistration) AndAlso Not Information.IsNothing(certainPatientBizboxConsultation.BizboxRegistration.Plans)) Then
                        Dim plans As List(Of Bizbox_ConsultationPlan) = certainPatientBizboxConsultation.BizboxRegistration.Plans
                        Dim customer As Customer = certainPatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer
                        Dim server As Server = certainPatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server
                        Dim custName As String = ""
                        Dim custFName As String = ""
                        Dim custMName As String = ""
                        Dim custLName As String = ""
                        Dim custAge As String = ""
                        Dim custBDay As String = ""
                        Dim custGender As String = ""
                        Dim custCivilStatus As String = ""
                        Dim custNationality As String = ""
                        Dim custEmail As String = ""
                        Dim custContact As String = ""
                        Dim custStreet As String = ""
                        Dim custBarangay As String = ""
                        Dim custCity As String = ""
                        Dim doctorsFullname As String = server.FullName.Trim.ToUpper
                        Dim doctorsPRCNo As String = server.PRC
                        Dim doctorsPTRNo As String = server.PTR
                        Dim doctorS2No As String = server.PTR
                        Dim doctorsHeader As String = ""
                        Dim doctorsSignature As String = ""
                        Dim consultationDate As String = Strings.Format(certainPatientBizboxConsultation.DateCreated, "MMM dd, yyyy")
                        If IsNothing(customer.CustomerInfo.FirstName) And IsNothing(customer.CustomerInfo.Lastname) Then
                            custName = "NAME NOT INDICATED"
                        ElseIf (Not customer.CustomerInfo.FirstName.Trim.Length > 0) And (Not customer.CustomerInfo.Lastname.Trim.Length > 0) Then
                            custName = "NAME NOT INDICATED"
                        Else
                            custName = customer.CustomerInfo.Lastname.ToUpper & ", " & customer.CustomerInfo.FirstName.ToUpper & " " & customer.CustomerInfo.Middlename.ToUpper
                            custFName = customer.CustomerInfo.FirstName.ToUpper
                            custMName = customer.CustomerInfo.Middlename.ToUpper
                            custLName = customer.CustomerInfo.Lastname.ToUpper
                        End If
                        Dim tmpAge = DateDiff(DateInterval.Year, customer.CustomerInfo.BirthDate, customer.DateOfVisit).ToString
                        custBDay = Format(customer.CustomerInfo.BirthDate, "MMM dd, yyyy")
                        If tmpAge > 0 Then
                            custAge = tmpAge.ToString
                        Else
                            custAge = "AGE NOT INDICATED"
                        End If
                        If IsNothing(customer.CustomerInfo.Sex) Then
                            custGender = "GENDER NOT INDICATED"
                        ElseIf Not customer.CustomerInfo.Sex.Trim.Length > 0 Then
                            custGender = "GENDER NOT INDICATED"
                        Else
                            custGender = customer.CustomerInfo.Sex.ToUpper
                        End If
                        If IsNothing(customer.CustomerInfo.PhoneNumber) Then
                            custContact = "CONTACT NOT INDICATED"
                        ElseIf customer.CustomerInfo.PhoneNumber.Length <= 0 Then
                            custContact = "CONTACT NOT INDICATED"
                        Else
                            custContact = customer.CustomerInfo.PhoneNumber.ToString
                        End If
                        custStreet = customer.CustomerInfo.StreetDrive
                        custBarangay = customer.CustomerInfo.Barangay
                        custCity = customer.CustomerInfo.CityMunicipality
                        If IsNothing(customer.CustomerInfo.CivilStatus) Then
                            custCivilStatus = "NOT INDICATED"
                        ElseIf customer.CustomerInfo.CivilStatus.Length <= 0 Then
                            custCivilStatus = "NOT INDICATED"
                        Else
                            custCivilStatus = customer.CustomerInfo.CivilStatus
                        End If
                        If IsNothing(customer.CustomerInfo.Nationality) Then
                            custNationality = "NOT INDICATED"
                        ElseIf customer.CustomerInfo.Nationality.Length <= 0 Then
                            custNationality = "NOT INDICATED"
                        Else
                            custNationality = customer.CustomerInfo.Nationality
                        End If
                        If IsNothing(customer.CustomerInfo.Email) Then
                            custEmail = "NOT INDICATED"
                        ElseIf customer.CustomerInfo.Email.Length <= 0 Then
                            custEmail = "NOT INDICATED"
                        Else
                            custEmail = customer.CustomerInfo.Email
                        End If
                        doctorsHeader = Me.doctorsHeaderLoc & doctorsPRCNo.Trim.ToLower & ".JPG"
                        If Not System.IO.File.Exists(doctorsHeader) Then
                            doctorsHeader = Me.doctorsHeaderLoc & "system_default.JPG"
                        End If
                        doctorsSignature = (Me.doctorsSignatureLoc & doctorsPRCNo.Trim.ToLower & ".JPG")
                        If Not System.IO.File.Exists(doctorsSignature) Then
                            doctorsSignature = ""
                        End If
                        Dim frm As New frmPrinting
                        Dim rpt As New RxPrescription
                        Dim withMeds As Boolean = False
                        Dim withS2Medicines As Boolean = False
                        If Not IsNothing(plans) Then
                            If plans.Count > 0 Then
                                withMeds = True
                            End If
                        End If
                        Dim dtPrescription As New DataTable
                        With dtPrescription
                            .Columns.Add("Description")
                            .Columns.Add("Generic")
                            .Columns.Add("Preparation")
                            .Columns.Add("SpecialInstruction")
                            .Columns.Add("beforeBreakfast")
                            .Columns.Add("afterBreakfast")
                            .Columns.Add("beforeLunch")
                            .Columns.Add("afterLunch")
                            .Columns.Add("beforeDinner")
                            .Columns.Add("afterDinner")
                            .Columns.Add("atBedTime")
                            .Columns.Add("qty")
                            If withMeds Then
                                Dim ctr As Integer = 0
                                For Each meds As Bizbox_ConsultationPlan In plans
                                    If (meds.PlanGroup.Trim.ToUpper = "MED") Then
                                        .Rows.Add(((ctr + 1) & ") " & meds.PlanDescription.Trim), "", "", "", "", "", "", "", "", "", "", "")
                                        ctr += 1
                                    End If
                                Next
                                If Not (ctr > 0) Then
                                    .Rows.Add("NO MEDICINE PRESCRIBED", "", "", "", "", "", "", "", "", "", "", "")
                                End If
                            Else
                                .Rows.Add("NO MEDICINE PRESCRIBED", "", "", "", "", "", "", "", "", "", "", "")
                            End If
                            rpt.Subreports("prescriptionList").SetDataSource(dtPrescription)
                        End With
                        rpt.SetParameterValue("prescriptionDate", consultationDate)
                        rpt.SetParameterValue("patientName", custName)
                        rpt.SetParameterValue("physicianName", ("Dr. " & doctorsFullname.Trim.ToUpper))
                        rpt.SetParameterValue("prcNo", (doctorsPRCNo.Trim.ToUpper))
                        rpt.SetParameterValue("ptrNo", (doctorsPTRNo.Trim.ToUpper))
                        rpt.SetParameterValue("s2No", (If(withS2Medicines, doctorS2No.Trim.ToUpper, "")))
                        rpt.SetParameterValue("signatureImg", doctorsSignature)
                        With frm
                            .CrystalReportViewer1.ReportSource = rpt
                            .ShowDialog()
                        End With
                        frm.Dispose()
                    End If
                End If
            Else
                Dim certainPatientRegistration As Bizbox_PatientDailyRegistration = New BizboxAPI().GetCertainPatientRegistration2(Me.tmpSelectedBizboxRegistration.ID, Me.tmpSelectedBizboxRegistration.DoctorData.ID)
                If Not Information.IsNothing(certainPatientRegistration) Then
                    If Not Information.IsNothing(certainPatientRegistration.Plans) Then
                        Dim plans As List(Of Bizbox_ConsultationPlan) = certainPatientRegistration.Plans
                        Dim patientData As Bizbox_PatientPersonalData = certainPatientRegistration.PatientData
                        Dim doctorData As Bizbox_DoctorsInfo = certainPatientRegistration.DoctorData
                        Dim custName As String = ""
                        Dim custFName As String = ""
                        Dim custMName As String = ""
                        Dim custLName As String = ""
                        Dim custAge As String = ""
                        Dim custBDay As String = ""
                        Dim custGender As String = ""
                        Dim custCivilStatus As String = ""
                        Dim custNationality As String = ""
                        Dim custEmail As String = ""
                        Dim custContact As String = ""
                        Dim custStreet As String = ""
                        Dim custBarangay As String = ""
                        Dim custCity As String = ""
                        Dim doctorsFullname As String = (doctorData.Lastname & ", " & doctorData.Firstname & " " & doctorData.MiddleName & ", " & doctorData.SuffixName).Trim.ToUpper
                        Dim doctorsPRCNo As String = doctorData.PRC
                        Dim doctorsPTRNo As String = doctorData.PTR
                        Dim doctorS2No As String = doctorData.S2No
                        Dim doctorsHeader As String = ""
                        Dim doctorsSignature As String = ""
                        Dim consultationDate As String = Format(certainPatientRegistration.RegistrationDate, "MMM dd, yyyy")
                        If IsNothing(patientData.Firstname) And IsNothing(patientData.Lastname) Then
                            custName = "NAME NOT INDICATED"
                        ElseIf (Not patientData.Firstname.Trim.Length > 0) And (Not patientData.Lastname.Trim.Length > 0) Then
                            custName = "NAME NOT INDICATED"
                        Else
                            custName = patientData.FullName.Trim.ToUpper
                            custFName = patientData.Firstname.Trim.ToUpper
                            custMName = patientData.MiddleName.Trim.ToUpper
                            custLName = patientData.Lastname.Trim.ToUpper
                        End If
                        Dim tmpAge = DateDiff(DateInterval.Year, patientData.BirthDate, certainPatientRegistration.RegistrationDate).ToString
                        custBDay = Format(patientData.BirthDate, "MMM dd, yyyy")
                        If tmpAge > 0 Then
                            custAge = tmpAge.ToString
                        Else
                            custAge = "AGE Not INDICATED"
                        End If
                        If Information.IsNothing(patientData.Gender) Then
                            custGender = "GENDER Not INDICATED"
                        ElseIf Not (patientData.Gender.Trim.Length > 0) Then
                            custGender = "GENDER Not INDICATED"
                        Else
                            custGender = patientData.Gender.Trim.ToUpper
                        End If
                        If Not Information.IsNothing(patientData.MobileNo1) Then
                            custContact = patientData.MobileNo1
                        ElseIf Not Information.IsNothing(patientData.MobileNo2) Then
                            custContact = patientData.MobileNo2
                        Else
                            custContact = "CONTACT Not INDICATED"
                        End If
                        custStreet = patientData.AddressPt1
                        custBarangay = patientData.AddressPt2
                        custCity = patientData.AddressPt3
                        If Information.IsNothing(patientData.CivilStatus) Then
                            custCivilStatus = "Not INDICATED"
                        ElseIf (patientData.CivilStatus.Length <= 0) Then
                            custCivilStatus = "Not INDICATED"
                        Else
                            custCivilStatus = patientData.CivilStatus.Trim.ToUpper
                        End If
                        If Information.IsNothing(patientData.Nationality) Then
                            custNationality = "Not INDICATED"
                        ElseIf (patientData.Nationality.Length <= 0) Then
                            custNationality = "Not INDICATED"
                        Else
                            custNationality = patientData.Nationality.Trim.ToUpper
                        End If
                        If Information.IsNothing(patientData.Email) Then
                            custEmail = "Not INDICATED"
                        ElseIf (patientData.Email.Length <= 0) Then
                            custEmail = "Not INDICATED"
                        Else
                            custEmail = patientData.Email.Trim.ToUpper
                        End If
                        doctorsHeader = Me.doctorsHeaderLoc & doctorsPRCNo.Trim.ToLower & ".JPG"
                        If Not System.IO.File.Exists(doctorsHeader) Then
                            doctorsHeader = Me.doctorsHeaderLoc & "system_default.JPG"
                        End If
                        doctorsSignature = (Me.doctorsSignatureLoc & doctorsPRCNo.Trim.ToLower & ".JPG")
                        If Not System.IO.File.Exists(doctorsSignature) Then
                            doctorsSignature = ""
                        End If
                        Dim frm As New frmPrinting
                        Dim rpt As New RxPrescription
                        Dim withMeds As Boolean = False
                        Dim withS2Medicines As Boolean = False
                        If Not IsNothing(plans) Then
                            If plans.Count > 0 Then
                                withMeds = True
                            End If
                        End If
                        Dim dtPrescription As New DataTable
                        With dtPrescription
                            .Columns.Add("Description")
                            .Columns.Add("Generic")
                            .Columns.Add("Preparation")
                            .Columns.Add("SpecialInstruction")
                            .Columns.Add("beforeBreakfast")
                            .Columns.Add("afterBreakfast")
                            .Columns.Add("beforeLunch")
                            .Columns.Add("afterLunch")
                            .Columns.Add("beforeDinner")
                            .Columns.Add("afterDinner")
                            .Columns.Add("atBedTime")
                            .Columns.Add("qty")
                            If withMeds Then
                                Dim ctr As Integer = 0
                                For Each meds As Bizbox_ConsultationPlan In plans
                                    If (meds.PlanGroup.Trim.ToUpper = "MED") Then
                                        .Rows.Add(((ctr + 1) & ") " & meds.PlanDescription.Trim), "", "", "", "", "", "", "", "", "", "", "")
                                        ctr += 1
                                    End If
                                Next
                                If Not (ctr > 0) Then
                                    .Rows.Add("NO MEDICINE PRESCRIBED", "", "", "", "", "", "", "", "", "", "", "")
                                End If
                            Else
                                .Rows.Add("NO MEDICINE PRESCRIBED", "", "", "", "", "", "", "", "", "", "", "")
                            End If
                            rpt.Subreports("prescriptionList").SetDataSource(dtPrescription)
                        End With
                        rpt.SetParameterValue("prescriptionDate", consultationDate)
                        rpt.SetParameterValue("patientName", custName)
                        rpt.SetParameterValue("physicianName", ("Dr. " & doctorsFullname.Trim.ToUpper))
                        rpt.SetParameterValue("prcNo", (doctorsPRCNo.Trim.ToUpper))
                        rpt.SetParameterValue("ptrNo", (doctorsPTRNo.Trim.ToUpper))
                        rpt.SetParameterValue("s2No", (If(withS2Medicines, doctorS2No.Trim.ToUpper, "")))
                        rpt.SetParameterValue("signatureImg", doctorsSignature)
                        With frm
                            .CrystalReportViewer1.ReportSource = rpt
                            .ShowDialog()
                        End With
                        frm.Dispose()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Please Select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        pnlPrintForm.Hide()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        If dgvConsulationList.SelectedRows.Count > 0 Then
            Dim ID As Long = dgvConsulationList.SelectedRows(0).Cells("conListID").Value
            Dim consultationController As New CustomerConsultationController
            Dim consultation As CustomerConsultation = consultationController.GetCertainPatientConsultation(ID)
            If Not IsNothing(consultation.ERTraigeForm) Then
                Dim erForm As New frmGenerateERTriageForm(consultation, True)
                erForm.ShowDialog(Me)
                erForm.Dispose()
            Else
                MessageBox.Show("No ER TRIAGE FORM was attached For this Consultation.", "No Attached Form", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Do you want To attach an ER TRIAGE FORM For this consultation?", "Attach Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    consultation.ERTraigeForm = consultationController.GetPatientERCharts_CreateInitialErChart(consultation)
                    consultation.ERTraigeForm.TriageOnDuty = ""
                    Dim erForm As New frmGenerateERTriageForm(consultation, True)
                    erForm.ShowDialog(Me)
                    erForm.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub tbPatientData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbPatientData.SelectedIndexChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        If dgvConsulationList.SelectedRows.Count > 0 Then
            Dim ID As Long = dgvConsulationList.SelectedRows(0).Cells("conListID").Value
            Dim consultationController As New CustomerConsultationController
            Dim consultation As CustomerConsultation = consultationController.GetCertainPatientConsultation(ID)
            If Not IsNothing(consultation.NurseNotes) Then
                Dim nnotes As New frmGenerateNurseNotes(consultation, True)
                nnotes.ShowDialog(Me)
                nnotes.Dispose()
            Else
                MessageBox.Show("No NURSE PROGRESS NOTES was attached For this Consultation.", "No Attached Form", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Do you want To attach an NURSE PROGRESS NOTES For this consultation?", "Attach Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    consultation.NurseNotes = consultationController.GetPatientNurseNotes_CreateInitialNurseNote(consultation)
                    Dim nNotesForm As New frmGenerateNurseNotes(consultation, True)
                    nNotesForm.ShowDialog(Me)
                    nNotesForm.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub lkCheckFolllowSchedules_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If Not IsNothing(Me.ServingCustomer) Then
            Dim frm As New frmFollowUpConsultationSchedule(Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo)
            frm.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnProccedForConsultation_Click(sender As Object, e As EventArgs) Handles btnProccedForConsultation.Click
        If Me.dgvConsulationList.SelectedRows.Count > 0 Then
            If Not Information.IsNothing(Me.ServingCustomer) Then
                If (Not Information.IsNothing(Me.forBizboxConsultation) AndAlso (Me.forBizboxConsultation.ID > 0)) Then
                    MessageBox.Show("This patient has an ongoing consultation. You may cancel the ongoing consultation To create New.", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Me.FillInitialConsultationDetail()
                Else
                    Dim regID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListID").Value)
                    Dim RODID As Long = (Me.dgvConsulationList.SelectedRows(0).Cells("conListRODID").Value)
                    For Each registration As Bizbox_PatientDailyRegistration In Me.bizboxRegistrationList
                        If (registration.ID = regID) Then
                            If Not IsNothing(registration.DoctorData) Then
                                If (registration.DoctorData.ID = RODID) Then
                                    Me.tmpSelectedBizboxRegistration = registration
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    If (Not Information.IsNothing(Me.tmpSelectedBizboxRegistration) AndAlso Not Information.IsNothing(Me.tmpSelectedBizboxRegistration.BizboxConsultation)) Then
                        MessageBox.Show("This transaction was already used For consultation, Please Select a different transaction", "Already Consulted", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Else
                        Dim controller As New ServerController
                        If Not Information.IsNothing(controller.GetDoctorInfo(Me.tmpSelectedBizboxRegistration.DoctorData.PRC)) Then
                            If (MessageBox.Show("Do you want To use this transaction And proceed For consultation?", "Proceed Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                                Dim consent As New frmGenerateConsent(1, Me.ServingCustomer.CustomerAssignCounter)
                                consent.ShowDialog(Me)
                                If (consent.DialogResult = DialogResult.Yes) Then
                                    Dim consultation As New Bizbox_Consultation With {
                                        .ID = 0,
                                        .OPDConsent1 = consent.ConsentFile1,
                                        .OPDConsent2 = consent.ConsentFile2,
                                        .PhysicianLookup_PRC = Me.tmpSelectedBizboxRegistration.DoctorData.PRC,
                                        .FK_psPatRegisters = Me.tmpSelectedBizboxRegistration.ID,
                                        .FK_emdPatients = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients,
                                        .Info_ID = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID,
                                        .ServerTransaction_ID = Me.ServingCustomer.ServerTransaction_ID,
                                        .ServedCustomerID = Me.ServingCustomer.ServedCustomer_ID,
                                        .ForInitialConsultation_ServerAssignCounter_ID = 0,
                                        .ForInitialConsultation_ServerAssignCounter = Nothing,
                                        .BizboxRegistration = Me.tmpSelectedBizboxRegistration
                                    }
                                    Me.forBizboxConsultation = consultation
                                    Me.FillInitialConsultationDetail()
                                End If
                            End If
                        Else
                            MessageBox.Show("Cannot proceed since doctor Is Not yet registered In e-clinic", "E-Clinic Account", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("Please Select a registration", "No Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub btnInitialConsultation_ViewConsent_Click(sender As Object, e As EventArgs) Handles btnInitialConsultation_ViewConsent.Click
        If (Not IsNothing(Me.ServingCustomer) AndAlso Not IsNothing(Me.forBizboxConsultation)) Then
            Dim pdfLink As New List(Of String)
            If (Not IsNothing(Me.forBizboxConsultation.OPDConsent1) Or Not IsNothing(Me.forBizboxConsultation.OPDConsent2)) Then
                If (Me.forBizboxConsultation.OPDConsent1.Trim.Length > 0) Then
                    pdfLink.Add(Me.forBizboxConsultation.OPDConsent1)
                End If
                If (Me.forBizboxConsultation.OPDConsent2.Trim.Length > 0) Then
                    pdfLink.Add(Me.forBizboxConsultation.OPDConsent2)
                End If
                If (pdfLink.Count > 0) Then
                    Dim frm As New frmPDFResultViewer(pdfLink)
                    frm.ShowDialog(Me)
                    frm.Dispose()
                Else
                    MessageBox.Show("No consent were attatched", "No Consent", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        End If
    End Sub

    Private Sub btnInitialConsultation_TransferAndContinue_Click(sender As Object, e As EventArgs) Handles btnInitialConsultation_TransferAndContinue.Click
        If Not IsNothing(Me.ServingCustomer) Then
            If Not IsNothing(Me.ServingCustomer.CustomerAssignCounter.CustomerAssignCounter_ID) Then
                If MessageBox.Show("Do you want to transfer the patient while still continue serving?", "Transfer and Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If SavePatientInitialConsultation_IfExist() Then
                        Dim frmIsDOle As New frmSelectDoleNonDole()
                        frmIsDOle.ShowDialog(Me)
                        If frmIsDOle.DialogResult = DialogResult.Yes Then 'Dole Patient Directly Transfer
                            If Not IsNothing(Me.autoTransferCounter) Then
                                Me.AutoTransferToConsulationClinic()
                            ElseIf ((WMMCQMSConfig.LoggedServer.ServerAssignCounter.Counter.initialconsultation AndAlso Not IsNothing(Me.forBizboxConsultation)) AndAlso Not IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter)) Then
                                Me.autoTransferCounter = Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter
                                Me.AutoTransferToConsulationClinic()
                            End If
                            Me.forBizboxConsultation = Nothing
                            Me.GetServingCustomerPCCInfo()
                            MessageBox.Show("Patient transfered successfully. You may continue serving the patient", "Transfered and Continue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.tbPatientData.SelectedTab = Me.tpConsultationHistory
                        ElseIf frmIsDOle.DialogResult = DialogResult.No Then 'None Dole requires Payment Method
                            Dim frm As New frmPaymentMethod
                            frm.ShowDialog(Me)
                            If frm.DialogResult = DialogResult.Yes Then
                                Dim selectedCounter As Counter = Nothing
                                If frm.PaymentMethod = 1 Then
                                    selectedCounter = Me.transferCounter_payment_cash
                                ElseIf frm.PaymentMethod = 2 Then
                                    selectedCounter = Me.transferCounter_payment_card
                                ElseIf frm.PaymentMethod = 3 Then
                                    selectedCounter = Me.transferCounter_payment_hmo
                                ElseIf frm.PaymentMethod = 4 Then
                                    selectedCounter = Me.transferCounter_payment_philhealth
                                End If
                                If Not IsNothing(selectedCounter) Then
                                    Dim customerAssignCounterController As New CustomerAssignCounterController
                                    Dim transferedCustomerAssignCounter As New CustomerAssignCounter
                                    transferedCustomerAssignCounter.Counter = selectedCounter
                                    transferedCustomerAssignCounter.Customer = Me.ServingCustomer.CustomerAssignCounter.Customer
                                    transferedCustomerAssignCounter.Priority = 0
                                    transferedCustomerAssignCounter.Notes = frm.NotesAndRemaks
                                    transferedCustomerAssignCounter.PaymentMethod = frm.PaymentMethod
                                    transferedCustomerAssignCounter.NoteDepartment = ""
                                    transferedCustomerAssignCounter.NoteSection = ""
                                    Dim generatedNumber As String = customerAssignCounterController.TransferPatient(transferedCustomerAssignCounter)
                                    If Not IsNothing(generatedNumber) Then
                                        If generatedNumber.Trim.Length > 0 Then
                                            Dim patient As Customer = Me.ServingCustomer.CustomerAssignCounter.Customer
                                            Dim patientName As String = ""
                                            Dim counter As String = "PLEASE GO TO PAYMENT"
                                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE DIAGNOSTICS"
                                            Dim queueNumber As String = generatedNumber
                                            If IsNothing(patient.CustomerInfo.FirstName) And IsNothing(patient.CustomerInfo.Lastname) Then
                                                patientName = "NAME NOT INDICATED"
                                            ElseIf (Not patient.CustomerInfo.FirstName.Trim.Length > 0) And (Not patient.CustomerInfo.Lastname.Trim.Length > 0) Then
                                                patientName = "NAME NOT INDICATED"
                                            Else
                                                patientName = patient.CustomerInfo.Lastname.ToUpper & ", " & patient.CustomerInfo.FirstName.ToUpper & " " & patient.CustomerInfo.Middlename.ToUpper
                                            End If
                                            Dim frmGenerated As New frmNoGenerated(queueNumber, patientName, counter, notes, patient.FK_emdPatients)
                                            frmGenerated.ShowDialog()
                                            Me.forBizboxConsultation = Nothing
                                            Me.GetServingCustomerPCCInfo()
                                            MessageBox.Show("Patient transfered successfully. You may continue serving the patient", "Transfered and Continue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Me.tbPatientData.SelectedTab = Me.tpConsultationHistory
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("There's no customer being serve to be transfer.", "Transfer Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub NextPage_BTN_Click(sender As Object, e As EventArgs) Handles NextPage_BTN.Click
        IDInfo_Panel.Show()
        Profile_Info2Panel.Hide()
    End Sub

    Private Sub PrevPage_BTN_Click(sender As Object, e As EventArgs) Handles PrevPage_BTN.Click
        Profile_Info2Panel.Show()
        IDInfo_Panel.Hide()
    End Sub

    Private Sub btnAssignPhysician_Click(sender As Object, e As EventArgs) Handles btnAssignPhysician.Click
        If Not IsNothing(Me.ServingCustomer) Then
            Dim flag As Boolean = False
            If Not IsNothing(Me.forBizboxConsultation) Then
                If Not IsNothing(Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter) Then
                    MessageBox.Show("You have already assigned a consultant For this consultation.", "Assigned Already", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    If (MessageBox.Show("Are you sure you want To re-assign a consultant For this consultation?", "Re-assign Consultant", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        flag = True
                    End If
                Else
                    flag = True
                End If
            End If
            If flag Then
                Dim defaultList As Integer = 0
                Dim consultant As New frmSelectConsultant(defaultList)
                consultant.ShowDialog()
                If (consultant.DialogResult = DialogResult.Yes) Then
                    flag = False
                    If (consultant.SelectedClinic.Server.PRC <> Me.forBizboxConsultation.BizboxRegistration.DoctorData.PRC) Then
                        MessageBox.Show("The physician you selected Is Not the same As the assigned physician On bizbox", "Physician Inconsistency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If (MessageBox.Show("Do you still want To assign this physician To this patient", "Assign Physician", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                            flag = True
                        End If
                    Else
                        flag = True
                    End If
                    If flag Then
                        Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter_ID = consultant.SelectedClinic.ServerAssignCounter_ID
                        Me.forBizboxConsultation.ForInitialConsultation_ServerAssignCounter = consultant.SelectedClinic
                        Me.FillInitialConsultationDetail()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ClinicCountersAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClinicCountersAlertToolStripMenuItem.Click
        If Mute Then
            GoTo showBoard
        Else
            MessageBox.Show("Standalone queuing board has its own beep mechanism And may confict the beep mechanism Of this queuing. It Is `recommended To mute this queuing` so it won't conflict with the audio in standalone queuing board", "Standalone Queuing Board", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If MessageBox.Show("Do you want to mute?", "Mute", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim voiceModel As VoiceModel = VoiceSetting()
                voiceModel.Mute = True
                Mute = voiceModel.Mute
                MuteToolStripMenuItem.Checked = voiceModel.Mute
                VoiceSetting() = voiceModel
            End If
        End If
showBoard:
        If Not Application.OpenForms().OfType(Of frmCounterQueuingBoard_ClinicPCC).Any Then
            frmX.Close()
            frmX = New frmCounterQueuingBoard_ClinicPCC
            frmX.Show()
        End If
    End Sub


    Private Sub dgvDiagnosticRequestItems_SelectionChanged(sender As Object, e As EventArgs)
        'If dgvDiagnosticRequestItems.SelectedRows.Count > 0 Then
        '    If Not IsNothing(selectedBizboxTransaction) Then
        '        If Not IsNothing(selectedBizboxTransaction.PatItems_Rendered) Then
        '            Dim index As Long = dgvDiagnosticRequestItems.SelectedRows(0).Cells("dgvDiagnosticRequestItems_ID").Value
        '            Dim selectedItm As PatientBizbox_PatItems = Nothing
        '            For Each tranItem As PatientBizbox_PatItems In selectedBizboxTransaction.PatItems_Rendered
        '                If tranItem.PK_psPatItems = index Then
        '                    selectedItm = tranItem
        '                    Exit For
        '                End If
        '            Next
        '            If Not IsNothing(selectedItm) Then
        '                lblDiagnosticRequestItemsSpecialPrep.Text = selectedItm.ItemPreparation.ToUpper.Trim.ToString
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub dgvConsulationList_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvConsulationList.RowValidating

    End Sub
End Class