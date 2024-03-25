Public Class Prescription
    Public Prescription_ID As Long
    Public ProductCode As Long
    Public ProductDescription As String
    Public GenericName As String
    Public Qty As Integer
    Public Strength As String
    Public Preparation As String
    Public Instruction As String
    Public UnitPrice As String
    Public UnitCost As String
    Public OnHand As String
    Public BeforeBreakfast As String
    Public BeforeLunch As String
    Public BeforeDinner As String
    Public AfterBreakfast As String
    Public AfterLunch As String
    Public AfterDinner As String
    Public AtBedTime As Boolean
    Public DaysOfIntake As String
    Public isS2Meds As Boolean
    Public PrescriptionCTR As Boolean
    Public PrescriptionUse As String
    Public SentDate As Nullable(Of Date)
    Public RequestDate As Date
    Public ModifiedDate As Nullable(Of Date)
    Public FK_emdPatients As Long
    Public ServerTransaction_ID As Long
    Public Info_ID As Long
    Public Consultation_ID As Long
    Public ServerTransaction As ServerTransaction
End Class
