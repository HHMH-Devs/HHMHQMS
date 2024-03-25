Public Class CustomerInfo
    Public Info_ID As Long
    Public FirstName As String
    Public Middlename As String
    Public Lastname As String
    Public Suffix As String
    Public Sex As String
    Public BirthDate As Date
    Public CivilStatus As String
    Public StreetDrive As String
    Public Barangay As String
    Public CityMunicipality As String
    Public Province As String
    Public Nationality As String
    Public Country As String
    Public Email As String
    Public PhoneNumber As String
    Public PatientPicture As String
    Public FK_emdPatients As Long
    Public Customers As List(Of Customer)
    Public IdentificationInfo As CustomerIdentificationInfo
    Public HealthCheck As HealthCheck
End Class
