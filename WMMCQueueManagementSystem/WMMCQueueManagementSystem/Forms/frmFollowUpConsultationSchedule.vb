Public Class frmFollowUpConsultationSchedule
    Private patientInfo As CustomerInfo

    Private followupConsultation As List(Of FollowUpConsultation) = Nothing
    Sub New(patient As CustomerInfo)
        ' This call is required by the designer.
        InitializeComponent()
        Me.patientInfo = patient
    End Sub

    Private Sub frmFollowUpConsultationSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPatientFollowUpSchedule()
    End Sub


    Private Sub GetPatientFollowUpSchedule()
        Dim dtFrom As Date = dtpDateFrom.Value
        Dim dtTo As Date = dtpDateTo.Value
        Dim ffController As New FollowUpConsultationController
        followupConsultation = ffController.GetPatientFollowUpConsultations(patientInfo.Info_ID, dtFrom, dtTo)
        dgvDiagnosticRequestItems.Rows.Clear()
        If Not IsNothing(followupConsultation) Then
            For Each ffconsultation As FollowUpConsultation In followupConsultation
                Dim consultationDate As String = ""
                If ffconsultation.Consultation_Date.Value.Date = Today.Date Then
                    consultationDate = "Today @ " & ffconsultation.Consultation_Date.Value.ToShortTimeString
                ElseIf ffconsultation.Consultation_Date.Value.Date = DateAdd(DateInterval.Day, 1, Today).Date Then
                    consultationDate = "Tommorow @ " & ffconsultation.Consultation_Date.Value.ToShortTimeString
                Else
                    consultationDate = Format(ffconsultation.Consultation_Date, "MMM dd, yyyy at h:mm tt")
                End If
                dgvDiagnosticRequestItems.Rows.Add(ffconsultation.FollowUp_ID, ffconsultation.Consultation.ServerTransaction.ServerAssignCounter.Server.FullName, consultationDate)
                dgvDiagnosticRequestItems.Rows(dgvDiagnosticRequestItems.Rows.Count - 1).Height = 30
            Next
        End If
    End Sub

    Private Sub dgvDiagnosticRequestItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnosticRequestItems.CellContentClick

    End Sub

    Private Sub dgvDiagnosticRequestItems_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDiagnosticRequestItems.SelectionChanged
        If dgvDiagnosticRequestItems.SelectedRows.Count > 0 Then
            Dim index As Long = dgvDiagnosticRequestItems.SelectedRows(0).Cells("ID").Value
            Dim ffConsultation As FollowUpConsultation = Nothing
            For Each ffcond As FollowUpConsultation In followupConsultation
                If ffcond.FollowUp_ID = index Then
                    ffConsultation = ffcond
                    Exit For
                End If
            Next
            If Not IsNothing(ffConsultation) Then
                lblFFConsultationInfo.Text = ffConsultation.Consultation.ServerTransaction.ServerAssignCounter.Server.FullName & vbCrLf &
                                             ffConsultation.Consultation.ServerTransaction.ServerAssignCounter.Server.Specialization & vbCrLf &
                                             Format(ffConsultation.Consultation_Date, "MMM dd, yyyy at h:mm tt") & vbCrLf &
                                             ffConsultation.ConsultationClinic & vbCrLf &
                                             Format(ffConsultation.Consultation.DateCreated, "MMM dd, yyyy at h:mm tt")
            End If
        End If
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        GetPatientFollowUpSchedule()
    End Sub
End Class