Public Class Bizbox_PatientDailyRegistration
    Public ID As Long
    Public ConsultationID As Long
    Public RegistrationDate As Date
    Public RegistrationType As String
    Public ChiefComplaint As String
    Public HistoryOfPresentIllness As String
    Public PertinentPhysicalExamination As String
    Public WorkingDiagnosis As String
    Public DischargeDiagnosis As String
    Public FinalDiagnosis As String
    Public Treatment As String
    Public Impression As String
    Public Remarks As String
    Public Height1 As Double
    Public Height2 As Double
    Public Weight As Double
    Public HeightUnit As String
    Public WeightUnit As String
    Public PulseRate As Double
    Public RespiratoryRate As Double
    Public Oxygen As Double
    Public Temparature As Double
    Public Systolic As Integer
    Public Diastolic As Integer
    Public DoleEmpNo As String
    Public DoleRefNO As String
    Public DoleAppStat As String
    Public ConsultationIn As Nullable(Of Date)
    Public ConsultationOut As Nullable(Of Date)
    Public PatientData As Bizbox_PatientPersonalData
    Public DoctorData As Bizbox_DoctorsInfo
    Public Plans As List(Of Bizbox_ConsultationPlan)
    Public FinalDiagnosisByICD10 As List(Of Bizbox_FinalDiagnosisICD10)
    Public SickLeaves As List(Of Bizbox_ConsultationSickLeave)
    Public Requisitions As List(Of PatientBizbox_PatItems)
    Public BizboxConsultation As Bizbox_Consultation
End Class
