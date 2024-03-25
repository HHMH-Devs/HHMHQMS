Imports System.Data
Imports System.Data.SqlClient
Public Class DiagnosticsController

    Public Function NewDiagnosicRequest(diagnosticRequest As Diagnostics) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[diagnosticrequests] ([diagnostic] ,[remarks] ,[FK_emdPatients], [servertransaction_id], [info_id]) VALUES (@diag,@rmrk,@fkid,@stid,@inid)"
            cmd.Parameters.AddWithValue("@diag", diagnosticRequest.Diagnostics)
            cmd.Parameters.AddWithValue("@rmrk", diagnosticRequest.Remarks)
            cmd.Parameters.AddWithValue("@fkid", diagnosticRequest.FK_emdPatients)
            cmd.Parameters.AddWithValue("@stid", diagnosticRequest.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@inid", diagnosticRequest.Info_ID)
            Return excecuteCommand(cmd)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function EditDiagnosicRequest(diagnosticRequest As Diagnostics) As Boolean
        Try
            Dim cmdChecker As New SqlCommand
            cmdChecker.CommandText = "SELECT * FROM [dbo].[diagnosticrequests] WHERE diagnostic_id = @ID AND doneDate IS NULL"
            cmdChecker.Parameters.AddWithValue("@ID", diagnosticRequest.Diagnostic_ID)
            Dim data As DataTable = fetchData(cmdChecker).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim cmd As New SqlCommand
                    cmd.CommandText = "UPDATE [dbo].[diagnosticrequests] SET [diagnostic] = @diag, [remarks] = @rmrk,  [modifiedDate] = GETDATE(), [FK_psPatRegisters] = @fkPatReg WHERE diagnostic_id = @ID AND doneDate IS NULL"
                    cmd.Parameters.AddWithValue("@diag", diagnosticRequest.Diagnostics)
                    cmd.Parameters.AddWithValue("@fkPatReg", diagnosticRequest.FK_psPatRegisters)
                    cmd.Parameters.AddWithValue("@rmrk", diagnosticRequest.Remarks)
                    cmd.Parameters.AddWithValue("@ID", diagnosticRequest.Diagnostic_ID)
                    Return excecuteCommand(cmd)
                End If
            End If
            Return False
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function DeleteDiagnosticRequests(ID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [dbo].[diagnosticrequests] WHERE diagnostic_id = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Return excecuteCommand(cmd)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function NewDiagnosticsFromBizbox(diagnosticRequest As Diagnostics) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[diagnosticrequests] 
                        ([diagnostic],[remarks],[opdconsent],[opdconsent2],[FK_emdPatients],[FK_psPatRegisters],[servertransaction_id],[info_id]) VALUES 
                        (@diag,@rmrk,@opdcnst,@opdcnst2,@fkid,@patReg,@stid,@inid)"
            cmd.Parameters.AddWithValue("@diag", diagnosticRequest.Diagnostics)
            cmd.Parameters.AddWithValue("@rmrk", diagnosticRequest.Remarks)
            cmd.Parameters.AddWithValue("@opdcnst", diagnosticRequest.OPDConsent1)
            cmd.Parameters.AddWithValue("@opdcnst2", diagnosticRequest.OPDConsent2)
            cmd.Parameters.AddWithValue("@fkid", diagnosticRequest.FK_emdPatients)
            cmd.Parameters.AddWithValue("@patReg", diagnosticRequest.FK_psPatRegisters)
            cmd.Parameters.AddWithValue("@stid", diagnosticRequest.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@inid", diagnosticRequest.Info_ID)
            Return excecuteCommand(cmd)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetPatientLatestDiagnosticRequest(infoID As Long, fkEmdPatient As Long) As Diagnostics
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or f.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * FROM [dbo].[diagnosticrequests] as a JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id  WHERE a.diagnostic_id = (SELECT MAX(f.diagnostic_id) FROM [dbo].[diagnosticrequests] as f WHERE (f.info_id = @ID " & qry & ") AND f.FK_diagnostic_id IS NULL)"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim latestRequestedDiagnostic As New Diagnostics
                    latestRequestedDiagnostic.Diagnostic_ID = data.Rows(0)("diagnostic_id")
                    latestRequestedDiagnostic.Diagnostics = If(Not IsDBNull(data.Rows(0)("diagnostic")), data.Rows(0)("diagnostic"), Nothing)
                    latestRequestedDiagnostic.Remarks = If(Not IsDBNull(data.Rows(0)("remarks")), data.Rows(0)("remarks"), Nothing)
                    latestRequestedDiagnostic.ItemDescription = If(Not IsDBNull(data.Rows(0)("ItemDescription")), data.Rows(0)("ItemDescription"), Nothing)
                    latestRequestedDiagnostic.DiagnosticDate = data.Rows(0)("requestDate")
                    latestRequestedDiagnostic.ModifiedDate = If(Not IsDBNull(data.Rows(0)("modifiedDate")), data.Rows(0)("modifiedDate"), Nothing)
                    latestRequestedDiagnostic.DoneDate = If(Not IsDBNull(data.Rows(0)("doneDate")), data.Rows(0)("doneDate"), Nothing)
                    latestRequestedDiagnostic.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    latestRequestedDiagnostic.FK_Diagnostic_ID = If(Not IsDBNull(data.Rows(0)("FK_diagnostic_id")), data.Rows(0)("FK_diagnostic_id"), Nothing)
                    latestRequestedDiagnostic.ServerTransaction = New ServerTransaction
                    latestRequestedDiagnostic.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    latestRequestedDiagnostic.ServerTransaction.CounterName = data.Rows(0)("countername")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server = New Server
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname")
                    latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                    Return latestRequestedDiagnostic
                End If
            End If
            Return Nothing
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function


    Public Function GetPatientLatestDiagnosticRequest_Consultation(patient As ServedCustomer, consultation As CustomerConsultation) As Diagnostics
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[diagnosticrequests] as a JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id  WHERE a.diagnostic_id = (SELECT MAX(f.diagnostic_id) FROM [dbo].[diagnosticrequests] as f WHERE vital_id = @ID AND f.FK_diagnostic_id IS NULL)"
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If Not data.Rows.Count > 0 Then
                    Dim cmdCreateNewDiagnosis As New SqlCommand
                    cmdCreateNewDiagnosis.CommandText = "INSERT INTO [dbo].[diagnosticrequests] ([diagnostic] ,[remarks] ,[FK_emdPatients], [servertransaction_id], [info_id], [vital_id]) VALUES (@diag,@rmrk,@fkid,@stid,@inid,@ID);SELECT @@IDENTITY;"
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@diag", "")
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@rmrk", "")
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@fkid", patient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@stid", If(patient.ServerTransaction_ID > 0, patient.ServerTransaction_ID, patient.ServerTransaction.ServerTransaction_ID))
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@inid", patient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                    cmdCreateNewDiagnosis.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
                    Dim diagnosticID As Long = excecuteCommandReturnID(cmdCreateNewDiagnosis)
                    If diagnosticID > 0 Then
                        cmd = New SqlCommand
                        cmd.CommandText = "SELECT * FROM [dbo].[diagnosticrequests] as a JOIN wmmcqms.[servertransaction] as b ON a.servertransaction_id = b.servertransaction_id JOIN wmmcqms.[serverassigncounter] as c ON b.serverassigncounter_id = c.serverassigncounter_ID JOIN wmmcqms.[counter] as d ON c.counter_id = d.counter_id JOIN wmmcqms.[server] as e ON c.server_id = e.server_id  WHERE a.diagnostic_id = (SELECT MAX(f.diagnostic_id) FROM [dbo].[diagnosticrequests] as f WHERE diagnostic_id = @ID AND f.FK_diagnostic_id IS NULL)"
                        cmd.Parameters.AddWithValue("@ID", diagnosticID)
                        data = fetchData(cmd).Tables(0)
                        If IsNothing(data) Then
                            Return Nothing
                        ElseIf Not data.Rows.Count > 0 Then
                            Return Nothing
                        End If
                    End If
                End If
                Dim latestRequestedDiagnostic As New Diagnostics
                latestRequestedDiagnostic.Diagnostic_ID = data.Rows(0)("diagnostic_id")
                latestRequestedDiagnostic.Diagnostics = If(Not IsDBNull(data.Rows(0)("diagnostic")), data.Rows(0)("diagnostic"), Nothing)
                latestRequestedDiagnostic.Remarks = If(Not IsDBNull(data.Rows(0)("remarks")), data.Rows(0)("remarks"), Nothing)
                latestRequestedDiagnostic.ItemDescription = If(Not IsDBNull(data.Rows(0)("ItemDescription")), data.Rows(0)("ItemDescription"), Nothing)
                latestRequestedDiagnostic.DiagnosticDate = data.Rows(0)("requestDate")
                latestRequestedDiagnostic.ModifiedDate = If(Not IsDBNull(data.Rows(0)("modifiedDate")), data.Rows(0)("modifiedDate"), Nothing)
                latestRequestedDiagnostic.FK_psPatRegisters = If(Not IsDBNull(data.Rows(0)("FK_psPatRegisters")), data.Rows(0)("FK_psPatRegisters"), 0)
                latestRequestedDiagnostic.DoneDate = If(Not IsDBNull(data.Rows(0)("doneDate")), data.Rows(0)("doneDate"), Nothing)
                latestRequestedDiagnostic.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                latestRequestedDiagnostic.FK_Diagnostic_ID = If(Not IsDBNull(data.Rows(0)("FK_diagnostic_id")), data.Rows(0)("FK_diagnostic_id"), 0)
                If latestRequestedDiagnostic.FK_psPatRegisters > 0 Then
                    Dim apiControler As New APIController
                    latestRequestedDiagnostic.PatRegisters = New PatientBixbox_PatRegisters
                    latestRequestedDiagnostic.PatRegisters = apiControler.GetCertainPatientBizboxTrasaction(latestRequestedDiagnostic.FK_psPatRegisters)
                Else
                    latestRequestedDiagnostic.PatRegisters = Nothing
                End If
                latestRequestedDiagnostic.ServerTransaction = New ServerTransaction
                latestRequestedDiagnostic.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                latestRequestedDiagnostic.ServerTransaction.CounterName = data.Rows(0)("countername")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter = New Counter
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.consultationView = data.Rows(0)("consultationView")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server = New Server
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname")
                latestRequestedDiagnostic.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                Return latestRequestedDiagnostic
            End If
            Return Nothing
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientCertainDiagnostics_Consultation(ID As Long) As Diagnostics
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT [diagnostic_id]  ,[diagnostic] ,[remarks] ,[ItemDescription] ,[requestDate] ,[modifiedDate] ,[doneDate] ,[FK_psPatRegisters] ,[FK_emdPatients] ,[FK_diagnostic_id] ,[servertransaction_id] ,[info_id] ,[vital_id] FROM [dbo].[diagnosticrequests] WHERE vital_id = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim requestedDiagnostic As New Diagnostics
                    requestedDiagnostic.Diagnostic_ID = data.Rows(0)("diagnostic_id")
                    requestedDiagnostic.Diagnostics = If(Not IsDBNull(data.Rows(0)("diagnostic")), data.Rows(0)("diagnostic"), Nothing)
                    requestedDiagnostic.Remarks = If(Not IsDBNull(data.Rows(0)("remarks")), data.Rows(0)("remarks"), Nothing)
                    requestedDiagnostic.ItemDescription = If(Not IsDBNull(data.Rows(0)("ItemDescription")), data.Rows(0)("ItemDescription"), Nothing)
                    requestedDiagnostic.DiagnosticDate = data.Rows(0)("requestDate")
                    requestedDiagnostic.ModifiedDate = If(Not IsDBNull(data.Rows(0)("modifiedDate")), data.Rows(0)("modifiedDate"), Nothing)
                    requestedDiagnostic.DoneDate = If(Not IsDBNull(data.Rows(0)("doneDate")), data.Rows(0)("doneDate"), Nothing)
                    requestedDiagnostic.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    requestedDiagnostic.FK_Diagnostic_ID = If(Not IsDBNull(data.Rows(0)("FK_diagnostic_id")), data.Rows(0)("FK_diagnostic_id"), Nothing)
                    requestedDiagnostic.FK_psPatRegisters = If(Not IsDBNull(data.Rows(0)("FK_psPatRegisters")), data.Rows(0)("FK_psPatRegisters"), Nothing)
                    If requestedDiagnostic.FK_psPatRegisters > 0 Then
                        Dim apiControler As New APIController
                        requestedDiagnostic.PatRegisters = New PatientBixbox_PatRegisters
                        requestedDiagnostic.PatRegisters = apiControler.GetCertainPatientBizboxTrasaction(requestedDiagnostic.FK_psPatRegisters)
                    Else
                        requestedDiagnostic.PatRegisters = Nothing
                    End If
                    Return requestedDiagnostic
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

    Public Function GetCertainDiagnostics(fkPatReg As Long) As Diagnostics
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[diagnosticrequests] WHERE FK_psPatRegisters = @ID"
            cmd.Parameters.AddWithValue("@ID", fkPatReg)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim requestedDiagnostic As New Diagnostics
                    requestedDiagnostic.Diagnostic_ID = data.Rows(0)("diagnostic_id")
                    requestedDiagnostic.Diagnostics = If(Not IsDBNull(data.Rows(0)("diagnostic")), data.Rows(0)("diagnostic"), Nothing)
                    requestedDiagnostic.Remarks = If(Not IsDBNull(data.Rows(0)("remarks")), data.Rows(0)("remarks"), Nothing)
                    requestedDiagnostic.ItemDescription = If(Not IsDBNull(data.Rows(0)("ItemDescription")), data.Rows(0)("ItemDescription"), Nothing)
                    requestedDiagnostic.OPDConsent1 = If(Not IsDBNull(data.Rows(0)("opdconsent")), data.Rows(0)("opdconsent"), Nothing)
                    requestedDiagnostic.OPDConsent2 = If(Not IsDBNull(data.Rows(0)("opdconsent2")), data.Rows(0)("opdconsent2"), Nothing)
                    requestedDiagnostic.DiagnosticDate = data.Rows(0)("requestDate")
                    requestedDiagnostic.ModifiedDate = If(Not IsDBNull(data.Rows(0)("modifiedDate")), data.Rows(0)("modifiedDate"), Nothing)
                    requestedDiagnostic.DoneDate = If(Not IsDBNull(data.Rows(0)("doneDate")), data.Rows(0)("doneDate"), Nothing)
                    requestedDiagnostic.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    requestedDiagnostic.FK_Diagnostic_ID = If(Not IsDBNull(data.Rows(0)("FK_diagnostic_id")), data.Rows(0)("FK_diagnostic_id"), Nothing)
                    Return requestedDiagnostic
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
End Class
