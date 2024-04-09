Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports MySqlConnector
Imports RestSharp

Public Class APIController
    Private Const MedExpressURL As String = "http://10.5.19.250/MedexERxAPI"

    Public Function GetCurrentServerDate_qms() As Date
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT GETDATE();"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                Dim dt As Date = data.Rows(0)(0)
                Return dt
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function FindPatientByKeyword(keyword As String) As DataTable
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause = whereClause & " AND "
                        End If
                        whereClause = whereClause & "(fullname like @kw" & x & " or fullname2 like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,mobilephone,mobilephone2
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE " & whereClause & ";"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd.Parameters.Contains("@kw" & x) Then
                        cmd.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            Return data
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindRecordPatientByKeyword(keyword As String) As List(Of CustomerInfo)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause1 As String = ""
            Dim whereClause2 As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause1.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause1 = whereClause1 & " AND "
                        End If
                        whereClause1 = whereClause1 & "(fullname like @kw" & x & " or fullname2 like @kw" & x & ")"
                    End If
                    If Not whereClause2.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause2 = whereClause2 & " AND "
                        End If
                        whereClause2 = whereClause2 & "(firstname like @kw" & x & " or middlename like @kw" & x & " or lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd2 As New SqlCommand
            cmd2.CommandText = "SELECT * FROM [dbo].[customerinfo]
                                WHERE " & whereClause2 & ";"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd2.Parameters.Contains("@kw" & x) Then
                        cmd2.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            Dim dataLocal As DataTable = fetchData(cmd2).Tables(0)
            Dim whereFilter As String = ""
            If Not IsNothing(dataLocal) Then
                If dataLocal.Rows.Count > 0 Then
                    For x As Integer = 0 To dataLocal.Rows.Count - 1
                        whereFilter = whereFilter & " AND PK_emdPatients != @fk_fil" & x
                    Next
                End If
            End If
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,mobilephone,mobilephone2
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE " & whereClause1 & whereFilter & ";"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd1.Parameters.Contains("@kw" & x) Then
                        cmd1.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            If Not IsNothing(dataLocal) Then
                If dataLocal.Rows.Count > 0 Then
                    For x As Integer = 0 To dataLocal.Rows.Count - 1
                        If Not cmd1.Parameters.Contains("@fk_fil" & x) Then
                            cmd1.Parameters.AddWithValue("@fk_fil" & x, dataLocal.Rows(x)("FK_emdPatients"))
                        End If
                    Next
                End If
            End If
            Dim dataBizBox As DataTable = fetchData(cmd1, openDatabaseBizbox).Tables(0)
            Dim patients As New List(Of CustomerInfo)
            If Not IsNothing(dataLocal) Then
                For Each row As DataRow In dataLocal.Rows
                    Dim patient As New CustomerInfo
                    With patient
                        .Info_ID = row("info_id")
                        .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                        .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                        .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                        .Suffix = ""
                        .Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                        .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                        .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                        .StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                        .Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                        .CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                        .Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                        .Email = If(Not IsDBNull(row("email")), row("email"), "")
                        .PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                        .FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), 0)
                    End With
                    patients.Add(patient)
                Next
            End If
            If Not IsNothing(dataBizBox) Then
                For Each row As DataRow In dataBizBox.Rows
                    Dim patient As New CustomerInfo
                    With patient
                        .Info_ID = 0
                        .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                        .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                        .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                        .Suffix = ""
                        .Sex = If(Not IsDBNull(row("gender")), row("gender"), "")
                        .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                        .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                        .StreetDrive = If(Not IsDBNull(row("cpaddress")), row("cpaddress"), "")
                        .Barangay = ""
                        .CityMunicipality = ""
                        .Nationality = ""
                        .Email = ""
                        .PhoneNumber = If(Not IsDBNull(row("mobilephone")), row("mobilephone"), "")
                        .FK_emdPatients = If(Not IsDBNull(row("PK_emdPatients")), row("PK_emdPatients"), 0)
                    End With
                    patients.Add(patient)
                Next
            End If
            Return patients
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindRecordPatientByKeyword_BizboxOnly(keyword As String) As List(Of CustomerInfo)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause1 As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause1.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause1 = whereClause1 & " AND "
                        End If
                        whereClause1 = whereClause1 & "(fullname like @kw" & x & " or fullname2 like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,mobilephone,mobilephone2
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE " & whereClause1 & ";"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd1.Parameters.Contains("@kw" & x) Then
                        cmd1.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            Dim dataBizBox As DataTable = fetchData(cmd1, openDatabaseBizbox).Tables(0)
            Dim patients As New List(Of CustomerInfo)
            For Each row As DataRow In dataBizBox.Rows
                Dim patient As New CustomerInfo
                With patient
                    .Info_ID = 0
                    .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    .Suffix = ""
                    .Sex = If(Not IsDBNull(row("gender")), row("gender"), "")
                    .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                    .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    .StreetDrive = If(Not IsDBNull(row("cpaddress")), row("cpaddress"), "")
                    .Barangay = ""
                    .CityMunicipality = ""
                    .Nationality = ""
                    .Email = ""
                    .PhoneNumber = If(Not IsDBNull(row("mobilephone")), row("mobilephone"), "")
                    .FK_emdPatients = If(Not IsDBNull(row("PK_emdPatients")), row("PK_emdPatients"), 0)
                End With
                patients.Add(patient)
            Next
            Return patients
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindRecordPatientByKeyword_MyPatient(keyword As String, doctor As ServerAssignCounter) As List(Of CustomerInfo)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause2 As String = ""
            If keyword.Trim.Length > 0 Then
                whereClause2 = "WHERE "
            End If
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause2.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause2 = whereClause2 & " AND "
                        End If
                        whereClause2 = whereClause2 & "(f.firstname like @kw" & x & " or f.middlename like @kw" & x & " or f.lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd2 As New SqlCommand
            cmd2.CommandText = "SELECT DISTINCT f.*
                                FROM [wmmcqms].[servedcustomer] as a
                                JOIN [wmmcqms].[servertransaction] as b on a.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as c on c.serverassigncounter_ID = b.serverassigncounter_id and c.serverassigncounter_ID = @ID
                                JOIN [wmmcqms].[customerassigncounter] as d on d.customerassigncounter_id = a.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as e on e.customer_id = d.customer_id
                                JOIN [dbo].[customerinfo] as f on f.info_id = e.info_id " & whereClause2 & " ORDER BY f.lastname asc"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd2.Parameters.Contains("@kw" & x) Then
                        cmd2.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            cmd2.Parameters.AddWithValue("@ID", doctor.ServerAssignCounter_ID)
            Dim dataLocal As DataTable = fetchData(cmd2).Tables(0)
            Dim patients As New List(Of CustomerInfo)
            For Each row As DataRow In dataLocal.Rows
                Dim patient As New CustomerInfo
                With patient
                    .Info_ID = row("info_id")
                    .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    .Suffix = ""
                    .Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                    .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                    .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    .StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                    .Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                    .CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                    .Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                    .Email = If(Not IsDBNull(row("email")), row("email"), "")
                    .PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                    .FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), 0)
                End With
                patients.Add(patient)
            Next
            Return patients
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindRecordPatientByKeyword_PCCPatients(keyword As String) As List(Of CustomerInfo)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause2 As String = ""
            If keyword.Trim.Length > 0 Then
                whereClause2 = "WHERE "
            End If
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause2.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause2 = whereClause2 & " AND "
                        End If
                        whereClause2 = whereClause2 & "(f.firstname like @kw" & x & " or f.middlename like @kw" & x & " or f.lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd2 As New SqlCommand
            cmd2.CommandText = "SELECT DISTINCT f.*
                                FROM [wmmcqms].[servedcustomer] as a
                                JOIN [wmmcqms].[servertransaction] as b on a.servertransaction_id = b.servertransaction_id
                                JOIN [wmmcqms].[serverassigncounter] as c on c.serverassigncounter_ID = b.serverassigncounter_id
                                JOIN [wmmcqms].[customerassigncounter] as d on d.customerassigncounter_id = a.customerassigncounter_id
                                JOIN [wmmcqms].[customer] as e on e.customer_id = d.customer_id
                                JOIN [dbo].[customerinfo] as f on f.info_id = e.info_id " & whereClause2 & " ORDER BY f.lastname asc"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd2.Parameters.Contains("@kw" & x) Then
                        cmd2.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            Dim dataLocal As DataTable = fetchData(cmd2).Tables(0)
            Dim patients As New List(Of CustomerInfo)
            For Each row As DataRow In dataLocal.Rows
                Dim patient As New CustomerInfo
                With patient
                    .Info_ID = row("info_id")
                    .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                    .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                    .Suffix = ""
                    .Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                    .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                    .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                    .StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                    .Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                    .CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                    .Nationality = If(Not IsDBNull(row("nationality")), row("nationality"), "")
                    .Email = If(Not IsDBNull(row("email")), row("email"), "")
                    .PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                    .FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), 0)
                End With
                patients.Add(patient)
            Next
            Return patients
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function


    Public Function FindPatientRecordByKeywordAndBday(keyword As String, bday As Date) As List(Of DataTable)
        Try
            Dim DATAs As New List(Of DataTable)
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClauseBizbox As String = ""
            Dim whereClauseHealthCheck As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClauseBizbox.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClauseBizbox = whereClauseBizbox & " AND "
                        End If
                        whereClauseBizbox = whereClauseBizbox & "(fullname like @kw" & x & " or fullname2 like @kw" & x & ")"
                    End If
                    If Not whereClauseHealthCheck.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClauseHealthCheck = whereClauseHealthCheck & " AND "
                        End If
                        whereClauseHealthCheck = whereClauseHealthCheck & "(firstname like @kw" & x & " or lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,mobilephone,mobilephone2
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE " & whereClauseBizbox & " AND birthdate = @bday;"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd1.Parameters.Contains("@kw" & x) Then
                        cmd1.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            cmd1.Parameters.AddWithValue("@bday", bday)
            Dim dataBizbox As DataTable = fetchData(cmd1, openDatabaseBizbox).Tables(0)
            DATAs.Add(dataBizbox)
            Dim cmd2 As New MySqlCommand
            cmd2.CommandText = "SELECT * FROM patient WHERE pk_patient = 
                                (SELECT MAX(pk_patient) FROM `patient` WHERE " & whereClauseHealthCheck & " AND DATE(birthday) = DATE(@bday))"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd2.Parameters.Contains("@kw" & x) Then
                        cmd2.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            cmd2.Parameters.AddWithValue("@bday", bday)
            'Dim dataHealthCheck As DataTable = fetchData(cmd2, openDatabaseBizbox).Tables(0)
            DATAs.Add(dataBizbox)
            Return DATAs
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindPatientByKeywordAndBday(keyword As String, bday As Date) As List(Of CustomerInfo)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause1 As String = ""
            Dim whereClause2 As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause1.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause1 = whereClause1 & " AND "
                        End If
                        whereClause1 = whereClause1 & "(fullname like @kw" & x & " or fullname2 like @kw" & x & ")"
                    End If
                    If Not whereClause2.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause2 = whereClause2 & " AND "
                        End If
                        whereClause2 = whereClause2 & "(firstname like @kw" & x & " or middlename like @kw" & x & " or lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd2 As New SqlCommand
            cmd2.CommandText = "SELECT * FROM [dbo].[customerinfo]
                                WHERE " & whereClause2 & " AND birthdate = @bday;"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd2.Parameters.Contains("@kw" & x) Then
                        cmd2.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            cmd2.Parameters.AddWithValue("@bday", bday)
            Dim dataLocal As DataTable = fetchData(cmd2).Tables(0)
            Dim whereFilter As String = ""
            If Not IsNothing(dataLocal) Then
                If dataLocal.Rows.Count > 0 Then
                    For x As Integer = 0 To dataLocal.Rows.Count - 1
                        whereFilter = whereFilter & " AND PK_emdPatients != @fk_fil" & x
                    Next
                End If
            End If
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,mobilephone,mobilephone2
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE " & whereClause1 & whereFilter & " AND birthdate = @bday;"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd1.Parameters.Contains("@kw" & x) Then
                        cmd1.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            If Not IsNothing(dataLocal) Then
                If dataLocal.Rows.Count > 0 Then
                    For x As Integer = 0 To dataLocal.Rows.Count - 1
                        If Not cmd1.Parameters.Contains("@fk_fil" & x) Then
                            cmd1.Parameters.AddWithValue("@fk_fil" & x, dataLocal.Rows(x)("FK_emdPatients"))
                        End If
                    Next
                End If
            End If
            cmd1.Parameters.AddWithValue("@bday", bday)
            Dim dataBizBox As DataTable = fetchData(cmd1, openDatabaseBizbox).Tables(0)
            Dim patients As New List(Of CustomerInfo)
            If Not IsNothing(dataLocal) Then
                For Each row As DataRow In dataLocal.Rows
                    Dim patient As New CustomerInfo
                    With patient
                        .Info_ID = row("info_id")
                        .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                        .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                        .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                        .Suffix = ""
                        .Sex = If(Not IsDBNull(row("sex")), row("sex"), "")
                        .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                        .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                        .StreetDrive = If(Not IsDBNull(row("street")), row("street"), "")
                        .Barangay = If(Not IsDBNull(row("barangay")), row("barangay"), "")
                        .CityMunicipality = If(Not IsDBNull(row("city")), row("city"), "")
                        .Nationality = If(Not IsDBNull(row("nationality")), row("nationality").ToString.Split("-")(0), "")
                        .Email = If(Not IsDBNull(row("email")), row("email"), "")
                        .PhoneNumber = If(Not IsDBNull(row("phonenumber")), row("phonenumber"), "")
                        .FK_emdPatients = If(Not IsDBNull(row("FK_emdPatients")), row("FK_emdPatients"), 0)
                        If Not IsDBNull(row("nationality")) Then
                            If row("nationality").ToString.Split("-").Count = 2 Then
                                .Country = row("nationality").ToString.Split("-")(1)
                            Else
                                .Country = ""
                            End If
                        End If
                        .Province = If(Not IsDBNull(row("province")), row("province"), "")
                    End With
                    patients.Add(patient)
                Next
            End If
            If Not IsNothing(dataBizBox) Then
                For Each row As DataRow In dataBizBox.Rows
                    Dim patient As New CustomerInfo
                    With patient
                        .Info_ID = 0
                        .FirstName = If(Not IsDBNull(row("firstname")), row("firstname"), "")
                        .Middlename = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                        .Lastname = If(Not IsDBNull(row("lastname")), row("lastname"), "")
                        .Suffix = ""
                        .Sex = If(Not IsDBNull(row("gender")), row("gender"), "")
                        .BirthDate = If(Not IsDBNull(row("birthdate")), row("birthdate"), Now)
                        .CivilStatus = If(Not IsDBNull(row("civilstatus")), row("civilstatus"), "")
                        .StreetDrive = If(Not IsDBNull(row("cpaddress")), row("cpaddress"), .StreetDrive)
                        .Barangay = If(Not IsDBNull(row("cpbarangay")), row("cpbarangay"), .Barangay)
                        .CityMunicipality = If(Not IsDBNull(row("cptowncity")), row("cptowncity"), .CityMunicipality)
                        .Nationality = .Nationality
                        .Email = .Email
                        .PhoneNumber = If(Not IsDBNull(row("mobilephone")), row("mobilephone"), "")
                        .FK_emdPatients = If(Not IsDBNull(row("PK_emdPatients")), row("PK_emdPatients"), 0)
                        .Country = If(Not IsDBNull(row("cpcountry")), row("cpcountry"), .Country)
                        .Province = If(Not IsDBNull(row("cpprovince")), row("cpprovince"), "")
                    End With
                    patients.Add(patient)
                Next
            End If
            For Each pat In patients
                Dim cmd = New SqlCommand
                cmd.CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE Info_ID = @ID"
                cmd.Parameters.AddWithValue("@ID", pat.Info_ID)
                Dim dt As DataTable = fetchData(cmd).Tables(0)
                Dim otherInfo = New CustomerIdentificationInfo
                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        For Each item As DataRow In dt.Rows
                            With otherInfo
                                .OtherInfo_ID = If(Not IsDBNull(item("OtherInfo_ID")), item("OtherInfo_ID"), 0)
                                .Info_ID = If(Not IsDBNull(item("Info_ID")), item("Info_ID"), 0)
                                .ID_Type = If(Not IsDBNull(item("ID_Type")), item("ID_Type"), 0)
                                .ID_Number = If(Not IsDBNull(item("ID_Number")), item("ID_Number"), 0)
                                .ValidUntil = If(Not IsDBNull(item("Valid_Until")), item("Valid_Until"), 0)
                            End With
                        Next
                    End If
                End If
                pat.IdentificationInfo = otherInfo
            Next
            Return patients
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientByInfoID(id As Long) As CustomerInfo
        Try
            Dim custInfo As New CustomerInfo
            Dim checkIfExistCMD As New SqlCommand
            checkIfExistCMD.CommandText = "SELECT * FROM [dbo].[customerinfo] WHERE info_id = @ID"
            checkIfExistCMD.Parameters.AddWithValue("@ID", id)
            Dim foundData As DataTable = fetchData(checkIfExistCMD, openDatabase).Tables(0)
            If Not IsNothing(foundData) Then
                If foundData.Rows.Count > 0 Then
                    custInfo.Info_ID = foundData.Rows(0)("info_id")
                    custInfo.FirstName = foundData.Rows(0)("firstname")
                    custInfo.Middlename = foundData.Rows(0)("middlename")
                    custInfo.Lastname = foundData.Rows(0)("lastname")
                    If foundData.Rows(0)("firstname").ToString.ToUpper.Contains("JR") Then
                        custInfo.Suffix = "JR"
                    ElseIf foundData.Rows(0)("firstname").ToString.ToUpper.Contains("SR") Then
                        custInfo.Suffix = "SR"
                    Else
                        custInfo.Suffix = ""
                    End If
                    custInfo.Sex = foundData.Rows(0)("sex")
                    custInfo.BirthDate = If(Not IsDBNull(foundData.Rows(0)("birthdate")), foundData.Rows(0)("birthdate"), Now)
                    custInfo.CivilStatus = foundData.Rows(0)("civilstatus")
                    custInfo.Nationality = If(Not IsDBNull(foundData.Rows(0)("nationality")), foundData.Rows(0)("nationality").ToString.ToUpper, "")
                    custInfo.StreetDrive = If(Not IsDBNull(foundData.Rows(0)("street")), foundData.Rows(0)("street").ToString.ToUpper, "")
                    custInfo.Barangay = If(Not IsDBNull(foundData.Rows(0)("barangay")), foundData.Rows(0)("barangay").ToString.ToUpper, "")
                    custInfo.CityMunicipality = If(Not IsDBNull(foundData.Rows(0)("city")), foundData.Rows(0)("city").ToString.ToUpper, "")
                    custInfo.PhoneNumber = If(Not IsDBNull(foundData.Rows(0)("phonenumber")), foundData.Rows(0)("phonenumber").ToString.ToUpper, "")
                    custInfo.Email = If(Not IsDBNull(foundData.Rows(0)("email")), foundData.Rows(0)("email").ToString.ToUpper, "")
                    custInfo.PatientPicture = If(Not IsDBNull(foundData.Rows(0)("picturelocation")), foundData.Rows(0)("picturelocation").ToString.ToUpper, "")
                    custInfo.FK_emdPatients = If(Not IsDBNull(foundData.Rows(0)("FK_emdPatients")), foundData.Rows(0)("FK_emdPatients").ToString.ToUpper, "")
                    custInfo.Province = If(Not IsDBNull(foundData.Rows(0)("province")), foundData.Rows(0)("province").ToString.ToUpper, "")

                    Dim cmd = New SqlCommand
                    cmd.CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE Info_ID = @ID"
                    cmd.Parameters.AddWithValue("@ID", id)
                    Dim data = fetchData(cmd).Tables(0)
                    If Not IsNothing(data) Then
                        Dim idInfo = New CustomerIdentificationInfo
                        If data.Rows.Count > 0 Then
                            For Each rw As DataRow In data.Rows
                                With idInfo
                                    .OtherInfo_ID = rw.Item("OtherInfo_ID")
                                    .Info_ID = rw.Item("Info_ID")
                                    .ID_Type = rw.Item("ID_Type")
                                    .ID_Number = rw.Item("ID_Number")
                                    .ValidUntil = rw.Item("Valid_Until")
                                End With
                                custInfo.IdentificationInfo = idInfo
                            Next
                        Else
                            custInfo.IdentificationInfo = idInfo
                        End If
                    End If
                    Return custInfo
                End If
            End If
            Return custInfo
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientByFK_emdPatient(id As Long) As CustomerInfo
        Try
            Dim custInfo As New CustomerInfo
            Dim checkIfExistCMD As New SqlCommand
            checkIfExistCMD.CommandText = "SELECT * FROM [dbo].[customerinfo] WHERE FK_emdPatients = @ID"
            checkIfExistCMD.Parameters.AddWithValue("@ID", id)
            Dim foundData As DataTable = fetchData(checkIfExistCMD, openDatabase).Tables(0)
            If Not IsNothing(foundData) Then
                If foundData.Rows.Count > 0 Then
                    custInfo.Info_ID = foundData.Rows(0)("info_id")
                    custInfo.FirstName = foundData.Rows(0)("firstname")
                    custInfo.Middlename = foundData.Rows(0)("middlename")
                    custInfo.Lastname = foundData.Rows(0)("lastname")
                    If foundData.Rows(0)("firstname").ToString.ToUpper.Contains("JR") Then
                        custInfo.Suffix = "JR"
                    ElseIf foundData.Rows(0)("firstname").ToString.ToUpper.Contains("SR") Then
                        custInfo.Suffix = "SR"
                    Else
                        custInfo.Suffix = ""
                    End If
                    custInfo.Sex = foundData.Rows(0)("sex")
                    custInfo.BirthDate = If(Not IsDBNull(foundData.Rows(0)("birthdate")), foundData.Rows(0)("birthdate"), Now)
                    custInfo.CivilStatus = foundData.Rows(0)("civilstatus")
                    custInfo.Nationality = If(Not IsDBNull(foundData.Rows(0)("nationality")), foundData.Rows(0)("nationality").ToString.ToUpper, "")
                    custInfo.StreetDrive = If(Not IsDBNull(foundData.Rows(0)("street")), foundData.Rows(0)("street").ToString.ToUpper, "")
                    custInfo.Barangay = If(Not IsDBNull(foundData.Rows(0)("barangay")), foundData.Rows(0)("barangay").ToString.ToUpper, "")
                    custInfo.CityMunicipality = If(Not IsDBNull(foundData.Rows(0)("city")), foundData.Rows(0)("city").ToString.ToUpper, "")
                    custInfo.PhoneNumber = If(Not IsDBNull(foundData.Rows(0)("phonenumber")), foundData.Rows(0)("phonenumber").ToString.ToUpper, "")
                    custInfo.Email = If(Not IsDBNull(foundData.Rows(0)("email")), foundData.Rows(0)("email").ToString.ToUpper, "")
                    custInfo.PatientPicture = If(Not IsDBNull(foundData.Rows(0)("picturelocation")), foundData.Rows(0)("picturelocation").ToString.ToUpper, "")
                    custInfo.FK_emdPatients = If(Not IsDBNull(foundData.Rows(0)("FK_emdPatients")), foundData.Rows(0)("FK_emdPatients").ToString.ToUpper, "")
                    custInfo.Province = If(Not IsDBNull(foundData.Rows(0)("province")), foundData.Rows(0)("province").ToString.ToUpper, "")

                    Dim cmd1 = New SqlCommand
                    cmd1.CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE Info_ID = @ID"
                    cmd1.Parameters.AddWithValue("@ID", custInfo.Info_ID)
                    Dim data1 = fetchData(cmd1).Tables(0)
                    If Not IsNothing(data1) Then
                        Dim idInfo = New CustomerIdentificationInfo
                        If data1.Rows.Count > 0 Then
                            For Each rw As DataRow In data1.Rows
                                With idInfo
                                    .OtherInfo_ID = rw.Item("OtherInfo_ID")
                                    .Info_ID = rw.Item("Info_ID")
                                    .ID_Type = rw.Item("ID_Type")
                                    .ID_Number = rw.Item("ID_Number")
                                    .ValidUntil = rw.Item("Valid_Until")
                                End With
                                custInfo.IdentificationInfo = idInfo
                            Next
                        Else
                            custInfo.IdentificationInfo = idInfo
                        End If
                    End If
                    Return custInfo
                End If
            End If
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT        
	                                PK_psPersonalData,PK_emdPatients,lastname,firstname,middlename,fullname,fullname2,
	                                --comaddress,
	                                cpaddress, cpstreetbldg1,cpstreetbldg2,cpstreetbldg3,cpbarangay,cptowncity,cpprovince,cpregion,cpcountry,cpmobilephone,
	                                --empaddress,
	                                --faaddress, fastreetbldg1,fastreetbldg2,fastreetbldg3,
	                                --icaddress, icstreet,
	                                --moaddress, mostreetbldg1,mostreetbldg2,mostreetbldg3,
	                                --nkaddress,
	                                --praddress, prstreetbldg1,prstreetbldg2,prstreetbldg3,
	                                --sdaddress, sdstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                --spaddress, spstreetbldg1,sdstreetbldg2,sdstreetbldg3,
	                                gender,birthdate,civilstatus,nationality,mobilephone,mobilephone2,email
                               FROM            
	                                psDatacenter AS a INNER JOIN
                                    emdPatients AS b ON a.PK_psDatacenter = b.PK_emdPatients INNER JOIN
                                    psPersonaldata AS c ON a.PK_psDatacenter = c.PK_psPersonalData
                               WHERE PK_psPersonalData = @id"
            cmd.Parameters.AddWithValue("@id", id)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    custInfo.Info_ID = 0
                    custInfo.FirstName = data.Rows(0)("firstname")
                    custInfo.Middlename = data.Rows(0)("middlename")
                    custInfo.Lastname = data.Rows(0)("lastname")
                    If data.Rows(0)("fullname").ToString.ToUpper.Contains("JR") Or data.Rows(0)("fullname").ToString.ToUpper.Contains("JR") Then
                        custInfo.Suffix = "JR"
                    ElseIf data.Rows(0)("fullname").ToString.ToUpper.Contains("SR") Or data.Rows(0)("fullname2").ToString.ToUpper.Contains("SR") Then
                        custInfo.Suffix = "SR"
                    Else
                        custInfo.Suffix = ""
                    End If
                    If Not IsDBNull(data.Rows(0)("gender")) Then
                        custInfo.Sex = data.Rows(0)("gender").ToString.ToUpper
                    Else
                        custInfo.Sex = "UNSPECIFIED"
                    End If
                    custInfo.BirthDate = If(Not IsDBNull(data.Rows(0)("birthdate")), data.Rows(0)("birthdate"), Now)
                    If Not IsDBNull(data.Rows(0)("civilstatus")) Then
                        Select Case data.Rows(0)("civilstatus").ToString.ToUpper
                            Case "S"
                                custInfo.CivilStatus = "SINGLE"
                            Case "M"
                                custInfo.CivilStatus = "MARRIED"
                            Case "W"
                                custInfo.CivilStatus = "WIDOWED"
                            Case "D"
                                custInfo.CivilStatus = "DEFACTO"
                            Case "T"
                                custInfo.CivilStatus = "TRADITIONAL"
                            Case "C"
                                custInfo.CivilStatus = "CHILD"
                            Case "N"
                                custInfo.CivilStatus = "NEWBORN"
                            Case "L"
                                custInfo.CivilStatus = "SEPARATED"
                            Case "A"
                                custInfo.CivilStatus = "ANULLED"
                            Case "CO"
                                custInfo.CivilStatus = "CO-HABITATION"
                        End Select
                    Else
                        custInfo.CivilStatus = "UNSPECIFIED"
                    End If
                    custInfo.Nationality = If(Not IsDBNull(data.Rows(0)("nationality")), data.Rows(0)("nationality").ToString.ToUpper, "")
                    custInfo.StreetDrive = If(Not IsDBNull(data.Rows(0)("cpstreetbldg1")), data.Rows(0)("cpstreetbldg1").ToString.ToUpper, "")
                    custInfo.Barangay = If(Not IsDBNull(data.Rows(0)("cpbarangay")), data.Rows(0)("cpbarangay").ToString.ToUpper, "")
                    custInfo.CityMunicipality = If(Not IsDBNull(data.Rows(0)("cptowncity")), data.Rows(0)("cptowncity").ToString.ToUpper, "")
                    custInfo.PhoneNumber = If(Not IsDBNull(data.Rows(0)("mobilephone")), data.Rows(0)("mobilephone").ToString.ToUpper, "")
                    custInfo.Email = If(Not IsDBNull(data.Rows(0)("email")), data.Rows(0)("email").ToString.ToUpper, "")
                    custInfo.FK_emdPatients = If(Not IsDBNull(data.Rows(0)("PK_psPersonalData")), data.Rows(0)("PK_psPersonalData").ToString.ToUpper, "")
                    custInfo.Province = If(Not IsDBNull(data.Rows(0)("cpprovince")), data.Rows(0)("cpprovince").ToString.ToUpper, "")

                    Dim cmd2 = New SqlCommand
                    cmd2.CommandText = "SELECT * FROM [dbo].[customerotherinfo] WHERE Info_ID = @ID"
                    cmd2.Parameters.AddWithValue("@ID", custInfo.Info_ID)
                    Dim data1 = fetchData(cmd2).Tables(0)
                    If Not IsNothing(data1) Then
                        Dim idInfo = New CustomerIdentificationInfo
                        If data1.Rows.Count > 0 Then
                            For Each rw As DataRow In data1.Rows
                                With idInfo
                                    .OtherInfo_ID = rw.Item("OtherInfo_ID")
                                    .Info_ID = rw.Item("Info_ID")
                                    .ID_Type = rw.Item("ID_Type")
                                    .ID_Number = rw.Item("ID_Number")
                                    .ValidUntil = rw.Item("Valid_Until")
                                End With
                                custInfo.IdentificationInfo = idInfo
                            Next
                        Else
                            custInfo.IdentificationInfo = idInfo
                        End If
                    End If
                End If
            End If
            Return custInfo
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientDiagnosticResults(fkid As Long) As List(Of Diagnostics)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "Select PK_psExamResultMstr,Convert(datetime, b.rendate) As ExamDate ,convert(date,a.withresultdate) as ResultDate,dbo.udf_GetExamType(a.FK_mscExamTypes) as ExamDesc ,dbo.udf_GetItemDescription(b.FK_iwItemsREN ) as ItemDesc ,a.[FK_mscExamTypes],a.[FK_iwItems],a.pattrantype,a.[imageLink],b.FK_emdPatients From [psExamResultMstr] As a Left outer join psPatitem As b On b.FK_TRXNO=a.FK_TRXNO where a.withresultflag = 1 and b.FK_emdPatients = @fkid order by b.rendate desc,a.withresultdate"
            cmd.Parameters.AddWithValue("@fkid", fkid)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim diagnosticResults As New List(Of Diagnostics)
                For Each row As DataRow In data.Rows
                    Dim diagnostics As New Diagnostics
                    diagnostics.PK_psExamResultMstr = row("PK_psExamResultMstr")
                    diagnostics.Diagnostics = row("ExamDesc")
                    diagnostics.ItemDescription = row("ItemDesc")
                    diagnostics.PatientType = row("pattrantype")
                    diagnostics.ResultReportLink = If(Not IsDBNull(row("imageLink")), row("imageLink"), Nothing)
                    diagnostics.DiagnosticDate = row("ExamDate")
                    diagnostics.ResultDate = row("ResultDate")
                    diagnostics.FK_emdPatients = row("FK_emdPatients")
                    diagnosticResults.Add(diagnostics)
                Next
                Return diagnosticResults
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainBizBoxDiagnostics(fkid As Long) As List(Of Diagnostics)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = ""
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetMedExpressInventoryData(keyword As String) As DataTable
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.Medicine_ID as 'ID', RTRIM(Name) as 'Item Description', RTRIM(Generic_Name) as 'Generic', SUM(b.Qty) as 'Qty Onhand' ,Ext_Prod_No as 'ProdID', convert(numeric(10,2), a.Unit_Price) as 'Price'
                               FROM [MedexInv].[dbo].[Medicines] as a 
                               JOIN [MedexInv].[dbo].[Med_Exp_Onhand] as b 
                               ON a.Medicine_ID = b.Medicine_ID 
                               WHERE (Active = 1 AND b.Branch_ID = 144) AND (name like @kword OR Generic_Name like @kword)
                               GROUP BY a.Medicine_ID, Name, Generic_Name, Ext_Prod_No,a.Unit_Price"
            cmd.Parameters.AddWithValue("@kword", keyword & "%")
            Dim data As DataTable = fetchData(cmd, openDatabaseMedExpress).Tables(0)
            Return data
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetMedExpressInventoryData_eKonsultaSort(keyword As String, eKonsultaOnly As Boolean) As DataTable
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.Medicine_ID as 'ID', RTRIM(Name) as 'Item Description', RTRIM(Generic_Name) as 'Generic', SUM(b.Qty) as 'Qty Onhand' ,Ext_Prod_No as 'ProdID', convert(numeric(10,2), a.Unit_Price) as 'Price'
                               FROM [MedexInv].[dbo].[Medicines] as a 
                               JOIN [MedexInv].[dbo].[Med_Exp_Onhand] as b 
                               ON a.Medicine_ID = b.Medicine_ID 
                               WHERE (Active = 1 AND b.Branch_ID = 144) AND (name like @kword OR Generic_Name like @kword)
                               GROUP BY a.Medicine_ID, Name, Generic_Name, Ext_Prod_No,a.Unit_Price"
            cmd.Parameters.AddWithValue("@kword", keyword & "%")
            Dim data As DataTable = fetchData(cmd, openDatabaseMedExpress).Tables(0)
            Return data
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainMedExpressMedDetail(id As Long) As Prescription
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [Medicines] WHERE Medicine_ID = @ID"
            cmd.Parameters.AddWithValue("@ID", id)
            Dim data As DataTable = fetchData(cmd, openDatabaseMedExpress).Tables(0)
            If Not IsNothing(data) Then
                Dim selectedMeds As New Prescription
                selectedMeds.ProductCode = data.Rows(0)("Medicine_ID")
                selectedMeds.ProductDescription = data.Rows(0)("Name")
                selectedMeds.Instruction = data.Rows(0)("Indications")
                selectedMeds.GenericName = data.Rows(0)("Generic_Name")
                selectedMeds.UnitPrice = data.Rows(0)("Unit_Price")
                Return selectedMeds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function SendPrescriptionsToMedExpress(prescriptions As List(Of Prescription), doctor As Server, patient As CustomerInfo, rxDate As Date) As Boolean
        Try
            Dim oApi = New RestClient(MedExpressURL)
            Dim oReq As New RestRequest("API/ERx/PostERx", Method.POST)
            oReq.RequestFormat = DataFormat.Json
            Dim oRxHeader As New RxHeader
            oRxHeader.rxID = rxDate.ToString("yyyyMMddHHmmssf")
            oRxHeader.rxDate = rxDate
            oRxHeader.doctorLicenseNo = doctor.PRC
            oRxHeader.doctorLastName = If(doctor.LastName.Trim.Length > 0, doctor.LastName.Trim.ToUpper, "Na")
            oRxHeader.doctorFirstName = If(doctor.FirstName.Trim.Length > 0, doctor.FirstName.Trim.ToUpper, "Na")
            oRxHeader.doctorMiddleName = If(doctor.MiddleName.Trim.Length > 0, If(Not (doctor.MiddleName.Trim.Length > 0), doctor.MiddleName, doctor.MiddleName.Substring(0, 1)), "Na")
            oRxHeader.doctorSpecialization = doctor.Specialization
            oRxHeader.doctorPTR = doctor.PTR
            oRxHeader.employeeID = doctor.PhysicianID
            oRxHeader.patientLastName = If(patient.Lastname.Trim.Length > 0, patient.Lastname.Trim.ToUpper, "Na")
            oRxHeader.patientFirstName = If(patient.FirstName.Trim.Length > 0, patient.FirstName.Trim.ToUpper, "Na")
            oRxHeader.patientMiddleName = If(patient.Middlename.Trim.Length > 0, patient.Middlename, "Na")
            oRxHeader.patientBirthday = If(Not IsNothing(patient.BirthDate), patient.BirthDate, Now)
            If Not IsNothing(patient.Sex) Then
                If patient.Sex.Trim.Length > 0 Then
                    If patient.Sex.ToUpper.Trim = "MALE" Then
                        oRxHeader.patientGender = "M"
                    ElseIf patient.Sex.ToUpper.Trim = "FEMALE" Then
                        oRxHeader.patientGender = "F"
                    Else
                        oRxHeader.patientGender = "."
                    End If
                Else
                    oRxHeader.patientGender = "M"
                End If
            Else
                oRxHeader.patientGender = "M"
            End If
            oRxHeader.createdBy = doctor.FullName
            oRxHeader.patientAddress = patient.StreetDrive & " " & patient.Barangay & " " & patient.CityMunicipality
            oRxHeader.station = "CLINIC"
            oRxHeader.remarks = "."
            oRxHeader.requestType = "."
            Dim oRxDetails As New List(Of RxDetail)
            For Each medsItem As Prescription In prescriptions
                Dim oRxDetail As New RxDetail
                oRxDetail.productNo = medsItem.ProductCode
                oRxDetail.qty = medsItem.Qty
                oRxDetail.remarks = medsItem.Instruction
                oRxDetail.externalProductNo = "" 'Hospital Prod ID
                oRxDetail.productName = medsItem.ProductDescription
                oRxDetail.genericName = medsItem.GenericName
                oRxDetail.freeMeds = False
                oRxDetails.Add(oRxDetail)
            Next
            oRxHeader.ERxDetails = oRxDetails
            oReq.AddBody(oRxHeader)
            Dim oResponse As RestSharp.IRestResponse = oApi.Execute(oReq)
            Dim oMsg As RxResponse = New JavaScriptSerializer().Deserialize(Of RxResponse)(oResponse.Content)
            If oMsg.success Then
                Return True
            Else
                MessageBox.Show(oMsg.errorMsg, "MedExpress Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function FindDoctor(prc As String) As Server
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.[PK_psPersonalData] ,b.fullname ,a.[firstname] ,a.[lastname] ,a.[middlename] ,a.[nickname] ,a.[gender] ,a.[coaddress] ,c.prcno, d.description, ptrno, s2no, a.cptelefax ,a.nktelefax ,a.sptelefax, c.smsplusmobileno
                                FROM [dbo].[psPersonaldata] as a
                                left outer join psDatacenter as b  on b.PK_psDatacenter = a.PK_psPersonalData 
                                left outer join dbo.emdDoctors AS c ON c.PK_emdDoctors = a.PK_psPersonalData
                                left outer join dbo.emdTempSpecializations AS d ON d.PK_emdTempSpecializations = c.FK_emdTempSpecializations
                               where c.prcno = @ID"
            cmd.Parameters.AddWithValue("@ID", prc)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim doctorInfo As New Server
                doctorInfo.PhysicianID = data.Rows(0)("PK_psPersonalData")
                doctorInfo.FullName = data.Rows(0)("fullname")
                doctorInfo.FirstName = data.Rows(0)("firstname")
                doctorInfo.MiddleName = data.Rows(0)("middlename")
                doctorInfo.LastName = data.Rows(0)("lastname")
                doctorInfo.PRC = data.Rows(0)("prcno")
                doctorInfo.PTR = If(Not IsDBNull(data.Rows(0)("ptrno")), data.Rows(0)("ptrno"), "")
                doctorInfo.S2No = If(Not IsDBNull(data.Rows(0)("s2no")), data.Rows(0)("s2no"), "")
                doctorInfo.ContactNo = If(Not IsDBNull(data.Rows(0)("smsplusmobileno")), data.Rows(0)("smsplusmobileno"), "")
                doctorInfo.PrimaryContactNo = If(Not IsDBNull(data.Rows(0)("cptelefax")), data.Rows(0)("cptelefax"), "")
                doctorInfo.SecondaryContactNo = If(Not IsDBNull(data.Rows(0)("nktelefax")), data.Rows(0)("nktelefax"), "")
                doctorInfo.Specialization = data.Rows(0)("description")
                Return doctorInfo
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function FindCertainDoctor(ID As Long) As ReferringConsultant
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.[PK_psPersonalData] ,b.fullname ,a.[firstname] ,a.[lastname] ,a.[middlename] ,a.[nickname] ,a.[gender] ,a.[coaddress] ,c.prcno, d.description, ptrno, s2no, a.cptelefax ,a.nktelefax ,a.sptelefax
                                FROM [dbo].[psPersonaldata] as a
                                left outer join psDatacenter as b  on b.PK_psDatacenter = a.PK_psPersonalData 
                                left outer join dbo.emdDoctors AS c ON c.PK_emdDoctors = a.PK_psPersonalData
                                left outer join dbo.emdTempSpecializations AS d ON d.PK_emdTempSpecializations = c.FK_emdTempSpecializations
                              WHERE a.[PK_psPersonalData] = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim doctor As New ReferringConsultant
                    doctor.ID = data.Rows(0)("PK_psPersonalData")
                    doctor.Fullname = data.Rows(0)("fullname")
                    doctor.FirstName = data.Rows(0)("firstname")
                    doctor.MiddleName = If(Not IsDBNull(data.Rows(0)("middlename")), data.Rows(0)("middlename"), "")
                    doctor.LastName = data.Rows(0)("lastname")
                    doctor.PRC = If(Not IsDBNull(data.Rows(0)("prcno")), data.Rows(0)("prcno"), "")
                    doctor.PTR = If(Not IsDBNull(data.Rows(0)("ptrno")), data.Rows(0)("ptrno"), "")
                    doctor.S2No = If(Not IsDBNull(data.Rows(0)("s2no")), data.Rows(0)("s2no"), "")
                    doctor.PrimaryMobile = If(Not IsDBNull(data.Rows(0)("cptelefax")), data.Rows(0)("cptelefax"), "")
                    doctor.SecondaryMobile = If(Not IsDBNull(data.Rows(0)("nktelefax")), data.Rows(0)("nktelefax"), "")
                    doctor.Specialization = If(Not IsDBNull(data.Rows(0)("description")), data.Rows(0)("description"), "")
                    Return doctor
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

    Public Function FindDoctor_ByKeyWord(keyword As String) As List(Of ReferringConsultant)
        Try
            Dim kwords As String() = keyword.Trim.Split
            Dim whereClause As String = ""
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not whereClause.Contains("@kw" & x) Then
                        If Not x = 0 Then
                            whereClause = whereClause & " AND "
                        Else
                            whereClause = "WHERE "
                        End If
                        whereClause = whereClause & "(fullname like @kw" & x & " or firstname like @kw" & x & " or lastname like @kw" & x & ")"
                    End If
                End If
            Next
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT a.[PK_psPersonalData] ,b.fullname ,a.[firstname] ,a.[lastname] ,a.[middlename] ,a.[nickname] ,a.[gender] ,a.[coaddress] ,c.prcno, d.description, ptrno, s2no, a.cptelefax ,a.nktelefax ,a.sptelefax ,c.smsplusmobileno
                                FROM [dbo].[psPersonaldata] as a
                                left outer join psDatacenter as b  on b.PK_psDatacenter = a.PK_psPersonalData 
                                left outer join dbo.emdDoctors AS c ON c.PK_emdDoctors = a.PK_psPersonalData
                                left outer join dbo.emdTempSpecializations AS d ON d.PK_emdTempSpecializations = c.FK_emdTempSpecializations " & whereClause & " ORDER BY b.fullname ASC"
            For x As Integer = 0 To kwords.Length - 1
                Dim wrd As String = kwords(x).Trim
                If wrd.Length > 0 Then
                    If Not cmd.Parameters.Contains("@kw" & x) Then
                        cmd.Parameters.AddWithValue("@kw" & x, "%" + wrd + "%")
                    End If
                End If
            Next
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim doctors As New List(Of ReferringConsultant)
                For Each row As DataRow In data.Rows
                    Dim doctor As New ReferringConsultant
                    doctor.ID = row("PK_psPersonalData")
                    doctor.Fullname = row("fullname")
                    doctor.FirstName = row("firstname")
                    doctor.MiddleName = If(Not IsDBNull(row("middlename")), row("middlename"), "")
                    doctor.LastName = row("lastname")
                    doctor.PRC = If(Not IsDBNull(row("prcno")), row("prcno"), "")
                    doctor.PTR = If(Not IsDBNull(row("ptrno")), row("ptrno"), "")
                    doctor.S2No = If(Not IsDBNull(row("s2no")), row("s2no"), "")
                    doctor.PrimaryMobile = If(Not IsDBNull(row("cptelefax")), row("cptelefax"), "")
                    doctor.SecondaryMobile = If(Not IsDBNull(row("nktelefax")), row("nktelefax"), "")
                    doctor.Specialization = If(Not IsDBNull(row("description")), row("description"), "NOT INDICATED")
                    doctors.Add(doctor)
                Next
                Return doctors
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxTrasactionHistory(fkid As Long) As List(Of PatientBixbox_PatRegisters)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[psPatRegisters] WHERE FK_emdPatients = @ID ORDER BY PK_psPatRegisters DESC"
            cmd.Parameters.AddWithValue("@ID", fkid)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBixbox_PatRegisters)
                For Each row As DataRow In data.Rows
                    Dim diagnosticController As New DiagnosticsController
                    Dim reg As New PatientBixbox_PatRegisters
                    reg.PK_psPatRegisters = row("PK_psPatRegisters")
                    reg.RegistryNo = row("registryno")
                    reg.RegistryDate = row("registrydate")
                    reg.FK_emdPatients = row("FK_emdPatients")
                    reg.Diagnostics = diagnosticController.GetCertainDiagnostics(reg.PK_psPatRegisters)
                    reg.PatItems_Rendered = GetCertainPatRegisterItems_All(reg.PK_psPatRegisters)
                    reg.PatItems_Requested = GetCertainPatRegisterItems_Requested(reg.PK_psPatRegisters)
                    lisOfTransactions.Add(reg)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxTrasaction(psPatReg As Long) As PatientBixbox_PatRegisters
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT TOP 1 * FROM [dbo].[psPatRegisters] WHERE PK_psPatRegisters = @ID ORDER BY PK_psPatRegisters DESC"
            cmd.Parameters.AddWithValue("@ID", psPatReg)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim diagnosticController As New DiagnosticsController
                Dim reg As New PatientBixbox_PatRegisters
                reg.PK_psPatRegisters = data.Rows(0)("PK_psPatRegisters")
                reg.RegistryNo = data.Rows(0)("registryno")
                reg.RegistryDate = data.Rows(0)("registrydate")
                reg.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                reg.Diagnostics = diagnosticController.GetCertainDiagnostics(reg.PK_psPatRegisters)
                reg.PatItems_Rendered = GetCertainPatRegisterItems_All(reg.PK_psPatRegisters)
                reg.PatItems_Requested = GetCertainPatRegisterItems_Requested(reg.PK_psPatRegisters)
                Return reg
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxLatestTrasaction(fkid As Long) As PatientBixbox_PatRegisters
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT TOP 1 * FROM [dbo].[psPatRegisters] WHERE FK_emdPatients = @ID ORDER BY PK_psPatRegisters DESC"
            cmd.Parameters.AddWithValue("@ID", fkid)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim diagnosticController As New DiagnosticsController
                Dim reg As New PatientBixbox_PatRegisters
                reg.PK_psPatRegisters = data.Rows(0)("PK_psPatRegisters")
                reg.RegistryNo = data.Rows(0)("registryno")
                reg.RegistryDate = data.Rows(0)("registrydate")
                reg.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                reg.Diagnostics = diagnosticController.GetCertainDiagnostics(reg.PK_psPatRegisters)
                reg.PatItems_Rendered = GetCertainPatRegisterItems_All(reg.PK_psPatRegisters)
                reg.PatItems_Requested = GetCertainPatRegisterItems_Requested(reg.PK_psPatRegisters)
                Return reg
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatientBizboxLatestCurrentTrasaction(fkid As Long) As PatientBixbox_PatRegisters
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT TOP 1 * FROM [dbo].[psPatRegisters] WHERE CONVERT(DATE,[registrydate]) = CONVERT(DATE,GETDATE()) AND FK_emdPatients = @ID ORDER BY PK_psPatRegisters DESC"
            cmd.Parameters.AddWithValue("@ID", fkid)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Dim diagnosticController As New DiagnosticsController
                    Dim reg As New PatientBixbox_PatRegisters
                    reg.PK_psPatRegisters = data.Rows(0)("PK_psPatRegisters")
                    reg.RegistryNo = data.Rows(0)("registryno")
                    reg.RegistryDate = data.Rows(0)("registrydate")
                    reg.FK_emdPatients = data.Rows(0)("FK_emdPatients")
                    reg.Diagnostics = diagnosticController.GetCertainDiagnostics(reg.PK_psPatRegisters)
                    reg.PatItems_Rendered = GetCertainPatRegisterItems_All(reg.PK_psPatRegisters)
                    reg.PatItems_Requested = GetCertainPatRegisterItems_Requested(reg.PK_psPatRegisters)
                    Return reg
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatRegisterItems_Rendered(ID As Long) As List(Of PatientBizbox_PatItems)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[psPatitem] as a 
                                JOIN [dbo].[psPatRegisters] as b on b.PK_psPatRegisters = a.FK_psPatRegisters 
                                LEFT JOIN [dbo].[iwItems] as c on c.PK_iwItems = a.FK_iwItemsREN
								LEFT JOIN [dbo].[mscItemCategory] as d on d.PK_mscItemCategory = c.FK_mscItemCategory 
                                WHERE FK_psPatRegisters = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBizbox_PatItems)
                For Each row As DataRow In data.Rows
                    Dim transaction As New PatientBizbox_PatItems
                    transaction.PK_psPatItems = row("PK_psPatitem")
                    transaction.FK_iwItemsREN = row("FK_iwItemsREN")
                    transaction.ItemDescription = If(Not IsDBNull(row("itemdesc")), row("itemdesc"), "")
                    transaction.ItemAbbreviation = If(Not IsDBNull(row("itemabbrev")), row("itemabbrev"), "")
                    transaction.ItemPreparation = If(Not IsDBNull(row("specs")), row("specs"), "")
                    transaction.DepartmentOfService = If(Not IsDBNull(row("description")), row("description"), "")
                    transaction.RequestPrice = row("reqprice")
                    transaction.RequestQTY = row("reqqty")
                    transaction.RenderPrice = row("renprice")
                    transaction.RenderQTY = row("renqty")
                    transaction.isRendered = If(row("renqty") > 0, True, False)
                    lisOfTransactions.Add(transaction)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatRegisterItems_Requested(ID As Long) As List(Of PatientBizbox_PatItems)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[psPatitem] as a 
                                JOIN [dbo].[psPatRegisters] as b on b.PK_psPatRegisters = a.FK_psPatRegisters 
                                LEFT JOIN [dbo].[iwItems] as c on c.PK_iwItems = a.FK_iwItemsREQ
								LEFT JOIN [dbo].[mscItemCategory] as d on d.PK_mscItemCategory = c.FK_mscItemCategory 
                                WHERE FK_psPatRegisters = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBizbox_PatItems)
                For Each row As DataRow In data.Rows
                    Dim transaction As New PatientBizbox_PatItems
                    transaction.PK_psPatItems = row("PK_psPatitem")
                    transaction.FK_iwItemsREN = If(Not IsDBNull(row("FK_iwItemsREN")), row("FK_iwItemsREN"), 0)
                    transaction.ItemDescription = If(Not IsDBNull(row("itemdesc")), row("itemdesc"), "")
                    transaction.ItemAbbreviation = If(Not IsDBNull(row("itemabbrev")), row("itemabbrev"), "")
                    transaction.ItemPreparation = If(Not IsDBNull(row("specs")), row("specs"), "")
                    transaction.DepartmentOfService = If(Not IsDBNull(row("description")), row("description"), "")
                    transaction.RequestPrice = row("reqprice")
                    transaction.RequestQTY = row("reqqty")
                    transaction.RenderPrice = If(Not IsDBNull(row("renprice")), row("renprice"), 0)
                    transaction.RenderQTY = If(Not IsDBNull(row("renqty")), row("renqty"), 0)
                    transaction.isRendered = If(row("renflag") > 0, True, False)
                    lisOfTransactions.Add(transaction)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetCertainPatRegisterItems_All(ID As Long) As List(Of PatientBizbox_PatItems)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT PK_psPatitem,FK_iwItemsREN,FK_iwItemsREQ,
                                x.itemdesc as 'renitemdesc',x.itemabbrev as 'renitemabbrev',x.specs as 'renspecs',
                                c.itemdesc as 'reqitemdesc',c.itemabbrev as 'reqitemabbrev',c.specs as 'reqspecs',
                                description,reqprice,reqqty,renprice,renqty,renflag,z.cancelflag as 'reqCancelled'
                                  FROM [dbo].[psPatitem] as a 
                                JOIN [dbo].[psPatRegisters] as b on b.PK_psPatRegisters = a.FK_psPatRegisters 
                                LEFT JOIN [dbo].[iwItems] as c on c.PK_iwItems = a.FK_iwItemsREN
							    LEFT JOIN [dbo].[iwItems] as x on x.PK_iwItems = a.FK_iwItemsREQ
							    LEFT JOIN [dbo].[mscItemCategory] as d on d.PK_mscItemCategory = c.FK_mscItemCategory
								LEFT JOIN [dbo].[psPatinv] as z on z.PK_TRXNO = a.FK_TRXNO
                                WHERE renqty >= 0 AND a.FK_psPatRegisters = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd, openDatabaseBizbox).Tables(0)
            If Not IsNothing(data) Then
                Dim lisOfTransactions As New List(Of PatientBizbox_PatItems)
                For Each row As DataRow In data.Rows
                    Dim transaction As New PatientBizbox_PatItems
                    transaction.PK_psPatItems = row("PK_psPatitem")
                    transaction.FK_iwItemsREN = If(Not IsDBNull(row("FK_iwItemsREN")), row("FK_iwItemsREN"), row("FK_iwItemsREQ"))
                    transaction.ItemDescription = If(Not IsDBNull(row("renitemdesc")), row("renitemdesc"), row("reqitemdesc"))
                    transaction.ItemAbbreviation = If(Not IsDBNull(row("renitemabbrev")), row("renitemabbrev"), row("reqitemabbrev"))
                    transaction.ItemPreparation = If(Not IsDBNull(row("renspecs")), row("renspecs"), If(Not IsDBNull(row("reqspecs")), row("reqspecs"), ""))
                    transaction.RequestPrice = If(Not IsDBNull(row("reqprice")), row("reqprice"), 0)
                    transaction.RequestQTY = If(Not IsDBNull(row("reqqty")), row("reqqty"), 0)
                    transaction.RenderPrice = If(Not IsDBNull(row("renprice")), row("renprice"), 0)
                    transaction.RenderQTY = If(Not IsDBNull(row("renqty")), row("renqty"), 0)
                    transaction.isRequestCancelled = If(Not IsDBNull(row("reqCancelled")), row("reqCancelled"), 0)
                    transaction.isRendered = row("renflag")
                    lisOfTransactions.Add(transaction)
                Next
                Return lisOfTransactions
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CheckIfSMSAlreadyCache(ID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[smsnotifications] WHERE patient_customerassigncounter_id = @ID"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CacheSMSSender(sms As SMSNotification) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[smsnotifications] ([smsbody] ,[smscontact] ,[patient_customerassigncounter_id] ,[sender_servertransaction_id] ,[receiver_server_id])
                               VALUES
                               (@smsbd,@smscnt,@ctmrassgnctrid,@srvrtnsid,@srvrid);"
            cmd.Parameters.AddWithValue("@smsbd", sms.SMSBody)
            cmd.Parameters.AddWithValue("@smscnt", sms.SMSContact)
            cmd.Parameters.AddWithValue("@ctmrassgnctrid", sms.Patient_CustomerAssignCounter_ID)
            cmd.Parameters.AddWithValue("@srvrtnsid", sms.Sender_ServerTransaction_ID)
            cmd.Parameters.AddWithValue("@srvrid", sms.Receiver_Server_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ConvertContact(oldContact As String) As String
        If oldContact.Substring(0, 2).Contains("09") And oldContact.Length = 11 Then
            Return "63" & oldContact.Substring(1, oldContact.Length - 1)
        ElseIf oldContact.Substring(0, 1).Contains("9") And oldContact.Length = 10 Then
            Return "63" & oldContact
        Else
            Return oldContact
        End If
    End Function
End Class
