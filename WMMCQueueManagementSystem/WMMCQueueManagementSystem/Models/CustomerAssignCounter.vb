Public Class CustomerAssignCounter
    Public CustomerAssignCounter_ID As Long
    Public Counter_ID As Long
    Public Customer_ID As Long
    Public DateTimeQueued As Date
    Public Priority As Integer
    Public ForHelee As Boolean
    Public Result As Boolean
    Public QueueNumber As Long
    Public PaymentMethod As Integer = 0
    Public Notes As String = Nothing
    Public NoteDepartment As String = Nothing
    Public NoteSection As String = Nothing
    Public showFlag As Boolean
    Public ProcessedQueueNumber As String
    Public Customer As New Customer
    Public Counter As New Counter
    Public ServedCustomerList As List(Of ServedCustomer)
    Public ServedCustomer As ServedCustomer
End Class
