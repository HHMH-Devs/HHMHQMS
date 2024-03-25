Imports System.Data.SqlClient

Public Class BizboxAPI

    Public Function GetCertainPatientRegistration(ByVal ID As Long) As Bizbox_PatientDailyRegistration
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType,consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment,assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink,patientInfo.PK_psPersonalData as PATInfoID, PK_emdPatients as PATID, patientInfo.lastname as PATLastname, patientInfo.firstname as PATFirstname, patientInfo.middlename as PATMiddlename, patientInfo.suffixname as PATSuffixname, patientMoreInfo.fullname as PATFullname1, patientMoreInfo.fullname2 as PATFullname2, patientInfo.cpstreetbldg1 as PATAddress1, patientInfo.cpstreetbldg2 as PATAddress2, patientInfo.cpstreetbldg3 as PATAddress3, patientMoreInfo.praddress as PATFullAddress, patientInfo.gender as PATGender, patientInfo.birthdate as PATBirthDate, patientInfo.civilstatus as PATCivilStatus, patientInfo.nationality as PATNationality, patientMoreInfo.mobilephone as PATMobileNo1, patientMoreInfo.mobilephone2 as PATMobileNo2, patientInfo.ImageLink as PATImageLink 
                                FROM [dbo].[psPatRegisters] as registration
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData 
                                LEFT JOIN [dbo].[emdPatients] as patient on patient.PK_emdPatients = consultation.FK_emdPatients
                                JOIN [dbo].[psPersonaldata] as patientInfo on patient.PK_emdPatients = patientInfo.PK_psPersonalData 
                                JOIN [dbo].[psDatacenter] as patientMoreInfo on patient.PK_emdPatients = patientMoreInfo.PK_psDatacenter 
                                WHERE registration.PK_psPatRegisters = @ID ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim registration As New Bizbox_PatientDailyRegistration
                registration.ID = data.Rows(0)("ID")
                registration.ConsultationID = data.Rows(0)("ConsultationID")
                registration.RegistrationDate = data.Rows(0)("RegistryDate")
                registration.RegistrationType = data.Rows(0)("TransactionType")
                registration.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("ChiefComplaint")), data.Rows(0)("ChiefComplaint"), "")
                registration.HistoryOfPresentIllness = If(Not IsDBNull(data.Rows(0)("HistoryOfPresentIllness")), data.Rows(0)("HistoryOfPresentIllness"), "")
                registration.PertinentPhysicalExamination = (If(Not IsDBNull(data.Rows(0)("PertinentPhysicalExam")), data.Rows(0)("PertinentPhysicalExam"), ""))
                registration.WorkingDiagnosis = (If(Not IsDBNull(data.Rows(0)("WorkingDiagnosis")), data.Rows(0)("WorkingDiagnosis"), ""))
                registration.DischargeDiagnosis = (If(Not IsDBNull((data.Rows(0)("DischargeDiagnosis"))), data.Rows(0)("DischargeDiagnosis"), ""))
                registration.FinalDiagnosis = (If(Not IsDBNull((data.Rows(0)("FinalDiagnosis"))), data.Rows(0)("FinalDiagnosis"), ""))
                registration.Treatment = (If(Not IsDBNull((data.Rows(0)("Treatment"))), data.Rows(0)("Treatment"), ""))
                registration.Impression = (If(Not IsDBNull((data.Rows(0)("Impression"))), data.Rows(0)("Impression"), ""))
                registration.Remarks = (If(Not IsDBNull((data.Rows(0)("Remarks"))), data.Rows(0)("Remarks"), ""))
                registration.Height1 = (If(Not IsDBNull((data.Rows(0)("InitialHeight1"))), data.Rows(0)("InitialHeight1"), 0))
                registration.Height2 = (If(Not IsDBNull((data.Rows(0)("InitialHeight2"))), data.Rows(0)("InitialHeight2"), 0))
                registration.Weight = (If(Not IsDBNull((data.Rows(0)("InitialWeight"))), data.Rows(0)("InitialWeight"), 0))
                registration.HeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialHeightUnit"))), data.Rows(0)("InitialHeightUnit"), ""))
                registration.WeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialWeightUnit"))), data.Rows(0)("InitialWeightUnit"), ""))
                registration.PulseRate = (If(Not IsDBNull((data.Rows(0)("PulseRate"))), data.Rows(0)("PulseRate"), 0))
                registration.RespiratoryRate = (If(Not IsDBNull((data.Rows(0)("RespiratoryRate"))), data.Rows(0)("RespiratoryRate"), 0))
                registration.Temparature = (If(Not IsDBNull((data.Rows(0)("Temparature"))), data.Rows(0)("Temparature"), 0))
                registration.Systolic = (If(Not IsDBNull((data.Rows(0)("Systolic"))), data.Rows(0)("Systolic"), 0))
                registration.Diastolic = (If(Not IsDBNull((data.Rows(0)("Diastolic"))), data.Rows(0)("Diastolic"), 0))
                registration.DoleEmpNo = (If(Not IsDBNull((data.Rows(0)("DoleEmployeeNo"))), data.Rows(0)("DoleEmployeeNo"), ""))
                registration.DoleRefNO = (If(Not IsDBNull((data.Rows(0)("DoleReferenceNo"))), data.Rows(0)("DoleReferenceNo"), ""))
                registration.DoleAppStat = (If(Not IsDBNull((data.Rows(0)("DoleType"))), data.Rows(0)("DoleType"), ""))
                registration.ConsultationIn = If(Not IsDBNull((data.Rows(0)("ConsultationIN"))), data.Rows(0)("ConsultationIN"), Nothing)
                registration.ConsultationOut = If(Not IsDBNull((data.Rows(0)("ConsultationOUT"))), data.Rows(0)("ConsultationOUT"), Nothing)
                registration.PatientData = New Bizbox_PatientPersonalData
                registration.PatientData.PatientID = (If(Not IsDBNull((data.Rows(0)("PATInfoID"))), data.Rows(0)("PATInfoID"), 0))
                registration.PatientData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.PatientData.MiddleName = (If(Not IsDBNull((data.Rows(0)("PATMiddlename"))), data.Rows(0)("PATMiddlename"), ""))
                registration.PatientData.Lastname = (If(Not IsDBNull((data.Rows(0)("PATLastname"))), data.Rows(0)("PATLastname"), ""))
                registration.PatientData.SuffixName = (If(Not IsDBNull((data.Rows(0)("PATSuffixname"))), data.Rows(0)("PATSuffixname"), ""))
                registration.PatientData.FullName = (If(Not IsDBNull((data.Rows(0)("PATFullname1"))), data.Rows(0)("PATFullname1"), ""))
                registration.PatientData.AddressPt1 = (If(Not IsDBNull((data.Rows(0)("PATAddress1"))), data.Rows(0)("PATAddress1"), ""))
                registration.PatientData.AddressPt2 = (If(Not IsDBNull((data.Rows(0)("PATAddress2"))), data.Rows(0)("PATAddress2"), ""))
                registration.PatientData.AddressPt3 = (If(Not IsDBNull((data.Rows(0)("PATAddress3"))), data.Rows(0)("PATAddress3"), ""))
                registration.PatientData.FullAddress = (If(Not IsDBNull((data.Rows(0)("PATFullAddress"))), data.Rows(0)("PATFullAddress"), ""))
                registration.PatientData.Gender = (If(Not IsDBNull((data.Rows(0)("PATGender"))), data.Rows(0)("PATGender"), ""))
                registration.PatientData.BirthDate = (If(Not IsDBNull((data.Rows(0)("PATBirthDate"))), data.Rows(0)("PATBirthDate"), Nothing))
                registration.PatientData.CivilStatus = (If(Not IsDBNull((data.Rows(0)("PATCivilStatus"))), data.Rows(0)("PATCivilStatus"), ""))
                registration.PatientData.Nationality = (If(Not IsDBNull((data.Rows(0)("PATNationality"))), data.Rows(0)("PATNationality"), ""))
                registration.PatientData.MobileNo1 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo1"))), data.Rows(0)("PATMobileNo1"), ""))
                registration.PatientData.MobileNo2 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo2"))), data.Rows(0)("PATMobileNo2"), ""))
                registration.PatientData.ImageLink = (If(Not IsDBNull((data.Rows(0)("PATImageLink"))), data.Rows(0)("PATImageLink"), ""))
                registration.DoctorData = New Bizbox_DoctorsInfo
                registration.DoctorData.ID = (If(Not IsDBNull((data.Rows(0)("RODInfoID"))), data.Rows(0)("RODInfoID"), 0))
                registration.DoctorData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.DoctorData.MiddleName = (If(Not IsDBNull((data.Rows(0)("RODMiddlename"))), data.Rows(0)("RODMiddlename"), ""))
                registration.DoctorData.Lastname = (If(Not IsDBNull((data.Rows(0)("RODLastname"))), data.Rows(0)("RODLastname"), ""))
                registration.DoctorData.SuffixName = (If(Not IsDBNull((data.Rows(0)("RODSuffix"))), data.Rows(0)("RODSuffix"), ""))
                registration.DoctorData.ContactNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Specialization = ""
                registration.DoctorData.PRC = (If(Not IsDBNull((data.Rows(0)("RODPRC"))), data.Rows(0)("RODPRC"), ""))
                registration.DoctorData.PTR = (If(Not IsDBNull((data.Rows(0)("RODPTR"))), data.Rows(0)("RODPTR"), ""))
                registration.DoctorData.S2No = (If(Not IsDBNull((data.Rows(0)("RODS2"))), data.Rows(0)("RODS2"), ""))
                registration.DoctorData.MobileNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Email = (If(Not IsDBNull((data.Rows(0)("RODEmail"))), data.Rows(0)("RODEmail"), ""))
                registration.DoctorData.ImageLink = (If(Not IsDBNull((data.Rows(0)("RODImageLink"))), data.Rows(0)("RODImageLink"), ""))
                registration.DoctorData.SignatureLocation = ""
                registration.FinalDiagnosisByICD10 = Me.GetPatientFinalDiagnosisByICD10(registration.ConsultationID)
                registration.Plans = Me.GetPatientConsultationsPlans(registration.ConsultationID)
                registration.SickLeaves = Me.GetPatientConsultationSickLeave(registration.ConsultationID)
                registration.Requisitions = Me.GetPatientConsultationRequisitions(registration.ConsultationID)
                registration.BizboxConsultation = New CustomerConsultationController().GetIfExistConsultation(registration.ID)
                Return registration
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientRegistration2(ByVal regID As Long, ByVal rodID As Long) As Bizbox_PatientDailyRegistration
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType,consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment,assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink,patientInfo.PK_psPersonalData as PATInfoID, PK_emdPatients as PATID, patientInfo.lastname as PATLastname, patientInfo.firstname as PATFirstname, patientInfo.middlename as PATMiddlename, patientInfo.suffixname as PATSuffixname, patientMoreInfo.fullname as PATFullname1, patientMoreInfo.fullname2 as PATFullname2, patientInfo.cpstreetbldg1 as PATAddress1, patientInfo.cpstreetbldg2 as PATAddress2, patientInfo.cpstreetbldg3 as PATAddress3, patientMoreInfo.praddress as PATFullAddress, patientInfo.gender as PATGender, patientInfo.birthdate as PATBirthDate, patientInfo.civilstatus as PATCivilStatus, patientInfo.nationality as PATNationality, patientMoreInfo.mobilephone as PATMobileNo1, patientMoreInfo.mobilephone2 as PATMobileNo2, patientInfo.ImageLink as PATImageLink 
                                FROM [dbo].[psPatRegisters] as registration
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData 
                                LEFT JOIN [dbo].[emdPatients] as patient on patient.PK_emdPatients = consultation.FK_emdPatients
                                JOIN [dbo].[psPersonaldata] as patientInfo on patient.PK_emdPatients = patientInfo.PK_psPersonalData 
                                JOIN [dbo].[psDatacenter] as patientMoreInfo on patient.PK_emdPatients = patientMoreInfo.PK_psDatacenter 
                                WHERE registration.PK_psPatRegisters = @regID AND assignDoctorInfo.PK_psPersonalData = @rodID
                                ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@regID", regID)
            cmd.Parameters.AddWithValue("@rodID", rodID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim registration As New Bizbox_PatientDailyRegistration
                registration.ID = data.Rows(0)("ID")
                registration.ConsultationID = data.Rows(0)("ConsultationID")
                registration.RegistrationDate = data.Rows(0)("RegistryDate")
                registration.RegistrationType = data.Rows(0)("TransactionType")
                registration.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("ChiefComplaint")), data.Rows(0)("ChiefComplaint"), "")
                registration.HistoryOfPresentIllness = If(Not IsDBNull(data.Rows(0)("HistoryOfPresentIllness")), data.Rows(0)("HistoryOfPresentIllness"), "")
                registration.PertinentPhysicalExamination = (If(Not IsDBNull(data.Rows(0)("PertinentPhysicalExam")), data.Rows(0)("PertinentPhysicalExam"), ""))
                registration.WorkingDiagnosis = (If(Not IsDBNull(data.Rows(0)("WorkingDiagnosis")), data.Rows(0)("WorkingDiagnosis"), ""))
                registration.DischargeDiagnosis = (If(Not IsDBNull((data.Rows(0)("DischargeDiagnosis"))), data.Rows(0)("DischargeDiagnosis"), ""))
                registration.FinalDiagnosis = (If(Not IsDBNull((data.Rows(0)("FinalDiagnosis"))), data.Rows(0)("FinalDiagnosis"), ""))
                registration.Treatment = (If(Not IsDBNull((data.Rows(0)("Treatment"))), data.Rows(0)("Treatment"), ""))
                registration.Impression = (If(Not IsDBNull((data.Rows(0)("Impression"))), data.Rows(0)("Impression"), ""))
                registration.Remarks = (If(Not IsDBNull((data.Rows(0)("Remarks"))), data.Rows(0)("Remarks"), ""))
                registration.Height1 = (If(Not IsDBNull((data.Rows(0)("InitialHeight1"))), data.Rows(0)("InitialHeight1"), 0))
                registration.Height2 = (If(Not IsDBNull((data.Rows(0)("InitialHeight2"))), data.Rows(0)("InitialHeight2"), 0))
                registration.Weight = (If(Not IsDBNull((data.Rows(0)("InitialWeight"))), data.Rows(0)("InitialWeight"), 0))
                registration.HeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialHeightUnit"))), data.Rows(0)("InitialHeightUnit"), ""))
                registration.WeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialWeightUnit"))), data.Rows(0)("InitialWeightUnit"), ""))
                registration.PulseRate = (If(Not IsDBNull((data.Rows(0)("PulseRate"))), data.Rows(0)("PulseRate"), 0))
                registration.RespiratoryRate = (If(Not IsDBNull((data.Rows(0)("RespiratoryRate"))), data.Rows(0)("RespiratoryRate"), 0))
                registration.Temparature = (If(Not IsDBNull((data.Rows(0)("Temparature"))), data.Rows(0)("Temparature"), 0))
                registration.Systolic = (If(Not IsDBNull((data.Rows(0)("Systolic"))), data.Rows(0)("Systolic"), 0))
                registration.Diastolic = (If(Not IsDBNull((data.Rows(0)("Diastolic"))), data.Rows(0)("Diastolic"), 0))
                registration.DoleEmpNo = (If(Not IsDBNull((data.Rows(0)("DoleEmployeeNo"))), data.Rows(0)("DoleEmployeeNo"), ""))
                registration.DoleRefNO = (If(Not IsDBNull((data.Rows(0)("DoleReferenceNo"))), data.Rows(0)("DoleReferenceNo"), ""))
                registration.DoleAppStat = (If(Not IsDBNull((data.Rows(0)("DoleType"))), data.Rows(0)("DoleType"), ""))
                registration.ConsultationIn = If(Not IsDBNull((data.Rows(0)("ConsultationIN"))), data.Rows(0)("ConsultationIN"), Nothing)
                registration.ConsultationOut = If(Not IsDBNull((data.Rows(0)("ConsultationOUT"))), data.Rows(0)("ConsultationOUT"), Nothing)
                registration.PatientData = New Bizbox_PatientPersonalData
                registration.PatientData.PatientID = (If(Not IsDBNull((data.Rows(0)("PATInfoID"))), data.Rows(0)("PATInfoID"), 0))
                registration.PatientData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.PatientData.MiddleName = (If(Not IsDBNull((data.Rows(0)("PATMiddlename"))), data.Rows(0)("PATMiddlename"), ""))
                registration.PatientData.Lastname = (If(Not IsDBNull((data.Rows(0)("PATLastname"))), data.Rows(0)("PATLastname"), ""))
                registration.PatientData.SuffixName = (If(Not IsDBNull((data.Rows(0)("PATSuffixname"))), data.Rows(0)("PATSuffixname"), ""))
                registration.PatientData.FullName = (If(Not IsDBNull((data.Rows(0)("PATFullname1"))), data.Rows(0)("PATFullname1"), ""))
                registration.PatientData.AddressPt1 = (If(Not IsDBNull((data.Rows(0)("PATAddress1"))), data.Rows(0)("PATAddress1"), ""))
                registration.PatientData.AddressPt2 = (If(Not IsDBNull((data.Rows(0)("PATAddress2"))), data.Rows(0)("PATAddress2"), ""))
                registration.PatientData.AddressPt3 = (If(Not IsDBNull((data.Rows(0)("PATAddress3"))), data.Rows(0)("PATAddress3"), ""))
                registration.PatientData.FullAddress = (If(Not IsDBNull((data.Rows(0)("PATFullAddress"))), data.Rows(0)("PATFullAddress"), ""))
                registration.PatientData.Gender = (If(Not IsDBNull((data.Rows(0)("PATGender"))), data.Rows(0)("PATGender"), ""))
                registration.PatientData.BirthDate = (If(Not IsDBNull((data.Rows(0)("PATBirthDate"))), data.Rows(0)("PATBirthDate"), Nothing))
                registration.PatientData.CivilStatus = (If(Not IsDBNull((data.Rows(0)("PATCivilStatus"))), data.Rows(0)("PATCivilStatus"), ""))
                registration.PatientData.Nationality = (If(Not IsDBNull((data.Rows(0)("PATNationality"))), data.Rows(0)("PATNationality"), ""))
                registration.PatientData.MobileNo1 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo1"))), data.Rows(0)("PATMobileNo1"), ""))
                registration.PatientData.MobileNo2 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo2"))), data.Rows(0)("PATMobileNo2"), ""))
                registration.PatientData.ImageLink = (If(Not IsDBNull((data.Rows(0)("PATImageLink"))), data.Rows(0)("PATImageLink"), ""))
                registration.DoctorData = New Bizbox_DoctorsInfo
                registration.DoctorData.ID = (If(Not IsDBNull((data.Rows(0)("RODInfoID"))), data.Rows(0)("RODInfoID"), 0))
                registration.DoctorData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.DoctorData.MiddleName = (If(Not IsDBNull((data.Rows(0)("RODMiddlename"))), data.Rows(0)("RODMiddlename"), ""))
                registration.DoctorData.Lastname = (If(Not IsDBNull((data.Rows(0)("RODLastname"))), data.Rows(0)("RODLastname"), ""))
                registration.DoctorData.SuffixName = (If(Not IsDBNull((data.Rows(0)("RODSuffix"))), data.Rows(0)("RODSuffix"), ""))
                registration.DoctorData.ContactNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Specialization = ""
                registration.DoctorData.PRC = (If(Not IsDBNull((data.Rows(0)("RODPRC"))), data.Rows(0)("RODPRC"), ""))
                registration.DoctorData.PTR = (If(Not IsDBNull((data.Rows(0)("RODPTR"))), data.Rows(0)("RODPTR"), ""))
                registration.DoctorData.S2No = (If(Not IsDBNull((data.Rows(0)("RODS2"))), data.Rows(0)("RODS2"), ""))
                registration.DoctorData.MobileNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Email = (If(Not IsDBNull((data.Rows(0)("RODEmail"))), data.Rows(0)("RODEmail"), ""))
                registration.DoctorData.ImageLink = (If(Not IsDBNull((data.Rows(0)("RODImageLink"))), data.Rows(0)("RODImageLink"), ""))
                registration.DoctorData.SignatureLocation = ""
                registration.FinalDiagnosisByICD10 = Me.GetPatientFinalDiagnosisByICD10(registration.ConsultationID)
                registration.Plans = Me.GetPatientConsultationsPlans(registration.ConsultationID)
                registration.SickLeaves = Me.GetPatientConsultationSickLeave(registration.ConsultationID)
                registration.BizboxConsultation = New CustomerConsultationController().GetIfExistConsultation(registration.ID)
                Return registration
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientRegistration3(ByVal regID As Long, ByVal rodprc As Long) As Bizbox_PatientDailyRegistration
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType,consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment,assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink,patientInfo.PK_psPersonalData as PATInfoID, PK_emdPatients as PATID, patientInfo.lastname as PATLastname, patientInfo.firstname as PATFirstname, patientInfo.middlename as PATMiddlename, patientInfo.suffixname as PATSuffixname, patientMoreInfo.fullname as PATFullname1, patientMoreInfo.fullname2 as PATFullname2, patientInfo.cpstreetbldg1 as PATAddress1, patientInfo.cpstreetbldg2 as PATAddress2, patientInfo.cpstreetbldg3 as PATAddress3, patientMoreInfo.praddress as PATFullAddress, patientInfo.gender as PATGender, patientInfo.birthdate as PATBirthDate, patientInfo.civilstatus as PATCivilStatus, patientInfo.nationality as PATNationality, patientMoreInfo.mobilephone as PATMobileNo1, patientMoreInfo.mobilephone2 as PATMobileNo2, patientInfo.ImageLink as PATImageLink 
                                FROM [dbo].[psPatRegisters] as registration
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData 
                                LEFT JOIN [dbo].[emdPatients] as patient on patient.PK_emdPatients = consultation.FK_emdPatients
                                JOIN [dbo].[psPersonaldata] as patientInfo on patient.PK_emdPatients = patientInfo.PK_psPersonalData 
                                JOIN [dbo].[psDatacenter] as patientMoreInfo on patient.PK_emdPatients = patientMoreInfo.PK_psDatacenter 
                                WHERE registration.PK_psPatRegisters = @regID AND assignDoctor.prcno = @rodprc
                                ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@regID", regID)
            cmd.Parameters.AddWithValue("@rodprc", rodprc)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim registration As New Bizbox_PatientDailyRegistration
                registration.ID = data.Rows(0)("ID")
                registration.ConsultationID = data.Rows(0)("ConsultationID")
                registration.RegistrationDate = data.Rows(0)("RegistryDate")
                registration.RegistrationType = data.Rows(0)("TransactionType")
                registration.ChiefComplaint = If(Not IsDBNull(data.Rows(0)("ChiefComplaint")), data.Rows(0)("ChiefComplaint"), "")
                registration.HistoryOfPresentIllness = If(Not IsDBNull(data.Rows(0)("HistoryOfPresentIllness")), data.Rows(0)("HistoryOfPresentIllness"), "")
                registration.PertinentPhysicalExamination = (If(Not IsDBNull(data.Rows(0)("PertinentPhysicalExam")), data.Rows(0)("PertinentPhysicalExam"), ""))
                registration.WorkingDiagnosis = (If(Not IsDBNull(data.Rows(0)("WorkingDiagnosis")), data.Rows(0)("WorkingDiagnosis"), ""))
                registration.DischargeDiagnosis = (If(Not IsDBNull((data.Rows(0)("DischargeDiagnosis"))), data.Rows(0)("DischargeDiagnosis"), ""))
                registration.FinalDiagnosis = (If(Not IsDBNull((data.Rows(0)("FinalDiagnosis"))), data.Rows(0)("FinalDiagnosis"), ""))
                registration.Treatment = (If(Not IsDBNull((data.Rows(0)("Treatment"))), data.Rows(0)("Treatment"), ""))
                registration.Impression = (If(Not IsDBNull((data.Rows(0)("Impression"))), data.Rows(0)("Impression"), ""))
                registration.Remarks = (If(Not IsDBNull((data.Rows(0)("Remarks"))), data.Rows(0)("Remarks"), ""))
                registration.Height1 = (If(Not IsDBNull((data.Rows(0)("InitialHeight1"))), data.Rows(0)("InitialHeight1"), 0))
                registration.Height2 = (If(Not IsDBNull((data.Rows(0)("InitialHeight2"))), data.Rows(0)("InitialHeight2"), 0))
                registration.Weight = (If(Not IsDBNull((data.Rows(0)("InitialWeight"))), data.Rows(0)("InitialWeight"), 0))
                registration.HeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialHeightUnit"))), data.Rows(0)("InitialHeightUnit"), ""))
                registration.WeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialWeightUnit"))), data.Rows(0)("InitialWeightUnit"), ""))
                registration.PulseRate = (If(Not IsDBNull((data.Rows(0)("PulseRate"))), data.Rows(0)("PulseRate"), 0))
                registration.RespiratoryRate = (If(Not IsDBNull((data.Rows(0)("RespiratoryRate"))), data.Rows(0)("RespiratoryRate"), 0))
                registration.Temparature = (If(Not IsDBNull((data.Rows(0)("Temparature"))), data.Rows(0)("Temparature"), 0))
                registration.Systolic = (If(Not IsDBNull((data.Rows(0)("Systolic"))), data.Rows(0)("Systolic"), 0))
                registration.Diastolic = (If(Not IsDBNull((data.Rows(0)("Diastolic"))), data.Rows(0)("Diastolic"), 0))
                registration.DoleEmpNo = (If(Not IsDBNull((data.Rows(0)("DoleEmployeeNo"))), data.Rows(0)("DoleEmployeeNo"), ""))
                registration.DoleRefNO = (If(Not IsDBNull((data.Rows(0)("DoleReferenceNo"))), data.Rows(0)("DoleReferenceNo"), ""))
                registration.DoleAppStat = (If(Not IsDBNull((data.Rows(0)("DoleType"))), data.Rows(0)("DoleType"), ""))
                registration.ConsultationIn = If(Not IsDBNull((data.Rows(0)("ConsultationIN"))), data.Rows(0)("ConsultationIN"), Nothing)
                registration.ConsultationOut = If(Not IsDBNull((data.Rows(0)("ConsultationOUT"))), data.Rows(0)("ConsultationOUT"), Nothing)
                registration.PatientData = New Bizbox_PatientPersonalData
                registration.PatientData.PatientID = (If(Not IsDBNull((data.Rows(0)("PATInfoID"))), data.Rows(0)("PATInfoID"), 0))
                registration.PatientData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.PatientData.MiddleName = (If(Not IsDBNull((data.Rows(0)("PATMiddlename"))), data.Rows(0)("PATMiddlename"), ""))
                registration.PatientData.Lastname = (If(Not IsDBNull((data.Rows(0)("PATLastname"))), data.Rows(0)("PATLastname"), ""))
                registration.PatientData.SuffixName = (If(Not IsDBNull((data.Rows(0)("PATSuffixname"))), data.Rows(0)("PATSuffixname"), ""))
                registration.PatientData.FullName = (If(Not IsDBNull((data.Rows(0)("PATFullname1"))), data.Rows(0)("PATFullname1"), ""))
                registration.PatientData.AddressPt1 = (If(Not IsDBNull((data.Rows(0)("PATAddress1"))), data.Rows(0)("PATAddress1"), ""))
                registration.PatientData.AddressPt2 = (If(Not IsDBNull((data.Rows(0)("PATAddress2"))), data.Rows(0)("PATAddress2"), ""))
                registration.PatientData.AddressPt3 = (If(Not IsDBNull((data.Rows(0)("PATAddress3"))), data.Rows(0)("PATAddress3"), ""))
                registration.PatientData.FullAddress = (If(Not IsDBNull((data.Rows(0)("PATFullAddress"))), data.Rows(0)("PATFullAddress"), ""))
                registration.PatientData.Gender = (If(Not IsDBNull((data.Rows(0)("PATGender"))), data.Rows(0)("PATGender"), ""))
                registration.PatientData.BirthDate = (If(Not IsDBNull((data.Rows(0)("PATBirthDate"))), data.Rows(0)("PATBirthDate"), Nothing))
                registration.PatientData.CivilStatus = (If(Not IsDBNull((data.Rows(0)("PATCivilStatus"))), data.Rows(0)("PATCivilStatus"), ""))
                registration.PatientData.Nationality = (If(Not IsDBNull((data.Rows(0)("PATNationality"))), data.Rows(0)("PATNationality"), ""))
                registration.PatientData.MobileNo1 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo1"))), data.Rows(0)("PATMobileNo1"), ""))
                registration.PatientData.MobileNo2 = (If(Not IsDBNull((data.Rows(0)("PATMobileNo2"))), data.Rows(0)("PATMobileNo2"), ""))
                registration.PatientData.ImageLink = (If(Not IsDBNull((data.Rows(0)("PATImageLink"))), data.Rows(0)("PATImageLink"), ""))
                registration.DoctorData = New Bizbox_DoctorsInfo
                registration.DoctorData.ID = (If(Not IsDBNull((data.Rows(0)("RODInfoID"))), data.Rows(0)("RODInfoID"), 0))
                registration.DoctorData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.DoctorData.MiddleName = (If(Not IsDBNull((data.Rows(0)("RODMiddlename"))), data.Rows(0)("RODMiddlename"), ""))
                registration.DoctorData.Lastname = (If(Not IsDBNull((data.Rows(0)("RODLastname"))), data.Rows(0)("RODLastname"), ""))
                registration.DoctorData.SuffixName = (If(Not IsDBNull((data.Rows(0)("RODSuffix"))), data.Rows(0)("RODSuffix"), ""))
                registration.DoctorData.ContactNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Specialization = ""
                registration.DoctorData.PRC = (If(Not IsDBNull((data.Rows(0)("RODPRC"))), data.Rows(0)("RODPRC"), ""))
                registration.DoctorData.PTR = (If(Not IsDBNull((data.Rows(0)("RODPTR"))), data.Rows(0)("RODPTR"), ""))
                registration.DoctorData.S2No = (If(Not IsDBNull((data.Rows(0)("RODS2"))), data.Rows(0)("RODS2"), ""))
                registration.DoctorData.MobileNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Email = (If(Not IsDBNull((data.Rows(0)("RODEmail"))), data.Rows(0)("RODEmail"), ""))
                registration.DoctorData.ImageLink = (If(Not IsDBNull((data.Rows(0)("RODImageLink"))), data.Rows(0)("RODImageLink"), ""))
                registration.DoctorData.SignatureLocation = ""
                registration.FinalDiagnosisByICD10 = Me.GetPatientFinalDiagnosisByICD10(registration.ConsultationID)
                registration.Plans = Me.GetPatientConsultationsPlans(registration.ConsultationID)
                registration.SickLeaves = Me.GetPatientConsultationSickLeave(registration.ConsultationID)
                registration.BizboxConsultation = New CustomerConsultationController().GetIfExistConsultation2(registration.ID, registration.DoctorData.PRC)
                Return registration
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientConsultationSickLeave(ByVal ID As Long) As List(Of Bizbox_ConsultationSickLeave)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT [PK_emdSOAPSickLeave] as ID,[FK_emdSOAPTranMstr] as ConsultationID,[StartDate] as StartDate,[EndDate] as EndDate,[ComputedDays] as ComputedDays 
                                FROM [dbo].[emdSOAPSickLeave] WHERE FK_emdSOAPTranMstr = @ID ORDER By PK_emdSOAPSickLeave ASC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_ConsultationSickLeave)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_ConsultationSickLeave
                    item.ID = (row("ID"))
                    item.ConsultationID = (row("ConsultationID"))
                    item.StartDate = (row("StartDate"))
                    item.EndDate = (row("EndDate"))
                    item.ComputedDays = (row("ComputedDays"))
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientConsultationRequisitions(registerID As Long) As List(Of PatientBizbox_PatItems)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT PK_psPatitem,FK_iwItemsREN,FK_iwItemsREQ,
                                x.itemdesc as 'renitemdesc',x.itemabbrev as 'renitemabbrev',x.specs as 'renspecs',
                                c.itemdesc as 'reqitemdesc',c.itemabbrev as 'reqitemabbrev',c.specs as 'reqspecs',
                                description,reqprice,reqqty,renprice,renqty,renflag,z.cancelflag as 'reqCancelled',
                                dbo.udf_getfullname(z.FK_ASUReqUser) as 'renderinguser',
                                dbo.udf_GetDepartmentName(a.FK_mscWarehouse) as 'reqdept'
                                FROM [dbo].[psPatitem] as a 
                                JOIN [dbo].[psPatRegisters] as b on b.PK_psPatRegisters = a.FK_psPatRegisters 
                                LEFT JOIN [dbo].[iwItems] as c on c.PK_iwItems = a.FK_iwItemsREN
                                LEFT JOIN [dbo].[iwItems] as x on x.PK_iwItems = a.FK_iwItemsREQ
                                LEFT JOIN [dbo].[mscItemCategory] as d on d.PK_mscItemCategory = c.FK_mscItemCategory
                                LEFT JOIN [dbo].[psPatinv] as z on z.PK_TRXNO = a.FK_TRXNO
                                LEFT JOIN emdDoctors as f on f.PK_emdDoctors = z.FK_ASUReqUser
                                WHERE renqty >= 0 AND (a.FK_psPatRegisters = @patreg);"
            }
            cmd.Parameters.AddWithValue("@patreg", registerID)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBizbox_PatItems)
                For Each row As DataRow In data.Rows
                    Dim transaction As New PatientBizbox_PatItems
                    transaction.PK_psPatItems = row("PK_psPatitem")
                    transaction.FK_iwItemsREN = If(Not IsDBNull(row("FK_iwItemsREN")), row("FK_iwItemsREN"), row("FK_iwItemsREQ"))
                    transaction.ItemDescription = If(Not IsDBNull(row("renitemdesc")), row("renitemdesc"), row("reqitemdesc"))
                    transaction.ItemAbbreviation = If(Not IsDBNull(row("renitemabbrev")), row("renitemabbrev"), row("reqitemabbrev"))
                    transaction.ItemPreparation = If(Not IsDBNull(row("renspecs")), row("renspecs"), If(Not IsDBNull(row("reqspecs")), row("reqspecs"), ""))
                    transaction.DepartmentOfService = If(Not IsDBNull(row("reqdept")), row("reqdept"), "")
                    transaction.RequestorName = If(Not IsDBNull(row("renderinguser")), row("renderinguser"), "")
                    transaction.RequestPrice = If(Not IsDBNull(row("reqprice")), row("reqprice"), 0)
                    transaction.RequestQTY = If(Not IsDBNull(row("reqqty")), row("reqqty"), 0)
                    transaction.RenderPrice = If(Not IsDBNull(row("renprice")), row("renprice"), 0)
                    transaction.RenderQTY = If(Not IsDBNull(row("renqty")), row("renqty"), 0)
                    transaction.isRequestCancelled = If(Not IsDBNull(row("reqCancelled")), row("reqCancelled"), 0)
                    transaction.isRendered = row("renflag")
                    lisOfTransactions.Add(transaction)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientConsultationRequisitions(registerID As Long, prcNo As String) As List(Of PatientBizbox_PatItems)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT PK_psPatitem,FK_iwItemsREN,FK_iwItemsREQ,
                                x.itemdesc as 'renitemdesc',x.itemabbrev as 'renitemabbrev',x.specs as 'renspecs',
                                c.itemdesc as 'reqitemdesc',c.itemabbrev as 'reqitemabbrev',c.specs as 'reqspecs',
                                description,reqprice,reqqty,renprice,renqty,renflag,z.cancelflag as 'reqCancelled',
                                dbo.udf_getfullname(z.FK_ASUReqUser) as 'renderinguser',
                                dbo.udf_GetDepartmentName(a.FK_mscWarehouse) as 'reqdept',
								a.FK_mscWarehouse as 'deptcode'
                                FROM [dbo].[psPatitem] as a 
                                JOIN [dbo].[psPatRegisters] as b on b.PK_psPatRegisters = a.FK_psPatRegisters 
                                LEFT JOIN [dbo].[iwItems] as c on c.PK_iwItems = a.FK_iwItemsREN
                                LEFT JOIN [dbo].[iwItems] as x on x.PK_iwItems = a.FK_iwItemsREQ
                                LEFT JOIN [dbo].[mscItemCategory] as d on d.PK_mscItemCategory = c.FK_mscItemCategory
                                LEFT JOIN [dbo].[psPatinv] as z on z.PK_TRXNO = a.FK_TRXNO
                                LEFT JOIN emdDoctors as f on f.PK_emdDoctors = z.FK_ASUReqUser
                                WHERE renqty >= 0 AND (f.prcno = @prcno AND a.FK_psPatRegisters = @patreg);"
            }
            cmd.Parameters.AddWithValue("@patreg", registerID)
            cmd.Parameters.AddWithValue("@prcno", prcNo)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBizbox_PatItems)
                For Each row As DataRow In data.Rows
                    Dim transaction As New PatientBizbox_PatItems
                    transaction.PK_psPatItems = row("PK_psPatitem")
                    transaction.FK_iwItemsREN = If(Not IsDBNull(row("FK_iwItemsREN")), row("FK_iwItemsREN"), row("FK_iwItemsREQ"))
                    transaction.ItemDescription = If(Not IsDBNull(row("renitemdesc")), row("renitemdesc"), row("reqitemdesc"))
                    transaction.ItemAbbreviation = If(Not IsDBNull(row("renitemabbrev")), row("renitemabbrev"), row("reqitemabbrev"))
                    transaction.ItemPreparation = If(Not IsDBNull(row("renspecs")), row("renspecs"), If(Not IsDBNull(row("reqspecs")), row("reqspecs"), ""))
                    transaction.DepartmentOfService = If(Not IsDBNull(row("reqdept")), row("reqdept"), "")
                    transaction.DepartmentCode = If(Not IsDBNull(row("deptcode")), row("deptcode").ToString.Trim, "")
                    transaction.RequestorName = If(Not IsDBNull(row("renderinguser")), row("renderinguser"), "")
                    transaction.RequestPrice = If(Not IsDBNull(row("reqprice")), row("reqprice"), 0)
                    transaction.RequestQTY = If(Not IsDBNull(row("reqqty")), row("reqqty"), 0)
                    transaction.RenderPrice = If(Not IsDBNull(row("renprice")), row("renprice"), 0)
                    transaction.RenderQTY = If(Not IsDBNull(row("renqty")), row("renqty"), 0)
                    transaction.isRequestCancelled = If(Not IsDBNull(row("reqCancelled")), row("reqCancelled"), 0)
                    transaction.isRendered = row("renflag")
                    lisOfTransactions.Add(transaction)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientConsultationsPlans(ByVal ID As Long) As List(Of Bizbox_ConsultationPlan)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT [PK_emdSOAPPlans] as ID,[FK_emdSOAPTranMstr] as ConsultationID,[plangrp] as PlanGroup,[FK_emdDoctors] as DoctorID,[FK_emdPatients] as PatientID,[rxlineitem] as PlanDescription,[FK_mscICD10Mstr] as ICD10ID
                                FROM [dbo].[emdSOAPPlans] " & ChrW(13) & ChrW(10) & "                               
                                Where FK_emdSOAPTranMstr = @ID ORDER BY PlanGroup,ID ASC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_ConsultationPlan)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_ConsultationPlan With {
                        .ID = (row("ID")),
                        .ConsultationID = (row("ConsultationID")),
                        .PlanGroup = (If(Not IsDBNull((row("PlanGroup"))), row("PlanGroup"), "")),
                        .PlanGroupAbrev = Me.DeterminePlanType((If(Not IsDBNull((row("PlanGroup"))), row("PlanGroup"), ""))),
                        .DoctorsID = (row("DoctorID")),
                        .PatientID = (row("PatientID")),
                        .PlanDescription = (If(Not IsDBNull((row("PlanDescription"))), row("PlanDescription"), "")),
                        .ICD10 = (If(Not IsDBNull((row("ICD10ID"))), row("ICD10ID"), ""))
                    }
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientFinalDiagnosisByICD10(ByVal ID As Long) As List(Of Bizbox_FinalDiagnosisICD10)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "  SELECT PK_psPatFinalDXDtls as ID,FK_psPatRegisters as ConsultationID,FK_mscICD10Mstr as ICD10MasterID,description as Description 
                                  FROM psPatFinalDXDtls WHERE FK_psPatRegisters=@ID ORDER BY ID ASC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_FinalDiagnosisICD10)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_FinalDiagnosisICD10 With {
                            .ID = (row("ID")),
                            .ConsultationID = (row("ConsultationID")),
                            .ICD10MasterID = (row("ICD10MasterID")),
                            .Description = (row("Description"))
                        }
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientLatestConsultations(ByVal ID As Long) As Bizbox_PatientDailyRegistration
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType, consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment, assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink 
                                FROM [dbo].[psPatRegisters] as registration 
                                LEFT JOIN [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters 
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors 
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData 
                                WHERE registration.FK_emdPatients = @ID ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim registration As New Bizbox_PatientDailyRegistration
                registration.ID = (data.Rows(0)("ID"))
                registration.ConsultationID = (data.Rows(0)("ConsultationID"))
                registration.RegistrationDate = (data.Rows(0)("RegistryDate"))
                registration.RegistrationType = (data.Rows(0)("TransactionType"))
                registration.ChiefComplaint = (If(Not IsDBNull((data.Rows(0)("ChiefComplaint"))), data.Rows(0)("ChiefComplaint"), ""))
                registration.HistoryOfPresentIllness = (If(Not IsDBNull((data.Rows(0)("HistoryOfPresentIllness"))), data.Rows(0)("HistoryOfPresentIllness"), ""))
                registration.PertinentPhysicalExamination = (If(Not IsDBNull((data.Rows(0)("PertinentPhysicalExam"))), data.Rows(0)("PertinentPhysicalExam"), ""))
                registration.WorkingDiagnosis = (If(Not IsDBNull((data.Rows(0)("WorkingDiagnosis"))), data.Rows(0)("WorkingDiagnosis"), ""))
                registration.DischargeDiagnosis = (If(Not IsDBNull((data.Rows(0)("DischargeDiagnosis"))), data.Rows(0)("DischargeDiagnosis"), ""))
                registration.FinalDiagnosis = (If(Not IsDBNull((data.Rows(0)("FinalDiagnosis"))), data.Rows(0)("FinalDiagnosis"), ""))
                registration.Treatment = (If(Not IsDBNull((data.Rows(0)("Treatment"))), data.Rows(0)("Treatment"), ""))
                registration.Impression = (If(Not IsDBNull((data.Rows(0)("Impression"))), data.Rows(0)("Impression"), ""))
                registration.Remarks = (If(Not IsDBNull((data.Rows(0)("Remarks"))), data.Rows(0)("Remarks"), ""))
                registration.Height1 = (If(Not IsDBNull((data.Rows(0)("InitialHeight1"))), data.Rows(0)("InitialHeight1"), 0))
                registration.Height2 = (If(Not IsDBNull((data.Rows(0)("InitialHeight2"))), data.Rows(0)("InitialHeight2"), 0))
                registration.Weight = (If(Not IsDBNull((data.Rows(0)("InitialWeight"))), data.Rows(0)("InitialWeight"), 0))
                registration.HeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialHeightUnit"))), data.Rows(0)("InitialHeightUnit"), ""))
                registration.WeightUnit = (If(Not IsDBNull((data.Rows(0)("InitialWeightUnit"))), data.Rows(0)("InitialWeightUnit"), ""))
                registration.PulseRate = (If(Not IsDBNull((data.Rows(0)("PulseRate"))), data.Rows(0)("PulseRate"), 0))
                registration.RespiratoryRate = (If(Not IsDBNull((data.Rows(0)("RespiratoryRate"))), data.Rows(0)("RespiratoryRate"), 0))
                registration.Temparature = (If(Not IsDBNull((data.Rows(0)("Temparature"))), data.Rows(0)("Temparature"), 0))
                registration.Systolic = (If(Not IsDBNull((data.Rows(0)("Systolic"))), data.Rows(0)("Systolic"), 0))
                registration.Diastolic = (If(Not IsDBNull((data.Rows(0)("Diastolic"))), data.Rows(0)("Diastolic"), 0))
                registration.DoleEmpNo = (If(Not IsDBNull((data.Rows(0)("DoleEmployeeNo"))), data.Rows(0)("DoleEmployeeNo"), ""))
                registration.DoleRefNO = (If(Not IsDBNull((data.Rows(0)("DoleReferenceNo"))), data.Rows(0)("DoleReferenceNo"), ""))
                registration.DoleAppStat = (If(Not IsDBNull((data.Rows(0)("DoleType"))), data.Rows(0)("DoleType"), ""))
                registration.ConsultationIn = If(Not IsDBNull((data.Rows(0)("ConsultationIN"))), data.Rows(0)("ConsultationIN"), Nothing)
                registration.ConsultationOut = If(Not IsDBNull((data.Rows(0)("ConsultationOUT"))), data.Rows(0)("ConsultationOUT"), Nothing)
                registration.DoctorData = New Bizbox_DoctorsInfo
                registration.DoctorData.ID = (If(Not IsDBNull((data.Rows(0)("RODInfoID"))), data.Rows(0)("RODInfoID"), 0))
                registration.DoctorData.Firstname = (If(Not IsDBNull((data.Rows(0)("RODFirstname"))), data.Rows(0)("RODFirstname"), ""))
                registration.DoctorData.MiddleName = (If(Not IsDBNull((data.Rows(0)("RODMiddlename"))), data.Rows(0)("RODMiddlename"), ""))
                registration.DoctorData.Lastname = (If(Not IsDBNull((data.Rows(0)("RODLastname"))), data.Rows(0)("RODLastname"), ""))
                registration.DoctorData.SuffixName = (If(Not IsDBNull((data.Rows(0)("RODSuffix"))), data.Rows(0)("RODSuffix"), ""))
                registration.DoctorData.ContactNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Specialization = ""
                registration.DoctorData.PTR = (If(Not IsDBNull((data.Rows(0)("RODPRC"))), data.Rows(0)("RODPRC"), ""))
                registration.DoctorData.PRC = (If(Not IsDBNull((data.Rows(0)("RODPTR"))), data.Rows(0)("RODPTR"), ""))
                registration.DoctorData.S2No = (If(Not IsDBNull((data.Rows(0)("RODS2"))), data.Rows(0)("RODS2"), ""))
                registration.DoctorData.MobileNo = (If(Not IsDBNull((data.Rows(0)("RODMobileNo"))), data.Rows(0)("RODMobileNo"), ""))
                registration.DoctorData.Email = (If(Not IsDBNull((data.Rows(0)("RODEmail"))), data.Rows(0)("RODEmail"), ""))
                registration.DoctorData.ImageLink = (If(Not IsDBNull((data.Rows(0)("RODImageLink"))), data.Rows(0)("RODImageLink"), ""))
                registration.DoctorData.SignatureLocation = ""
                registration.Plans = Me.GetPatientConsultationsPlans(registration.ConsultationID)
                registration.Plans = Me.GetPatientConsultationsPlans(registration.ConsultationID)
                registration.SickLeaves = Me.GetPatientConsultationSickLeave(registration.ConsultationID)
                Return registration
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientMainData(ByVal ID As Long) As Bizbox_PatientPersonalData
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
                               --comaddress,                  
                               cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,             
                               --empaddress,  
                               --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
                               --icaddress, icstreet,                                 
                               --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
                               --nkaddress,
                               --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
                               --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
                               --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
                               gender,birthdate,civilstatus,mobilephone,mobilephone2, ImageLink
                               FROM psDatacenter AS a 
                               INNER JOIN emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients 
                               INNER JOIN psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData  
                               WHERE (PK_psPersonalData = @ID and PK_emdPatients = @ID)"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                If (data.Rows.Count > 0) Then
                    Return New Bizbox_PatientPersonalData With {
                       .PatientID = (data.Rows(0)("PK_psPersonalData")),
                       .Firstname = (data.Rows(0)("firstname")),
                       .MiddleName = (data.Rows(0)("middlename")),
                       .Lastname = (data.Rows(0)("suffixname")),
                       .SuffixName = (data.Rows(0)("suffixname")),
                       .FullName = (data.Rows(0)("fullname")),
                       .AddressPt1 = (data.Rows(0)("prstreetbldg1")),
                       .AddressPt2 = (data.Rows(0)("prstreetbldg2")),
                       .AddressPt3 = (data.Rows(0)("prstreetbldg3")),
                       .FullAddress = (data.Rows(0)("praddress")),
                       .Gender = (data.Rows(0)("gender")),
                       .BirthDate = (data.Rows(0)("birthdate")),
                       .CivilStatus = (data.Rows(0)("civilstatus")),
                       .Nationality = (data.Rows(0)("nationality")),
                       .MobileNo1 = (data.Rows(0)("mobilephone")),
                       .MobileNo2 = (data.Rows(0)("mobilephone2")),
                       .ImageLink = (data.Rows(0)("ImageLink"))
                   }
                End If
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientRegistrations(ByVal ID As Long) As List(Of Bizbox_PatientDailyRegistration)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType, consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment, assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink 
                                FROM [dbo].[psPatRegisters] as registration                      
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData
                                WHERE registration.FK_emdPatients = @ID
                                ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_PatientDailyRegistration)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_PatientDailyRegistration
                    item.ID = (row("ID"))
                    item.ConsultationID = (row("ConsultationID"))
                    item.RegistrationDate = (row("RegistryDate"))
                    item.RegistrationType = (row("TransactionType"))
                    item.ChiefComplaint = (If(Not IsDBNull((row("ChiefComplaint"))), row("ChiefComplaint"), ""))
                    item.HistoryOfPresentIllness = (If(Not IsDBNull((row("HistoryOfPresentIllness"))), row("HistoryOfPresentIllness"), ""))
                    item.PertinentPhysicalExamination = (If(Not IsDBNull((row("PertinentPhysicalExam"))), row("PertinentPhysicalExam"), ""))
                    item.WorkingDiagnosis = (If(Not IsDBNull((row("WorkingDiagnosis"))), row("WorkingDiagnosis"), ""))
                    item.DischargeDiagnosis = (If(Not IsDBNull((row("DischargeDiagnosis"))), row("DischargeDiagnosis"), ""))
                    item.FinalDiagnosis = (If(Not IsDBNull((row("FinalDiagnosis"))), row("FinalDiagnosis"), ""))
                    item.Treatment = (If(Not IsDBNull((row("Treatment"))), row("Treatment"), ""))
                    item.Impression = (If(Not IsDBNull((row("Impression"))), row("Impression"), ""))
                    item.Remarks = (If(Not IsDBNull((row("Remarks"))), row("Remarks"), ""))
                    item.Height1 = (If(Not IsDBNull((row("InitialHeight1"))), row("InitialHeight1"), 0))
                    item.Height2 = (If(Not IsDBNull((row("InitialHeight2"))), row("InitialHeight2"), 0))
                    item.Weight = (If(Not IsDBNull((row("InitialWeight"))), row("InitialWeight"), 0))
                    item.HeightUnit = (If(Not IsDBNull((row("InitialHeightUnit"))), row("InitialHeightUnit"), ""))
                    item.WeightUnit = (If(Not IsDBNull((row("InitialWeightUnit"))), row("InitialWeightUnit"), ""))
                    item.PulseRate = (If(Not IsDBNull((row("PulseRate"))), row("PulseRate"), 0))
                    item.RespiratoryRate = (If(Not IsDBNull((row("RespiratoryRate"))), row("RespiratoryRate"), 0))
                    item.Temparature = (If(Not IsDBNull((row("Temparature"))), row("Temparature"), 0))
                    item.Systolic = (If(Not IsDBNull((row("Systolic"))), row("Systolic"), 0))
                    item.Diastolic = (If(Not IsDBNull((row("Diastolic"))), row("Diastolic"), 0))
                    item.DoleEmpNo = (If(Not IsDBNull((row("DoleEmployeeNo"))), row("DoleEmployeeNo"), ""))
                    item.DoleRefNO = (If(Not IsDBNull((row("DoleReferenceNo"))), row("DoleReferenceNo"), ""))
                    item.DoleAppStat = (If(Not IsDBNull((row("DoleType"))), row("DoleType"), ""))
                    item.ConsultationIn = If(Not IsDBNull((row("ConsultationIN"))), row("ConsultationIN"), Nothing)
                    item.ConsultationOut = If(Not IsDBNull((row("ConsultationOUT"))), row("ConsultationOUT"), Nothing)
                    item.DoctorData = New Bizbox_DoctorsInfo
                    item.DoctorData.ID = (If(Not IsDBNull((row("RODInfoID"))), row("RODInfoID"), 0))
                    item.DoctorData.Firstname = (If(Not IsDBNull((row("RODFirstname"))), row("RODFirstname"), ""))
                    item.DoctorData.MiddleName = (If(Not IsDBNull((row("RODMiddlename"))), row("RODMiddlename"), ""))
                    item.DoctorData.Lastname = (If(Not IsDBNull((row("RODLastname"))), row("RODLastname"), ""))
                    item.DoctorData.SuffixName = (If(Not IsDBNull((row("RODSuffix"))), row("RODSuffix"), ""))
                    item.DoctorData.ContactNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Specialization = ""
                    item.DoctorData.PRC = (If(Not IsDBNull((row("RODPRC"))), row("RODPRC"), ""))
                    item.DoctorData.PTR = (If(Not IsDBNull((row("RODPTR"))), row("RODPTR"), ""))
                    item.DoctorData.S2No = (If(Not IsDBNull((row("RODS2"))), row("RODS2"), ""))
                    item.DoctorData.MobileNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Email = (If(Not IsDBNull((row("RODEmail"))), row("RODEmail"), ""))
                    item.DoctorData.ImageLink = (If(Not IsDBNull((row("RODImageLink"))), row("RODImageLink"), ""))
                    item.DoctorData.SignatureLocation = ""
                    item.FinalDiagnosisByICD10 = Me.GetPatientFinalDiagnosisByICD10(item.ConsultationID)
                    item.Plans = Me.GetPatientConsultationsPlans(item.ConsultationID)
                    item.SickLeaves = Me.GetPatientConsultationSickLeave(item.ConsultationID)
                    item.BizboxConsultation = New CustomerConsultationController().GetIfExistConsultation(item.ID)
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientRegistrations2(ByVal ID As Long) As List(Of Bizbox_PatientDailyRegistration)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT TOP 10 registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType, consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment, assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink 
                                FROM [dbo].[psPatRegisters] as registration                      
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData
                                WHERE registration.FK_emdPatients = @ID
                                ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_PatientDailyRegistration)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_PatientDailyRegistration
                    item.ID = (row("ID"))
                    item.ConsultationID = (row("ConsultationID"))
                    item.RegistrationDate = (row("RegistryDate"))
                    item.RegistrationType = (row("TransactionType"))
                    item.ChiefComplaint = (If(Not IsDBNull((row("ChiefComplaint"))), row("ChiefComplaint"), ""))
                    item.HistoryOfPresentIllness = (If(Not IsDBNull((row("HistoryOfPresentIllness"))), row("HistoryOfPresentIllness"), ""))
                    item.PertinentPhysicalExamination = (If(Not IsDBNull((row("PertinentPhysicalExam"))), row("PertinentPhysicalExam"), ""))
                    item.WorkingDiagnosis = (If(Not IsDBNull((row("WorkingDiagnosis"))), row("WorkingDiagnosis"), ""))
                    item.DischargeDiagnosis = (If(Not IsDBNull((row("DischargeDiagnosis"))), row("DischargeDiagnosis"), ""))
                    item.FinalDiagnosis = (If(Not IsDBNull((row("FinalDiagnosis"))), row("FinalDiagnosis"), ""))
                    item.Treatment = (If(Not IsDBNull((row("Treatment"))), row("Treatment"), ""))
                    item.Impression = (If(Not IsDBNull((row("Impression"))), row("Impression"), ""))
                    item.Remarks = (If(Not IsDBNull((row("Remarks"))), row("Remarks"), ""))
                    item.Height1 = (If(Not IsDBNull((row("InitialHeight1"))), row("InitialHeight1"), 0))
                    item.Height2 = (If(Not IsDBNull((row("InitialHeight2"))), row("InitialHeight2"), 0))
                    item.Weight = (If(Not IsDBNull((row("InitialWeight"))), row("InitialWeight"), 0))
                    item.HeightUnit = (If(Not IsDBNull((row("InitialHeightUnit"))), row("InitialHeightUnit"), ""))
                    item.WeightUnit = (If(Not IsDBNull((row("InitialWeightUnit"))), row("InitialWeightUnit"), ""))
                    item.PulseRate = (If(Not IsDBNull((row("PulseRate"))), row("PulseRate"), 0))
                    item.RespiratoryRate = (If(Not IsDBNull((row("RespiratoryRate"))), row("RespiratoryRate"), 0))
                    item.Temparature = (If(Not IsDBNull((row("Temparature"))), row("Temparature"), 0))
                    item.Systolic = (If(Not IsDBNull((row("Systolic"))), row("Systolic"), 0))
                    item.Diastolic = (If(Not IsDBNull((row("Diastolic"))), row("Diastolic"), 0))
                    item.DoleEmpNo = (If(Not IsDBNull((row("DoleEmployeeNo"))), row("DoleEmployeeNo"), ""))
                    item.DoleRefNO = (If(Not IsDBNull((row("DoleReferenceNo"))), row("DoleReferenceNo"), ""))
                    item.DoleAppStat = (If(Not IsDBNull((row("DoleType"))), row("DoleType"), ""))
                    item.ConsultationIn = If(Not IsDBNull((row("ConsultationIN"))), row("ConsultationIN"), Nothing)
                    item.ConsultationOut = If(Not IsDBNull((row("ConsultationOUT"))), row("ConsultationOUT"), Nothing)
                    item.DoctorData = New Bizbox_DoctorsInfo
                    item.DoctorData.ID = (If(Not IsDBNull((row("RODInfoID"))), row("RODInfoID"), 0))
                    item.DoctorData.Firstname = (If(Not IsDBNull((row("RODFirstname"))), row("RODFirstname"), ""))
                    item.DoctorData.MiddleName = (If(Not IsDBNull((row("RODMiddlename"))), row("RODMiddlename"), ""))
                    item.DoctorData.Lastname = (If(Not IsDBNull((row("RODLastname"))), row("RODLastname"), ""))
                    item.DoctorData.SuffixName = (If(Not IsDBNull((row("RODSuffix"))), row("RODSuffix"), ""))
                    item.DoctorData.ContactNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Specialization = ""
                    item.DoctorData.PRC = (If(Not IsDBNull((row("RODPRC"))), row("RODPRC"), ""))
                    item.DoctorData.PTR = (If(Not IsDBNull((row("RODPTR"))), row("RODPTR"), ""))
                    item.DoctorData.S2No = (If(Not IsDBNull((row("RODS2"))), row("RODS2"), ""))
                    item.DoctorData.MobileNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Email = (If(Not IsDBNull((row("RODEmail"))), row("RODEmail"), ""))
                    item.DoctorData.ImageLink = (If(Not IsDBNull((row("RODImageLink"))), row("RODImageLink"), ""))
                    item.DoctorData.SignatureLocation = ""
                    item.FinalDiagnosisByICD10 = Me.GetPatientFinalDiagnosisByICD10(item.ConsultationID)
                    item.Plans = Me.GetPatientConsultationsPlans(item.ConsultationID)
                    item.SickLeaves = Me.GetPatientConsultationSickLeave(item.ConsultationID)
                    item.BizboxConsultation = New CustomerConsultationController().GetIfExistConsultation2(item.ID, item.DoctorData.PRC)
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientVitalSummary(ByVal ID As Long) As List(Of Bizbox_PatientDailyRegistration)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT TOP 5
                                registration.PK_psPatRegisters as ID, registration.registrydate as RegistryDate, registration.pattrantype as TransactionType, registration.chiefcomplaint as ChiefComplaint, registration.impression as Impression, registration.dischdiagnosis as DischargeDiagnosis, registration.finaldiagnosis as FinalDiagnosis, registration.remarks as Remarks, registration.height1 as InitialHeight1, registration.height2 as InitialHeight2, registration.height3 as InitialHeight3, registration.heightUnit as InitialHeightUnit,  registration.weight as InitialWeight, registration.weightUnit as InitialWeightUnit, registration.DOLEEmpNo as DoleEmployeeNo, registration.DOLERefNo as DoleReferenceNo, registration.DOLEAppStat as DoleType,                              
                                consultation.PK_emdSOAPTranMstr as ConsultationID, consultation.height as Height, consultation.weight as Weight, consultation.bloodpressure as Systolic, consultation.bloodpressureovr as Diastolic, consultation.pulserate as PulseRate, consultation.resprate as RespiratoryRate, consultation.bodytemp as Temparature, consultation.consultationin as ConsultationIN, consultation.consultationout as ConsultationOUT, consultation.asswdx as WorkingDiagnosis, consultation.objppe as PertinentPhysicalExam, consultation.subjhpi as HistoryOfPresentIllness, consultation.treatment AS Treatment,
                                assignDoctorInfo.PK_psPersonalData as RODInfoID, assignDoctor.PK_emdDoctors as RODID, assignDoctorInfo.firstname as RODFirstname, assignDoctorInfo.middlename as RODMiddlename, assignDoctorInfo.lastname as RODLastname, assignDoctorInfo.suffixname as RODSuffix, assignDoctor.specialize as RODSpecialization, assignDoctor.prcno as RODPRC, assignDoctor.ptrno as RODPTR, assignDoctor.s2no as RODS2, assignDoctor.smsplusmobileno as RODMobileNo, assignDoctorInfo.cpemail as RODEmail, assignDoctorInfo.ImageLink as RODImageLink
                                FROM [dbo].[psPatRegisters] as registration
                                LEFT JOIN  [dbo].[emdSOAPTranMstr] as consultation on registration.PK_psPatRegisters = consultation.FK_psPatRegisters
                                LEFT JOIN [dbo].[emdDoctors] as assignDoctor on assignDoctor.PK_emdDoctors = consultation.FK_emdDoctors
                                JOIN [dbo].[psPersonaldata] as assignDoctorInfo on assignDoctor.PK_emdDoctors = assignDoctorInfo.PK_psPersonalData
                                WHERE registration.FK_emdPatients = @ID
                                ORDER BY registration.PK_psPatRegisters DESC"
            }
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = WMMCQMSConfig.fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            If Not Information.IsNothing(data) Then
                Dim list As New List(Of Bizbox_PatientDailyRegistration)
                For Each row As DataRow In data.Rows
                    Dim item As New Bizbox_PatientDailyRegistration
                    item.ID = (row("ID"))
                    item.ConsultationID = (row("ConsultationID"))
                    item.RegistrationDate = (row("RegistryDate"))
                    item.RegistrationType = (row("TransactionType"))
                    item.ChiefComplaint = (If(Not IsDBNull((row("ChiefComplaint"))), row("ChiefComplaint"), ""))
                    item.HistoryOfPresentIllness = (If(Not IsDBNull((row("HistoryOfPresentIllness"))), row("HistoryOfPresentIllness"), ""))
                    item.PertinentPhysicalExamination = (If(Not IsDBNull((row("PertinentPhysicalExam"))), row("PertinentPhysicalExam"), ""))
                    item.WorkingDiagnosis = (If(Not IsDBNull((row("WorkingDiagnosis"))), row("WorkingDiagnosis"), ""))
                    item.DischargeDiagnosis = (If(Not IsDBNull((row("DischargeDiagnosis"))), row("DischargeDiagnosis"), ""))
                    item.FinalDiagnosis = (If(Not IsDBNull((row("FinalDiagnosis"))), row("FinalDiagnosis"), ""))
                    item.Treatment = (If(Not IsDBNull((row("Treatment"))), row("Treatment"), ""))
                    item.Impression = (If(Not IsDBNull((row("Impression"))), row("Impression"), ""))
                    item.Remarks = (If(Not IsDBNull((row("Remarks"))), row("Remarks"), ""))
                    item.Height1 = (If(Not IsDBNull((row("InitialHeight1"))), row("InitialHeight1"), 0))
                    item.Height2 = (If(Not IsDBNull((row("InitialHeight2"))), row("InitialHeight2"), 0))
                    item.Weight = (If(Not IsDBNull((row("InitialWeight"))), row("InitialWeight"), 0))
                    item.HeightUnit = (If(Not IsDBNull((row("InitialHeightUnit"))), row("InitialHeightUnit"), ""))
                    item.WeightUnit = (If(Not IsDBNull((row("InitialWeightUnit"))), row("InitialWeightUnit"), ""))
                    item.PulseRate = (If(Not IsDBNull((row("PulseRate"))), row("PulseRate"), 0))
                    item.RespiratoryRate = (If(Not IsDBNull((row("RespiratoryRate"))), row("RespiratoryRate"), 0))
                    item.Temparature = (If(Not IsDBNull((row("Temparature"))), row("Temparature"), 0))
                    item.Systolic = (If(Not IsDBNull((row("Systolic"))), row("Systolic"), 0))
                    item.Diastolic = (If(Not IsDBNull((row("Diastolic"))), row("Diastolic"), 0))
                    item.DoleEmpNo = (If(Not IsDBNull((row("DoleEmployeeNo"))), row("DoleEmployeeNo"), ""))
                    item.DoleRefNO = (If(Not IsDBNull((row("DoleReferenceNo"))), row("DoleReferenceNo"), ""))
                    item.DoleAppStat = (If(Not IsDBNull((row("DoleType"))), row("DoleType"), ""))
                    item.ConsultationIn = If(Not IsDBNull((row("ConsultationIN"))), row("ConsultationIN"), Nothing)
                    item.ConsultationOut = If(Not IsDBNull((row("ConsultationOUT"))), row("ConsultationOUT"), Nothing)
                    item.DoctorData = New Bizbox_DoctorsInfo
                    item.DoctorData.ID = (If(Not IsDBNull((row("RODInfoID"))), row("RODInfoID"), 0))
                    item.DoctorData.Firstname = (If(Not IsDBNull((row("RODFirstname"))), row("RODFirstname"), ""))
                    item.DoctorData.MiddleName = (If(Not IsDBNull((row("RODMiddlename"))), row("RODMiddlename"), ""))
                    item.DoctorData.Lastname = (If(Not IsDBNull((row("RODLastname"))), row("RODLastname"), ""))
                    item.DoctorData.SuffixName = (If(Not IsDBNull((row("RODSuffix"))), row("RODSuffix"), ""))
                    item.DoctorData.ContactNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Specialization = ""
                    item.DoctorData.PTR = (If(Not IsDBNull((row("RODPRC"))), row("RODPRC"), ""))
                    item.DoctorData.PRC = (If(Not IsDBNull((row("RODPTR"))), row("RODPTR"), ""))
                    item.DoctorData.S2No = (If(Not IsDBNull((row("RODS2"))), row("RODS2"), ""))
                    item.DoctorData.MobileNo = (If(Not IsDBNull((row("RODMobileNo"))), row("RODMobileNo"), ""))
                    item.DoctorData.Email = (If(Not IsDBNull((row("RODEmail"))), row("RODEmail"), ""))
                    item.DoctorData.ImageLink = (If(Not IsDBNull((row("RODImageLink"))), row("RODImageLink"), ""))
                    item.DoctorData.SignatureLocation = ""
                    item.Plans = Me.GetPatientConsultationsPlans(item.ConsultationID)
                    item.SickLeaves = Me.GetPatientConsultationSickLeave(item.ConsultationID)
                    list.Add(item)
                Next
                Return list
            End If
            Return Nothing
        Catch exception1 As Exception
            Return Nothing
        End Try
    End Function

    Private Function DeterminePlanType(ByVal planGroup As String) As String
        If Not Information.IsNothing(planGroup) Then
            If (planGroup.Trim.ToUpper = "MED") Then
                Return "PRESCRIPTION"
            End If
            If (planGroup.Trim.ToUpper = "PRC") Then
                Return "PROCEDURE"
            End If
            If (planGroup.Trim.ToUpper = "EXM") Then
                Return "WORKUP"
            End If
        End If
        Return "OTHERS"
    End Function
End Class



