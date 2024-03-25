Public Class Bizbox_PatientPersonalData
    Public PatientID As Long
    Public Firstname As String
    Public MiddleName As String
    Public Lastname As String
    Public SuffixName As String
    Public FullName As String
    Public AddressPt1 As String
    Public AddressPt2 As String
    Public AddressPt3 As String
    Public FullAddress As String
    Public Gender As String
    Public BirthDate As Date
    Public CivilStatus As String
    Public Nationality As String
    Public MobileNo1 As String
    Public MobileNo2 As String
    Public Email As String
    Public ImageLink As String
    Public PatientRegistry As List(Of Bizbox_PatientDailyRegistration)
End Class
