Public Class CustomerQueuedSummary

    Public CustomerInfo As CustomerInfo
    Public CustomerAssignCounter As CustomerAssignCounter
    Public CustomerAssignCounters As List(Of CustomerAssignCounter)
    Public Journey_Triage As CustomerAssignCounter
    Public Journey_Payment As CustomerAssignCounter
    Public Journey_Ancillary As CustomerAssignCounter
End Class
