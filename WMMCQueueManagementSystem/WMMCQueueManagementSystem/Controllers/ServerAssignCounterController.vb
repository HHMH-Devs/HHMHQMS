Imports System.Data
Imports System.Data.SqlClient
Public Class ServerAssignCounterController
    Public Function GetCertainServerAssignCounter(id As Long) As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from wmmcqms.counter as a JOIN wmmcqms.serverassigncounter as b ON a.counter_id = b.counter_id WHERE counterType = 0 AND b.server_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim serverAssignCounters As New List(Of ServerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim serverAssignCounter As New ServerAssignCounter
                serverAssignCounter.ServerAssignCounter_ID = row.Item("serverassignCounter_id")
                serverAssignCounter.Server_ID = row.Item("server_id")
                serverAssignCounter.Counter_ID = row.Item("counter_id")
                serverAssignCounter.DateCreated = row.Item("datecreated")
                serverAssignCounter.isMain = row.Item("isMain")
                serverAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                serverAssignCounter.Counter.Department = row.Item("department")
                serverAssignCounter.Counter.Section = row.Item("section")
                serverAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                serverAssignCounter.Counter.CounterCode = row.Item("countercode")
                serverAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                serverAssignCounter.Counter.Icon = row.Item("icon")
                serverAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                serverAssignCounters.Add(serverAssignCounter)
            Next
            Return serverAssignCounters
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerCertainAssignCounter(id As Long) As ServerAssignCounter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM wmmcqms.serverassigncounter as a 
                                JOIN wmmcqms.server as b ON a.server_id = b.server_id
                                JOIN wmmcqms.counter as c ON a.counter_id = c.counter_id
                                WHERE a.serverassigncounter_ID = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
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
                    clinic.Server.PrimaryContactNo = If(Not IsDBNull(data.Rows(0)("primarycontact")), data.Rows(0)("primarycontact"), "")
                    clinic.Server.SecondaryContactNo = If(Not IsDBNull(data.Rows(0)("secondarycontact")), data.Rows(0)("secondarycontact"), "")
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
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function AddServerAssignCounter(serverAssignCounters As List(Of ServerAssignCounter)) As Boolean
        Try
            Dim cmds As New List(Of SqlCommand)
            For Each serverAssignCounter As ServerAssignCounter In serverAssignCounters
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO wmmcqms.serverassigncounter (server_id, counter_id, isMain) VALUES (@serverid,@counterid,@ismain)"
                cmd.Parameters.AddWithValue("@serverid", serverAssignCounter.Server_ID)
                cmd.Parameters.AddWithValue("@counterid", serverAssignCounter.Counter_ID)
                cmd.Parameters.AddWithValue("@ismain", serverAssignCounter.isMain)
                cmds.Add(cmd)
            Next
            Return excecuteMultipleCommand(cmds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function DeleteServerAssignCounter(ids As List(Of Long)) As Boolean
        Try
            Dim cmds As New List(Of SqlCommand)
            For Each id As Long In ids
                Dim cmd As New SqlCommand
                cmd.CommandText = "DELETE FROM wmmcqms.serverassigncounter WHERE serverassigncounter_ID = @ID"
                cmd.Parameters.AddWithValue("@ID", id)
                cmds.Add(cmd)
            Next
            Return excecuteMultipleCommand(cmds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetServerAssignCounterOfCertainServer(server As Server) As List(Of ServerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.*,b.*,c.* from [wmmcqms].[serverassigncounter] as a, [wmmcqms].[counter] as b, [wmmcqms].[server] as c WHERE ( a.[counter_id] = b.[counter_id] and a.[server_id] = c.[server_id]) and a.[server_id] = @ID"
            cmd.Parameters.AddWithValue("@ID", server.Server_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim serverAssignCounters As New List(Of ServerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim serverAssignCounter As New ServerAssignCounter
                serverAssignCounter.ServerAssignCounter_ID = row.Item("serverassignCounter_id")
                serverAssignCounter.Server_ID = row.Item("server_id")
                serverAssignCounter.Counter_ID = row.Item("counter_id")
                serverAssignCounter.DateCreated = row.Item("datecreated")
                serverAssignCounter.isMain = row.Item("isMain")
                serverAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                serverAssignCounter.Counter.Department = row.Item("department")
                serverAssignCounter.Counter.Section = row.Item("section")
                serverAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                serverAssignCounter.Counter.CounterCode = row.Item("countercode")
                serverAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                serverAssignCounter.Counter.Icon = row.Item("icon")
                serverAssignCounter.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                serverAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                serverAssignCounter.Counter.CounterType = row.Item("counterType")
                serverAssignCounter.Counter.consultationView = row.Item("consultationView")
                serverAssignCounter.Counter.consultationAddEdit = row.Item("consultationAddEdit")
                serverAssignCounter.Counter.diagnosticView = row.Item("diagnosticView")
                serverAssignCounter.Counter.diagnosticAddEdit = row.Item("diagnosticAddEdit")
                serverAssignCounter.Counter.eprescriptionView = row.Item("eprescirptionView")
                serverAssignCounter.Counter.eprescriptionAddEdit = row.Item("eprescirptionAddEdit")
                serverAssignCounter.Counter.healthcheckView = row.Item("healthcheckView")
                serverAssignCounter.Counter.healthcheckAddEdit = row.Item("healthcheckAddEdit")
                serverAssignCounter.Counter.initialconsultation = row.Item("initialconsultation")
                serverAssignCounter.Counter.erconsultation = row.Item("erconsultation")
                serverAssignCounter.Counter.SyncDetail = row.Item("syncDetail")
                serverAssignCounter.Counter.canEKonsulta = row.Item("canEKonsulta")
                serverAssignCounter.Counter.canHelee = row.Item("canHelee")
                serverAssignCounter.Counter.generateScreening = row.Item("generateScreening")
                serverAssignCounter.Counter.AutoTransfer_Payment = row.Item("autotransfer_payment")
                serverAssignCounter.Counter.AutoTransfer_Diagnostics = row.Item("autotransfer_diagnosticrequest")
                serverAssignCounter.Counter.AutoTransfer_Prescriptions = row.Item("autotransfer_prescriptiobrequest")
                serverAssignCounter.Counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                serverAssignCounter.Server.Server_ID = row.Item("server_id")
                serverAssignCounter.Server.EmmployeeID = row.Item("employee_id")
                serverAssignCounter.Server.FullName = row.Item("fullname")
                serverAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                serverAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                serverAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                serverAssignCounter.Server.AssignDepartment = row.Item("assigndepartment")
                serverAssignCounter.Server.Specialization = If(Not IsDBNull(row.Item("specializaton")), row.Item("specializaton"), "")
                serverAssignCounter.Server.PRC = If(Not IsDBNull(row.Item("prc")), row.Item("prc"), "")
                serverAssignCounter.Server.PTR = If(Not IsDBNull(row.Item("ptr")), row.Item("ptr"), "")
                serverAssignCounter.Server.S2No = If(Not IsDBNull(row.Item("s2")), row.Item("s2"), "")
                serverAssignCounter.Server.AccountType = row.Item("accountType")
                serverAssignCounter.Server.PhysicianID = If(Not IsDBNull(row.Item("physician_id")), row.Item("physician_id"), "")
                serverAssignCounter.Server.Username = row.Item("username")
                serverAssignCounter.Server.Pasaword = row.Item("password")
                serverAssignCounters.Add(serverAssignCounter)
            Next
            Return serverAssignCounters
        Catch ex As SqlException
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function
End Class
