Public Class PatientBixbox_PatRegisters
    Public PK_psPatRegisters As Long
    Public RegistryNo As Long
    Public PatRegistersConsent As String
    Public RegistryDate As Date
    Public FK_emdPatients As Long
    Public PatItems_Rendered As List(Of PatientBizbox_PatItems)
    Public PatItems_Requested As List(Of PatientBizbox_PatItems)
    Public Diagnostics As Diagnostics
End Class
