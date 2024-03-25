Imports System.Data.SqlClient
Public Class ServerController
    Public Function GetDoctorInfo(ByVal prc As String) As Server
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT *  FROM wmmcqms.server where prc = @prc"
            }
            cmd.Parameters.AddWithValue("@prc", prc)
            Dim table As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (table.Rows.Count > 0) Then
                Dim server As New Server
                server.Server_ID = (table.Rows(0)("server_id"))
                server.EmmployeeID = (table.Rows(0)("employee_id"))
                server.FullName = (table.Rows(0)("fullname"))
                server.FirstName = (If(Not Information.IsDBNull((table.Rows(0)("firstname"))), table.Rows(0)("firstname"), ""))
                server.MiddleName = (If(Not Information.IsDBNull((table.Rows(0)("middlename"))), table.Rows(0)("middlename"), ""))
                server.LastName = (If(Not Information.IsDBNull((table.Rows(0)("lastname"))), table.Rows(0)("lastname"), ""))
                server.AssignDepartment = (table.Rows(0)("assigndepartment"))
                server.Specialization = (If(Not Information.IsDBNull((table.Rows(0)("specializaton"))), table.Rows(0)("specializaton"), ""))
                server.PRC = (If(Not Information.IsDBNull((table.Rows(0)("prc"))), table.Rows(0)("prc"), ""))
                server.PTR = (If(Not Information.IsDBNull((table.Rows(0)("ptr"))), table.Rows(0)("ptr"), ""))
                server.S2No = (If(Not Information.IsDBNull((table.Rows(0)("s2"))), table.Rows(0)("s2"), ""))
                server.SignatureLocation = (If(Not Information.IsDBNull((table.Rows(0)("digitalSignature"))), table.Rows(0)("digitalSignature"), ""))
                server.PhysicianID = (If(Not Information.IsDBNull((table.Rows(0)("physician_id"))), table.Rows(0)("physician_id"), ""))
                server.AccountType = (table.Rows(0)("accountType"))
                server.Username = (table.Rows(0)("username"))
                server.Pasaword = (table.Rows(0)("password"))
                server.ServerAssignCounter = New ServerAssignCounterController().GetServerAssignCounterOfCertainServer(server)
                Return server
            End If
            Return Nothing
        Catch exception As SqlException
            Return Nothing
        End Try
    End Function

    Public Function GetAllServers() As List(Of Server)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.*, (SELECT COUNT(serverassigncounter_ID) from wmmcqms.serverassigncounter as x, wmmcqms.counter as y WHERE (x.counter_id = y.counter_id) and server_id = a.server_id) as 'assinedcounter' FROM wmmcqms.server as a"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim Servers As New List(Of Server)
                For Each row As DataRow In data.Rows
                    Dim server As New Server
                    server.Server_ID = row.Item("server_id")
                    server.EmmployeeID = row.Item("employee_id")
                    server.FullName = row.Item("fullname")
                    server.AssignDepartment = row.Item("assigndepartment")
                    server.Username = row.Item("username")
                    server.Pasaword = row.Item("password")
                    server.CounterAssignNumber = row.Item("assinedcounter")
                    server.AccountType = row.Item("accountType")
                    Servers.Add(server)
                Next
                Return Servers
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function LoginReturnUserInformation(loginInfo As Server) As Server
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[server] where [username] = @username and [password] = @password;"
            cmd.Parameters.AddWithValue("@username", loginInfo.Username)
            cmd.Parameters.AddWithValue("@password", loginInfo.Pasaword)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim server As New Server
                server.Server_ID = data.Rows(0).Item("server_id")
                server.EmmployeeID = data.Rows(0).Item("employee_id")
                server.FullName = data.Rows(0).Item("fullname")
                server.FirstName = If(Not IsDBNull(data.Rows(0).Item("firstname")), data.Rows(0).Item("firstname"), "")
                server.MiddleName = If(Not IsDBNull(data.Rows(0).Item("middlename")), data.Rows(0).Item("middlename"), "")
                server.LastName = If(Not IsDBNull(data.Rows(0).Item("lastname")), data.Rows(0).Item("lastname"), "")
                server.AssignDepartment = data.Rows(0).Item("assigndepartment")
                server.Specialization = If(Not IsDBNull(data.Rows(0).Item("specializaton")), data.Rows(0).Item("specializaton"), "")
                server.PRC = If(Not IsDBNull(data.Rows(0).Item("prc")), data.Rows(0).Item("prc"), "")
                server.PTR = If(Not IsDBNull(data.Rows(0).Item("ptr")), data.Rows(0).Item("ptr"), "")
                server.S2No = If(Not IsDBNull(data.Rows(0).Item("s2")), data.Rows(0).Item("s2"), "")
                server.PhysicianID = If(Not IsDBNull(data.Rows(0).Item("physician_id")), data.Rows(0).Item("physician_id"), "")
                server.AccountType = data.Rows(0).Item("accountType")
                server.Username = data.Rows(0).Item("username")
                server.Pasaword = data.Rows(0).Item("password")
                Dim serverAssignCounterController As New ServerAssignCounterController
                server.ServerAssignCounter = serverAssignCounterController.GetServerAssignCounterOfCertainServer(server)
                Return server
            End If
            Return Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServer(id As Long) As Server
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *  FROM wmmcqms.server where server_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim server As New Server
                server.Server_ID = data.Rows(0).Item("server_id")
                server.EmmployeeID = data.Rows(0).Item("employee_id")
                server.FullName = data.Rows(0).Item("fullname")
                server.FirstName = If(Not IsDBNull(data.Rows(0).Item("firstname")), data.Rows(0).Item("firstname"), "")
                server.MiddleName = If(Not IsDBNull(data.Rows(0).Item("middlename")), data.Rows(0).Item("middlename"), "")
                server.LastName = If(Not IsDBNull(data.Rows(0).Item("lastname")), data.Rows(0).Item("lastname"), "")
                server.AssignDepartment = data.Rows(0).Item("assigndepartment")
                server.Specialization = If(Not IsDBNull(data.Rows(0).Item("specializaton")), data.Rows(0).Item("specializaton"), "")
                server.PRC = If(Not IsDBNull(data.Rows(0).Item("prc")), data.Rows(0).Item("prc"), "")
                server.PTR = If(Not IsDBNull(data.Rows(0).Item("ptr")), data.Rows(0).Item("ptr"), "")
                server.S2No = If(Not IsDBNull(data.Rows(0).Item("s2")), data.Rows(0).Item("s2"), "")
                'server.PrimaryContactNo = If(Not IsDBNull(data.Rows(0).Item("primarycontact")), data.Rows(0).Item("primarycontact"), "")
                'server.SecondaryContactNo = If(Not IsDBNull(data.Rows(0).Item("secondarycontact")), data.Rows(0).Item("secondarycontact"), "")
                server.PhysicianID = If(Not IsDBNull(data.Rows(0).Item("physician_id")), data.Rows(0).Item("physician_id"), "")
                server.AccountType = data.Rows(0).Item("accountType")
                server.Username = data.Rows(0).Item("username")
                server.Pasaword = data.Rows(0).Item("password")
                Dim serverAssignCounterController As New ServerAssignCounterController
                server.ServerAssignCounter = serverAssignCounterController.GetServerAssignCounterOfCertainServer(server)
                Return server
            End If
            Return Nothing
        Catch ex As SqlException
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function DeleteMultipleServer(ids As List(Of Long)) As Boolean
        Try
            Dim cmds As New List(Of SqlCommand)
            For Each id As Long In ids
                Dim cmd As New SqlCommand
                cmd.CommandText = "DELETE FROM wmmcqms.server WHERE server_id = @ID"
                cmd.Parameters.AddWithValue("@ID", id)
                cmds.Add(cmd)
            Next
            Return excecuteMultipleCommand(cmds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function DeleteServer(id As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM wmmcqms.server  WHERE server_id = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function NewDoctorAccount(mabAccount As ServerAssignCounter) As Boolean
        Try
            If IfExistUsername(mabAccount.Server.Username) Then
                MessageBox.Show("User name already exist. Please use different user name", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            Dim cmdDoctor As New SqlCommand
            cmdDoctor.CommandText = "INSERT INTO [wmmcqms].[server] ([employee_id],[fullname],[assigndepartment],[username],[password],[firstname],[middlename],[lastname],[specializaton],[ptr],[prc],[physician_id],[accountType]) VALUES (@empid,@name,@dept,@uname,@pass,@fname,@mname,@lname,@spl,@ptr,@prc,@phys,@acctype); SELECT @@IDENTITY;"
            cmdDoctor.Parameters.AddWithValue("@empid", mabAccount.Server.EmmployeeID)
            cmdDoctor.Parameters.AddWithValue("@name", mabAccount.Server.FullName)
            cmdDoctor.Parameters.AddWithValue("@dept", mabAccount.Server.AssignDepartment)
            cmdDoctor.Parameters.AddWithValue("@uname", mabAccount.Server.Username)
            cmdDoctor.Parameters.AddWithValue("@pass", mabAccount.Server.Pasaword)
            cmdDoctor.Parameters.AddWithValue("@fname", mabAccount.Server.FirstName)
            cmdDoctor.Parameters.AddWithValue("@mname", mabAccount.Server.MiddleName)
            cmdDoctor.Parameters.AddWithValue("@lname", mabAccount.Server.LastName)
            cmdDoctor.Parameters.AddWithValue("@spl", If(Not IsNothing(mabAccount.Server.Specialization), mabAccount.Server.Specialization, ""))
            cmdDoctor.Parameters.AddWithValue("@ptr", If(Not IsNothing(mabAccount.Server.PTR), mabAccount.Server.PTR, ""))
            cmdDoctor.Parameters.AddWithValue("@prc", If(Not IsNothing(mabAccount.Server.PRC), mabAccount.Server.PRC, ""))
            cmdDoctor.Parameters.AddWithValue("@phys", If(Not IsNothing(mabAccount.Server.PhysicianID), mabAccount.Server.PhysicianID, ""))
            cmdDoctor.Parameters.AddWithValue("@acctype", mabAccount.Server.AccountType)
            Dim doctorsID As Long = excecuteCommandReturnID(cmdDoctor)
            If doctorsID > 0 Then
                Dim cmdClinic As New SqlCommand
                cmdClinic.CommandText = "INSERT INTO [wmmcqms].[counter] (department, section, servicedescription, counterPrefix, countercode, icon, isQueuingCounter,counterType,allowableTurnaroundTime ,[consultationView] ,[consultationAddEdit] ,[diagnosticView] ,[diagnosticAddEdit] ,[eprescirptionView] ,[eprescirptionAddEdit] ,[syncDetail],[canEKonsulta]) VALUES (@dept,@sec,@desc,@pre,@cod,@ico,@flag,@ctype,@tat,@conVw,@conAe,@diaVw,@diaAe,@epreVw,@epreAe,@sncInf,@eKonsult); SELECT @@IDENTITY;"
                cmdClinic.Parameters.AddWithValue("@dept", mabAccount.Counter.Department)
                cmdClinic.Parameters.AddWithValue("@sec", mabAccount.Counter.Section)
                cmdClinic.Parameters.AddWithValue("@desc", mabAccount.Counter.ServiceDescription)
                cmdClinic.Parameters.AddWithValue("@pre", mabAccount.Counter.CounterPrefix)
                cmdClinic.Parameters.AddWithValue("@cod", mabAccount.Counter.CounterCode)
                cmdClinic.Parameters.AddWithValue("@ico", mabAccount.Counter.Icon)
                cmdClinic.Parameters.AddWithValue("@flag", If(Not mabAccount.Counter.showOnMainCounter, 2, mabAccount.Counter.isQueueingCounter))
                cmdClinic.Parameters.AddWithValue("@ctype", mabAccount.Counter.CounterType)
                cmdClinic.Parameters.AddWithValue("@tat", mabAccount.Counter.allowedTurnaroundTime)
                cmdClinic.Parameters.AddWithValue("@conVw", mabAccount.Counter.consultationView)
                cmdClinic.Parameters.AddWithValue("@conAe", mabAccount.Counter.consultationAddEdit)
                cmdClinic.Parameters.AddWithValue("@diaVw", mabAccount.Counter.diagnosticView)
                cmdClinic.Parameters.AddWithValue("@diaAe", mabAccount.Counter.diagnosticAddEdit)
                cmdClinic.Parameters.AddWithValue("@epreVw", mabAccount.Counter.eprescriptionView)
                cmdClinic.Parameters.AddWithValue("@epreAe", mabAccount.Counter.eprescriptionAddEdit)
                cmdClinic.Parameters.AddWithValue("@sncInf", mabAccount.Counter.SyncDetail)
                cmdClinic.Parameters.AddWithValue("@eKonsult", mabAccount.Counter.canEKonsulta)
                Dim clinicID As Long = excecuteCommandReturnID(cmdClinic)
                If clinicID > 0 Then
                    Dim serverAssignCounter As New ServerAssignCounter
                    serverAssignCounter.Server_ID = doctorsID
                    serverAssignCounter.Counter_ID = clinicID
                    serverAssignCounter.isMain = False
                    Dim cmd As New SqlCommand
                    cmd.CommandText = "INSERT INTO wmmcqms.serverassigncounter (server_id, counter_id, isMain) VALUES (@serverid,@counterid,@ismain)"
                    cmd.Parameters.AddWithValue("@serverid", serverAssignCounter.Server_ID)
                    cmd.Parameters.AddWithValue("@counterid", serverAssignCounter.Counter_ID)
                    cmd.Parameters.AddWithValue("@ismain", serverAssignCounter.isMain)
                    Return excecuteCommand(cmd)
                End If
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function UpdateServer2(mabAccount As ServerAssignCounter) As Boolean
        Try
            If mabAccount.Counter.Counter_ID > 0 Then 'IF USER HAS ALREADY ASSIGNED CLINIC
                Dim CMDs As New List(Of SqlCommand)
                Dim cmdDoctor As New SqlCommand
                cmdDoctor.CommandText = "UPDATE wmmcqms.server SET employee_id=@empid,fullname=@name,assigndepartment=@dept,username=@uname,password=@pass,firstname=@fname,middlename=@mname,lastname=@lname,specializaton=@spl,ptr=@ptr,prc=@prc,physician_id=@phys,accountType=@acctype WHERE server_id = @ID"
                cmdDoctor.Parameters.AddWithValue("@empid", mabAccount.Server.EmmployeeID)
                cmdDoctor.Parameters.AddWithValue("@name", mabAccount.Server.FullName)
                cmdDoctor.Parameters.AddWithValue("@dept", mabAccount.Server.AssignDepartment)
                cmdDoctor.Parameters.AddWithValue("@uname", mabAccount.Server.Username)
                cmdDoctor.Parameters.AddWithValue("@pass", mabAccount.Server.Pasaword)
                cmdDoctor.Parameters.AddWithValue("@fname", mabAccount.Server.FirstName)
                cmdDoctor.Parameters.AddWithValue("@mname", mabAccount.Server.MiddleName)
                cmdDoctor.Parameters.AddWithValue("@lname", mabAccount.Server.LastName)
                cmdDoctor.Parameters.AddWithValue("@spl", If(Not IsNothing(mabAccount.Server.Specialization), mabAccount.Server.Specialization, ""))
                cmdDoctor.Parameters.AddWithValue("@ptr", If(Not IsNothing(mabAccount.Server.PTR), mabAccount.Server.PTR, ""))
                cmdDoctor.Parameters.AddWithValue("@prc", If(Not IsNothing(mabAccount.Server.PRC), mabAccount.Server.PRC, ""))
                cmdDoctor.Parameters.AddWithValue("@phys", If(Not IsNothing(mabAccount.Server.PhysicianID), mabAccount.Server.PhysicianID, ""))
                cmdDoctor.Parameters.AddWithValue("@acctype", mabAccount.Server.AccountType)
                cmdDoctor.Parameters.AddWithValue("@ID", mabAccount.Server.Server_ID)
                CMDs.Add(cmdDoctor)
                Dim cmdClinic As New SqlCommand
                cmdClinic.CommandText = "UPDATE [wmmcqms].[counter] SET [department] = @dept, [isQueuingCounter] = @flag, [section] = @sec, [servicedescription] = @desc, [counterPrefix] = @pre, [counterType] = @ctype, [canEKonsulta] = @eKonsult WHERE counter_id = @ID"
                cmdClinic.Parameters.AddWithValue("@dept", mabAccount.Counter.Department)
                cmdClinic.Parameters.AddWithValue("@sec", mabAccount.Counter.Section)
                cmdClinic.Parameters.AddWithValue("@desc", mabAccount.Counter.ServiceDescription)
                cmdClinic.Parameters.AddWithValue("@pre", mabAccount.Counter.CounterPrefix)
                cmdClinic.Parameters.AddWithValue("@ctype", mabAccount.Counter.CounterType)
                cmdClinic.Parameters.AddWithValue("@eKonsult", mabAccount.Counter.canEKonsulta)
                cmdClinic.Parameters.AddWithValue("@flag", If(Not mabAccount.Counter.showOnMainCounter, 2, mabAccount.Counter.isQueueingCounter))
                cmdClinic.Parameters.AddWithValue("@ID", mabAccount.Counter.Counter_ID)
                CMDs.Add(cmdClinic)
                Return excecuteMultipleCommand(CMDs)
            Else 'IF USER DON'T HAVE EXISTING ASSIGNED CLINIC
                Dim cmdDoctor As New SqlCommand
                cmdDoctor.CommandText = "UPDATE wmmcqms.server SET employee_id=@empid,fullname=@name,assigndepartment=@dept,username=@uname,password=@pass,firstname=@fname,middlename=@mname,lastname=@lname,specializaton=@spl,ptr=@ptr,prc=@prc,physician_id=@phys,accountType=@acctype WHERE server_id = @ID"
                cmdDoctor.Parameters.AddWithValue("@empid", mabAccount.Server.EmmployeeID)
                cmdDoctor.Parameters.AddWithValue("@name", mabAccount.Server.FullName)
                cmdDoctor.Parameters.AddWithValue("@dept", mabAccount.Server.AssignDepartment)
                cmdDoctor.Parameters.AddWithValue("@uname", mabAccount.Server.Username)
                cmdDoctor.Parameters.AddWithValue("@pass", mabAccount.Server.Pasaword)
                cmdDoctor.Parameters.AddWithValue("@fname", mabAccount.Server.FirstName)
                cmdDoctor.Parameters.AddWithValue("@mname", mabAccount.Server.MiddleName)
                cmdDoctor.Parameters.AddWithValue("@lname", mabAccount.Server.LastName)
                cmdDoctor.Parameters.AddWithValue("@spl", If(Not IsNothing(mabAccount.Server.Specialization), mabAccount.Server.Specialization, ""))
                cmdDoctor.Parameters.AddWithValue("@ptr", If(Not IsNothing(mabAccount.Server.PTR), mabAccount.Server.PTR, ""))
                cmdDoctor.Parameters.AddWithValue("@prc", If(Not IsNothing(mabAccount.Server.PRC), mabAccount.Server.PRC, ""))
                cmdDoctor.Parameters.AddWithValue("@phys", If(Not IsNothing(mabAccount.Server.PhysicianID), mabAccount.Server.PhysicianID, ""))
                cmdDoctor.Parameters.AddWithValue("@acctype", mabAccount.Server.AccountType)
                cmdDoctor.Parameters.AddWithValue("@ID", mabAccount.Server.Server_ID)
                If excecuteCommand(cmdDoctor) Then
                    Dim cmdClinic As New SqlCommand
                    cmdClinic.CommandText = "INSERT INTO [wmmcqms].[counter] (department, section, servicedescription, counterPrefix, countercode, icon, isQueuingCounter,counterType,allowableTurnaroundTime ,[consultationView] ,[consultationAddEdit] ,[diagnosticView] ,[diagnosticAddEdit] ,[eprescirptionView] ,[eprescirptionAddEdit] ,[syncDetail] ,[canEKonsulta]) VALUES (@dept,@sec,@desc,@pre,@cod,@ico,@flag,@ctype,@tat,@conVw,@conAe,@diaVw,@diaAe,@epreVw,@epreAe,@sncInf,@eKonsult); SELECT @@IDENTITY;"
                    cmdClinic.Parameters.AddWithValue("@dept", mabAccount.Counter.Department)
                    cmdClinic.Parameters.AddWithValue("@sec", mabAccount.Counter.Section)
                    cmdClinic.Parameters.AddWithValue("@desc", mabAccount.Counter.ServiceDescription)
                    cmdClinic.Parameters.AddWithValue("@pre", mabAccount.Counter.CounterPrefix)
                    cmdClinic.Parameters.AddWithValue("@cod", mabAccount.Counter.CounterCode)
                    cmdClinic.Parameters.AddWithValue("@ico", mabAccount.Counter.Icon)
                    cmdClinic.Parameters.AddWithValue("@flag", If(Not mabAccount.Counter.showOnMainCounter, 2, mabAccount.Counter.isQueueingCounter))
                    cmdClinic.Parameters.AddWithValue("@ctype", mabAccount.Counter.CounterType)
                    cmdClinic.Parameters.AddWithValue("@tat", mabAccount.Counter.allowedTurnaroundTime)
                    cmdClinic.Parameters.AddWithValue("@conVw", mabAccount.Counter.consultationView)
                    cmdClinic.Parameters.AddWithValue("@conAe", mabAccount.Counter.consultationAddEdit)
                    cmdClinic.Parameters.AddWithValue("@diaVw", mabAccount.Counter.diagnosticView)
                    cmdClinic.Parameters.AddWithValue("@diaAe", mabAccount.Counter.diagnosticAddEdit)
                    cmdClinic.Parameters.AddWithValue("@epreVw", mabAccount.Counter.eprescriptionView)
                    cmdClinic.Parameters.AddWithValue("@epreAe", mabAccount.Counter.eprescriptionAddEdit)
                    cmdClinic.Parameters.AddWithValue("@sncInf", mabAccount.Counter.SyncDetail)
                    cmdClinic.Parameters.AddWithValue("@eKonsult", mabAccount.Counter.canEKonsulta)
                    Dim clinicID As Long = excecuteCommandReturnID(cmdClinic)
                    If clinicID > 0 Then
                        Dim serverAssignCounter As New ServerAssignCounter
                        serverAssignCounter.Server_ID = mabAccount.Server.Server_ID
                        serverAssignCounter.Counter_ID = clinicID
                        serverAssignCounter.isMain = False
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "INSERT INTO wmmcqms.serverassigncounter (server_id, counter_id, isMain) VALUES (@serverid,@counterid,@ismain)"
                        cmd.Parameters.AddWithValue("@serverid", serverAssignCounter.Server_ID)
                        cmd.Parameters.AddWithValue("@counterid", serverAssignCounter.Counter_ID)
                        cmd.Parameters.AddWithValue("@ismain", serverAssignCounter.isMain)
                        Return excecuteCommand(cmd)
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function NewServer(server As Server) As Boolean
        Try
            If IfExistUsername(server.Username) Then
                MessageBox.Show("User name already exist. Please use different user name", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [wmmcqms].[server] ([employee_id],[fullname],[assigndepartment],[username],[password],[firstname],[middlename],[lastname],[specializaton],[ptr],[prc],[physician_id],[accountType],[s2]
                                --,[primarycontact],
                                --[secondarycontact]
                               ) VALUES (@empid,@name,@dept,@uname,@pass,@fname,@mname,@lname,@spl,@ptr,@prc,@phys,@acctype,@s2
							   --,@primcontact,
                               --@seccontact
                               )"
            cmd.Parameters.AddWithValue("@empid", server.EmmployeeID)
            cmd.Parameters.AddWithValue("@name", server.FullName)
            cmd.Parameters.AddWithValue("@dept", server.AssignDepartment)
            cmd.Parameters.AddWithValue("@uname", server.Username)
            cmd.Parameters.AddWithValue("@pass", server.Pasaword)
            cmd.Parameters.AddWithValue("@fname", server.FirstName)
            cmd.Parameters.AddWithValue("@mname", server.MiddleName)
            cmd.Parameters.AddWithValue("@lname", server.LastName)
            cmd.Parameters.AddWithValue("@spl", If(Not IsNothing(server.Specialization), server.Specialization, ""))
            cmd.Parameters.AddWithValue("@prc", If(Not IsNothing(server.PRC), server.PRC, ""))
            cmd.Parameters.AddWithValue("@ptr", If(Not IsNothing(server.PTR), server.PTR, ""))
            cmd.Parameters.AddWithValue("@s2", If(Not IsNothing(server.S2No), server.S2No, ""))
            'cmd.Parameters.AddWithValue("@primcontact", If(Not IsNothing(server.PrimaryContactNo), server.PrimaryContactNo, ""))
            'cmd.Parameters.AddWithValue("@seccontact", If(Not IsNothing(server.SecondaryContactNo), server.SecondaryContactNo, ""))
            cmd.Parameters.AddWithValue("@phys", If(Not IsNothing(server.PhysicianID), server.PhysicianID, ""))
            cmd.Parameters.AddWithValue("@acctype", server.AccountType)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function UpdateServer(server As Server) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.server 
                                SET employee_id=@empid,fullname=@name,assigndepartment=@dept,username=@uname,password=@pass,firstname=@fname,middlename=@mname,lastname=@lname,specializaton=@spl,ptr=@ptr,prc=@prc,physician_id=@phys,accountType=@acctype,s2=@s2
							    --,primarycontact=@primcontact,
                                --secondarycontact=@seccontact 
                               WHERE server_id = @ID"
            cmd.Parameters.AddWithValue("@empid", server.EmmployeeID)
            cmd.Parameters.AddWithValue("@name", server.FullName)
            cmd.Parameters.AddWithValue("@dept", server.AssignDepartment)
            cmd.Parameters.AddWithValue("@uname", server.Username)
            cmd.Parameters.AddWithValue("@pass", server.Pasaword)
            cmd.Parameters.AddWithValue("@fname", server.FirstName)
            cmd.Parameters.AddWithValue("@mname", server.MiddleName)
            cmd.Parameters.AddWithValue("@lname", server.LastName)
            cmd.Parameters.AddWithValue("@spl", If(Not IsNothing(server.Specialization), server.Specialization, ""))
            cmd.Parameters.AddWithValue("@prc", If(Not IsNothing(server.PRC), server.PRC, ""))
            cmd.Parameters.AddWithValue("@ptr", If(Not IsNothing(server.PTR), server.PTR, ""))
            cmd.Parameters.AddWithValue("@s2", If(Not IsNothing(server.S2No), server.S2No, ""))
            'cmd.Parameters.AddWithValue("@primcontact", If(Not IsNothing(server.PrimaryContactNo), server.PrimaryContactNo, ""))
            'cmd.Parameters.AddWithValue("@seccontact", If(Not IsNothing(server.SecondaryContactNo), server.SecondaryContactNo, ""))
            cmd.Parameters.AddWithValue("@phys", If(Not IsNothing(server.PhysicianID), server.PhysicianID, ""))
            cmd.Parameters.AddWithValue("@acctype", server.AccountType)
            cmd.Parameters.AddWithValue("@ID", server.Server_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function ChangePassword(server As Server) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE wmmcqms.server SET password=@pass WHERE server_id = @ID"
            cmd.Parameters.AddWithValue("@pass", server.Pasaword)
            cmd.Parameters.AddWithValue("@ID", server.Server_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Private Function IfExistUsername(username As String) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[server] where [username] = @username"
            cmd.Parameters.AddWithValue("@username", username)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
