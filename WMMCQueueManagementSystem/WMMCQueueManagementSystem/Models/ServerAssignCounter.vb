Public Class ServerAssignCounter
    Public ServerAssignCounter_ID As Long
    Public Server_ID As Long
    Public Counter_ID As Long
    Public DateCreated As Date
    Public isMain As Boolean
    Public isAvailable As Boolean

    Public Server As New Server
    Public Counter As New Counter
    Public ServerTransaction As New List(Of ServerTransaction)
End Class
