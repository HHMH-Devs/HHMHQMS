Public Class ServedCustomer
    Public ServedCustomer_ID As Long
    Public ServerTransaction_ID As Long
    Public CustomerAssginCounter_ID As Long
    Public DateTimeStart As Nullable(Of Date)
    Public DateTimeEnd As Nullable(Of Date)
    Public NoShow As Boolean
    Public CustomerAssignCounter As New CustomerAssignCounter
    Public ServerTransaction As New ServerTransaction
    Public Consultation As New CustomerConsultation
End Class
