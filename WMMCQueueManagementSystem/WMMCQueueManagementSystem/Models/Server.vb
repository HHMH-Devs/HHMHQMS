Public Class Server
    Public Server_ID As Long
    Public EmmployeeID As String
    Public FullName As String
    Public FirstName As String
    Public MiddleName As String
    Public LastName As String
    Public ContactNo As String
    Public PrimaryContactNo As String
    Public SecondaryContactNo As String
    Public SecretaryContactNo As String
    Public AssignDepartment As String
    Public Specialization As String
    Public PTR As String
    Public PRC As String
    Public S2No As String
    Public SignatureLocation As String
    Public PhysicianID As String
    Public AccountType As String
    Public Username As String
    Public Pasaword As String
    Public CounterAssignNumber As Integer
    Public ServerAssignCounter As New List(Of ServerAssignCounter)
    Public Schedules As List(Of DoctorSchedule)
End Class
