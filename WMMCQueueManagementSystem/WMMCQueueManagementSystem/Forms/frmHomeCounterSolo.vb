Public Class frmHomeCounterSolo
    Private _loggedServer As Server
    Private SelectedCounter As Counter
    Private WithEvents frmX As New Form
    Private WithEvents frmY As New Form
    Private WithEvents frmZ As New Form
    Private _language As Boolean = False
    Private _generateScreening As Boolean = False
    Declare Auto Function SetDefaultPrinter Lib "winspool.drv" (ByVal pszPrinter As String) As Boolean

    Public Property Server As Server
        Get
            Return _loggedServer
        End Get
        Private Set(value As Server)
            _loggedServer = value
        End Set
    End Property

    Private Sub GetCounterToView()
        If _language Then
            btnToogleLanguage.Text = "ENGLISH"
        Else
            btnToogleLanguage.Text = "TAGALOG"
        End If
        Dim imgs1 As New ImageList
        For Each img As Image In CounterImageIconsXXLg.Images
            imgs1.Images.Add(img)
        Next
        imgs1.Images.Add(CustomImageIconsXXLg.Images(0))
        imgs1.ColorDepth = ColorDepth.Depth32Bit
        imgs1.ImageSize = New Size(250, 250)
        lstFetchCounter.Items.Clear()
        lstFetchCounter.LargeImageList = imgs1
retryselection:
        Dim frm As New frmSelectQiosk
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            Me.SelectedCounter = frm.SelecedQueueCounter
            If Me.SelectedCounter.CounterType = 0 Then
                lstFetchCounter.Items.Add(If(_language, Me.SelectedCounter.ServiceDescription2.Trim.ToUpper, Me.SelectedCounter.ServiceDescription.Trim.ToUpper), If(Me.SelectedCounter.Icon > CounterImageIconsLg.Images.Count, 0, Me.SelectedCounter.Icon))
            End If
        Else
            MessageBox.Show("Please select a counter view", "No Counter Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GoTo retryselection
        End If
    End Sub

    Private Sub GenerateQueueNumber()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Long = lstFetchCounter.SelectedIndices(0)
            Dim selectedCounter As Counter = Me.SelectedCounter
            Dim customerAssignCounterController As New CustomerAssignCounterController
            progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
            printProgress.Value = 10
            pnlProgress.Show()
            Dim customerAssignCounter As New CustomerAssignCounter
            customerAssignCounter.Priority = 0
            customerAssignCounter.ForHelee = 0
            customerAssignCounter.Counter = selectedCounter
            customerAssignCounter.Customer = New Customer
            customerAssignCounter.Customer.FullName = Nothing
            customerAssignCounter.Customer.FK_emdPatients = Nothing
            customerAssignCounter.Customer.PhoneNumber = Nothing
            customerAssignCounter.Customer.CustomerInfo = Nothing
            printProgress.Value = 30
            Dim generatedNumber As String = customerAssignCounterController.GenerateQueueNumber_TemporaryCustomer(customerAssignCounter)
            If Not IsNothing(generatedNumber) Then
                lstFetchCounter.Select()
PrintNormalNumber:
                Try
                    Dim reportDocs As New ticketNoReport
                    Dim dt As New DataTable
                    With dt.Columns
                        .Add("ticketNo")
                        .Add("patName")
                        .Add("counter")
                        .Add("note")
                    End With
                    With dt.Rows
                        .Add(generatedNumber.Trim.ToUpper, "", ("THIS IS YOUR NUMBER FOR " & customerAssignCounter.Counter.ServiceDescription).Trim.ToUpper, ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper)
                    End With
                    reportDocs.SetDataSource(dt)
                    printProgress.Value = 60
                    progressText.Text = "PRINTING NUMBER..."
                    reportDocs.PrintToPrinter(1, False, 0, 0)
                    reportDocs.Close()
                Catch ex As Exception
                    MessageBox.Show("There was some error encountered during the printing process: " + ex.ToString, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If MessageBox.Show("Do you want retry printing again?", "Re-print Number", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        GoTo PrintNormalNumber
                    End If
                Finally
                    progressText.Text = "DONE"
                    printProgress.Value = 100
                    pnlProgress.Hide()
                    pnlConfirmGenerateNumber.Hide()
                End Try
            Else
                MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub GenerateNormalNumber()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Long = lstFetchCounter.SelectedIndices(0)
            Dim selectedCounter As Counter = Me.SelectedCounter
            Dim customerInfo As CustomerInfo = CustomerLookup2()
            If Not IsNothing(customerInfo) Then
                With customerInfo.HealthCheck
                    .PurposeOfVisit = selectedCounter.ServiceDescription
                End With
                Dim customerAssignCounterController As New CustomerAssignCounterController
                progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
                printProgress.Value = 10
                pnlProgress.Show()
                Dim customerAssignCounter As New CustomerAssignCounter
                customerAssignCounter.Priority = 0
                customerAssignCounter.ForHelee = 0
                customerAssignCounter.Counter = selectedCounter
                customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
                customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
                customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
                customerAssignCounter.Customer.CustomerInfo = customerInfo
                printProgress.Value = 30
                Dim generatedNumber As String = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
                If Not IsNothing(generatedNumber) Then
                    lstFetchCounter.Select()
PrintNormalNumber:
                    Try
                        Dim reportDocs As New ticketNoReport
                        Dim dt As New DataTable
                        With dt.Columns
                            .Add("ticketNo")
                            .Add("patName")
                            .Add("counter")
                            .Add("note")
                        End With
                        With dt.Rows
                            .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("THIS IS YOUR NUMBER FOR " & customerAssignCounter.Counter.ServiceDescription).Trim.ToUpper, ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper)
                        End With
                        reportDocs.SetDataSource(dt)
                        printProgress.Value = 60
                        progressText.Text = "PRINTING NUMBER..."
                        reportDocs.PrintToPrinter(1, False, 0, 0)
                        reportDocs.Close()
                    Catch ex As Exception
                        MessageBox.Show("There was some error encountered during the printing process: " + ex.ToString, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If MessageBox.Show("Do you want retry printing again?", "Re-print Number", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            GoTo PrintNormalNumber
                        End If
                    Finally
                        progressText.Text = "DONE"
                        printProgress.Value = 100
                        pnlProgress.Hide()
                    End Try
                Else
                    MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a counter first before generating a number", "No Counter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function CustomerLookup2() As CustomerInfo
repeat:
        Dim customerInfo As CustomerInfo = Nothing
        Dim frmFind As New frmFindPatient_Touch
        frmFind.ShowDialog()
        If frmFind.DialogResult = DialogResult.Yes Then
            Dim frmFound As New frmFoundPatientList_Touch(frmFind.MatchedData)
            frmFound.ShowDialog()
            If frmFound.DialogResult = DialogResult.Yes Then
                Dim frmProfiling As New frmPatientProfiling_Touch(frmFound.SelectedCustomer)
                frmProfiling.ShowDialog(Me)
                If frmProfiling.DialogResult = DialogResult.Yes Then
                    If Not IsNothing(frmProfiling.CustomerProfile) Then
                        customerInfo = frmProfiling.CustomerProfile
                        If Not _generateScreening Then
                            Dim hc As New HealthCheck
                            customerInfo.HealthCheck = hc
                            Return customerInfo
                        Else
                            Dim frmHealthCheck As New frmHealthCheck_Touch
                            frmHealthCheck.ShowDialog(Me)
                            If frmHealthCheck.DialogResult = DialogResult.Yes Then
                                If Not IsNothing(frmHealthCheck.PatientHealthCheck) Then
                                    customerInfo.HealthCheck = frmHealthCheck.PatientHealthCheck
                                    Return customerInfo
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf frmFound.DialogResult = DialogResult.No Then
                Dim fname As String = ""
                Dim mname As String = ""
                Dim lname As String = ""
                Dim bday As Date = Now
                If Not IsNothing(frmFind.TemporaryData) Then
                    Dim tmpData As CustomerInfo = frmFind.TemporaryData
                    fname = tmpData.FirstName
                    mname = tmpData.Middlename
                    lname = tmpData.Lastname
                    bday = tmpData.BirthDate
                End If
                Dim frmProfiling As New frmPatientProfiling_Touch(fname, mname, lname, bday)
                frmProfiling.ShowDialog(Me)
                If frmProfiling.DialogResult = DialogResult.Yes Then
                    If Not IsNothing(frmProfiling.CustomerProfile) Then
                        customerInfo = frmProfiling.CustomerProfile
                        If Not _generateScreening Then
                            Dim hc As New HealthCheck
                            customerInfo.HealthCheck = hc
                            Return customerInfo
                        Else
                            Dim frmHealthCheck As New frmHealthCheck_Touch
                            frmHealthCheck.ShowDialog(Me)
                            If frmHealthCheck.DialogResult = DialogResult.Yes Then
                                If Not IsNothing(frmHealthCheck.PatientHealthCheck) Then
                                    customerInfo.HealthCheck = frmHealthCheck.PatientHealthCheck
                                    Return customerInfo
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                GoTo repeat
            End If
        ElseIf frmFind.DialogResult = DialogResult.OK Then
            Dim frmProfiling As New frmPatientProfiling_Touch(frmFind.TemporaryData.FirstName, frmFind.TemporaryData.Middlename, frmFind.TemporaryData.Lastname, frmFind.TemporaryData.BirthDate)
            frmProfiling.ShowDialog(Me)
            If frmProfiling.DialogResult = DialogResult.Yes Then
                If Not IsNothing(frmProfiling.CustomerProfile) Then
                    customerInfo = frmProfiling.CustomerProfile
                    If Not _generateScreening Then
                        Dim hc As New HealthCheck
                        customerInfo.HealthCheck = hc
                        Return customerInfo
                    Else
                        Dim frmHealthCheck As New frmHealthCheck_Touch
                        frmHealthCheck.ShowDialog(Me)
                        If frmHealthCheck.DialogResult = DialogResult.Yes Then
                            If Not IsNothing(frmHealthCheck.PatientHealthCheck) Then
                                customerInfo.HealthCheck = frmHealthCheck.PatientHealthCheck
                                Return customerInfo
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub frmHomeCounterSolo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCounterToView()
        Timer1.Start()
    End Sub

    Private Sub lstFetchCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFetchCounter.SelectedIndexChanged

    End Sub

    Private Sub tsExit_Click(sender As Object, e As EventArgs) Handles tsExit.Click
        If MessageBox.Show("Are you sure to close this program?", "Close Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Abort
            Application.Exit()
        End If
    End Sub

    Private Sub tsLogout_Click(sender As Object, e As EventArgs) Handles tsLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ChangeCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeCounterToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to change the current counter you're logging in?", "Change Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim serverController As New ServerController
            Server = serverController.GetCertainServer(LoggedServer.ServerAssignCounter.Server.Server_ID)
            Me.DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub MinimizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeToolStripMenuItem.Click
        If Not Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsTime.Text = TimeOfDay
        tsDate.Text = Today.ToLongDateString.ToString
    End Sub

    Private Sub lstFetchCounter_MouseClick(sender As Object, e As MouseEventArgs) Handles lstFetchCounter.MouseClick
        If lstFetchCounter.SelectedItems.Count > 0 Then
            pnlConfirmGenerateNumber.Show()
        End If
    End Sub

    Private Sub lstFetchCounter_KeyDown(sender As Object, e As KeyEventArgs) Handles lstFetchCounter.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lstFetchCounter.SelectedItems.Count > 0 Then
                pnlConfirmGenerateNumber.Show()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerateQueueNumber()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pnlConfirmGenerateNumber.Hide()
    End Sub
End Class