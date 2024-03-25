Public Class Counter
    Public Counter_ID As Long
    Public Department As String
    Public Section As String
    Public ServiceDescription As String
    Public ServiceDescription2 As String
    Public CounterPrefix As String
    Public CounterCode As String
    Public Icon As Integer
    Public isQueueingCounter As Integer
    Public isSoloCounter As Boolean
    Public AutoTransfer_Diagnostics As Boolean
    Public AutoTransfer_Prescriptions As Boolean
    Public AutoTransfer_Screening As Boolean
    Public AutoTransfer_Payment As Integer
    Public AutoTransfer_GCBER As Boolean
    Public AutoTransfer_RespiER As Boolean
    Public AutoTransfer_Ancillary As Integer
    Public CounterType As Integer
    Public isResultCounter As Boolean
    Public showOnMainCounter As Boolean
    Public canHaveCustomerName As Boolean
    Public canHavePaymentMethod As Boolean
    Public consultationView As Boolean
    Public consultationAddEdit As Boolean
    Public diagnosticView As Boolean
    Public diagnosticAddEdit As Boolean
    Public eprescriptionView As Boolean
    Public eprescriptionAddEdit As Boolean
    Public healthcheckView As Boolean
    Public healthcheckAddEdit As Boolean
    Public initialconsultation As Boolean
    Public erconsultation As Boolean
    Public SyncDetail As Boolean
    Public allowedTurnaroundTime As Long
    Public isMabCounter As Boolean
    Public canEKonsulta As Boolean
    Public canHelee As Boolean
    Public generateScreening As Boolean
    Public MainCounterCTR As Integer
    Public ServerAssignCounter As List(Of ServerAssignCounter)
    Public CustomerAssignCounter As List(Of CustomerAssignCounter)
End Class
