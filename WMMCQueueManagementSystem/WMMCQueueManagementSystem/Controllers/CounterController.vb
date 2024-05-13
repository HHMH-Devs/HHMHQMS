Imports System.Data.SqlClient
Public Class CounterController

    Public Function NewDoctorClinic(doctorClinic As ServerAssignCounter) As Boolean
        Dim cmdClinic As New SqlCommand
        cmdClinic.CommandText = "INSERT INTO [wmmcqms].[counter] (department, section, servicedescription, counterPrefix, countercode, icon, isQueuingCounter,counterType,allowableTurnaroundTime ,[consultationView] ,[consultationAddEdit] ,[diagnosticView] ,[diagnosticAddEdit] ,[eprescirptionView] ,[eprescirptionAddEdit] ,[syncDetail],[canEKonsulta]) VALUES (@dept,@sec,@desc,@pre,@cod,@ico,@flag,@ctype,@tat,@conVw,@conAe,@diaVw,@diaAe,@epreVw,@epreAe,@sncInf,@eKonsult); SELECT @@IDENTITY;"
        cmdClinic.Parameters.AddWithValue("@dept", doctorClinic.Counter.Department)
        cmdClinic.Parameters.AddWithValue("@sec", doctorClinic.Counter.Section)
        cmdClinic.Parameters.AddWithValue("@desc", doctorClinic.Counter.ServiceDescription)
        cmdClinic.Parameters.AddWithValue("@pre", doctorClinic.Counter.CounterPrefix)
        cmdClinic.Parameters.AddWithValue("@cod", doctorClinic.Counter.CounterCode)
        cmdClinic.Parameters.AddWithValue("@ico", doctorClinic.Counter.Icon)
        cmdClinic.Parameters.AddWithValue("@flag", If(Not doctorClinic.Counter.showOnMainCounter, 2, doctorClinic.Counter.isQueueingCounter))
        cmdClinic.Parameters.AddWithValue("@ctype", doctorClinic.Counter.CounterType)
        cmdClinic.Parameters.AddWithValue("@tat", doctorClinic.Counter.allowedTurnaroundTime)
        cmdClinic.Parameters.AddWithValue("@conVw", doctorClinic.Counter.consultationView)
        cmdClinic.Parameters.AddWithValue("@conAe", doctorClinic.Counter.consultationAddEdit)
        cmdClinic.Parameters.AddWithValue("@diaVw", doctorClinic.Counter.diagnosticView)
        cmdClinic.Parameters.AddWithValue("@diaAe", doctorClinic.Counter.diagnosticAddEdit)
        cmdClinic.Parameters.AddWithValue("@epreVw", doctorClinic.Counter.eprescriptionView)
        cmdClinic.Parameters.AddWithValue("@epreAe", doctorClinic.Counter.eprescriptionAddEdit)
        cmdClinic.Parameters.AddWithValue("@sncInf", doctorClinic.Counter.SyncDetail)
        cmdClinic.Parameters.AddWithValue("@eKonsult", doctorClinic.Counter.canEKonsulta)
        Dim clinicID As Long = excecuteCommandReturnID(cmdClinic)
        If clinicID > 0 Then
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO wmmcqms.serverassigncounter (server_id, counter_id, isMain) VALUES (@serverid,@counterid,@ismain)"
            cmd.Parameters.AddWithValue("@serverid", doctorClinic.Server_ID)
            cmd.Parameters.AddWithValue("@counterid", clinicID)
            cmd.Parameters.AddWithValue("@ismain", False)
            Return excecuteCommand(cmd)
        End If
        Return False
    End Function

    Public Function UpdateDoctorClinic(doctorClinic As ServerAssignCounter) As Boolean
        Dim cmdClinic As New SqlCommand
        cmdClinic.CommandText = "UPDATE [wmmcqms].[counter] SET [department] = @dept, [isQueuingCounter] = @flag, [section] = @sec, [servicedescription] = @desc, [counterPrefix] = @pre, [counterType] = @ctype, [canEKonsulta] = @eKonsult WHERE counter_id = @ID"
        cmdClinic.Parameters.AddWithValue("@dept", doctorClinic.Counter.Department)
        cmdClinic.Parameters.AddWithValue("@sec", doctorClinic.Counter.Section)
        cmdClinic.Parameters.AddWithValue("@desc", doctorClinic.Counter.ServiceDescription)
        cmdClinic.Parameters.AddWithValue("@pre", doctorClinic.Counter.CounterPrefix)
        cmdClinic.Parameters.AddWithValue("@ctype", doctorClinic.Counter.CounterType)
        cmdClinic.Parameters.AddWithValue("@eKonsult", doctorClinic.Counter.canEKonsulta)
        cmdClinic.Parameters.AddWithValue("@flag", If(Not doctorClinic.Counter.showOnMainCounter, 2, doctorClinic.Counter.isQueueingCounter))
        cmdClinic.Parameters.AddWithValue("@ID", doctorClinic.Counter.Counter_ID)
        Return excecuteCommand(cmdClinic)
    End Function

    Public Function GetCertainCounterPreDefineCounterLabels(counterID As Long) As List(Of CounterBoard)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT [counterboarditem_id] ,[displayname] ,[displayctr] ,[counter_id] FROM [dbo].[counterboard] WHERE counter_id = @ID ORDER BY displayctr ASC"
            cmd.Parameters.AddWithValue("@ID", counterID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim boards As New List(Of CounterBoard)
                For Each row As DataRow In data.Rows
                    Dim boardItem As New CounterBoard
                    boardItem.CounterBoard_ID = row("counterboarditem_id")
                    boardItem.DisplayedName = row("displayname")
                    boardItem.DisplayCtr = row("displayctr")
                    boardItem.Counter_ID = row("counter_id")
                    boards.Add(boardItem)
                Next
                Return boards
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPreDefineCounterLabels(counterBoardID As Long) As CounterBoard
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT [counterboarditem_id] ,[displayname] ,[displayctr] ,[counter_id] FROM [dbo].[counterboard] WHERE counterboarditem_id = @ID"
            cmd.Parameters.AddWithValue("@ID", counterBoardID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim boardItem As New CounterBoard
                boardItem.CounterBoard_ID = data.Rows(0)("counterboarditem_id")
                boardItem.DisplayedName = data.Rows(0)("displayname")
                boardItem.DisplayCtr = data.Rows(0)("displayctr")
                boardItem.Counter_ID = data.Rows(0)("counter_id")
                Return boardItem
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllPCCCounter_ReportFilter() As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT [counter_id] ,[department] ,[section] ,[servicedescription] ,[servicedescription2], 
                                CASE
	                                WHEN section = 'CLAIM RESULTS' THEN 'CLAIM RESULTS (TRIAGE 06)'
	                                WHEN section = 'CONSULTATION' THEN 'CONSULTATION (TRIAGE 01 - TRIAGE 02)'
	                                WHEN section = 'Diagnostics' THEN 'DIAGNOSTICS (TRIAGE 03 - TRIAGE 05)'
	                                ELSE section
                                END as 'countername'
                               FROM [wmmcqms].[counter] 
                               WHERE counterType = 0 ORDER BY countername ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim counters As New List(Of Counter)
                For Each row As DataRow In data.Rows
                    Dim counter As New Counter
                    counter.Counter_ID = row("counter_id")
                    counter.Department = row("department")
                    counter.Section = row("section")
                    counter.ServiceDescription = row("countername")
                    counter.ServiceDescription2 = If(Not IsDBNull(row("servicedescription2")), row("servicedescription2"), "")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllMABClinic_ReportFilter() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM  [wmmcqms].[serverassigncounter] as a
                               JOIN [wmmcqms].[counter] as b on a.counter_id = b.counter_id
                               JOIN [wmmcqms].[server] as c on c.server_id = a.server_id
                               WHERE b.counterType = 1
                               ORDER BY fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim counters As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim counter As New ServerAssignCounter
                    counter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                    counter.Server_ID = row("server_id")
                    counter.Counter_ID = row("counter_id")
                    counter.Counter = New Counter
                    counter.Counter.Counter_ID = row("counter_id")
                    counter.Counter.Department = row("department")
                    counter.Counter.Section = row("section")
                    counter.Counter.ServiceDescription = If(Not IsDBNull(row("servicedescription")), row("servicedescription"), "")
                    counter.Counter.ServiceDescription2 = If(Not IsDBNull(row("servicedescription2")), row("servicedescription2"), "")
                    counter.Server = New Server
                    counter.Server.Server_ID = row("server_id")
                    counter.Server.FullName = row("fullname")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllPCCClinic_ReportFilter() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM  [wmmcqms].[serverassigncounter] as a
                               JOIN [wmmcqms].[counter] as b on a.counter_id = b.counter_id
                               JOIN [wmmcqms].[server] as c on c.server_id = a.server_id
                               WHERE b.counterType = 2
                               ORDER BY fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim counters As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim counter As New ServerAssignCounter
                    counter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                    counter.Server_ID = row("server_id")
                    counter.Counter_ID = row("counter_id")
                    counter.Counter = New Counter
                    counter.Counter.Counter_ID = row("counter_id")
                    counter.Counter.Department = row("department")
                    counter.Counter.Section = row("section")
                    counter.Counter.ServiceDescription = If(Not IsDBNull(row("servicedescription")), row("servicedescription"), "")
                    counter.Counter.ServiceDescription2 = If(Not IsDBNull(row("servicedescription2")), row("servicedescription2"), "")
                    counter.Server = New Server
                    counter.Server.Server_ID = row("server_id")
                    counter.Server.FullName = row("fullname")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllMABHybridClinic_ReportFilter() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM  [wmmcqms].[serverassigncounter] as a
                               JOIN [wmmcqms].[counter] as b on a.counter_id = b.counter_id
                               JOIN [wmmcqms].[server] as c on c.server_id = a.server_id
                               WHERE b.counterType = 3
                               ORDER BY fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim counters As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim counter As New ServerAssignCounter
                    counter.ServerAssignCounter_ID = row("serverassigncounter_ID")
                    counter.Server_ID = row("server_id")
                    counter.Counter_ID = row("counter_id")
                    counter.Counter = New Counter
                    counter.Counter.Counter_ID = row("counter_id")
                    counter.Counter.Department = row("department")
                    counter.Counter.Section = row("section")
                    counter.Counter.ServiceDescription = If(Not IsDBNull(row("servicedescription")), row("servicedescription"), "")
                    counter.Counter.ServiceDescription2 = If(Not IsDBNull(row("servicedescription2")), row("servicedescription2"), "")
                    counter.Server = New Server
                    counter.Server.Server_ID = row("server_id")
                    counter.Server.FullName = row("fullname")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function NewCounter(counter As Counter) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            If counter.canHelee Then
                Dim cmd2 As New SqlCommand
                cmd2.CommandText = "UPDATE [wmmcqms].[counter] SET [canHelee] = 0"
                CMDs.Add(cmd2)
            End If
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [wmmcqms].[counter] (healthcheckView,healthcheckAddEdit,canPaymentMethod,autotransfer_diagnosticrequest,autotransfer_prescriptiobrequest,autotransfer_screening,autotransfer_payment,department, section, servicedescription, counterPrefix, countercode, icon, isQueuingCounter,counterType,allowableTurnaroundTime ,[consultationView] ,[consultationAddEdit] ,[diagnosticView] ,[diagnosticAddEdit] ,[eprescirptionView] ,[eprescirptionAddEdit] ,[syncDetail] ,[initialconsultation] ,[erconsultation] ,[autotransfer_gcber] ,[autotransfer_respiber], [canEKonsulta], [canHelee], [autotransfer_ancillary]) VALUES 
                                           (@hcvw,@hcae,@pmethod,@autdiag,@autpresc,@autscreen,@autpay,@dept,@sec,@desc,@pre,@cod,@ico,@flag,@ctype,@tat,@conVw,@conAe,@diaVw,@diaAe,@epreVw,@epreAe,@sncInf,@initCon,@econ,@autgcb,@autrespi,@ekon,@helee,@ansc)"
            cmd.Parameters.AddWithValue("@autdiag", counter.AutoTransfer_Diagnostics)
            cmd.Parameters.AddWithValue("@autpresc", counter.AutoTransfer_Prescriptions)
            cmd.Parameters.AddWithValue("@autscreen", counter.AutoTransfer_Screening)
            cmd.Parameters.AddWithValue("@autpay", counter.AutoTransfer_Payment)
            cmd.Parameters.AddWithValue("@autgcb", counter.AutoTransfer_GCBER)
            cmd.Parameters.AddWithValue("@autrespi", counter.AutoTransfer_RespiER)
            cmd.Parameters.AddWithValue("@pmethod", counter.canHavePaymentMethod)
            cmd.Parameters.AddWithValue("@dept", counter.Department)
            cmd.Parameters.AddWithValue("@sec", counter.Section)
            cmd.Parameters.AddWithValue("@desc", counter.ServiceDescription)
            cmd.Parameters.AddWithValue("@pre", counter.CounterPrefix)
            cmd.Parameters.AddWithValue("@cod", counter.CounterCode)
            cmd.Parameters.AddWithValue("@ico", counter.Icon)
            cmd.Parameters.AddWithValue("@flag", counter.isQueueingCounter)
            cmd.Parameters.AddWithValue("@ctype", counter.CounterType)
            cmd.Parameters.AddWithValue("@tat", counter.allowedTurnaroundTime)
            cmd.Parameters.AddWithValue("@hcvw", counter.healthcheckView)
            cmd.Parameters.AddWithValue("@hcae", counter.healthcheckAddEdit)
            cmd.Parameters.AddWithValue("@conVw", counter.consultationView)
            cmd.Parameters.AddWithValue("@conAe", counter.consultationAddEdit)
            cmd.Parameters.AddWithValue("@initCon", counter.initialconsultation)
            cmd.Parameters.AddWithValue("@econ", counter.erconsultation)
            cmd.Parameters.AddWithValue("@diaVw", counter.diagnosticView)
            cmd.Parameters.AddWithValue("@diaAe", counter.diagnosticAddEdit)
            cmd.Parameters.AddWithValue("@epreVw", counter.eprescriptionView)
            cmd.Parameters.AddWithValue("@epreAe", counter.eprescriptionAddEdit)
            cmd.Parameters.AddWithValue("@sncInf", counter.SyncDetail)
            cmd.Parameters.AddWithValue("@ekon", counter.canEKonsulta)
            cmd.Parameters.AddWithValue("@helee", counter.canHelee)
            cmd.Parameters.AddWithValue("@ansc", counter.AutoTransfer_Ancillary)
            CMDs.Add(cmd)
            Return excecuteMultipleCommand(CMDs)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function UpdateCounter(counter As Counter) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            If counter.canHelee Then
                Dim cmd2 As New SqlCommand
                cmd2.CommandText = "UPDATE [wmmcqms].[counter] SET [canHelee] = 0"
                CMDs.Add(cmd2)
            End If
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [wmmcqms].[counter] SET canPaymentMethod=@pmethod,autotransfer_diagnosticrequest=@autdiag, autotransfer_prescriptiobrequest=@autpresc,autotransfer_screening=@autscreen,autotransfer_payment=@autpay,department =@dept,section=@sec,servicedescription=@desc,counterPrefix=@pre,countercode=@cod,icon=@ico,isQueuingCounter=@flag,counterType=@ctype,allowableTurnaroundTime=@tat,[consultationView]=@conVw,[consultationAddEdit]=@conAe,[diagnosticView]=@diaVw,[diagnosticAddEdit]=@diaAe,[eprescirptionView]=@epreVw,[eprescirptionAddEdit]=@epreAe,[syncDetail]=@sncInf,[initialconsultation]=@initCon,[erconsultation]=@econ,[autotransfer_gcber]=@autgcb,[autotransfer_respiber]=@autrespi,[healthcheckView]=@hcvw,[healthcheckAddEdit]=@hcae,[canEKonsulta]=@ekon,[canHelee]=@helee,[autotransfer_ancillary]=@ansc WHERE counter_id=@ID; 
                               UPDATE [wmmcqms].[serverassigncounter] SET isMain = @isM WHERE counter_id = @ID;"
            cmd.Parameters.AddWithValue("@autdiag", counter.AutoTransfer_Diagnostics)
            cmd.Parameters.AddWithValue("@autpresc", counter.AutoTransfer_Prescriptions)
            cmd.Parameters.AddWithValue("@autscreen", counter.AutoTransfer_Screening)
            cmd.Parameters.AddWithValue("@autpay", counter.AutoTransfer_Payment)
            cmd.Parameters.AddWithValue("@autgcb", counter.AutoTransfer_GCBER)
            cmd.Parameters.AddWithValue("@autrespi", counter.AutoTransfer_RespiER)
            cmd.Parameters.AddWithValue("@pmethod", counter.canHavePaymentMethod)
            cmd.Parameters.AddWithValue("@dept", counter.Department)
            cmd.Parameters.AddWithValue("@sec", counter.Section)
            cmd.Parameters.AddWithValue("@desc", counter.ServiceDescription)
            cmd.Parameters.AddWithValue("@pre", counter.CounterPrefix)
            cmd.Parameters.AddWithValue("@cod", counter.CounterCode)
            cmd.Parameters.AddWithValue("@ico", counter.Icon)
            cmd.Parameters.AddWithValue("@flag", If(counter.showOnMainCounter, 2, counter.isQueueingCounter))
            cmd.Parameters.AddWithValue("@isM", If(Not counter.isQueueingCounter > 0, 1, 0))
            cmd.Parameters.AddWithValue("@ctype", counter.CounterType)
            cmd.Parameters.AddWithValue("@tat", counter.allowedTurnaroundTime)
            cmd.Parameters.AddWithValue("@hcvw", counter.healthcheckView)
            cmd.Parameters.AddWithValue("@hcae", counter.healthcheckAddEdit)
            cmd.Parameters.AddWithValue("@conVw", counter.consultationView)
            cmd.Parameters.AddWithValue("@conAe", counter.consultationAddEdit)
            cmd.Parameters.AddWithValue("@initCon", counter.initialconsultation)
            cmd.Parameters.AddWithValue("@econ", counter.erconsultation)
            cmd.Parameters.AddWithValue("@diaVw", counter.diagnosticView)
            cmd.Parameters.AddWithValue("@diaAe", counter.diagnosticAddEdit)
            cmd.Parameters.AddWithValue("@epreVw", counter.eprescriptionView)
            cmd.Parameters.AddWithValue("@epreAe", counter.eprescriptionAddEdit)
            cmd.Parameters.AddWithValue("@sncInf", counter.SyncDetail)
            cmd.Parameters.AddWithValue("@ekon", counter.canEKonsulta)
            cmd.Parameters.AddWithValue("@helee", counter.canHelee)
            cmd.Parameters.AddWithValue("@ansc", counter.AutoTransfer_Ancillary)
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            CMDs.Add(cmd)
            Return excecuteMultipleCommand(CMDs)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function DeleteCounter(counter As Counter) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [wmmcqms].[counter] WHERE counter_id =@ID"
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            Return excecuteCommand(cmd)
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function PinnedCounter(severCounterShorcuts As List(Of SeverCounterShorcuts)) As Boolean
        Try
            Dim cmds As New List(Of SqlCommand)
            For Each serverCounterShorcut As SeverCounterShorcuts In severCounterShorcuts
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [wmmcqms].[servercountershorcut] (server_id, counter_id) VALUES (@sid,@cid)"
                cmd.Parameters.AddWithValue("@sid", serverCounterShorcut.Server_ID)
                cmd.Parameters.AddWithValue("@cid", serverCounterShorcut.Counter_ID)
                cmds.Add(cmd)
            Next
            Return excecuteMultipleCommand(cmds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function UnpinnedCounter(severCounterShorcuts As List(Of SeverCounterShorcuts)) As Boolean
        Try
            Dim cmds As New List(Of SqlCommand)
            For Each serverCounterShorcut As SeverCounterShorcuts In severCounterShorcuts
                Dim cmd As New SqlCommand
                cmd.CommandText = "DELETE FROM [wmmcqms].[servercountershorcut] WHERE servershorcut_id = @ID"
                cmd.Parameters.AddWithValue("@ID", serverCounterShorcut.ServerShorcut_ID)
                cmds.Add(cmd)
            Next
            Return excecuteMultipleCommand(cmds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function GetGCBERAutoTransfer() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where  autotransfer_gcber = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetRespiERAutoTransfer() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where  autotransfer_respiber = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetDiagnosticAutoTransfer() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_diagnosticrequest = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPrescriptionAutoTransfer() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_prescriptiobrequest = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPaymentAutoTransfer_Cash() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_payment = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPaymentAutoTransfer_Card() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_payment = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPaymentAutoTransfer_HMO() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_payment = 2"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPaymentAutoTransfer_PHIC() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_payment = 3"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetAncillaryAutoTransfer_LabExtraction() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_ancillary = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetAncillaryAutoTransfer_Radiology() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 AND autotransfer_ancillary = 2"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counter As New Counter
                counter.Counter_ID = data.Rows(0)("counter_id")
                counter.Department = data.Rows(0)("department")
                counter.Section = data.Rows(0)("section")
                counter.CounterCode = data.Rows(0)("countercode")
                counter.ServiceDescription = data.Rows(0)("servicedescription")
                counter.CounterPrefix = data.Rows(0)("counterPrefix")
                counter.Icon = data.Rows(0)("icon")
                counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return counter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerUnpinCounters(id As Long) As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] where isQueuingCounter >= 1 and counter_id NOT IN (SELECT counter_id FROM [wmmcqms].[servercountershorcut] WHERE server_id = @ID)"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim counters As New List(Of Counter)
                For Each rows As DataRow In data.Rows
                    Dim counter As New Counter
                    counter.Counter_ID = rows("counter_id")
                    counter.Department = rows("department")
                    counter.Section = rows("section")
                    counter.CounterCode = rows("countercode")
                    counter.ServiceDescription = rows("servicedescription")
                    counter.CounterPrefix = rows("counterPrefix")
                    counter.Icon = rows("icon")
                    counter.isQueueingCounter = rows("isQueuingCounter")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerCounterShorcuts(id As Long) As List(Of SeverCounterShorcuts)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[servercountershorcut] as a, [wmmcqms].[counter] as b WHERE a.counter_id = b.counter_id and server_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim serverShorcuts As New List(Of SeverCounterShorcuts)
                For Each rows As DataRow In data.Rows
                    Dim serverShorcut As New SeverCounterShorcuts
                    serverShorcut.ServerShorcut_ID = rows("servershorcut_id")
                    serverShorcut.Server_ID = rows("server_id")
                    serverShorcut.Counter_ID = rows("counter_id")

                    serverShorcut.Counter.Counter_ID = rows("counter_id")
                    serverShorcut.Counter.Department = rows("department")
                    serverShorcut.Counter.Section = rows("section")
                    serverShorcut.Counter.CounterCode = rows("countercode")
                    serverShorcut.Counter.ServiceDescription = rows("servicedescription")
                    serverShorcut.Counter.CounterPrefix = rows("counterPrefix")
                    serverShorcut.Counter.Icon = rows("icon")
                    serverShorcut.Counter.isQueueingCounter = rows("isQueuingCounter")
                    serverShorcut.Counter.canHaveCustomerName = rows("canCustomerName")
                    serverShorcut.Counter.canHavePaymentMethod = rows("canPaymentMethod")
                    serverShorcuts.Add(serverShorcut)
                Next
                Return serverShorcuts
            End If
            Return Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetAllCounters() As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] WHERE counterType = 0"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim counters As New List(Of Counter)
            For Each row As DataRow In data.Rows
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.CounterCode = row.Item("countercode")
                counter.Icon = row.Item("icon")
                counter.isQueueingCounter = row.Item("isQueuingCounter")
                counter.AutoTransfer_Diagnostics = row.Item("autotransfer_diagnosticrequest")
                counter.AutoTransfer_Prescriptions = row.Item("autotransfer_prescriptiobrequest")
                counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                counter.AutoTransfer_Payment = row.Item("autotransfer_payment")
                counter.AutoTransfer_GCBER = row.Item("autotransfer_gcber")
                counter.AutoTransfer_RespiER = row.Item("autotransfer_respiber")
                counter.CounterType = row.Item("counterType")
                counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                counter.healthcheckAddEdit = row.Item("healthcheckAddEdit")
                counter.healthcheckView = row.Item("healthcheckView")
                counter.consultationView = row.Item("consultationView")
                counter.consultationAddEdit = row.Item("consultationAddEdit")
                counter.initialconsultation = row.Item("initialconsultation")
                counter.erconsultation = row.Item("erconsultation")
                counter.diagnosticView = row.Item("diagnosticView")
                counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                counter.eprescriptionView = row.Item("eprescirptionView")
                counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                counter.SyncDetail = row.Item("syncDetail")
                counter.canEKonsulta = row.Item("canEKonsulta")
                counter.canHelee = row.Item("canHelee")
                counter.AutoTransfer_Ancillary = row.Item("autotransfer_ancillary")
                counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                counters.Add(counter)
            Next
            Return counters
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllClinicQueuingCounters_Sorted(aplhabetically As String, specialization As String) As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[serverassigncounter] as a JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 1"
            If aplhabetically.Trim.Length > 0 And specialization.Trim.Length > 0 Then
                cmd.CommandText = cmd.CommandText & "WEHRE (lastname like @aph) AND (specializaton = @spl)"
                cmd.Parameters.AddWithValue("@aph", aplhabetically.Trim.ToUpper & "%")
                cmd.Parameters.AddWithValue("@spl", specialization.Trim.ToUpper)
            ElseIf aplhabetically.Trim.Length > 0 Then
                cmd.CommandText = cmd.CommandText & "WEHRE (lastname like @aph)"
                cmd.Parameters.AddWithValue("@aph", aplhabetically.Trim.ToUpper & "%")
            ElseIf specialization.Trim.Length > 0 Then
                cmd.CommandText = cmd.CommandText & "WEHRE (specializaton = @spl)"
                cmd.Parameters.AddWithValue("@spl", specialization.Trim.ToUpper)
            End If
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllClinicQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * 
                               FROM [wmmcqms].[serverassigncounter] as a 
                               JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                               JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType > 0
                               ORDER BY b.fullname asc"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllMABClinicQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id]) FROM [wmmcqms].[servertransaction] WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                               FROM [wmmcqms].[serverassigncounter] as a 
                               JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                               JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 1
                               ORDER BY b.fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.isAvailable = If(row.Item("Logged") > 0, True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllERPhysicianQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id]) FROM [wmmcqms].[servertransaction] WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                                    FROM [wmmcqms].[serverassigncounter] as a 
                                    JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                                    JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 5 ORDER BY b.fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.isAvailable = If(row.Item("Logged") > 0, True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.PrimaryContactNo = If(Not IsDBNull(row.Item("primarycontact")), row.Item("primarycontact"), "")
                    clinic.Server.SecondaryContactNo = If(Not IsDBNull(row.Item("secondarycontact")), row.Item("secondarycontact"), "")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllPCCClinicQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id])
                                FROM [wmmcqms].[servertransaction]
                                WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                                FROM [wmmcqms].[serverassigncounter] as a
                                JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1
                                JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 2
                                --JOIN [wmmcqms].serverschedule d on a.server_id = d.ServerID
                                --WHERE (d.Availability <> '' and d.Availability IS NOT NULL) and d.[Day] = @day
                                ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@day", Now.ToString("dddd"))
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.isAvailable = If(row.Item("Logged") > 0, True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllPCCHybridClinicQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id]) FROM [wmmcqms].[servertransaction] WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                                    FROM [wmmcqms].[serverassigncounter] as a 
                                    JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                                    JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 4 ORDER BY b.fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.isAvailable = If(row.Item("Logged") > 0, True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllMABHybridClinicQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id]) FROM [wmmcqms].[servertransaction] WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                                    FROM [wmmcqms].[serverassigncounter] as a 
                                    JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                                    JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 3 ORDER BY b.fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = (row("serverassigncounter_ID"))
                    clinic.Server_ID = (row("server_id"))
                    clinic.Counter_ID = (row("counter_id"))
                    clinic.DateCreated = row("datecreated")
                    clinic.isMain = (row("isMain"))
                    clinic.isAvailable = If(row("Logged"), True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = (row("server_id"))
                    clinic.Server.EmmployeeID = (row("employee_id"))
                    clinic.Server.FullName = (row("fullname"))
                    clinic.Server.AssignDepartment = (row("assigndepartment"))
                    clinic.Server.FirstName = (row("firstname"))
                    clinic.Server.MiddleName = (row("middlename"))
                    clinic.Server.LastName = (row("lastname"))
                    clinic.Server.Specialization = (row("specializaton"))
                    clinic.Server.PTR = (row("ptr"))
                    clinic.Server.PRC = (row("prc"))
                    clinic.Server.AccountType = (row("accountType"))
                    clinic.Server.PhysicianID = (row("physician_id"))
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = (row("counter_id"))
                    clinic.Counter.Department = (row("department"))
                    clinic.Counter.Section = (row("section"))
                    clinic.Counter.ServiceDescription = (row("servicedescription"))
                    clinic.Counter.CounterPrefix = (row("counterPrefix"))
                    clinic.Counter.CounterCode = (row("countercode"))
                    clinic.Counter.Icon = (row("icon"))
                    clinic.Counter.isQueueingCounter = (row("isQueuingCounter"))
                    clinic.Counter.CounterType = (row("counterType"))
                    clinic.Counter.allowedTurnaroundTime = (row("allowableTurnaroundTime"))
                    clinic.Counter.consultationView = (row("consultationView"))
                    clinic.Counter.consultationAddEdit = (row("consultationAddEdit"))
                    clinic.Counter.diagnosticView = (row("diagnosticView"))
                    clinic.Counter.diagnosticAddEdit = (row("diagnosticAddEdit"))
                    clinic.Counter.eprescriptionView = (row("eprescirptionView"))
                    clinic.Counter.eprescriptionAddEdit = (row("eprescirptionAddEdit"))
                    clinic.Counter.SyncDetail = (row("syncDetail"))
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllEKonsultaQueuingCounters() As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, (SELECT count([serverassigncounter_id]) FROM [wmmcqms].[servertransaction] WHERE serverassigncounter_id = a.serverassigncounter_ID and datetimelogout is null and CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE())) as Logged
                                    FROM [wmmcqms].[serverassigncounter] as a 
                                    JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                                    JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.canEKonsulta = 1 ORDER BY b.fullname ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)

            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = (row("serverassigncounter_ID"))
                    clinic.Server_ID = (row("server_id"))
                    clinic.Counter_ID = (row("counter_id"))
                    clinic.DateCreated = row("datecreated")
                    clinic.isMain = (row("isMain"))
                    clinic.isAvailable = If(row("Logged"), True, False)
                    clinic.Server = New Server
                    clinic.Server.Server_ID = (row("server_id"))
                    clinic.Server.EmmployeeID = (row("employee_id"))
                    clinic.Server.FullName = (row("fullname"))
                    clinic.Server.AssignDepartment = (row("assigndepartment"))
                    clinic.Server.FirstName = (row("firstname"))
                    clinic.Server.MiddleName = (row("middlename"))
                    clinic.Server.LastName = (row("lastname"))
                    clinic.Server.Specialization = (row("specializaton"))
                    clinic.Server.PTR = (row("ptr"))
                    clinic.Server.PRC = (row("prc"))
                    clinic.Server.AccountType = (row("accountType"))
                    clinic.Server.PhysicianID = (row("physician_id"))
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = (row("counter_id"))
                    clinic.Counter.Department = (row("department"))
                    clinic.Counter.Section = (row("section"))
                    clinic.Counter.ServiceDescription = (row("servicedescription"))
                    clinic.Counter.CounterPrefix = (row("counterPrefix"))
                    clinic.Counter.CounterCode = (row("countercode"))
                    clinic.Counter.Icon = (row("icon"))
                    clinic.Counter.isQueueingCounter = (row("isQueuingCounter"))
                    clinic.Counter.CounterType = (row("counterType"))
                    clinic.Counter.allowedTurnaroundTime = (row("allowableTurnaroundTime"))
                    clinic.Counter.consultationView = (row("consultationView"))
                    clinic.Counter.consultationAddEdit = (row("consultationAddEdit"))
                    clinic.Counter.diagnosticView = (row("diagnosticView"))
                    clinic.Counter.diagnosticAddEdit = (row("diagnosticAddEdit"))
                    clinic.Counter.eprescriptionView = (row("eprescirptionView"))
                    clinic.Counter.eprescriptionAddEdit = (row("eprescirptionAddEdit"))
                    clinic.Counter.SyncDetail = (row("syncDetail"))
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllMABClinicQueuingCounters_Filtered(filterStr As String) As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * 
                               FROM [wmmcqms].[serverassigncounter] as a 
                               JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                               JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 1 AND c.isQueuingCounter = 1
                               WHERE lastname like @flt
                               ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@flt", filterStr.Trim.ToUpper & "%")
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim doctorClinics As New List(Of ServerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim clinic As New ServerAssignCounter
                    clinic.ServerAssignCounter_ID = row.Item("serverassigncounter_ID")
                    clinic.Server_ID = row.Item("server_id")
                    clinic.Counter_ID = row.Item("counter_id")
                    clinic.DateCreated = row.Item("datecreated")
                    clinic.isMain = row.Item("isMain")
                    clinic.Server = New Server
                    clinic.Server.Server_ID = row.Item("server_id")
                    clinic.Server.EmmployeeID = row.Item("employee_id")
                    clinic.Server.FullName = row.Item("fullname")
                    clinic.Server.AssignDepartment = row.Item("assigndepartment")
                    clinic.Server.FirstName = row.Item("firstname")
                    clinic.Server.MiddleName = row.Item("middlename")
                    clinic.Server.LastName = row.Item("lastname")
                    clinic.Server.Specialization = row.Item("specializaton")
                    clinic.Server.PTR = row.Item("ptr")
                    clinic.Server.PRC = row.Item("prc")
                    clinic.Server.AccountType = row.Item("accountType")
                    clinic.Server.PhysicianID = row.Item("physician_id")
                    clinic.Counter = New Counter
                    clinic.Counter.Counter_ID = row.Item("counter_id")
                    clinic.Counter.Department = row.Item("department")
                    clinic.Counter.Section = row.Item("section")
                    clinic.Counter.ServiceDescription = row.Item("servicedescription")
                    clinic.Counter.CounterPrefix = row.Item("counterPrefix")
                    clinic.Counter.CounterCode = row.Item("countercode")
                    clinic.Counter.Icon = row.Item("icon")
                    clinic.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    clinic.Counter.CounterType = row.Item("counterType")
                    clinic.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    clinic.Counter.consultationView = row.Item("consultationView")
                    clinic.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                    clinic.Counter.diagnosticView = row.Item("diagnosticView")
                    clinic.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                    clinic.Counter.eprescriptionView = row.Item("eprescirptionView")
                    clinic.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                    clinic.Counter.SyncDetail = row.Item("syncDetail")
                    clinic.Counter.showOnMainCounter = If(row.Item("isQueuingCounter") > 1, True, False)
                    doctorClinics.Add(clinic)
                Next
                Return doctorClinics
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainClinicDoctor(refNo As Long) As ServerAssignCounter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * 
                                FROM [wmmcqms].[serverassigncounter] as a 
                                JOIN [wmmcqms].[server] as b on a.server_id = b.server_id and b.accountType = 1 
                                JOIN [wmmcqms].[counter] as c on a.counter_id = c.counter_id and c.counterType = 1 AND c.isQueuingCounter = 1
                                WHERE a.serverassigncounter_ID = @ID"
            cmd.Parameters.AddWithValue("@ID", refNo)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim clinic As New ServerAssignCounter
                clinic.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_ID")
                clinic.Server_ID = data.Rows(0)("server_id")
                clinic.Counter_ID = data.Rows(0)("counter_id")
                clinic.DateCreated = data.Rows(0)("datecreated")
                clinic.isMain = data.Rows(0)("isMain")
                clinic.Server = New Server
                clinic.Server.Server_ID = data.Rows(0)("server_id")
                clinic.Server.EmmployeeID = data.Rows(0)("employee_id")
                clinic.Server.FullName = data.Rows(0)("fullname")
                clinic.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                clinic.Server.FirstName = data.Rows(0)("firstname")
                clinic.Server.MiddleName = data.Rows(0)("middlename")
                clinic.Server.LastName = data.Rows(0)("lastname")
                clinic.Server.Specialization = data.Rows(0)("specializaton")
                clinic.Server.PTR = data.Rows(0)("ptr")
                clinic.Server.PRC = data.Rows(0)("prc")
                clinic.Server.AccountType = data.Rows(0)("accountType")
                clinic.Server.PhysicianID = data.Rows(0)("physician_id")
                clinic.Counter = New Counter
                clinic.Counter.Counter_ID = data.Rows(0)("counter_id")
                clinic.Counter.Department = data.Rows(0)("department")
                clinic.Counter.Section = data.Rows(0)("section")
                clinic.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                clinic.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                clinic.Counter.CounterCode = data.Rows(0)("countercode")
                clinic.Counter.Icon = data.Rows(0)("icon")
                clinic.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                clinic.Counter.CounterType = data.Rows(0)("counterType")
                clinic.Counter.allowedTurnaroundTime = data.Rows(0)("allowableTurnaroundTime")
                clinic.Counter.consultationView = data.Rows(0)("consultationView")
                clinic.Counter.consultationAddEdit = data.Rows(0)("consultationAddEdit")
                clinic.Counter.diagnosticView = data.Rows(0)("diagnosticView")
                clinic.Counter.diagnosticAddEdit = data.Rows(0)("diagnosticAddEdit")
                clinic.Counter.eprescriptionView = data.Rows(0)("eprescirptionView")
                clinic.Counter.eprescriptionAddEdit = data.Rows(0)("eprescirptionAddEdit")
                clinic.Counter.SyncDetail = data.Rows(0)("syncDetail")
                clinic.Counter.showOnMainCounter = If(data.Rows(0)("isQueuingCounter") > 1, True, False)
                Return clinic
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllPCCQueuingCounters() As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] WHERE isQueuingCounter = 1 AND counterType = 0"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim counters As New List(Of Counter)
            For Each row As DataRow In data.Rows
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.ServiceDescription2 = If(Not IsDBNull(row.Item("servicedescription2")), row.Item("servicedescription2"), "")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.CounterCode = row.Item("countercode")
                counter.Icon = row.Item("icon")
                counter.canHelee = row.Item("canHelee")
                counter.isQueueingCounter = row.Item("isQueuingCounter")
                counter.CounterType = row.Item("counterType")
                counters.Add(counter)
            Next
            Return counters
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetHealeeCounter() As Counter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] WHERE isQueuingCounter = 1 AND counterType = 0 and canHelee = 1"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim counter As New Counter
                    counter.Counter_ID = data.Rows(0).Item("counter_id")
                    counter.Department = data.Rows(0).Item("department")
                    counter.Section = data.Rows(0).Item("section")
                    counter.ServiceDescription = data.Rows(0).Item("servicedescription")
                    counter.ServiceDescription2 = If(Not IsDBNull(data.Rows(0).Item("servicedescription2")), data.Rows(0).Item("servicedescription2"), "")
                    counter.CounterPrefix = data.Rows(0).Item("counterPrefix")
                    counter.CounterCode = data.Rows(0).Item("countercode")
                    counter.Icon = data.Rows(0).Item("icon")
                    counter.canHelee = data.Rows(0).Item("canHelee")
                    counter.isQueueingCounter = data.Rows(0).Item("isQueuingCounter")
                    counter.CounterType = data.Rows(0).Item("counterType")
                    Return counter
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

    Public Function GetAllQueuingCountersForTransferring() As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] WHERE isQueuingCounter <> 0 and counterType <= 0 ORDER BY section"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim counters As New List(Of Counter)
            For Each row As DataRow In data.Rows
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.CounterCode = row.Item("countercode")
                counter.Icon = row.Item("icon")
                counter.isQueueingCounter = row.Item("isQueuingCounter")
                counter.canHavePaymentMethod = row.Item("canPaymentMethod")
                counter.canHavePaymentMethod = row.Item("canPaymentMethod")
                counter.AutoTransfer_Payment = row.Item("autotransfer_payment")
                counter.AutoTransfer_Diagnostics = row.Item("autotransfer_diagnosticrequest")
                counter.AutoTransfer_Prescriptions = row.Item("autotransfer_prescriptiobrequest")
                counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                counters.Add(counter)
            Next
            Return counters
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerUnassignCounter(id As Long) As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from [wmmcqms].[counter] as a WHERE counterType = 0 AND counter_id NOT IN (SELECT counter_id from [wmmcqms].[serverassigncounter] WHERE server_id = @ID)"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim counters As New List(Of Counter)
            For Each row As DataRow In data.Rows
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.CounterCode = row.Item("countercode")
                counter.Icon = row.Item("icon")
                counter.isQueueingCounter = row.Item("isQueuingCounter")
                counters.Add(counter)
            Next
            Return counters
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainDoctorAssignedClinic(id As Long) As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from [wmmcqms].[counter] as a WHERE counterType != 0 AND counter_id IN (SELECT counter_id from [wmmcqms].[serverassigncounter] WHERE server_id = @ID)"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim counters As New List(Of Counter)
            For Each row As DataRow In data.Rows
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.CounterCode = row.Item("countercode")
                counter.CounterType = row.Item("counterType")
                counter.canEKonsulta = row.Item("canEKonsulta")
                counters.Add(counter)
            Next
            Return counters
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllSoloCounter() As List(Of Counter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[counter] WHERE isSoloCounter = 1 and isQueuingCounter > 0"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim counters As New List(Of Counter)
                For Each row As DataRow In data.Rows
                    Dim counter As New Counter
                    counter.Counter_ID = row.Item("counter_id")
                    counter.Department = row.Item("department")
                    counter.Section = row.Item("section")
                    counter.ServiceDescription = row.Item("servicedescription")
                    counter.CounterPrefix = row.Item("counterPrefix")
                    counter.CounterCode = row.Item("countercode")
                    counter.CounterType = row.Item("counterType")
                    counter.canEKonsulta = row.Item("canEKonsulta")
                    counter.Icon = row.Item("icon")
                    counters.Add(counter)
                Next
                Return counters
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function UpdateMainCounterOrder(counters As List(Of Counter)) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            Dim cmdResetOrder As New SqlCommand
            cmdResetOrder.CommandText = "UPDATE [wmmcqms].[counter] SET [maincounterctr] = 0 WHERE [maincounterctr] > 0;"
            CMDs.Add(cmdResetOrder)
            For Each counter As Counter In counters
                Dim cmdOrder As New SqlCommand
                cmdOrder.CommandText = "UPDATE [wmmcqms].[counter] SET [maincounterctr] = @ordr WHERE counter_id = @ID;"
                cmdOrder.Parameters.AddWithValue("@ordr", counter.MainCounterCTR)
                cmdOrder.Parameters.AddWithValue("@ID", counter.Counter_ID)
                CMDs.Add(cmdOrder)
            Next
            Return excecuteMultipleCommand(CMDs)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function
End Class
