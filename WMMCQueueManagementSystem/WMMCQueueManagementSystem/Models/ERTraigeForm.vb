Public Class ERTraigeForm
    Public Form_ID As Long
    Public DateCreated As Date
    Public CaseNo As String
    Public BedNo As String
    Public isGCB As Boolean
    Public isRespi As Boolean
    Public ModeOfArrival As Integer
    Public Ambulance As String
    Public TimeOfCall As Nullable(Of Date)
    Public TimeOfDispatch As Nullable(Of Date)
    Public LevelOfConsciousness As Integer
    Public Classification As Integer
    Public TimeOfArrival As Nullable(Of Date)
    Public TimeEndorsedROD As Nullable(Of Date)
    Public TimeSeenROD As Nullable(Of Date)
    Public TimeEndorsedUnit As Nullable(Of Date)
    Public PatientContact As String
    Public WatchersContact As String
    Public PatientReligion As String
    Public PainScale As String
    Public TravelHistory As String
    Public Vaccination1 As String
    Public Vaccination2 As String
    Public Vaccination3 As String
    Public TriageOnDuty As String
    Public RODOnDuty As String
    Public CarriedBy As String
    Public FileLocation As String
    Public Consultation_ID As Long
End Class
