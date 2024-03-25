Public Class frmServiceCounter_Clinic
    Private tmpCounterName As String = ""
    Private patientList As List(Of PatientItem) = Nothing
    Private servingTime As Long = 0
    Private ServingPatient As ServedCustomer = Nothing
    Private _tmpSelectedPatient As PatientItem = Nothing
    Private latestBizboxConsultation As Bizbox_Consultation = Nothing
    Private myBizboxRequisitions As List(Of PatientBizbox_PatItems) = Nothing
    Private bizboxConsultationHistory As List(Of Bizbox_Consultation) = Nothing
    Private diagnosticResults As List(Of Diagnostics) = Nothing
    Private transferCounter_diagnosticRequest As Counter = Nothing
    Private transferCounter_prescriptionRequest As Counter = Nothing
    Private transferCounter_payment_cash As Counter = Nothing
    Private transferCounter_payment_card As Counter = Nothing
    Private transferCounter_payment_hmo As Counter = Nothing
    Private transferCounter_payment_philhealth As Counter = Nothing
    Private transferCounter_ancillary_labextraction As Counter = Nothing
    Private transferCounter_ancillary_radiology As Counter = Nothing
    Private ReadOnly doctorsHeaderLoc As String = WMMCQMSConfig.DoctorHeaderLocation()
    Private ReadOnly doctorsSignatureLoc As String = WMMCQMSConfig.DoctorSignatureLocation()

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

    Private Sub GetQueueList()
        If Not IsNothing(LoggedServer) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim queueList As List(Of CustomerAssignCounter) = customerAssignCounterController.GetListOfPatientByClinic(LoggedServer.ServerAssignCounter.Counter)
            Dim incomingQueueList As List(Of CustomerInfo) = customerAssignCounterController.GetAssignPatientToROD(LoggedServer.ServerAssignCounter.ServerAssignCounter_ID)
            flpPatientList.Controls.Clear()
            If Not IsNothing(queueList) Then
                patientList = New List(Of PatientItem)
                If cbPatientListFilter.SelectedIndex = 0 Then 'WAITING
                    For Each customer As CustomerAssignCounter In queueList
                        If IsNothing(customer.ServedCustomer) Then
                            Dim patientItem As New PatientItem(customer)
                            With patientItem
                                .BackColor = Color.AliceBlue
                                .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                                .Name = "patientList" & customer.CustomerAssignCounter_ID
                            End With
                            flpPatientList.Controls.Add(patientItem)
                            patientList.Add(patientItem)
                        ElseIf IsNothing(customer.ServedCustomer.DateTimeStart) Then
                            Dim patientItem As New PatientItem(customer)
                            With patientItem
                                .BackColor = Color.AliceBlue
                                .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                                .Name = "patientList" & customer.CustomerAssignCounter_ID
                            End With
                            flpPatientList.Controls.Add(patientItem)
                            patientList.Add(patientItem)
                        End If
                    Next
                ElseIf cbPatientListFilter.SelectedIndex = 1 Then 'COMPLETED
                    For Each customer As CustomerAssignCounter In queueList
                        If Not IsNothing(customer.ServedCustomer) Then
                            If Not IsNothing(customer.ServedCustomer.DateTimeStart) And Not IsNothing(customer.ServedCustomer.DateTimeEnd) Then
                                Dim patientItem As New PatientItem(customer)
                                With patientItem
                                    .BackColor = Color.AliceBlue
                                    .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                                    .Name = "patientList" & customer.CustomerAssignCounter_ID
                                End With
                                flpPatientList.Controls.Add(patientItem)
                                patientList.Add(patientItem)
                            End If
                        End If
                    Next
                ElseIf cbPatientListFilter.SelectedIndex = 2 Then 'ON PROCESS
                    For Each customer As CustomerAssignCounter In queueList
                        If Not IsNothing(customer.ServedCustomer) Then
                            If Not IsNothing(customer.ServedCustomer.DateTimeStart) And IsNothing(customer.ServedCustomer.DateTimeEnd) Then
                                Dim patientItem As New PatientItem(customer)
                                With patientItem
                                    .BackColor = Color.Yellow
                                    .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                                    .Name = "patientList" & customer.CustomerAssignCounter_ID
                                End With
                                flpPatientList.Controls.Add(patientItem)
                                patientList.Add(patientItem)
                            End If
                        End If
                    Next
                Else 'ALL
                    For Each customer As CustomerAssignCounter In queueList
                        Dim patientItem As New PatientItem(customer)
                        With patientItem
                            .BackColor = If(Not IsNothing(customer.ServedCustomer), If(Not IsNothing(customer.ServedCustomer.DateTimeStart) And IsNothing(customer.ServedCustomer.DateTimeEnd), Color.Yellow, Color.AliceBlue), Color.AliceBlue)
                            .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                            .Name = "patientList" & customer.CustomerAssignCounter_ID
                        End With
                        flpPatientList.Controls.Add(patientItem)
                        patientList.Add(patientItem)
                    Next
                End If
            Else
                patientList = Nothing
            End If
            If Not IsNothing(incomingQueueList) Then
                If IsNothing(patientList) Then
                    patientList = New List(Of PatientItem)
                End If
                For Each customer As CustomerInfo In incomingQueueList
                    Dim patientItem As New PatientItem(customer)
                    With patientItem
                        .BackColor = Color.LightGray
                        .Width = flpPatientList.Width - (flpPatientList.Width * 0.17)
                        .Name = "incommingPatientList" & customer.Info_ID
                    End With
                    flpPatientList.Controls.Add(patientItem)
                    patientList.Add(patientItem)
                Next
            End If
        End If
    End Sub

    Public Sub ViewPatientInfo(patient As PatientItem)
        If Not IsNothing(Me.ServingPatient) Then
            MessageBox.Show("Cannot view other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNothing(patient) Then
            _tmpSelectedPatient = Nothing
            If Not IsNothing(patientList) Then
                For Each patientItem As PatientItem In patientList
                    If Not IsNothing(patientItem.QueuedPatient) Then
                        If Not patientItem.BackColor = Color.Yellow Then
                            With patientItem
                                .BackColor = Color.AliceBlue
                            End With
                        End If
                    End If
                Next
            End If
            ViewPatientInformationtTemp(patient.IncomingPatient)
        End If
    End Sub

    Public Sub ServedDoubleClickedCustomer(ByVal patient As PatientItem)
        If Not Information.IsNothing(Me.ServingPatient) Then
            MessageBox.Show("Cannot view other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf Not Information.IsNothing(patient) Then
            Me._tmpSelectedPatient = patient
            If Not Information.IsNothing(Me.patientList) Then
                For Each item As PatientItem In Me.patientList
                    If (Not Information.IsNothing(item.QueuedPatient) AndAlso Not (item.BackColor = Color.Yellow)) Then
                        item.BackColor = Color.MintCream
                        item = Nothing
                    End If
                Next
            End If
            If Not Information.IsNothing(Me._tmpSelectedPatient) Then
                If Not Information.IsNothing(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer) Then
                    Me.ReConsultation()
                Else
                    Me.StartConsultation()
                End If
                Me.GetPatientCurrentConsultation()
                Me.GetCertainDoctorBizboxRequisions()
                Me.GetPatientConsultationHistory()
                Me.GetPatientBizboxResults()
            Else
                MessageBox.Show("Please select a patient that you want to consult", "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Public Sub SelectedPatient(patient As PatientItem)
        If Not IsNothing(Me.ServingPatient) Then
            MessageBox.Show("Cannot view other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNothing(patient) Then
            _tmpSelectedPatient = patient
            If Not IsNothing(patientList) Then
                For Each patientItem As PatientItem In patientList
                    If Not IsNothing(patientItem.QueuedPatient) Then
                        If Not patientItem.BackColor = Color.Yellow Then
                            With patientItem
                                .BackColor = Color.AliceBlue
                            End With
                        End If
                    End If
                Next
            End If
            If IsNothing(patient.QueuedPatient.ServedCustomer) Then
                btnStartCompleteConsultation.Text = "START CONSULTATION"
                btnSkip.Text = "REMOVE FROM LIST"
            ElseIf Not IsNothing(patient.QueuedPatient.ServedCustomer.DateTimeEnd) Then
                btnStartCompleteConsultation.Text = "ADDITIONAL ENTRY"
            End If
            patient.BackColor = Color.LightBlue
            gbSelectedPatient_Actions.Enabled = True
            ViewPatientInformation(patient.QueuedPatient)
        End If
    End Sub

    Private Sub UnselectAllPatient()
        If IsNothing(Me.ServingPatient) Then
            _tmpSelectedPatient = Nothing
            btnStartCompleteConsultation.Text = "START CONSULTATION"
            If Not IsNothing(patientList) Then
                For Each patientItem As PatientItem In patientList
                    If Not IsNothing(patientItem.QueuedPatient) Then
                        If Not patientItem.BackColor = Color.Yellow Then
                            With patientItem
                                .BackColor = Color.AliceBlue
                            End With
                        End If
                    End If
                Next
            End If
            If IsNothing(Me.ServingPatient) Then
                lblRefNo.Text = ""
                patient_info1.Text = ""
                patient_info2.Text = ""
                pbProfilePicture.Image = Nothing
                gbSelectedPatient_Actions.Enabled = False
            End If
        End If
    End Sub

    Private Sub ViewPatientInformation(patientInfo As CustomerAssignCounter)
        If Not IsNothing(patientInfo) Then
            Dim customer As Customer = patientInfo.Customer
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
            custPicture = If(Not IsNothing(customer.CustomerInfo.PatientPicture), customer.CustomerInfo.PatientPicture.Trim, "")
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
            If custPicture.Length > 0 Then
                Try
                    pbProfilePicture.Image = Image.FromFile(custPicture)
                Catch ex As Exception
                    pbProfilePicture.Image = Nothing
                End Try
            Else
                pbProfilePicture.Image = Nothing
            End If
            lblRefNo.Text = If(customer.CustomerInfo.FK_emdPatients > 0, customer.CustomerInfo.FK_emdPatients, "PROFILE NOT SYNC YET")
            patient_info1.Text = (custLName & Environment.NewLine & custFName & Environment.NewLine & custMName & Environment.NewLine & custAge & Environment.NewLine & custBDay).ToUpper
            patient_info2.Text = (custGender & Environment.NewLine & custCivilStatus & Environment.NewLine & custContact & Environment.NewLine & custEmail & Environment.NewLine & custStreet + " " + custBarangay + " " + custCity).ToUpper
        End If
    End Sub

    Private Sub ViewPatientInformationtTemp(patientInfo As CustomerInfo)
        If Not IsNothing(patientInfo) Then
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
            If IsNothing(patientInfo.FirstName) And IsNothing(patientInfo.Lastname) Then
                custName = "NAME NOT INDICATED"
            ElseIf (Not patientInfo.FirstName.Trim.Length > 0) And (Not patientInfo.Lastname.Trim.Length > 0) Then
                custName = "NAME NOT INDICATED"
            Else
                custName = patientInfo.Lastname.ToUpper & ", " & patientInfo.FirstName.ToUpper & " " & patientInfo.Middlename.ToUpper
                custFName = patientInfo.FirstName.ToUpper
                custMName = patientInfo.Middlename.ToUpper
                custLName = patientInfo.Lastname.ToUpper
            End If
            custPicture = If(Not IsNothing(patientInfo.PatientPicture), patientInfo.PatientPicture.Trim, "")
            Dim tmpAge = DateDiff(DateInterval.Year, patientInfo.BirthDate, Today.Date).ToString
            custBDay = Format(patientInfo.BirthDate, "MMM dd, yyyy")
            If tmpAge > 0 Then
                custAge = tmpAge.ToString
            Else
                custAge = "AGE NOT INDICATED"
            End If
            If IsNothing(patientInfo.Sex) Then
                custGender = "GENDER NOT INDICATED"
            ElseIf Not patientInfo.Sex.Trim.Length > 0 Then
                custGender = "GENDER NOT INDICATED"
            Else
                custGender = patientInfo.Sex.ToUpper
            End If
            If IsNothing(patientInfo.PhoneNumber) Then
                custContact = "CONTACT NOT INDICATED"
            ElseIf patientInfo.PhoneNumber.Length <= 0 Then
                custContact = "CONTACT NOT INDICATED"
            Else
                custContact = patientInfo.PhoneNumber.ToString
            End If
            custStreet = patientInfo.StreetDrive
            custBarangay = patientInfo.Barangay
            custCity = patientInfo.CityMunicipality
            If IsNothing(patientInfo.CivilStatus) Then
                custCivilStatus = "NOT INDICATED"
            ElseIf patientInfo.CivilStatus.Length <= 0 Then
                custCivilStatus = "NOT INDICATED"
            Else
                custCivilStatus = patientInfo.CivilStatus
            End If
            If IsNothing(patientInfo.Nationality) Then
                custNationality = "NOT INDICATED"
            ElseIf patientInfo.Nationality.Length <= 0 Then
                custNationality = "NOT INDICATED"
            Else
                custNationality = patientInfo.Nationality
            End If
            If IsNothing(patientInfo.Email) Then
                custEmail = "NOT INDICATED"
            ElseIf patientInfo.Email.Length <= 0 Then
                custEmail = "NOT INDICATED"
            Else
                custEmail = patientInfo.Email
            End If
            If custPicture.Length > 0 Then
                Try
                    pbProfilePicture.Image = Image.FromFile(custPicture)
                Catch ex As Exception
                    pbProfilePicture.Image = Nothing
                End Try
            Else
                pbProfilePicture.Image = Nothing
            End If
            lblRefNo.Text = If(patientInfo.FK_emdPatients > 0, patientInfo.FK_emdPatients, "PROFILE NOT SYNC YET")
            patient_info1.Text = (custLName & Environment.NewLine & custFName & Environment.NewLine & custMName & Environment.NewLine & custAge & Environment.NewLine & custBDay).ToUpper
            patient_info2.Text = (custGender & Environment.NewLine & custCivilStatus & Environment.NewLine & custContact & Environment.NewLine & custEmail & Environment.NewLine & custStreet + " " + custBarangay + " " + custCity).ToUpper
        End If
    End Sub

    Private Sub GetPatientConsultationHistory()
        If Not Information.IsNothing(Me.ServingPatient) Then
            Me.TabControl1.SelectedTab = Me.TabPage1
            Dim controller As New CustomerConsultationController
            Dim infoID As Long = Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
            Dim fkEmdPatient As Long = Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
            Dim num3 As Long = WMMCQMSConfig.LoggedServer.ServerAssignCounter.Server.Server_ID
            Me.bizboxConsultationHistory = controller.GetBizboxCustomerConsultations(infoID, fkEmdPatient)
            Me.dgvMedicalHistory_ConsultationList.Rows.Clear()
            If Not Information.IsNothing(Me.bizboxConsultationHistory) Then
                Dim consultation As Bizbox_Consultation
                For Each consultation In Me.bizboxConsultationHistory
                    Dim values As Object() = New Object() {consultation.ID, Strings.Format(consultation.DateCreated, "MMM dd, yyyy @ h:mm tt")}
                    Me.dgvMedicalHistory_ConsultationList.Rows.Add(values)
                    Me.dgvMedicalHistory_ConsultationList.Rows((Me.dgvMedicalHistory_ConsultationList.Rows.Count - 1)).Height = 30
                Next
            End If
        End If
    End Sub

    Private Sub ViewPatientCertainConsultationHistory_MedicalHistory(ByVal consultation As Bizbox_Consultation)
        If Not Information.IsNothing(consultation) Then
            Dim bizboxRegistration As Bizbox_PatientDailyRegistration = consultation.BizboxRegistration
            Me.lblConsultationHistory_PhysicianConsultationDate.Text = String.Concat("DR. ", bizboxRegistration.DoctorData.Lastname, ", ", bizboxRegistration.DoctorData.Firstname, " ", bizboxRegistration.DoctorData.SuffixName, ChrW(13) & ChrW(10), If(Not Information.IsNothing(bizboxRegistration.ConsultationIn), Strings.Format(bizboxRegistration.ConsultationIn.Value, "MMM dd, yyyy @ h:mm tt"), "CONSULTATION NOT STARTED"), ChrW(13) & ChrW(10), If(Not Information.IsNothing(bizboxRegistration.ConsultationOut), Strings.Format(bizboxRegistration.ConsultationOut.Value, "MMM dd, yyyy @ h:mm tt"), " "), ChrW(13) & ChrW(10), ("DR. " & consultation.ServerTransaction.ServerAssignCounter.Server.FullName.ToUpper), ChrW(13) & ChrW(10), Strings.Format(consultation.DateCreated, "MMM dd, yyyy @ h:mm tt"))
            Me.lblConsultationHistory_PhysicianConsultationDate_ConsultationType.Text = String.Concat(If(Not Information.IsNothing(bizboxRegistration.DoleEmpNo), bizboxRegistration.DoleEmpNo, "N/A"), ChrW(13) & ChrW(10), If(Not Information.IsNothing(bizboxRegistration.DoleRefNO), bizboxRegistration.DoleRefNO.Trim.ToUpper, "N/A"), ChrW(13) & ChrW(10), If(Not Information.IsNothing(bizboxRegistration.DoleAppStat), bizboxRegistration.DoleAppStat.Trim.ToUpper, "N/A"))
            Me.lblConsultationHistory_height.Text = ((bizboxRegistration.Height1) & " " & bizboxRegistration.HeightUnit)
            Me.lblConsultationHistory_weight.Text = ((bizboxRegistration.Weight) & " " & bizboxRegistration.WeightUnit)
            Me.lblConsultationHistory_Allergies.Text = ""
            Me.lblConsultationHistory_Symptoms.Text = ""
            Me.lblConsultationHistory_bp.Text = ((bizboxRegistration.Systolic) & "/" & (bizboxRegistration.Diastolic))
            Me.lblConsultationHistory_pr.Text = (bizboxRegistration.PulseRate)
            Me.lblConsultationHistory_rr.Text = (bizboxRegistration.RespiratoryRate)
            Me.lblConsultationHistory_temp.Text = ((bizboxRegistration.Temparature) & " °C")
            Me.lblConsultationHistory_o2.Text = (CDbl(0))
            Me.lblConsultationHistory_ChiefComplaints.Text = bizboxRegistration.ChiefComplaint.Trim
            Me.lblConsultationHistory_HistoryOfPresentIllness.Text = bizboxRegistration.HistoryOfPresentIllness.Trim
            Me.lblConsultationHistory_PertinentPhysicalExam.Text = bizboxRegistration.PertinentPhysicalExamination.Trim
            Me.lblConsultationHistory_WorkingDiagnosis.Text = bizboxRegistration.WorkingDiagnosis.Trim
            Me.lblConsultationHistory_FinalDiagnosis.Text = bizboxRegistration.FinalDiagnosis.Trim
            Me.lblConsultationHistory_Impression.Text = bizboxRegistration.Treatment.Trim
            Me.lblConsultationHistory_Treatment.Text = bizboxRegistration.Impression.Trim
            Me.dgvConsultationHistory_DoctorsOrderPlans.Rows.Clear()
            If Not Information.IsNothing(bizboxRegistration.Plans) Then
                Dim plan As Bizbox_ConsultationPlan
                For Each plan In bizboxRegistration.Plans
                    Me.dgvConsultationHistory_DoctorsOrderPlans.Rows.Add(plan.ID, plan.PlanGroup, plan.PlanGroupAbrev.Trim.ToUpper, plan.PlanDescription.Trim)
                    Me.dgvConsultationHistory_DoctorsOrderPlans.Rows((Me.dgvConsultationHistory_DoctorsOrderPlans.Rows.Count - 1)).Height = 30
                Next
            End If
            Me.dgvConsultationHistory_SickLeave.Rows.Clear()
            If Not Information.IsNothing(bizboxRegistration.SickLeaves) Then
                Dim leave As Bizbox_ConsultationSickLeave
                For Each leave In bizboxRegistration.SickLeaves
                    Me.dgvConsultationHistory_SickLeave.Rows.Add(leave.ID, Strings.Format(leave.StartDate, "MMM dd, yyyy @ h:mm tt"), Strings.Format(leave.EndDate, "MMM dd, yyyy @ h:mm tt"), leave.ComputedDays)
                    Me.dgvConsultationHistory_SickLeave.Rows((Me.dgvSickLeave.Rows.Count - 1)).Height = 30
                Next
            End If

            Me.dgvConsultationHistory_BizboxRequisitions.Rows.Clear()
            If Not Information.IsNothing(bizboxRegistration.Requisitions) Then
                Dim item As PatientBizbox_PatItems
                For Each item In bizboxRegistration.Requisitions
                    Me.dgvConsultationHistory_BizboxRequisitions.Rows.Add(item.PK_psPatItems, item.ItemDescription.Trim.ToUpper, item.DepartmentOfService.Trim.ToUpper, item.RequestorName.Trim.ToUpper, item.RequestPrice, item.RequestQTY)
                    Me.dgvConsultationHistory_BizboxRequisitions.Rows((Me.dgvConsultationHistory_BizboxRequisitions.Rows.Count - 1)).Height = 30
                Next
            End If

            If (Not Information.IsNothing(consultation.OPDConsent1) Or Not Information.IsNothing(consultation.OPDConsent2)) Then
                If ((consultation.OPDConsent1.Trim.Length > 0) And (consultation.OPDConsent2.Trim.Length > 0)) Then
                    Me.btnViewConsent.Enabled = True
                Else
                    Me.btnViewConsent.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub GetPatientCurrentConsultation()
        Try
            If Not Information.IsNothing(Me.ServingPatient) Then
                Me.lblPhysicianNursingAttendantConsultDate.Text = ""
                Me.lblConsultationType.Text = ""
                Me.lblHeight.Text = ""
                Me.lblWeight.Text = ""
                Me.lblAllergies.Text = ""
                Me.lblSymptoms.Text = ""
                Me.lbBP.Text = ""
                Me.lbPR.Text = ""
                Me.lbRR.Text = ""
                Me.lbTemp.Text = ""
                Me.lbO2.Text = ""
                Me.lblChiefComplaint.Text = ""
                Me.lblHistoryOfPresentIllness.Text = ""
                Me.lblPertinentPhysicalExam.Text = ""
                Me.lblWorkingDiagnosis.Text = ""
                Me.lbFinalDiagnosis.Text = ""
                Me.txtImpression.Text = ""
                Me.lbTreatment.Text = ""
                Me.latestBizboxConsultation = New CustomerConsultationController().GetLatestPatientBizboxConsultation(Me.ServingPatient)
                If Not Information.IsNothing(Me.latestBizboxConsultation) Then
                    Dim bizboxRegistration As Bizbox_PatientDailyRegistration = Me.latestBizboxConsultation.BizboxRegistration
                    Me.lblPhysicianNursingAttendantConsultDate.Text = String.Concat("DR. ", bizboxRegistration.DoctorData.Lastname, ", ", bizboxRegistration.DoctorData.Firstname, " ", bizboxRegistration.DoctorData.SuffixName,
                                                                                    ChrW(13) & ChrW(10),
                                                                                    If(Not Information.IsNothing(bizboxRegistration.ConsultationIn), Format(bizboxRegistration.ConsultationIn.Value, "MMM dd, yyyy @ h:mm tt"), "CONSULTATION NOT STARTED"),
                                                                                    ChrW(13) & ChrW(10),
                                                                                    If(Not Information.IsNothing(bizboxRegistration.ConsultationOut), Format(bizboxRegistration.ConsultationOut.Value, "MMM dd, yyyy @ h:mm tt"), ""),
                                                                                    ChrW(13) & ChrW(10),
                                                                                    Format(Me.latestBizboxConsultation.DateCreated, "MMM dd, yyyy"))
                    Me.lblConsultationType.Text = String.Concat(If(Not Information.IsNothing(bizboxRegistration.RegistrationDate), bizboxRegistration.RegistrationDate, "NO REGISTRY DATE"),
                                                                ChrW(13) & ChrW(10),
                                                                If(Not Information.IsNothing(bizboxRegistration.DoleEmpNo), bizboxRegistration.DoleEmpNo, "N/A"),
                                                                ChrW(13) & ChrW(10),
                                                                If(Not Information.IsNothing(bizboxRegistration.DoleRefNO), bizboxRegistration.DoleRefNO.Trim.ToUpper, "N/A"),
                                                                ChrW(13) & ChrW(10), If(Not Information.IsNothing(bizboxRegistration.DoleAppStat),
                                                                bizboxRegistration.DoleAppStat.Trim.ToUpper, "N/A"))
                    Me.lblHeight.Text = (bizboxRegistration.Height1 & " " & bizboxRegistration.HeightUnit).ToString
                    Me.lblWeight.Text = (bizboxRegistration.Weight & " " & bizboxRegistration.WeightUnit).ToString
                    Me.lblAllergies.Text = ""
                    Me.lblSymptoms.Text = ""
                    Me.lbBP.Text = (bizboxRegistration.Systolic & "/" & bizboxRegistration.Diastolic).ToString
                    Me.lbPR.Text = bizboxRegistration.PulseRate.ToString
                    Me.lbRR.Text = bizboxRegistration.RespiratoryRate.ToString
                    Me.lbTemp.Text = (bizboxRegistration.Temparature.ToString & " °C")
                    Me.lbO2.Text = "0.0"
                    Me.lblChiefComplaint.Text = bizboxRegistration.ChiefComplaint.Trim
                    Me.lblHistoryOfPresentIllness.Text = bizboxRegistration.HistoryOfPresentIllness.Trim
                    Me.lblPertinentPhysicalExam.Text = bizboxRegistration.PertinentPhysicalExamination.Trim
                    Me.lblWorkingDiagnosis.Text = bizboxRegistration.WorkingDiagnosis.Trim
                    Me.lbFinalDiagnosis.Text = bizboxRegistration.FinalDiagnosis.Trim
                    Me.lbTreatment.Text = bizboxRegistration.Treatment.Trim
                    Me.txtImpression.Text = bizboxRegistration.Impression.Trim
                    Me.dgvDoctorsOrderPlans.Rows.Clear()
                    If Not Information.IsNothing(bizboxRegistration.Plans) Then
                        Dim plan As Bizbox_ConsultationPlan
                        For Each plan In bizboxRegistration.Plans
                            Me.dgvDoctorsOrderPlans.Rows.Add(plan.ID, plan.PlanGroup, plan.PlanGroupAbrev.Trim.ToUpper, plan.PlanDescription.Trim)
                            Me.dgvDoctorsOrderPlans.Rows((Me.dgvDoctorsOrderPlans.Rows.Count - 1)).Height = 30
                        Next
                    End If
                    Me.dgvSickLeave.Rows.Clear()
                    If Not Information.IsNothing(bizboxRegistration.SickLeaves) Then
                        Dim leave As Bizbox_ConsultationSickLeave
                        For Each leave In bizboxRegistration.SickLeaves
                            Dim values As Object() = New Object() {leave.ID, Strings.Format(leave.StartDate, "MMM dd, yyyy @ h:mm tt"), Strings.Format(leave.EndDate, "MMM dd, yyyy @ h:mm tt"), leave.ComputedDays}
                            Me.dgvSickLeave.Rows.Add(values)
                            Me.dgvSickLeave.Rows((Me.dgvSickLeave.Rows.Count - 1)).Height = 30
                        Next
                    End If
                    If (Not Information.IsNothing(Me.latestBizboxConsultation.OPDConsent1) Or Not Information.IsNothing(Me.latestBizboxConsultation.OPDConsent2)) Then
                        If ((Me.latestBizboxConsultation.OPDConsent1.Trim.Length > 0) And (Me.latestBizboxConsultation.OPDConsent2.Trim.Length > 0)) Then
                            Me.btnViewConsent.Enabled = True
                        Else
                            Me.btnViewConsent.Enabled = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function AutoSendPrescriptionsToMedExpress() As Boolean
        Return False
    End Function

    Private Function AutoGenerateQueueNumber_DiagnosticRequest() As String
        If ((Not Information.IsNothing(Me.latestBizboxConsultation) AndAlso Not Information.IsNothing(Me.transferCounter_diagnosticRequest)) AndAlso (Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration) AndAlso Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration.Plans))) Then
            Dim flag As Boolean = False
            Dim plan As Bizbox_ConsultationPlan
            For Each plan In Me.latestBizboxConsultation.BizboxRegistration.Plans
                If ((plan.PlanGroup.Trim.ToUpper = "EXM") Or (plan.PlanGroup.Trim.ToUpper = "PRC")) Then
                    flag = True
                End If
            Next
            If flag Then
                Dim controller As New CustomerAssignCounterController
                Dim forTransferPatient As New CustomerAssignCounter With {
                    .Counter = Me.transferCounter_diagnosticRequest,
                    .Customer = Me.ServingPatient.CustomerAssignCounter.Customer,
                    .Priority = 0,
                    .Notes = Nothing,
                    .PaymentMethod = 0,
                    .NoteDepartment = Nothing,
                    .NoteSection = Nothing
                }
                Return controller.TransferPatient(forTransferPatient)
            End If
        End If
        Return Nothing
    End Function

    Private Function AutoGenerateQueueNumber_Prescriptions() As String
        If ((Not Information.IsNothing(Me.latestBizboxConsultation) AndAlso Not Information.IsNothing(Me.transferCounter_prescriptionRequest)) AndAlso (Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration) AndAlso Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration.Plans))) Then
            Dim flag As Boolean = False
            Dim plan As Bizbox_ConsultationPlan
            For Each plan In Me.latestBizboxConsultation.BizboxRegistration.Plans
                If (plan.PlanGroup.Trim.ToUpper = "MED") Then
                    flag = True
                End If
            Next
            If flag Then
                Dim controller As New CustomerAssignCounterController
                Dim forTransferPatient As New CustomerAssignCounter With {
                    .Counter = Me.transferCounter_prescriptionRequest,
                    .Customer = Me.ServingPatient.CustomerAssignCounter.Customer,
                    .Priority = 0,
                    .Notes = Nothing,
                    .PaymentMethod = 0,
                    .NoteDepartment = Nothing,
                    .NoteSection = Nothing
                }
                Return controller.TransferPatient(forTransferPatient)
            End If
        End If
        Return Nothing
    End Function

    Private Function AutoGenerateQueueNumber_Laboratory() As String
        If ((Not Information.IsNothing(Me.latestBizboxConsultation) AndAlso Not Information.IsNothing(Me.transferCounter_ancillary_labextraction)) AndAlso (Not Information.IsNothing(Me.myBizboxRequisitions))) Then
            Dim flag As Boolean = False
            For Each req In Me.myBizboxRequisitions
                'Checks if any of the request is from Laboratory warehouse
                If (req.DepartmentCode.Trim.ToUpper = "1004") Then
                    flag = True
                End If
            Next
            If flag Then
                Dim controller As New CustomerAssignCounterController
                Dim forTransferPatient As New CustomerAssignCounter With {
                    .Counter = Me.transferCounter_ancillary_labextraction,
                    .Customer = Me.ServingPatient.CustomerAssignCounter.Customer,
                    .Priority = 0,
                    .Notes = Nothing,
                    .PaymentMethod = 0,
                    .NoteDepartment = Nothing,
                    .NoteSection = Nothing
                }
                Return controller.TransferPatient(forTransferPatient)
            End If
        End If
        Return Nothing
    End Function

    Private Function AutoGenerateQueueNumber_Radiology() As String
        If ((Not Information.IsNothing(Me.latestBizboxConsultation) AndAlso Not Information.IsNothing(Me.transferCounter_ancillary_radiology)) AndAlso (Not Information.IsNothing(Me.myBizboxRequisitions))) Then
            Dim flag As Boolean = False
            For Each req In Me.myBizboxRequisitions
                'Checks if any of the request is from Radiology warehouse
                If (req.DepartmentCode.Trim.ToUpper = "1005") Then
                    flag = True
                End If
            Next
            If flag Then
                Dim controller As New CustomerAssignCounterController
                Dim forTransferPatient As New CustomerAssignCounter With {
                    .Counter = Me.transferCounter_ancillary_radiology,
                    .Customer = Me.ServingPatient.CustomerAssignCounter.Customer,
                    .Priority = 0,
                    .Notes = Nothing,
                    .PaymentMethod = 0,
                    .NoteDepartment = Nothing,
                    .NoteSection = Nothing
                }
                Return controller.TransferPatient(forTransferPatient)
            End If
        End If
        Return Nothing
    End Function

    Private Sub GetPatientBizboxResults()
        Me.dgvBizboxResults.Rows.Clear()
        If (Not Information.IsNothing(Me.ServingPatient) AndAlso (Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0)) Then
            Me.diagnosticResults = New APIController().GetCertainPatientDiagnosticResults(Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
            If Not Information.IsNothing(Me.diagnosticResults) Then
                Dim diagnostics As Diagnostics
                For Each diagnostics In Me.diagnosticResults
                    Dim values As Object() = New Object() {diagnostics.PK_psExamResultMstr, diagnostics.Diagnostics, diagnostics.ItemDescription, If(Not Information.IsNothing(diagnostics.ResultReportLink), "AVAILABLE", "None"), diagnostics.ResultReportLink, diagnostics.DiagnosticDate, diagnostics.ResultDate}
                    Me.dgvBizboxResults.Rows.Add(values)
                    Me.dgvBizboxResults.Rows((Me.dgvBizboxResults.Rows.Count - 1)).Height = 30
                Next
            End If
        End If
    End Sub

    Private Sub GetCertainDoctorBizboxRequisions()
        If Not Information.IsNothing(Me.ServingPatient) Then
            If Not Information.IsNothing(Me.latestBizboxConsultation) Then
                Me.dgvBizboxRequisitions.Rows.Clear()
                Dim registryID As Long = Me.latestBizboxConsultation.BizboxRegistration.ID
                Dim prc As String = LoggedServer.ServerAssignCounter.Server.PRC   'Me.latestBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.PRC
                Me.myBizboxRequisitions = New BizboxAPI().GetPatientConsultationRequisitions(registryID, prc)
                If Not IsNothing(Me.myBizboxRequisitions) Then
                    For Each request As PatientBizbox_PatItems In Me.myBizboxRequisitions
                        Me.dgvBizboxRequisitions.Rows.Add(request.PK_psPatItems, request.ItemDescription.Trim.ToUpper, request.DepartmentOfService.Trim.ToUpper, request.RequestPrice, request.RequestQTY)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub CompleteConsultation()
        If Not Information.IsNothing(Me.ServingPatient) Then
            If Not Information.IsNothing(Me.ServingPatient.DateTimeEnd) Then
                If (MessageBox.Show("Do you want to save all changes made on this consultation?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Dim frmIsDOle As New frmSelectDoleNonDole()
                    frmIsDOle.ShowDialog(Me)
                    If frmIsDOle.DialogResult = DialogResult.Yes Then 'Dole Patient Directly Transfer
                        Dim anlrLabQueueNumber As String = Me.AutoGenerateQueueNumber_Laboratory
                        Dim anlrRadQueueNumber As String = Me.AutoGenerateQueueNumber_Radiology
                        Dim dxQueueNumber As String = If((Not IsNothing(anlrLabQueueNumber) AndAlso Not (anlrLabQueueNumber.Trim.Length > 0)) And (Not IsNothing(anlrRadQueueNumber) AndAlso Not (anlrRadQueueNumber.Trim.Length > 0)), Me.AutoGenerateQueueNumber_DiagnosticRequest, "") 'If doctor has some requisition, no need to transfer to  dx encoder. 
                        If (Not Information.IsNothing(anlrLabQueueNumber) AndAlso (anlrLabQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO LABORATORY"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE LABORATORY"
                            Dim ticketNumber As String = anlrLabQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
                        If (Not Information.IsNothing(anlrRadQueueNumber) AndAlso (anlrRadQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO RADIOLOGY"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE RADIOLOGY"
                            Dim ticketNumber As String = anlrRadQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
                        If (Not Information.IsNothing(dxQueueNumber) AndAlso (dxQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO OPD DIAGNOSTICS"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE OPD DIAGNOSTICS"
                            Dim ticketNumber As String = dxQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
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
                                transferedCustomerAssignCounter.Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                                transferedCustomerAssignCounter.Priority = 0
                                transferedCustomerAssignCounter.Notes = frm.NotesAndRemaks
                                transferedCustomerAssignCounter.PaymentMethod = frm.PaymentMethod
                                transferedCustomerAssignCounter.NoteDepartment = ""
                                transferedCustomerAssignCounter.NoteSection = ""
                                Dim generatedNumber As String = customerAssignCounterController.TransferPatient(transferedCustomerAssignCounter)
                                If Not IsNothing(generatedNumber) Then
                                    If generatedNumber.Trim.Length > 0 Then
                                        Dim patient As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
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
                                        Dim frmGenerated As New frmNoGenerated(queueNumber, patientName, counter, notes)
                                        frmGenerated.ShowDialog()
                                    End If
                                End If
                            End If
                        End If
                    End If
                    Dim rxQueueNumber As String = Me.AutoGenerateQueueNumber_Prescriptions
                    If (Not Information.IsNothing(rxQueueNumber) AndAlso (rxQueueNumber.Trim.Length > 0)) Then
                        Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                        Dim patientName As String = ""
                        Dim counterName As String = "PLEASE GO TO PHARMACY"
                        Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR PHARMACY."
                        Dim ticketNumber As String = rxQueueNumber
                        If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                            patientName = "NAME NOT INDICATED"
                        ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                            patientName = "NAME NOT INDICATED"
                        Else
                            patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                        End If
                        Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                        frm.ShowDialog()
                    End If
                    Me.pnlConsultation_Blocker1.Show()
                    Me.pnlConsultation_Blocker2.Show()
                    Me.pnlConsultation_Blocker3.Show()
                    Me.btnViewPatientCharts.Hide()
                    Me.pnlPatientCharts.Hide()
                    Me.pnlMedHistory_PatientCharts.Hide()
                    Me.lblRefNo.Text = ""
                    Me.patient_info1.Text = ""
                    Me.patient_info2.Text = ""
                    Me.pbProfilePicture.Image = Nothing
                    Me.btnSkip.Text = "REMOVE FROM LIST"
                    Me.btnStartCompleteConsultation.Text = "START CONSULTATION"
                    Me.btnStartCompleteConsultation.BackColor = Color.LimeGreen
                    Me.lbcountername.Text = WMMCQMSConfig.LoggedServer.CounterName
                    Me.ServingPatient = Nothing
                    Me._tmpSelectedPatient = Nothing
                    Me.GetQueueList()
                    MessageBox.Show("All changes saved. You may now consult new patient.", "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            ElseIf MessageBox.Show("Are you sure to complete this patient consultation?", "Complete Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim controller As New ServedCustomerController
                If controller.UpdateServedCustomerServeTime(Me.ServingPatient) Then
                    Dim frmIsDOle As New frmSelectDoleNonDole()
                    frmIsDOle.ShowDialog(Me)
                    If frmIsDOle.DialogResult = DialogResult.Yes Then 'Dole Patient Directly Transfer
                        Dim anlrLabQueueNumber As String = Me.AutoGenerateQueueNumber_Laboratory
                        Dim anlrRadQueueNumber As String = Me.AutoGenerateQueueNumber_Radiology
                        Dim dxQueueNumber As String = If((Not IsNothing(anlrLabQueueNumber) AndAlso Not (anlrLabQueueNumber.Trim.Length > 0)) And (Not IsNothing(anlrRadQueueNumber) AndAlso Not (anlrRadQueueNumber.Trim.Length > 0)), Me.AutoGenerateQueueNumber_DiagnosticRequest, "") 'If doctor has some requisition, no need to transfer to  dx encoder. 
                        If (Not Information.IsNothing(anlrLabQueueNumber) AndAlso (anlrLabQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO LABORATORY"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE LABORATORY"
                            Dim ticketNumber As String = anlrLabQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
                        If (Not Information.IsNothing(anlrRadQueueNumber) AndAlso (anlrRadQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO RADIOLOGY"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE RADIOLOGY"
                            Dim ticketNumber As String = anlrRadQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
                        If (Not Information.IsNothing(dxQueueNumber) AndAlso (dxQueueNumber.Trim.Length > 0)) Then
                            Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                            Dim patientName As String = ""
                            Dim counterName As String = "PLEASE GO TO OPD DIAGNOSTICS"
                            Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR THE OPD DIAGNOSTICS"
                            Dim ticketNumber As String = dxQueueNumber
                            If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                                patientName = "NAME NOT INDICATED"
                            ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                                patientName = "NAME NOT INDICATED"
                            Else
                                patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                            End If
                            Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                            frm.ShowDialog()
                        End If
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
                                transferedCustomerAssignCounter.Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                                transferedCustomerAssignCounter.Priority = 0
                                transferedCustomerAssignCounter.Notes = frm.NotesAndRemaks
                                transferedCustomerAssignCounter.PaymentMethod = frm.PaymentMethod
                                transferedCustomerAssignCounter.NoteDepartment = ""
                                transferedCustomerAssignCounter.NoteSection = ""
                                Dim generatedNumber As String = customerAssignCounterController.TransferPatient(transferedCustomerAssignCounter)
                                If Not IsNothing(generatedNumber) Then
                                    If generatedNumber.Trim.Length > 0 Then
                                        Dim patient As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
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
                                        Dim frmGenerated As New frmNoGenerated(queueNumber, patientName, counter, notes)
                                        frmGenerated.ShowDialog()
                                    End If
                                End If
                            End If
                        End If
                    End If
                    Dim rxQueueNumber As String = Me.AutoGenerateQueueNumber_Prescriptions
                    If (Not Information.IsNothing(rxQueueNumber) AndAlso (rxQueueNumber.Trim.Length > 0)) Then
                        Dim customer As Customer = Me.ServingPatient.CustomerAssignCounter.Customer
                        Dim patientName As String = ""
                        Dim counterName As String = "PLEASE GO TO PHARMACY"
                        Dim notes As String = "THIS IS YOUR REQUEST NUMBER FOR PHARMACY."
                        Dim ticketNumber As String = rxQueueNumber
                        If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                            patientName = "NAME NOT INDICATED"
                        ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                            patientName = "NAME NOT INDICATED"
                        Else
                            patientName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                        End If
                        Dim frm As New frmNoGenerated(ticketNumber, patientName, counterName, notes)
                        frm.ShowDialog()
                    End If
                    Me.pnlConsultation_Blocker1.Show()
                    Me.pnlConsultation_Blocker2.Show()
                    Me.pnlConsultation_Blocker3.Show()
                    Me.btnViewPatientCharts.Hide()
                    Me.pnlPatientCharts.Hide()
                    Me.pnlMedHistory_PatientCharts.Hide()
                    Me.lblRefNo.Text = ""
                    Me.patient_info1.Text = ""
                    Me.patient_info2.Text = ""
                    Me.pbProfilePicture.Image = Nothing
                    Me.btnSkip.Text = "REMOVE FROM LIST"
                    Me.btnStartCompleteConsultation.Text = "START CONSULTATION"
                    Me.btnStartCompleteConsultation.BackColor = Color.LimeGreen
                    Me.lbcountername.Text = WMMCQMSConfig.LoggedServer.CounterName
                    Me.ServingPatient = Nothing
                    Me._tmpSelectedPatient = Nothing
                    Me.GetQueueList()
                    MessageBox.Show("Consultation completed. You may now consult new patient.", "Consultation Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("Something went wrong on the process. Please try again", "Serving Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        End If
    End Sub

    Private Sub ReConsultation()
        If Not Information.IsNothing(Me._tmpSelectedPatient) Then
            If Not Information.IsNothing(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer.DateTimeEnd) Then
                MessageBox.Show("This patient consultation was already completed", "Completed Consult", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If (MessageBox.Show("Do you want to make additional entry", "Additional Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Dim reconsultPatient As ServedCustomer = New ServedCustomerController().GetCertainPatient_AdditionalData(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer.ServedCustomer_ID)
                    If Not Information.IsNothing(reconsultPatient) Then
                        reconsultPatient.ServerTransaction_ID = WMMCQMSConfig.LoggedServer.ServerTransaction_ID
                        Me.ServingPatient = reconsultPatient
                        Me._tmpSelectedPatient = Nothing
                        Me.pnlConsultation_Blocker1.Hide()
                        Me.pnlConsultation_Blocker2.Hide()
                        Me.pnlConsultation_Blocker3.Hide()
                        Me.btnViewPatientCharts.Show()
                        Me.btnSkip.Text = "HOLD CONSULTATION"
                        Me.btnStartCompleteConsultation.Text = "SAVE ADDITIONAL ENTRY"
                        Me.btnStartCompleteConsultation.BackColor = Color.Green
                        Me.lbcountername.Text = (WMMCQMSConfig.LoggedServer.CounterName & " : " & Me.ServingPatient.CustomerAssignCounter.ProcessedQueueNumber)
                    Else
                        Me.ServingPatient = Nothing
                        MessageBox.Show("Something went wrong during the process. Please try againg later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    Me.GetQueueList()
                End If
            ElseIf Not Information.IsNothing(Me.ServingPatient) Then
                MessageBox.Show("Cannot consult other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            ElseIf (MessageBox.Show(("Do you want to start consulting: " & Me._tmpSelectedPatient.QueuedPatient.ProcessedQueueNumber & "?"), "Start Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim controller As New ServedCustomerController
                Dim certainSkippedCustomer As ServedCustomer = controller.GetCertainSkippedCustomer(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer.ServedCustomer_ID)
                If Not Information.IsNothing(certainSkippedCustomer) Then
                    certainSkippedCustomer.ServerTransaction_ID = WMMCQMSConfig.LoggedServer.ServerTransaction_ID
                    If controller.UpdateSkippedCustomeraServetimeStart(certainSkippedCustomer) Then
                        Me.ServingPatient = certainSkippedCustomer
                        Me._tmpSelectedPatient = Nothing
                        Me.pnlConsultation_Blocker1.Hide()
                        Me.pnlConsultation_Blocker2.Hide()
                        Me.pnlConsultation_Blocker3.Hide()
                        Me.btnViewPatientCharts.Show()
                        Me.btnSkip.Text = "HOLD CONSULTATION"
                        Me.btnStartCompleteConsultation.Text = "COMPLETE CONSULTATION"
                        Me.btnStartCompleteConsultation.BackColor = Color.Green
                        Me.lbcountername.Text = (WMMCQMSConfig.LoggedServer.CounterName & " : " & Me.ServingPatient.CustomerAssignCounter.ProcessedQueueNumber)
                    Else
                        Me.ServingPatient = Nothing
                        MessageBox.Show("Something went wrong during the process. Please try againg later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                End If
                Me.GetQueueList()
            End If
        End If
    End Sub

    Private Sub StartConsultation()
        If Not Information.IsNothing(Me._tmpSelectedPatient) Then
            If Not Information.IsNothing(Me.ServingPatient) Then
                MessageBox.Show("Cannot consult other patient while there's an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            ElseIf (MessageBox.Show(("Do you want to start consulting: " & Me._tmpSelectedPatient.QueuedPatient.ProcessedQueueNumber & "?"), "Start Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim servedCustomer As New ServedCustomer
                Dim controller As New CustomerAssignCounterController
                servedCustomer.ServerTransaction = WMMCQMSConfig.LoggedServer
                servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = Me._tmpSelectedPatient.QueuedPatient.CustomerAssignCounter_ID
                servedCustomer.CustomerAssignCounter.Counter = Me._tmpSelectedPatient.QueuedPatient.Counter
                servedCustomer = controller.GetNextNumber(servedCustomer)
                If Not Information.IsNothing(servedCustomer) Then
                    If (servedCustomer.ServedCustomer_ID > 0) Then
                        Me.ServingPatient = servedCustomer
                        Me._tmpSelectedPatient = Nothing
                        Me.pnlConsultation_Blocker1.Hide()
                        Me.pnlConsultation_Blocker2.Hide()
                        Me.pnlConsultation_Blocker3.Hide()
                        Me.btnViewPatientCharts.Show()
                        Me.btnSkip.Text = "HOLD CONSULTATION"
                        Me.btnStartCompleteConsultation.Text = "COMPLETE CONSULTATION"
                        Me.btnStartCompleteConsultation.BackColor = Color.Green
                        Me.lbcountername.Text = (WMMCQMSConfig.LoggedServer.CounterName & " : " & Me.ServingPatient.CustomerAssignCounter.ProcessedQueueNumber)
                    Else
                        Me.ServingPatient = Nothing
                        Me._tmpSelectedPatient = Nothing
                        Me.pnlConsultation_Blocker1.Show()
                        Me.pnlConsultation_Blocker2.Show()
                        Me.pnlConsultation_Blocker3.Hide()
                        Me.btnViewPatientCharts.Hide()
                        Me.pnlPatientCharts.Hide()
                        Me.pnlMedHistory_PatientCharts.Hide()
                        Me.btnSkip.Text = "REMOVE FROM LIST"
                        Me.btnStartCompleteConsultation.Text = "START CONSULTATION"
                        Me.btnStartCompleteConsultation.BackColor = Color.LimeGreen
                        Me.lbcountername.Text = WMMCQMSConfig.LoggedServer.CounterName
                        MessageBox.Show("Patient is not on the list. Please try other Customer.", "No Patient", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If
                    Me.GetQueueList()
                Else
                    Me.ServingPatient = Nothing
                    MessageBox.Show("Something went wrong during the process. Please try againg later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        Else
            MessageBox.Show("Please select a patient to start consultation", "No Selected Patient", MessageBoxButtons.OK, MessageBoxIcon.Hand)
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

    Private Function CheckIfPatientAlreadyQueued(customerInfo As CustomerInfo) As Boolean
        If Not IsNothing(patientList) Then
            Dim foundDuplicate As Boolean = False
            Dim foundAtIncoming As Boolean = False
            For Each patientInfo As PatientItem In patientList
                If Not IsNothing(patientInfo.QueuedPatient) Then
                    If customerInfo.Info_ID = patientInfo.QueuedPatient.Customer.CustomerInfo.Info_ID Or customerInfo.FK_emdPatients = patientInfo.QueuedPatient.Customer.CustomerInfo.FK_emdPatients Then
                        foundDuplicate = True
                        Exit For
                    End If
                    If (patientInfo.QueuedPatient.Customer.CustomerInfo.FirstName.Trim.Contains(customerInfo.FirstName.Trim) Or patientInfo.QueuedPatient.Customer.CustomerInfo.Lastname.Trim.Contains(customerInfo.Lastname.Trim) Or patientInfo.QueuedPatient.Customer.CustomerInfo.Middlename.Trim.Contains(customerInfo.Middlename.Trim)) And patientInfo.QueuedPatient.Customer.CustomerInfo.BirthDate = customerInfo.BirthDate Then
                        foundDuplicate = True
                        Exit For
                    End If
                ElseIf Not IsNothing(patientInfo.IncomingPatient) Then
                    If customerInfo.Info_ID = patientInfo.IncomingPatient.Info_ID Or customerInfo.FK_emdPatients = patientInfo.IncomingPatient.FK_emdPatients Then
                        foundAtIncoming = True
                        Exit For
                    End If
                    If (patientInfo.IncomingPatient.FirstName.Trim.Contains(customerInfo.FirstName.Trim) Or patientInfo.IncomingPatient.Lastname.Trim.Contains(customerInfo.Lastname.Trim) Or patientInfo.IncomingPatient.Middlename.Trim.Contains(customerInfo.Middlename.Trim)) And patientInfo.IncomingPatient.BirthDate = customerInfo.BirthDate Then
                        foundAtIncoming = True
                        Exit For
                    End If
                End If
            Next
            Return (foundDuplicate Or foundAtIncoming)
        End If
        Return False
    End Function

    Private Sub RegisterConsultation()
        Dim customerInfo As CustomerInfo = CustomerLookup()
        If Not IsNothing(customerInfo) Then
            If CheckIfPatientAlreadyQueued(customerInfo) Then
                MessageBox.Show("This Patient has the same entry as the patient in the waiting list or in the incoming list .", "Duplicate Entry Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If Not MessageBox.Show("Do you want to continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Exit Sub
                End If
            End If
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
                Dim notes As String = "THIS IS YOUR APPOINTMENT NUMBER FOR CLINIC OF DR." & LoggedServer.ServerAssignCounter.Server.LastName
                Dim frm As New frmNoGenerated(generatedNumber, patientName, counter, notes)
                frm.ShowDialog()
            Else
                MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub GotoDiagnosticResult(link As String)
        Try
            Dim urlLink = New Uri(link).LocalPath
            If System.IO.File.Exists(urlLink) Then
                Dim fileInfo As New IO.FileInfo(urlLink)
                Dim fileExtn As String = (fileInfo.Extension).ToUpper.Trim
                If fileExtn.Contains("PDF") Then
                    Dim diagnosticResults As New List(Of String)
                    With diagnosticResults
                        .Add(urlLink)
                    End With
                    Dim frm As New frmPDFResultViewer(diagnosticResults)
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

    Private Sub frmServiceCounter_Clinic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LoggedServer.ServerAssignCounter.Counter.CounterType = 1 And LoggedServer.ServerAssignCounter.Counter.CounterType = 5 Then 'MAB CLINIC / ER CLINICS
            btnRegisterPatient.BackColor = Color.RoyalBlue
            btnRegisterPatient.Enabled = True
        ElseIf LoggedServer.ServerAssignCounter.Counter.CounterType = 2 Or LoggedServer.ServerAssignCounter.Counter.CounterType = 3 Or LoggedServer.ServerAssignCounter.Counter.CounterType = 4 Then 'PCC CLINIC / PCC HYBRID / MAB HYBRID 
            btnRegisterPatient.BackColor = Color.DarkGray
            btnRegisterPatient.Enabled = False
        End If
        renameCounter(False)
        tmpCounterName = LoggedServer.CounterName
        lbcountername.Text = tmpCounterName
        lblLoggedDoctor_Name.Text = LoggedServer.ServerAssignCounter.Server.FullName.ToUpper.Trim
        cbPatientListFilter.SelectedIndex = 0
        Dim counterController As New CounterController
        transferCounter_diagnosticRequest = counterController.GetDiagnosticAutoTransfer()
        transferCounter_prescriptionRequest = counterController.GetPrescriptionAutoTransfer()
        transferCounter_payment_cash = counterController.GetPaymentAutoTransfer_Cash()
        transferCounter_payment_card = counterController.GetPaymentAutoTransfer_Card()
        transferCounter_payment_hmo = counterController.GetPaymentAutoTransfer_HMO()
        transferCounter_payment_philhealth = counterController.GetPaymentAutoTransfer_PHIC()
        transferCounter_ancillary_labextraction = counterController.GetAncillaryAutoTransfer_LabExtraction()
        transferCounter_ancillary_radiology = counterController.GetAncillaryAutoTransfer_Radiology()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Not IsNothing(Me.ServingPatient) Then
            MessageBox.Show("There's still an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim result As DialogResult = MessageBox.Show("Do you want to complete the consultation before you logout?", "Mark and Change Counter", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingPatient) Then
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
        If Not IsNothing(Me.ServingPatient) Then
            MessageBox.Show("There's still an ongoing consultation", "Ongoing Consultation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim result As DialogResult = MessageBox.Show("Do you want to complete the consultation before you logout?", "Mark and Change Counter", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim servedCustomerController As New ServedCustomerController
                If servedCustomerController.UpdateServedCustomerServeTime(Me.ServingPatient) Then
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

    Private Sub btnStartConsultation_Click(sender As Object, e As EventArgs) Handles btnStartCompleteConsultation.Click
        If Not Information.IsNothing(Me.ServingPatient) Then
            Me.CompleteConsultation()
        ElseIf Not Information.IsNothing(Me._tmpSelectedPatient) Then
            If Not Information.IsNothing(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer) Then
                Me.ReConsultation()
            Else
                Me.StartConsultation()
            End If
            Me.GetPatientCurrentConsultation()
            Me.GetCertainDoctorBizboxRequisions()
            Me.GetPatientConsultationHistory()
            Me.GetPatientBizboxResults()
        Else
            MessageBox.Show("Please select a patient that you want to consult", "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub flpPatientList_Click(sender As Object, e As EventArgs) Handles flpPatientList.Click
        UnselectAllPatient()
    End Sub

    Private Sub btnSkip_Click(sender As Object, e As EventArgs) Handles btnSkip.Click
        If Not Information.IsNothing(Me.ServingPatient) Then
            MessageBox.Show("If you hold this consultation, you may reconsult it again if you want.", "Cancel Consultation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If (MessageBox.Show("Are you sure to hold current consultation?", "Cancel Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim controller As New ServerTransactionController
                If controller.UnserveAllCustomerOfCertainServerIfSkipped(WMMCQMSConfig.LoggedServer) Then
                    Me.ServingPatient = Nothing
                    Me._tmpSelectedPatient = Nothing
                    Me.pnlConsultation_Blocker1.Show()
                    Me.pnlConsultation_Blocker2.Show()
                    Me.pnlConsultation_Blocker3.Show()
                    Me.btnViewPatientCharts.Hide()
                    Me.pnlPatientCharts.Hide()
                    Me.pnlMedHistory_PatientCharts.Hide()
                    Me.lblRefNo.Text = ""
                    Me.patient_info1.Text = ""
                    Me.patient_info2.Text = ""
                    Me.pbProfilePicture.Image = Nothing
                    Me.btnSkip.Text = "REMOVE FROM LIST"
                    Me.btnStartCompleteConsultation.Text = "START CONSULTATION"
                    Me.btnStartCompleteConsultation.BackColor = Color.LimeGreen
                    Me.lbcountername.Text = WMMCQMSConfig.LoggedServer.CounterName
                    Me.GetQueueList()
                End If
            End If
        ElseIf Not Information.IsNothing(Me._tmpSelectedPatient) Then
            Dim flag As Boolean = False
            If Information.IsNothing(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer) Then
                flag = True
            ElseIf Information.IsNothing(Me._tmpSelectedPatient.QueuedPatient.ServedCustomer.DateTimeEnd) Then
                flag = True
            End If
            If flag Then
                MessageBox.Show("Removing patient from the list will also remove the current consultation have given and this action can't be undone.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If (MessageBox.Show(("Are you sure to remove: " & Me._tmpSelectedPatient.QueuedPatient.ProcessedQueueNumber & " to the list?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Dim controller As New CustomerAssignCounterController
                    If controller.DeleteCustomerAssignCounter(Me._tmpSelectedPatient.QueuedPatient.CustomerAssignCounter_ID) Then
                        Me.ServingPatient = Nothing
                        Me._tmpSelectedPatient = Nothing
                        Me.pnlConsultation_Blocker1.Show()
                        Me.pnlConsultation_Blocker2.Show()
                        Me.pnlConsultation_Blocker3.Show()
                        Me.btnViewPatientCharts.Hide()
                        Me.pnlPatientCharts.Hide()
                        Me.pnlMedHistory_PatientCharts.Hide()
                        Me.btnSkip.Text = "REMOVE FROM LIST"
                        Me.btnStartCompleteConsultation.Text = "START CONSULTATION"
                        Me.btnStartCompleteConsultation.BackColor = Color.LimeGreen
                        Me.lbcountername.Text = WMMCQMSConfig.LoggedServer.CounterName
                        Me.GetQueueList()
                    End If
                End If
            Else
                MessageBox.Show("You cannot remove patient when you already click START CONSULTATION atleast once.", "Cannot Remove", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub cbPatientListFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPatientListFilter.SelectedIndexChanged
        GetQueueList()
    End Sub

    Private Sub dgvMedicalHistory_ConsultationList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicalHistory_ConsultationList.CellContentClick

    End Sub

    Private Sub dgvMedicalHistory_ConsultationList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMedicalHistory_ConsultationList.SelectionChanged
        If ((Me.dgvMedicalHistory_ConsultationList.SelectedRows.Count > 0) AndAlso Not Information.IsNothing(Me.bizboxConsultationHistory)) Then
            Dim num As Long = (Me.dgvMedicalHistory_ConsultationList.SelectedRows(0).Cells("consultationHIstory_ID").Value)
            Dim selectedConsulation As Bizbox_Consultation = Nothing
            For Each consultation As Bizbox_Consultation In Me.bizboxConsultationHistory
                If (consultation.ID = num) Then
                    selectedConsulation = consultation
                    Exit For
                End If
            Next
            If Not IsNothing(selectedConsulation) Then
                Me.ViewPatientCertainConsultationHistory_MedicalHistory(selectedConsulation)
            End If
        End If
    End Sub

    Private Sub btnRegisterPatient_Click(sender As Object, e As EventArgs) Handles btnRegisterPatient.Click
        GetQueueList()
        MessageBox.Show("Note: Before you register new patient, make sure that the patient was not yet on the queue list or the consultation will be recreated.", "Avoid Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        RegisterConsultation()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not IsNothing(Me.ServingPatient) Then
            If dgvBizboxResults.SelectedRows.Count > 0 Then
                Dim fileLink As String = dgvBizboxResults.SelectedRows(0).Cells("resultDiagnosticLink").Value
                If IsNothing(fileLink) Then
                    MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf fileLink.ToString.Trim.Length <= 0 Then
                    MessageBox.Show("This diagnostics doesn't have any file of the result", "No Result File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    GotoDiagnosticResult(fileLink)
                End If
            End If
        End If
    End Sub

    Private Sub pbRefreshList_Click(sender As Object, e As EventArgs) Handles pbRefreshList.Click
        Me.GetQueueList()
        Me.GetPatientCurrentConsultation()
        Me.GetCertainDoctorBizboxRequisions()
        Me.GetPatientConsultationHistory()
        Me.GetPatientBizboxResults()
    End Sub

    Private Sub pbProfilePicture_Click(sender As Object, e As EventArgs) Handles pbProfilePicture.Click
        If Not IsNothing(pbProfilePicture.Image) Then
            Dim frm As New frmViewPicture(pbProfilePicture.Image)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub lbcountername_DoubleClick(sender As Object, e As EventArgs) Handles lbcountername.DoubleClick
        renameCounter(True)
    End Sub

    Private Sub btnEditPatientInfo_Click(sender As Object, e As EventArgs) Handles btnEditPatientInfo.Click
        If Not IsNothing(Me.ServingPatient) Then
            Dim wantEdit As Boolean = False
            If Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0 Then
                MessageBox.Show("This patient information was already sync before. Any modification will cause a difference of data.", "Edit Not Recommended", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Do you still want to edit this patient information?", "Edit Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    wantEdit = True
                End If
            Else
                wantEdit = True
            End If
            If wantEdit Then
                Dim frmProfiling As New frmPatientProfiling(Me.ServingPatient.CustomerAssignCounter.Customer.CustomerInfo, True, False, False)
                frmProfiling.ShowDialog(Me)
                If frmProfiling.DialogResult = DialogResult.Yes Then
                    If Not IsNothing(frmProfiling.CustomerProfile) Then
                        Dim customerInfoController As New CustomerInfoController
                        Dim newServingCustomer As ServedCustomer = customerInfoController.EditCustomerInfo(Me.ServingPatient, frmProfiling.CustomerProfile)
                        If Not IsNothing(newServingCustomer) Then
                            Me.ServingPatient = newServingCustomer
                            ViewPatientInformation(Me.ServingPatient.CustomerAssignCounter)
                            MessageBox.Show("Patient profile edited successfully", "Information Edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("You can only modify a patient information during consultation", "Edit Patient", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbcountername_Click(sender As Object, e As EventArgs) Handles lbcountername.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ((Me.dgvMedicalHistory_ConsultationList.SelectedRows.Count > 0) AndAlso Not Information.IsNothing(Me.bizboxConsultationHistory)) Then
            Dim num As Long = (Me.dgvMedicalHistory_ConsultationList.SelectedRows(0).Cells("consultationHIstory_ID").Value)
            Dim selectedConsulation As Bizbox_Consultation = Nothing
            For Each consultation As Bizbox_Consultation In Me.bizboxConsultationHistory
                If (consultation.ID = num) Then
                    selectedConsulation = consultation
                    Exit For
                End If
            Next
            If Not Information.IsNothing(selectedConsulation) Then
                Dim frm As New frmGenerateMedicalCertificate(selectedConsulation, False)
                frm.ShowDialog(Me)
                frm.Dispose()
            End If
        End If
    End Sub

    Private Sub btnPreviewMedicalCertificate_Click(sender As Object, e As EventArgs) Handles btnPreviewMedicalCertificate.Click
        If (Not Information.IsNothing(Me.ServingPatient) AndAlso Not Information.IsNothing(Me.latestBizboxConsultation)) Then
            Dim frm As New frmGenerateMedicalCertificate(Me.latestBizboxConsultation, False)
            frm.ShowDialog(Me)
            frm.Dispose()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btnConsultationHistory_ViewRX.Click
        If ((Me.dgvMedicalHistory_ConsultationList.SelectedRows.Count > 0) AndAlso Not Information.IsNothing(Me.bizboxConsultationHistory)) Then
            Dim num As Long = (Me.dgvMedicalHistory_ConsultationList.SelectedRows(0).Cells("consultationHIstory_ID").Value)
            Dim selectedConsulation As Bizbox_Consultation = Nothing
            For Each consultation As Bizbox_Consultation In Me.bizboxConsultationHistory
                If (consultation.ID = num) Then
                    selectedConsulation = consultation
                    Exit For
                End If
            Next
            If ((Not Information.IsNothing(selectedConsulation) AndAlso Not Information.IsNothing(selectedConsulation.BizboxRegistration)) AndAlso Not Information.IsNothing(selectedConsulation.BizboxRegistration.Plans)) Then
                Dim plans As List(Of Bizbox_ConsultationPlan) = selectedConsulation.BizboxRegistration.Plans
                Dim customer As Customer = selectedConsulation.ServedCustomer.CustomerAssignCounter.Customer
                Dim server As Server = selectedConsulation.ServerTransaction.ServerAssignCounter.Server
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
                Dim doctorsFullname As String = server.FullName
                Dim doctorsPRCNo As String = server.PRC
                Dim doctorsPTRNo As String = server.PTR
                Dim doctorS2No As String = server.PTR
                Dim doctorsHeader As String = ""
                Dim doctorsSignature As String = ""
                Dim consultationDate As String = Strings.Format(Me.latestBizboxConsultation.DateCreated, "MMM dd, yyyy")
                If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                    custName = "NAME NOT INDICATED"
                ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                    custName = "NAME NOT INDICATED"
                Else
                    custName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                    custFName = customer.CustomerInfo.FirstName.ToUpper
                    custMName = customer.CustomerInfo.Middlename.ToUpper
                    custLName = customer.CustomerInfo.Lastname.ToUpper
                End If
                custBDay = Strings.Format(customer.CustomerInfo.BirthDate, "MMM dd, yyyy")
                custAge = DateAndTime.DateDiff(DateInterval.Year, customer.CustomerInfo.BirthDate, customer.DateOfVisit, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString
                If Not custAge > 0 Then
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
                If (Not Information.IsNothing(plans) AndAlso (plans.Count > 0)) Then
                    withMeds = True
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
    End Sub

    Private Sub btnConsultationHistory_ViewConsent_Click(sender As Object, e As EventArgs) Handles btnConsultationHistory_ViewConsent.Click
        If ((Me.dgvMedicalHistory_ConsultationList.SelectedRows.Count > 0) AndAlso Not Information.IsNothing(Me.bizboxConsultationHistory)) Then
            Dim num As Long = (Me.dgvMedicalHistory_ConsultationList.SelectedRows(0).Cells("consultationHIstory_ID").Value)
            Dim selectedConsulation As Bizbox_Consultation = Nothing
            For Each consultation As Bizbox_Consultation In Me.bizboxConsultationHistory
                If (consultation.ID = num) Then
                    selectedConsulation = consultation
                    Exit For
                End If
            Next
            If (Not Information.IsNothing(selectedConsulation) AndAlso (Not Information.IsNothing(selectedConsulation.OPDConsent1) Or Not Information.IsNothing(selectedConsulation.OPDConsent2))) Then
                Dim pdfLink As New List(Of String)
                If (selectedConsulation.OPDConsent1.Trim.Length > 0) Then
                    pdfLink.Add(selectedConsulation.OPDConsent1)
                End If
                If (selectedConsulation.OPDConsent2.Trim.Length > 0) Then
                    pdfLink.Add(selectedConsulation.OPDConsent2)
                End If
                Dim frm As New frmPDFResultViewer(pdfLink)
                frm.ShowDialog()
                frm.Dispose()
            End If
        End If
    End Sub

    Private Sub btnViewConsent_Click(sender As Object, e As EventArgs) Handles btnViewConsent.Click
        If ((Not Information.IsNothing(Me.ServingPatient) AndAlso Not Information.IsNothing(Me.latestBizboxConsultation)) AndAlso (Not Information.IsNothing(Me.latestBizboxConsultation.OPDConsent1) Or Not Information.IsNothing(Me.latestBizboxConsultation.OPDConsent2))) Then
            Dim pdfLink As New List(Of String)
            If (Me.latestBizboxConsultation.OPDConsent1.Trim.Length > 0) Then
                pdfLink.Add(Me.latestBizboxConsultation.OPDConsent1)
            End If
            If (Me.latestBizboxConsultation.OPDConsent2.Trim.Length > 0) Then
                pdfLink.Add(Me.latestBizboxConsultation.OPDConsent2)
            End If
            If (pdfLink.Count > 0) Then
                Dim viewer As New frmPDFResultViewer(pdfLink)
                viewer.ShowDialog(Me)
                viewer.Dispose()
            Else
                MessageBox.Show("No consent were attatched", "No Consent", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub btnViewPatientCharts_Click(sender As Object, e As EventArgs) Handles btnViewPatientCharts.Click
        If Me.pnlPatientCharts.Visible Then
            Me.pnlPatientCharts.Hide()
        Else
            Me.pnlPatientCharts.Show()
        End If
    End Sub

    Private Sub btnClosePatientChart_Click(sender As Object, e As EventArgs) Handles btnClosePatientChart.Click
        pnlPatientCharts.Hide()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        pnlMedHistory_PatientCharts.Hide()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If pnlMedHistory_PatientCharts.Visible Then
            pnlMedHistory_PatientCharts.Hide()
        Else
            pnlMedHistory_PatientCharts.Show()
        End If
    End Sub

    Private Sub btnViewRX_Click(sender As Object, e As EventArgs) Handles btnViewRX.Click
        If Not Information.IsNothing(Me.ServingPatient) Then
            If Not Information.IsNothing(Me.latestBizboxConsultation) Then
                If (Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration) AndAlso Not Information.IsNothing(Me.latestBizboxConsultation.BizboxRegistration.Plans)) Then
                    Dim plans As List(Of Bizbox_ConsultationPlan) = Me.latestBizboxConsultation.BizboxRegistration.Plans
                    Dim customer As Customer = Me.latestBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer
                    Dim server As Server = Me.latestBizboxConsultation.ServerTransaction.ServerAssignCounter.Server
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
                    Dim doctorsFullname As String = server.FullName
                    Dim doctorsPRCNo As String = server.PRC
                    Dim doctorsPTRNo As String = server.PTR
                    Dim doctorS2No As String = server.PTR
                    Dim doctorsHeader As String = ""
                    Dim doctorsSignature As String = ""
                    Dim consultationDate As String = Strings.Format(Me.latestBizboxConsultation.DateCreated, "MMM dd, yyyy")
                    If (Information.IsNothing(customer.CustomerInfo.FirstName) And Information.IsNothing(customer.CustomerInfo.Lastname)) Then
                        custName = "NAME NOT INDICATED"
                    ElseIf ((customer.CustomerInfo.FirstName.Trim.Length <= 0) And (customer.CustomerInfo.Lastname.Trim.Length <= 0)) Then
                        custName = "NAME NOT INDICATED"
                    Else
                        custName = String.Concat(customer.CustomerInfo.Lastname.ToUpper, ", ", customer.CustomerInfo.FirstName.ToUpper, " ", customer.CustomerInfo.Middlename.ToUpper)
                        custFName = customer.CustomerInfo.FirstName.ToUpper
                        custMName = customer.CustomerInfo.Middlename.ToUpper
                        custLName = customer.CustomerInfo.Lastname.ToUpper
                    End If
                    custBDay = Strings.Format(customer.CustomerInfo.BirthDate, "MMM dd, yyyy")
                    custAge = DateAndTime.DateDiff(DateInterval.Year, customer.CustomerInfo.BirthDate, customer.DateOfVisit, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString
                    If Not custAge > 0 Then
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
                    If (Not Information.IsNothing(plans) AndAlso (plans.Count > 0)) Then
                        withMeds = True
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
            Else
                MessageBox.Show("No consultation occured during this date", "No Consultation Record", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub

    Private Sub tbPatient_Information_Click(sender As Object, e As EventArgs) Handles tbPatient_Information.Click

    End Sub

    Private Sub btnFetchRequisitionFromBizbox_Click(sender As Object, e As EventArgs) Handles btnFetchRequisitionFromBizbox.Click
        Me.GetCertainDoctorBizboxRequisions()
    End Sub
End Class