Imports System.Data
Imports System.Data.SqlClient
Public Class ServerTransactionController
    Public Function NewServerTransaction(serverAssignCounter As ServerAssignCounter) As ServerTransaction
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO wmmcqms.servertransaction (serverassigncounter_id, countername) VALUES (@serverassigncounterid,@cname);SELECT @@IDENTITY;"
            cmd.Parameters.AddWithValue("@serverassigncounterid", serverAssignCounter.ServerAssignCounter_ID)
            cmd.Parameters.AddWithValue("@cname", serverAssignCounter.Counter.ServiceDescription.ToUpper)
            Dim id As Long = excecuteCommandReturnID(cmd)
            If id > 0 Then
                Dim serverTransaction As New ServerTransaction
                serverTransaction = Me.GetCertainServerTransaction(id)
                Return serverTransaction
            End If
            Return Nothing
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function NewBoardTrasaction(counterBoardTransaction As CounterBoardTransaction) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[counterboardtransaction] ([counterboarditem_id] ,[counter_id] ,[servertransaction_id]) VALUES (@cbID,@cID,@stID)"
            cmd.Parameters.AddWithValue("@cbID", counterBoardTransaction.CounterBoard_ID)
            cmd.Parameters.AddWithValue("@cID", counterBoardTransaction.Counter_ID)
            cmd.Parameters.AddWithValue("@stID", counterBoardTransaction.ServerTransaction_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetCertainServerTransaction2(id As Long) As ServerTransaction
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM wmmcqms.servertransaction as a, wmmcqms.serverassigncounter as b, wmmcqms.server as c, wmmcqms.counter as d  where (a.serverassigncounter_id = b.serverassigncounter_id and b.server_id = c.server_id and b.counter_id = d.counter_id) and a.servertransaction_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim serverTransaction As New ServerTransaction
                serverTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                serverTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                serverTransaction.CounterName = data.Rows(0)("countername")
                serverTransaction.DateTimeLogin = data.Rows(0)("datetimelogin")
                serverTransaction.ServerAssignCounter.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                serverTransaction.ServerAssignCounter.Server_ID = data.Rows(0)("server_id")
                serverTransaction.ServerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                serverTransaction.ServerAssignCounter.DateCreated = data.Rows(0)("datecreated")
                serverTransaction.ServerAssignCounter.isMain = data.Rows(0)("isMain")
                serverTransaction.ServerAssignCounter.Server.Server_ID = data.Rows(0)("server_id")
                serverTransaction.ServerAssignCounter.Server.EmmployeeID = data.Rows(0)("employee_id")
                serverTransaction.ServerAssignCounter.Server.FullName = data.Rows(0)("fullname")
                serverTransaction.ServerAssignCounter.Server.AssignDepartment = data.Rows(0)("assigndepartment")
                serverTransaction.ServerAssignCounter.Server.Username = data.Rows(0)("username")
                serverTransaction.ServerAssignCounter.Server.Pasaword = data.Rows(0)("password")
                serverTransaction.ServerAssignCounter.Counter.Counter_ID = data.Rows(0)("counter_id")
                serverTransaction.ServerAssignCounter.Counter.Department = data.Rows(0)("department")
                serverTransaction.ServerAssignCounter.Counter.Section = data.Rows(0)("section")
                serverTransaction.ServerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                serverTransaction.ServerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                serverTransaction.ServerAssignCounter.Counter.CounterCode = data.Rows(0)("countercode")
                serverTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                serverTransaction.ServerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                serverTransaction.ServerAssignCounter.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                Return serverTransaction
            End If
            Return Nothing
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerTransaction(id As Long) As ServerTransaction
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT servertransaction_id, serverassigncounter_id, countername, datetimelogin FROM wmmcqms.servertransaction WHERE servertransaction_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim serverTransaction As New ServerTransaction
                serverTransaction.ServerTransaction_ID = data.Rows(0).Item("servertransaction_id")
                serverTransaction.ServerAssignCounter_ID = data.Rows(0).Item("serverassigncounter_id")
                serverTransaction.DateTimeLogin = data.Rows(0).Item("datetimelogin")
                serverTransaction.CounterName = data.Rows(0).Item("countername")
                Try
                    serverTransaction.DateTimeLogout = data.Rows(0).Item("datetimelogout")
                Catch ex As Exception
                    serverTransaction.DateTimeLogout = Nothing
                End Try
                Return serverTransaction
            End If
            Return Nothing
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function UnserveAllCustomerOfCertainServerIfSkipped(serverTransaction As ServerTransaction) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.servedcustomer SET datetimeservedstart = NULL  WHERE datetimeservedend is NULL AND servertransaction_id = @ID"
            cmd.Parameters.AddWithValue("@ID", serverTransaction.ServerTransaction_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function LogoutSession(id As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.servertransaction SET datetimelogout= CURRENT_TIMESTAMP WHERE servertransaction_id = @ID; UPDATE wmmcqms.servedcustomer SET datetimeservedstart = NULL  WHERE datetimeservedend is NULL AND servertransaction_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function UpdateCertainServerTransactionC(serverTransaction As ServerTransaction) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.servertransaction SET countername=@cname,datetimelogout= @out WHERE servertransaction_id = @ID"
            cmd.Parameters.AddWithValue("@ID", serverTransaction.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@cname", serverTransaction.CounterName)
            cmd.Parameters.AddWithValue("@out", If(IsNothing(serverTransaction.DateTimeLogout), DBNull.Value, serverTransaction.DateTimeLogout))
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

End Class
