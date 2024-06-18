Public Class frmHomeMainCounterForTouch
    Private _loggedServer As Server
    Private _listOfSelectionCounter As List(Of Counter)
    Private _listOfMabClinics As List(Of ServerAssignCounter)
    Private _selectedListOfCounter As List(Of Counter) = Nothing
    Private _healeeCounter As Counter = Nothing
    Private WithEvents frmX As New Form
    Private WithEvents frmY As New Form
    Private WithEvents frmZ As New Form
    Private _language As Boolean = False
    Private _generateScreening As Boolean = False
    Declare Auto Function SetDefaultPrinter Lib "winspool.drv" (ByVal pszPrinter As String) As Boolean

    Public Property SelectionCounters As List(Of Counter)
        Get
            Return _listOfSelectionCounter
        End Get
        Private Set(value As List(Of Counter))
            _listOfSelectionCounter = value
        End Set
    End Property

    Public Property HealeeCounter As Counter
        Get
            Return _healeeCounter
        End Get
        Private Set(value As Counter)
            _healeeCounter = value
            _healeeCounter = value
        End Set
    End Property

    Public Property MabCounters As List(Of ServerAssignCounter)
        Get
            Return _listOfMabClinics
        End Get
        Private Set(value As List(Of ServerAssignCounter))
            _listOfMabClinics = value
        End Set
    End Property

    Public Property Server As Server
        Get
            Return _loggedServer
        End Get
        Private Set(value As Server)
            _loggedServer = value
        End Set
    End Property

    Private Sub ToogleMabClinicsQueue(flag As Boolean)
        If flag Then
            lblHelp.Text = If(_language, "PUMILI NG DOKTOR NA IYONG NINANAIS.", "PLEASE SELECT A DOCTOR.")
            If Me.MabCounters.Count > 0 Then
                pnlNoDoctorAlert.Hide()
            Else
                pnlNoDoctorAlert.Show()
            End If
            cbNameFilter.SelectedIndex = 0
            pnlDoctorsDirectory.Show()
        Else
            lblHelp.Text = If(_language, "ANONG GUSTO MONG GAWIN?", "WHAT SERVICE DO YOU WANT?")
            pnlDoctorsDirectory.Hide()
        End If
    End Sub

    Private Sub getOnlyMabClinics()
        Dim counterController As New CounterController
        flpDoctorsList.Controls.Clear()
        MabCounters = counterController.GetAllMABClinicQueuingCounters()
        For Each queuecounter As ServerAssignCounter In MabCounters
            If queuecounter.Counter.CounterType = 1 Then
                CreateDoctorPanel(queuecounter)
            End If
        Next
    End Sub

    Private Sub getOnlyMabClinicsFiltered()
        If cbNameFilter.SelectedIndex > 0 Then
            Dim counterController As New CounterController
            flpDoctorsList.Controls.Clear()
            MabCounters = counterController.GetAllMABClinicQueuingCounters_Filtered(cbNameFilter.SelectedItem)
            For Each queuecounter As ServerAssignCounter In MabCounters
                If queuecounter.Counter.CounterType = 1 Then
                    CreateDoctorPanel(queuecounter)
                End If
            Next
        End If
    End Sub

    Private Sub getAllCounters()
        lblHelp.Text = If(_language, "ANONG GUSTO MONG GAWIN?", "WHAT SERVICE DO YOU WANT?")
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
        imgs1.ImageSize = New Size(180, 170)
        lstFetchCounter.Items.Clear()
        lstFetchCounter.LargeImageList = imgs1
        Dim counterController As New CounterController
        SelectionCounters = counterController.GetAllPCCQueuingCounters()
        HealeeCounter = counterController.GetHealeeCounter()
        For Each queuecounter As Counter In SelectionCounters
            If queuecounter.CounterType = 0 Then
                lstFetchCounter.Items.Add(If(_language, queuecounter.ServiceDescription2.Trim.ToUpper, queuecounter.ServiceDescription.Trim.ToUpper), If(queuecounter.Icon > CounterImageIconsLg.Images.Count, 0, queuecounter.Icon))
            End If
        Next
        lstFetchCounter.Items.Add(If(_language, "BUMISITA SA CLINIC", "PRIVATE CLINIC VISIT"), lstFetchCounter.LargeImageList.Images.Count - 1)
        flpDoctorsList.Controls.Clear()
        MabCounters = counterController.GetAllMABClinicQueuingCounters()
        For Each queuecounter As ServerAssignCounter In MabCounters
            If queuecounter.Counter.CounterType = 1 Then
                CreateDoctorPanel(queuecounter)
            End If
        Next
        Dim imgs2 As New ImageList
        imgs2.Images.Add(CustomImageIconsXXLg.Images(13)) 'MWELL
        imgs2.Images.Add(CustomImageIconsXXLg.Images(14)) 'WATCHERS
        imgs2.Images.Add(CustomImageIconsXXLg.Images(15)) 'QR CODE
        imgs2.ColorDepth = ColorDepth.Depth32Bit
        imgs2.ImageSize = New Size(150, 120)
        lstCustomCounter.Items.Clear()
        lstCustomCounter.LargeImageList = imgs2
        'lstCustomCounter.Items.Add(If(_language, "MWELL KONSULTA", "MWELL CONSULTATION"), 0)
        lstCustomCounter.Items.Add("WATCHERS / VISITORS", 1)
        'lstCustomCounter.Items.Add("SCAN QR CODE", 2)
    End Sub

    Private Sub ShowConsent()
        Dim frmConsent As New frmConsent
        frmConsent.ShowDialog(Me)
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

    Private Sub CreateDoctorPanel(clinic As ServerAssignCounter)
        Dim doctorItems As New DoctorItem(clinic)
        With doctorItems
            .Size = New Size((flpDoctorsList.Size.Width / 3) - 10, doctorItems.Height)
            .Name = "doctorPanel" & clinic.ServerAssignCounter_ID
        End With
        flpDoctorsList.Controls.Add(doctorItems)
    End Sub

    Public Sub GenerateClinicNumber(clinicCounter As ServerAssignCounter)
        If Not IsNothing(clinicCounter) Then
            Dim customerInfo As CustomerInfo = CustomerLookup2()
            If Not IsNothing(customerInfo) Then
                With customerInfo.HealthCheck
                    .PurposeOfVisit = "CLINIC VISIT"
                End With
                Dim customerAssignCounterController As New CustomerAssignCounterController
                If Not isSafeHealthCheck(customerInfo) Then
                    If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                        ToogleMabClinicsQueue(False)
                        pbInvalidQR.Hide()
                        pbGeneralError.Hide()
                        pbSick.Show()
                        msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
                        pnlQRCodeAlertBox.Show()
                    End If
                    Exit Sub
                End If
                progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
                printProgress.Value = 10
                pnlProgress.Show()
                Dim customerAssignCounter As New CustomerAssignCounter
                customerAssignCounter.Priority = 0
                customerAssignCounter.ForHelee = 0
                customerAssignCounter.Counter = clinicCounter.Counter
                customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
                customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
                customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
                customerAssignCounter.Customer.CustomerInfo = customerInfo
                printProgress.Value = 30
                Dim generatedNumber As String = Nothing
                If _generateScreening Then
                    generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
                Else
                    generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
                End If
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
                            .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("PLEASE GO TO " & If(customerAssignCounter.Counter.ServiceDescription.Trim.ToUpper.Contains("CLINIC"), customerAssignCounter.Counter.ServiceDescription, "CLINIC " & customerAssignCounter.Counter.ServiceDescription)).Trim.ToUpper, ("THIS IS YOUR QUEUE NUMBER FOR DR." & clinicCounter.Server.LastName).Trim.ToUpper)
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
                        ToogleMabClinicsQueue(False)
                    End Try
                Else
                    MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select a doctor first before generating a number", "No Doctor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub GenerateNormalNumber()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Long = lstFetchCounter.SelectedIndices(0)
            Dim selectedCounter As Counter = Me.SelectionCounters(index)
            Dim customerInfo As CustomerInfo = CustomerLookup2()
            If Not IsNothing(customerInfo) Then
                With customerInfo.HealthCheck
                    .PurposeOfVisit = selectedCounter.ServiceDescription
                End With
                Dim customerAssignCounterController As New CustomerAssignCounterController
                If Not isSafeHealthCheck(customerInfo) Then
                    If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                        pbInvalidQR.Hide()
                        pbGeneralError.Hide()
                        pbSick.Show()
                        msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
                        pnlQRCodeAlertBox.Show()
                    End If
                    Exit Sub
                End If
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
                Dim generatedNumber As String = Nothing
                If _generateScreening Then
                    generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
                Else
                    generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
                End If
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
                        reportDocs.SetParameterValue("FK_emdPatients", String.Format("{0}", customerAssignCounter.Customer.FK_emdPatients))
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

    Private Sub GenerateNormalNumber_QRCode(counter As Long, patientDetails As CustomerInfo)
        Dim index As Long = counter
        Dim customerInfo As CustomerInfo = patientDetails
        If Not IsNothing(customerInfo) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            If Not isSafeHealthCheck(customerInfo) Then
                If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                    pbInvalidQR.Hide()
                    pbGeneralError.Hide()
                    pbSick.Show()
                    msgQRAlert.Text = "We've detected that you have a symptoms. Please go to the emergency room for you to be check as soon as possible."
                    pnlQRCodeAlertBox.Show()
                End If
                Exit Sub
            End If
            progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
            printProgress.Value = 10
            pnlProgress.Show()
            Dim customerAssignCounter As New CustomerAssignCounter
            customerAssignCounter.Priority = 0
            customerAssignCounter.ForHelee = 0
            customerAssignCounter.Counter = Me.SelectionCounters(index)
            customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
            customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
            customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
            customerAssignCounter.Customer.CustomerInfo = customerInfo
            printProgress.Value = 30
            Dim generatedNumber As String = Nothing
            If _generateScreening Then
                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
            Else
                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
            End If
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
                        .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("PLEASE GO TO " & customerAssignCounter.Counter.ServiceDescription).Trim.ToUpper, ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper)
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
    End Sub

    Public Sub GenerateClinicNumber_QRCode(clinicPhysician As ServerAssignCounter, patientDetails As CustomerInfo)
        Dim clinicCounter As ServerAssignCounter = clinicPhysician
        Dim customerInfo As CustomerInfo = patientDetails
        If Not IsNothing(customerInfo) Then
            progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
            printProgress.Value = 10
            pnlProgress.Show()
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim customerAssignCounter As New CustomerAssignCounter
            customerAssignCounter.Priority = 0
            customerAssignCounter.ForHelee = 0
            customerAssignCounter.Counter = clinicCounter.Counter
            customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
            customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
            customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
            customerAssignCounter.Customer.CustomerInfo = customerInfo
            printProgress.Value = 30
            Dim generatedNumber As String = Nothing
            If _generateScreening Then
                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
            Else
                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
            End If
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
                        .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("PLEASE GO TO " & customerAssignCounter.Counter.ServiceDescription).Trim.ToUpper, ("THIS IS YOUR APPOINTMENT NUMBER FOR CLINIC OF DR." & clinicCounter.Server.LastName).Trim.ToUpper)
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
                    ToogleMabClinicsQueue(False)
                End Try
            Else
                MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub QueueToScreeningOnly(patientInfo As CustomerInfo)
        Dim customerInfo As CustomerInfo = patientInfo
        If Not IsNothing(customerInfo) Then
            Dim customerAssignCounterController As New CustomerAssignCounterController
            If Not isSafeHealthCheck(customerInfo) Then
                If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                    pbInvalidQR.Hide()
                    pbGeneralError.Hide()
                    pbSick.Show()
                    msgQRAlert.Text = "We've detected that you have a symptoms. Please go to the emergency room for you to be check as soon as possible."
                    pnlQRCodeAlertBox.Show()
                End If
                Exit Sub
            Else
                progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
                printProgress.Value = 10
                pnlProgress.Show()
                printProgress.Value = 30
                If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
PrintNormalNumber:
                    Try
                        Dim reportDocs As New ticketVisitationStub
                        Dim dt As New DataTable
                        With dt.Columns
                            .Add("patName")
                            .Add("note")
                        End With
                        With dt.Rows
                            .Add(customerInfo.Lastname.Trim.ToUpper & " " & customerInfo.FirstName.Trim.ToUpper & " " & customerInfo.Middlename.Trim.ToUpper, "USE THIS STUB TO ENTER HOSPITAL PREMISES")
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
                End If
            End If
        End If
    End Sub

    Private Function isSafeHealthCheck(patientInfo As CustomerInfo) As Boolean
        Dim patientHealthCheck As HealthCheck = patientInfo.HealthCheck
        If patientHealthCheck.Fever Or patientHealthCheck.Cough Or patientHealthCheck.Sorethroat Or patientHealthCheck.Diarrhea Or patientHealthCheck.ShortnessOfBreathing Or patientHealthCheck.Ageusia Or patientHealthCheck.Anosmia Or patientHealthCheck.Colds Then
            Return False
        End If
        Return True
    End Function

    Private Sub ShowSelectedCounterQueueBoardADS()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardADs).Any Then
                frmY = New frmCounterQueuingBoardADs(Me.SelectionCounters(index))
                frmY.Show()
            End If
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardROOMS()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmShowMyQueueBoard).Any Then
                frmY.Close()
                frmY = New frmShowMyQueueBoard(Me.SelectionCounters(index))
                frmY.Show()
            End If
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardADSStandalone()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardADsStandalone).Any Then
                frmX.Close()
                frmX = New frmCounterQueuingBoardADsStandalone(Me.SelectionCounters(index))
            End If
            frmX.Show()
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardROOMSStandalone()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmCountersQueueBoardRoomStandalone).Any Then
                frmX.Close()
                frmX = New frmCountersQueueBoardRoomStandalone(Me.SelectionCounters(index))
            End If
            frmX.Show()
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardNumbers()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmCountersQueueBoardNumbers).Any Then
                frmY.Close()
                frmY = New frmCountersQueueBoardNumbers(Me.SelectionCounters(index))
            End If
            frmY.Show()
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardNumbersStandalone()
        If lstFetchCounter.SelectedItems.Count > 0 Then
            Dim index As Integer = lstFetchCounter.SelectedIndices(0).ToString
            If Not Application.OpenForms.OfType(Of frmCountersQueueBoardNumbersStandalone).Any Then
                frmX.Close()
                frmX = New frmCountersQueueBoardNumbersStandalone(Me.SelectionCounters(index))
            End If
            frmX.Show()
        Else
            MessageBox.Show("Please select or highlight the counter on the list of counters that you want to view", "Select a Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowSelectedCounterQueueBoardSelectedCounters()
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardSelectedCounters).Any Then
            frmY.Close()
            frmY = New frmCounterQueuingBoardSelectedCounters()
        End If
        frmY.Show()
    End Sub


    Private Sub ShowSelectedCounterQueueBoardSelectedCountersStandalone()
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardSelectedCountersStandalone).Any Then
            frmY.Close()
            frmY = New frmCounterQueuingBoardSelectedCountersStandalone()
        End If
        frmY.Show()
    End Sub

    Private Sub ShowAllCounterQueuingBoard()
        If Not Application.OpenForms().OfType(Of frmAllQueueBoard_Test).Any Then
            frmY.Close()
            frmY = New frmAllQueueBoard_Test
            frmY.Show()
        End If
    End Sub

    Private Sub ShowAllCounterQueuingBoardStatic()
        If Not Application.OpenForms().OfType(Of frmAllQueueBoard_Static).Any Then
            frmY.Close()
            frmY = New frmAllQueueBoard_Static
            frmY.Show()
        End If
    End Sub

    Private Sub ShowSwitchToTouchMode()
        If Not Application.OpenForms().OfType(Of frmHomeMainCounterForTouch).Any Then
            frmY.Close()
            frmY = New frmHomeMainCounterForTouch
            frmY.Show()
        End If
    End Sub

    Private Sub ShowAllCounterQueuingBoardStandalone()
        If Not Application.OpenForms().OfType(Of frmAllQueueBoardStandalone).Any Then
            frmX.Close()
            frmX = New frmAllQueueBoardStandalone
            frmX.Show()
        End If
    End Sub


    Private Sub ShowAllCounterQueuingBoardStandaloneStatic()
        If Not Application.OpenForms().OfType(Of frmAllQueueBoardStandalone_Static).Any Then
            frmX.Close()
            frmX = New frmAllQueueBoardStandalone_Static
            frmX.Show()
        End If
    End Sub

    Private Sub ShowClinicCounterQueuingBoardStandaloneStatic()
        If Not Application.OpenForms().OfType(Of frmCounterQueuingBoard_ClinicPCC).Any Then
            frmX.Close()
            frmX = New frmCounterQueuingBoard_ClinicPCC
            frmX.Show()
        End If
    End Sub

    Private Sub frmHomeMainCounterForTouch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LoggedServer.ServerAssignCounter.Counter.generateScreening Then
            _generateScreening = True
        End If
        getAllCounters()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tsTime.Text = TimeOfDay
        tsDate.Text = Today.ToLongDateString.ToString
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles lstFetchCounter.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lstFetchCounter.SelectedItems.Count > 0 Then
                If lstFetchCounter.SelectedIndices(0) = (lstFetchCounter.Items.Count - 1) Then
                    getOnlyMabClinics()
                    ToogleMabClinicsQueue(True)
                Else
                    GenerateNormalNumber()
                End If
            End If
        End If
    End Sub

    Private Sub tsLogout_Click(sender As Object, e As EventArgs) Handles tsLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub tsExit_Click(sender As Object, e As EventArgs) Handles tsExit.Click
        If MessageBox.Show("Are you sure to close this program?", "Close Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Abort
            Application.Exit()
        End If
    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles lstFetchCounter.MouseClick
        If lstFetchCounter.SelectedItems.Count > 0 Then
            If lstFetchCounter.SelectedIndices(0) = (lstFetchCounter.Items.Count - 1) Then
                getOnlyMabClinics()
                ToogleMabClinicsQueue(True)
            Else
                GenerateNormalNumber()
            End If
        End If
    End Sub

    Private Sub ShowAllDepartmentQueuingBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowAllCounterQueuingBoard()
    End Sub

    Private Sub ShowSelectedCounterQueuingBoardROOMSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMS()
    End Sub

    Private Sub ShowSelectedCounterQueuingBoardROOMSToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMS()
    End Sub

    Private Sub MinimizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MinimizeToolStripMenuItem.Click
        If Not Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ShowThisDepartmentQueuingBoardStandaloneADSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardADSStandalone()
    End Sub

    Private Sub ShowSelectedCounterQueuingBoardStanaloneADSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardADSStandalone()
    End Sub

    Private Sub ShowSelectedCounterQueuingBoardStandaloneROOMSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMSStandalone()
    End Sub

    Private Sub ShowThisDepartmentQueuingBoardStandaloneROOMSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMSStandalone()
    End Sub

    Private Sub ShowAllQueuingBoardStandaloneToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowAllCounterQueuingBoardStandalone()
    End Sub

    Private Sub ShowAllDepartmentQueuingBoardStanaloneToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowAllCounterQueuingBoardStandalone()
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QueuingBoardADSToolStripMenuItem1.Click
        ShowSelectedCounterQueueBoardADSStandalone()
    End Sub

    Private Sub QueuingBoardBILLINGSATUSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QueuingBoardBILLINGSATUSToolStripMenuItem1.Click
        ShowSelectedCounterQueueBoardROOMSStandalone()
    End Sub

    Private Sub QueuingBoardLABRESULTSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QueuingBoardLABRESULTSToolStripMenuItem1.Click
        ShowSelectedCounterQueueBoardNumbersStandalone()
    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardADSToolStripMenuItem.Click
        ShowSelectedCounterQueueBoardADS()
    End Sub

    Private Sub QueuingBoardBILLINGSATUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardBILLINGSATUSToolStripMenuItem.Click
        ShowSelectedCounterQueueBoardROOMS()
    End Sub

    Private Sub ToolStripMenuItem5_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ShowSelectedCounterQueueBoardSelectedCounters()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ShowSelectedCounterQueueBoardSelectedCountersStandalone()
    End Sub

    Private Sub QueuingBoardALLCOUNTERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardALLCOUNTERSToolStripMenuItem.Click
        ShowAllCounterQueuingBoardStandalone()
    End Sub

    Private Sub QueuingBoardSELECTEDCOUNTERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardSELECTEDCOUNTERSToolStripMenuItem.Click
        ShowAllCounterQueuingBoard()
    End Sub

    Private Sub QueuingBoardLABRESULTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueuingBoardLABRESULTSToolStripMenuItem.Click
        ShowSelectedCounterQueueBoardNumbers()
    End Sub

    Private Sub QueuingBoardBILLINGSTATUSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMS()
    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardADS()
    End Sub

    Private Sub QueuingBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardNumbers()
    End Sub

    Private Sub QueuingBoardSELECTEDDEPARTMENTToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardSelectedCounters()
    End Sub

    Private Sub QueuingBoardALLToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowAllCounterQueuingBoard()
    End Sub

    Private Sub QueuingBoardADSToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardADSStandalone()
    End Sub

    Private Sub QueuingBoardBILLINGSTATUSToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardROOMSStandalone()
    End Sub

    Private Sub QueuingBoardLABRESULTSToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardNumbersStandalone()
    End Sub

    Private Sub QueuingBoardALLToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ShowAllCounterQueuingBoardStandalone()
    End Sub

    Private Sub QueuingBoardSELECTEDDEPARTMENTToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ShowSelectedCounterQueueBoardSelectedCountersStandalone()
    End Sub

    Private Sub SwitchToTouchModeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowSwitchToTouchMode()
    End Sub

    Private Sub SetPrinterToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dlgPrint As New PrintDialog()
        Dim result As DialogResult = dlgPrint.ShowDialog()
        If result = DialogResult.OK Then
            If Not dlgPrint.PrinterSettings.IsDefaultPrinter Then
                SetDefaultPrinter(dlgPrint.PrinterSettings.PrinterName)
            End If
        End If
    End Sub

    Private Sub ChangeCounterToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you sure you want to close touch screen mode?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub ThisDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThisDepartmentToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueList).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueList(LoggedServer.ServerAssignCounter.Counter)
            frmZ.Show()
        End If
    End Sub

    Private Sub AllDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllDepartmentToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueListAll).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueListAll()
            frmZ.Show()
        End If
    End Sub

    Private Sub DepartmentSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentSummaryToolStripMenuItem.Click
        If Not Application.OpenForms.OfType(Of frmCounterQueuingBoardQueueListAll).Any Then
            frmZ.Close()
            frmZ = New frmCounterQueuingBoardQueueListSummary()
            frmZ.Show()
        End If
    End Sub

    Private Sub ChangeCounterToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangeCounterToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to change the current counter you're logging in?", "Change Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim serverController As New ServerController
            Server = serverController.GetCertainServer(LoggedServer.ServerAssignCounter.Server.Server_ID)
            Me.DialogResult = DialogResult.Retry
        End If
    End Sub

    Private Sub frmHomeMainCounterForTouch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogoutUser()
        frmX.Dispose()
        frmY.Dispose()
        frmZ.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToogleMabClinicsQueue(False)
    End Sub

    Private Sub cbNameFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNameFilter.SelectedIndexChanged
        If cbNameFilter.SelectedIndex > 0 Then
            getOnlyMabClinicsFiltered()
        Else
            getOnlyMabClinics()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnToogleLanguage.Click
        _language = Not _language
        getAllCounters()
    End Sub

    Private Sub btnScanQR_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        pnlQRCodeAlertBox.Hide()
    End Sub

    Private Sub btnVisitorsQueue_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AllCounterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCounterToolStripMenuItem.Click
        ShowAllCounterQueuingBoardStatic()
    End Sub

    Private Sub AllCounterAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCounterAlertToolStripMenuItem.Click
        ShowAllCounterQueuingBoardStandaloneStatic()
    End Sub

    Private Sub ClinicCounterAlertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClinicCounterAlertToolStripMenuItem.Click
        ShowClinicCounterQueuingBoardStandaloneStatic()
    End Sub

    Private Sub lstCustomCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCustomCounter.SelectedIndexChanged

    End Sub

    Private Sub lstCustomCounter_MouseClick(sender As Object, e As MouseEventArgs) Handles lstCustomCounter.MouseClick
        If lstCustomCounter.SelectedItems.Count > 0 Then
            If lstCustomCounter.SelectedIndices(0) = 0 Then 'Watchers
                Dim customerInfo As CustomerInfo = CustomerLookup2()
                If Not IsNothing(customerInfo) Then
                    With customerInfo.HealthCheck
                        .PurposeOfVisit = "VISITOR/PATIENT VISIT"
                    End With
                    QueueToScreeningOnly(customerInfo)
                End If
            End If
            '            If lstCustomCounter.SelectedIndices(0) = 0 Then 'Healee
            '                If Not IsNothing(HealeeCounter) Then
            '                    Dim selectedCounter As Counter = HealeeCounter
            '                    Dim customerInfo As CustomerInfo = CustomerLookup2()
            '                    If Not IsNothing(customerInfo) Then
            '                        With customerInfo.HealthCheck
            '                            .PurposeOfVisit = selectedCounter.ServiceDescription
            '                        End With
            '                        Dim customerAssignCounterController As New CustomerAssignCounterController
            '                        If Not isSafeHealthCheck(customerInfo) Then
            '                            If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
            '                                pbInvalidQR.Hide()
            '                                pbGeneralError.Hide()
            '                                pbSick.Show()
            '                                msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
            '                                pnlQRCodeAlertBox.Show()
            '                            End If
            '                            Exit Sub
            '                        End If
            '                        progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
            '                        printProgress.Value = 10
            '                        pnlProgress.Show()
            '                        Dim customerAssignCounter As New CustomerAssignCounter
            '                        customerAssignCounter.Priority = 0
            '                        customerAssignCounter.ForHelee = 1
            '                        customerAssignCounter.Counter = selectedCounter
            '                        customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
            '                        customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
            '                        customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
            '                        customerAssignCounter.Customer.CustomerInfo = customerInfo
            '                        printProgress.Value = 30
            '                        Dim generatedNumber As String = Nothing
            '                        If _generateScreening Then
            '                            generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
            '                        Else
            '                            generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
            '                        End If
            '                        If Not IsNothing(generatedNumber) Then
            '                            lstFetchCounter.Select()
            'PrintNormalNumber:
            '                            Try
            '                                Dim reportDocs As New ticketNoReport
            '                                Dim dt As New DataTable
            '                                With dt.Columns
            '                                    .Add("ticketNo")
            '                                    .Add("patName")
            '                                    .Add("counter")
            '                                    .Add("note")
            '                                End With
            '                                With dt.Rows
            '                                    .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("THIS IS YOUR NUMBER FOR MWELL").Trim.ToUpper, ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper)
            '                                End With
            '                                reportDocs.SetDataSource(dt)
            '                                printProgress.Value = 60
            '                                progressText.Text = "PRINTING NUMBER..."
            '                                reportDocs.PrintToPrinter(1, False, 0, 0)
            '                                reportDocs.Close()
            '                            Catch ex As Exception
            '                                MessageBox.Show("There was some error encountered during the printing process: " + ex.ToString, "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '                                If MessageBox.Show("Do you want retry printing again?", "Re-print Number", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '                                    GoTo PrintNormalNumber
            '                                End If
            '                            Finally
            '                                progressText.Text = "DONE"
            '                                printProgress.Value = 100
            '                                pnlProgress.Hide()
            '                            End Try
            '                        Else
            '                            MessageBox.Show("There was some error on the process. Please try again", "Error Generating Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '                        End If
            '                    End If
            '                Else
            '                    pbSick.Hide()
            '                    pbInvalidQR.Hide()
            '                    pbGeneralError.Show()
            '                    msgQRAlert.Text = "MWELL CONSULTATION IS NOT AVAILABLE FOR A MOMENT."
            '                    pnlQRCodeAlertBox.Show()
            '                End If
            '            ElseIf lstCustomCounter.SelectedIndices(0) = 1 Then 'Watchers
            '                Dim customerInfo As CustomerInfo = CustomerLookup2()
            '                If Not IsNothing(customerInfo) Then
            '                    With customerInfo.HealthCheck
            '                        .PurposeOfVisit = "VISITOR/PATIENT VISIT"
            '                    End With
            '                    QueueToScreeningOnly(customerInfo)
            '                End If
            '            ElseIf lstCustomCounter.SelectedIndices(0) = 2 Then 'QR Code
            '                pnlQRCodeAlertBox.Hide()
            '                Dim frm As New frmScanQRCode
            '                frm.ShowDialog(Me)
            '                If frm.DialogResult = DialogResult.Yes Then
            '                    If Not IsNothing(frm.FetchedRecord) Then
            '                        If Not frm.FetchedRecord.isValid Then
            '                            pbSick.Hide()
            '                            pbGeneralError.Hide()
            '                            pbInvalidQR.Show()
            '                            msgQRAlert.Text = "Oops, sorry. The Q.R Code was already expired. Please make a new one using this qiosk."
            '                            pnlQRCodeAlertBox.Show()
            '                        ElseIf frm.FetchedRecord.FeverChills Or frm.FetchedRecord.Cough Or frm.FetchedRecord.SoreThroat Or frm.FetchedRecord.Diarrhea Or frm.FetchedRecord.ShortnessOfBreathing Or frm.FetchedRecord.Ageusia Or frm.FetchedRecord.Anosmia Or frm.FetchedRecord.Colds Then
            '                            Dim customerAssignCounterController As New CustomerAssignCounterController
            '                            Dim customerInfo As CustomerInfo = Nothing
            '                            Dim apiController As New APIController
            '                            Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                            Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                            If Not IsNothing(matchedInfo) Then
            '                                If matchedInfo.Count > 0 Then
            '                                    Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                    frmFound.ShowDialog()
            '                                    customerInfo = frmFound.SelectedCustomer
            '                                Else
            '                                    Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                    frmProfiling.ShowDialog(Me)
            '                                    If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                        customerInfo = frmProfiling.CustomerProfile
            '                                    End If
            '                                End If
            '                            End If
            '                            If Not IsNothing(customerInfo) Then
            '                                customerInfo.HealthCheck = New HealthCheck
            '                                With customerInfo.HealthCheck
            '                                    .Fever = frm.FetchedRecord.FeverChills
            '                                    .Cough = frm.FetchedRecord.Cough
            '                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                    .Colds = frm.FetchedRecord.Colds
            '                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                End With
            '                                If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
            '                                    pbInvalidQR.Hide()
            '                                    pbGeneralError.Hide()
            '                                    pbSick.Show()
            '                                    msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
            '                                    pnlQRCodeAlertBox.Show()
            '                                End If
            '                            End If
            '                        Else
            '                            If frm.FetchedRecord.Purpose.Trim.ToUpper = "CONSULTATION" Then
            '                                Dim index As Long = lstFetchCounter.Items(0).Index
            '                                Dim apiController As New APIController
            '                                Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                                Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                                If Not IsNothing(matchedInfo) Then
            '                                    If matchedInfo.Count > 0 Then
            '                                        Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                        frmFound.ShowDialog()
            '                                        Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
            '                                        If Not IsNothing(CustomerInfo) Then
            '                                            CustomerInfo.HealthCheck = New HealthCheck
            '                                            With CustomerInfo.HealthCheck
            '                                                .Fever = frm.FetchedRecord.FeverChills
            '                                                .Cough = frm.FetchedRecord.Cough
            '                                                .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                .Ageusia = frm.FetchedRecord.Ageusia
            '                                                .Anosmia = frm.FetchedRecord.Anosmia
            '                                                .Colds = frm.FetchedRecord.Colds
            '                                                .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                            End With
            '                                            GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                        End If
            '                                    Else
            '                                        Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                        frmProfiling.ShowDialog(Me)
            '                                        If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                            Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
            '                                            If Not IsNothing(CustomerInfo) Then
            '                                                CustomerInfo.HealthCheck = New HealthCheck
            '                                                With CustomerInfo.HealthCheck
            '                                                    .Fever = frm.FetchedRecord.FeverChills
            '                                                    .Cough = frm.FetchedRecord.Cough
            '                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                                    .Colds = frm.FetchedRecord.Colds
            '                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                End With
            '                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                            End If
            '                                        End If
            '                                    End If
            '                                End If
            '                            ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "DIAGNOSTICS" Then
            '                                Dim index As Long = lstFetchCounter.Items(1).Index
            '                                Dim apiController As New APIController
            '                                Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                                Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                                If Not IsNothing(matchedInfo) Then
            '                                    If matchedInfo.Count > 0 Then
            '                                        Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                        frmFound.ShowDialog()
            '                                        Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
            '                                        If Not IsNothing(CustomerInfo) Then
            '                                            CustomerInfo.HealthCheck = New HealthCheck
            '                                            With CustomerInfo.HealthCheck
            '                                                .Fever = frm.FetchedRecord.FeverChills
            '                                                .Cough = frm.FetchedRecord.Cough
            '                                                .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                .Ageusia = frm.FetchedRecord.Ageusia
            '                                                .Anosmia = frm.FetchedRecord.Anosmia
            '                                                .Colds = frm.FetchedRecord.Colds
            '                                                .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                            End With
            '                                            GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                        End If
            '                                    Else
            '                                        Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                        frmProfiling.ShowDialog(Me)
            '                                        If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                            Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
            '                                            If Not IsNothing(CustomerInfo) Then
            '                                                CustomerInfo.HealthCheck = New HealthCheck
            '                                                With CustomerInfo.HealthCheck
            '                                                    .Fever = frm.FetchedRecord.FeverChills
            '                                                    .Cough = frm.FetchedRecord.Cough
            '                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                                    .Colds = frm.FetchedRecord.Colds
            '                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                End With
            '                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                            End If
            '                                        End If
            '                                    End If
            '                                End If
            '                            ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "CLAIM RESULTS" Then
            '                                Dim index As Long = lstFetchCounter.Items(2).Index
            '                                Dim apiController As New APIController
            '                                Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                                Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                                If Not IsNothing(matchedInfo) Then
            '                                    If matchedInfo.Count > 0 Then
            '                                        Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                        frmFound.ShowDialog()
            '                                        Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
            '                                        If Not IsNothing(CustomerInfo) Then
            '                                            CustomerInfo.HealthCheck = New HealthCheck
            '                                            With CustomerInfo.HealthCheck
            '                                                .Fever = frm.FetchedRecord.FeverChills
            '                                                .Cough = frm.FetchedRecord.Cough
            '                                                .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                .Ageusia = frm.FetchedRecord.Ageusia
            '                                                .Anosmia = frm.FetchedRecord.Anosmia
            '                                                .Colds = frm.FetchedRecord.Colds
            '                                                .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                            End With
            '                                            GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                        End If
            '                                    Else
            '                                        Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                        frmProfiling.ShowDialog(Me)
            '                                        If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                            Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
            '                                            If Not IsNothing(CustomerInfo) Then
            '                                                CustomerInfo.HealthCheck = New HealthCheck
            '                                                With CustomerInfo.HealthCheck
            '                                                    .Fever = frm.FetchedRecord.FeverChills
            '                                                    .Cough = frm.FetchedRecord.Cough
            '                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                                    .Colds = frm.FetchedRecord.Colds
            '                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                End With
            '                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
            '                                            End If
            '                                        End If
            '                                    End If
            '                                End If
            '                            ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "CLINIC APPOINTMENT" Then
            '                                Dim detailString As String = frm.FetchedRecord.Details
            '                                Dim details As ClinicAppointmentDetail = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClinicAppointmentDetail)(detailString)
            '                                Dim counterController As New CounterController
            '                                Dim doctorClinic As ServerAssignCounter = counterController.GetCertainClinicDoctor(details.RefNo)
            '                                If Not IsNothing(doctorClinic) Then
            '                                    Dim apiController As New APIController
            '                                    Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                                    Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                                    If Not IsNothing(matchedInfo) Then
            '                                        If matchedInfo.Count > 0 Then
            '                                            Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                            frmFound.ShowDialog()
            '                                            Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
            '                                            If Not IsNothing(CustomerInfo) Then
            '                                                CustomerInfo.HealthCheck = New HealthCheck
            '                                                With CustomerInfo.HealthCheck
            '                                                    .Fever = frm.FetchedRecord.FeverChills
            '                                                    .Cough = frm.FetchedRecord.Cough
            '                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                                    .Colds = frm.FetchedRecord.Colds
            '                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                End With
            '                                                GenerateClinicNumber_QRCode(doctorClinic, CustomerInfo)
            '                                            End If
            '                                        Else
            '                                            Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                            frmProfiling.ShowDialog(Me)
            '                                            If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                                Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
            '                                                If Not IsNothing(CustomerInfo) Then
            '                                                    CustomerInfo.HealthCheck = New HealthCheck
            '                                                    With CustomerInfo.HealthCheck
            '                                                        .Fever = frm.FetchedRecord.FeverChills
            '                                                        .Cough = frm.FetchedRecord.Cough
            '                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                        .Ageusia = frm.FetchedRecord.Ageusia
            '                                                        .Anosmia = frm.FetchedRecord.Anosmia
            '                                                        .Colds = frm.FetchedRecord.Colds
            '                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                    End With
            '                                                    GenerateClinicNumber_QRCode(doctorClinic, CustomerInfo)
            '                                                End If
            '                                            End If
            '                                        End If
            '                                    End If
            '                                Else
            '                                    pbSick.Hide()
            '                                    pbGeneralError.Hide()
            '                                    pbInvalidQR.Show()
            '                                    msgQRAlert.Text = "The doctor of the selected clinic appointment is currently not available. Please select a different doctor."
            '                                    pnlQRCodeAlertBox.Show()
            '                                End If
            '                            Else
            '                                Dim apiController As New APIController
            '                                Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
            '                                Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
            '                                If Not IsNothing(matchedInfo) Then
            '                                    If matchedInfo.Count > 0 Then
            '                                        Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
            '                                        frmFound.ShowDialog()
            '                                        Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
            '                                        If Not IsNothing(CustomerInfo) Then
            '                                            CustomerInfo.HealthCheck = New HealthCheck
            '                                            With CustomerInfo.HealthCheck
            '                                                .Fever = frm.FetchedRecord.FeverChills
            '                                                .Cough = frm.FetchedRecord.Cough
            '                                                .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                .Ageusia = frm.FetchedRecord.Ageusia
            '                                                .Anosmia = frm.FetchedRecord.Anosmia
            '                                                .Colds = frm.FetchedRecord.Colds
            '                                                .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                            End With
            '                                            QueueToScreeningOnly(CustomerInfo)
            '                                        End If
            '                                    Else
            '                                        Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
            '                                        frmProfiling.ShowDialog(Me)
            '                                        If Not IsNothing(frmProfiling.CustomerProfile) Then
            '                                            Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
            '                                            If Not IsNothing(CustomerInfo) Then
            '                                                CustomerInfo.HealthCheck = New HealthCheck
            '                                                With CustomerInfo.HealthCheck
            '                                                    .Fever = frm.FetchedRecord.FeverChills
            '                                                    .Cough = frm.FetchedRecord.Cough
            '                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
            '                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
            '                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
            '                                                    .Ageusia = frm.FetchedRecord.Ageusia
            '                                                    .Anosmia = frm.FetchedRecord.Anosmia
            '                                                    .Colds = frm.FetchedRecord.Colds
            '                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
            '                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
            '                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
            '                                                End With
            '                                                QueueToScreeningOnly(CustomerInfo)
            '                                            End If
            '                                        End If
            '                                    End If
            '                                End If
            '                            End If
            '                        End If
            '                    End If
            '                End If
            '            End If
        End If
    End Sub

    Private Sub lstCustomCounter_KeyDown(sender As Object, e As KeyEventArgs) Handles lstCustomCounter.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lstCustomCounter.SelectedItems.Count > 0 Then
                If lstCustomCounter.SelectedIndices(0) = 0 Then 'Healee
                    If Not IsNothing(HealeeCounter) Then
                        Dim selectedCounter As Counter = HealeeCounter
                        Dim customerInfo As CustomerInfo = CustomerLookup2()
                        If Not IsNothing(customerInfo) Then
                            With customerInfo.HealthCheck
                                .PurposeOfVisit = selectedCounter.ServiceDescription
                            End With
                            Dim customerAssignCounterController As New CustomerAssignCounterController
                            If Not isSafeHealthCheck(customerInfo) Then
                                If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                                    pbInvalidQR.Hide()
                                    pbGeneralError.Hide()
                                    pbSick.Show()
                                    msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
                                    pnlQRCodeAlertBox.Show()
                                End If
                                Exit Sub
                            End If
                            progressText.Text = "GENERATING NUMBER, PLEASE WAIT..."
                            printProgress.Value = 10
                            pnlProgress.Show()
                            Dim customerAssignCounter As New CustomerAssignCounter
                            customerAssignCounter.Priority = 0
                            customerAssignCounter.ForHelee = 1
                            customerAssignCounter.Counter = selectedCounter
                            customerAssignCounter.Customer.FullName = (customerInfo.Lastname & " " & customerInfo.FirstName & " " & customerInfo.Middlename).Trim
                            customerAssignCounter.Customer.FK_emdPatients = customerInfo.FK_emdPatients
                            customerAssignCounter.Customer.PhoneNumber = customerInfo.PhoneNumber
                            customerAssignCounter.Customer.CustomerInfo = customerInfo
                            printProgress.Value = 30
                            Dim generatedNumber As String = Nothing
                            If _generateScreening Then
                                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber_QueueToScreening(customerAssignCounter)
                            Else
                                generatedNumber = customerAssignCounterController.NewCustomerGenerateQueueNumber(customerAssignCounter)
                            End If
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
                                        .Add(generatedNumber.Trim.ToUpper, customerAssignCounter.Customer.FullName.Trim.ToUpper, ("THIS IS YOUR NUMBER FOR MWELL").Trim.ToUpper, ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper)
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
                        pbSick.Hide()
                        pbInvalidQR.Hide()
                        pbGeneralError.Show()
                        msgQRAlert.Text = "MWELL CONSULTATION IS NOT AVAILABLE FOR A MOMENT."
                        pnlQRCodeAlertBox.Show()
                    End If
                ElseIf lstCustomCounter.SelectedIndices(0) = 1 Then 'Watchers
                    Dim customerInfo As CustomerInfo = CustomerLookup2()
                    If Not IsNothing(customerInfo) Then
                        With customerInfo.HealthCheck
                            .PurposeOfVisit = "VISITOR/PATIENT VISIT"
                        End With
                        QueueToScreeningOnly(customerInfo)
                    End If
                ElseIf lstCustomCounter.SelectedIndices(0) = 2 Then 'QR Code
                    pnlQRCodeAlertBox.Hide()
                    Dim frm As New frmScanQRCode
                    frm.ShowDialog(Me)
                    If frm.DialogResult = DialogResult.Yes Then
                        If Not IsNothing(frm.FetchedRecord) Then
                            If Not frm.FetchedRecord.isValid Then
                                pbSick.Hide()
                                pbGeneralError.Hide()
                                pbInvalidQR.Show()
                                msgQRAlert.Text = "Oops, sorry. The Q.R Code was already expired. Please make a new one using this qiosk."
                                pnlQRCodeAlertBox.Show()
                            ElseIf frm.FetchedRecord.FeverChills Or frm.FetchedRecord.Cough Or frm.FetchedRecord.SoreThroat Or frm.FetchedRecord.Diarrhea Or frm.FetchedRecord.ShortnessOfBreathing Or frm.FetchedRecord.Ageusia Or frm.FetchedRecord.Anosmia Or frm.FetchedRecord.Colds Then
                                Dim customerAssignCounterController As New CustomerAssignCounterController
                                Dim customerInfo As CustomerInfo = Nothing
                                Dim apiController As New APIController
                                Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                If Not IsNothing(matchedInfo) Then
                                    If matchedInfo.Count > 0 Then
                                        Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                        frmFound.ShowDialog()
                                        customerInfo = frmFound.SelectedCustomer
                                    Else
                                        Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                        frmProfiling.ShowDialog(Me)
                                        If Not IsNothing(frmProfiling.CustomerProfile) Then
                                            customerInfo = frmProfiling.CustomerProfile
                                        End If
                                    End If
                                End If
                                If Not IsNothing(customerInfo) Then
                                    customerInfo.HealthCheck = New HealthCheck
                                    With customerInfo.HealthCheck
                                        .Fever = frm.FetchedRecord.FeverChills
                                        .Cough = frm.FetchedRecord.Cough
                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                        .Ageusia = frm.FetchedRecord.Ageusia
                                        .Anosmia = frm.FetchedRecord.Anosmia
                                        .Colds = frm.FetchedRecord.Colds
                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                    End With
                                    If customerAssignCounterController.SavePatientNoQueueNumber_QueueToScreening(customerInfo) Then
                                        pbInvalidQR.Hide()
                                        pbGeneralError.Hide()
                                        pbSick.Show()
                                        msgQRAlert.Text = "We've detected that you have a symptoms. Please go see our screening personel for further assessment."
                                        pnlQRCodeAlertBox.Show()
                                    End If
                                End If
                            Else
                                If frm.FetchedRecord.Purpose.Trim.ToUpper = "CONSULTATION" Then
                                    Dim index As Long = lstFetchCounter.Items(0).Index
                                    Dim apiController As New APIController
                                    Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                    Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                    If Not IsNothing(matchedInfo) Then
                                        If matchedInfo.Count > 0 Then
                                            Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                            frmFound.ShowDialog()
                                            Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
                                            If Not IsNothing(CustomerInfo) Then
                                                CustomerInfo.HealthCheck = New HealthCheck
                                                With CustomerInfo.HealthCheck
                                                    .Fever = frm.FetchedRecord.FeverChills
                                                    .Cough = frm.FetchedRecord.Cough
                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                    .Ageusia = frm.FetchedRecord.Ageusia
                                                    .Anosmia = frm.FetchedRecord.Anosmia
                                                    .Colds = frm.FetchedRecord.Colds
                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                End With
                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
                                            End If
                                        Else
                                            Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                            frmProfiling.ShowDialog(Me)
                                            If Not IsNothing(frmProfiling.CustomerProfile) Then
                                                Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
                                                If Not IsNothing(CustomerInfo) Then
                                                    CustomerInfo.HealthCheck = New HealthCheck
                                                    With CustomerInfo.HealthCheck
                                                        .Fever = frm.FetchedRecord.FeverChills
                                                        .Cough = frm.FetchedRecord.Cough
                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                        .Ageusia = frm.FetchedRecord.Ageusia
                                                        .Anosmia = frm.FetchedRecord.Anosmia
                                                        .Colds = frm.FetchedRecord.Colds
                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                    End With
                                                    GenerateNormalNumber_QRCode(index, CustomerInfo)
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "DIAGNOSTICS" Then
                                    Dim index As Long = lstFetchCounter.Items(1).Index
                                    Dim apiController As New APIController
                                    Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                    Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                    If Not IsNothing(matchedInfo) Then
                                        If matchedInfo.Count > 0 Then
                                            Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                            frmFound.ShowDialog()
                                            Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
                                            If Not IsNothing(CustomerInfo) Then
                                                CustomerInfo.HealthCheck = New HealthCheck
                                                With CustomerInfo.HealthCheck
                                                    .Fever = frm.FetchedRecord.FeverChills
                                                    .Cough = frm.FetchedRecord.Cough
                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                    .Ageusia = frm.FetchedRecord.Ageusia
                                                    .Anosmia = frm.FetchedRecord.Anosmia
                                                    .Colds = frm.FetchedRecord.Colds
                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                End With
                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
                                            End If
                                        Else
                                            Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                            frmProfiling.ShowDialog(Me)
                                            If Not IsNothing(frmProfiling.CustomerProfile) Then
                                                Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
                                                If Not IsNothing(CustomerInfo) Then
                                                    CustomerInfo.HealthCheck = New HealthCheck
                                                    With CustomerInfo.HealthCheck
                                                        .Fever = frm.FetchedRecord.FeverChills
                                                        .Cough = frm.FetchedRecord.Cough
                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                        .Ageusia = frm.FetchedRecord.Ageusia
                                                        .Anosmia = frm.FetchedRecord.Anosmia
                                                        .Colds = frm.FetchedRecord.Colds
                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                    End With
                                                    GenerateNormalNumber_QRCode(index, CustomerInfo)
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "CLAIM RESULTS" Then
                                    Dim index As Long = lstFetchCounter.Items(2).Index
                                    Dim apiController As New APIController
                                    Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                    Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                    If Not IsNothing(matchedInfo) Then
                                        If matchedInfo.Count > 0 Then
                                            Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                            frmFound.ShowDialog()
                                            Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
                                            If Not IsNothing(CustomerInfo) Then
                                                CustomerInfo.HealthCheck = New HealthCheck
                                                With CustomerInfo.HealthCheck
                                                    .Fever = frm.FetchedRecord.FeverChills
                                                    .Cough = frm.FetchedRecord.Cough
                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                    .Ageusia = frm.FetchedRecord.Ageusia
                                                    .Anosmia = frm.FetchedRecord.Anosmia
                                                    .Colds = frm.FetchedRecord.Colds
                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                End With
                                                GenerateNormalNumber_QRCode(index, CustomerInfo)
                                            End If
                                        Else
                                            Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                            frmProfiling.ShowDialog(Me)
                                            If Not IsNothing(frmProfiling.CustomerProfile) Then
                                                Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
                                                If Not IsNothing(CustomerInfo) Then
                                                    CustomerInfo.HealthCheck = New HealthCheck
                                                    With CustomerInfo.HealthCheck
                                                        .Fever = frm.FetchedRecord.FeverChills
                                                        .Cough = frm.FetchedRecord.Cough
                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                        .Ageusia = frm.FetchedRecord.Ageusia
                                                        .Anosmia = frm.FetchedRecord.Anosmia
                                                        .Colds = frm.FetchedRecord.Colds
                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                    End With
                                                    GenerateNormalNumber_QRCode(index, CustomerInfo)
                                                End If
                                            End If
                                        End If
                                    End If
                                ElseIf frm.FetchedRecord.Purpose.Trim.ToUpper = "CLINIC APPOINTMENT" Then
                                    Dim detailString As String = frm.FetchedRecord.Details
                                    Dim details As ClinicAppointmentDetail = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClinicAppointmentDetail)(detailString)
                                    Dim counterController As New CounterController
                                    Dim doctorClinic As ServerAssignCounter = counterController.GetCertainClinicDoctor(details.RefNo)
                                    If Not IsNothing(doctorClinic) Then
                                        Dim apiController As New APIController
                                        Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                        Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                        If Not IsNothing(matchedInfo) Then
                                            If matchedInfo.Count > 0 Then
                                                Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                                frmFound.ShowDialog()
                                                Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
                                                If Not IsNothing(CustomerInfo) Then
                                                    CustomerInfo.HealthCheck = New HealthCheck
                                                    With CustomerInfo.HealthCheck
                                                        .Fever = frm.FetchedRecord.FeverChills
                                                        .Cough = frm.FetchedRecord.Cough
                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                        .Ageusia = frm.FetchedRecord.Ageusia
                                                        .Anosmia = frm.FetchedRecord.Anosmia
                                                        .Colds = frm.FetchedRecord.Colds
                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                    End With
                                                    GenerateClinicNumber_QRCode(doctorClinic, CustomerInfo)
                                                End If
                                            Else
                                                Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                                frmProfiling.ShowDialog(Me)
                                                If Not IsNothing(frmProfiling.CustomerProfile) Then
                                                    Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
                                                    If Not IsNothing(CustomerInfo) Then
                                                        CustomerInfo.HealthCheck = New HealthCheck
                                                        With CustomerInfo.HealthCheck
                                                            .Fever = frm.FetchedRecord.FeverChills
                                                            .Cough = frm.FetchedRecord.Cough
                                                            .Sorethroat = frm.FetchedRecord.SoreThroat
                                                            .Diarrhea = frm.FetchedRecord.Diarrhea
                                                            .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                            .Ageusia = frm.FetchedRecord.Ageusia
                                                            .Anosmia = frm.FetchedRecord.Anosmia
                                                            .Colds = frm.FetchedRecord.Colds
                                                            .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                            .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                            .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                        End With
                                                        GenerateClinicNumber_QRCode(doctorClinic, CustomerInfo)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        pbSick.Hide()
                                        pbGeneralError.Hide()
                                        pbInvalidQR.Show()
                                        msgQRAlert.Text = "The doctor of the selected clinic appointment is currently not available. Please select a different doctor."
                                        pnlQRCodeAlertBox.Show()
                                    End If
                                Else
                                    Dim apiController As New APIController
                                    Dim searchText As String = frm.FetchedRecord.FirstName.Trim & " " & frm.FetchedRecord.MiddleName.Trim & " " & frm.FetchedRecord.LastName.Trim
                                    Dim matchedInfo As List(Of CustomerInfo) = apiController.FindPatientByKeywordAndBday(searchText, frm.FetchedRecord.BirthDate)
                                    If Not IsNothing(matchedInfo) Then
                                        If matchedInfo.Count > 0 Then
                                            Dim frmFound As New frmFoundPatientList_Touch(matchedInfo)
                                            frmFound.ShowDialog()
                                            Dim CustomerInfo As CustomerInfo = frmFound.SelectedCustomer
                                            If Not IsNothing(CustomerInfo) Then
                                                CustomerInfo.HealthCheck = New HealthCheck
                                                With CustomerInfo.HealthCheck
                                                    .Fever = frm.FetchedRecord.FeverChills
                                                    .Cough = frm.FetchedRecord.Cough
                                                    .Sorethroat = frm.FetchedRecord.SoreThroat
                                                    .Diarrhea = frm.FetchedRecord.Diarrhea
                                                    .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                    .Ageusia = frm.FetchedRecord.Ageusia
                                                    .Anosmia = frm.FetchedRecord.Anosmia
                                                    .Colds = frm.FetchedRecord.Colds
                                                    .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                    .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                    .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                End With
                                                QueueToScreeningOnly(CustomerInfo)
                                            End If
                                        Else
                                            Dim frmProfiling As New frmPatientProfiling_Touch(frm.FetchedRecord.FirstName.Trim.ToUpper, frm.FetchedRecord.MiddleName.Trim.ToUpper, frm.FetchedRecord.LastName.Trim.ToUpper, frm.FetchedRecord.BirthDate, frm.FetchedRecord.Suffix.Trim.ToUpper, frm.FetchedRecord.Sex.ToUpper, frm.FetchedRecord.CivilStatus.Trim.ToUpper, frm.FetchedRecord.MobileNumber.Trim)
                                            frmProfiling.ShowDialog(Me)
                                            If Not IsNothing(frmProfiling.CustomerProfile) Then
                                                Dim CustomerInfo As CustomerInfo = frmProfiling.CustomerProfile
                                                If Not IsNothing(CustomerInfo) Then
                                                    CustomerInfo.HealthCheck = New HealthCheck
                                                    With CustomerInfo.HealthCheck
                                                        .Fever = frm.FetchedRecord.FeverChills
                                                        .Cough = frm.FetchedRecord.Cough
                                                        .Sorethroat = frm.FetchedRecord.SoreThroat
                                                        .Diarrhea = frm.FetchedRecord.Diarrhea
                                                        .ShortnessOfBreathing = frm.FetchedRecord.ShortnessOfBreathing
                                                        .Ageusia = frm.FetchedRecord.Ageusia
                                                        .Anosmia = frm.FetchedRecord.Anosmia
                                                        .Colds = frm.FetchedRecord.Colds
                                                        .CloseContactConfirmed = frm.FetchedRecord.CloseContactConfirmed
                                                        .CloseContactExhiting = frm.FetchedRecord.CloseContactPersonExhibiting
                                                        .PurposeOfVisit = frm.FetchedRecord.Purpose.Trim.ToUpper
                                                    End With
                                                    QueueToScreeningOnly(CustomerInfo)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lstFetchCounter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFetchCounter.SelectedIndexChanged

    End Sub
End Class