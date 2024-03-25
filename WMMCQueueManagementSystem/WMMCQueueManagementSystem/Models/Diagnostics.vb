Public Class Diagnostics
    Public Diagnostic_ID As Long
    Public Diagnostics As String
    Public ItemDescription As String
    Public Remarks As String
    Public OPDConsent1 As String
    Public OPDConsent2 As String
    Public PatientType As String
    Public ResultReportLink As String
    Public DiagnosticDate As Date
    Public ResultDate As Date
    Public ModifiedDate As Nullable(Of Date)
    Public DoneDate As Nullable(Of Date)
    Public PK_psExamResultMstr As Long
    Public FK_emdPatients As Long
    Public FK_Diagnostic_ID As Long
    Public FK_psPatRegisters As Long
    Public ServerTransaction_ID As Long
    Public Info_ID As Long
    Public Consultation_ID As Long
    Public PatRegisters As PatientBixbox_PatRegisters
    Public ServerTransaction As ServerTransaction
End Class
