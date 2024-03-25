Public Class RxHeader
    Public rxID As String = ""
    Public rxDate As Date = #1/1/1980#
    Public doctorLicenseNo As String = ""
    Public doctorLastName As String = ""
    Public doctorFirstName As String = ""
    Public doctorMiddleName As String = ""
    Public doctorSpecialization As String = ""
    Public doctorPTR As String = ""
    Public employeeID As String = ""
    Public patientLastName As String = ""
    Public patientFirstName As String = ""
    Public patientMiddleName As String = ""
    Public patientBirthday As Date = #1/1/1980#
    Public patientGender As String = ""
    Public createdBy As String = ""
    Public patientAddress As String = ""
    Public station As String = ""
    Public remarks As String = ""
    Public requestType As String = ""
    Public ERxDetails As List(Of RxDetail)
End Class
