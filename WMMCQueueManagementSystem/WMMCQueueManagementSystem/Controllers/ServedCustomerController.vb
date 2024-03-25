Imports System.Data.SqlClient
Public Class ServedCustomerController

    Public Function NewServingReturn(servedCustomer As ServedCustomer) As ServedCustomer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO wmmcqms.servedcustomer (servertransaction_id, customerassigncounter_id) VALUES (@serv,@cust); SELECT @@IDENTITY;"
            cmd.Parameters.AddWithValue("@serv", servedCustomer.ServerTransaction.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@cust", servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID)
            Dim id As Long = excecuteCommandReturnID(cmd)
            If id > 0 Then
                Dim servingCustomer As New ServedCustomer
                servingCustomer.ServedCustomer_ID = id
                servingCustomer.ServerTransaction_ID = servedCustomer.ServerTransaction.ServerTransaction_ID
                servingCustomer.CustomerAssginCounter_ID = servedCustomer.CustomerAssignCounter.CustomerAssignCounter_ID
                Return servingCustomer
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return Nothing
        End Try
    End Function

    Public Function UpdateServedCustomerServeTime(servedCustomer As ServedCustomer) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.servedcustomer SET datetimeservedend = CURRENT_TIMESTAMP WHERE servedcustomer.served_id = @ID;"
            cmd.Parameters.AddWithValue("@ID", servedCustomer.ServedCustomer_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return False
        End Try
    End Function

    Public Function GetMultipleDepartmentServingQueue(counter As List(Of Counter)) As List(Of GetServingCustomerOfServer)
        Try
#Region "Unused"
            'If counter.Count = 2 Then
            '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1) WHERE CONVERT(DATE,datetimelogin) =  CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;;"
            '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            'ElseIf counter.Count = 3 Then
            '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            'ElseIf counter.Count = 4 Then
            '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    'ElseIf counter.Count = 5 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    'ElseIf counter.Count = 6 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4 or d.counter_id = @ID5) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID5", counter(5).Counter_ID)
            '    'ElseIf counter.Count = 7 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4 or d.counter_id = @ID5 or d.counter_id = @ID6) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID5", counter(5).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID6", counter(6).Counter_ID)
            '    'ElseIf counter.Count = 8 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4 or d.counter_id = @ID5 or d.counter_id = @ID6 or d.counter_id = @ID7) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID5", counter(5).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID6", counter(6).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID7", counter(7).Counter_ID)
            '    'ElseIf counter.Count = 9 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4 or d.counter_id = @ID5 or d.counter_id = @ID6 or d.counter_id = @ID7 or d.counter_id = @ID8) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID5", counter(5).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID6", counter(6).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID7", counter(7).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID8", counter(8).Counter_ID)
            '    'ElseIf counter.Count = 10 Then
            '    '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND (d.counter_id = @ID0 or d.counter_id = @ID1 or d.counter_id = @ID2 or d.counter_id = @ID3 or d.counter_id = @ID4 or d.counter_id = @ID5 or d.counter_id = @ID6 or d.counter_id = @ID7 or d.counter_id = @ID8 or d.counter_id = @ID9) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC;"
            '    '    cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID1", counter(1).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID2", counter(2).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID3", counter(3).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID4", counter(4).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID5", counter(5).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID6", counter(6).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID7", counter(7).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID8", counter(8).Counter_ID)
            '    '    cmd.Parameters.AddWithValue("@ID9", counter(9).Counter_ID)
            'Else
            '    cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms. customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND ("
            '    Dim cmdTextParam As String = ""
            '    For index = 0 To counter.Count - 1
            '        cmd.Parameters.AddWithValue($"@ID{index}", counter(index).Counter_ID)
            '        If index = 0 Then
            '            cmdTextParam += $"d.counter_id = @ID{index}"
            '        Else
            '            cmdTextParam += $" or d.counter_id = @ID{index}"
            '        End If
            '    Next
            '    'For Each cntr In counter
            '    '    cmd.Parameters.AddWithValue($"@ID{i}", cntr.Counter_ID)
            '    '    cmdTextParam += $" or d.counter_id = @ID{i}"
            '    '    i += 1
            '    'Next
            '    cmd.CommandText += $"{cmdTextParam}) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC"
            '    'cmd.Parameters.AddWithValue("@ID0", counter(0).Counter_ID)
            'End If
#End Region
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms.customerassigncounter as b 
                                ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) 
                                JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x 
                                ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL 
                                JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND ("
            }
            Dim cmdTextParam As String = ""
            For index = 0 To counter.Count - 1
                cmd.Parameters.AddWithValue($"@ID{index}", counter(index).Counter_ID)
                If index = 0 Then
                    cmdTextParam += $"d.counter_id = @ID{index}"
                Else
                    cmdTextParam += $" or d.counter_id = @ID{index}"
                End If
            Next
            cmd.CommandText += $"{cmdTextParam}) WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC"


            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim currentServingCustomer As New List(Of GetServingCustomerOfServer)
            If Not IsNothing(currentServingCustomer) Then
                For Each row As DataRow In data.Rows
                    Dim isqueueCusomter As New GetServingCustomerOfServer
                    isqueueCusomter.serverTransaction.ServerTransaction_ID = row.Item("servertransaction_id")
                    isqueueCusomter.serverTransaction.ServerAssignCounter_ID = row.Item("serverassigncounter_id")
                    isqueueCusomter.serverTransaction.CounterName = row.Item("countername")
                    isqueueCusomter.serverTransaction.DateTimeLogin = If(IsDBNull(row.Item("datetimelogin")), Nothing, row.Item("datetimelogin"))
                    isqueueCusomter.serverTransaction.DateTimeLogout = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                    If Not IsDBNull(row.Item("served_id")) Then
                        isqueueCusomter.servedCustomer.ServedCustomer_ID = row.Item("served_id")
                        isqueueCusomter.servedCustomer.ServerTransaction_ID = row.Item("servertransaction_id")
                        isqueueCusomter.servedCustomer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.servedCustomer.DateTimeStart = If(IsDBNull(row.Item("datetimeservedstart")), Nothing, row.Item("datetimeservedstart"))
                        isqueueCusomter.servedCustomer.DateTimeEnd = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                        isqueueCusomter.customerAssigncounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.customerAssigncounter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.customerAssigncounter.Customer_ID = row.Item("customer_id")
                        isqueueCusomter.customerAssigncounter.DateTimeQueued = row.Item("datetimequeued")
                        isqueueCusomter.customerAssigncounter.Priority = row.Item("priority")
                        isqueueCusomter.customerAssigncounter.QueueNumber = row.Item("queuenumber")
                        isqueueCusomter.counter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.counter.Department = row.Item("department")
                        isqueueCusomter.counter.Section = row.Item("section")
                        isqueueCusomter.counter.ServiceDescription = row.Item("servicedescription")
                        isqueueCusomter.counter.CounterPrefix = row.Item("counterPrefix")
                        isqueueCusomter.counter.CounterCode = row.Item("countercode")
                        isqueueCusomter.counter.Icon = row.Item("icon")
                        isqueueCusomter.counter.isQueueingCounter = row.Item("isQueuingCounter")

                        Dim customerAsignCounterController As New CustomerAssignCounterController
                        isqueueCusomter.customerAssigncounter.Counter = isqueueCusomter.counter
                        isqueueCusomter.customerAssigncounter.ProcessedQueueNumber = customerAsignCounterController.GetProcessedQueueNumber(isqueueCusomter.customerAssigncounter)
                    Else
                        isqueueCusomter.servedCustomer = Nothing
                        isqueueCusomter.customerAssigncounter = Nothing
                        isqueueCusomter.counter = Nothing
                    End If

                    currentServingCustomer.Add(isqueueCusomter)
                Next
                Return currentServingCustomer
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return Nothing
        End Try
    End Function

    Public Function AllCounterQueueBoardDisplay() As List(Of GetServingCustomerOfServer)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT DISTINCT(a.counterboarditem_id), a.displayname,a.displayctr, b.*,c.counter_id,c.counterPrefix, 
                                (SELECT queuenumber FROM wmmcqms.customerassigncounter WHERE wmmcqms.customerassigncounter.customerassigncounter_id = 
                                (SELECT MAX(wmmcqms.customerassigncounter.customerassigncounter_id) FROM wmmcqms.customerassigncounter 
                                JOIN wmmcqms.servedcustomer ON wmmcqms.customerassigncounter.customerassigncounter_id = wmmcqms.servedcustomer.customerassigncounter_id
                                WHERE wmmcqms.customerassigncounter.counter_id = 5 AND CONVERT(DATE,wmmcqms.customerassigncounter.datetimequeued) = CONVERT(DATE,GETDATE())
                                AND wmmcqms.servedcustomer.datetimeservedstart IS NOT NULL))
                                FROM dbo.counterboard as a
                                LEFT JOIN dbo.counterboardtransaction as b on a.counterboarditem_id = b.counterboarditem_id AND CONVERT(DATE,b.datetimelogged) = CONVERT(DATE,GETDATE()) AND b.datetimelogged = (SELECT MAX(datetimelogged) FROM dbo.counterboardtransaction WHERE dbo.counterboardtransaction.counterboarditem_id = a.counterboarditem_id)
                                LEFT JOIN wmmcqms.counter as c on c.counter_id = b.counter_id
                                ORDER BY a.displayctr,displayname"
            }
            Dim data As DataTable = fetchData(cmd).Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllDepartmentServingQueue() As List(Of GetServingCustomerOfServer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT y.counterType,x.*,a.*,b.*,c.*,
                                    CASE WHEN b.customerassigncounter_id IS NULL 
                                    THEN 
                                    (SELECT CONCAT(counterPrefix,'-',queuenumber)  FROM [wmmcqms].customerassigncounter as m
								    JOIN [wmmcqms].servedcustomer as n on m.customerassigncounter_id = n.customerassigncounter_id
								    JOIN [wmmcqms].counter as o on o.counter_id = m.counter_id
								    WHERE CONVERT(DATE,m.datetimequeued) = CONVERT (DATE,GETDATE()) AND (m.customerassigncounter_id = (select MAX(p.customerassigncounter_id) FROM [wmmcqms].customerassigncounter as p JOIN [wmmcqms].servedcustomer as q ON p.customerassigncounter_id = q.customerassigncounter_id JOIN [wmmcqms].servertransaction as r on r.servertransaction_id = q.servertransaction_id JOIN [wmmcqms].serverassigncounter as s on s.serverassigncounter_ID = r.serverassigncounter_id  WHERE r.serverassigncounter_id = x.serverassigncounter_id)))
                                    ELSE 
                                    NULL
                                    END 
                                    AS 'tempqueue'
                                    FROM wmmcqms.servedcustomer as a 
                                    JOIN wmmcqms.customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) =CONVERT (DATE,GETDATE())
                                    JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id 
                                    RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND (a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL)
                                    JOIN wmmcqms.serverassigncounter as z ON x.serverassigncounter_ID = z.serverassigncounter_ID AND z.isMain = 0
                                    JOIN wmmcqms.counter as y ON y.counter_id = z.counter_id AND ((y.counterType = 0) or (y.counterType = 2) or (y.counterType = 3))
                                    WHERE CONVERT(DATE, datetimelogin) =  CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL
                               ORDER BY y.counterStepByStep,countername ASC;"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim currentServingCustomer As New List(Of GetServingCustomerOfServer)
                For Each row As DataRow In data.Rows
                    Dim isqueueCusomter As New GetServingCustomerOfServer
                    isqueueCusomter.serverTransaction.ServerTransaction_ID = row.Item("servertransaction_id")
                    isqueueCusomter.serverTransaction.ServerAssignCounter_ID = row.Item("serverassigncounter_id")
                    isqueueCusomter.serverTransaction.CounterName = row.Item("countername")
                    isqueueCusomter.serverTransaction.DateTimeLogin = If(IsDBNull(row.Item("datetimelogin")), Nothing, row.Item("datetimelogin"))
                    isqueueCusomter.serverTransaction.DateTimeLogout = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                    isqueueCusomter.TemporaryQueueNumber = If(IsDBNull(row.Item("tempqueue")), "", row.Item("tempqueue"))
                    If Not IsDBNull(row.Item("served_id")) Then
                        isqueueCusomter.servedCustomer.ServedCustomer_ID = row.Item("served_id")
                        isqueueCusomter.servedCustomer.ServerTransaction_ID = row.Item("servertransaction_id")
                        isqueueCusomter.servedCustomer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.servedCustomer.DateTimeStart = If(IsDBNull(row.Item("datetimeservedstart")), Nothing, row.Item("datetimeservedstart"))
                        isqueueCusomter.servedCustomer.DateTimeEnd = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                        isqueueCusomter.customerAssigncounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.customerAssigncounter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.customerAssigncounter.Customer_ID = row.Item("customer_id")
                        isqueueCusomter.customerAssigncounter.DateTimeQueued = row.Item("datetimequeued")
                        isqueueCusomter.customerAssigncounter.Priority = row.Item("priority")
                        isqueueCusomter.customerAssigncounter.QueueNumber = row.Item("queuenumber")
                        isqueueCusomter.counter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.counter.Department = row.Item("department")
                        isqueueCusomter.counter.Section = row.Item("section")
                        isqueueCusomter.counter.ServiceDescription = row.Item("servicedescription")
                        isqueueCusomter.counter.CounterPrefix = row.Item("counterPrefix")
                        isqueueCusomter.counter.CounterCode = row.Item("countercode")
                        isqueueCusomter.counter.Icon = row.Item("icon")
                        isqueueCusomter.counter.isQueueingCounter = row.Item("isQueuingCounter")
                        Dim customerAsignCounterController As New CustomerAssignCounterController
                        isqueueCusomter.customerAssigncounter.Counter = isqueueCusomter.counter
                        isqueueCusomter.customerAssigncounter.ProcessedQueueNumber = customerAsignCounterController.GetProcessedQueueNumber(isqueueCusomter.customerAssigncounter)
                    Else
                        isqueueCusomter.servedCustomer = Nothing
                        isqueueCusomter.customerAssigncounter = Nothing
                        isqueueCusomter.counter = Nothing
                    End If
                    currentServingCustomer.Add(isqueueCusomter)
                Next
                Return currentServingCustomer
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetPCCClinicAndPaymentServingQueue() As List(Of GetServingCustomerOfServer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT y.counterType,x.*,a.*,b.*,c.*,
                                CASE WHEN b.customerassigncounter_id IS NULL 
                                THEN 
                                (SELECT CONCAT(counterPrefix,'-',queuenumber)  FROM [wmmcqms].customerassigncounter as m
                                JOIN [wmmcqms].servedcustomer as n on m.customerassigncounter_id = n.customerassigncounter_id
                                JOIN [wmmcqms].counter as o on o.counter_id = m.counter_id
                                WHERE CONVERT(DATE,m.datetimequeued) = CONVERT (DATE,GETDATE()) AND (m.customerassigncounter_id = (select MAX(p.customerassigncounter_id) FROM [wmmcqms].customerassigncounter as p JOIN [wmmcqms].servedcustomer as q ON p.customerassigncounter_id = q.customerassigncounter_id JOIN [wmmcqms].servertransaction as r on r.servertransaction_id = q.servertransaction_id JOIN [wmmcqms].serverassigncounter as s on s.serverassigncounter_ID = r.serverassigncounter_id  WHERE r.serverassigncounter_id = x.serverassigncounter_id)))
                                ELSE 
                                NULL
                                END 
                                AS 'tempqueue'
                                FROM wmmcqms.servedcustomer as a 
                                JOIN wmmcqms.customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT(DATE,b.datetimequeued) =CONVERT (DATE,GETDATE())
                                JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id 
                                RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND (a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL)
                                JOIN wmmcqms.serverassigncounter as z ON x.serverassigncounter_ID = z.serverassigncounter_ID AND z.isMain = 0
                                JOIN wmmcqms.counter as y ON y.counter_id = z.counter_id AND ((y.counterType = 2) or (y.counterType = 3))
                                WHERE CONVERT(DATE, datetimelogin) =  CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL AND y.autotransfer_screening = 0 AND (y.counterType = 2 or (y.counterType = 3))
                                ORDER BY y.counterStepByStep,countername ASC;"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim currentServingCustomer As New List(Of GetServingCustomerOfServer)
                For Each row As DataRow In data.Rows
                    Dim isqueueCusomter As New GetServingCustomerOfServer
                    isqueueCusomter.serverTransaction.ServerTransaction_ID = row.Item("servertransaction_id")
                    isqueueCusomter.serverTransaction.ServerAssignCounter_ID = row.Item("serverassigncounter_id")
                    isqueueCusomter.serverTransaction.CounterName = row.Item("countername")
                    isqueueCusomter.serverTransaction.DateTimeLogin = If(IsDBNull(row.Item("datetimelogin")), Nothing, row.Item("datetimelogin"))
                    isqueueCusomter.serverTransaction.DateTimeLogout = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                    isqueueCusomter.TemporaryQueueNumber = If(IsDBNull(row.Item("tempqueue")), "", row.Item("tempqueue"))
                    If Not IsDBNull(row.Item("served_id")) Then
                        isqueueCusomter.servedCustomer.ServedCustomer_ID = row.Item("served_id")
                        isqueueCusomter.servedCustomer.ServerTransaction_ID = row.Item("servertransaction_id")
                        isqueueCusomter.servedCustomer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.servedCustomer.DateTimeStart = If(IsDBNull(row.Item("datetimeservedstart")), Nothing, row.Item("datetimeservedstart"))
                        isqueueCusomter.servedCustomer.DateTimeEnd = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                        isqueueCusomter.customerAssigncounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.customerAssigncounter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.customerAssigncounter.Customer_ID = row.Item("customer_id")
                        isqueueCusomter.customerAssigncounter.DateTimeQueued = row.Item("datetimequeued")
                        isqueueCusomter.customerAssigncounter.Priority = row.Item("priority")
                        isqueueCusomter.customerAssigncounter.QueueNumber = row.Item("queuenumber")
                        isqueueCusomter.counter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.counter.Department = row.Item("department")
                        isqueueCusomter.counter.Section = row.Item("section")
                        isqueueCusomter.counter.ServiceDescription = row.Item("servicedescription")
                        isqueueCusomter.counter.CounterPrefix = row.Item("counterPrefix")
                        isqueueCusomter.counter.CounterCode = row.Item("countercode")
                        isqueueCusomter.counter.Icon = row.Item("icon")
                        isqueueCusomter.counter.isQueueingCounter = row.Item("isQueuingCounter")

                        Dim customerAsignCounterController As New CustomerAssignCounterController
                        isqueueCusomter.customerAssigncounter.Counter = isqueueCusomter.counter
                        isqueueCusomter.customerAssigncounter.ProcessedQueueNumber = customerAsignCounterController.GetProcessedQueueNumber(isqueueCusomter.customerAssigncounter)
                    Else
                        isqueueCusomter.servedCustomer = Nothing
                        isqueueCusomter.customerAssigncounter = Nothing
                        isqueueCusomter.counter = Nothing
                    End If
                    currentServingCustomer.Add(isqueueCusomter)
                Next
                Return currentServingCustomer
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllDepartmentResetQueue() As List(Of AllDeparmentCustomerInQueue)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT(a.counterboarditem_id), a.displayname, a.displayctr, b.counterPrefix, e.priority, '100' as 'queuenumber'
                                FROM dbo.counterboard AS a
                                LEFT JOIN wmmcqms.counter AS b ON b.counter_id = a.counter_id
                                LEFT JOIN dbo.counterboardtransaction AS c ON (c.counter_id = b.counter_id AND c.counterboarditem_id = a.counterboarditem_id) AND c.datetimelogged = (SELECT MAX(datetimelogged) FROM dbo.counterboardtransaction WHERE dbo.counterboardtransaction.counterboarditem_id = a.counterboarditem_id)
                                LEFT JOIN wmmcqms.servertransaction as d on d.servertransaction_id = c.servertransaction_id
                                LEFT JOIN wmmcqms.customerassigncounter as e on e.customerassigncounter_id = (SELECT CASE WHEN (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE datetimeservedstart IS NOT NULL AND servertransaction_id = d.servertransaction_id) IS NOT NULL THEN (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE datetimeservedstart IS NOT NULL AND servertransaction_id = d.servertransaction_id) ELSE (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE  servertransaction_id = d.servertransaction_id) END)
                                ORDER BY a.displayctr,displayname;"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim allQueueNumber As New List(Of AllDeparmentCustomerInQueue)
                For Each row As DataRow In data.Rows
                    Dim queueNumber As New AllDeparmentCustomerInQueue
                    queueNumber.CounterBoard_ID = row("counterboarditem_id")
                    queueNumber.DisplayName = row("displayname")
                    queueNumber.DisplayCounter = row("displayctr")
                    queueNumber.CounterPrefix = If(Not IsDBNull(row("counterPrefix")), row("counterPrefix"), "--")
                    queueNumber.Priority = If(Not IsDBNull(row("priority")), row("priority"), 0)
                    queueNumber.QueueNumber = If(Not IsDBNull(row("queuenumber")), row("queuenumber"), 100)
                    queueNumber.withNumber = If(Not IsDBNull(row("queuenumber")), True, False)
                    queueNumber.ProcessQueueNumber = Me.GetProcessedQueueNumber2(queueNumber)
                    allQueueNumber.Add(queueNumber)
                Next
                Return allQueueNumber
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetAllDepartmentServingQueue2() As List(Of AllDeparmentCustomerInQueue)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT DISTINCT(a.counterboarditem_id), a.displayname, a.displayctr, b.counterPrefix, e.priority, e.queuenumber as 'queuenumber'
                                FROM dbo.counterboard AS a
                                LEFT JOIN wmmcqms.counter AS b ON b.counter_id = a.counter_id
                                LEFT JOIN dbo.counterboardtransaction AS c ON (c.counter_id = b.counter_id AND c.counterboarditem_id = a.counterboarditem_id) AND c.datetimelogged = (SELECT MAX(datetimelogged) FROM dbo.counterboardtransaction WHERE dbo.counterboardtransaction.counterboarditem_id = a.counterboarditem_id)
                                LEFT JOIN wmmcqms.servertransaction as d on d.servertransaction_id = c.servertransaction_id
                                LEFT JOIN wmmcqms.customerassigncounter as e on e.customerassigncounter_id = (SELECT CASE WHEN (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE datetimeservedstart IS NOT NULL AND servertransaction_id = d.servertransaction_id) IS NOT NULL THEN (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE datetimeservedstart IS NOT NULL AND servertransaction_id = d.servertransaction_id) ELSE (SELECT MAX(customerassigncounter_id)  FROM wmmcqms.servedcustomer WHERE  servertransaction_id = d.servertransaction_id) END)
                                ORDER BY a.displayctr,displayname;"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim allQueueNumber As New List(Of AllDeparmentCustomerInQueue)
                For Each row As DataRow In data.Rows
                    Dim queueNumber As New AllDeparmentCustomerInQueue
                    queueNumber.CounterBoard_ID = row("counterboarditem_id")
                    queueNumber.DisplayName = row("displayname")
                    queueNumber.DisplayCounter = row("displayctr")
                    queueNumber.CounterPrefix = If(Not IsDBNull(row("counterPrefix")), row("counterPrefix"), "--")
                    queueNumber.Priority = If(Not IsDBNull(row("priority")), row("priority"), 0)
                    queueNumber.QueueNumber = If(Not IsDBNull(row("queuenumber")), row("queuenumber"), 100)
                    queueNumber.withNumber = If(Not IsDBNull(row("queuenumber")), True, False)
                    queueNumber.ProcessQueueNumber = Me.GetProcessedQueueNumber2(queueNumber)
                    allQueueNumber.Add(queueNumber)
                Next
                Return allQueueNumber
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetProcessedQueueNumber2(custommerAssignCounter As AllDeparmentCustomerInQueue) As String
        Dim numlen As Integer = custommerAssignCounter.QueueNumber.ToString.Length
        If numlen = 1 Then
            Return custommerAssignCounter.CounterPrefix + "-00" + custommerAssignCounter.QueueNumber.ToString
        ElseIf numlen = 2 Then
            Return custommerAssignCounter.CounterPrefix + "-0" + custommerAssignCounter.QueueNumber.ToString
        Else
            Return custommerAssignCounter.CounterPrefix + "-" + custommerAssignCounter.QueueNumber.ToString
        End If
    End Function


    Public Function GetCertainDepartmentServingQueue(counter As Counter) As List(Of GetServingCustomerOfServer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT x.*,d.*,a.*,b.*,c.* FROM wmmcqms.servedcustomer as a JOIN wmmcqms.customerassigncounter as b ON a.customerassigncounter_id = b.customerassigncounter_id AND CONVERT( DATE,b.datetimequeued) = CONVERT( DATE,GETDATE()) JOIN wmmcqms.counter as c ON b.counter_id = c.counter_id  RIGHT JOIN wmmcqms.servertransaction as x ON x.servertransaction_id = a.servertransaction_id AND a.datetimeservedend IS NULL AND datetimeservedstart IS NOT NULL JOIN wmmcqms.serverassigncounter as d ON x.serverassigncounter_id =  d.serverassigncounter_id AND d.counter_id = @ID WHERE CONVERT(DATE,datetimelogin) = CONVERT(DATE,GETDATE()) AND datetimelogout IS NULL ORDER BY countername ASC"
            cmd.Parameters.AddWithValue("@ID", counter.Counter_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim currentServingCustomer As New List(Of GetServingCustomerOfServer)
            If Not IsNothing(currentServingCustomer) Then
                For Each row As DataRow In data.Rows
                    Dim isqueueCusomter As New GetServingCustomerOfServer
                    isqueueCusomter.serverTransaction.ServerTransaction_ID = row.Item("servertransaction_id")
                    isqueueCusomter.serverTransaction.ServerAssignCounter_ID = row.Item("serverassigncounter_id")
                    isqueueCusomter.serverTransaction.CounterName = row.Item("countername")
                    isqueueCusomter.serverTransaction.DateTimeLogin = If(IsDBNull(row.Item("datetimelogin")), Nothing, row.Item("datetimelogin"))
                    isqueueCusomter.serverTransaction.DateTimeLogout = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                    If Not IsDBNull(row.Item("served_id")) Then
                        isqueueCusomter.servedCustomer.ServedCustomer_ID = row.Item("served_id")
                        isqueueCusomter.servedCustomer.ServerTransaction_ID = row.Item("servertransaction_id")
                        isqueueCusomter.servedCustomer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.servedCustomer.DateTimeStart = If(IsDBNull(row.Item("datetimeservedstart")), Nothing, row.Item("datetimeservedstart"))
                        isqueueCusomter.servedCustomer.DateTimeEnd = If(IsDBNull(row.Item("datetimelogout")), Nothing, row.Item("datetimelogout"))
                        isqueueCusomter.customerAssigncounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                        isqueueCusomter.customerAssigncounter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.customerAssigncounter.Customer_ID = row.Item("customer_id")
                        isqueueCusomter.customerAssigncounter.DateTimeQueued = row.Item("datetimequeued")
                        isqueueCusomter.customerAssigncounter.Priority = row.Item("priority")
                        isqueueCusomter.customerAssigncounter.QueueNumber = row.Item("queuenumber")
                        isqueueCusomter.counter.Counter_ID = row.Item("counter_id")
                        isqueueCusomter.counter.Department = row.Item("department")
                        isqueueCusomter.counter.Section = row.Item("section")
                        isqueueCusomter.counter.ServiceDescription = row.Item("servicedescription")
                        isqueueCusomter.counter.CounterPrefix = row.Item("counterPrefix")
                        isqueueCusomter.counter.CounterCode = row.Item("countercode")
                        isqueueCusomter.counter.Icon = row.Item("icon")
                        isqueueCusomter.counter.isQueueingCounter = row.Item("isQueuingCounter")

                        Dim customerAsignCounterController As New CustomerAssignCounterController
                        isqueueCusomter.customerAssigncounter.Counter = isqueueCusomter.counter
                        isqueueCusomter.customerAssigncounter.ProcessedQueueNumber = customerAsignCounterController.GetProcessedQueueNumber(isqueueCusomter.customerAssigncounter)
                    Else
                        isqueueCusomter.servedCustomer = Nothing
                        isqueueCusomter.customerAssigncounter = Nothing
                        isqueueCusomter.counter = Nothing
                    End If


                    currentServingCustomer.Add(isqueueCusomter)
                Next
                Return currentServingCustomer
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return Nothing
        End Try
    End Function

    Public Function UpdateSkippedCustomeraServetimeStart(servedCustomer As ServedCustomer) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.servedcustomer SET datetimeservedstart = CURRENT_TIMESTAMP, servertransaction_id = @SID WHERE served_id = @ID;"
            cmd.Parameters.AddWithValue("@ID", servedCustomer.ServedCustomer_ID)
            cmd.Parameters.AddWithValue("@SID", servedCustomer.ServerTransaction_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetSkippedCustomerByCounter(id As Long) As List(Of ServedCustomer)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from wmmcqms.servedcustomer as a, wmmcqms.customerassigncounter as b, wmmcqms.counter as c, wmmcqms.customer as d  where (a.customerassigncounter_id = b.customerassigncounter_id and b.counter_id = c.counter_id and b.customer_id = d.customer_id) AND (CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) AND a.datetimeservedstart  IS NULL) AND (c.counter_id = @ID) ORDER BY b.customerassigncounter_id DESC"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            Dim skippedCustomers As New List(Of ServedCustomer)

            For Each row As DataRow In data.Rows
                Dim customer As New ServedCustomer
                customer.ServedCustomer_ID = row.Item("served_id")
                customer.ServerTransaction_ID = row.Item("servertransaction_id")
                customer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                customer.CustomerAssginCounter_ID = row.Item("customerassigncounter_id")
                customer.CustomerAssignCounter.CustomerAssignCounter_ID = row.Item("customerassigncounter_id")
                customer.CustomerAssignCounter.Counter_ID = row.Item("counter_id")
                customer.CustomerAssignCounter.Customer_ID = row.Item("customer_id")
                customer.CustomerAssignCounter.DateTimeQueued = row.Item("datetimequeued")
                customer.CustomerAssignCounter.Result = row.Item("result")
                customer.CustomerAssignCounter.Priority = row.Item("priority")
                customer.CustomerAssignCounter.ForHelee = row.Item("forHelee")
                customer.CustomerAssignCounter.QueueNumber = row.Item("queuenumber")
                customer.CustomerAssignCounter.PaymentMethod = row.Item("paymentmethod")
                customer.CustomerAssignCounter.Notes = If(Not IsDBNull(row.Item("notes")), row.Item("notes"), Nothing)
                customer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(row.Item("notedepartment")), row.Item("notedepartment"), Nothing)
                customer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(row.Item("notesection")), row.Item("notesection"), Nothing)
                customer.CustomerAssignCounter.Counter.Counter_ID = row.Item("queuenumber")
                customer.CustomerAssignCounter.Counter.Department = row.Item("department")
                customer.CustomerAssignCounter.Counter.Section = row.Item("section")
                customer.CustomerAssignCounter.Counter.ServiceDescription = row.Item("servicedescription")
                customer.CustomerAssignCounter.Counter.CounterPrefix = row.Item("counterPrefix")
                customer.CustomerAssignCounter.Counter.CounterCode = row.Item("countercode")
                customer.CustomerAssignCounter.Counter.Icon = row.Item("icon")
                customer.CustomerAssignCounter.Counter.isQueueingCounter = row.Item("isQueuingCounter")
                Dim customerController As New CustomerController
                customer.CustomerAssignCounter.Customer = customerController.GetCertainCustomer(row.Item("customer_id"))
                Dim customerassginCounter As New CustomerAssignCounterController
                customer.CustomerAssignCounter.ProcessedQueueNumber = customerassginCounter.GetProcessedQueueNumber(customer.CustomerAssignCounter)
                skippedCustomers.Add(customer)
            Next
            Return skippedCustomers
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainSkippedCustomer(id As Long) As ServedCustomer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from wmmcqms.servedcustomer as a, wmmcqms.customerassigncounter as b, wmmcqms.counter as c, wmmcqms.customer as d  where (a.customerassigncounter_id = b.customerassigncounter_id and b.counter_id = c.counter_id and b.customer_id = d.customer_id) AND (CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE()) AND a.datetimeservedstart  IS NULL) AND (a.served_id = @ID) ORDER BY a.served_id DESC"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim customer As New ServedCustomer
                    customer.ServedCustomer_ID = data.Rows(0)("served_id")
                    customer.DateTimeStart = If(Not IsDBNull(data.Rows(0)("datetimeservedstart")), data.Rows(0)("datetimeservedstart"), Nothing)
                    customer.DateTimeEnd = If(Not IsDBNull(data.Rows(0)("datetimeservedend")), data.Rows(0)("datetimeservedend"), Nothing)
                    customer.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    customer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssignCounter.CustomerAssignCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    customer.CustomerAssignCounter.Customer_ID = data.Rows(0)("customer_id")
                    customer.CustomerAssignCounter.DateTimeQueued = data.Rows(0)("datetimequeued")
                    customer.CustomerAssignCounter.Result = data.Rows(0)("result")
                    customer.CustomerAssignCounter.Priority = data.Rows(0)("priority")
                    customer.CustomerAssignCounter.QueueNumber = data.Rows(0)("queuenumber")
                    customer.CustomerAssignCounter.PaymentMethod = data.Rows(0)("paymentmethod")
                    customer.CustomerAssignCounter.Notes = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    customer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(data.Rows(0)("notedepartment")), data.Rows(0)("notedepartment"), Nothing)
                    customer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(data.Rows(0)("notesection")), data.Rows(0)("notesection"), Nothing)
                    customer.CustomerAssignCounter.Counter.Counter_ID = data.Rows(0)("queuenumber")
                    customer.CustomerAssignCounter.Counter.Department = data.Rows(0)("department")
                    customer.CustomerAssignCounter.Counter.Section = data.Rows(0)("section")
                    customer.CustomerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                    customer.CustomerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                    customer.CustomerAssignCounter.Counter.CounterCode = data.Rows(0)("countercode")
                    customer.CustomerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                    customer.CustomerAssignCounter.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                    Dim customerController As New CustomerController
                    customer.CustomerAssignCounter.Customer = customerController.GetCertainCustomer(data.Rows(0)("customer_id"))
                    Dim customerassginCounter As New CustomerAssignCounterController
                    customer.CustomerAssignCounter.ProcessedQueueNumber = customerassginCounter.GetProcessedQueueNumber(customer.CustomerAssignCounter)
                    Return customer
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatient_AdditionalData(id As Long) As ServedCustomer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from wmmcqms.servedcustomer as a, wmmcqms.customerassigncounter as b, wmmcqms.counter as c, wmmcqms.customer as d  where (a.customerassigncounter_id = b.customerassigncounter_id and b.counter_id = c.counter_id and b.customer_id = d.customer_id) AND (CONVERT(DATE,b.datetimequeued) = CONVERT(DATE,GETDATE())) AND (a.served_id = @ID) ORDER BY a.served_id DESC"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim customer As New ServedCustomer
                    customer.ServedCustomer_ID = data.Rows(0)("served_id")
                    customer.DateTimeStart = If(Not IsDBNull(data.Rows(0)("datetimeservedstart")), data.Rows(0)("datetimeservedstart"), Nothing)
                    customer.DateTimeEnd = If(Not IsDBNull(data.Rows(0)("datetimeservedend")), data.Rows(0)("datetimeservedend"), Nothing)
                    customer.ServedCustomer_ID = data.Rows(0)("served_id")
                    customer.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    customer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssginCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssignCounter.CustomerAssignCounter_ID = data.Rows(0)("customerassigncounter_id")
                    customer.CustomerAssignCounter.Counter_ID = data.Rows(0)("counter_id")
                    customer.CustomerAssignCounter.Customer_ID = data.Rows(0)("customer_id")
                    customer.CustomerAssignCounter.DateTimeQueued = data.Rows(0)("datetimequeued")
                    customer.CustomerAssignCounter.Result = data.Rows(0)("result")
                    customer.CustomerAssignCounter.Priority = data.Rows(0)("priority")
                    customer.CustomerAssignCounter.QueueNumber = data.Rows(0)("queuenumber")
                    customer.CustomerAssignCounter.PaymentMethod = data.Rows(0)("paymentmethod")
                    customer.CustomerAssignCounter.Notes = If(Not IsDBNull(data.Rows(0)("notes")), data.Rows(0)("notes"), Nothing)
                    customer.CustomerAssignCounter.NoteDepartment = If(Not IsDBNull(data.Rows(0)("notedepartment")), data.Rows(0)("notedepartment"), Nothing)
                    customer.CustomerAssignCounter.NoteSection = If(Not IsDBNull(data.Rows(0)("notesection")), data.Rows(0)("notesection"), Nothing)
                    customer.CustomerAssignCounter.Counter.Counter_ID = data.Rows(0)("queuenumber")
                    customer.CustomerAssignCounter.Counter.Department = data.Rows(0)("department")
                    customer.CustomerAssignCounter.Counter.Section = data.Rows(0)("section")
                    customer.CustomerAssignCounter.Counter.ServiceDescription = data.Rows(0)("servicedescription")
                    customer.CustomerAssignCounter.Counter.CounterPrefix = data.Rows(0)("counterPrefix")
                    customer.CustomerAssignCounter.Counter.CounterCode = data.Rows(0)("countercode")
                    customer.CustomerAssignCounter.Counter.Icon = data.Rows(0)("icon")
                    customer.CustomerAssignCounter.Counter.isQueueingCounter = data.Rows(0)("isQueuingCounter")
                    Dim customerController As New CustomerController
                    customer.CustomerAssignCounter.Customer = customerController.GetCertainCustomer(data.Rows(0)("customer_id"))
                    Dim customerassginCounter As New CustomerAssignCounterController
                    customer.CustomerAssignCounter.ProcessedQueueNumber = customerassginCounter.GetProcessedQueueNumber(customer.CustomerAssignCounter)
                    Return customer
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function
End Class
