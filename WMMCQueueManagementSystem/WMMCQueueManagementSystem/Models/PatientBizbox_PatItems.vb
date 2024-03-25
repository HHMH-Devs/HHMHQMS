Public Class PatientBizbox_PatItems
    Public PK_psPatItems As Long
    Public FK_iwItemsREN As String
    Public ItemDescription As String
    Public ItemAbbreviation As String
    Public ItemPreparation As String
    Public DepartmentOfService As String
    Public DepartmentCode As String
    Public RequestorName As String
    Public RequestPrice As Double
    Public RequestQTY As Integer
    Public RenderPrice As Double
    Public RenderQTY As Integer
    Public isRequestCancelled As Boolean
    Public isRendered As Boolean
End Class
