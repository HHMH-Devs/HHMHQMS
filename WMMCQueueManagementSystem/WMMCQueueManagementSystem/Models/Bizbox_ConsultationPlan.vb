Public Class Bizbox_ConsultationPlan
    Public ID As Long
    Public ConsultationID As Long
    Public DoctorsID As Long
    Public PatientID As Long
    Public PlanGroup As String
    Public PlanGroupAbrev As String
    Public PlanDescription As String
    Public ICD10 As String
    Public PatientRegistry As List(Of Bizbox_PatientDailyRegistration)
End Class
