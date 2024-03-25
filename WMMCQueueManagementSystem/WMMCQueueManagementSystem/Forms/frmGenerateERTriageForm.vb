Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text.pdf

Public Class frmGenerateERTriageForm
    Private PatientConsultation As CustomerConsultation = Nothing
    Private isEditable As Boolean = False
    Private newFile As String = ""

    Sub New(consultation As CustomerConsultation, isEditable As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        Me.PatientConsultation = consultation
        Me.isEditable = isEditable
        txtFirstName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName.Trim.ToUpper
        txtMiddleName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename.Trim.ToUpper
        txtLastName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname.Trim.ToUpper
        dtpBirthDate.Text = Format(Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate, "MMM dd, yyyy")
        txtSex.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex.Trim.ToUpper
        txtAddress.Text = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive + " " + Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay + " " + Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality).Trim.ToUpper
        If Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper = "ROMAN CATHOLIC" Then
            cbRomanCatholic.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper = "ISLAM" Then
            cbIslam.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper = "PROTESTANT" Then
            cbProtestant.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper = "SDA" Then
            cbSDA.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper = "INC" Then
            cbSDA.Checked = True
        Else
            txtOtherReligion.Text = If(Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.Length > 0, Me.PatientConsultation.ERTraigeForm.PatientReligion.Trim.ToUpper, "ENTER RELIGION")
            cbOtheReligion.Checked = True
        End If
        If Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "CHILD" Or Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "NEWBORN" Then
            cbChild.Checked = True
        ElseIf Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "SINGLE" Then
            cbSingle.Checked = True
        ElseIf Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "MARRIED" Then
            cbMarried.Checked = True
        ElseIf Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "SEPARATED" Or Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "ANULLED" Then
            cbSeparated.Checked = True
        ElseIf Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus = "WIDOWED" Then
            cbWidowed.Checked = True
        Else
            cbChild.Checked = False
            cbSingle.Checked = False
            cbMarried.Checked = False
            cbSeparated.Checked = False
            cbWidowed.Checked = False
        End If
        txtPatientNo.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber.Trim.ToUpper
        txtContact_Watchers.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber.Trim.ToUpper
        txtCaseno.Text = Me.PatientConsultation.ERTraigeForm.CaseNo
        txtBedNo.Text = Me.PatientConsultation.ERTraigeForm.BedNo
        cbCaseType_GCB.Checked = Me.PatientConsultation.ERTraigeForm.isGCB
        cbCaseType_RESPI.Checked = Me.PatientConsultation.ERTraigeForm.isRespi
        If Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 1 Then
            cbModeOfArrival_WalkIn.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 2 Then
            cbModeOfArrival_Personal.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 3 Then
            cbModeOfArrival_Public.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 4 Then
            cbModeOfArrival_Police.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 5 Then
            cbModeOfArrival_Barangay.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 6 Then
            cbModeOfArrival_Ambulance.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.ModeOfArrival = 7 Then
            cbModeOfArrival_AmbulanceCall.Checked = True
        Else
            cbModeOfArrival_WalkIn.Checked = False
            cbModeOfArrival_Personal.Checked = False
            cbModeOfArrival_Public.Checked = False
            cbModeOfArrival_Police.Checked = False
            cbModeOfArrival_Barangay.Checked = False
            cbModeOfArrival_Ambulance.Checked = False
            cbModeOfArrival_AmbulanceCall.Checked = False
        End If
        txtAmbulance.Text = Me.PatientConsultation.ERTraigeForm.Ambulance.Trim.ToUpper
        dtp_ModeOfArrivalTimeOfCall.Value = Me.PatientConsultation.ERTraigeForm.TimeOfCall
        dtp_ModeOfArrivalTimeOfDispatched.Value = Me.PatientConsultation.ERTraigeForm.TimeOfDispatch
        If Me.PatientConsultation.ERTraigeForm.LevelOfConsciousness = 1 Then
            cbLevelOfConsiousness_Conscious.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.LevelOfConsciousness = 2 Then
            cbLevelOfConsiousness_Lethargic.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.LevelOfConsciousness = 3 Then
            cbLevelOfConsiousness_Stuporous.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.LevelOfConsciousness = 4 Then
            cbLevelOfConsiousness_Unconscious.Checked = True
        Else
            cbLevelOfConsiousness_Conscious.Checked = False
            cbLevelOfConsiousness_Lethargic.Checked = False
            cbLevelOfConsiousness_Stuporous.Checked = False
            cbLevelOfConsiousness_Unconscious.Checked = False
        End If
        If Me.PatientConsultation.ERTraigeForm.Classification = 1 Then
            cbClass_Critical.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.Classification = 2 Then
            cbClass_Urgent.Checked = True
        ElseIf Me.PatientConsultation.ERTraigeForm.Classification = 3 Then
            cbClass_NonUrgent.Checked = True
        Else
            cbClass_Critical.Checked = False
            cbClass_Urgent.Checked = False
            cbClass_NonUrgent.Checked = False
        End If
        dtpTimeOfArrival.Text = If(Not IsNothing(Me.PatientConsultation.ERTraigeForm.TimeOfArrival), Me.PatientConsultation.ERTraigeForm.TimeOfArrival, Today)
        dtpTimeEndorseROD.Text = If(Not IsNothing(Me.PatientConsultation.ERTraigeForm.TimeEndorsedROD), Me.PatientConsultation.ERTraigeForm.TimeEndorsedROD, Today)
        dtpTimeSeenROD.Text = If(Not IsNothing(Me.PatientConsultation.ERTraigeForm.TimeSeenROD), Me.PatientConsultation.ERTraigeForm.TimeSeenROD, Today)
        dtpTimeEndorseUnit.Text = If(Not IsNothing(Me.PatientConsultation.ERTraigeForm.TimeEndorsedUnit), Me.PatientConsultation.ERTraigeForm.TimeEndorsedUnit, Today)
        txtContact_Watchers.Text = Me.PatientConsultation.ERTraigeForm.WatchersContact.Trim.ToUpper
        txtVaccine_Dose1.Text = Me.PatientConsultation.ERTraigeForm.Vaccination1.Trim.ToUpper
        txtVaccine_Dose2.Text = Me.PatientConsultation.ERTraigeForm.Vaccination2.Trim.ToUpper
        txtVaccine_Booster.Text = Me.PatientConsultation.ERTraigeForm.Vaccination3.Trim.ToUpper
        txtTravelHistory.Text = Me.PatientConsultation.ERTraigeForm.TravelHistory.Trim.ToUpper
        txtDuty_Nurse.Text = If(Me.PatientConsultation.ERTraigeForm.TriageOnDuty.Trim.Length > 0, Me.PatientConsultation.ERTraigeForm.TriageOnDuty.Trim.ToUpper, If(Me.PatientConsultation.TriageNurseOnDuty.Trim.Length > 0, Me.PatientConsultation.TriageNurseOnDuty.Trim.ToUpper, ""))
        txtTimpStamp_ROD.Text = Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper
        txtDuty_Carried.Text = Me.PatientConsultation.ERTraigeForm.CarriedBy
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub fillUpOutpatientConsentForm()
        Dim patientFirstName As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName.Trim.ToUpper
        Dim patientMiddleName As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename.Trim.ToUpper
        Dim patientLastName As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname.Trim.ToUpper
        Dim patientAge As Integer = DateDiff(DateInterval.Year, Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate, Me.PatientConsultation.DateCreated)
        Dim patientSex As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex.Trim.ToUpper
        Dim patientAddress As String = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive + " " + Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay + " " + Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality).Trim.ToUpper
        Dim patientBday As Date = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate
        Dim religion As String = ""
        If cbRomanCatholic.Checked Then
            religion = "ROMAN CATHOLIC"
        ElseIf cbIslam.Checked Then
            religion = "ISLAM"
        ElseIf cbProtestant.Checked Then
            religion = "PROTESTANT"
        ElseIf cbSDA.Checked Then
            religion = "SDA"
        ElseIf cbINC.Checked Then
            religion = "INC"
        End If
        Dim otherReligion As String = ""
        otherReligion = txtOtherReligion.Text.Trim.ToUpper
        Dim patientCivilStatus As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CivilStatus.Trim.ToUpper
        Dim patientContact As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.PhoneNumber
        Dim watchersContact As String = txtContact_Watchers.Text.Trim.ToUpper
        Dim consultDate As Date = Me.PatientConsultation.ERTraigeForm.DateCreated
        Dim caseNo As String = txtCaseno.Text.ToUpper
        Dim bedNo As String = txtBedNo.Text.Trim.ToUpper
        Dim isGCB As Boolean = cbCaseType_GCB.Checked
        Dim isRespiER As Boolean = cbCaseType_RESPI.Checked
        Dim modeOfArrival As Integer = 0
        If cbModeOfArrival_WalkIn.Checked Then
            modeOfArrival = 1
        ElseIf cbModeOfArrival_Personal.Checked Then
            modeOfArrival = 2
        ElseIf cbModeOfArrival_Public.Checked Then
            modeOfArrival = 3
        ElseIf cbModeOfArrival_Police.Checked Then
            modeOfArrival = 4
        ElseIf cbModeOfArrival_Barangay.Checked Then
            modeOfArrival = 5
        ElseIf cbModeOfArrival_Ambulance.Checked Then
            modeOfArrival = 6
        ElseIf cbModeOfArrival_AmbulanceCall.Checked Then
            modeOfArrival = 7
        End If
        Dim ambulance As String = txtAmbulance.Text.Trim.ToUpper
        Dim timeOfCall As Date = dtp_ModeOfArrivalTimeOfCall.Value
        Dim timeOfDipatch As Date = dtp_ModeOfArrivalTimeOfDispatched.Value
        Dim levelOdConsciousness As Integer = 0
        If cbLevelOfConsiousness_Conscious.Checked Then
            levelOdConsciousness = 1
        ElseIf cbLevelOfConsiousness_Lethargic.Checked Then
            levelOdConsciousness = 2
        ElseIf cbLevelOfConsiousness_Stuporous.Checked Then
            levelOdConsciousness = 3
        ElseIf cbLevelOfConsiousness_Unconscious.Checked Then
            levelOdConsciousness = 4
        End If
        Dim timeOfArrival As Date = dtpTimeOfArrival.Value
        Dim timeEdorsedROD As Date = dtpTimeEndorseROD.Value
        Dim timeSeenROD As Date = dtpTimeSeenROD.Value
        Dim timeEndorseUnit As Date = dtpTimeEndorseUnit.Value
        Dim classification As Integer = 0
        If cbClass_Critical.Checked Then
            classification = 1
        ElseIf cbClass_Urgent.Checked Then
            classification = 2
        ElseIf cbClass_NonUrgent.Checked Then
            classification = 3
        End If
        Dim vaccination1 As String = txtVaccine_Dose1.Text.Trim.ToUpper
        Dim vaccination2 As String = txtVaccine_Dose2.Text.Trim.ToUpper
        Dim vaccination3 As String = txtVaccine_Booster.Text.Trim.ToUpper
        Dim vaccinated As Boolean = False
        If vaccination1.Trim.Length > 0 Or vaccination2.Trim.Length > 0 Or vaccination3.Trim.Length > 0 Then
            vaccinated = True
        End If
        Dim systolic As Double = Me.PatientConsultation.Systolic
        Dim diastolic As Double = Me.PatientConsultation.Diastolic
        Dim heartRate As Double = Me.PatientConsultation.PulseRate
        Dim respiRate As Double = Me.PatientConsultation.RespiratoryRate
        Dim temparature As Double = Me.PatientConsultation.Temperature
        Dim o2 As Double = Me.PatientConsultation.Oxygen
        Dim painScale As String = ""
        Dim cbg As String = ""
        Dim weight As Double = Me.PatientConsultation.Weight
        Dim height As Double = Me.PatientConsultation.Height
        Dim allergies As String = Me.PatientConsultation.Allergies
        Dim withAllergy As Boolean = False
        If allergies.Trim.Length > 0 Then
            withAllergy = True
        End If
        Dim travelHistory As String = txtTravelHistory.Text.Trim.ToUpper
        Dim withTravelHist As Boolean = False
        If travelHistory.Trim.Length > 0 Then
            withTravelHist = True
        End If
        Dim hypertension As Boolean = Me.PatientConsultation.Hypertension
        Dim diabetes As Boolean = Me.PatientConsultation.Diabetes
        Dim asthma As Boolean = Me.PatientConsultation.Asthma
        Dim stroke As Boolean = Me.PatientConsultation.Stroke
        Dim heartdisease As Boolean = Me.PatientConsultation.HeartDisease
        Dim cancer As Boolean = Me.PatientConsultation.Cancer
        Dim tuberculosis As Boolean = Me.PatientConsultation.Tuberculosis
        Dim COPD As Boolean = Me.PatientConsultation.COPD
        Dim otherMedHistory As String = Me.PatientConsultation.othermedicalhistory
        Dim nonMedicalHistory As Boolean = False
        If hypertension Or diabetes Or asthma Or stroke Or heartdisease Or cancer Or tuberculosis Or COPD Or (otherMedHistory.Trim.Length > 0) Then
            nonMedicalHistory = True
        End If
        Dim cheifComplaint As String = Me.PatientConsultation.ChiefComplaint
        Dim medicineTaken As String = Me.PatientConsultation.MedicineTaken
        Dim illnessHistory As String = Me.PatientConsultation.IllnessHistory
        Dim findings As String = Me.PatientConsultation.Findings
        Dim diagnosis As String = Me.PatientConsultation.Diagnosis
        Dim doctorOrder As String = Me.PatientConsultation.AdmittedDoctorsOrder
        Dim remarks As String = Me.PatientConsultation.AdmittedRemarks
        Dim transferred As Boolean = Me.PatientConsultation.TransferredReferred
        Dim refused As Boolean = Me.PatientConsultation.RefusedAdmission
        Dim erDeath As Boolean = Me.PatientConsultation.ERDeath
        Dim DOA As Boolean = Me.PatientConsultation.DOA
        Dim discharge As Boolean = Me.PatientConsultation.Discharged
        Dim HAMADAMA As Boolean = Me.PatientConsultation.HAMADAMA
        Dim absconed As Boolean = Me.PatientConsultation.Absconed
        Dim admitted As Boolean = Me.PatientConsultation.Admitted
        Dim admittedRoom As String = Me.PatientConsultation.RoomAdmitted.Trim.ToUpper
        Dim admittedWard As String = Me.PatientConsultation.WardAdmitted.Trim.ToUpper
        Dim nurseOnDuty As String = txtDuty_Nurse.Text.Trim
        Dim RODOnDuty As String = If(Not IsNothing(Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName), Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper, "NO SET ROD")
        Dim carriedBy As String = txtDuty_Carried.Text.Trim
        Dim apiControl As New APIController
        Dim serverDate As Date = apiControl.GetCurrentServerDate_qms()
        Dim forDeletion As Boolean = False
        If Not IsNothing(Me.PatientConsultation.ERTraigeForm.FileLocation) Then
            If Me.PatientConsultation.ERTraigeForm.FileLocation.Trim.Length > 0 Then
                forDeletion = True
            End If
        End If
        If forDeletion Then
            Try
                If System.IO.File.Exists(Me.PatientConsultation.ERTraigeForm.FileLocation) = True Then
                    System.IO.File.Delete(Me.PatientConsultation.ERTraigeForm.FileLocation)
                End If
            Catch ex As Exception

            End Try
        End If
        Dim pdfTemp As String = "\\10.5.19.237\wmmc_pcms\template_forms\ER TRIAGE FORM.pdf"
        newFile = "\\10.5.19.237\wmmc_pcms\patient_er_triage_forms\ER_TRIAGE_FORM_" & PatientConsultation.Consultation_ID & serverDate.ToString("MMddyyyyHHmmsstt") & ".Pdf"
        Try
            ' ------ READING -------
            Dim pdfReader As New PdfReader(pdfTemp)
            ' ------ WRITING -------
            ' If you don’t specify version and append flag (last 2 params) in below line then you may receive “Extended Features” error when you open generated PDF
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)
            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            Dim PdfContentByte = pdfStamper.GetOverContent(1)
            pdfFormFields.SetField("txtDateToday", Format(consultDate, "MMM dd, yyyy"))
            pdfFormFields.SetField("txtCaseNo", caseNo)
            pdfFormFields.SetField("txtBedNo", bedNo)
            pdfFormFields.SetField("cbGCBER", If(isGCB, "Yes", "No"))
            pdfFormFields.SetField("cbRESPIER", If(isRespiER, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_Walkin", If(modeOfArrival = 1, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_PersonalService", If(modeOfArrival = 2, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_PublicService", If(modeOfArrival = 3, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_Police", If(modeOfArrival = 4, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_Barangay", If(modeOfArrival = 5, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_Ambulance", If(modeOfArrival = 6, "Yes", "No"))
            pdfFormFields.SetField("cbModeOfArrival_AmbulanceCall", If(modeOfArrival = 7, "Yes", "No"))
            pdfFormFields.SetField("txtAmbulance", ambulance)
            pdfFormFields.SetField("txtCall", timeOfCall)
            pdfFormFields.SetField("txtDispatchTime", timeOfDipatch)
            pdfFormFields.SetField("cbLevelOfConscious_Conscious", If(levelOdConsciousness = 1, "Yes", "No"))
            pdfFormFields.SetField("cbLevelOfConscious_Lethargic", If(levelOdConsciousness = 2, "Yes", "No"))
            pdfFormFields.SetField("cbLevelOfConscious_Stuporous", If(levelOdConsciousness = 3, "Yes", "No"))
            pdfFormFields.SetField("cbLevelOfConscious_Unconscious", If(levelOdConsciousness = 4, "Yes", "No"))
            pdfFormFields.SetField("txtArrivalTime", timeOfArrival.ToShortTimeString)
            pdfFormFields.SetField("txtEndorsedRODTime", timeEdorsedROD.ToShortTimeString)
            pdfFormFields.SetField("txtSeenRODTime", timeSeenROD.ToShortTimeString)
            pdfFormFields.SetField("txtEndorseUnitTime", timeEndorseUnit.ToShortTimeString)
            pdfFormFields.SetField("cbClassification_Critical", If(classification = 1, "Yes", "No"))
            pdfFormFields.SetField("cbClassification_Urgent", If(classification = 2, "Yes", "No"))
            pdfFormFields.SetField("cbClassification_NonUrgent", If(classification = 3, "Yes", "No"))
            pdfFormFields.SetField("txtFirstName", patientFirstName)
            pdfFormFields.SetField("MiddleName", patientMiddleName)
            pdfFormFields.SetField("txtLastName", patientLastName)
            pdfFormFields.SetField("txtAge", patientAge)
            pdfFormFields.SetField("txtSex", patientSex)
            pdfFormFields.SetField("txtAddress", patientAddress)
            pdfFormFields.SetField("cbReligion_RC", If(religion = "ROMAN CATHOLIC", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Islam", If(religion = "ISLAM", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Protestant", If(religion = "PROTESTANT", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_SDA", If(religion = "SDA", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_INC", If(religion = "INC", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Other", If(otherReligion.Trim.Length > 0, "Yes", "No"))
            pdfFormFields.SetField("txtOtherReligion", otherReligion)
            pdfFormFields.SetField("cbReligion_Child", If(patientCivilStatus = "CHILD" Or patientCivilStatus = "NEWBORN", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Single", If(patientCivilStatus = "SINGLE", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Married", If(patientCivilStatus = "MARRIED", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Separated", If(patientCivilStatus = "SEPARATED" Or patientCivilStatus = "ANULLED", "Yes", "No"))
            pdfFormFields.SetField("cbReligion_Widow", If(patientCivilStatus = "WIDOWED", "Yes", "No"))
            pdfFormFields.SetField("txtPhneNumber", patientContact)
            pdfFormFields.SetField("txtWachersPhoneNumber", watchersContact)
            pdfFormFields.SetField("txtSystolic", systolic)
            pdfFormFields.SetField("txtDysastolic", diastolic)
            pdfFormFields.SetField("txtHeartRate", heartRate)
            pdfFormFields.SetField("txtRespiratoryRate", respiRate)
            pdfFormFields.SetField("txtTemperature", temparature)
            pdfFormFields.SetField("txtO2Sat", o2)
            pdfFormFields.SetField("txtPainScale", painScale)
            pdfFormFields.SetField("txtCBG", cbg)
            pdfFormFields.SetField("txtWeight", weight)
            pdfFormFields.SetField("txtHeight", height)
            pdfFormFields.SetField("txtChiefComplaint", cheifComplaint)
            pdfFormFields.SetField("cbAllergy", If(Not withAllergy, "Yes", "No"))
            pdfFormFields.SetField("cbFoodAllergy", "")
            pdfFormFields.SetField("txtFoodAllergy", allergies)
            pdfFormFields.SetField("cbMediciniceAllergy", "")
            pdfFormFields.SetField("txtMediciniceAllergy", allergies)
            pdfFormFields.SetField("cbTravelHistory_None", If(Not withTravelHist, "Yes", "No"))
            pdfFormFields.SetField("cbTravelHistory_Yes", If(withTravelHist, "Yes", "No"))
            pdfFormFields.SetField("txtTravelHistory_Location", travelHistory)
            pdfFormFields.SetField("cbVaccination_None", If(Not vaccinated, "Yes", "No"))
            pdfFormFields.SetField("cbVaccination_Yes", If(vaccinated, "Yes", "No"))
            pdfFormFields.SetField("txtVaccination_1stDose", vaccination1)
            pdfFormFields.SetField("txtVaccination_2stDose", vaccination2)
            pdfFormFields.SetField("txtVaccination_Booster", vaccination3)
            pdfFormFields.SetField("txtMedicationTaken", medicineTaken)
            pdfFormFields.SetField("cbMedicalHistory_None", nonMedicalHistory)
            pdfFormFields.SetField("cbMedicalHistory_Hypertension", hypertension)
            pdfFormFields.SetField("cbMedicalHistory_Diabetes", diabetes)
            pdfFormFields.SetField("cbMedicalHistory_Asthma", asthma)
            pdfFormFields.SetField("cbMedicalHistory_Stroke", stroke)
            pdfFormFields.SetField("cbMedicalHistory_HeartDisease", heartdisease)
            pdfFormFields.SetField("cbMedicalHistory_Cancer", cancer)
            pdfFormFields.SetField("txtCancer", "")
            pdfFormFields.SetField("cbMedicalHistory_Tuberculosis", tuberculosis)
            pdfFormFields.SetField("txtTuberculosis", "")
            pdfFormFields.SetField("cbMedicalHistory_COPD", COPD)
            pdfFormFields.SetField("cbMedicalHistory_Others", If(otherMedHistory.Trim.Length > 0, "Yes", "No"))
            pdfFormFields.SetField("txtOtherPastMedicalHistory", otherMedHistory)
            pdfFormFields.SetField("txtHIstoryOfPresentIllness", illnessHistory)
            pdfFormFields.SetField("txtDoctorsOrder", doctorOrder)
            pdfFormFields.SetField("txtRemark", remarks)
            pdfFormFields.SetField("txtFindings", findings)
            pdfFormFields.SetField("txtFinalDiagnosis", diagnosis)
            pdfFormFields.SetField("cbCaseDisposition_Transferred", If(transferred, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_Refused", If(refused, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_ERDeath", If(erDeath, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_DOA", If(DOA, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_Admitted", If(admitted, "Yes", "No"))
            pdfFormFields.SetField("txtRoomAdmitted", admittedRoom)
            pdfFormFields.SetField("cbCaseDisposition_Discharged", If(discharge, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_HAMA", If(HAMADAMA, "Yes", "No"))
            pdfFormFields.SetField("cbCaseDisposition_Absconded", If(absconed, "Yes", "No"))
            pdfFormFields.SetField("txtTriageNurseOnDuty", nurseOnDuty)
            pdfFormFields.SetField("txtResidentPhysicianOnDuty", RODOnDuty)
            pdfFormFields.SetField("txtCarriedOutBy", carriedBy)
            pdfStamper.FormFlattening = False
            ' close the pdf
            pdfStamper.Close()
            ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
            ViewPDFToViewer(newFile)
        Catch ex As Exception

        Finally
            Dim ERTriage As New ERTraigeForm
            ERTriage.Form_ID = Me.PatientConsultation.ERTraigeForm.Form_ID
            ERTriage.CaseNo = caseNo
            ERTriage.BedNo = bedNo
            ERTriage.isGCB = isGCB
            ERTriage.isRespi = isRespiER
            ERTriage.ModeOfArrival = modeOfArrival
            ERTriage.Ambulance = ambulance
            ERTriage.TimeOfCall = timeOfCall
            ERTriage.TimeOfDispatch = timeOfDipatch
            ERTriage.LevelOfConsciousness = levelOdConsciousness
            ERTriage.TimeOfArrival = timeOfArrival
            ERTriage.TimeEndorsedROD = timeEdorsedROD
            ERTriage.TimeSeenROD = timeSeenROD
            ERTriage.TimeEndorsedUnit = timeEndorseUnit
            ERTriage.Classification = classification
            ERTriage.PatientContact = patientContact
            ERTriage.WatchersContact = watchersContact
            ERTriage.PatientReligion = If(religion.Trim.Length > 0, religion, otherReligion)
            ERTriage.PainScale = ""
            ERTriage.TravelHistory = travelHistory
            ERTriage.Vaccination1 = vaccination1
            ERTriage.Vaccination2 = vaccination2
            ERTriage.Vaccination3 = vaccination3
            ERTriage.TriageOnDuty = txtDuty_Nurse.Text
            ERTriage.RODOnDuty = txtTimpStamp_ROD.Text
            ERTriage.CarriedBy = txtDuty_Carried.Text
            ERTriage.FileLocation = newFile
            Dim cusConsultationController As New CustomerConsultationController
            If cusConsultationController.SaveERTriageFormCharts(ERTriage) Then
                Me.PatientConsultation.ERTraigeForm.FileLocation = newFile
            End If
        End Try
    End Sub

    Private Function ViewPDFToViewer(viewPDFFile) As Boolean
        Try
            pdfViewer.LoadFromFile(viewPDFFile)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub frmGenerateERTriageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pd As New PrintDialog
            Dim pdoc As Printing.PrintDocument = pdfViewer.PrintDocument()
            pd.Document = pdoc
            If pd.ShowDialog = DialogResult.OK Then
                pdoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Something went wrong during printing. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub cbOtheReligion_CheckedChanged(sender As Object, e As EventArgs) Handles cbOtheReligion.CheckedChanged
        If Not cbOtheReligion.Checked Then
            txtOtherReligion.Text = ""
        End If
    End Sub
End Class