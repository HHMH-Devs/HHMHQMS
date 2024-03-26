Imports System.Data.SqlClient
Public Class CustomerAssignCounterController
    Public Function RemoveCertainPatientUnusedQueuedNumber(infoID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [wmmcqms].[customerassigncounter] WHERE customerassigncounter_id IN
                               (SELECT customerassigncounter_id FROM [wmmcqms].[customerassigncounter] as a
                               JOIN [wmmcqms].[customer] as b on b.customer_id = a.customer_id and b.info_id = @ID
                               WHERE CONVERT(DATE, a.datetimequeued) = CONVERT(DATE, GETDATE()) AND a.customerassigncounter_id NOT IN (SELECT customerassigncounter_id FROM [wmmcqms].[servedcustomer]))"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RemoveCertainPatientCurrentQueuedNumber(queueID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [wmmcqms].[customerassigncounter] WHERE customerassigncounter_id = @QID;"
            cmd.Parameters.AddWithValue("@QID", queueID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RemoveCertainPatientUnusedAndCurrentQueuedNumber(infoID As Long, queueID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [wmmcqms].[customerassigncounter] WHERE customerassigncounter_id IN
                               (SELECT customerassigncounter_id FROM [wmmcqms].[customerassigncounter] as a
                               JOIN [wmmcqms].[customer] as b on b.customer_id = a.customer_id and b.info_id = @ID
                               WHERE CONVERT(DATE, a.datetimequeued) = CONVERT(DATE, GETDATE()) AND a.customerassigncounter_id = @QID OR a.customerassigncounter_id NOT IN (SELECT customerassigncounter_id FROM [wmmcqms].[servedcustomer]))"
            cmd.Parameters.AddWithValue("@ID", infoID)
            cmd.Parameters.AddWithValue("@QID", queueID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllPatientServedBy_MultipleCounter(dt1 As Date, dt2 As Date, counterIDs As List(Of Long)) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            For x As Integer = 0 To counterIDs.Count - 1
                qry = qry & " or a.counter_id = @ID" & x
                cmd.Parameters.AddWithValue("@ID" & x, counterIDs(x))
            Next
            cmd.CommandText = "SELECT DISTINCT c.* FROM [wmmcqms].[customerassigncounter] as a
                                    JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                    JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id ) 
                                   WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND (a.counter_id = 0" & qry & ") ORDER BY c.lastname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounters = New List(Of CustomerAssignCounter)
                    customerQueue.CustomerAssignCounters = Me.GetCertainCustomerQueueHistoryByDate(customerQueue.CustomerInfo.Info_ID, dt1, dt2)
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllPatientTransactions_ByCounter(dt1 As Date, dt2 As Date, counterID As Long) As List(Of OutpatientTAT)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.customerassigncounter_id ,a.datetimequeued,a.queuenumber,
	                                   b.counter_id,b.department,b.section,b.servicedescription,b.counterPrefix,
                                       c.info_id,c.firstname,c.middlename,c.lastname,c.sex,c.birthdate,c.FK_emdPatients 
	                                FROM [wmmcqms].[customerassigncounter] as a
	                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
	                                JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id ) 
	                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND a.counter_id = @ID
                                GROUP BY a.customerassigncounter_id, a.datetimequeued,a.queuenumber,b.counter_id,b.department,b.section,b.servicedescription,b.counterPrefix, c.info_id,c.firstname,c.middlename,c.lastname,c.sex,c.birthdate,c.FK_emdPatients
                                ORDER BY CONVERT(DATE,a.datetimequeued),c.lastname ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            cmd.Parameters.AddWithValue("@ID", counterID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim OPDTatReport As New List(Of OutpatientTAT)
                For Each row As DataRow In data.Rows
                    Dim OPDTatItem As New OutpatientTAT
                    OPDTatItem.CustomerAssignCounter_ID = row("customerassigncounter_id")
                    OPDTatItem.DateTimeQueued = row("datetimequeued")
                    OPDTatItem.QueueNumber = row("queuenumber")
                    OPDTatItem.Counter_ID = row("counter_id")
                    OPDTatItem.Department = row("department")
                    OPDTatItem.Section = row("section")
                    OPDTatItem.ServiceDescription = row("servicedescription")
                    OPDTatItem.CounterPrefix = row("counterPrefix")
                    OPDTatItem.Info_ID = row("info_id")
                    OPDTatItem.FirstName = row("firstname")
                    OPDTatItem.MiddleName = row("middlename")
                    OPDTatItem.LastName = row("lastname")
                    OPDTatItem.Sex = row("sex")
                    OPDTatItem.BirthDate = row("birthdate")
                    OPDTatItem.FK_emdPatient = row("FK_emdPatients")
                    OPDTatItem.QueuingTransactions = New List(Of CustomerAssignCounter)
                    OPDTatItem.QueuingTransactions = Me.GetCertainPatientQueueHistoryByDate(OPDTatItem.Info_ID, OPDTatItem.DateTimeQueued)
                    OPDTatReport.Add(OPDTatItem)
                Next
                Return OPDTatReport
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientQueueHistoryByDate(infoID As Long, dt As Date) As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *,CASE
		                                WHEN b.section = 'CLAIM RESULTS' THEN 'CLAIM RESULTS (TRIAGE 06)'
		                                WHEN b.section = 'CONSULTATION' THEN 'CONSULTATION (TRIAGE 01 - TRIAGE 02)'
		                                WHEN b.section = 'Diagnostics' THEN 'DIAGNOSTICS (TRIAGE 03 - TRIAGE 05)'
		                                ELSE b.section
		                                END as 'ctrname'
	                                FROM [wmmcqms].[customerassigncounter] as a
	                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
	                                LEFT JOIN [wmmcqms].[servedcustomer] as c on c.customerassigncounter_id = a.customerassigncounter_id
	                                LEFT JOIN [wmmcqms].servertransaction as d on d.servertransaction_id = c.servertransaction_id
	                                LEFT JOIN [wmmcqms].serverassigncounter as e on e.serverassigncounter_ID = d.serverassigncounter_id
	                                LEFT JOIN [wmmcqms].server as f on f.server_id = e.server_id
                                WHERE CONVERT(DATE,a.datetimequeued) = CONVERT(DATE,@dt) AND a.customer_id in (SELECT customer_id from [wmmcqms].customer where info_id = @ID)  
                                ORDER BY a.customerassigncounter_id;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            cmd.Parameters.AddWithValue("@dt", dt)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim queueHistoryList As New List(Of CustomerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim customerInQueue As New CustomerAssignCounter
                    customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                    customerInQueue.Counter_ID = row.Item("counter_id")
                    customerInQueue.Customer_ID = row.Item("customer_id")
                    customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                    customerInQueue.Result = row.Item("result")
                    customerInQueue.Priority = row.Item("priority")
                    customerInQueue.QueueNumber = row.Item("queuenumber")
                    customerInQueue.Counter = New Counter
                    customerInQueue.Counter.Counter_ID = row.Item("counter_id")
                    customerInQueue.Counter.Department = row.Item("department")
                    customerInQueue.Counter.Section = row.Item("ctrname")
                    customerInQueue.Counter.CounterCode = row.Item("countercode")
                    customerInQueue.Counter.ServiceDescription = row.Item("servicedescription")
                    customerInQueue.Counter.CounterPrefix = row.Item("counterPrefix")
                    customerInQueue.Counter.Icon = row.Item("icon")
                    customerInQueue.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    customerInQueue.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    customerInQueue.Counter.CounterType = row.Item("counterType")
                    If Not IsDBNull(row.Item("served_id")) Then
                        customerInQueue.ServedCustomer = New ServedCustomer
                        customerInQueue.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                        customerInQueue.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                        customerInQueue.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                        customerInQueue.ServedCustomer.ServerTransaction = New ServerTransaction
                        customerInQueue.ServedCustomer.ServerTransaction.ServerTransaction_ID = If(Not IsDBNull(row.Item("servertransaction_id")), row.Item("servertransaction_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = If(Not IsDBNull(row.Item("serverassigncounter_id")), row.Item("serverassigncounter_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server = New Server
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.Server_ID = If(Not IsDBNull(row.Item("server_id")), row.Item("server_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                    End If
                    customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                    queueHistoryList.Add(customerInQueue)
                Next
                Return queueHistoryList
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetAllPatientServedBy_Counter(dt1 As Date, dt2 As Date, counterID As Long) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            If counterID > 0 Then
                cmd.CommandText = "SELECT DISTINCT c.* FROM [wmmcqms].[customerassigncounter] as a
                                    JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                    JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id ) 
                                   WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND a.counter_id = @ID ORDER BY c.lastname ASC"
                cmd.Parameters.AddWithValue("@ID", counterID)
            Else
                cmd.CommandText = "SELECT DISTINCT c.* FROM [wmmcqms].[customerassigncounter] as a
                                    JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                    JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id ) 
                                   WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) ORDER BY c.lastname ASC"
            End If
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounters = New List(Of CustomerAssignCounter)
                    customerQueue.CustomerAssignCounters = Me.GetCertainCustomerQueueHistoryByDate(customerQueue.CustomerInfo.Info_ID, dt1, dt2)
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainCustomerQueueHistoryByDate(infoID As Long, dt1 As Date, dt2 As Date) As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *,CASE
                                        WHEN b.section = 'CLAIM RESULTS' THEN 'CLAIM RESULTS (TRIAGE 06)'
                                        WHEN b.section = 'CONSULTATION' THEN 'CONSULTATION (TRIAGE 01 - TRIAGE 02)'
                                        WHEN b.section = 'Diagnostics' THEN 'DIAGNOSTICS (TRIAGE 03 - TRIAGE 05)'
                                        ELSE b.section
                                        END as 'ctrname'
                                FROM [wmmcqms].[customerassigncounter] as a
                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                LEFT JOIN [wmmcqms].[servedcustomer] as c on c.customerassigncounter_id = a.customerassigncounter_id
                                LEFT JOIN [wmmcqms].servertransaction as d on d.servertransaction_id = c.servertransaction_id
                                LEFT JOIN [wmmcqms].serverassigncounter as e on e.serverassigncounter_ID = d.serverassigncounter_id
                                LEFT JOIN [wmmcqms].server as f on f.server_id = e.server_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND a.customer_id in (SELECT customer_id from [wmmcqms].customer where info_id = @ID)  
                                ORDER BY a.customerassigncounter_id;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim queueHistoryList As New List(Of CustomerAssignCounter)
                For Each row As DataRow In data.Rows
                    Dim customerInQueue As New CustomerAssignCounter
                    customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                    customerInQueue.Counter_ID = row.Item("counter_id")
                    customerInQueue.Customer_ID = row.Item("customer_id")
                    customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                    customerInQueue.Result = row.Item("result")
                    customerInQueue.Priority = row.Item("priority")
                    customerInQueue.QueueNumber = row.Item("queuenumber")
                    customerInQueue.Counter = New Counter
                    customerInQueue.Counter.Counter_ID = row.Item("counter_id")
                    customerInQueue.Counter.Department = row.Item("department")
                    customerInQueue.Counter.Section = row.Item("ctrname")
                    customerInQueue.Counter.CounterCode = row.Item("countercode")
                    customerInQueue.Counter.ServiceDescription = row.Item("servicedescription")
                    customerInQueue.Counter.CounterPrefix = row.Item("counterPrefix")
                    customerInQueue.Counter.Icon = row.Item("icon")
                    customerInQueue.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    customerInQueue.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    customerInQueue.Counter.CounterType = row.Item("counterType")
                    If Not IsDBNull(row.Item("served_id")) Then
                        customerInQueue.ServedCustomer = New ServedCustomer
                        customerInQueue.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                        customerInQueue.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                        customerInQueue.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                        customerInQueue.ServedCustomer.ServerTransaction = New ServerTransaction
                        customerInQueue.ServedCustomer.ServerTransaction.ServerTransaction_ID = If(Not IsDBNull(row.Item("servertransaction_id")), row.Item("servertransaction_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = If(Not IsDBNull(row.Item("serverassigncounter_id")), row.Item("serverassigncounter_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server = New Server
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.Server_ID = If(Not IsDBNull(row.Item("server_id")), row.Item("server_id"), 0)
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                        customerInQueue.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                    End If
                    customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                    queueHistoryList.Add(customerInQueue)
                Next
                Return queueHistoryList
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function


    Public Function GetAncillarySummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 
                                a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
                                From wmmcqms.counter a where a.counter_id = 9 or a.counter_id = 21 or a.counter_id = 20 or a.counter_id = 19 ORDER BY a.counterStepByStep, countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = data.Rows(0)("counter_id")
                summary.Counter.Department = data.Rows(0)("department")
                summary.Counter.Section = data.Rows(0)("countername")
                summary.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                summary.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                summary.Counter.CounterCode = data.Rows(0)("countercode")
                summary.Counter.Icon = data.Rows(0)("icon")
                summary.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                summary.Counter.AutoTransfer_Screening = data.Rows(0)("autotransfer_screening")
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAdmittingSummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT
                a.section as 'countername', a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
            From wmmcqms.counter a where a.counter_id = 54 ORDER BY a.counterStepByStep, countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = data.Rows(0)("counter_id")
                summary.Counter.Department = data.Rows(0)("department")
                summary.Counter.Section = data.Rows(0)("countername")
                summary.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                summary.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                summary.Counter.CounterCode = data.Rows(0)("countercode")
                summary.Counter.Icon = data.Rows(0)("icon")
                summary.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                summary.Counter.AutoTransfer_Screening = data.Rows(0)("autotransfer_screening")
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRadiologySummaryByDate(dt1 As Date, dt2 As Date) As List(Of CounterSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 
                                a.section as 'countername',
                                a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
                               From wmmcqms.counter a where (a.counter_id = 54) ORDER BY a.counterStepByStep, countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of CounterSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New CounterSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("countername")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Counter.CounterPrefix = row.Item("counterPrefix")
                    summary.Counter.CounterCode = row.Item("countercode")
                    summary.Counter.Icon = row.Item("icon")
                    summary.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    summary.Counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientServedBy_Radiology(dt1 As Date, dt2 As Date) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT * FROM [wmmcqms].[customerassigncounter] as a
                                LEFT JOIN [wmmcqms].servedcustomer as x on x.customerassigncounter_id = a.customerassigncounter_id
                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id )
                                LEFT JOIN [wmmcqms].servertransaction as d on d.servertransaction_id = x.servertransaction_id
                                LEFT JOIN [wmmcqms].serverassigncounter as e on e.serverassigncounter_ID = d.serverassigncounter_id
                                LEFT JOIN [wmmcqms].server as f on f.server_id = e.server_id                               
                               WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND (a.counter_id = 54) ORDER BY a.counter_id, a.customerassigncounter_id ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounter = New CustomerAssignCounter
                    customerQueue.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                    customerQueue.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                    customerQueue.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                    customerQueue.CustomerAssignCounter.Result = row.Item("result")
                    customerQueue.CustomerAssignCounter.Priority = row.Item("priority")
                    customerQueue.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                    customerQueue.CustomerAssignCounter.Counter = New Counter
                    customerQueue.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Counter.Department = row.Item("department")
                    customerQueue.CustomerAssignCounter.Counter.Section = row.Item("section")
                    customerQueue.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                    customerQueue.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                    customerQueue.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                    customerQueue.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                    customerQueue.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    customerQueue.CustomerAssignCounter.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    customerQueue.CustomerAssignCounter.Counter.CounterType = row.Item("counterType")
                    customerQueue.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(customerQueue.CustomerAssignCounter)
                    If Not IsDBNull(row.Item("served_id")) Then
                        customerQueue.CustomerAssignCounter.ServedCustomer = New ServedCustomer
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction = New ServerTransaction
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerTransaction_ID = If(Not IsDBNull(row.Item("servertransaction_id")), row.Item("servertransaction_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = If(Not IsDBNull(row.Item("serverassigncounter_id")), row.Item("serverassigncounter_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server = New Server
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.Server_ID = If(Not IsDBNull(row.Item("server_id")), row.Item("server_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                    End If
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetLaboratorySummaryByDate(dt1 As Date, dt2 As Date) As List(Of CounterSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT
                                a.section as 'countername',
                                a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
                                From wmmcqms.counter a where a.counter_id = 38 ORDER BY a.counterStepByStep, countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of CounterSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New CounterSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("countername")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Counter.CounterPrefix = row.Item("counterPrefix")
                    summary.Counter.CounterCode = row.Item("countercode")
                    summary.Counter.Icon = row.Item("icon")
                    summary.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    summary.Counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientServedBy_Laboratory(dt1 As Date, dt2 As Date) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT * FROM [wmmcqms].[customerassigncounter] as a
                                LEFT JOIN [wmmcqms].servedcustomer as x on x.customerassigncounter_id = a.customerassigncounter_id
                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id )
                                LEFT JOIN [wmmcqms].servertransaction as d on d.servertransaction_id = x.servertransaction_id
                                LEFT JOIN [wmmcqms].serverassigncounter as e on e.serverassigncounter_ID = d.serverassigncounter_id
                                LEFT JOIN [wmmcqms].server as f on f.server_id = e.server_id                               
                               WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND a.counter_id = 38 ORDER BY a.customerassigncounter_id ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounter = New CustomerAssignCounter
                    customerQueue.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                    customerQueue.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                    customerQueue.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                    customerQueue.CustomerAssignCounter.Result = row.Item("result")
                    customerQueue.CustomerAssignCounter.Priority = row.Item("priority")
                    customerQueue.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                    customerQueue.CustomerAssignCounter.Counter = New Counter
                    customerQueue.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Counter.Department = row.Item("department")
                    customerQueue.CustomerAssignCounter.Counter.Section = row.Item("section")
                    customerQueue.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                    customerQueue.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                    customerQueue.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                    customerQueue.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                    customerQueue.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    customerQueue.CustomerAssignCounter.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    customerQueue.CustomerAssignCounter.Counter.CounterType = row.Item("counterType")
                    customerQueue.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(customerQueue.CustomerAssignCounter)
                    If Not IsDBNull(row.Item("served_id")) Then
                        customerQueue.CustomerAssignCounter.ServedCustomer = New ServedCustomer
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction = New ServerTransaction
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerTransaction_ID = If(Not IsDBNull(row.Item("servertransaction_id")), row.Item("servertransaction_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = If(Not IsDBNull(row.Item("serverassigncounter_id")), row.Item("serverassigncounter_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server = New Server
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.Server_ID = If(Not IsDBNull(row.Item("server_id")), row.Item("server_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                    End If
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetBillingSummaryByDate(dt1 As Date, dt2 As Date) As List(Of CounterSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 
                                a.section as 'countername',
                                a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
                               From wmmcqms.counter a where (a.counter_id = 34 or a.counter_id = 35) ORDER BY a.counterStepByStep, countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of CounterSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New CounterSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("countername")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Counter.CounterPrefix = row.Item("counterPrefix")
                    summary.Counter.CounterCode = row.Item("countercode")
                    summary.Counter.Icon = row.Item("icon")
                    summary.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    summary.Counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientServedBy_Billing(dt1 As Date, dt2 As Date) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT * FROM [wmmcqms].[customerassigncounter] as a
                                LEFT JOIN [wmmcqms].servedcustomer as x on x.customerassigncounter_id = a.customerassigncounter_id
                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id )
                                LEFT JOIN [wmmcqms].servertransaction as d on d.servertransaction_id = x.servertransaction_id
                                LEFT JOIN [wmmcqms].serverassigncounter as e on e.serverassigncounter_ID = d.serverassigncounter_id
                                LEFT JOIN [wmmcqms].server as f on f.server_id = e.server_id                               
                               WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND (a.counter_id = 34 or a.counter_id = 35) ORDER BY a.customerassigncounter_id ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounter = New CustomerAssignCounter
                    customerQueue.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                    customerQueue.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                    customerQueue.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                    customerQueue.CustomerAssignCounter.Result = row.Item("result")
                    customerQueue.CustomerAssignCounter.Priority = row.Item("priority")
                    customerQueue.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                    customerQueue.CustomerAssignCounter.Counter = New Counter
                    customerQueue.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                    customerQueue.CustomerAssignCounter.Counter.Department = row.Item("department")
                    customerQueue.CustomerAssignCounter.Counter.Section = row.Item("section")
                    customerQueue.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                    customerQueue.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                    customerQueue.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                    customerQueue.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                    customerQueue.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    customerQueue.CustomerAssignCounter.Counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                    customerQueue.CustomerAssignCounter.Counter.CounterType = row.Item("counterType")
                    customerQueue.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(customerQueue.CustomerAssignCounter)
                    If Not IsDBNull(row.Item("served_id")) Then
                        customerQueue.CustomerAssignCounter.ServedCustomer = New ServedCustomer
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction = New ServerTransaction
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerTransaction_ID = If(Not IsDBNull(row.Item("servertransaction_id")), row.Item("servertransaction_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = If(Not IsDBNull(row.Item("serverassigncounter_id")), row.Item("serverassigncounter_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server = New Server
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.Server_ID = If(Not IsDBNull(row.Item("server_id")), row.Item("server_id"), 0)
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FirstName = If(Not IsDBNull(row.Item("firstname")), row.Item("firstname"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.MiddleName = If(Not IsDBNull(row.Item("middlename")), row.Item("middlename"), "")
                        customerQueue.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.LastName = If(Not IsDBNull(row.Item("lastname")), row.Item("lastname"), "")
                    End If
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPatientServedBy_Admitting(dt1 As Date, dt2 As Date) As List(Of CustomerQueuedSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT c.* FROM [wmmcqms].[customerassigncounter] as a
                                JOIN [wmmcqms].[counter] as b on b.counter_id = a.counter_id
                                JOIN [dbo].[customerinfo] as c on c.info_id IN (SELECT info_id from [wmmcqms].[customer] where customer_id = a.customer_id ) 
                               WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2) AND a.counter_id = 2 ORDER BY c.lastname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim customerQueueSummary As New List(Of CustomerQueuedSummary)
                For Each row As DataRow In data.Rows
                    Dim customerQueue As New CustomerQueuedSummary
                    customerQueue.CustomerInfo = New CustomerInfo
                    customerQueue.CustomerInfo.Info_ID = row("info_id")
                    customerQueue.CustomerInfo.FirstName = row("firstname")
                    customerQueue.CustomerInfo.Middlename = row("middlename")
                    customerQueue.CustomerInfo.Lastname = row("lastname")
                    customerQueue.CustomerInfo.Sex = row("sex")
                    customerQueue.CustomerInfo.BirthDate = row("birthdate")
                    customerQueue.CustomerInfo.FK_emdPatients = row("FK_emdPatients")
                    customerQueue.CustomerAssignCounters = New List(Of CustomerAssignCounter)
                    customerQueue.CustomerAssignCounters = Me.GetCertainCustomerQueueHistoryByDate(customerQueue.CustomerInfo.Info_ID, dt1, dt2)
                    customerQueueSummary.Add(customerQueue)
                Next
                Return customerQueueSummary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllPatientQueuedByDate(dt1 As Date, dt2 As Date) As List(Of PatientCensusSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT a.info_id, a.lastname, a.firstname, a.middlename
                               FROM dbo.customerinfo as a
                               LEFT JOIN [wmmcqms].[customer] as b ON a.info_id = b.info_id
                               WHERE CONVERT(DATE,b.dateofvisit) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2)
                               ORDER BY a.lastname, a.firstname, a.middlename"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim patientList As New List(Of PatientCensusSummary)
                For Each row As DataRow In data.Rows
                    Dim patientItem As New PatientCensusSummary
                    patientItem.PatientInfo = New CustomerInfo
                    patientItem.PatientInfo.Info_ID = row("info_id")
                    patientItem.PatientInfo.FirstName = row("firstname")
                    patientItem.PatientInfo.Middlename = row("middlename")
                    patientItem.PatientInfo.Lastname = row("lastname")
                    patientItem.PatientQueuing = New List(Of CustomerAssignCounter)
                    Dim cmd2 As New SqlCommand
                    cmd2.CommandText = "SELECT * FROM  [wmmcqms].[customer] as a
                                        JOIN [wmmcqms].[customerassigncounter] as b on a.customer_id = b.customer_id
                                        JOIN [wmmcqms].[counter] as c on c.counter_id = b.counter_id
                                        WHERE info_id = @ID"
                    cmd2.Parameters.AddWithValue("@ID", dt1)
                    Dim data2 As DataTable = fetchData(cmd).Tables(0)
                    If Not IsNothing(data2) Then
                        If data2.Rows.Count > 0 Then
                            For Each row2 As DataRow In data2.Rows
                                Dim patientQueue As New CustomerAssignCounter
                                patientQueue.CustomerAssignCounter_ID = row2("customerassigncounter_id")
                                patientQueue.Customer_ID = row2("customer_id")
                                patientQueue.Counter_ID = row2("customerassigncounter_id")
                                patientItem.PatientQueuing.Add(patientQueue)
                            Next
                        End If
                    End If
                    patientList.Add(patientItem)
                Next
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABHybridClinicCounterSummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 'PRIMARY CARE CENTER' as department,'MAB HYBRID CLINICS' as section,
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3) as queuedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null)) as holdCount,
    
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageTime,

                                (SELECT avg(DATEDIFF(MINUTE,a.datetimequeued,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageWaitingTime;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = 0
                summary.Counter.Department = data.Rows(0).Item("department")
                summary.Counter.Section = data.Rows(0).Item("section")
                summary.Counter.ServiceDescription = ""
                summary.Counter.CounterPrefix = ""
                summary.Counter.CounterCode = 0
                summary.Counter.Icon = 0
                summary.Counter.isQueueingCounter = 0
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCClinicCSummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 'PRIMARY CARE CENTER' as department,'PCC CLINICS' as section,
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2) as queuedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null)) as holdCount,
    
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageTime,

                                (SELECT avg(DATEDIFF(MINUTE,a.datetimequeued,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageWaitingTime;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = 0
                summary.Counter.Department = data.Rows(0).Item("department")
                summary.Counter.Section = data.Rows(0).Item("section")
                summary.Counter.ServiceDescription = ""
                summary.Counter.CounterPrefix = ""
                summary.Counter.CounterCode = 0
                summary.Counter.Icon = 0
                summary.Counter.isQueueingCounter = 0
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCHybridClinicCSummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 'PRIMARY CARE CENTER' as department,'PCC HYBRID CLINICS' as section,
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 5) as queuedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 5
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 5
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null)) as holdCount,
    
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 5
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageTime,

                                (SELECT avg(DATEDIFF(MINUTE,a.datetimequeued,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 5
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageWaitingTime;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = 0
                summary.Counter.Department = data.Rows(0).Item("department")
                summary.Counter.Section = data.Rows(0).Item("section")
                summary.Counter.ServiceDescription = ""
                summary.Counter.CounterPrefix = ""
                summary.Counter.CounterCode = 0
                summary.Counter.Icon = 0
                summary.Counter.isQueueingCounter = 0
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABClinicCSummaryByDate(dt1 As Date, dt2 As Date) As CounterSummary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 'MEDICAL ARTS BUILDING' as department,'MAB CLINICS' as section,
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1) as queuedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount,

                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null)) as holdCount,
    
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageTime,

                                (SELECT avg(DATEDIFF(MINUTE,a.datetimequeued,c.datetimeservedend)) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                JOIN [wmmcqms].servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1
                                AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer)) as averageWaitingTime;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summary As New CounterSummary
                summary.Counter.Counter_ID = 0
                summary.Counter.Department = data.Rows(0).Item("department")
                summary.Counter.Section = data.Rows(0).Item("section")
                summary.Counter.ServiceDescription = ""
                summary.Counter.CounterPrefix = ""
                summary.Counter.CounterCode = 0
                summary.Counter.Icon = 0
                summary.Counter.isQueueingCounter = 0
                summary.QueuedCount = data.Rows(0)("queuedCount")
                summary.ServedCount = data.Rows(0)("servedCount")
                summary.HoldCount = data.Rows(0)("holdCount")
                summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                summary.AverageTurnoverTime = If(IsDBNull(data.Rows(0)("averageTime")), -1, data.Rows(0)("averageTime"))
                summary.AverageWaitingTurnoverTime = If(IsDBNull(data.Rows(0)("averageWaitingTime")), -1, data.Rows(0)("averageWaitingTime"))
                Return summary
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCounterSummaryByDate(dt1 As Date, dt2 As Date) As List(Of CounterSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT 
                                a.section as 'countername',
                                a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS queuedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS servedCount,
                                (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS holdCount,
                                (select avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageTime,
                                (select avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) AS averageWaitingTime
                                from wmmcqms.counter a where a.counterType = 0 AND (a.counterStepByStep > 0) ORDER BY counterStepByStep,countername ASC;"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of CounterSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New CounterSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("countername")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Counter.CounterPrefix = row.Item("counterPrefix")
                    summary.Counter.CounterCode = row.Item("countercode")
                    summary.Counter.Icon = row.Item("icon")
                    summary.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                    summary.Counter.AutoTransfer_Screening = row.Item("autotransfer_screening")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCounterSummaryChart(dt As Date) As DataTable
        Try
            Dim cmd As New SqlCommand
            For x As Integer = 1 To dt.Day
                cmd.CommandText = cmd.CommandText &
                                   "SELECT 
                                    CASE
	                                    WHEN a.section = 'CLAIM RESULTS' THEN 'CLAIM RESULTS (TRIAGE 06)'
	                                    WHEN a.section = 'CONSULTATION' THEN 'CONSULTATION (TRIAGE 01 - TRIAGE 02)'
	                                    WHEN a.section = 'Diagnostics' THEN 'DIAGNOSTICS (TRIAGE 03 - TRIAGE 05)'
	                                    ELSE a.section
                                    END as 'countername',
                                    a.counter_id AS counter_id,a.autotransfer_screening,a.department AS department,a.section AS section,a.servicedescription AS servicedescription,a.counterPrefix AS counterPrefix,a.countercode AS countercode,a.icon AS icon,a.isQueuingCounter AS isQueuingCounter,
                                    (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ")) AS queuedCount,
                                    (select count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) = CONVERT(DATE,CONVERT(DATE,@dt" & x & "))) AS servedCount
                                    from wmmcqms.counter a where a.counterType = 0 AND (a.counterStepByStep > 0  ) ORDER BY a.counterStepByStep, countername ASC;"
                cmd.Parameters.AddWithValue("@dt" & x, (dt.Year & "-" & dt.Month & "-" & x).ToString)
            Next
            Dim data As DataSet = fetchData(cmd)
            If Not IsNothing(data) Then
                Dim summChart As New DataTable
                With summChart
                    .Columns.Add("Section")
                    Dim x As Integer = 1
                    For Each tb As DataTable In data.Tables
                        .Columns.Add(dt.ToString("MMM") & x)
                        For y As Integer = 0 To tb.Rows.Count - 1
                            If x = 1 Then
                                summChart.Rows.Add(tb.Rows(y)("countername"))
                            End If
                            summChart.Rows(y)(x) = tb.Rows(y)("queuedCount")
                        Next
                        x += 1
                    Next
                End With
                Return summChart
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCClinicCSummaryChart(dt As Date) As DataTable
        Try
            Dim cmd As New SqlCommand
            For x As Integer = 1 To dt.Day
                cmd.CommandText = cmd.CommandText & "SELECT 'PRIMARY CARE CENTER' as department,'PCC CLINICS' as section,
                                  (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                  JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                  WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 2) as queuedCount,
                                  (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                  JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                  WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 2
                                  AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount;"
                cmd.Parameters.AddWithValue("@dt" & x, (dt.Year & "-" & dt.Month & "-" & x).ToString)
            Next
            Dim data As DataSet = fetchData(cmd)
            If Not IsNothing(data) Then
                Dim summChart As New DataTable
                With summChart
                    .Columns.Add("Section")
                    Dim x As Integer = 1
                    For Each tb As DataTable In data.Tables
                        .Columns.Add(dt.ToString("MMM") & x)
                        For y As Integer = 0 To tb.Rows.Count - 1
                            If x = 1 Then
                                summChart.Rows.Add(tb.Rows(y)("section"))
                            End If
                            summChart.Rows(y)(x) = tb.Rows(y)("queuedCount")
                        Next
                        x += 1
                    Next
                End With
                Return summChart
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCHybridClinicCSummaryChart(dt As Date) As DataTable
        Try
            Dim cmd As New SqlCommand
            For x As Integer = 1 To dt.Day
                cmd.CommandText = cmd.CommandText & "SELECT 'PRIMARY CARE CENTER' as department,'PCC HYBRID CLINICS' as section,
                                  (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                  JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                  WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 5) as queuedCount,
                                  (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                  JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                  WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 5
                                  AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount;"
                cmd.Parameters.AddWithValue("@dt" & x, (dt.Year & "-" & dt.Month & "-" & x).ToString)
            Next
            Dim data As DataSet = fetchData(cmd)
            If Not IsNothing(data) Then
                Dim summChart As New DataTable
                With summChart
                    .Columns.Add("Section")
                    Dim x As Integer = 1
                    For Each tb As DataTable In data.Tables
                        .Columns.Add(dt.ToString("MMM") & x)
                        For y As Integer = 0 To tb.Rows.Count - 1
                            If x = 1 Then
                                summChart.Rows.Add(tb.Rows(y)("section"))
                            End If
                            summChart.Rows(y)(x) = tb.Rows(y)("queuedCount")
                        Next
                        x += 1
                    Next
                End With
                Return summChart
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABHybridClinicCounterSummaryChart(dt As Date) As DataTable
        Try
            Dim cmd As New SqlCommand
            For x As Integer = 1 To dt.Day
                cmd.CommandText = cmd.CommandText & "SELECT 'PRIMARY CARE CENTER' as department,'MAB HYBRID CLINICS' as section,
                                    (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                    JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                    WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 3) as queuedCount,
                                    (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                    JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                    WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 3
                                    AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount;"
                cmd.Parameters.AddWithValue("@dt" & x, (dt.Year & "-" & dt.Month & "-" & x).ToString)
            Next
            Dim data As DataSet = fetchData(cmd)
            If Not IsNothing(data) Then
                Dim summChart As New DataTable
                With summChart
                    .Columns.Add("Section")
                    Dim x As Integer = 1
                    For Each tb As DataTable In data.Tables
                        .Columns.Add(dt.ToString("MMM") & x)
                        For y As Integer = 0 To tb.Rows.Count - 1
                            If x = 1 Then
                                summChart.Rows.Add(tb.Rows(y)("section"))
                            End If
                            summChart.Rows(y)(x) = tb.Rows(y)("queuedCount")
                        Next
                        x += 1
                    Next
                End With
                Return summChart
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABClinicCSummaryByChart(dt As Date) As DataTable
        Try
            Dim cmd As New SqlCommand
            For x As Integer = 1 To dt.Day
                cmd.CommandText = cmd.CommandText & "SELECT 'MEDICAL ARTS BUILDING' as department,'MAB CLINICS' as section,
                                    (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                    JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                    WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 1) as queuedCount,
                                    (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                    JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                    WHERE CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt" & x & ") AND b.counterType = 1
                                    AND a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null)) as servedCount;"
                cmd.Parameters.AddWithValue("@dt" & x, (dt.Year & "-" & dt.Month & "-" & x).ToString)
            Next
            Dim data As DataSet = fetchData(cmd)
            If Not IsNothing(data) Then
                Dim summChart As New DataTable
                With summChart
                    .Columns.Add("Section")
                    Dim x As Integer = 1
                    For Each tb As DataTable In data.Tables
                        .Columns.Add(dt.ToString("MMM") & x)
                        For y As Integer = 0 To tb.Rows.Count - 1
                            If x = 1 Then
                                summChart.Rows.Add(tb.Rows(y)("section"))
                            End If
                            summChart.Rows(y)(x) = tb.Rows(y)("queuedCount")
                        Next
                        x += 1
                    Next
                End With
                Return summChart
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDoctorSummaryByDate(dt1 As Date, dt2 As Date) As List(Of DoctorSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.counter_id, b.fullname, a.department AS department,a.section AS section,a.servicedescription AS servicedescription,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS queuedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS servedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS holdCount,
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageTime,
                                (SELECT avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageWaitingTime
                                FROM wmmcqms.serverassigncounter as c
                                JOIN wmmcqms.counter a ON c.counter_id = a.counter_id
                                RIGHT JOIN wmmcqms.server b on c.server_id = b.server_id
                               WHERE a.counterType = 1 or a.counterType = 2 or a.counterType = 3 ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of DoctorSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New DoctorSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("section")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Doctor.FullName = row.Item("fullname")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCClinicSummaryByDate(dt1 As Date, dt2 As Date) As List(Of DoctorSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.counter_id, b.fullname, a.department AS department,a.section AS section,a.servicedescription AS servicedescription,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS queuedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS servedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS holdCount,
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageTime,
                                (SELECT avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedstart)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageWaitingTime
                                FROM wmmcqms.serverassigncounter as c
                                JOIN wmmcqms.counter a ON c.counter_id = a.counter_id
                                RIGHT JOIN wmmcqms.server b on c.server_id = b.server_id
                               WHERE a.counterType = 2 ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of DoctorSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New DoctorSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("section")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Doctor.FullName = row.Item("fullname")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABHybridClinicSummaryByDate(dt1 As Date, dt2 As Date) As List(Of DoctorSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.counter_id, b.fullname, a.department AS department,a.section AS section,a.servicedescription AS servicedescription,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS queuedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS servedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS holdCount,
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageTime,
                                (SELECT avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageWaitingTime
                                FROM wmmcqms.serverassigncounter as c
                                JOIN wmmcqms.counter a ON c.counter_id = a.counter_id
                                RIGHT JOIN wmmcqms.server b on c.server_id = b.server_id
                               WHERE a.counterType = 3 ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of DoctorSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New DoctorSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("section")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Doctor.FullName = row.Item("fullname")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetMABClinicSummaryByDate(dt1 As Date, dt2 As Date) As List(Of DoctorSummary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.counter_id, b.fullname, a.department AS department,a.section AS section,a.servicedescription AS servicedescription,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.counter_id = a.counter_id and CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS queuedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS servedCount,
                                (SELECT count(wmmcqms.customerassigncounter.counter_id) from wmmcqms.customerassigncounter where wmmcqms.customerassigncounter.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is null) and wmmcqms.customerassigncounter.counter_id = a.counter_id and  CONVERT(DATE,datetimequeued) BETWEEN @dt1 and @dt2) AS holdCount,
                                (SELECT avg(DATEDIFF(MINUTE,c.datetimeservedstart,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageTime,
                                (SELECT avg(DATEDIFF(MINUTE,b.datetimequeued,c.datetimeservedend)) from (wmmcqms.customerassigncounter b join wmmcqms.servedcustomer c on(b.customerassigncounter_id = c.customerassigncounter_id)) where c.customerassigncounter_id in (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer) and b.counter_id = a.counter_id and  CONVERT(DATE,b.datetimequeued) BETWEEN @dt1 and @dt2) AS averageWaitingTime
                                FROM wmmcqms.serverassigncounter as c
                                JOIN wmmcqms.counter a ON c.counter_id = a.counter_id
                                RIGHT JOIN wmmcqms.server b on c.server_id = b.server_id
                               WHERE a.counterType = 1 ORDER BY b.fullname ASC"
            cmd.Parameters.AddWithValue("@dt1", dt1)
            cmd.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New List(Of DoctorSummary)
                For Each row As DataRow In data.Rows
                    Dim summary As New DoctorSummary
                    summary.Counter.Counter_ID = row.Item("counter_id")
                    summary.Counter.Department = row.Item("department")
                    summary.Counter.Section = row.Item("section")
                    summary.Counter.ServiceDescription = row.Item("servicedescription")
                    summary.Doctor.FullName = row.Item("fullname")
                    summary.QueuedCount = row("queuedCount")
                    summary.ServedCount = row("servedCount")
                    summary.HoldCount = row("holdCount")
                    summary.UnservedCount = summary.QueuedCount - (summary.ServedCount + summary.HoldCount)
                    summary.AverageTurnoverTime = If(IsDBNull(row("averageTime")), -1, row("averageTime"))
                    summary.AverageWaitingTurnoverTime = If(IsDBNull(row("averageWaitingTime")), -1, row("averageWaitingTime"))
                    summaryData.Add(summary)
                Next
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCTATReconData(dt1 As Date, dt2 As Date) As PatientTATReconnReport
        Try
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                JOIN wmmcqms.servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE c.datetimeservedend is not null AND b.counter_id = 5 AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'triage_consultation',
                                (SELECT COUNT(customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                WHERE (b.counterType = 2 or b.counterType = 3) AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'clinics',
                                (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                JOIN wmmcqms.servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE c.datetimeservedend is not null AND b.counter_id = 27 AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'triage_diagnostics',
                                (SELECT COUNT(customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                WHERE (b.counter_id = 4 or b.counter_id = 23 or b.counter_id = 20 or b.counter_id = 9 or b.counter_id = 185 or b.counter_id = 19 or b.counter_id = 21) AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'diagnostics',
                                (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                JOIN wmmcqms.servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE (b.counter_id = 5 or b.counter_id = 27) AND c.datetimeservedend is not null  AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'triage_forpayment',
                                (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                JOIN wmmcqms.servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE (b.counterType = 2 or b.counterType = 3) AND c.datetimeservedend is not null AND c.served_id IN (SELECT served_id FROM dbo.diagnosticrequests JOIN dbo.customervitals ON dbo.diagnosticrequests.vital_id = dbo.customervitals.consultation_id WHERE FK_psPatRegisters > 0)  AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'clinic_forpayment',
                                (SELECT COUNT(customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                WHERE (b.counter_id = 7 or b.counter_id = 3 or b.counter_id = 11) AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'payment',
                                (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                WHERE a.customerassigncounter_id IN (select wmmcqms.servedcustomer.customerassigncounter_id from wmmcqms.servedcustomer where datetimeservedend is not null) AND b.counter_id = 93 AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'screened',
                                (SELECT COUNT(a.customerassigncounter_id) FROM wmmcqms.customerassigncounter as a
                                JOIN wmmcqms.counter as b ON b.counter_id = a.counter_id
                                JOIN wmmcqms.servedcustomer as c on c.customerassigncounter_id = a.customerassigncounter_id
                                WHERE c.datetimeservedend is not null AND b.counter_id = 31 AND CONVERT(DATE,datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2)) as 'triage_claimresult',
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 1) as 'mab_clinics',
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 2) as 'pcc_clinic',
                                (SELECT COUNT(customerassigncounter_id) FROM [wmmcqms].customerassigncounter as a 
                                JOIN [wmmcqms].counter as b on b.counter_id = a.counter_id
                                WHERE CONVERT(DATE,a.datetimequeued) BETWEEN CONVERT(DATE,@dt1) and CONVERT(DATE,@dt2) AND b.counterType = 3) as 'mabhybrid_clinic',
                                (SELECT COUNT(customer_id) FROM [wmmcqms].[customer] where CONVERT(DATE,dateofvisit) BETWEEN CONVERT(DATE,@dt1) AND CONVERT(DATE,@dt2)) as 'total_registers';"
            cmd1.Parameters.AddWithValue("@dt1", dt1)
            cmd1.Parameters.AddWithValue("@dt2", dt2)
            Dim data As DataTable = fetchData(cmd1).Tables(0)
            If data.Rows.Count > 0 Then
                Dim tatReport As New PatientTATReconnReport
                tatReport.TriageConsultation = data.Rows(0)("triage_consultation")
                tatReport.PCCMABHybridClinics = data.Rows(0)("clinics")
                tatReport.TriageDiagnostics = data.Rows(0)("triage_diagnostics")
                tatReport.DiagosticDepartment = data.Rows(0)("diagnostics")
                tatReport.TriagePayment = data.Rows(0)("triage_forpayment")
                tatReport.ClinicPayment = data.Rows(0)("clinic_forpayment")
                tatReport.PaymentSection = data.Rows(0)("payment")
                tatReport.ScreenedPatient = data.Rows(0)("screened")
                tatReport.TriageClaimResult = data.Rows(0)("triage_claimresult")
                tatReport.MABClinics = data.Rows(0)("mab_clinics")
                tatReport.MABHybridClinics = data.Rows(0)("mabhybrid_clinic")
                tatReport.PCCClinics = data.Rows(0)("pcc_clinic")
                tatReport.TotalRegistered = data.Rows(0)("total_registers")
                Return tatReport
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainDateSummary(dt As Date) As Summary
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = "SELECT (SELECT COUNT(customerassigncounter_id) FROM  [wmmcqms].[customerassigncounter] WHERE customerassigncounter_id IN (SELECT customerassigncounter_id FROM [wmmcqms].[servedcustomer]) AND  CONVERT(DATE,datetimequeued) = CONVERT(DATE,@dt)) as servedToday , (SELECT COUNT(queuenumber) FROM  [wmmcqms].[customerassigncounter]  WHERE CONVERT(DATE,(datetimequeued)) = CONVERT(DATE,@dt)) as custToday, (SELECT COUNT(servertransaction_id) FROM [wmmcqms].[servertransaction] WHERE  CONVERT(DATE,datetimelogin) =  CONVERT(DATE,@dt)) AS loggedUser"
            cmd.Parameters.AddWithValue("@dt", dt)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New Summary
                summaryData.ServedCustomerToday = If(IsDBNull(data.Rows(0).Item("servedToday")), 0, data.Rows(0).Item("servedToday"))
                summaryData.TotalCustomerToday = If(IsDBNull(data.Rows(0).Item("custToday")), 0, data.Rows(0).Item("custToday"))
                summaryData.LoggedUserToday = If(IsDBNull(data.Rows(0).Item("loggedUser")), 0, data.Rows(0).Item("loggedUser"))
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainMonthSummary(dt As Date) As List(Of Summary)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DAY(datetimequeued) as 'day', custCount,servedCount,loggedUser FROM `monthlysummary` where MONTH(datetimequeued) = MONTH(@dt) AND YEAR(datetimequeued) = YEAR(@dt) order by datetimequeued asc"
            cmd.Parameters.AddWithValue("@dt", dt)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaries As New List(Of Summary)
                For Each row As DataRow In data.Rows
                    Dim summary As New Summary
                    summary.DateDay = row("day")
                    summary.ServedCustomerToday = row("servedCount")
                    summary.TotalCustomerToday = row("custCount")
                    summaries.Add(summary)
                Next
                Return summaries
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function GetSummary() As Summary
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM `monthlysummary` where Date(datetimequeued) = Date(CURRENT_DATE)"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim summaryData As New Summary
                summaryData.ServedCustomerToday = If(IsDBNull(data.Rows(0).Item("servedCount")), 0, data.Rows(0).Item("servedCount"))
                summaryData.TotalCustomerToday = If(IsDBNull(data.Rows(0).Item("custCount")), 0, data.Rows(0).Item("custCount"))
                summaryData.LoggedUserToday = If(IsDBNull(data.Rows(0).Item("loggedUser")), 0, data.Rows(0).Item("loggedUser"))
                Return summaryData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllDepartmentTurnAroundTimeStatus() As DataTable
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.*,
                                (SELECT COUNT(b.counter_id) FROM [wmmcqms].[customerassigncounter] as b where a.counter_id = b.counter_id and CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) and b.priority <= 0 AND (b.customerassigncounter_id NOT IN (SELECT c.customerassigncounter_id FROM wmmcqms.servedcustomer as c))) as 'PendingNormalQueue',
                                (SELECT COUNT(b.counter_id) FROM [wmmcqms].[customerassigncounter] as b where a.counter_id = b.counter_id and CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) and b.priority = 1 AND (b.customerassigncounter_id NOT IN (SELECT c.customerassigncounter_id FROM wmmcqms.servedcustomer as c))) as 'PendingPriorityQueue',
                                (SELECT COUNT(b.counter_id) FROM [wmmcqms].[customerassigncounter] as b where a.counter_id = b.counter_id and CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) AND (b.customerassigncounter_id NOT IN (SELECT c.customerassigncounter_id FROM wmmcqms.servedcustomer as c))) as 'TotalQueuePerDept',
                                (SELECT MIN(b.datetimequeued) FROM [wmmcqms].customerassigncounter AS b WHERE (convert(DATE,datetimequeued) = convert(DATE,GETDATE()) AND b.counter_id = a.counter_id) AND b.priority < =0 AND (b.customerassigncounter_id NOT IN (SELECT c.customerassigncounter_id FROM wmmcqms.servedcustomer as c))) as 'NotServeNormalQueueDate',
                                (SELECT MIN(b.datetimequeued) FROM [wmmcqms].customerassigncounter AS b WHERE (convert(DATE,datetimequeued) = convert(DATE,GETDATE()) AND b.counter_id = a.counter_id) AND b.priority >= 1 AND (b.customerassigncounter_id NOT IN (SELECT c.customerassigncounter_id FROM wmmcqms.servedcustomer as c))) as 'NotServePriorityQueueDate'
                                FROM [wmmcqms].[counter] as a WHERE a.counter_id IN (SELECT counter_id FROM [wmmcqms].serverassigncounter as d WHERE d.serverassigncounter_ID IN (SELECT serverassigncounter_ID FROM [wmmcqms].[servertransaction] WHERE convert(DATE,datetimelogin) = convert(DATE,GETDATE()) and  datetimelogout IS NULL))
                                AND isQueuingCounter > 0 AND ((counterType = 0) or (counterType = 1 AND isQueuingCounter != 1))
                                ORDER BY a.servicedescription asc"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim dt As New DataTable
                With dt.Columns
                    .Add("Department")
                    .Add("Section")
                    .Add("ServiceDescription")
                    .Add("AllowedTurnAroundTime")
                    .Add("PendingNormalQueue")
                    .Add("PendingPriorityQueue")
                    .Add("PendingTotalQueue")
                    .Add("NotServeNormalQueueDate")
                    .Add("NotServePriorityQueueDate")
                End With
                For Each row As DataRow In data.Rows
                    dt.Rows.Add(row.Item("department"), row.Item("section"), row.Item("servicedescription"), row.Item("allowableTurnaroundTime"), row.Item("PendingNormalQueue"), row.Item("PendingPriorityQueue"), row.Item("TotalQueuePerDept"), row.Item("NotServeNormalQueueDate"), row.Item("NotServePriorityQueueDate"))
                Next
                Return dt
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainCustomerAssignCounter(id As Long) As CustomerAssignCounter
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[customerassigncounter] as a, [wmmcqms].[counter] as b, [wmmcqms].[customer] as c where a.counter_id = b.counter_id and a.customer_id = c.customer_id and customerassigncounter_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim customerAssignCounter As New CustomerAssignCounter
                customerAssignCounter.CustomerAssignCounter_ID = data.Rows(0).Item("customerassigncounter_id")
                customerAssignCounter.Counter_ID = data.Rows(0).Item("counter_id")
                customerAssignCounter.Customer_ID = data.Rows(0).Item("customer_id")
                customerAssignCounter.DateTimeQueued = data.Rows(0).Item("datetimequeued")
                customerAssignCounter.Priority = data.Rows(0).Item("priority")
                customerAssignCounter.QueueNumber = data.Rows(0).Item("queuenumber")
                customerAssignCounter.Counter.Counter_ID = data.Rows(0).Item("counter_id")
                customerAssignCounter.Counter.Department = data.Rows(0).Item("department")
                customerAssignCounter.Counter.Section = data.Rows(0).Item("section")
                customerAssignCounter.Counter.ServiceDescription = data.Rows(0).Item("servicedescription")
                customerAssignCounter.Counter.CounterPrefix = data.Rows(0).Item("counterPrefix")
                customerAssignCounter.Counter.CounterCode = data.Rows(0).Item("countercode")
                customerAssignCounter.Counter.Icon = data.Rows(0).Item("icon")
                customerAssignCounter.Counter.isQueueingCounter = data.Rows(0).Item("isQueuingCounter")
                customerAssignCounter.Customer.Customer_ID = data.Rows(0).Item("customer_id")
                customerAssignCounter.Customer.FullName = data.Rows(0).Item("fullname")
                customerAssignCounter.Customer.Address = data.Rows(0).Item("address")
                customerAssignCounter.Customer.PhoneNumber = data.Rows(0).Item("phonenumber")
                customerAssignCounter.Customer.DateOfVisit = data.Rows(0).Item("dateofvisit")
                customerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(customerAssignCounter)
                Return customerAssignCounter
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetNumbersWithResults(counter As Counter) As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *  FROM [wmmcqms].[customerassigncounter] AS a WHERE (CONVERT(DATE,datetimequeued) = CONVERT(DATE,GETDATE()) AND result =1 AND a.counter_id = 8) AND (a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM [wmmcqms].[servedcustomer] as b WHERE CONVERT(DATE,b.datetimeservedstart) = CONVERT(DATE,GETDATE()) AND b.datetimeservedend  IS NOT NULL))"
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim customersInQueue As New List(Of CustomerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim customerInQueue As New CustomerAssignCounter
                customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                customerInQueue.Counter_ID = row.Item("counter_id")
                customerInQueue.Customer_ID = row.Item("customer_id")
                customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                customerInQueue.Priority = row.Item("priority")
                customerInQueue.Result = row.Item("result")
                customerInQueue.QueueNumber = row.Item("queuenumber")
                customerInQueue.Counter = counter
                customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                customersInQueue.Add(customerInQueue)
            Next
            Return customersInQueue
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function TransferCustomerGenerateQueueNumber(customerAssignCounter As CustomerAssignCounter) As String
        Try
            Dim cmd0 As New SqlCommand
            If customerAssignCounter.Customer.CustomerInfo.Info_ID > 0 Then
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [wmmcqms].[customer] (fullname, address, phonenumber,FK_emdPatients,info_id) VALUES (@fname, @addr, @phone, @fk_emd, @infid); SELECT @@IDENTITY;"
                cmd.Parameters.AddWithValue("@fname", If(IsNothing(customerAssignCounter.Customer.FullName), DBNull.Value, customerAssignCounter.Customer.FullName))
                cmd.Parameters.AddWithValue("@addr", If(IsNothing(customerAssignCounter.Customer.Address), DBNull.Value, customerAssignCounter.Customer.Address))
                cmd.Parameters.AddWithValue("@phone", If(IsNothing(customerAssignCounter.Customer.PhoneNumber), DBNull.Value, customerAssignCounter.Customer.PhoneNumber))
                cmd.Parameters.AddWithValue("@fk_emd", customerAssignCounter.Customer.FK_emdPatients)
                cmd.Parameters.AddWithValue("@infid", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                Dim customerID As Long = excecuteCommandReturnID(cmd)
                If customerID > 0 Then
                    Dim cmd3 As New SqlCommand
                    cmd3.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                    cmd3.Parameters.AddWithValue("@ID", customerAssignCounter.Counter.Counter_ID)
                    Dim nextNum As Long = fetchData(cmd3).Tables(0).Rows(0).Item("nextNum")
                    Dim cmd2 As New SqlCommand
                    cmd2.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber, paymentmethod, notes, notedepartment, notesection) VALUES (@countrID,@custID,@prio,@nextNum,@payment,@note,@ntdept,@ntsect);"
                    cmd2.Parameters.AddWithValue("@countrID", customerAssignCounter.Counter.Counter_ID)
                    cmd2.Parameters.AddWithValue("@custID", customerID)
                    cmd2.Parameters.AddWithValue("@prio", customerAssignCounter.Priority)
                    cmd2.Parameters.AddWithValue("@nextNum", nextNum)
                    cmd2.Parameters.AddWithValue("@payment", customerAssignCounter.PaymentMethod)
                    cmd2.Parameters.AddWithValue("@note", If(Not IsNothing(customerAssignCounter.Notes), customerAssignCounter.Notes, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntdept", If(Not IsNothing(customerAssignCounter.NoteDepartment), customerAssignCounter.NoteDepartment, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntsect", If(Not IsNothing(customerAssignCounter.NoteSection), customerAssignCounter.NoteSection, DBNull.Value))
                    If excecuteCommand(cmd2) Then
                        Dim numlen As Integer = nextNum.ToString.Length
                        If numlen = 1 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-00" + nextNum.ToString
                        ElseIf numlen = 2 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-0" + nextNum.ToString
                        Else
                            Return customerAssignCounter.Counter.CounterPrefix + "-" + nextNum.ToString
                        End If
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function TransferPatient(forTransferPatient As CustomerAssignCounter) As String
        Try
            Dim cmdNextNumber As New SqlCommand
            cmdNextNumber.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
            cmdNextNumber.Parameters.AddWithValue("@ID", forTransferPatient.Counter.Counter_ID)
            Dim nextNum As Long = fetchData(cmdNextNumber).Tables(0).Rows(0).Item("nextNum")
            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            cmd2.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber, paymentmethod, notes, notedepartment, notesection) VALUES (@countrID,@custID,@prio,@nextNum,@payment,@note,@ntdept,@ntsect);"
            cmd2.Parameters.AddWithValue("@countrID", forTransferPatient.Counter.Counter_ID)
            cmd2.Parameters.AddWithValue("@custID", forTransferPatient.Customer.Customer_ID)
            cmd2.Parameters.AddWithValue("@prio", 0)
            cmd2.Parameters.AddWithValue("@nextNum", nextNum)
            cmd2.Parameters.AddWithValue("@payment", forTransferPatient.PaymentMethod)
            cmd2.Parameters.AddWithValue("@note", If(Not IsNothing(forTransferPatient.Notes), forTransferPatient.Notes, DBNull.Value))
            cmd2.Parameters.AddWithValue("@ntdept", If(Not IsNothing(forTransferPatient.NoteDepartment), forTransferPatient.NoteDepartment, DBNull.Value))
            cmd2.Parameters.AddWithValue("@ntsect", If(Not IsNothing(forTransferPatient.NoteSection), forTransferPatient.NoteSection, DBNull.Value))
            If excecuteCommand(cmd2) Then
                Dim numlen As Integer = nextNum.ToString.Length
                If numlen = 1 Then
                    Return forTransferPatient.Counter.CounterPrefix + "-00" + nextNum.ToString
                ElseIf numlen = 2 Then
                    Return forTransferPatient.Counter.CounterPrefix + "-0" + nextNum.ToString
                Else
                    Return forTransferPatient.Counter.CounterPrefix + "-" + nextNum.ToString
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function SavePatientNoQueueNumber(customerInfo As CustomerInfo) As Boolean
        Try
            Dim cmd0 As New SqlCommand
            Dim infoID As Long = 0
            If customerInfo.FK_emdPatients > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE FK_emdPatients =@fkemd;"
                cmdlookup.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            ElseIf customerInfo.Info_ID > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE info_id = @ID"
                cmdlookup.Parameters.AddWithValue("@ID", customerInfo.Info_ID)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            End If
            cmd0.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname],[middlename],[lastname],[sex],[birthdate],[civilstatus],[street],[barangay],[city],[phonenumber],[nationality],[email],[FK_emdPatients]) VALUES (@fname,@mname,@lname,@sex,@bday,@cstat,@street,@brgy,@ct,@cp,@nat,@email,@fkemd); SELECT @@IDENTITY;"
            cmd0.Parameters.AddWithValue("@fname", If(Not IsNothing(customerInfo.FirstName), customerInfo.FirstName, ""))
            cmd0.Parameters.AddWithValue("@mname", If(Not IsNothing(customerInfo.Middlename), customerInfo.Middlename, ""))
            cmd0.Parameters.AddWithValue("@lname", If(Not IsNothing(customerInfo.Lastname), customerInfo.Lastname, ""))
            cmd0.Parameters.AddWithValue("@sex", If(Not IsNothing(customerInfo.Sex), customerInfo.Sex, ""))
            cmd0.Parameters.AddWithValue("@bday", If(Not IsNothing(customerInfo.BirthDate), customerInfo.BirthDate, ""))
            cmd0.Parameters.AddWithValue("@cstat", If(Not IsNothing(customerInfo.CivilStatus), customerInfo.CivilStatus, ""))
            cmd0.Parameters.AddWithValue("@street", If(Not IsNothing(customerInfo.StreetDrive), customerInfo.StreetDrive, ""))
            cmd0.Parameters.AddWithValue("@brgy", If(Not IsNothing(customerInfo.Barangay), customerInfo.Barangay, ""))
            cmd0.Parameters.AddWithValue("@ct", If(Not IsNothing(customerInfo.CityMunicipality), customerInfo.CityMunicipality, ""))
            cmd0.Parameters.AddWithValue("@cp", If(Not IsNothing(customerInfo.PhoneNumber), customerInfo.PhoneNumber, ""))
            cmd0.Parameters.AddWithValue("@nat", If(Not IsNothing(customerInfo.Nationality), customerInfo.Nationality, ""))
            cmd0.Parameters.AddWithValue("@email", If(Not IsNothing(customerInfo.Email), customerInfo.Email, ""))
            cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
            infoID = excecuteCommandReturnID(cmd0)
skip:
            If infoID > 0 Then
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[healthcheckdata] ([feverchills] ,[cough] ,[sorethroat] ,[diarrhea] ,[shortnessofbreathing] ,[ageusia] ,[anosmia] ,[colds] ,[closecontactconfirmed] ,[closecontactpersonexhibiting] ,[FK_emdPatients] ,[info_id]) VALUES (@fever ,@cough ,@sorethroat ,@diarrhea ,@shortness ,@ageusia ,@anosmia ,@colds ,@closecontactconfirmed ,@closecontactpersonexhibiting ,@fk_id ,@infoID);"
                cmd.Parameters.AddWithValue("@fever", customerInfo.HealthCheck.Fever)
                cmd.Parameters.AddWithValue("@cough", customerInfo.HealthCheck.Cough)
                cmd.Parameters.AddWithValue("@sorethroat", customerInfo.HealthCheck.Sorethroat)
                cmd.Parameters.AddWithValue("@diarrhea", customerInfo.HealthCheck.Diarrhea)
                cmd.Parameters.AddWithValue("@shortness", customerInfo.HealthCheck.ShortnessOfBreathing)
                cmd.Parameters.AddWithValue("@ageusia", customerInfo.HealthCheck.Ageusia)
                cmd.Parameters.AddWithValue("@anosmia", customerInfo.HealthCheck.Anosmia)
                cmd.Parameters.AddWithValue("@colds", customerInfo.HealthCheck.Colds)
                cmd.Parameters.AddWithValue("@closecontactconfirmed", customerInfo.HealthCheck.CloseContactConfirmed)
                cmd.Parameters.AddWithValue("@closecontactpersonexhibiting", customerInfo.HealthCheck.CloseContactExhiting)
                cmd.Parameters.AddWithValue("@fk_id", customerInfo.FK_emdPatients)
                cmd.Parameters.AddWithValue("@infoID", infoID)
                If excecuteCommand(cmd) Then
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function SavePatientNoQueueNumber_QueueToScreening(customerInfo As CustomerInfo) As Boolean
        Try
            Dim cmd0 As New SqlCommand
            Dim infoID As Long = 0
            If customerInfo.FK_emdPatients > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE FK_emdPatients =@fkemd;"
                cmdlookup.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            ElseIf customerInfo.Info_ID > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE info_id = @ID"
                cmdlookup.Parameters.AddWithValue("@ID", customerInfo.Info_ID)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            End If
            cmd0.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname],[middlename],[lastname],[sex],[birthdate],[civilstatus],[street],[barangay],[city],[phonenumber],[nationality],[email],[FK_emdPatients]) VALUES (@fname,@mname,@lname,@sex,@bday,@cstat,@street,@brgy,@ct,@cp,@nat,@email,@fkemd); SELECT @@IDENTITY;"
            cmd0.Parameters.AddWithValue("@fname", If(Not IsNothing(customerInfo.FirstName), customerInfo.FirstName, ""))
            cmd0.Parameters.AddWithValue("@mname", If(Not IsNothing(customerInfo.Middlename), customerInfo.Middlename, ""))
            cmd0.Parameters.AddWithValue("@lname", If(Not IsNothing(customerInfo.Lastname), customerInfo.Lastname, ""))
            cmd0.Parameters.AddWithValue("@sex", If(Not IsNothing(customerInfo.Sex), customerInfo.Sex, ""))
            cmd0.Parameters.AddWithValue("@bday", If(Not IsNothing(customerInfo.BirthDate), customerInfo.BirthDate, ""))
            cmd0.Parameters.AddWithValue("@cstat", If(Not IsNothing(customerInfo.CivilStatus), customerInfo.CivilStatus, ""))
            cmd0.Parameters.AddWithValue("@street", If(Not IsNothing(customerInfo.StreetDrive), customerInfo.StreetDrive, ""))
            cmd0.Parameters.AddWithValue("@brgy", If(Not IsNothing(customerInfo.Barangay), customerInfo.Barangay, ""))
            cmd0.Parameters.AddWithValue("@ct", If(Not IsNothing(customerInfo.CityMunicipality), customerInfo.CityMunicipality, ""))
            cmd0.Parameters.AddWithValue("@cp", If(Not IsNothing(customerInfo.PhoneNumber), customerInfo.PhoneNumber, ""))
            cmd0.Parameters.AddWithValue("@nat", If(Not IsNothing(customerInfo.Nationality), customerInfo.Nationality, ""))
            cmd0.Parameters.AddWithValue("@email", If(Not IsNothing(customerInfo.Email), customerInfo.Email, ""))
            cmd0.Parameters.AddWithValue("@fkemd", customerInfo.FK_emdPatients)
            infoID = excecuteCommandReturnID(cmd0)
skip:
            If infoID > 0 Then
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[healthcheckdata] ([feverchills] ,[cough] ,[sorethroat] ,[diarrhea] ,[shortnessofbreathing] ,[ageusia] ,[anosmia] ,[colds] ,[closecontactconfirmed] ,[closecontactpersonexhibiting], [VisitPurpose] ,[FK_emdPatients] ,[info_id]) VALUES (@fever ,@cough ,@sorethroat ,@diarrhea ,@shortness ,@ageusia ,@anosmia ,@colds ,@closecontactconfirmed ,@closecontactpersonexhibiting ,@visitpurpose ,@fk_id ,@infoID);"
                cmd.Parameters.AddWithValue("@fever", customerInfo.HealthCheck.Fever)
                cmd.Parameters.AddWithValue("@cough", customerInfo.HealthCheck.Cough)
                cmd.Parameters.AddWithValue("@sorethroat", customerInfo.HealthCheck.Sorethroat)
                cmd.Parameters.AddWithValue("@diarrhea", customerInfo.HealthCheck.Diarrhea)
                cmd.Parameters.AddWithValue("@shortness", customerInfo.HealthCheck.ShortnessOfBreathing)
                cmd.Parameters.AddWithValue("@ageusia", customerInfo.HealthCheck.Ageusia)
                cmd.Parameters.AddWithValue("@anosmia", customerInfo.HealthCheck.Anosmia)
                cmd.Parameters.AddWithValue("@colds", customerInfo.HealthCheck.Colds)
                cmd.Parameters.AddWithValue("@closecontactconfirmed", customerInfo.HealthCheck.CloseContactConfirmed)
                cmd.Parameters.AddWithValue("@closecontactpersonexhibiting", customerInfo.HealthCheck.CloseContactExhiting)
                cmd.Parameters.AddWithValue("@visitpurpose", customerInfo.HealthCheck.PurposeOfVisit)
                cmd.Parameters.AddWithValue("@fk_id", customerInfo.FK_emdPatients)
                cmd.Parameters.AddWithValue("@infoID", infoID)
                If excecuteCommand(cmd) Then
                    Dim cmdScreening As New SqlCommand
                    cmdScreening.CommandText = "SELECT * FROM  [wmmcqms].[counter] WHERE autotransfer_screening = 1"
                    Dim dtScreeningCounters As DataTable = fetchData(cmdScreening).Tables(0)
                    If Not IsNothing(dtScreeningCounters) Then
                        If dtScreeningCounters.Rows.Count > 0 Then
                            Dim cmd1 As New SqlCommand
                            cmd1.CommandText = "INSERT INTO [wmmcqms].[customer] ( fullname, address, phonenumber,FK_emdPatients,info_id) VALUES (@fname, @addr, @phone, @fk_emd, @infid); SELECT @@IDENTITY;"
                            cmd1.Parameters.AddWithValue("@fname", customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename)
                            cmd1.Parameters.AddWithValue("@addr", customerInfo.StreetDrive & " " & customerInfo.Barangay & " " & customerInfo.CityMunicipality)
                            cmd1.Parameters.AddWithValue("@phone", If(IsNothing(customerInfo.PhoneNumber), DBNull.Value, customerInfo.PhoneNumber))
                            cmd1.Parameters.AddWithValue("@fk_emd", customerInfo.FK_emdPatients)
                            cmd1.Parameters.AddWithValue("@infid", infoID)
                            Dim customerID As Long = excecuteCommandReturnID(cmd1)
                            If customerID > 0 Then
                                Dim cmd5 As New SqlCommand
                                cmd5.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                                cmd5.Parameters.AddWithValue("@ID", dtScreeningCounters.Rows(0)("counter_id"))
                                Dim nextNum2 As Long = fetchData(cmd5).Tables(0).Rows(0).Item("nextNum")
                                Dim cmd6 As New SqlCommand
                                cmd6.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber) VALUES (@countrID,@custID,@prio,@nextNum);"
                                cmd6.Parameters.AddWithValue("@countrID", dtScreeningCounters.Rows(0)("counter_id"))
                                cmd6.Parameters.AddWithValue("@custID", customerID)
                                cmd6.Parameters.AddWithValue("@prio", 0)
                                cmd6.Parameters.AddWithValue("@nextNum", nextNum2)
                                excecuteCommand(cmd6)
                            End If
                        End If
                    End If
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function GenerateQueueNumber_TemporaryCustomer(customerAssignCounter As CustomerAssignCounter) As String
        Try
            Dim cmd0 As New SqlCommand
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [wmmcqms].[customer] (fullname, address, phonenumber,FK_emdPatients,info_id) VALUES (@fname, @addr, @phone, @fk_emd, @infid); SELECT @@IDENTITY;"
            cmd.Parameters.AddWithValue("@fname", If(IsNothing(customerAssignCounter.Customer.FullName), DBNull.Value, customerAssignCounter.Customer.FullName))
            cmd.Parameters.AddWithValue("@addr", If(IsNothing(customerAssignCounter.Customer.Address), DBNull.Value, customerAssignCounter.Customer.Address))
            cmd.Parameters.AddWithValue("@phone", If(IsNothing(customerAssignCounter.Customer.PhoneNumber), DBNull.Value, customerAssignCounter.Customer.PhoneNumber))
            cmd.Parameters.AddWithValue("@fk_emd", DBNull.Value)
            cmd.Parameters.AddWithValue("@infid", DBNull.Value)
            Dim customerID As Long = excecuteCommandReturnID(cmd)
            If customerID > 0 Then
                Dim cmd3 As New SqlCommand
                cmd3.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                cmd3.Parameters.AddWithValue("@ID", customerAssignCounter.Counter.Counter_ID)
                Dim nextNum As Long = fetchData(cmd3).Tables(0).Rows(0).Item("nextNum")
                Dim cmd2 As New SqlCommand
                cmd2.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber, paymentmethod, notes, notedepartment, notesection, forHelee) VALUES (@countrID,@custID,@prio,@nextNum,@payment,@note,@ntdept,@ntsect,@helee);"
                cmd2.Parameters.AddWithValue("@countrID", customerAssignCounter.Counter.Counter_ID)
                cmd2.Parameters.AddWithValue("@custID", customerID)
                cmd2.Parameters.AddWithValue("@prio", customerAssignCounter.Priority)
                cmd2.Parameters.AddWithValue("@helee", customerAssignCounter.ForHelee)
                cmd2.Parameters.AddWithValue("@nextNum", nextNum)
                cmd2.Parameters.AddWithValue("@payment", customerAssignCounter.PaymentMethod)
                cmd2.Parameters.AddWithValue("@note", If(Not IsNothing(customerAssignCounter.Notes), customerAssignCounter.Notes, DBNull.Value))
                cmd2.Parameters.AddWithValue("@ntdept", If(Not IsNothing(customerAssignCounter.NoteDepartment), customerAssignCounter.NoteDepartment, DBNull.Value))
                cmd2.Parameters.AddWithValue("@ntsect", If(Not IsNothing(customerAssignCounter.NoteSection), customerAssignCounter.NoteSection, DBNull.Value))
                If excecuteCommand(cmd2) Then
                    Dim numlen As Integer = nextNum.ToString.Length
                    If numlen = 1 Then
                        Return customerAssignCounter.Counter.CounterPrefix + "-00" + nextNum.ToString
                    ElseIf numlen = 2 Then
                        Return customerAssignCounter.Counter.CounterPrefix + "-0" + nextNum.ToString
                    Else
                        Return customerAssignCounter.Counter.CounterPrefix + "-" + nextNum.ToString
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function NewCustomerGenerateQueueNumber(customerAssignCounter As CustomerAssignCounter) As String
        Try
            Dim cmd0 As New SqlCommand
            Dim infoID As Long = 0
            Dim otherInfoID As Long = 0
            If customerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE FK_emdPatients =@fkemd;"
                cmdlookup.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[province] = @province ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd, [picturelocation] = @imgloc WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerAssignCounter.Customer.CustomerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerAssignCounter.Customer.CustomerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerAssignCounter.Customer.CustomerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerAssignCounter.Customer.CustomerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerAssignCounter.Customer.CustomerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerAssignCounter.Customer.CustomerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerAssignCounter.Customer.CustomerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerAssignCounter.Customer.CustomerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerAssignCounter.Customer.CustomerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerAssignCounter.Customer.CustomerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerAssignCounter.Customer.CustomerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@province", customerAssignCounter.Customer.CustomerInfo.Province)
                        cmd0.Parameters.AddWithValue("@email", customerAssignCounter.Customer.CustomerInfo.Email)
                        cmd0.Parameters.AddWithValue("@imgloc", customerAssignCounter.Customer.CustomerInfo.PatientPicture)
                        cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        cmd0 = New SqlCommand With {
                            .CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE info_ID = @ID"
                        }
                        cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                        dt.Clear()
                        dt = fetchData(cmd0).Tables(0)
                        If Not IsNothing(dt) Then
                            If dt.Rows.Count <= 0 Then
                                cmd0 = New SqlCommand
                                cmd0.CommandText = "INSERT INTO [dbo].[customerotherinfo] (Info_ID, ID_Type, ID_Number, Valid_Until) 
                                                VALUES (@ID, @IDType, @IDNumber, @ValidUntil)"
                                cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                                cmd0.Parameters.AddWithValue("@IDType", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Type)
                                cmd0.Parameters.AddWithValue("@IDNumber", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Number)
                                cmd0.Parameters.AddWithValue("@ValidUntil", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ValidUntil)
                                otherInfoID = excecuteCommandReturnID(cmd0)
                            Else
                                cmd0 = New SqlCommand
                                cmd0.CommandText = "UPDATE [dbo].[customerotherinfo] SET ID_Type = @IDType, ID_Number = @IDNumber, Valid_Until = @ValidUntil
                                                    WHERE Info_ID = @ID"
                                cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                                cmd0.Parameters.AddWithValue("@IDType", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Type)
                                cmd0.Parameters.AddWithValue("@IDNumber", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Number)
                                cmd0.Parameters.AddWithValue("@ValidUntil", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ValidUntil)
                                If Not excecuteCommand(cmd0) Then
                                    infoID = 0
                                End If
                            End If
                        End If
                        GoTo skip
                    End If
                End If
            ElseIf customerAssignCounter.Customer.CustomerInfo.Info_ID > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE info_id = @ID"
                cmdlookup.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[province] = @province ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd, [picturelocation] = @imgloc WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerAssignCounter.Customer.CustomerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerAssignCounter.Customer.CustomerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerAssignCounter.Customer.CustomerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerAssignCounter.Customer.CustomerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerAssignCounter.Customer.CustomerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerAssignCounter.Customer.CustomerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerAssignCounter.Customer.CustomerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerAssignCounter.Customer.CustomerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerAssignCounter.Customer.CustomerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerAssignCounter.Customer.CustomerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerAssignCounter.Customer.CustomerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@province", customerAssignCounter.Customer.CustomerInfo.Province)
                        cmd0.Parameters.AddWithValue("@email", customerAssignCounter.Customer.CustomerInfo.Email)
                        cmd0.Parameters.AddWithValue("@imgloc", customerAssignCounter.Customer.CustomerInfo.PatientPicture)
                        cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If

                        cmd0 = New SqlCommand With {
                            .CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE info_ID = @ID"
                        }
                        cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                        dt.Clear()
                        dt = fetchData(cmd0).Tables(0)
                        If Not IsNothing(dt) Then
                            If dt.Rows.Count <= 0 Then
                                cmd0 = New SqlCommand
                                cmd0.CommandText = "INSERT INTO [dbo].[customerotherinfo] (Info_ID, ID_Type, ID_Number, Valid_Until) 
                                                VALUES (@ID, @IDType, @IDNumber, @ValidUntil)"
                                cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                                cmd0.Parameters.AddWithValue("@IDType", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Type)
                                cmd0.Parameters.AddWithValue("@IDNumber", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Number)
                                cmd0.Parameters.AddWithValue("@ValidUntil", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ValidUntil)
                                otherInfoID = excecuteCommandReturnID(cmd0)
                            Else
                                cmd0 = New SqlCommand
                                cmd0.CommandText = "UPDATE [dbo].[customerotherinfo] SET ID_Type = @IDType, ID_Number = @IDNumber, Valid_Until = @ValidUntil
                                                    WHERE Info_ID = @ID"
                                cmd0.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                                cmd0.Parameters.AddWithValue("@IDType", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Type)
                                cmd0.Parameters.AddWithValue("@IDNumber", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Number)
                                cmd0.Parameters.AddWithValue("@ValidUntil", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ValidUntil)
                                If Not excecuteCommand(cmd0) Then
                                    infoID = 0
                                End If
                            End If
                        End If
                        GoTo skip
                    End If
                End If
            End If
            cmd0.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname],[middlename],[lastname],[sex],[birthdate],[civilstatus],[street],[barangay],[city],[province],[phonenumber],[nationality],[email], [picturelocation], [FK_emdPatients]) VALUES (@fname,@mname,@lname,@sex,@bday,@cstat,@street,@brgy,@ct,@cp,@nat,@email,@imgloc,@fkemd); SELECT @@IDENTITY;"
            cmd0.Parameters.AddWithValue("@fname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.FirstName), customerAssignCounter.Customer.CustomerInfo.FirstName, ""))
            cmd0.Parameters.AddWithValue("@mname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Middlename), customerAssignCounter.Customer.CustomerInfo.Middlename, ""))
            cmd0.Parameters.AddWithValue("@lname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Lastname), customerAssignCounter.Customer.CustomerInfo.Lastname, ""))
            cmd0.Parameters.AddWithValue("@sex", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Sex), customerAssignCounter.Customer.CustomerInfo.Sex, ""))
            cmd0.Parameters.AddWithValue("@bday", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.BirthDate), customerAssignCounter.Customer.CustomerInfo.BirthDate, ""))
            cmd0.Parameters.AddWithValue("@cstat", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.CivilStatus), customerAssignCounter.Customer.CustomerInfo.CivilStatus, ""))
            cmd0.Parameters.AddWithValue("@street", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.StreetDrive), customerAssignCounter.Customer.CustomerInfo.StreetDrive, ""))
            cmd0.Parameters.AddWithValue("@brgy", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Barangay), customerAssignCounter.Customer.CustomerInfo.Barangay, ""))
            cmd0.Parameters.AddWithValue("@ct", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.CityMunicipality), customerAssignCounter.Customer.CustomerInfo.CityMunicipality, ""))
            cmd0.Parameters.AddWithValue("@cp", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.PhoneNumber), customerAssignCounter.Customer.CustomerInfo.PhoneNumber, ""))
            cmd0.Parameters.AddWithValue("@province", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Province), customerAssignCounter.Customer.CustomerInfo.Province, ""))
            cmd0.Parameters.AddWithValue("@nat", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Nationality), customerAssignCounter.Customer.CustomerInfo.Nationality, ""))
            cmd0.Parameters.AddWithValue("@email", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Email), customerAssignCounter.Customer.CustomerInfo.Email, ""))
            cmd0.Parameters.AddWithValue("@imgloc", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.PatientPicture), customerAssignCounter.Customer.CustomerInfo.PatientPicture, ""))
            cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
            infoID = excecuteCommandReturnID(cmd0)
            cmd0 = New SqlCommand
            cmd0.CommandText = "INSERT INTO [dbo].[customerotherinfo] (Info_ID, ID_Type, ID_Number, Valid_Until) 
                                                VALUES (@ID, @IDType, @IDNumber, @ValidUntil)"
            cmd0.Parameters.AddWithValue("@ID", infoID)
            cmd0.Parameters.AddWithValue("@IDType", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Type)
            cmd0.Parameters.AddWithValue("@IDNumber", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ID_Number)
            cmd0.Parameters.AddWithValue("@ValidUntil", customerAssignCounter.Customer.CustomerInfo.IdentificationInfo.ValidUntil)
            otherInfoID = excecuteCommandReturnID(cmd0)

skip:
            If infoID > 0 Then
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [wmmcqms].[customer] (fullname, address, phonenumber,FK_emdPatients,info_id) VALUES (@fname, @addr, @phone, @fk_emd, @infid); SELECT @@IDENTITY;"
                cmd.Parameters.AddWithValue("@fname", If(IsNothing(customerAssignCounter.Customer.FullName), DBNull.Value, customerAssignCounter.Customer.FullName))
                cmd.Parameters.AddWithValue("@addr", If(IsNothing(customerAssignCounter.Customer.Address), DBNull.Value, customerAssignCounter.Customer.Address))
                cmd.Parameters.AddWithValue("@phone", If(IsNothing(customerAssignCounter.Customer.PhoneNumber), DBNull.Value, customerAssignCounter.Customer.PhoneNumber))
                cmd.Parameters.AddWithValue("@fk_emd", customerAssignCounter.Customer.FK_emdPatients)
                cmd.Parameters.AddWithValue("@infid", infoID)
                Dim customerID As Long = excecuteCommandReturnID(cmd)
                If customerID > 0 Then
                    Dim cmd3 As New SqlCommand
                    cmd3.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                    cmd3.Parameters.AddWithValue("@ID", customerAssignCounter.Counter.Counter_ID)
                    Dim nextNum As Long = fetchData(cmd3).Tables(0).Rows(0).Item("nextNum")
                    Dim cmd2 As New SqlCommand
                    cmd2.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber, paymentmethod, notes, notedepartment, notesection, forHelee) VALUES (@countrID,@custID,@prio,@nextNum,@payment,@note,@ntdept,@ntsect,@helee);"
                    cmd2.Parameters.AddWithValue("@countrID", customerAssignCounter.Counter.Counter_ID)
                    cmd2.Parameters.AddWithValue("@custID", customerID)
                    cmd2.Parameters.AddWithValue("@prio", customerAssignCounter.Priority)
                    cmd2.Parameters.AddWithValue("@helee", customerAssignCounter.ForHelee)
                    cmd2.Parameters.AddWithValue("@nextNum", nextNum)
                    cmd2.Parameters.AddWithValue("@payment", customerAssignCounter.PaymentMethod)
                    cmd2.Parameters.AddWithValue("@note", If(Not IsNothing(customerAssignCounter.Notes), customerAssignCounter.Notes, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntdept", If(Not IsNothing(customerAssignCounter.NoteDepartment), customerAssignCounter.NoteDepartment, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntsect", If(Not IsNothing(customerAssignCounter.NoteSection), customerAssignCounter.NoteSection, DBNull.Value))
                    If excecuteCommand(cmd2) Then
                        If Not IsNothing(customerAssignCounter.Customer.CustomerInfo.HealthCheck) Then
                            Dim cmd4 As New SqlCommand
                            cmd4.CommandText = "INSERT INTO [dbo].[healthcheckdata] ([feverchills] ,[cough] ,[sorethroat] ,[diarrhea] ,[shortnessofbreathing] ,[ageusia] ,[anosmia] ,[colds] ,[closecontactconfirmed] ,[closecontactpersonexhibiting] ,[FK_emdPatients] ,[info_id]) VALUES (@fever ,@cough ,@sorethroat ,@diarrhea ,@shortness ,@ageusia ,@anosmia ,@colds ,@closecontactconfirmed ,@closecontactpersonexhibiting ,@fk_id ,@infoID);"
                            cmd4.Parameters.AddWithValue("@fever", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Fever)
                            cmd4.Parameters.AddWithValue("@cough", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Cough)
                            cmd4.Parameters.AddWithValue("@sorethroat", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Sorethroat)
                            cmd4.Parameters.AddWithValue("@diarrhea", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Diarrhea)
                            cmd4.Parameters.AddWithValue("@shortness", customerAssignCounter.Customer.CustomerInfo.HealthCheck.ShortnessOfBreathing)
                            cmd4.Parameters.AddWithValue("@ageusia", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Ageusia)
                            cmd4.Parameters.AddWithValue("@anosmia", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Anosmia)
                            cmd4.Parameters.AddWithValue("@colds", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Colds)
                            cmd4.Parameters.AddWithValue("@closecontactconfirmed", customerAssignCounter.Customer.CustomerInfo.HealthCheck.CloseContactConfirmed)
                            cmd4.Parameters.AddWithValue("@closecontactpersonexhibiting", customerAssignCounter.Customer.CustomerInfo.HealthCheck.CloseContactExhiting)
                            cmd4.Parameters.AddWithValue("@fk_id", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                            cmd4.Parameters.AddWithValue("@infoID", infoID)
                            excecuteCommand(cmd4)
                        End If
                        Dim numlen As Integer = nextNum.ToString.Length
                        If numlen = 1 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-00" + nextNum.ToString
                        ElseIf numlen = 2 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-0" + nextNum.ToString
                        Else
                            Return customerAssignCounter.Counter.CounterPrefix + "-" + nextNum.ToString
                        End If
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter As CustomerAssignCounter) As String
        Try
            Dim cmd0 As New SqlCommand
            Dim infoID As Long = 0
            If customerAssignCounter.Customer.CustomerInfo.FK_emdPatients > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE FK_emdPatients =@fkemd;"
                cmdlookup.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerAssignCounter.Customer.CustomerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerAssignCounter.Customer.CustomerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerAssignCounter.Customer.CustomerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerAssignCounter.Customer.CustomerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerAssignCounter.Customer.CustomerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerAssignCounter.Customer.CustomerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerAssignCounter.Customer.CustomerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerAssignCounter.Customer.CustomerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerAssignCounter.Customer.CustomerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerAssignCounter.Customer.CustomerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerAssignCounter.Customer.CustomerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerAssignCounter.Customer.CustomerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            ElseIf customerAssignCounter.Customer.CustomerInfo.Info_ID > 0 Then
                Dim cmdlookup As New SqlCommand
                cmdlookup.CommandText = "SELECT * FROM dbo.customerinfo WHERE info_id = @ID"
                cmdlookup.Parameters.AddWithValue("@ID", customerAssignCounter.Customer.CustomerInfo.Info_ID)
                Dim dt As DataTable = fetchData(cmdlookup).Tables(0)
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        infoID = dt.Rows(0)("info_id")
                        cmd0.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname,[middlename] = @mname ,[lastname] = @lname ,[sex] = @sex ,[birthdate] =@bday ,[civilstatus] = @cstat ,[street] =  @street ,[barangay] = @brgy ,[city] = @ct ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID;"
                        cmd0.Parameters.AddWithValue("@fname", customerAssignCounter.Customer.CustomerInfo.FirstName)
                        cmd0.Parameters.AddWithValue("@mname", customerAssignCounter.Customer.CustomerInfo.Middlename)
                        cmd0.Parameters.AddWithValue("@lname", customerAssignCounter.Customer.CustomerInfo.Lastname)
                        cmd0.Parameters.AddWithValue("@sex", customerAssignCounter.Customer.CustomerInfo.Sex)
                        cmd0.Parameters.AddWithValue("@bday", customerAssignCounter.Customer.CustomerInfo.BirthDate)
                        cmd0.Parameters.AddWithValue("@cstat", customerAssignCounter.Customer.CustomerInfo.CivilStatus)
                        cmd0.Parameters.AddWithValue("@street", customerAssignCounter.Customer.CustomerInfo.StreetDrive)
                        cmd0.Parameters.AddWithValue("@brgy", customerAssignCounter.Customer.CustomerInfo.Barangay)
                        cmd0.Parameters.AddWithValue("@ct", customerAssignCounter.Customer.CustomerInfo.CityMunicipality)
                        cmd0.Parameters.AddWithValue("@cp", customerAssignCounter.Customer.CustomerInfo.PhoneNumber)
                        cmd0.Parameters.AddWithValue("@nat", customerAssignCounter.Customer.CustomerInfo.Nationality)
                        cmd0.Parameters.AddWithValue("@email", customerAssignCounter.Customer.CustomerInfo.Email)
                        cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                        cmd0.Parameters.AddWithValue("@ID", infoID)
                        If Not excecuteCommand(cmd0) Then
                            infoID = 0
                        End If
                        GoTo skip
                    End If
                End If
            End If
            cmd0.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname],[middlename],[lastname],[sex],[birthdate],[civilstatus],[street],[barangay],[city],[phonenumber],[nationality],[email],[FK_emdPatients]) VALUES (@fname,@mname,@lname,@sex,@bday,@cstat,@street,@brgy,@ct,@cp,@nat,@email,@fkemd); SELECT @@IDENTITY;"
            cmd0.Parameters.AddWithValue("@fname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.FirstName), customerAssignCounter.Customer.CustomerInfo.FirstName, ""))
            cmd0.Parameters.AddWithValue("@mname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Middlename), customerAssignCounter.Customer.CustomerInfo.Middlename, ""))
            cmd0.Parameters.AddWithValue("@lname", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Lastname), customerAssignCounter.Customer.CustomerInfo.Lastname, ""))
            cmd0.Parameters.AddWithValue("@sex", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Sex), customerAssignCounter.Customer.CustomerInfo.Sex, ""))
            cmd0.Parameters.AddWithValue("@bday", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.BirthDate), customerAssignCounter.Customer.CustomerInfo.BirthDate, ""))
            cmd0.Parameters.AddWithValue("@cstat", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.CivilStatus), customerAssignCounter.Customer.CustomerInfo.CivilStatus, ""))
            cmd0.Parameters.AddWithValue("@street", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.StreetDrive), customerAssignCounter.Customer.CustomerInfo.StreetDrive, ""))
            cmd0.Parameters.AddWithValue("@brgy", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Barangay), customerAssignCounter.Customer.CustomerInfo.Barangay, ""))
            cmd0.Parameters.AddWithValue("@ct", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.CityMunicipality), customerAssignCounter.Customer.CustomerInfo.CityMunicipality, ""))
            cmd0.Parameters.AddWithValue("@cp", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.PhoneNumber), customerAssignCounter.Customer.CustomerInfo.PhoneNumber, ""))
            cmd0.Parameters.AddWithValue("@nat", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Nationality), customerAssignCounter.Customer.CustomerInfo.Nationality, ""))
            cmd0.Parameters.AddWithValue("@email", If(Not IsNothing(customerAssignCounter.Customer.CustomerInfo.Email), customerAssignCounter.Customer.CustomerInfo.Email, ""))
            cmd0.Parameters.AddWithValue("@fkemd", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
            infoID = excecuteCommandReturnID(cmd0)
skip:
            If infoID > 0 Then
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [wmmcqms].[customer] ( fullname, address, phonenumber,FK_emdPatients,info_id) VALUES (@fname, @addr, @phone, @fk_emd, @infid); SELECT @@IDENTITY;"
                cmd.Parameters.AddWithValue("@fname", If(IsNothing(customerAssignCounter.Customer.FullName), DBNull.Value, customerAssignCounter.Customer.FullName))
                cmd.Parameters.AddWithValue("@addr", If(IsNothing(customerAssignCounter.Customer.Address), DBNull.Value, customerAssignCounter.Customer.Address))
                cmd.Parameters.AddWithValue("@phone", If(IsNothing(customerAssignCounter.Customer.PhoneNumber), DBNull.Value, customerAssignCounter.Customer.PhoneNumber))
                cmd.Parameters.AddWithValue("@fk_emd", customerAssignCounter.Customer.FK_emdPatients)
                cmd.Parameters.AddWithValue("@infid", infoID)
                Dim customerID As Long = excecuteCommandReturnID(cmd)
                If customerID > 0 Then
                    Dim cmd3 As New SqlCommand
                    cmd3.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                    cmd3.Parameters.AddWithValue("@ID", customerAssignCounter.Counter.Counter_ID)
                    Dim nextNum As Long = fetchData(cmd3).Tables(0).Rows(0).Item("nextNum")
                    Dim cmd2 As New SqlCommand
                    cmd2.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber, paymentmethod, notes, notedepartment, notesection, forHelee) VALUES (@countrID,@custID,@prio,@nextNum,@payment,@note,@ntdept,@ntsect,@helee);"
                    cmd2.Parameters.AddWithValue("@countrID", customerAssignCounter.Counter.Counter_ID)
                    cmd2.Parameters.AddWithValue("@custID", customerID)
                    cmd2.Parameters.AddWithValue("@prio", customerAssignCounter.Priority)
                    cmd2.Parameters.AddWithValue("@helee", customerAssignCounter.ForHelee)
                    cmd2.Parameters.AddWithValue("@nextNum", nextNum)
                    cmd2.Parameters.AddWithValue("@payment", customerAssignCounter.PaymentMethod)
                    cmd2.Parameters.AddWithValue("@note", If(Not IsNothing(customerAssignCounter.Notes), customerAssignCounter.Notes, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntdept", If(Not IsNothing(customerAssignCounter.NoteDepartment), customerAssignCounter.NoteDepartment, DBNull.Value))
                    cmd2.Parameters.AddWithValue("@ntsect", If(Not IsNothing(customerAssignCounter.NoteSection), customerAssignCounter.NoteSection, DBNull.Value))
                    If excecuteCommand(cmd2) Then
                        If Not IsNothing(customerAssignCounter.Customer.CustomerInfo.HealthCheck) Then
                            Dim cmd4 As New SqlCommand
                            cmd4.CommandText = "INSERT INTO [dbo].[healthcheckdata] ([feverchills] ,[cough] ,[sorethroat] ,[diarrhea] ,[shortnessofbreathing] ,[ageusia] ,[anosmia] ,[colds] ,[closecontactconfirmed] ,[closecontactpersonexhibiting] , [VisitPurpose],[FK_emdPatients] ,[info_id]) VALUES (@fever ,@cough ,@sorethroat ,@diarrhea ,@shortness ,@ageusia ,@anosmia ,@colds ,@closecontactconfirmed ,@closecontactpersonexhibiting , @visitpurpose,@fk_id ,@infoID);"
                            cmd4.Parameters.AddWithValue("@fever", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Fever)
                            cmd4.Parameters.AddWithValue("@cough", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Cough)
                            cmd4.Parameters.AddWithValue("@sorethroat", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Sorethroat)
                            cmd4.Parameters.AddWithValue("@diarrhea", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Diarrhea)
                            cmd4.Parameters.AddWithValue("@shortness", customerAssignCounter.Customer.CustomerInfo.HealthCheck.ShortnessOfBreathing)
                            cmd4.Parameters.AddWithValue("@ageusia", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Ageusia)
                            cmd4.Parameters.AddWithValue("@anosmia", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Anosmia)
                            cmd4.Parameters.AddWithValue("@colds", customerAssignCounter.Customer.CustomerInfo.HealthCheck.Colds)
                            cmd4.Parameters.AddWithValue("@closecontactconfirmed", customerAssignCounter.Customer.CustomerInfo.HealthCheck.CloseContactConfirmed)
                            cmd4.Parameters.AddWithValue("@closecontactpersonexhibiting", customerAssignCounter.Customer.CustomerInfo.HealthCheck.CloseContactExhiting)
                            cmd4.Parameters.AddWithValue("@visitpurpose", customerAssignCounter.Customer.CustomerInfo.HealthCheck.PurposeOfVisit)
                            cmd4.Parameters.AddWithValue("@fk_id", customerAssignCounter.Customer.CustomerInfo.FK_emdPatients)
                            cmd4.Parameters.AddWithValue("@infoID", infoID)
                            excecuteCommand(cmd4)
                        End If
                        Dim cmdScreening As New SqlCommand
                        cmdScreening.CommandText = "SELECT * FROM  [wmmcqms].[counter] WHERE autotransfer_screening = 1"
                        Dim dtScreeningCounters As DataTable = fetchData(cmdScreening).Tables(0)
                        If Not IsNothing(dtScreeningCounters) Then
                            If dtScreeningCounters.Rows.Count > 0 Then
                                Dim cmd5 As New SqlCommand
                                cmd5.CommandText = "SELECT ISNULL(MAX(queuenumber) + 1,101) as nextNum FROM wmmcqms.customerassigncounter where CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) and counter_id = @ID"
                                cmd5.Parameters.AddWithValue("@ID", dtScreeningCounters.Rows(0)("counter_id"))
                                Dim nextNum2 As Long = fetchData(cmd5).Tables(0).Rows(0).Item("nextNum")
                                Dim cmd6 As New SqlCommand
                                cmd6.CommandText = "INSERT INTO [wmmcqms].[customerassigncounter] (counter_id, customer_id, priority, queuenumber) VALUES (@countrID,@custID,@prio,@nextNum);"
                                cmd6.Parameters.AddWithValue("@countrID", dtScreeningCounters.Rows(0)("counter_id"))
                                cmd6.Parameters.AddWithValue("@custID", customerID)
                                cmd6.Parameters.AddWithValue("@prio", 0)
                                cmd6.Parameters.AddWithValue("@nextNum", nextNum2)
                                excecuteCommand(cmd6)
                            End If
                        End If
                        Dim numlen As Integer = nextNum.ToString.Length
                        If numlen = 1 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-00" + nextNum.ToString
                        ElseIf numlen = 2 Then
                            Return customerAssignCounter.Counter.CounterPrefix + "-0" + nextNum.ToString
                        Else
                            Return customerAssignCounter.Counter.CounterPrefix + "-" + nextNum.ToString
                        End If
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function


    Public Function GetCertainCustomerQueueHistory(infoID As Long, fkEmdPatient As Long) As List(Of GetCustomerQueuingHistoryAll)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or d.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT a.*,b.*,c.*,
                              (SELECT countername FROM [wmmcqms].[servedcustomer] as d, [wmmcqms].[servertransaction] as e where (d.servertransaction_id = e.servertransaction_id) and customerassigncounter_id = a.customerassigncounter_id) as 'servedby', 
                              (select case when CONVERT(DATE,datetimequeued) = CONVERT(DATE, GETDATE()) then 1 else 0 end from [wmmcqms].customerassigncounter where customerassigncounter_id = a.customerassigncounter_id) AS offdate,(SELECT DATEDIFF(MINUTE,datetimeservedstart,datetimeservedend)  FROM [wmmcqms].[servedcustomer] where customerassigncounter_id = a.customerassigncounter_id) as 'transactiontime'
                              FROM [wmmcqms].[customerassigncounter] as a, [wmmcqms].[counter] as b, [wmmcqms].[customer] as c 
                              RIGHT JOIN [customerinfo] as d ON d.FK_emdPatients = c.FK_emdPatients
                              WHERE (a.counter_id = b.counter_id AND a.customer_id = c.customer_id) and (d.info_id = @ID " & qry & ")
                              ORDER BY a.customerassigncounter_id  DESC;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim queueHistoryList As New List(Of GetCustomerQueuingHistoryAll)
            For Each row As DataRow In data.Rows
                Dim queueHistory As New GetCustomerQueuingHistoryAll
                queueHistory.ServedBy = If(IsDBNull(row.Item("servedby")), Nothing, row.Item("servedby"))
                queueHistory.OffDate = row.Item("offdate")
                queueHistory.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                queueHistory.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                queueHistory.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                queueHistory.CustomerAssignCounter.Priority = row.Item("priority")
                queueHistory.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                queueHistory.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Counter.Section = row.Item("section")
                queueHistory.CustomerAssignCounter.Counter.Department = row.Item("department")
                queueHistory.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                queueHistory.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                queueHistory.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                queueHistory.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                queueHistory.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                queueHistory.CustomerAssignCounter.Customer.Customer_ID = row.Item("customer_id")
                queueHistory.CustomerAssignCounter.Customer.FullName = If(IsDBNull(row.Item("fullname")), "", row.Item("fullname"))
                queueHistory.CustomerAssignCounter.Customer.Address = If(IsDBNull(row.Item("address")), "", row.Item("address"))
                queueHistory.CustomerAssignCounter.Customer.PhoneNumber = If(IsDBNull(row.Item("phonenumber")), "", row.Item("phonenumber"))
                queueHistory.CustomerAssignCounter.Customer.DateOfVisit = row.Item("dateofvisit")
                queueHistory.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(queueHistory.CustomerAssignCounter)
                queueHistoryList.Add(queueHistory)
            Next
            Return queueHistoryList
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetQueueHistoryForMain(filter As CustomerAssignCounter) As List(Of GetCustomerQueuingHistoryAll)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT TOP 10000 a.*,b.*,c.*,(SELECT countername FROM [wmmcqms].[servedcustomer] as d, [wmmcqms].[servertransaction] as e where (d.servertransaction_id = e.servertransaction_id) and customerassigncounter_id = a.customerassigncounter_id) as 'servedby', (select case when CONVERT(DATE,datetimequeued) = CONVERT(DATE, GETDATE()) then 1 else 0 end from [wmmcqms].customerassigncounter where customerassigncounter_id = a.customerassigncounter_id) AS offdate,(SELECT DATEDIFF(MINUTE,datetimeservedstart,datetimeservedend)  FROM [wmmcqms].[servedcustomer] where customerassigncounter_id = a.customerassigncounter_id) as 'transactiontime' FROM [wmmcqms].[customerassigncounter] as a, [wmmcqms].[counter] as b, [wmmcqms].[customer] as c WHERE a.counter_id = b.counter_id AND a.customer_id = c.customer_id 
                               ORDER BY a.customerassigncounter_id  DESC;"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim queueHistoryList As New List(Of GetCustomerQueuingHistoryAll)
            For Each row As DataRow In data.Rows
                Dim queueHistory As New GetCustomerQueuingHistoryAll
                queueHistory.ServedBy = If(IsDBNull(row.Item("servedby")), Nothing, row.Item("servedby"))
                queueHistory.OffDate = row.Item("offdate")
                queueHistory.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                queueHistory.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                queueHistory.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                queueHistory.CustomerAssignCounter.Priority = row.Item("priority")
                queueHistory.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                queueHistory.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Counter.Section = row.Item("section")
                queueHistory.CustomerAssignCounter.Counter.Department = row.Item("department")
                queueHistory.CustomerAssignCounter.Counter.Counter_ID = row.Item("counter_id")
                queueHistory.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                queueHistory.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                queueHistory.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                queueHistory.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                queueHistory.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                queueHistory.CustomerAssignCounter.Customer.Customer_ID = row.Item("customer_id")
                queueHistory.CustomerAssignCounter.Customer.FullName = If(IsDBNull(row.Item("fullname")), "", row.Item("fullname"))
                queueHistory.CustomerAssignCounter.Customer.Address = If(IsDBNull(row.Item("address")), "", row.Item("address"))
                queueHistory.CustomerAssignCounter.Customer.PhoneNumber =
                If(IsDBNull(row.Item("phonenumber")), "", row.Item("phonenumber"))
                queueHistory.CustomerAssignCounter.Customer.DateOfVisit = row.Item("dateofvisit")
                queueHistory.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(queueHistory.CustomerAssignCounter)
                queueHistoryList.Add(queueHistory)
            Next
            Return queueHistoryList
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetListOfCustomerInQueueAll() As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *  FROM wmmcqms.customerassigncounter AS a join wmmcqms.customer as b on a.customer_id = b.customer_id JOIN wmmcqms.counter as c on a.counter_id = c.counter_id WHERE (convert(DATE,datetimequeued) = convert(DATE,GETDATE())) AND (a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM wmmcqms.servedcustomer as b))"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim customersInQueue As New List(Of CustomerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim customerInQueue As New CustomerAssignCounter
                customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                customerInQueue.Counter_ID = row.Item("counter_id")
                customerInQueue.Customer_ID = row.Item("customer_id")
                customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                customerInQueue.Result = row.Item("result")
                customerInQueue.Priority = row.Item("priority")
                customerInQueue.QueueNumber = row.Item("queuenumber")
                customerInQueue.Customer.Customer_ID = row.Item("customer_id")
                customerInQueue.Customer.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), Nothing)
                customerInQueue.Customer.Address = If(Not IsDBNull(row.Item("address")), row.Item("address"), Nothing)
                customerInQueue.Customer.PhoneNumber = If(Not IsDBNull(row.Item("phonenumber")), row.Item("phonenumber"), Nothing)
                customerInQueue.Customer.DateOfVisit = row.Item("dateofvisit")
                Dim counter As New Counter
                counter.Counter_ID = row.Item("counter_id")
                counter.Department = row.Item("department")
                counter.Section = row.Item("section")
                counter.CounterCode = row.Item("countercode")
                counter.ServiceDescription = row.Item("servicedescription")
                counter.CounterPrefix = row.Item("counterPrefix")
                counter.Icon = row.Item("icon")
                counter.isQueueingCounter = row.Item("isQueuingCounter")
                counter.allowedTurnaroundTime = row.Item("allowableTurnaroundTime")
                customerInQueue.Counter = counter
                customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                customersInQueue.Add(customerInQueue)
            Next
            Return customersInQueue
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetListOfCustomerInQueueByCounter(counter As Counter) As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.*,b.*,c.*  FROM wmmcqms.customerassigncounter AS a join wmmcqms.customer as b on a.customer_id = b.customer_id left join customerinfo as c on c.info_id = b.info_id WHERE (convert(DATE,datetimequeued) = convert(DATE,GETDATE()) AND a.counter_id = @ID) AND (a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM wmmcqms.servedcustomer as b)) ORDER BY queuenumber ASC"
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim customersInQueue As New List(Of CustomerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim customerInQueue As New CustomerAssignCounter
                customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                customerInQueue.Counter_ID = row.Item("counter_id")
                customerInQueue.Customer_ID = row.Item("customer_id")
                customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                customerInQueue.Result = row.Item("result")
                customerInQueue.Priority = row.Item("priority")
                customerInQueue.ForHelee = row.Item("forHelee")
                customerInQueue.QueueNumber = row.Item("queuenumber")
                customerInQueue.Customer.Customer_ID = row.Item("customer_id")
                customerInQueue.Customer.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), Nothing)
                customerInQueue.Customer.Address = If(Not IsDBNull(row.Item("address")), row.Item("address"), Nothing)
                customerInQueue.Customer.PhoneNumber = If(Not IsDBNull(row.Item("phonenumber")), row.Item("phonenumber"), Nothing)
                customerInQueue.Customer.DateOfVisit = row.Item("dateofvisit")
                customerInQueue.Customer.CustomerInfo = New CustomerInfo
                customerInQueue.Customer.CustomerInfo.Info_ID = If(Not IsDBNull(row.Item("info_id")), row.Item("info_id"), 0)
                customerInQueue.Customer.CustomerInfo.FirstName = If(Not IsDBNull(row.Item("firstname1")), row.Item("firstname1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Middlename = If(Not IsDBNull(row.Item("middlename1")), row.Item("middlename1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Lastname = If(Not IsDBNull(row.Item("lastname1")), row.Item("lastname1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Sex = If(Not IsDBNull(row.Item("sex1")), row.Item("sex1"), Nothing)
                customerInQueue.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(row.Item("birthdate1")), row.Item("birthdate1"), Now)
                customerInQueue.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(row.Item("civilstatus1")), row.Item("civilstatus1"), Nothing)
                customerInQueue.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(row.Item("street")), row.Item("street"), Nothing)
                customerInQueue.Customer.CustomerInfo.Barangay = If(Not IsDBNull(row.Item("barangay")), row.Item("barangay"), Nothing)
                customerInQueue.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(row.Item("city")), row.Item("city"), Nothing)
                customerInQueue.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(row.Item("phonenumber1")), row.Item("phonenumber1"), Nothing)
                customerInQueue.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(row.Item("FK_emdPatients1")), row.Item("FK_emdPatients1"), 0)
                customerInQueue.Counter = counter
                customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                customersInQueue.Add(customerInQueue)
            Next
            Return customersInQueue
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetAssignPatientToROD(ID As Long) As List(Of CustomerInfo)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM  [dbo].[customervitals] as a 
                                JOIN dbo.customerinfo as b on b.info_id = a.info_id
                                JOIN wmmcqms.customerassigncounter as c on c.customerassigncounter_id = (SELECT MAX(customerassigncounter_id) FROM wmmcqms.customerassigncounter JOIN wmmcqms.customer ON wmmcqms.customerassigncounter.customer_id = wmmcqms.customer.customer_id WHERE wmmcqms.customer.info_id = b.info_id)
                                JOIN wmmcqms.counter as d on d.counter_id = c.counter_id
                                WHERE CONVERT(DATE,a.datecreated) = CONVERT(DATE,GETDATE()) AND tmpAssignCounter_id =  @ID
                                AND a.info_id NOT IN 
                                (SELECT dbo.customerinfo.info_id FROM wmmcqms.customerassigncounter
                                JOIN wmmcqms.customer ON wmmcqms.customer.customer_id = wmmcqms.customerassigncounter.customer_id  
                                JOIN dbo.customerinfo ON dbo.customerinfo.info_id = wmmcqms.customer.info_id
                                WHERE CONVERT(DATE,wmmcqms.customerassigncounter.datetimequeued) = CONVERT(DATE,GETDATE()) AND wmmcqms.customerassigncounter.counter_id = (SELECT counter_id FROM wmmcqms.serverassigncounter where wmmcqms.serverassigncounter.serverassigncounter_ID = @ID))
                                ORDER BY a.consultation_id ASC"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim patients As New List(Of CustomerInfo)
                For Each row As DataRow In data.Rows
                    Dim patient As New CustomerInfo
                    patient.Info_ID = row("info_id")
                    patient.FirstName = row("firstname")
                    patient.Middlename = row("middlename")
                    patient.Lastname = row("lastname")
                    patient.Sex = row("sex")
                    patient.BirthDate = row("birthdate")
                    patient.CivilStatus = row("civilstatus")
                    patient.StreetDrive = row("street")
                    patient.Barangay = row("barangay")
                    patient.CityMunicipality = row("city")
                    patient.Nationality = row("nationality")
                    patient.Email = row("email")
                    patient.PhoneNumber = row("phonenumber")
                    patient.PatientPicture = row("picturelocation")
                    patient.FK_emdPatients = row("FK_emdPatients")
                    patients.Add(patient)
                Next
                Return patients
            End If
            Return Nothing
            cmd.Parameters.AddWithValue("@ID", ID)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function


    Public Function GetListOfPatientByClinic(counter As Counter) As List(Of CustomerAssignCounter)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.*,b.*,c.*, d.*
                               FROM wmmcqms.customerassigncounter AS a 
                               JOIN wmmcqms.customer as b on a.customer_id = b.customer_id 
                               LEFT JOIN customerinfo as c on c.info_id = b.info_id
                               LEFT JOIN wmmcqms.servedcustomer as d on a.customerassigncounter_id = d.customerassigncounter_id
                               WHERE (convert(DATE,datetimequeued) = convert(DATE,GETDATE()) AND a.counter_id = @ID) ORDER BY queuenumber ASC"
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim customersInQueue As New List(Of CustomerAssignCounter)
            For Each row As DataRow In data.Rows
                Dim customerInQueue As New CustomerAssignCounter
                customerInQueue.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                customerInQueue.Counter_ID = row.Item("counter_id")
                customerInQueue.Customer_ID = row.Item("customer_id")
                customerInQueue.DateTimeQueued = row.Item("datetimequeued")
                customerInQueue.Result = row.Item("result")
                customerInQueue.Priority = row.Item("priority")
                customerInQueue.QueueNumber = row.Item("queuenumber")
                customerInQueue.Customer.Customer_ID = row.Item("customer_id")
                customerInQueue.Customer.FullName = If(Not IsDBNull(row.Item("fullname")), row.Item("fullname"), Nothing)
                customerInQueue.Customer.Address = If(Not IsDBNull(row.Item("address")), row.Item("address"), Nothing)
                customerInQueue.Customer.PhoneNumber = If(Not IsDBNull(row.Item("phonenumber")), row.Item("phonenumber"), Nothing)
                customerInQueue.Customer.DateOfVisit = row.Item("dateofvisit")
                customerInQueue.Customer.CustomerInfo = New CustomerInfo
                customerInQueue.Customer.CustomerInfo.Info_ID = If(Not IsDBNull(row.Item("info_id")), row.Item("info_id"), 0)
                customerInQueue.Customer.CustomerInfo.FirstName = If(Not IsDBNull(row.Item("firstname1")), row.Item("firstname1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Middlename = If(Not IsDBNull(row.Item("middlename1")), row.Item("middlename1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Lastname = If(Not IsDBNull(row.Item("lastname1")), row.Item("lastname1"), Nothing)
                customerInQueue.Customer.CustomerInfo.Sex = If(Not IsDBNull(row.Item("sex1")), row.Item("sex1"), Nothing)
                customerInQueue.Customer.CustomerInfo.BirthDate = If(Not IsDBNull(row.Item("birthdate1")), row.Item("birthdate1"), Now)
                customerInQueue.Customer.CustomerInfo.CivilStatus = If(Not IsDBNull(row.Item("civilstatus1")), row.Item("civilstatus1"), Nothing)
                customerInQueue.Customer.CustomerInfo.StreetDrive = If(Not IsDBNull(row.Item("street")), row.Item("street"), Nothing)
                customerInQueue.Customer.CustomerInfo.Barangay = If(Not IsDBNull(row.Item("barangay")), row.Item("barangay"), Nothing)
                customerInQueue.Customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(row.Item("city")), row.Item("city"), Nothing)
                customerInQueue.Customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(row.Item("phonenumber1")), row.Item("phonenumber1"), Nothing)
                customerInQueue.Customer.CustomerInfo.PatientPicture = If(Not IsDBNull(row.Item("picturelocation")), row.Item("picturelocation"), Nothing)
                customerInQueue.Customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(row.Item("FK_emdPatients1")), row.Item("FK_emdPatients1"), 0)
                customerInQueue.Counter = counter
                customerInQueue.ProcessedQueueNumber = GetProcessedQueueNumber(customerInQueue)
                If Not IsDBNull(row.Item("served_id")) Then
                    customerInQueue.ServedCustomer = New ServedCustomer
                    customerInQueue.ServedCustomer.ServedCustomer_ID = row.Item("served_id")
                    customerInQueue.ServedCustomer.ServerTransaction_ID = row.Item("servertransaction_id")
                    customerInQueue.ServedCustomer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                    customerInQueue.ServedCustomer.DateTimeStart = If(Not IsDBNull(row.Item("datetimeservedstart")), row.Item("datetimeservedstart"), Nothing)
                    customerInQueue.ServedCustomer.DateTimeEnd = If(Not IsDBNull(row.Item("datetimeservedend")), row.Item("datetimeservedend"), Nothing)
                Else
                    customerInQueue.ServedCustomer = Nothing
                End If
                customersInQueue.Add(customerInQueue)
            Next
            Return customersInQueue
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetNextNumber(servedCustomer As ServedCustomer) As ServedCustomer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = ""
            If servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID > 0 Then
                cmd.CommandText = "SELECT MIN(a.customerassigncounter_id) as customerassigncounter_id, (a.queuenumber), a.priority, a.forHelee,a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection FROM wmmcqms.customerassigncounter AS a WHERE (convert(date,datetimequeued) = convert(DATE,GETDATE())) AND (a.customerassigncounter_id =@ID and a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM wmmcqms.servedcustomer as b)) GROUP BY customerassigncounter_id,a.queuenumber, a.priority, a.forHelee, a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection"
                'SELECT MIN(a.`customerassigncounter_id`) as `customerassigncounter_id`, a.`queuenumber`, a.priority FROM `customerassigncounter` AS `a` WHERE (DATE(datetimequeued) = CURRENT_DATE) AND (a.`customerassigncounter_id` = @ID and a.`customerassigncounter_id` NOT IN (SELECT b.`customerassigncounter_id` FROM servedcustomer as `b`))
                cmd.Parameters.AddWithValue("@ID", servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID)
            Else
                If servedCustomer.CustomerAssignCounter.Priority > 0 Then
                    cmd.CommandText = "SELECT MIN(a.customerassigncounter_id) as customerassigncounter_id, a.queuenumber, a.priority, a.forHelee, a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection FROM wmmcqms.customerassigncounter AS a WHERE (CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) AND a.counter_id = @ID and priority > 0) AND (a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM wmmcqms.servedcustomer as b)) GROUP BY customerassigncounter_id,a.queuenumber, a.priority, a.forHelee, a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection"
                    'SELECT MIN(a.`customerassigncounter_id`) as `customerassigncounter_id`, a.`queuenumber`, a.priority FROM `customerassigncounter` AS `a` WHERE (DATE(datetimequeued) = CURRENT_DATE AND a.counter_id = @ID and priority > 0) AND (a.`customerassigncounter_id` NOT IN (SELECT b.`customerassigncounter_id` FROM servedcustomer as `b`))
                Else
                    cmd.CommandText = "SELECT MIN(a.customerassigncounter_id) as customerassigncounter_id, a.queuenumber, a.priority, a.forHelee, a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection FROM wmmcqms.customerassigncounter AS a WHERE (CONVERT(DATE,datetimequeued) = convert(DATE,GETDATE()) AND a.counter_id = @ID and priority >= 0) AND (a.customerassigncounter_id NOT IN (SELECT b.customerassigncounter_id FROM wmmcqms.servedcustomer as b)) GROUP BY customerassigncounter_id,a.queuenumber, a.priority, a.forHelee, a.customer_id, a.paymentmethod, a.notes, a.notedepartment, a.notesection"
                End If
                cmd.Parameters.AddWithValue("@ID", servedCustomer.CustomerAssignCounter.Counter_ID)
            End If
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                If Not IsDBNull(data.Rows(0).Item("customerassigncounter_id")) Or Not IsDBNull(data.Rows(0).Item("queuenumber")) Then
                    servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID = data.Rows(0).Item("customerassigncounter_id")
                    servedCustomer.CustomerAssignCounter.QueueNumber = data.Rows(0).Item("queuenumber")
                    servedCustomer.CustomerAssignCounter.Priority = data.Rows(0).Item("priority")
                    servedCustomer.CustomerAssignCounter.ForHelee = data.Rows(0).Item("forHelee")
                    servedCustomer.CustomerAssignCounter.Notes = If(Not IsDBNull(data.Rows(0).Item("notes")), data.Rows(0).Item("notes"), Nothing)
                    servedCustomer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(data.Rows(0).Item("notedepartment")), data.Rows(0).Item("notedepartment"), Nothing)
                    servedCustomer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(data.Rows(0).Item("notesection")), data.Rows(0).Item("notesection"), Nothing)
                    servedCustomer.CustomerAssignCounter.PaymentMethod = data.Rows(0).Item("paymentmethod")
                    servedCustomer.CustomerAssignCounter.Customer_ID = data.Rows(0).Item("customer_id")
                    Dim customerController As New CustomerController
                    servedCustomer.CustomerAssignCounter.Customer = customerController.GetCertainCustomer(data.Rows(0).Item("customer_id"))
                    servedCustomer.CustomerAssignCounter.ProcessedQueueNumber = GetProcessedQueueNumber(servedCustomer.CustomerAssignCounter)
                    Dim servedCustomerController As New ServedCustomerController
                    Dim servingCustomer As New ServedCustomer
                    servingCustomer = servedCustomerController.NewServingReturn(servedCustomer)
                    If Not IsNothing(servingCustomer) Then
                        servedCustomer.ServedCustomer_ID = servingCustomer.ServedCustomer_ID
                        servedCustomer.ServerTransaction_ID = servingCustomer.ServerTransaction_ID
                        servedCustomer.CustomerAssginCounter_ID = servingCustomer.CustomerAssginCounter_ID
                        Return servedCustomer
                    End If
                End If
            Else
                servedCustomer.ServedCustomer_ID = 0
                Return servedCustomer
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function DeleteCustomerAssignCounter(ID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [wmmcqms].[customerassigncounter] WHERE customerassigncounter_id = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetProcessedQueueNumber(custommerAssignCounter As CustomerAssignCounter) As String
        Dim numlen As Integer = custommerAssignCounter.QueueNumber.ToString.Length
        If numlen = 1 Then
            Return custommerAssignCounter.Counter.CounterPrefix + "-00" + custommerAssignCounter.QueueNumber.ToString
        ElseIf numlen = 2 Then
            Return custommerAssignCounter.Counter.CounterPrefix + "-0" + custommerAssignCounter.QueueNumber.ToString
        Else
            Return custommerAssignCounter.Counter.CounterPrefix + "-" + custommerAssignCounter.QueueNumber.ToString
        End If
    End Function

End Class
