Public Class Bizbox_Consultation
    Public ID As Long
    Public DateCreated As Date
    Public DateModified As Nullable(Of Date)
    Public OPDConsent1 As String
    Public OPDConsent2 As String
    Public isServed As Boolean
    Public ForInitialConsultation_ServerAssignCounter_ID As Long
    Public PhysicianLookup_PRC As String
    Public FK_psPatRegisters As Long
    Public FK_emdPatients As Long
    Public Info_ID As Long
    Public ServerTransaction_ID As Long
    Public ServedCustomerID As Long
    Public ForInitialConsultation_ServerAssignCounter As ServerAssignCounter
    Public BizboxRegistration As Bizbox_PatientDailyRegistration
    Public ServerTransaction As ServerTransaction
    Public ServedCustomer As ServedCustomer
End Class
