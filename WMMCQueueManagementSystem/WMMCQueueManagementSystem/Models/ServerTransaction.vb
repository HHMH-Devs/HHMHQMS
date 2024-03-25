Public Class ServerTransaction
    Public ServerTransaction_ID As Long
    Public ServerAssignCounter_ID As Long
    Public CounterName As String
    Public DateTimeLogin As Date
    Public DateTimeLogout As Nullable(Of DateTime)

    Public ServerAssignCounter As New ServerAssignCounter
    'Public ServedCustomer As New List(Of ServedCustomer)
End Class
