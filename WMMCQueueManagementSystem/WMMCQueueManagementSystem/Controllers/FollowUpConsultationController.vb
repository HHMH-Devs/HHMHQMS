Imports System.Data
Imports System.Data.SqlClient
Public Class FollowUpConsultationController

    Public Function GetPatientFollowUpConsultations(consultation As CustomerConsultation) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[followupconsultation]
                               WHERE consultation_id = @ID"
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUps As New List(Of FollowUpConsultation)
                If data.Rows.Count > 0 Then
                    For Each row As DataRow In data.Rows
                        Dim followUp As New FollowUpConsultation
                        followUp.FollowUp_ID = row("ff_id")
                        followUp.Consultation_Date = row("consultationdate")
                        followUp.ConsultationClinic = row("consultationclinic")
                        followUp.Consultation_ID = row("consultation_id")
                        followUps.Add(followUp)
                    Next
                    Return followUps
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientFollowUpConsultations(ID As Long) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[followupconsultation] as a
                                JOIN [dbo].[customervitals] as b on b.consultation_id = a.consultation_id
                                JOIN [wmmcqms].[servertransaction] as c on c.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as d on d.serverassigncounter_ID = c.serverassigncounter_id
                                JOIN [wmmcqms].[server] as e on e.server_id = d.server_id
                                JOIN [wmmcqms].[counter] as f on f.counter_id = d.counter_id
                                WHERE b.info_id = @ID ORDER BY a.consultationdate desc"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUps As New List(Of FollowUpConsultation)
                If data.Rows.Count > 0 Then
                    For Each row As DataRow In data.Rows
                        Dim followUp As New FollowUpConsultation
                        followUp.FollowUp_ID = row("ff_id")
                        followUp.Consultation_Date = row("consultationdate")
                        followUp.ConsultationClinic = row("consultationclinic")
                        followUp.Consultation_ID = row("consultation_id")
                        followUp.Consultation = New CustomerConsultation
                        followUp.Consultation.Consultation_ID = row("consultation_id")
                        followUp.Consultation.DateCreated = row("datecreated")
                        followUp.Consultation.ServerTransaction = New ServerTransaction
                        followUp.Consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FirstName = row("firstname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.MiddleName = row("middlename")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.LastName = row("lastname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = row("specializaton")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")

                        followUps.Add(followUp)
                    Next
                    Return followUps
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientFollowUpConsultations(ID As Long, dtFrom As Date, dtTo As Date) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[followupconsultation] as a
                                JOIN [dbo].[customervitals] as b on b.consultation_id = a.consultation_id
                                JOIN [wmmcqms].[servertransaction] as c on c.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as d on d.serverassigncounter_ID = c.serverassigncounter_id
                                JOIN [wmmcqms].[server] as e on e.server_id = d.server_id
                                JOIN [wmmcqms].[counter] as f on f.counter_id = d.counter_id
                               WHERE CONVERT(date,a.consultationdate) BETWEEN CONVERT(date,@dt1) AND CONVERT(date,@dt2) AND b.info_id = @ID ORDER BY a.consultationdate ASC"
            cmd.Parameters.AddWithValue("@dt1", dtFrom)
            cmd.Parameters.AddWithValue("@dt2", dtTo)
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUps As New List(Of FollowUpConsultation)
                If data.Rows.Count > 0 Then
                    For Each row As DataRow In data.Rows
                        Dim followUp As New FollowUpConsultation
                        followUp.FollowUp_ID = row("ff_id")
                        followUp.Consultation_Date = row("consultationdate")
                        followUp.ConsultationClinic = row("consultationclinic")
                        followUp.Consultation_ID = row("consultation_id")
                        followUp.Consultation = New CustomerConsultation
                        followUp.Consultation.Consultation_ID = row("consultation_id")
                        followUp.Consultation.DateCreated = row("datecreated")
                        followUp.Consultation.ServerTransaction = New ServerTransaction
                        followUp.Consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FirstName = row("firstname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.MiddleName = row("middlename")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.LastName = row("lastname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = row("specializaton")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")

                        followUps.Add(followUp)
                    Next
                    Return followUps
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainConsultations_FollowUpConsultations(ID As Long) As List(Of FollowUpConsultation)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[followupconsultation] as a
                                JOIN [dbo].[customervitals] as b on b.consultation_id = a.consultation_id
                                JOIN [wmmcqms].[servertransaction] as c on c.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as d on d.serverassigncounter_ID = c.serverassigncounter_id
                                JOIN [wmmcqms].[server] as e on e.server_id = d.server_id
                                JOIN [wmmcqms].[counter] as f on f.counter_id = d.counter_id
                                WHERE a.consultation_id  = @ID ORDER BY a.consultationdate desc"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim followUps As New List(Of FollowUpConsultation)
                If data.Rows.Count > 0 Then
                    For Each row As DataRow In data.Rows
                        Dim followUp As New FollowUpConsultation
                        followUp.FollowUp_ID = row("ff_id")
                        followUp.Consultation_Date = row("consultationdate")
                        followUp.ConsultationClinic = row("consultationclinic")
                        followUp.Consultation_ID = row("consultation_id")
                        followUp.Consultation = New CustomerConsultation
                        followUp.Consultation.Consultation_ID = row("consultation_id")
                        followUp.Consultation.DateCreated = row("datecreated")
                        followUp.Consultation.ServerTransaction = New ServerTransaction
                        followUp.Consultation.ServerTransaction.ServerTransaction_ID = row("servertransaction_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server = New Server
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.FirstName = row("firstname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.MiddleName = row("middlename")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.LastName = row("lastname")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Server.Specialization = row("specializaton")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter = New Counter
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                        followUp.Consultation.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")

                        followUps.Add(followUp)
                    Next
                    Return followUps
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function SaveNewFollowUpCheckUp_Consultation(consultation As CustomerConsultation, ffConsultation As List(Of FollowUpConsultation)) As Boolean
        Try
            Dim hasFFConsultation As Boolean = False
            Dim CMDs As New List(Of SqlCommand)
            Dim deleteCmd As New SqlCommand
            deleteCmd.CommandText = "DELETE FROM [dbo].[followupconsultation] WHERE consultation_id = @ID"
            deleteCmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            CMDs.Add(deleteCmd)
            If Not IsNothing(ffConsultation) Then
                For Each ffItem As FollowUpConsultation In ffConsultation
                    hasFFConsultation = True
                    Dim cmd As New SqlCommand
                    cmd.CommandText = " INSERT INTO [dbo].[followupconsultation] ([consultationdate] ,[consultationclinic] ,[consultation_id]) VALUES (@dt, @cl,@ID)"
                    cmd.Parameters.AddWithValue("@dt", ffItem.Consultation_Date)
                    cmd.Parameters.AddWithValue("@cl", ffItem.ConsultationClinic)
                    cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    CMDs.Add(cmd)
                Next
                Dim ffConsult As New SqlCommand
                ffConsult.CommandText = "UPDATE [dbo].[customervitals]  SET [forfollowup] = @ffcon WHERE consultation_id = @ID"
                ffConsult.Parameters.AddWithValue("@ffcon", hasFFConsultation)
                ffConsult.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                CMDs.Add(ffConsult)
            End If
            Return excecuteMultipleCommand(CMDs)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function
End Class
