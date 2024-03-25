Public Class Customer
    Public Customer_ID As Long
    Public FullName As String
    Public FirstName As String
    Public MiddleName As String
    Public LastName As String
    Public Sex As String
    Public Birthdate As Date
    Public CivilStatus As String
    Public Address As String
    Public PhoneNumber As String
    Public DateOfVisit As Date
    Public FK_emdPatients As Long
    Public Info_ID As Long
    Public CustomerInfo As customerinfo
    Public CustomerAssignCounter As List(Of CustomerAssignCounter)
End Class
