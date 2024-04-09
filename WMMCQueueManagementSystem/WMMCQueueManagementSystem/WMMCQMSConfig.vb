Imports System.Data.SqlClient
Imports MySqlConnector

Module WMMCQMSConfig
    Private _loggedServer As ServerTransaction
    Private tmpServer As Server
    Public isWebAvailable As Boolean = False
    Public SignatureLicense As String = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA"

    Public Property CounterImageIconsXXLg As ImageList
    Public Property CounterImageIconsExLg As ImageList
    Public Property CounterImageIconsLg As ImageList
    Public Property CounterImageIconsMd As ImageList
    Public Property CounterImageIconsSm As ImageList
    Public Property CustomImageIconsXXLg As ImageList
    Public Property CustomImageIconsLg As ImageList
    Private OSK As Process = Nothing

    Public Property LoggedServer As ServerTransaction
        Get
            Return _loggedServer
        End Get
        Private Set(value As ServerTransaction)
            Try
                _loggedServer = value
                If Not IsNothing(_loggedServer) Then
                    My.Settings.loggedServerTransaction = LoggedServer.ServerTransaction_ID
                Else
                    My.Settings.loggedServerTransaction = 0
                End If
                My.Settings.Save()
            Catch ex As Exception
                _loggedServer = Nothing
                MessageBox.Show(ex.ToString, "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Set
    End Property

    Public Function LogoutUser() As Boolean
        Try
            If Not IsNothing(LoggedServer) Then
                Dim serverTransactionController As New ServerTransactionController
                If serverTransactionController.LogoutSession(LoggedServer.ServerTransaction_ID) Then
                    LoggedServer = Nothing
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Sub Main() ' This line here is where the system start.
line1:
        Dim connString As String = connectionString()
        If TryConnection(connString) Then
            If My.Settings.loggedServerTransaction > 0 Then
                Dim ServerTransactionController As New ServerTransactionController
                LoggedServer = ServerTransactionController.GetCertainServerTransaction2(My.Settings.loggedServerTransaction)
                If Not IsNothing(LoggedServer) Then
                    If Not LogoutUser() Then
                        GoTo line1
                    End If
                End If
            End If
            Dim frmLogin As New frmLogin
            frmLogin.ShowDialog()
            If frmLogin.DialogResult = DialogResult.Yes Then
                If frmLogin.AdminLogin Then
                    If frmLogin.DialogResult = DialogResult.Yes Then
                        Dim frm As New frmAdminHome
                        frm.ShowDialog()
                    End If
                    GoTo line1
                Else
                    If Not IsNothing(frmLogin.LoggedUser) Then
                        tmpServer = frmLogin.LoggedUser
line2:
                        Dim frmLogSelection As New frmLoginSelection(tmpServer)
                        frmLogSelection.ShowDialog()
                        If frmLogSelection.DialogResult = DialogResult.Yes Then
                            LoggedServer = frmLogSelection.ServerTransaction
                            If LoggedServer.ServerAssignCounter.isMain Then
                                If LoggedServer.ServerAssignCounter.Counter.isSoloCounter Then
                                    Dim frmSoloQiosk As New frmHomeCounterSolo
                                    frmSoloQiosk.ShowDialog()
                                    If frmSoloQiosk.DialogResult = DialogResult.Abort Then
                                        GoTo endline
                                    ElseIf frmSoloQiosk.DialogResult = DialogResult.Retry Then
                                        tmpServer = frmSoloQiosk.Server
                                        GoTo line2
                                    End If
                                Else
                                    Dim frmMainQiosk As New frmHomeMainCounterForTouch
                                    frmMainQiosk.ShowDialog()
                                    If frmMainQiosk.DialogResult = DialogResult.Abort Then
                                        GoTo endline
                                    ElseIf frmMainQiosk.DialogResult = DialogResult.Retry Then
                                        tmpServer = frmMainQiosk.Server
                                        GoTo line2
                                    End If
                                End If
                            Else
                                If LoggedServer.ServerAssignCounter.Server.AccountType > 0 Then
                                    Dim frmClinicCounter As New frmServiceCounter_Clinic
                                    frmClinicCounter.ShowDialog()
                                    If frmClinicCounter.DialogResult = DialogResult.Abort Then
                                        GoTo endline
                                    ElseIf frmClinicCounter.DialogResult = DialogResult.Retry Then
                                        GoTo line2
                                    End If
                                Else
                                    Dim frmPCCCounter As New frmServiceCounter
                                    frmPCCCounter.ShowDialog()
                                    If frmPCCCounter.DialogResult = DialogResult.Abort Then
                                        GoTo endline
                                    ElseIf frmPCCCounter.DialogResult = DialogResult.Retry Then
                                        tmpServer = frmPCCCounter.Server
                                        GoTo line2
                                    End If
                                End If
                            End If
                        ElseIf frmLogSelection.DialogResult = DialogResult.Abort Then
                            GoTo endline
                        End If
                        GoTo line1
                    End If
                End If
            End If
        Else
            MessageBox.Show("Cannot Connect to the Server. Please check your network connection and try again", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
endline:
    End Sub

    Private Function connectionString() As String
        If My.Settings.isLive Then 'Live Database
            Return "Data Source=hhmh-s-bb; User ID=sa; Initial Catalog=hhmhqueueingdb;Password=@Letmein.2023;"
        Else 'Testing Database
            Return "Data Source=hhmh-bb; User ID=sa; Initial Catalog=hhmhqueueingdb;Password=@Letmein.2023;"
        End If
    End Function

    Private Function sqlconnectionString() As String
        If My.Settings.isLive Then 'Live Database
            Return "Data Source=hhmh-s-bb;User ID=sa;Initial Catalog=HISPRDDTA;Password=@Letmein.2023;"
        Else 'Testing Database
            Return "Data Source=hhmh-bb; User ID=sa; Initial Catalog=hhmhqueueingdb;Password=@Letmein.2023;"
        End If
    End Function

    Private Function medexConnectionString() As String
        Return "Enter your MedExpress Connection Here"
    End Function

    Private Function webConnectionString() As String
        Return "Enter Your Web Server Connection Here"
    End Function

    Public Function TryConnection(connString As String) As Boolean
        Dim conn As New SqlConnection
        Try
            conn.ConnectionString = connString
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Return True
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function TryConnection_Web(connString As String) As Boolean
        Dim conn As New MySqlConnection
        Try
            conn.ConnectionString = connString
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Return True
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    'Queuing Connection
    Public Function openDatabase() As SqlConnection
        Try
            Dim conn As New SqlConnection
            conn.ConnectionString = connectionString()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Return conn
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function excecuteCommand(cmd As SqlCommand) As Boolean
        Dim conn = openDatabase()
        Try
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function
    Public Function excecuteCommandReturnID(cmd As SqlCommand) As Long

        Dim conn = openDatabase()
        Dim x As SqlTransaction = conn.BeginTransaction()
        cmd.Transaction = x
        Try
            Dim id As Long = -1
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                id = cmd.ExecuteScalar()
            End If
            x.Commit()
            Return id
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return -1
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function excecuteMultipleCommand(cmds As List(Of SqlCommand)) As Boolean
        Dim conn = openDatabase()
        Dim x As SqlTransaction = conn.BeginTransaction()
        Try
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                For Each cmd As SqlCommand In cmds
                    cmd.Transaction = x
                    cmd.Connection = conn
                    cmd.ExecuteNonQuery()
                Next
                x.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function fetchData(cmd As SqlCommand) As DataSet
        Dim conn = openDatabase()
        Try
            Dim adapter As New SqlDataAdapter
            Dim datas As New DataSet

            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                adapter.SelectCommand = cmd
                adapter.Fill(datas)
                Return datas
            Else
                Return Nothing
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    'Modified Connection
    Public Function openDatabaseBizbox() As SqlConnection
        Try
            Dim conn As New SqlConnection
            conn.ConnectionString = sqlconnectionString()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Return conn
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function openDatabaseMedExpress() As SqlConnection
        Try
            Dim conn As New SqlConnection
            conn.ConnectionString = medexConnectionString()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Return conn
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function openDatabaseWeb() As MySqlConnection
        Try
            Dim conn As New MySqlConnection
            conn.ConnectionString = webConnectionString()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Return conn
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function excecuteCommand(cmd As SqlCommand, selectedConnection As SqlConnection) As Boolean
        Dim conn = selectedConnection
        Try
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function excecuteCommandReturnID(cmd As SqlCommand, selectedConnection As SqlConnection) As Long
        Dim conn = selectedConnection
        Dim x As SqlTransaction = conn.BeginTransaction()
        cmd.Transaction = x
        Try
            Dim id As Long = -1
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                id = cmd.ExecuteScalar()
            End If
            x.Commit()
            Return id
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return -1
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function excecuteMultipleCommand(cmds As List(Of SqlCommand), selectedConnection As SqlConnection) As Boolean
        Dim conn = selectedConnection
        Dim x As SqlTransaction = conn.BeginTransaction()
        Try

            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                For Each cmd As SqlCommand In cmds
                    cmd.Transaction = x
                    cmd.Connection = conn
                    cmd.ExecuteNonQuery()
                Next
                x.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function fetchData(cmd As SqlCommand, selectedConnection As SqlConnection) As DataSet
        Dim conn = selectedConnection
        Try
            Dim adapter As New SqlDataAdapter
            Dim datas As New DataSet
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                adapter.SelectCommand = cmd
                adapter.Fill(datas)
                Return datas
            Else
                Return Nothing
            End If
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    ' Web Commands
    Public Function excecuteCommand(cmd As MySqlCommand, selectedConnection As MySqlConnection) As Boolean
        Dim conn = selectedConnection
        Try
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                cmd.ExecuteNonQuery()
                Return True
            Else
                Return False
            End If
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function excecuteCommandReturnID(cmd As MySqlCommand, selectedConnection As MySqlConnection) As Long
        Dim conn = selectedConnection
        Dim x As MySqlTransaction = conn.BeginTransaction()
        cmd.Transaction = x
        Try
            Dim id As Long = -1
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                id = cmd.ExecuteScalar()
            End If
            x.Commit()
            Return id
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return -1
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function excecuteMultipleCommand(cmds As List(Of MySqlCommand), selectedConnection As MySqlConnection) As Boolean
        Dim conn = selectedConnection
        Dim x As MySqlTransaction = conn.BeginTransaction()
        Try

            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                For Each cmd As MySqlCommand In cmds
                    cmd.Transaction = x
                    cmd.Connection = conn
                    cmd.ExecuteNonQuery()
                Next
                x.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            x.Rollback()
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function fetchData(cmd As MySqlCommand, selectedConnection As MySqlConnection) As DataSet
        Dim conn = selectedConnection
        Try
            Dim adapter As New MySqlDataAdapter
            Dim datas As New DataSet
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                cmd.Connection = conn
                adapter.SelectCommand = cmd
                adapter.Fill(datas)
                Return datas
            Else
                Return Nothing
            End If
        Catch ex As MySqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function


    Public Function TestConn(str As String) As Boolean
        Dim conn = openDatabase()
        Try
            Dim adapter As New SqlDataAdapter
            Dim datas As New DataSet

            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = str
            conn.Open()
            Return True
        Catch ex As SqlException
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Finally
            If conn.State = ConnectionState.Open And Not (IsNothing(conn)) Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function UseDefaultDatabaseConnection() As Boolean
        Try
            My.Settings.Reset()
            Return True
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Sub OpenOnScreenKeyboard()
        'OSK = Process.Start("C:\Windows\System32\OSK.EXE")
    End Sub

    Public Sub CloseOnScreenKeyboard()
        If Not IsNothing(OSK) Then
            Try
                OSK.Kill()
            Catch ex As Exception
                'OSK Already Killed
            Finally
                OSK = Nothing
            End Try

        End If
    End Sub

    Public Property BeepVoice() As Boolean
        Get
            Return My.Settings.voice
        End Get
        Set(value As Boolean)
            My.Settings.voice = value
            My.Settings.Save()
        End Set
    End Property

    Public Property AutoRefreshQueueList() As Boolean
        Get
            Return My.Settings.AutoRefreshQueueList
        End Get
        Set(value As Boolean)
            My.Settings.AutoRefreshQueueList = value
            My.Settings.Save()
        End Set
    End Property

    Public Property VoiceSetting() As VoiceModel
        Get
            Dim voiceModel As New VoiceModel
            voiceModel.BeepAndVoice = My.Settings.voice
            voiceModel.VoiceVolume = My.Settings.VoiceVolume
            voiceModel.VoiceGenderMale = My.Settings.VoiceGenderMale
            voiceModel.VoiceSpeed = My.Settings.VoiceSpeed
            voiceModel.Mute = My.Settings.Mute
            Return voiceModel
        End Get
        Set(value As VoiceModel)
            My.Settings.voice = value.BeepAndVoice
            My.Settings.VoiceVolume = value.VoiceVolume
            My.Settings.VoiceGenderMale = value.VoiceGenderMale
            My.Settings.VoiceSpeed = value.VoiceSpeed
            My.Settings.Mute = value.Mute
            My.Settings.Save()
        End Set
    End Property

    Public Property QRInputDevice() As Long
        Get
            Return My.Settings.QRInputDevice
        End Get
        Set(value As Long)
            My.Settings.QRInputDevice = value
            My.Settings.Save()
        End Set
    End Property

    Public Property WebCamDevice() As Long
        Get
            Return My.Settings.WebCamDevice
        End Get
        Set(value As Long)
            My.Settings.WebCamDevice = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SignatureDevice() As Long
        Get
            Return My.Settings.SignaturePadDevice
        End Get
        Set(value As Long)
            My.Settings.SignaturePadDevice = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SystemIsLive As Boolean
        Get
            Return My.Settings.isLive
        End Get
        Set(value As Boolean)
            My.Settings.isLive = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SystemVersion As String
        Set(value As String)

        End Set
        Get
            Try
                Return My.Application.Deployment.CurrentVersion.ToString
            Catch ex As Exception
                Return "DEBUG MODE"
            End Try
        End Get
    End Property

    Public Property SavedCounterName As String
        Get
            Return My.Settings.CounterName
        End Get
        Set(value As String)
            My.Settings.CounterName = value
            My.Settings.Save()
        End Set
    End Property

    Public Property SavedCounterBoard As CounterBoard
        Get
            Dim counterBoard As New CounterBoard
            counterBoard.CounterBoard_ID = My.Settings.PrevCounterBoardID
            counterBoard.Counter_ID = My.Settings.PrevCounterID
            counterBoard.DisplayedName = My.Settings.CounterName
            Return counterBoard
        End Get
        Set(value As CounterBoard)
            My.Settings.PrevCounterBoardID = value.CounterBoard_ID
            My.Settings.PrevCounterID = value.Counter_ID
            My.Settings.CounterName = value.DisplayedName
            My.Settings.Save()
        End Set
    End Property

    Public Function TemplateFormLocation() As String
        If My.Settings.isLive Then
            Return "\\192.168.11.2\update\QMS\hhmh_files\template_forms\"
        Else
            Return "D:\Deploy Apps\HHMHQMS\hhmh_files\template_forms\"
        End If
    End Function

    Public Function SaveFormLocation() As String
        If My.Settings.isLive Then
            Return "\\192.168.11.2\update\QMS\hhmh_files\patient_forms\"
        Else
            Return "D:\Deploy Apps\HHMHQMS\hhmh_files\patient_forms\"
        End If
    End Function

    Public Function DoctorHeaderLocation() As String
        If My.Settings.isLive Then
            Return "\\192.168.11.2\update\QMS\hhmh_files\doctors_headers\"
        Else
            Return "D:\Deploy Apps\HHMHQMS\hhmh_files\doctors_headers"
        End If
    End Function

    Public Function DoctorSignatureLocation() As String
        If My.Settings.isLive Then
            Return "\\192.168.11.2\update\QMS\hhmh_files\doctors_signatures\"
        Else
            Return "D:\Deploy Apps\HHMHQMS\hhmh_files\doctors_signatures"
        End If
    End Function

End Module
