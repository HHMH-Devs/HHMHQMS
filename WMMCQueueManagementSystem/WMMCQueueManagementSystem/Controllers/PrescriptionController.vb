Imports System.Data
Imports System.Data.SqlClient

Public Class PrescriptionController

    Public Function NewPrescriptions(prescribedMeds As List(Of Prescription), sendToMedExpress As Boolean) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            For Each medItem As Prescription In prescribedMeds
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[customerprescription] ([productcode] ,[productdescription] ,[genericname] ,[qty] ,[instruction] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime] ,[FK_emdPatients] ,[servertransaction_id], [info_id]) VALUES (@prodcode, @proddesc, @genname, @qty, @inst, @bb, @bl, @bd, @ab, @al, @ad, @atbt, @fkid, @stid, @inid);"
                cmd.Parameters.AddWithValue("@prodcode", medItem.ProductCode)
                cmd.Parameters.AddWithValue("@proddesc", medItem.ProductDescription)
                cmd.Parameters.AddWithValue("@genname", medItem.GenericName)
                cmd.Parameters.AddWithValue("@qty", medItem.Qty)
                cmd.Parameters.AddWithValue("@inst", medItem.Instruction)
                cmd.Parameters.AddWithValue("@bb", medItem.BeforeBreakfast)
                cmd.Parameters.AddWithValue("@bl", medItem.BeforeLunch)
                cmd.Parameters.AddWithValue("@bd", medItem.BeforeDinner)
                cmd.Parameters.AddWithValue("@ab", medItem.AfterBreakfast)
                cmd.Parameters.AddWithValue("@al", medItem.AfterLunch)
                cmd.Parameters.AddWithValue("@ad", medItem.AfterDinner)
                cmd.Parameters.AddWithValue("@atbt", medItem.AtBedTime)
                cmd.Parameters.AddWithValue("@fkid", medItem.FK_emdPatients)
                cmd.Parameters.AddWithValue("@stid", medItem.ServerTransaction_ID)
                cmd.Parameters.AddWithValue("@inid", medItem.Info_ID)
                CMDs.Add(cmd)
            Next
            If excecuteMultipleCommand(CMDs) Then
                If sendToMedExpress Then
                    Return Me.SendPrescribeMedsToMedExpress(prescribedMeds)
                Else
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function NewPrescription(prescribedMeds As Prescription) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[customerprescription] ([productcode] ,[productdescription] ,[genericname] ,[qty] ,[instruction] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime] ,[FK_emdPatients] ,[servertransaction_id], [info_id]) VALUES (@prodcode, @proddesc, @genname, @qty, @inst, @bb, @bl, @bd, @ab, @al, @ad, @atbt, @fkid, @stid, @inid);"
            cmd.Parameters.AddWithValue("@prodcode", prescribedMeds.ProductCode)
            cmd.Parameters.AddWithValue("@proddesc", prescribedMeds.ProductDescription)
            cmd.Parameters.AddWithValue("@genname", prescribedMeds.GenericName)
            cmd.Parameters.AddWithValue("@qty", prescribedMeds.Qty)
            cmd.Parameters.AddWithValue("@inst", prescribedMeds.Instruction)
            cmd.Parameters.AddWithValue("@bb", prescribedMeds.BeforeBreakfast)
            cmd.Parameters.AddWithValue("@bl", prescribedMeds.BeforeLunch)
            cmd.Parameters.AddWithValue("@bd", prescribedMeds.BeforeDinner)
            cmd.Parameters.AddWithValue("@ab", prescribedMeds.AfterBreakfast)
            cmd.Parameters.AddWithValue("@al", prescribedMeds.AfterLunch)
            cmd.Parameters.AddWithValue("@ad", prescribedMeds.AfterDinner)
            cmd.Parameters.AddWithValue("@atbt", prescribedMeds.AtBedTime)
            cmd.Parameters.AddWithValue("@fkid", prescribedMeds.FK_emdPatients)
            cmd.Parameters.AddWithValue("@stid", prescribedMeds.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@inid", prescribedMeds.Info_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function NewPrescription_Consultation(prescribedMeds As Prescription, consultation As CustomerConsultation) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[customerprescription] ([productcode] ,[productdescription] ,[genericname] ,[qty] ,[instruction] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime] ,[FK_emdPatients] ,[servertransaction_id], [info_id], [vital_id]) VALUES (@prodcode, @proddesc, @genname, @qty, @inst, @bb, @bl, @bd, @ab, @al, @ad, @atbt, @fkid, @stid, @inid, @vid);"
            cmd.Parameters.AddWithValue("@prodcode", prescribedMeds.ProductCode)
            cmd.Parameters.AddWithValue("@proddesc", prescribedMeds.ProductDescription)
            cmd.Parameters.AddWithValue("@genname", prescribedMeds.GenericName)
            cmd.Parameters.AddWithValue("@qty", prescribedMeds.Qty)
            cmd.Parameters.AddWithValue("@inst", prescribedMeds.Instruction)
            cmd.Parameters.AddWithValue("@bb", prescribedMeds.BeforeBreakfast)
            cmd.Parameters.AddWithValue("@bl", prescribedMeds.BeforeLunch)
            cmd.Parameters.AddWithValue("@bd", prescribedMeds.BeforeDinner)
            cmd.Parameters.AddWithValue("@ab", prescribedMeds.AfterBreakfast)
            cmd.Parameters.AddWithValue("@al", prescribedMeds.AfterLunch)
            cmd.Parameters.AddWithValue("@ad", prescribedMeds.AfterDinner)
            cmd.Parameters.AddWithValue("@atbt", prescribedMeds.AtBedTime)
            cmd.Parameters.AddWithValue("@fkid", prescribedMeds.FK_emdPatients)
            cmd.Parameters.AddWithValue("@stid", prescribedMeds.ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@inid", prescribedMeds.Info_ID)
            cmd.Parameters.AddWithValue("@vid", consultation.Consultation_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function NewPrescriptions_Consultation(prescribedMeds As List(Of Prescription)) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            For Each prescription As Prescription In prescribedMeds
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[customerprescription] ([productcode] ,[productdescription] ,[genericname] ,[qty] , [preparation],[instruction] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime], [daysIntake],[FK_emdPatients] ,[servertransaction_id], [info_id], [vital_id], [isS2], [ctr]) VALUES (@prodcode, @proddesc, @genname, @qty, @prep,@inst, @bb, @bl, @bd, @ab, @al, @ad, @atbt, @dyIk,@fkid, @stid, @inid, @vid, @s2, (SELECT CASE WHEN MAX(ctr + 1) IS NULL THEN 1 ELSE MAX(ctr + 1) END FROM dbo.customerprescription WHERE vital_id = @vid));"
                cmd.Parameters.AddWithValue("@prodcode", prescription.ProductCode)
                cmd.Parameters.AddWithValue("@proddesc", prescription.ProductDescription)
                cmd.Parameters.AddWithValue("@genname", prescription.GenericName)
                cmd.Parameters.AddWithValue("@qty", prescription.Qty)
                cmd.Parameters.AddWithValue("@s2", prescription.isS2Meds)
                cmd.Parameters.AddWithValue("@prep", prescription.Preparation)
                cmd.Parameters.AddWithValue("@inst", prescription.Instruction)
                cmd.Parameters.AddWithValue("@bb", prescription.BeforeBreakfast)
                cmd.Parameters.AddWithValue("@bl", prescription.BeforeLunch)
                cmd.Parameters.AddWithValue("@bd", prescription.BeforeDinner)
                cmd.Parameters.AddWithValue("@ab", prescription.AfterBreakfast)
                cmd.Parameters.AddWithValue("@al", prescription.AfterLunch)
                cmd.Parameters.AddWithValue("@ad", prescription.AfterDinner)
                cmd.Parameters.AddWithValue("@atbt", prescription.AtBedTime)
                cmd.Parameters.AddWithValue("@dyIk", prescription.DaysOfIntake)
                cmd.Parameters.AddWithValue("@fkid", prescription.FK_emdPatients)
                cmd.Parameters.AddWithValue("@stid", prescription.ServerTransaction_ID)
                cmd.Parameters.AddWithValue("@inid", prescription.Info_ID)
                cmd.Parameters.AddWithValue("@vid", prescription.Consultation_ID)
                CMDs.Add(cmd)
            Next
            Return excecuteMultipleCommand(CMDs)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function EditPrescription(prescribedMeds As Prescription) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [dbo].[customerprescription]
                                   SET [qty] = @qty
                                      ,[instruction] = @inst
                                      ,[beforebreakfast] = @bb
                                      ,[beforelunch] = @bl
                                      ,[beforedinner] = @bd
                                      ,[afterbreakfast] = @ab
                                      ,[afterlunch] = @al
                                      ,[afterdinner] = @ad
                                      ,[atbedtime] = @atbt
                                      ,[modifieddate] = GETDATE()
                                 WHERE [prescription_id] = @ID"
            cmd.Parameters.AddWithValue("@qty", prescribedMeds.Qty)
            cmd.Parameters.AddWithValue("@inst", prescribedMeds.Instruction)
            cmd.Parameters.AddWithValue("@bb", prescribedMeds.BeforeBreakfast)
            cmd.Parameters.AddWithValue("@bl", prescribedMeds.BeforeLunch)
            cmd.Parameters.AddWithValue("@bd", prescribedMeds.BeforeDinner)
            cmd.Parameters.AddWithValue("@ab", prescribedMeds.AfterBreakfast)
            cmd.Parameters.AddWithValue("@al", prescribedMeds.AfterLunch)
            cmd.Parameters.AddWithValue("@ad", prescribedMeds.AfterDinner)
            cmd.Parameters.AddWithValue("@atbt", prescribedMeds.AtBedTime)
            cmd.Parameters.AddWithValue("@ID", prescribedMeds.Prescription_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function MoveUpPrescription(id As Long) As Boolean
        Try
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "Select * from dbo.customerprescription where vital_id = (SELECT vital_id from dbo.customerprescription where prescription_id = @ID) order by ctr asc;"
            cmd1.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd1).Tables(0)
            If Not IsNothing(data) Then
                Dim ctr As Integer = 0
                Dim selectedCtr As Integer = 0
                Dim prescriptions As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescription As New Prescription
                    prescription.Prescription_ID = row("prescription_id")
                    prescription.PrescriptionCTR = row("ctr")
                    prescriptions.Add(prescription)
                    If row("prescription_id") = id Then
                        selectedCtr = ctr
                    End If
                    ctr += 1
                Next
                If Not IsNothing(prescriptions) Then
                    Dim nextctr As Integer = 0
                    If selectedCtr = 0 Then
                        nextctr = (data.Rows.Count - 1)
                        Dim tmpPr1 As New Prescription
                        tmpPr1 = prescriptions(selectedCtr)
                        prescriptions.Remove(tmpPr1)
                        prescriptions.Add(tmpPr1)
                    Else
                        nextctr = (selectedCtr - 1)
                        Dim tmpPr1 As New Prescription
                        tmpPr1 = prescriptions(selectedCtr)
                        prescriptions(selectedCtr) = prescriptions(nextctr)
                        prescriptions(nextctr) = tmpPr1
                    End If
                    Dim CMDs As New List(Of SqlCommand)
                    For x As Integer = 0 To prescriptions.Count - 1
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [ctr] = @ctr WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ctr", x)
                        cmd.Parameters.AddWithValue("@ID", prescriptions(x).Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    If Not IsNothing(CMDs) Then
                        Return excecuteMultipleCommand(CMDs)
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function MoveDownPrescription(id As Long) As Boolean
        Try
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "Select * from dbo.customerprescription where vital_id = (SELECT vital_id from dbo.customerprescription where prescription_id = @ID) order by ctr asc;"
            cmd1.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd1).Tables(0)
            If Not IsNothing(data) Then
                Dim ctr As Integer = 0
                Dim selectedCtr As Integer = 0
                Dim prescriptions As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescription As New Prescription
                    prescription.Prescription_ID = row("prescription_id")
                    prescription.PrescriptionCTR = row("ctr")
                    prescriptions.Add(prescription)
                    If row("prescription_id") = id Then
                        selectedCtr = ctr
                    End If
                    ctr += 1
                Next
                If Not IsNothing(prescriptions) Then
                    Dim nextctr As Integer = 0
                    If selectedCtr = (data.Rows.Count - 1) Then
                        nextctr = 0
                        Dim tmpPr1 As New Prescription
                        tmpPr1 = prescriptions(selectedCtr)
                        For x As Integer = 0 To data.Rows.Count - 1
                            If x = (data.Rows.Count - 1) Then
                                prescriptions(0) = tmpPr1
                            Else
                                prescriptions(x + 1) = prescriptions(x)
                            End If
                        Next
                    Else
                        nextctr = (selectedCtr + 1)
                        Dim tmpPr1 As New Prescription
                        tmpPr1 = prescriptions(selectedCtr)
                        prescriptions(selectedCtr) = prescriptions(nextctr)
                        prescriptions(nextctr) = tmpPr1
                    End If
                    Dim CMDs As New List(Of SqlCommand)
                    For x As Integer = 0 To prescriptions.Count - 1
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [ctr] = @ctr WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ctr", x)
                        cmd.Parameters.AddWithValue("@ID", prescriptions(x).Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    If Not IsNothing(CMDs) Then
                        Return excecuteMultipleCommand(CMDs)
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetPatientLatestPrescribeMeds(infoID As Long, fkEmdPatient As Long) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (a.info_id = @ID " & qry & ")
                               AND (CONVERT(DATE,requestdate) = CONVERT(DATE,GETDATE()) or CONVERT(DATE,modifieddate) = CONVERT(DATE,GETDATE()))
                               ORDER BY prescription_id desc"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientPrescribeMeds(infoID As Long, fkEmdPatient As Long, keyword As String, serverID As Long) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            Dim qryFindKeyword As String = ""
            Dim qryShowCertain = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            If serverID > 0 Then
                qryShowCertain = "AND d.server_id = @srid"
                cmd.Parameters.AddWithValue("@srid", serverID)
            End If
            If keyword.Trim.Length > 0 Then
                qryFindKeyword = "AND (a.productdescription like @kword OR a.genericname like @kword)"
                cmd.Parameters.AddWithValue("@kword", keyword & "%")
            End If
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (a.info_id = @ID " & qry & ")    " & qryShowCertain & "   " & qryFindKeyword & "
                               ORDER BY prescription_id desc"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientPrescribeMeds(infoID As Long, fkEmdPatient As Long, serverID As Long) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            Dim qry As String = ""
            If fkEmdPatient > 0 Then
                qry = "or a.FK_emdPatients = @fkid"
                cmd.Parameters.AddWithValue("@fkid", fkEmdPatient)
            End If
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (a.info_id = @ID " & qry & ") AND d.server_id = @srid
                               ORDER BY prescription_id desc"
            cmd.Parameters.AddWithValue("@srid", serverID)
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientPrescribeMeds_Consulation(patient As ServedCustomer, consultation As CustomerConsultation) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (a.vital_id = @ID)
                               ORDER BY ctr asc"
            cmd.Parameters.AddWithValue("@ID", consultation.Consultation_ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.PrescriptionUse = If(Not IsDBNull(row("prescriptionuse")), row("prescriptionuse"), Nothing)
                    prescribedMed.isS2Meds = row("isS2")
                    prescribedMed.Preparation = If(Not IsDBNull(row("preparation")), row("preparation"), "")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.DaysOfIntake = row("daysIntake")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPatientPrescribeMeds_Consulation(ID As Long) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (a.vital_id = @ID)
                               ORDER BY prescription_id desc"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.isS2Meds = row("isS2")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.Preparation = row("preparation")
                    prescribedMed.PrescriptionUse = If(Not IsDBNull(row("prescriptionuse")), row("prescriptionuse"), Nothing)
                    prescribedMed.DaysOfIntake = row("daysIntake")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainServerCertainPatientPrescribeMeds(serverID As Long, patientID As Long) As List(Of Prescription)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[customerprescription] as a
                               JOIN wmmcqms.servertransaction as b ON a.servertransaction_id = b.servertransaction_id
                               JOIN wmmcqms.serverassigncounter as c ON b.serverassigncounter_id = c.serverassigncounter_ID
                               JOIN wmmcqms.server as d ON c.server_id = d.server_id
                               JOIN wmmcqms.counter as e ON c.counter_id = e.counter_id
                               WHERE (FK_emdPatients = @fkid AND c.server_id = @ID) AND (CONVERT(DATE,requestdate) = CONVERT(DATE,GETDATE()) or CONVERT(DATE,modifieddate) = CONVERT(DATE,GETDATE())) AND sentdate IS NULL
                               ORDER BY prescription_id desc"
            cmd.Parameters.AddWithValue("@ID", serverID)
            cmd.Parameters.AddWithValue("@fkid", patientID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim prescribedMeds As New List(Of Prescription)
                For Each row As DataRow In data.Rows
                    Dim prescribedMed As New Prescription
                    prescribedMed.Prescription_ID = row("prescription_id")
                    prescribedMed.ProductCode = row("productcode")
                    prescribedMed.ProductDescription = row("productdescription")
                    prescribedMed.GenericName = row("genericname")
                    prescribedMed.Qty = row("qty")
                    prescribedMed.Instruction = row("instruction")
                    prescribedMed.BeforeBreakfast = row("beforebreakfast")
                    prescribedMed.AfterBreakfast = row("afterbreakfast")
                    prescribedMed.BeforeLunch = row("beforelunch")
                    prescribedMed.AfterLunch = row("afterlunch")
                    prescribedMed.BeforeDinner = row("beforedinner")
                    prescribedMed.AfterDinner = row("afterdinner")
                    prescribedMed.AtBedTime = row("atbedtime")
                    prescribedMed.SentDate = If(Not IsDBNull(row("sentdate")), row("sentdate"), Nothing)
                    prescribedMed.RequestDate = row("requestdate")
                    prescribedMed.ModifiedDate = If(Not IsDBNull(row("modifieddate")), row("modifieddate"), Nothing)
                    prescribedMed.FK_emdPatients = row("FK_emdPatients")
                    prescribedMed.ServerTransaction_ID = row("servertransaction_id")
                    prescribedMed.ServerTransaction = New ServerTransaction
                    prescribedMed.ServerTransaction.ServerTransaction_ID = data.Rows(0)("servertransaction_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter_ID = data.Rows(0)("serverassigncounter_id")
                    prescribedMed.ServerTransaction.CounterName = data.Rows(0)("countername")
                    prescribedMed.ServerTransaction.ServerAssignCounter = New ServerAssignCounter
                    prescribedMed.ServerTransaction.ServerAssignCounter.ServerAssignCounter_ID = row("serverassigncounter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter = New Counter
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Counter_ID = row("counter_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Department = row("department")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Section = row("section")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.ServiceDescription = row("servicedescription")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.CounterPrefix = row("counterPrefix")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.Icon = row("icon")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationView = row("consultationView")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Counter.consultationAddEdit = row("consultationAddEdit")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server = New Server
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.Server_ID = row("server_id")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.FullName = row("fullname")
                    prescribedMed.ServerTransaction.ServerAssignCounter.Server.AssignDepartment = row("assigndepartment")
                    prescribedMeds.Add(prescribedMed)
                Next
                Return prescribedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function
    Public Function DeleteCertainMeds(deleteMeds As Prescription) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "DELETE FROM [dbo].[customerprescription] WHERE prescription_id = @ID AND sentdate IS NULL"
            cmd.Parameters.AddWithValue("@ID", deleteMeds.Prescription_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SendPrescribeMedsToMedExpress(medList As List(Of Prescription)) As Boolean
        Try
            'Checks if the doctor and the patient of these prescription are all the same
            Dim ctrDoctorID As Long = 0
            Dim doctor As Server = Nothing
            Dim ctrPatientID As Long = 0
            Dim patient As CustomerInfo = Nothing
            Dim curDate As Nullable(Of Date) = Nothing
            For Each medsItem As Prescription In medList
                If ctrPatientID = 0 Then
                    ctrPatientID = medsItem.FK_emdPatients
                    Dim cmd As New SqlCommand
                    cmd.CommandText = "SELECT * FROM [dbo].[customerinfo] WHERE FK_emdPatients = @ID;"
                    cmd.Parameters.AddWithValue("@ID", ctrPatientID)
                    Dim data As DataTable = fetchData(cmd).Tables(0)
                    If Not IsNothing(data) Then
                        patient = New CustomerInfo
                        patient.Info_ID = If(Not IsDBNull(data.Rows(0)("info_id")), data.Rows(0)("info_id"), 0)
                        patient.FirstName = If(Not IsDBNull(data.Rows(0)("firstname")), data.Rows(0)("firstname"), "")
                        patient.Middlename = If(Not IsDBNull(data.Rows(0)("middlename")), data.Rows(0)("middlename"), "")
                        patient.Lastname = If(Not IsDBNull(data.Rows(0)("lastname")), data.Rows(0)("lastname"), "")
                        patient.Sex = If(Not IsDBNull(data.Rows(0)("sex")), data.Rows(0)("sex"), "")
                        patient.BirthDate = If(Not IsDBNull(data.Rows(0)("birthdate")), data.Rows(0)("birthdate"), Now)
                        patient.CivilStatus = If(Not IsDBNull(data.Rows(0)("civilstatus")), data.Rows(0)("civilstatus"), "")
                        patient.StreetDrive = If(Not IsDBNull(data.Rows(0)("street")), data.Rows(0)("street"), "")
                        patient.Barangay = If(Not IsDBNull(data.Rows(0)("barangay")), data.Rows(0)("barangay"), "")
                        patient.CityMunicipality = If(Not IsDBNull(data.Rows(0)("city")), data.Rows(0)("city"), "")
                        patient.PhoneNumber = If(Not IsDBNull(data.Rows(0)("phonenumber")), data.Rows(0)("phonenumber"), 0)
                        patient.Nationality = If(Not IsDBNull(data.Rows(0)("nationality")), data.Rows(0)("nationality"), "")
                        patient.Email = If(Not IsDBNull(data.Rows(0)("email")), data.Rows(0)("email"), "")
                        patient.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("FK_emdPatients")), data.Rows(0)("FK_emdPatients"), 0)
                    End If
                Else
                    If Not (ctrPatientID = medsItem.FK_emdPatients) Then
                        MessageBox.Show("Some prescription was not for this patient. Sending terminated", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
                If ctrDoctorID = 0 Then
                    ctrDoctorID = medsItem.ServerTransaction.ServerAssignCounter.Server.Server_ID
                    Dim cmd As New SqlCommand
                    cmd.CommandText = "SELECT *  FROM [wmmcqms].[server] WHERE server_id = @ID"
                    cmd.Parameters.AddWithValue("@ID", ctrDoctorID)
                    Dim data As DataTable = fetchData(cmd).Tables(0)
                    If Not IsNothing(data) Then
                        doctor = New Server
                        doctor.Server_ID = data.Rows(0).Item("server_id")
                        doctor.EmmployeeID = data.Rows(0).Item("employee_id")
                        doctor.FullName = data.Rows(0).Item("fullname")
                        doctor.FirstName = If(Not IsDBNull(data.Rows(0).Item("firstname")), data.Rows(0).Item("firstname"), "")
                        doctor.MiddleName = If(Not IsDBNull(data.Rows(0).Item("middlename")), data.Rows(0).Item("middlename"), "")
                        doctor.LastName = If(Not IsDBNull(data.Rows(0).Item("lastname")), data.Rows(0).Item("lastname"), "")
                        doctor.AssignDepartment = data.Rows(0).Item("assigndepartment")
                        doctor.Specialization = If(Not IsDBNull(data.Rows(0).Item("specializaton")), data.Rows(0).Item("specializaton"), "")
                        doctor.PRC = If(Not IsDBNull(data.Rows(0).Item("prc")), data.Rows(0).Item("prc"), "")
                        doctor.PTR = If(Not IsDBNull(data.Rows(0).Item("ptr")), data.Rows(0).Item("ptr"), "")
                        doctor.PhysicianID = If(Not IsDBNull(data.Rows(0).Item("physician_id")), data.Rows(0).Item("physician_id"), "")
                    End If
                Else
                    If Not (ctrDoctorID = medsItem.ServerTransaction.ServerAssignCounter.Server.Server_ID) Then
                        MessageBox.Show("Some prescription was not created by you. Sending terminated.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
            Next
            Dim cmdDate As New SqlCommand
            cmdDate.CommandText = "SELECT GETDATE() as 'CURRENTDATE'"
            Dim dateData As DataTable = fetchData(cmdDate).Tables(0)
            If Not IsNothing(dateData) Then
                curDate = dateData.Rows(0)("CURRENTDATE")
            End If
            If IsNothing(doctor) Then
                MessageBox.Show("Unable to find the doctor for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(patient) Then
                MessageBox.Show("Unable to find the patient for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PhysicianID) Or doctor.PhysicianID.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Physician ID'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.Specialization) Or doctor.Specialization.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Specialization'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PRC) Or doctor.PRC.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'PRC or Liscence Number'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(curDate) Then
                MessageBox.Show("Failed to get the date for this prescription. Please try again later", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Dim apiController As New APIController
                If apiController.SendPrescriptionsToMedExpress(medList, doctor, patient, curDate) Then
                    Dim CMDs As New List(Of SqlCommand)
                    For Each meditem As Prescription In medList
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [sentdate] = GETDATE() WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ID", meditem.Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    Return excecuteMultipleCommand(CMDs)
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SendPrescriptionsToMedExpress(medList As List(Of Prescription), doctor As Server, patient As CustomerInfo) As Boolean
        Try
            Dim curDate As Nullable(Of Date) = Nothing
            Dim cmdDate As New SqlCommand
            cmdDate.CommandText = "SELECT GETDATE() as 'CURRENTDATE'"
            Dim dateData As DataTable = fetchData(cmdDate).Tables(0)
            If Not IsNothing(dateData) Then
                curDate = dateData.Rows(0)("CURRENTDATE")
            End If
            If IsNothing(doctor) Then
                MessageBox.Show("Unable to find the doctor for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(patient) Then
                MessageBox.Show("Unable to find the patient for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PhysicianID) Or doctor.PhysicianID.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Physician ID'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.Specialization) Or doctor.Specialization.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Specialization'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PRC) Or doctor.PRC.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'PRC or Liscence Number'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(curDate) Then
                MessageBox.Show("Failed to get the date for this prescription. Please try again later", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Dim apiController As New APIController
                If apiController.SendPrescriptionsToMedExpress(medList, doctor, patient, curDate) Then
                    Dim CMDs As New List(Of SqlCommand)
                    For Each meditem As Prescription In medList
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [sentdate] = GETDATE() WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ID", meditem.Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    Return excecuteMultipleCommand(CMDs)
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SendPrescriptionsToMedExpress_ForERUse(medList As List(Of Prescription), doctor As Server, patient As CustomerInfo) As Boolean
        Try
            Dim curDate As Nullable(Of Date) = Nothing
            Dim cmdDate As New SqlCommand
            cmdDate.CommandText = "SELECT GETDATE() as 'CURRENTDATE'"
            Dim dateData As DataTable = fetchData(cmdDate).Tables(0)
            If Not IsNothing(dateData) Then
                curDate = dateData.Rows(0)("CURRENTDATE")
            End If
            If IsNothing(doctor) Then
                MessageBox.Show("Unable to find the doctor for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(patient) Then
                MessageBox.Show("Unable to find the patient for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PhysicianID) Or doctor.PhysicianID.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Physician ID'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.Specialization) Or doctor.Specialization.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Specialization'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PRC) Or doctor.PRC.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'PRC or Liscence Number'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(curDate) Then
                MessageBox.Show("Failed to get the date for this prescription. Please try again later", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Dim apiController As New APIController
                If apiController.SendPrescriptionsToMedExpress(medList, doctor, patient, curDate) Then
                    Dim CMDs As New List(Of SqlCommand)
                    For Each meditem As Prescription In medList
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [sentdate] = GETDATE(), [prescriptionuse] = 'eru' WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ID", meditem.Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    Return excecuteMultipleCommand(CMDs)
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function SendPrescriptionsToMedExpress_ConsumeNow(medList As List(Of Prescription), doctor As Server, patient As CustomerInfo) As Boolean
        Try
            Dim curDate As Nullable(Of Date) = Nothing
            Dim cmdDate As New SqlCommand
            cmdDate.CommandText = "SELECT GETDATE() as 'CURRENTDATE'"
            Dim dateData As DataTable = fetchData(cmdDate).Tables(0)
            If Not IsNothing(dateData) Then
                curDate = dateData.Rows(0)("CURRENTDATE")
            End If
            If IsNothing(doctor) Then
                MessageBox.Show("Unable to find the doctor for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(patient) Then
                MessageBox.Show("Unable to find the patient for this prescription.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PhysicianID) Or doctor.PhysicianID.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Physician ID'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.Specialization) Or doctor.Specialization.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'Specialization'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(doctor.PRC) Or doctor.PRC.Trim.Length = 0 Then
                MessageBox.Show("This account has no 'PRC or Liscence Number'. Please complete this account's information first.", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            ElseIf IsNothing(curDate) Then
                MessageBox.Show("Failed to get the date for this prescription. Please try again later", "Medexpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Dim apiController As New APIController
                If apiController.SendPrescriptionsToMedExpress(medList, doctor, patient, curDate) Then
                    Dim CMDs As New List(Of SqlCommand)
                    For Each meditem As Prescription In medList
                        Dim cmd As New SqlCommand
                        cmd.CommandText = "UPDATE [dbo].[customerprescription] SET [sentdate] = GETDATE(), [prescriptionuse] = 'cn' WHERE prescription_id = @ID"
                        cmd.Parameters.AddWithValue("@ID", meditem.Prescription_ID)
                        CMDs.Add(cmd)
                    Next
                    Return excecuteMultipleCommand(CMDs)
                End If
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function
End Class
