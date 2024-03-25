Public Class NurseNote
    Public Form_ID As Long
    Public DateCreated As Date
    Public HospitalNo As String
    Public FileLocation As String
    Public Consultation_ID As Long
    Public NurseOrderItems As List(Of NurseNoteItem)
End Class
