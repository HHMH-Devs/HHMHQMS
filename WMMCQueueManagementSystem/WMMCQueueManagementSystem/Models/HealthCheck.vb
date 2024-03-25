Public Class HealthCheck
    Public HealthCheck_ID As Long
    Public Fever As Boolean
    Public Cough As Boolean
    Public Sorethroat As Boolean
    Public Diarrhea As Boolean
    Public ShortnessOfBreathing As Boolean
    Public Ageusia As Boolean
    Public Anosmia As Boolean
    Public Colds As Boolean
    Public CloseContactConfirmed As Boolean
    Public CloseContactExhiting As Boolean
    Public PurposeOfVisit As String
    Public isCurrent As Boolean
    Public isEligible As Nullable(Of Boolean)
    Public DateOfAssesment As Date
    Public Fk_emdPatient As Long
    Public Info_ID As Long
End Class
