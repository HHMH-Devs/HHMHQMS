Public Class OutpatientTAT
    Public CustomerAssignCounter_ID As Long
    Public DateTimeQueued As Date
    Public QueueNumber As Long
    Public Counter_ID As Long
    Public Department As String
    Public Section As String
    Public ServiceDescription As String
    Public CounterPrefix As String
    Public Info_ID As Long
    Public FirstName As String
    Public MiddleName As String
    Public LastName As String
    Public Sex As String
    Public BirthDate As Date
    Public FK_emdPatient As Long
    Public QueuingTransactions As List(Of CustomerAssignCounter)
End Class
