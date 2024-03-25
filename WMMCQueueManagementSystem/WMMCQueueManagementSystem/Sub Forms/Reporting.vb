Imports System.IO
Imports System.Net.Mail
Imports OfficeOpenXml
Imports _Worksheet = Microsoft.Office.Interop.Excel._Worksheet
Imports Range = Microsoft.Office.Interop.Excel.Range

Public Class Reporting
    Private tmpQueueCount As Long = 0
    Private tmpServedCount As Long = 0
    Private tmpHoldCount As Long = 0
    Private tmpUnservedeCount As Long = 0
    Private tmpQueuedPatientCount As Long = 0
    Private tmpConsultedPatientCount As Long = 0
    Private tmpHoldPatientCount As Long = 0
    Private tmpUnconsultedPatientCount As Long = 0

    Private Smtp_Server As SmtpClient = Nothing
    Const EmailAddress As String = "mmhitatreport@outlook.com"
    Const EmailPassword As String = "@Hospital.2023"
    Const EmailPort As String = "587"
    Const EmailHost As String = "smtp-mail.outlook.com"

    Private backroundSenderTimer As Timer = Nothing
    Private backRoundSender As Boolean = False
    Private logfile As String = "Mail Logs.txt"

    Private _PCCCounter As List(Of Counter) = Nothing
    Private _MABHybridClinic As List(Of ServerAssignCounter) = Nothing
    Private _PCCClinic As List(Of ServerAssignCounter) = Nothing
    Private _MABClinic As List(Of ServerAssignCounter) = Nothing
    Private _customerSummary As List(Of CustomerQueuedSummary) = Nothing
    Private _tmpTrySendingLimit As Integer = 5
    Private _currentDate As Date = Now

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        If IsNothing(backroundSenderTimer) Then
            backroundSenderTimer = New Timer()
            backroundSenderTimer.Interval = 10000
            AddHandler backroundSenderTimer.Tick, AddressOf SendEmailReport_Tick
        End If
        If IsNothing(Smtp_Server) Then
            Smtp_Server = New SmtpClient
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential((EmailAddress), (EmailPassword))
            Smtp_Server.Port = EmailPort
            Smtp_Server.EnableSsl = "True"
            Smtp_Server.Host = EmailHost
        End If
    End Sub

    Sub AppendLogs(log As String)
        Dim strFile As String = logfile
        Dim fileExists As Boolean = File.Exists(strFile)
        Using sw As New StreamWriter(File.Open(strFile, IIf(fileExists, FileMode.Append, FileMode.Create)))
            sw.WriteLine(Now.ToShortDateString & " @ " & Now.ToShortTimeString & " " & log)
        End Using
    End Sub

    Sub ViewLogs()
        Dim strFile As String = logfile
        If File.Exists(strFile) = True Then
            Process.Start(strFile)
        Else
            MessageBox.Show("There are no logs to show", "Empty Logs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub GellAllCounterList()
        ComboBox2.Items.Clear()
        Dim counterController As New CounterController
        Dim pccCounter As List(Of Counter) = counterController.GetAllPCCCounter_ReportFilter()
        Dim MABHybridClinic As List(Of ServerAssignCounter) = counterController.GetAllMABHybridClinic_ReportFilter()
        Dim PCCClinic As List(Of ServerAssignCounter) = counterController.GetAllPCCClinic_ReportFilter()
        Dim MABClinic As List(Of ServerAssignCounter) = counterController.GetAllMABClinic_ReportFilter()
        _PCCCounter = pccCounter
        _MABHybridClinic = MABHybridClinic
        _PCCClinic = PCCClinic
        _MABClinic = MABClinic
        ComboBox2.Items.Add(("ALL").ToUpper.Trim)
        If Not IsNothing(pccCounter) Then
            For Each counter As Counter In pccCounter
                ComboBox2.Items.Add(counter.ServiceDescription.ToUpper.Trim)
            Next
        End If
        ComboBox2.Items.Add(("MAB HYBRID CLINICS").ToUpper.Trim)
        ComboBox2.Items.Add(("PCC CLINICS").ToUpper.Trim)
        ComboBox2.Items.Add(("MAB CLINICS").ToUpper.Trim)
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub getCounterSummaryChart()
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim counteSummary As DataTable = customerAssignCounterController.GetCounterSummaryChart(dtpDateChart.Value)
        Dim PCCSummary As DataTable = customerAssignCounterController.GetPCCClinicCSummaryChart(dtpDateChart.Value)
        Dim PCCHybridSummary As DataTable = customerAssignCounterController.GetPCCHybridClinicCSummaryChart(dtpDateChart.Value)
        Dim MABSummary As DataTable = customerAssignCounterController.GetMABClinicCSummaryByChart(dtpDateChart.Value)
        Dim MABHybridSummary As DataTable = customerAssignCounterController.GetMABHybridClinicCounterSummaryChart(dtpDateChart.Value)
        If Not IsNothing(counteSummary) And Not IsNothing(PCCSummary) And Not IsNothing(PCCHybridSummary) And Not IsNothing(MABSummary) And Not IsNothing(MABHybridSummary) Then
            Dim dt As New DataTable
            With dt
                .Columns.Add("Section")
                For x As Integer = 1 To counteSummary.Columns.Count - 1
                    .Columns.Add(dtpDateChart.Value.ToString("MMM") & " " & x)
                Next
                For Each row As DataRow In counteSummary.Rows
                    .Rows.Add(row("Section"))
                    For x As Integer = 1 To counteSummary.Columns.Count - 1
                        .Rows(.Rows.Count - 1)(x) = row(x)
                    Next
                Next
                For Each row As DataRow In PCCSummary.Rows
                    .Rows.Add(row("Section"))
                    For x As Integer = 1 To PCCSummary.Columns.Count - 1
                        .Rows(.Rows.Count - 1)(x) = row(x)
                    Next
                Next
                For Each row As DataRow In PCCHybridSummary.Rows
                    .Rows.Add(row("Section"))
                    For x As Integer = 1 To PCCHybridSummary.Columns.Count - 1
                        .Rows(.Rows.Count - 1)(x) = row(x)
                    Next
                Next
                For Each row As DataRow In MABSummary.Rows
                    .Rows.Add(row("Section"))
                    For x As Integer = 1 To MABSummary.Columns.Count - 1
                        .Rows(.Rows.Count - 1)(x) = row(x)
                    Next
                Next
                For Each row As DataRow In MABHybridSummary.Rows
                    .Rows.Add(row("Section"))
                    For x As Integer = 1 To MABHybridSummary.Columns.Count - 1
                        .Rows(.Rows.Count - 1)(x) = row(x)
                    Next
                Next
            End With
            crtPCCREPORT.Series.Clear()
            For Each row As DataRow In dt.Rows
                crtPCCREPORT.Series.Add(row("Section"))
                crtPCCREPORT.Series.Item(row("Section")).ChartType = DataVisualization.Charting.SeriesChartType.Line
                For x As Integer = 1 To dt.Columns.Count - 1
                    Dim dtString As String =
                    crtPCCREPORT.Series(row("Section")).Points.AddXY(dtpDateChart.Value.ToString("MMM") & " " & x, row.ItemArray(x))
                Next
            Next
        End If
    End Sub

    Private Function CustomExcelReport_GenerateBilling(fromdate As Date, todate As Date) As String
        Try
            Dim labFile As String = "\\ThirdParty-PC\Common\wmmc_pcms\tat_report\BIL\" & fromdate.ToString("MMddyyyy") & fromdate.ToString("MMddyyyy") & ".xlsx"
            Using epLaboratory As ExcelPackage = New ExcelPackage()
                Dim customerAssignCounterController As New CustomerAssignCounterController
                Dim billingSummary As List(Of CounterSummary) = customerAssignCounterController.GetBillingSummaryByDate(fromdate, todate)
                Dim billingList As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetPatientServedBy_Billing(fromdate, todate)
                Dim dtBillingSummary As New DataTable
                With dtBillingSummary.Columns
                    .Add("DEPARTMENT/SECTION")
                    .Add("# PATIENT QUEUED")
                    .Add("# CALLED & SERVED")
                    .Add("# CALLED BUT NOT SURVED")
                    .Add("# UNCALLED")
                    .Add("% CALLED & SERVED")
                    .Add("% CALLED BUT NOT SURVED")
                    .Add("% UNCALLED")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                End With
                If Not IsNothing(billingSummary) Then
                    With dtBillingSummary.Rows
                        For Each billingItem As CounterSummary In billingSummary
                            Dim strServedPercent As String = "0 %"
                            Dim strUnservedPercent As String = "0 %"
                            Dim strHoldPercent As String = "0 %"
                            Dim strAveTimePercent As String = "0 %"
                            Dim strAveWaitingTimePercent As String = "0 %"
                            tmpQueueCount += billingItem.QueuedCount
                            tmpServedCount += billingItem.ServedCount
                            tmpHoldCount += billingItem.HoldCount
                            tmpUnservedeCount += billingItem.UnservedCount
                            If billingItem.ServedCount > 0 Then
                                strServedPercent = (Format(((billingItem.ServedCount / billingItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If billingItem.HoldCount > 0 Then
                                strHoldPercent = (Format(((billingItem.HoldCount / billingItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If billingItem.UnservedCount > 0 Then
                                strUnservedPercent = (Format(((billingItem.UnservedCount / billingItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If billingItem.AverageTurnoverTime > 0 Then
                                strAveTimePercent = (Format(billingItem.AverageTurnoverTime & " Minutes")).ToString
                            ElseIf billingItem.AverageTurnoverTime < 0 Then
                                strAveTimePercent = "0 %"
                            Else
                                strAveTimePercent = "Less than a Minute"
                            End If
                            If billingItem.AverageWaitingTurnoverTime > 0 Then
                                strAveWaitingTimePercent = (Format(billingItem.AverageWaitingTurnoverTime & " Minutes")).ToString
                            ElseIf billingItem.AverageWaitingTurnoverTime < 0 Then
                                strAveWaitingTimePercent = "0 %"
                            Else
                                strAveWaitingTimePercent = "Less than a Minute"
                            End If
                            .Add(billingItem.Counter.Section.ToUpper, billingItem.QueuedCount, billingItem.ServedCount, billingItem.HoldCount, billingItem.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                        Next
                    End With
                    Dim worksheet1 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Summary")
                    worksheet1.Cells.LoadFromDataTable(dtBillingSummary, True)
                End If
                Dim dtLaboratorList As New DataTable
                With dtLaboratorList.Columns
                    .Add("DATE QUEUED")
                    .Add("PATIENT NAME")
                    .Add("DEPARTMENT/SECTION")
                    .Add("QUEUE NUMBER")
                    .Add("SERVE START")
                    .Add("SERVED END")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                    .Add("SERVED BY")
                End With
                If Not IsNothing(billingList) Then
                    With dtLaboratorList.Rows
                        For Each labitem As CustomerQueuedSummary In billingList
                            Dim servedStart As String = "N/A"
                            Dim servedEnd As String = "N/A"
                            Dim servedBy As String = "N/A"
                            Dim servingTAT As String = "N/A"
                            Dim waitingTAT As String = "N/A"
                            If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer) Then
                                servedStart = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart, "MMM dd h:mm tt"), "N/A")
                                servedEnd = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd, "MMM dd h:mm tt"), "N/A")
                                servedBy = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                                If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart) And Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd) Then
                                    Dim svtat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart.Value, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    Dim wttat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.DateTimeQueued, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    servingTAT = (If(svtat > 0, svtat & " Minutes", "Less than a Minute"))
                                    waitingTAT = (If(wttat > 0, wttat & " Minutes", "Less than a Minute"))
                                End If
                            End If
                            .Add(Format(labitem.CustomerAssignCounter.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"),
                                 (labitem.CustomerInfo.Lastname & ", " & labitem.CustomerInfo.FirstName & " " & labitem.CustomerInfo.Middlename & " " & labitem.CustomerInfo.Suffix).Trim.ToUpper,
                                 labitem.CustomerAssignCounter.Counter.ServiceDescription,
                                 labitem.CustomerAssignCounter.ProcessedQueueNumber,
                                 servedStart,
                                 servedEnd,
                                 servingTAT,
                                 waitingTAT,
                                 servedBy)
                        Next
                    End With
                    Dim worksheet2 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Patient List")
                    worksheet2.Cells.LoadFromDataTable(dtLaboratorList, True)
                End If
                epLaboratory.SaveAs(labFile)
            End Using
            Return labFile
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function CustomExcelReport_GenerateLaboratory2(fromdate As Date, todate As Date) As String
        Try
            If Not Directory.Exists("\\ThirdParty-PC\Common\wmmc_pcms\tat_report\LAB") Then
                Directory.CreateDirectory("\\ThirdParty-PC\Common\wmmc_pcms\tat_report\LAB")
            End If
            Dim labFile As String = "\\ThirdParty-PC\Common\wmmc_pcms\tat_report\LAB\" & fromdate.ToString("MMddyyyyhhmmss") & fromdate.ToString("MMddyyyyhhmmsss") & ".xlsx"
            Using epLaboratory As ExcelPackage = New ExcelPackage()
                Dim consultID As Long = 28 'Consultation Triage ID
                Dim dxID As Long = 29 'Diagnostic Triage ID
                Dim cashierID As Long = 34 ' Cashier ID
                Dim hmoID As Long = 35 'HMO ID
                Dim labID As Long = 38 'Laboratory ID 

                Dim customerAssignCounterController As New CustomerAssignCounterController
                Dim labSummary As List(Of CounterSummary) = customerAssignCounterController.GetLaboratorySummaryByDate(fromdate, todate)
                Dim labList As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetPatientServedBy_Laboratory(fromdate, todate)
                Dim labTimeline As List(Of OutpatientTAT) = customerAssignCounterController.GetAllPatientTransactions_ByCounter(fromdate, todate, labID)

                Dim dtLaboratorySummary As New DataTable
                With dtLaboratorySummary.Columns
                    .Add("DEPARTMENT/SECTION")
                    .Add("# PATIENT QUEUED")
                    .Add("# CALLED & SERVED")
                    .Add("# CALLED BUT NOT SURVED")
                    .Add("# UNCALLED")
                    .Add("% CALLED & SERVED")
                    .Add("% CALLED BUT NOT SURVED")
                    .Add("% UNCALLED")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                End With
                If Not IsNothing(labSummary) Then
                    With dtLaboratorySummary.Rows
                        For Each labItem As CounterSummary In labSummary
                            Dim strServedPercent As String = "0 %"
                            Dim strUnservedPercent As String = "0 %"
                            Dim strHoldPercent As String = "0 %"
                            Dim strAveTimePercent As String = "0 %"
                            Dim strAveWaitingTimePercent As String = "0 %"
                            tmpQueueCount += labItem.QueuedCount
                            tmpServedCount += labItem.ServedCount
                            tmpHoldCount += labItem.HoldCount
                            tmpUnservedeCount += labItem.UnservedCount
                            If labItem.ServedCount > 0 Then
                                strServedPercent = (Format(((labItem.ServedCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.HoldCount > 0 Then
                                strHoldPercent = (Format(((labItem.HoldCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.UnservedCount > 0 Then
                                strUnservedPercent = (Format(((labItem.UnservedCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.AverageTurnoverTime > 0 Then
                                strAveTimePercent = (Format(labItem.AverageTurnoverTime & " Minutes")).ToString
                            ElseIf labItem.AverageTurnoverTime < 0 Then
                                strAveTimePercent = "0 %"
                            Else
                                strAveTimePercent = "Less than a Minute"
                            End If
                            If labItem.AverageWaitingTurnoverTime > 0 Then
                                strAveWaitingTimePercent = (Format(labItem.AverageWaitingTurnoverTime & " Minutes")).ToString
                            ElseIf labItem.AverageWaitingTurnoverTime < 0 Then
                                strAveWaitingTimePercent = "0 %"
                            Else
                                strAveWaitingTimePercent = "Less than a Minute"
                            End If
                            .Add(labItem.Counter.Section.ToUpper, labItem.QueuedCount, labItem.ServedCount, labItem.HoldCount, labItem.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                        Next
                    End With
                    Dim worksheet1 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Summary")
                    worksheet1.Cells.LoadFromDataTable(dtLaboratorySummary, True)
                End If
                Dim dtLaboratorList As New DataTable
                With dtLaboratorList.Columns
                    .Add("DATE QUEUED")
                    .Add("PATIENT NAME")
                    .Add("DEPARTMENT/SECTION")
                    .Add("QUEUE NUMBER")
                    .Add("SERVE START")
                    .Add("SERVED END")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                    .Add("SERVED BY")
                End With
                If Not IsNothing(labList) Then
                    With dtLaboratorList.Rows
                        For Each labitem As CustomerQueuedSummary In labList
                            Dim servedStart As String = "N/A"
                            Dim servedEnd As String = "N/A"
                            Dim servedBy As String = "N/A"
                            Dim servingTAT As String = "N/A"
                            Dim waitingTAT As String = "N/A"
                            If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer) Then
                                servedStart = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart, "MMM dd h:mm tt"), "N/A")
                                servedEnd = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd, "MMM dd h:mm tt"), "N/A")
                                servedBy = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                                If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart) And Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd) Then
                                    Dim svtat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart.Value, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    Dim wttat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.DateTimeQueued, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    servingTAT = (If(svtat > 0, svtat & " Minutes", "Less than a Minute"))
                                    waitingTAT = (If(wttat > 0, wttat & " Minutes", "Less than a Minute"))
                                End If
                            End If
                            .Add(Format(labitem.CustomerAssignCounter.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"),
                                 (labitem.CustomerInfo.Lastname & ", " & labitem.CustomerInfo.FirstName & " " & labitem.CustomerInfo.Middlename & " " & labitem.CustomerInfo.Suffix).Trim.ToUpper,
                                 labitem.CustomerAssignCounter.Counter.ServiceDescription,
                                 labitem.CustomerAssignCounter.ProcessedQueueNumber,
                                 servedStart,
                                 servedEnd,
                                 servingTAT,
                                 waitingTAT,
                                 servedBy)
                        Next
                    End With
                    Dim worksheet2 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Patient List")
                    worksheet2.Cells.LoadFromDataTable(dtLaboratorList, True)
                End If
                Dim dtLaboratoryTimelineList As New DataTable
                With dtLaboratoryTimelineList.Columns
                    .Add("DATE")
                    .Add("PATIENT NAME")
                    .Add("REGISTRATION QUEUEING TIME")
                    .Add("REGISTRATION TRANSACTION TIME")
                    .Add("PAYMENT TRANSACTION TIME")
                    .Add("PROCEDURE QUEUING TIME")
                    .Add("PROCEDURE RENDERING TIME")
                    .Add("RESULT RELEASING TIME")
                End With
                If Not IsNothing(labTimeline) Then
                    With dtLaboratoryTimelineList.Rows
                        Dim allRegistrationQueueingTime As New List(Of Long)
                        Dim allRegistrationTransactionTime As New List(Of Long)
                        Dim allPaymentTransactionTime As New List(Of Long)
                        Dim allProcedureQueueingTime As New List(Of Long)
                        Dim allProcedureRednderingTime As New List(Of Long)

                        For Each labitem As OutpatientTAT In labTimeline
                            Dim tmpTriage As CustomerAssignCounter = Nothing
                            Dim tmpPayment As CustomerAssignCounter = Nothing
                            Dim tmpLaboratory As CustomerAssignCounter = Nothing
                            Dim tmpDateOfTransaction As Date = Nothing
                            For Each counter As CustomerAssignCounter In labitem.QueuingTransactions
                                If counter.Counter_ID = dxID Or counter.Counter_ID = consultID Then
                                    tmpTriage = counter
                                ElseIf counter.Counter_ID = cashierID Or counter.Counter_ID = hmoID Then
                                    tmpPayment = counter
                                ElseIf counter.Counter_ID = labID Then
                                    tmpLaboratory = counter
                                    tmpDateOfTransaction = tmpLaboratory.DateTimeQueued
                                    Exit For
                                End If
                            Next
                            'TAT CALCULATION
                            Dim registrationQueueingTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.DateTimeQueued, tmpTriage.ServedCustomer.DateTimeStart.Value)
                                        registrationQueueingTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationQueueingTime.Add(registrationQueueingTime)
                                    End If
                                End If
                            End If

                            Dim registrationTransactionTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) And Not IsNothing(tmpTriage.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.ServedCustomer.DateTimeStart.Value, tmpTriage.ServedCustomer.DateTimeEnd.Value)
                                        registrationTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationTransactionTime.Add(registrationTransactionTime)
                                    End If
                                End If
                            End If

                            Dim paymentTransactionTime As Integer = 0
                            If Not IsNothing(tmpPayment) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeStart) And Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeStart.Value, tmpPayment.ServedCustomer.DateTimeEnd.Value)
                                        paymentTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allPaymentTransactionTime.Add(paymentTransactionTime)
                                    End If
                                End If
                            End If

                            Dim procedureQueuingTime As Integer = 0
                            If Not IsNothing(tmpPayment) And Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) And Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeEnd.Value, tmpLaboratory.ServedCustomer.DateTimeStart.Value)
                                        procedureQueuingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureQueueingTime.Add(procedureQueuingTime)
                                    End If
                                End If
                            End If

                            Dim procedureRenderingTime As Integer = 0
                            If Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpLaboratory.ServedCustomer.DateTimeStart.Value, tmpLaboratory.ServedCustomer.DateTimeEnd.Value)
                                        procedureRenderingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureRednderingTime.Add(procedureRenderingTime)
                                    End If
                                End If
                            End If
                            .Add(Format(tmpDateOfTransaction, "MMM/dd"), (labitem.LastName & ", " & labitem.FirstName & " " & labitem.MiddleName).Trim.ToUpper,
                                 registrationQueueingTime,
                                 registrationTransactionTime,
                                 paymentTransactionTime,
                                 procedureQueuingTime,
                                 procedureRenderingTime,
                                 "NOT YET PROCESSED")
                        Next
                        Dim avgRegistrationQueueingTime As Long = 0
                        For Each x As Long In allRegistrationQueueingTime
                            avgRegistrationQueueingTime += x
                        Next
                        avgRegistrationQueueingTime = (avgRegistrationQueueingTime / If(allRegistrationQueueingTime.Count > 0, allRegistrationQueueingTime.Count, 1))

                        Dim avgRegistrationTransactionTime As Long = 0
                        For Each x As Long In allRegistrationTransactionTime
                            avgRegistrationTransactionTime += x
                        Next
                        avgRegistrationTransactionTime = (avgRegistrationTransactionTime / If(allRegistrationTransactionTime.Count > 0, allRegistrationTransactionTime.Count, 1))

                        Dim avgPaymentTransactionTime As Long = 0
                        For Each x As Long In allPaymentTransactionTime
                            avgPaymentTransactionTime += x
                        Next
                        avgPaymentTransactionTime = (avgPaymentTransactionTime / If(allPaymentTransactionTime.Count > 0, allPaymentTransactionTime.Count, 1))

                        Dim avgProcedureQueueingTime As Long = 0
                        For Each x As Long In allProcedureQueueingTime
                            avgProcedureQueueingTime += x
                        Next
                        avgProcedureQueueingTime = (avgProcedureQueueingTime / If(allProcedureQueueingTime.Count > 0, allProcedureQueueingTime.Count, 1))

                        Dim avgProcedureRednderingTime As Long = 0
                        For Each x As Long In allProcedureRednderingTime
                            avgProcedureRednderingTime += x
                        Next
                        avgProcedureRednderingTime = (avgProcedureRednderingTime / If(allProcedureRednderingTime.Count > 0, allProcedureRednderingTime.Count, 1))
                        .Add("", "AVERAGE TAT",
                             avgRegistrationQueueingTime,
                             avgRegistrationTransactionTime,
                             avgPaymentTransactionTime,
                             avgProcedureQueueingTime,
                             avgProcedureRednderingTime,
                             "NOT YET PROCESSED")
                    End With
                    Dim worksheet3 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("LABORATORY JOURNEY TAT")
                    worksheet3.Cells.LoadFromDataTable(dtLaboratoryTimelineList, True)
                End If
                epLaboratory.SaveAs(labFile)
            End Using
            AppendLogs("[MANUAL][LAB FILE GENERATION][SUCCESS]: File generation success.")
            Return labFile
        Catch ex As Exception
            AppendLogs("[MANUAL][LAB FILE GENERATION][FAILED]: File generation failed. Error: " & ex.ToString)
            Return Nothing
        End Try
    End Function


    Private Function CustomExcelReport_GenerateLaboratory(fromdate As Date, todate As Date) As String
        Try
            Dim labFile As String = "\\ThirdParty-PC\Common\wmmc_pcms\tat_report\LAB" & fromdate.ToString("MMddyyyy") & fromdate.ToString("MMddyyyy") & ".xlsx"
            Using epLaboratory As ExcelPackage = New ExcelPackage()
                Dim consultID As Long = 5 'Consultation Triage ID
                Dim dxID As Long = 27 'Diagnostic Triage ID
                Dim cashierID As Long = 3 ' Cashier ID
                Dim hmoID As Long = 7 'HMO ID
                Dim labID As Long = 9 'Laboratory ID 

                Dim customerAssignCounterController As New CustomerAssignCounterController
                Dim labSummary As List(Of CounterSummary) = customerAssignCounterController.GetLaboratorySummaryByDate(fromdate, todate)
                Dim labList As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetPatientServedBy_Laboratory(fromdate, todate)
                Dim labTimeline As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetAllPatientServedBy_Counter(fromdate, todate, labID)
                Dim dtLaboratorySummary As New DataTable
                With dtLaboratorySummary.Columns
                    .Add("DEPARTMENT/SECTION")
                    .Add("# PATIENT QUEUED")
                    .Add("# CALLED & SERVED")
                    .Add("# CALLED BUT NOT SURVED")
                    .Add("# UNCALLED")
                    .Add("% CALLED & SERVED")
                    .Add("% CALLED BUT NOT SURVED")
                    .Add("% UNCALLED")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                End With
                If Not IsNothing(labSummary) Then
                    With dtLaboratorySummary.Rows
                        For Each labItem As CounterSummary In labSummary
                            Dim strServedPercent As String = "0 %"
                            Dim strUnservedPercent As String = "0 %"
                            Dim strHoldPercent As String = "0 %"
                            Dim strAveTimePercent As String = "0 %"
                            Dim strAveWaitingTimePercent As String = "0 %"
                            tmpQueueCount += labItem.QueuedCount
                            tmpServedCount += labItem.ServedCount
                            tmpHoldCount += labItem.HoldCount
                            tmpUnservedeCount += labItem.UnservedCount
                            If labItem.ServedCount > 0 Then
                                strServedPercent = (Format(((labItem.ServedCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.HoldCount > 0 Then
                                strHoldPercent = (Format(((labItem.HoldCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.UnservedCount > 0 Then
                                strUnservedPercent = (Format(((labItem.UnservedCount / labItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If labItem.AverageTurnoverTime > 0 Then
                                strAveTimePercent = (Format(labItem.AverageTurnoverTime & " Minutes")).ToString
                            ElseIf labItem.AverageTurnoverTime < 0 Then
                                strAveTimePercent = "0 %"
                            Else
                                strAveTimePercent = "Less than a Minute"
                            End If
                            If labItem.AverageWaitingTurnoverTime > 0 Then
                                strAveWaitingTimePercent = (Format(labItem.AverageWaitingTurnoverTime & " Minutes")).ToString
                            ElseIf labItem.AverageWaitingTurnoverTime < 0 Then
                                strAveWaitingTimePercent = "0 %"
                            Else
                                strAveWaitingTimePercent = "Less than a Minute"
                            End If
                            .Add(labItem.Counter.Section.ToUpper, labItem.QueuedCount, labItem.ServedCount, labItem.HoldCount, labItem.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                        Next
                    End With
                    Dim worksheet1 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Summary")
                    worksheet1.Cells.LoadFromDataTable(dtLaboratorySummary, True)
                End If
                Dim dtLaboratorList As New DataTable
                With dtLaboratorList.Columns
                    .Add("DATE QUEUED")
                    .Add("PATIENT NAME")
                    .Add("DEPARTMENT/SECTION")
                    .Add("QUEUE NUMBER")
                    .Add("SERVE START")
                    .Add("SERVED END")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                    .Add("SERVED BY")
                End With
                If Not IsNothing(labList) Then
                    With dtLaboratorList.Rows
                        For Each labitem As CustomerQueuedSummary In labList
                            Dim servedStart As String = "N/A"
                            Dim servedEnd As String = "N/A"
                            Dim servedBy As String = "N/A"
                            Dim servingTAT As String = "N/A"
                            Dim waitingTAT As String = "N/A"
                            If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer) Then
                                servedStart = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart, "MMM dd h:mm tt"), "N/A")
                                servedEnd = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd), Format(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd, "MMM dd h:mm tt"), "N/A")
                                servedBy = If(Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), labitem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                                If Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart) And Not IsNothing(labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd) Then
                                    Dim svtat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.ServedCustomer.DateTimeStart.Value, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    Dim wttat As Integer = DateDiff(DateInterval.Minute, labitem.CustomerAssignCounter.DateTimeQueued, labitem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    servingTAT = (If(svtat > 0, svtat & " Minutes", "Less than a Minute"))
                                    waitingTAT = (If(wttat > 0, wttat & " Minutes", "Less than a Minute"))
                                End If
                            End If
                            .Add(Format(labitem.CustomerAssignCounter.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"),
                                 (labitem.CustomerInfo.Lastname & ", " & labitem.CustomerInfo.FirstName & " " & labitem.CustomerInfo.Middlename & " " & labitem.CustomerInfo.Suffix).Trim.ToUpper,
                                 labitem.CustomerAssignCounter.Counter.ServiceDescription,
                                 labitem.CustomerAssignCounter.ProcessedQueueNumber,
                                 servedStart,
                                 servedEnd,
                                 servingTAT,
                                 waitingTAT,
                                 servedBy)
                        Next
                    End With
                    Dim worksheet2 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("Patient List")
                    worksheet2.Cells.LoadFromDataTable(dtLaboratorList, True)
                End If
                Dim dtLaboratoryTimelineList As New DataTable
                With dtLaboratoryTimelineList.Columns
                    .Add("DATE")
                    .Add("PATIENT NAME")
                    .Add("REGISTRATION QUEUEING TIME")
                    .Add("REGISTRATION TRANSACTION TIME")
                    .Add("PAYMENT TRANSACTION TIME")
                    .Add("PROCEDURE QUEUING TIME")
                    .Add("PROCEDURE RENDERING TIME")
                    .Add("RESULT RELEASING TIME")
                End With
                If Not IsNothing(labTimeline) Then
                    With dtLaboratoryTimelineList.Rows
                        Dim allRegistrationQueueingTime As New List(Of Long)
                        Dim allRegistrationTransactionTime As New List(Of Long)
                        Dim allPaymentTransactionTime As New List(Of Long)
                        Dim allProcedureQueueingTime As New List(Of Long)
                        Dim allProcedureRednderingTime As New List(Of Long)

                        For Each labitem As CustomerQueuedSummary In labTimeline
                            Dim tmpTriage As CustomerAssignCounter = Nothing
                            Dim tmpPayment As CustomerAssignCounter = Nothing
                            Dim tmpLaboratory As CustomerAssignCounter = Nothing
                            Dim tmpDateOfTransaction As Date = Nothing
                            For Each counter As CustomerAssignCounter In labitem.CustomerAssignCounters
                                If counter.Counter_ID = dxID Or counter.Counter_ID = consultID Then
                                    tmpTriage = counter
                                ElseIf counter.Counter_ID = cashierID Or counter.Counter_ID = hmoID Then
                                    tmpPayment = counter
                                ElseIf counter.Counter_ID = labID Then
                                    tmpLaboratory = counter
                                    tmpDateOfTransaction = tmpLaboratory.DateTimeQueued
                                    Exit For
                                End If
                            Next
                            'TAT CALCULATION
                            Dim registrationQueueingTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.DateTimeQueued, tmpTriage.ServedCustomer.DateTimeStart.Value)
                                        registrationQueueingTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationQueueingTime.Add(registrationQueueingTime)
                                    End If
                                End If
                            End If

                            Dim registrationTransactionTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) And Not IsNothing(tmpTriage.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.ServedCustomer.DateTimeStart.Value, tmpTriage.ServedCustomer.DateTimeEnd.Value)
                                        registrationTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationTransactionTime.Add(registrationTransactionTime)
                                    End If
                                End If
                            End If

                            Dim paymentTransactionTime As Integer = 0
                            If Not IsNothing(tmpPayment) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeStart) And Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeStart.Value, tmpPayment.ServedCustomer.DateTimeEnd.Value)
                                        paymentTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allPaymentTransactionTime.Add(paymentTransactionTime)
                                    End If
                                End If
                            End If

                            Dim procedureQueuingTime As Integer = 0
                            If Not IsNothing(tmpPayment) And Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) And Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeEnd.Value, tmpLaboratory.ServedCustomer.DateTimeStart.Value)
                                        procedureQueuingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureQueueingTime.Add(procedureQueuingTime)
                                    End If
                                End If
                            End If

                            Dim procedureRenderingTime As Integer = 0
                            If Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpLaboratory.ServedCustomer.DateTimeStart.Value, tmpLaboratory.ServedCustomer.DateTimeEnd.Value)
                                        procedureRenderingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureRednderingTime.Add(procedureRenderingTime)
                                    End If
                                End If
                            End If
                            .Add(Format(tmpDateOfTransaction, "MMM/dd"), (labitem.CustomerInfo.Lastname & ", " & labitem.CustomerInfo.FirstName & " " & labitem.CustomerInfo.Middlename & " " & labitem.CustomerInfo.Suffix).Trim.ToUpper,
                                 registrationQueueingTime,
                                 registrationTransactionTime,
                                 paymentTransactionTime,
                                 procedureQueuingTime,
                                 procedureRenderingTime,
                                 "NOT YET PROCESSED")
                        Next
                        Dim avgRegistrationQueueingTime As Long = 0
                        For Each x As Long In allRegistrationQueueingTime
                            avgRegistrationQueueingTime += x
                        Next
                        avgRegistrationQueueingTime = (avgRegistrationQueueingTime / If(allRegistrationQueueingTime.Count > 0, allRegistrationQueueingTime.Count, 1))

                        Dim avgRegistrationTransactionTime As Long = 0
                        For Each x As Long In allRegistrationTransactionTime
                            avgRegistrationTransactionTime += x
                        Next
                        avgRegistrationTransactionTime = (avgRegistrationTransactionTime / If(allRegistrationTransactionTime.Count > 0, allRegistrationTransactionTime.Count, 1))

                        Dim avgPaymentTransactionTime As Long = 0
                        For Each x As Long In allPaymentTransactionTime
                            avgPaymentTransactionTime += x
                        Next
                        avgPaymentTransactionTime = (avgPaymentTransactionTime / If(allPaymentTransactionTime.Count > 0, allPaymentTransactionTime.Count, 1))

                        Dim avgProcedureQueueingTime As Long = 0
                        For Each x As Long In allProcedureQueueingTime
                            avgProcedureQueueingTime += x
                        Next
                        avgProcedureQueueingTime = (avgProcedureQueueingTime / If(allProcedureQueueingTime.Count > 0, allProcedureQueueingTime.Count, 1))

                        Dim avgProcedureRednderingTime As Long = 0
                        For Each x As Long In allProcedureRednderingTime
                            avgProcedureRednderingTime += x
                        Next
                        avgProcedureRednderingTime = (avgProcedureRednderingTime / If(allProcedureRednderingTime.Count > 0, allProcedureRednderingTime.Count, 1))
                        .Add("", "AVERAGE TAT",
                             avgRegistrationQueueingTime,
                             avgRegistrationTransactionTime,
                             avgPaymentTransactionTime,
                             avgProcedureQueueingTime,
                             avgProcedureRednderingTime,
                             "NOT YET PROCESSED")
                    End With
                    Dim worksheet3 As ExcelWorksheet = epLaboratory.Workbook.Worksheets.Add("LABORATORY JOURNEY TAT")
                    worksheet3.Cells.LoadFromDataTable(dtLaboratoryTimelineList, True)
                End If
                epLaboratory.SaveAs(labFile)
            End Using
            AppendLogs("[MANUAL][LAB FILE GENERATION][SUCCESS]: File generation success.")
            Return labFile
        Catch ex As Exception
            AppendLogs("[MANUAL][LAB FILE GENERATION][FAILED]: File generation failed. Error: " & ex.ToString)
            Return Nothing
        End Try
    End Function

    Private Function CustomExcelReport_GenerateRadiology(fromdate As Date, todate As Date) As String
        Try
            Dim radFile As String = "\\ThirdParty-PC\Common\wmmc_pcms\tat_report\RAD\" & fromdate.ToString("MMddyyyyhhmmss") & fromdate.ToString("MMddyyyyhhmmss") & ".xlsx"
            Using epRadiology As ExcelPackage = New ExcelPackage()
                Dim consultID As Long = 28 'Consultation Triage ID
                Dim dxID As Long = 29 'Diagnostic Triage ID
                Dim cashierID As Long = 34 ' Cashier ID
                Dim hmoID As Long = 35 'HMO ID
                Dim ultrasoundID As Long = 54
                'Dim ctscanID As Long = 54
                'Dim xrayID As Long = 54

                Dim customerAssignCounterController As New CustomerAssignCounterController
                Dim radSummary As List(Of CounterSummary) = customerAssignCounterController.GetRadiologySummaryByDate(fromdate, todate)
                Dim radList As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetPatientServedBy_Radiology(fromdate, todate)
                Dim ultrasoundTimeline As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetAllPatientServedBy_Counter(fromdate, todate, ultrasoundID)
                'Dim ctscanTimeline As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetAllPatientServedBy_Counter(fromdate, todate, ctscanID)
                'Dim xrayTimeline As List(Of CustomerQueuedSummary) = customerAssignCounterController.GetAllPatientServedBy_Counter(fromdate, todate, xrayID)

                Dim dtRadiologySummary As New DataTable
                With dtRadiologySummary.Columns
                    .Add("DEPARTMENT/SECTION")
                    .Add("# PATIENT QUEUED")
                    .Add("# CALLED & SERVED")
                    .Add("# CALLED BUT NOT SURVED")
                    .Add("# UNCALLED")
                    .Add("% CALLED & SERVED")
                    .Add("% CALLED BUT NOT SURVED")
                    .Add("% UNCALLED")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                End With
                If Not IsNothing(radSummary) Then
                    With dtRadiologySummary.Rows
                        For Each radItem As CounterSummary In radSummary
                            Dim strServedPercent As String = "0 %"
                            Dim strUnservedPercent As String = "0 %"
                            Dim strHoldPercent As String = "0 %"
                            Dim strAveTimePercent As String = "0 %"
                            Dim strAveWaitingTimePercent As String = "0 %"
                            tmpQueueCount += radItem.QueuedCount
                            tmpServedCount += radItem.ServedCount
                            tmpHoldCount += radItem.HoldCount
                            tmpUnservedeCount += radItem.UnservedCount
                            If radItem.ServedCount > 0 Then
                                strServedPercent = (Format(((radItem.ServedCount / radItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If radItem.HoldCount > 0 Then
                                strHoldPercent = (Format(((radItem.HoldCount / radItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If radItem.UnservedCount > 0 Then
                                strUnservedPercent = (Format(((radItem.UnservedCount / radItem.QueuedCount) * 100), "0") & " %").ToString
                            End If
                            If radItem.AverageTurnoverTime > 0 Then
                                strAveTimePercent = (Format(radItem.AverageTurnoverTime & " Minutes")).ToString
                            ElseIf radItem.AverageTurnoverTime < 0 Then
                                strAveTimePercent = "0 %"
                            Else
                                strAveTimePercent = "Less than a Minute"
                            End If
                            If radItem.AverageWaitingTurnoverTime > 0 Then
                                strAveWaitingTimePercent = (Format(radItem.AverageWaitingTurnoverTime & " Minutes")).ToString
                            ElseIf radItem.AverageWaitingTurnoverTime < 0 Then
                                strAveWaitingTimePercent = "0 %"
                            Else
                                strAveWaitingTimePercent = "Less than a Minute"
                            End If
                            .Add(radItem.Counter.Section.ToUpper, radItem.QueuedCount, radItem.ServedCount, radItem.HoldCount, radItem.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                        Next
                    End With
                    Dim worksheet1 As ExcelWorksheet = epRadiology.Workbook.Worksheets.Add("Summary")
                    worksheet1.Cells.LoadFromDataTable(dtRadiologySummary, True)
                End If

                Dim dtRadiologyList As New DataTable
                With dtRadiologyList.Columns
                    .Add("DATE QUEUED")
                    .Add("PATIENT NAME")
                    .Add("DEPARTMENT/SECTION")
                    .Add("QUEUE NUMBER")
                    .Add("SERVE START")
                    .Add("SERVED END")
                    .Add("SERVING TAT")
                    .Add("WAITING TAT")
                    .Add("SERVED BY")
                End With
                If Not IsNothing(radList) Then
                    With dtRadiologyList.Rows
                        For Each raditem As CustomerQueuedSummary In radList
                            Dim servedStart As String = "N/A"
                            Dim servedEnd As String = "N/A"
                            Dim servedBy As String = "N/A"
                            Dim servingTAT As String = "N/A"
                            Dim waitingTAT As String = "N/A"
                            If Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer) Then
                                servedStart = If(Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer.DateTimeStart), Format(raditem.CustomerAssignCounter.ServedCustomer.DateTimeStart, "MMM dd h:mm tt"), "N/A")
                                servedEnd = If(Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer.DateTimeEnd), Format(raditem.CustomerAssignCounter.ServedCustomer.DateTimeEnd, "MMM dd h:mm tt"), "N/A")
                                servedBy = If(Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), raditem.CustomerAssignCounter.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                                If Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer.DateTimeStart) And Not IsNothing(raditem.CustomerAssignCounter.ServedCustomer.DateTimeEnd) Then
                                    Dim svtat As Integer = DateDiff(DateInterval.Minute, raditem.CustomerAssignCounter.ServedCustomer.DateTimeStart.Value, raditem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    Dim wttat As Integer = DateDiff(DateInterval.Minute, raditem.CustomerAssignCounter.DateTimeQueued, raditem.CustomerAssignCounter.ServedCustomer.DateTimeEnd.Value)
                                    servingTAT = (If(svtat > 0, svtat & " Minutes", "Less than a Minute"))
                                    waitingTAT = (If(wttat > 0, wttat & " Minutes", "Less than a Minute"))
                                End If
                            End If
                            .Add(Format(raditem.CustomerAssignCounter.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"),
                                 (raditem.CustomerInfo.Lastname & ", " & raditem.CustomerInfo.FirstName & " " & raditem.CustomerInfo.Middlename & " " & raditem.CustomerInfo.Suffix).Trim.ToUpper,
                                 raditem.CustomerAssignCounter.Counter.ServiceDescription,
                                 raditem.CustomerAssignCounter.ProcessedQueueNumber,
                                 servedStart,
                                 servedEnd,
                                 servingTAT,
                                 waitingTAT,
                                 servedBy)
                        Next
                    End With
                    Dim worksheet2 As ExcelWorksheet = epRadiology.Workbook.Worksheets.Add("Patient List")
                    worksheet2.Cells.LoadFromDataTable(dtRadiologyList, True)
                End If

                Dim dtUltrasoundTimelineList As New DataTable
                With dtUltrasoundTimelineList.Columns
                    .Add("PATIENT NAME")
                    .Add("REGISTRATION QUEUEING TIME")
                    .Add("REGISTRATION TRANSACTION TIME")
                    .Add("PAYMENT TRANSACTION TIME")
                    .Add("PROCEDURE QUEUING TIME")
                    .Add("PROCEDURE RENDERING TIME")
                    .Add("RESULT RELEASING TIME")
                End With
                If Not IsNothing(dtUltrasoundTimelineList) Then
                    With dtUltrasoundTimelineList.Rows
                        Dim allRegistrationQueueingTime As New List(Of Long)
                        Dim allRegistrationTransactionTime As New List(Of Long)
                        Dim allPaymentTransactionTime As New List(Of Long)
                        Dim allProcedureQueueingTime As New List(Of Long)
                        Dim allProcedureRednderingTime As New List(Of Long)

                        For Each raditem As CustomerQueuedSummary In ultrasoundTimeline
                            Dim tmpTriage As CustomerAssignCounter = Nothing
                            Dim tmpPayment As CustomerAssignCounter = Nothing
                            Dim tmpLaboratory As CustomerAssignCounter = Nothing
                            For Each counter As CustomerAssignCounter In raditem.CustomerAssignCounters
                                If counter.Counter_ID = dxID Or counter.Counter_ID = consultID Then
                                    tmpTriage = counter
                                ElseIf counter.Counter_ID = cashierID Or counter.Counter_ID = hmoID Then
                                    tmpPayment = counter
                                ElseIf counter.Counter_ID = ultrasoundID Then
                                    tmpLaboratory = counter
                                    Exit For
                                End If
                            Next
                            'TAT CALCULATION
                            Dim registrationQueueingTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.DateTimeQueued, tmpTriage.ServedCustomer.DateTimeStart.Value)
                                        registrationQueueingTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationQueueingTime.Add(registrationQueueingTime)
                                    End If
                                End If
                            End If

                            Dim registrationTransactionTime As Integer = 0
                            If Not IsNothing(tmpTriage) Then
                                If Not IsNothing(tmpTriage.ServedCustomer) Then
                                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) And Not IsNothing(tmpTriage.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.ServedCustomer.DateTimeStart.Value, tmpTriage.ServedCustomer.DateTimeEnd.Value)
                                        registrationTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allRegistrationTransactionTime.Add(registrationTransactionTime)
                                    End If
                                End If
                            End If

                            Dim paymentTransactionTime As Integer = 0
                            If Not IsNothing(tmpPayment) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeStart) And Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeStart.Value, tmpPayment.ServedCustomer.DateTimeEnd.Value)
                                        paymentTransactionTime = If(tmpVal > 0, tmpVal, 1)
                                        allPaymentTransactionTime.Add(paymentTransactionTime)
                                    End If
                                End If
                            End If

                            Dim procedureQueuingTime As Integer = 0
                            If Not IsNothing(tmpPayment) And Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpPayment.ServedCustomer) And Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeEnd.Value, tmpLaboratory.ServedCustomer.DateTimeStart.Value)
                                        procedureQueuingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureQueueingTime.Add(procedureQueuingTime)
                                    End If
                                End If
                            End If

                            Dim procedureRenderingTime As Integer = 0
                            If Not IsNothing(tmpLaboratory) Then
                                If Not IsNothing(tmpLaboratory.ServedCustomer) Then
                                    If Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeEnd) Then
                                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpLaboratory.ServedCustomer.DateTimeStart.Value, tmpLaboratory.ServedCustomer.DateTimeEnd.Value)
                                        procedureRenderingTime = If(tmpVal > 0, tmpVal, 1)
                                        allProcedureRednderingTime.Add(procedureRenderingTime)
                                    End If
                                End If
                            End If

                            .Add((raditem.CustomerInfo.Lastname & ", " & raditem.CustomerInfo.FirstName & " " & raditem.CustomerInfo.Middlename & " " & raditem.CustomerInfo.Suffix).Trim.ToUpper,
                                 registrationQueueingTime,
                                 registrationTransactionTime,
                                 paymentTransactionTime,
                                 procedureQueuingTime,
                                 procedureRenderingTime,
                                 "NOT YET PROCESSED")
                        Next
                        Dim avgRegistrationQueueingTime As Long = 0
                        For Each x As Long In allRegistrationQueueingTime
                            avgRegistrationQueueingTime += x
                        Next
                        avgRegistrationQueueingTime = (avgRegistrationQueueingTime / If(allRegistrationQueueingTime.Count > 0, allRegistrationQueueingTime.Count, 1))

                        Dim avgRegistrationTransactionTime As Long = 0
                        For Each x As Long In allRegistrationTransactionTime
                            avgRegistrationTransactionTime += x
                        Next
                        avgRegistrationTransactionTime = (avgRegistrationTransactionTime / If(allRegistrationTransactionTime.Count > 0, allRegistrationTransactionTime.Count, 1))

                        Dim avgPaymentTransactionTime As Long = 0
                        For Each x As Long In allPaymentTransactionTime
                            avgPaymentTransactionTime += x
                        Next
                        avgPaymentTransactionTime = (avgPaymentTransactionTime / If(allPaymentTransactionTime.Count > 0, allPaymentTransactionTime.Count, 1))

                        Dim avgProcedureQueueingTime As Long = 0
                        For Each x As Long In allProcedureQueueingTime
                            avgProcedureQueueingTime += x
                        Next
                        avgProcedureQueueingTime = (avgProcedureQueueingTime / If(allProcedureQueueingTime.Count > 0, allProcedureQueueingTime.Count, 1))

                        Dim avgProcedureRednderingTime As Long = 0
                        For Each x As Long In allProcedureRednderingTime
                            avgProcedureRednderingTime += x
                        Next
                        avgProcedureRednderingTime = (avgProcedureRednderingTime / If(allProcedureRednderingTime.Count > 0, allProcedureRednderingTime.Count, 1))
                        .Add("AVERAGE TAT",
                             avgRegistrationQueueingTime,
                             avgRegistrationTransactionTime,
                             avgPaymentTransactionTime,
                             avgProcedureQueueingTime,
                             avgProcedureRednderingTime,
                             "NOT YET PROCESSED")
                    End With
                    Dim worksheet3 As ExcelWorksheet = epRadiology.Workbook.Worksheets.Add("RADIOLGY JOURNEY TAT")
                    worksheet3.Cells.LoadFromDataTable(dtUltrasoundTimelineList, True)
                End If

                'Dim dtCTScanTimelineList As New DataTable
                'With dtCTScanTimelineList.Columns
                '    .Add("PATIENT NAME")
                '    .Add("REGISTRATION QUEUEING TIME")
                '    .Add("REGISTRATION TRANSACTION TIME")
                '    .Add("PAYMENT TRANSACTION TIME")
                '    .Add("PROCEDURE QUEUING TIME")
                '    .Add("PROCEDURE RENDERING TIME")
                '    .Add("RESULT RELEASING TIME")
                'End With
                'If Not IsNothing(ctscanTimeline) Then
                '    With dtCTScanTimelineList.Rows
                '        Dim allRegistrationQueueingTime As New List(Of Long)
                '        Dim allRegistrationTransactionTime As New List(Of Long)
                '        Dim allPaymentTransactionTime As New List(Of Long)
                '        Dim allProcedureQueueingTime As New List(Of Long)
                '        Dim allProcedureRednderingTime As New List(Of Long)

                '        For Each raditem As CustomerQueuedSummary In ctscanTimeline
                '            Dim tmpTriage As CustomerAssignCounter = Nothing
                '            Dim tmpPayment As CustomerAssignCounter = Nothing
                '            Dim tmpLaboratory As CustomerAssignCounter = Nothing
                '            For Each counter As CustomerAssignCounter In raditem.CustomerAssignCounters
                '                If counter.Counter_ID = dxID Or counter.Counter_ID = consultID Then
                '                    tmpTriage = counter
                '                ElseIf counter.Counter_ID = cashierID Or counter.Counter_ID = hmoID Then
                '                    tmpPayment = counter
                '                ElseIf counter.Counter_ID = ctscanID Then
                '                    tmpLaboratory = counter
                '                    Exit For
                '                End If
                '            Next
                '            'TAT CALCULATION
                '            Dim registrationQueueingTime As Integer = 0
                '            If Not IsNothing(tmpTriage) Then
                '                If Not IsNothing(tmpTriage.ServedCustomer) Then
                '                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.DateTimeQueued, tmpTriage.ServedCustomer.DateTimeStart.Value)
                '                        registrationQueueingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allRegistrationQueueingTime.Add(registrationQueueingTime)
                '                    End If
                '                End If
                '            End If

                '            Dim registrationTransactionTime As Integer = 0
                '            If Not IsNothing(tmpTriage) Then
                '                If Not IsNothing(tmpTriage.ServedCustomer) Then
                '                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) And Not IsNothing(tmpTriage.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.ServedCustomer.DateTimeStart.Value, tmpTriage.ServedCustomer.DateTimeEnd.Value)
                '                        registrationTransactionTime = If(tmpVal > 0, tmpVal, 1)
                '                        allRegistrationTransactionTime.Add(registrationTransactionTime)
                '                    End If
                '                End If
                '            End If

                '            Dim paymentTransactionTime As Integer = 0
                '            If Not IsNothing(tmpPayment) Then
                '                If Not IsNothing(tmpPayment.ServedCustomer) Then
                '                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeStart) And Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeStart.Value, tmpPayment.ServedCustomer.DateTimeEnd.Value)
                '                        paymentTransactionTime = If(tmpVal > 0, tmpVal, 1)
                '                        allPaymentTransactionTime.Add(paymentTransactionTime)
                '                    End If
                '                End If
                '            End If

                '            Dim procedureQueuingTime As Integer = 0
                '            If Not IsNothing(tmpPayment) And Not IsNothing(tmpLaboratory) Then
                '                If Not IsNothing(tmpPayment.ServedCustomer) And Not IsNothing(tmpLaboratory.ServedCustomer) Then
                '                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeEnd.Value, tmpLaboratory.ServedCustomer.DateTimeStart.Value)
                '                        procedureQueuingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allProcedureQueueingTime.Add(procedureQueuingTime)
                '                    End If
                '                End If
                '            End If

                '            Dim procedureRenderingTime As Integer = 0
                '            If Not IsNothing(tmpLaboratory) Then
                '                If Not IsNothing(tmpLaboratory.ServedCustomer) Then
                '                    If Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpLaboratory.ServedCustomer.DateTimeStart.Value, tmpLaboratory.ServedCustomer.DateTimeEnd.Value)
                '                        procedureRenderingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allProcedureRednderingTime.Add(procedureRenderingTime)
                '                    End If
                '                End If
                '            End If

                '            .Add((raditem.CustomerInfo.Lastname & ", " & raditem.CustomerInfo.FirstName & " " & raditem.CustomerInfo.Middlename & " " & raditem.CustomerInfo.Suffix).Trim.ToUpper,
                '                 registrationQueueingTime,
                '                 registrationTransactionTime,
                '                 paymentTransactionTime,
                '                 procedureQueuingTime,
                '                 procedureRenderingTime,
                '                 "NOT YET PROCESSED")
                '        Next
                '        Dim avgRegistrationQueueingTime As Long = 0
                '        For Each x As Long In allRegistrationQueueingTime
                '            avgRegistrationQueueingTime += x
                '        Next
                '        avgRegistrationQueueingTime = (avgRegistrationQueueingTime / If(allRegistrationQueueingTime.Count > 0, allRegistrationQueueingTime.Count, 1))

                '        Dim avgRegistrationTransactionTime As Long = 0
                '        For Each x As Long In allRegistrationTransactionTime
                '            avgRegistrationTransactionTime += x
                '        Next
                '        avgRegistrationTransactionTime = (avgRegistrationTransactionTime / If(allRegistrationTransactionTime.Count > 0, allRegistrationTransactionTime.Count, 1))

                '        Dim avgPaymentTransactionTime As Long = 0
                '        For Each x As Long In allPaymentTransactionTime
                '            avgPaymentTransactionTime += x
                '        Next
                '        avgPaymentTransactionTime = (avgPaymentTransactionTime / If(allPaymentTransactionTime.Count > 0, allPaymentTransactionTime.Count, 1))

                '        Dim avgProcedureQueueingTime As Long = 0
                '        For Each x As Long In allProcedureQueueingTime
                '            avgProcedureQueueingTime += x
                '        Next
                '        avgProcedureQueueingTime = (avgProcedureQueueingTime / If(allProcedureQueueingTime.Count > 0, allProcedureQueueingTime.Count, 1))

                '        Dim avgProcedureRednderingTime As Long = 0
                '        For Each x As Long In allProcedureRednderingTime
                '            avgProcedureRednderingTime += x
                '        Next
                '        avgProcedureRednderingTime = (avgProcedureRednderingTime / If(allProcedureRednderingTime.Count > 0, allProcedureRednderingTime.Count, 1))
                '        .Add("AVERAGE TAT",
                '             avgRegistrationQueueingTime,
                '             avgRegistrationTransactionTime,
                '             avgPaymentTransactionTime,
                '             avgProcedureQueueingTime,
                '             avgProcedureRednderingTime,
                '             "NOT YET PROCESSED")
                '    End With
                '    Dim worksheet3 As ExcelWorksheet = epRadiology.Workbook.Worksheets.Add("CT SCAN JOURNEY TAT")
                '    worksheet3.Cells.LoadFromDataTable(dtCTScanTimelineList, True)
                'End If

                'Dim dtXRayTimelineList As New DataTable
                'With dtXRayTimelineList.Columns
                '    .Add("PATIENT NAME")
                '    .Add("REGISTRATION QUEUEING TIME")
                '    .Add("REGISTRATION TRANSACTION TIME")
                '    .Add("PAYMENT TRANSACTION TIME")
                '    .Add("PROCEDURE QUEUING TIME")
                '    .Add("PROCEDURE RENDERING TIME")
                '    .Add("RESULT RELEASING TIME")
                'End With
                'If Not IsNothing(xrayTimeline) Then
                '    With dtXRayTimelineList.Rows
                '        Dim allRegistrationQueueingTime As New List(Of Long)
                '        Dim allRegistrationTransactionTime As New List(Of Long)
                '        Dim allPaymentTransactionTime As New List(Of Long)
                '        Dim allProcedureQueueingTime As New List(Of Long)
                '        Dim allProcedureRednderingTime As New List(Of Long)

                '        For Each raditem As CustomerQueuedSummary In xrayTimeline
                '            Dim tmpTriage As CustomerAssignCounter = Nothing
                '            Dim tmpPayment As CustomerAssignCounter = Nothing
                '            Dim tmpLaboratory As CustomerAssignCounter = Nothing
                '            For Each counter As CustomerAssignCounter In raditem.CustomerAssignCounters
                '                If counter.Counter_ID = dxID Or counter.Counter_ID = consultID Then
                '                    tmpTriage = counter
                '                ElseIf counter.Counter_ID = cashierID Or counter.Counter_ID = hmoID Then
                '                    tmpPayment = counter
                '                ElseIf counter.Counter_ID = xrayID Then
                '                    tmpLaboratory = counter
                '                    Exit For
                '                End If
                '            Next
                '            'TAT CALCULATION
                '            Dim registrationQueueingTime As Integer = 0
                '            If Not IsNothing(tmpTriage) Then
                '                If Not IsNothing(tmpTriage.ServedCustomer) Then
                '                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.DateTimeQueued, tmpTriage.ServedCustomer.DateTimeStart.Value)
                '                        registrationQueueingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allRegistrationQueueingTime.Add(registrationQueueingTime)
                '                    End If
                '                End If
                '            End If

                '            Dim registrationTransactionTime As Integer = 0
                '            If Not IsNothing(tmpTriage) Then
                '                If Not IsNothing(tmpTriage.ServedCustomer) Then
                '                    If Not IsNothing(tmpTriage.ServedCustomer.DateTimeStart) And Not IsNothing(tmpTriage.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpTriage.ServedCustomer.DateTimeStart.Value, tmpTriage.ServedCustomer.DateTimeEnd.Value)
                '                        registrationTransactionTime = If(tmpVal > 0, tmpVal, 1)
                '                        allRegistrationTransactionTime.Add(registrationTransactionTime)
                '                    End If
                '                End If
                '            End If

                '            Dim paymentTransactionTime As Integer = 0
                '            If Not IsNothing(tmpPayment) Then
                '                If Not IsNothing(tmpPayment.ServedCustomer) Then
                '                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeStart) And Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeStart.Value, tmpPayment.ServedCustomer.DateTimeEnd.Value)
                '                        paymentTransactionTime = If(tmpVal > 0, tmpVal, 1)
                '                        allPaymentTransactionTime.Add(paymentTransactionTime)
                '                    End If
                '                End If
                '            End If

                '            Dim procedureQueuingTime As Integer = 0
                '            If Not IsNothing(tmpPayment) And Not IsNothing(tmpLaboratory) Then
                '                If Not IsNothing(tmpPayment.ServedCustomer) And Not IsNothing(tmpLaboratory.ServedCustomer) Then
                '                    If Not IsNothing(tmpPayment.ServedCustomer.DateTimeEnd) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpPayment.ServedCustomer.DateTimeEnd.Value, tmpLaboratory.ServedCustomer.DateTimeStart.Value)
                '                        procedureQueuingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allProcedureQueueingTime.Add(procedureQueuingTime)
                '                    End If
                '                End If
                '            End If

                '            Dim procedureRenderingTime As Integer = 0
                '            If Not IsNothing(tmpLaboratory) Then
                '                If Not IsNothing(tmpLaboratory.ServedCustomer) Then
                '                    If Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeStart) And Not IsNothing(tmpLaboratory.ServedCustomer.DateTimeEnd) Then
                '                        Dim tmpVal As Integer = DateDiff(DateInterval.Minute, tmpLaboratory.ServedCustomer.DateTimeStart.Value, tmpLaboratory.ServedCustomer.DateTimeEnd.Value)
                '                        procedureRenderingTime = If(tmpVal > 0, tmpVal, 1)
                '                        allProcedureRednderingTime.Add(procedureRenderingTime)
                '                    End If
                '                End If
                '            End If

                '            .Add((raditem.CustomerInfo.Lastname & ", " & raditem.CustomerInfo.FirstName & " " & raditem.CustomerInfo.Middlename & " " & raditem.CustomerInfo.Suffix).Trim.ToUpper,
                '                 registrationQueueingTime,
                '                 registrationTransactionTime,
                '                 paymentTransactionTime,
                '                 procedureQueuingTime,
                '                 procedureRenderingTime,
                '                 "NOT YET PROCESSED")
                '        Next
                '        Dim avgRegistrationQueueingTime As Long = 0
                '        For Each x As Long In allRegistrationQueueingTime
                '            avgRegistrationQueueingTime += x
                '        Next
                '        avgRegistrationQueueingTime = (avgRegistrationQueueingTime / If(allRegistrationQueueingTime.Count > 0, allRegistrationQueueingTime.Count, 1))

                '        Dim avgRegistrationTransactionTime As Long = 0
                '        For Each x As Long In allRegistrationTransactionTime
                '            avgRegistrationTransactionTime += x
                '        Next
                '        avgRegistrationTransactionTime = (avgRegistrationTransactionTime / If(allRegistrationTransactionTime.Count > 0, allRegistrationTransactionTime.Count, 1))

                '        Dim avgPaymentTransactionTime As Long = 0
                '        For Each x As Long In allPaymentTransactionTime
                '            avgPaymentTransactionTime += x
                '        Next
                '        avgPaymentTransactionTime = (avgPaymentTransactionTime / If(allPaymentTransactionTime.Count > 0, allPaymentTransactionTime.Count, 1))

                '        Dim avgProcedureQueueingTime As Long = 0
                '        For Each x As Long In allProcedureQueueingTime
                '            avgProcedureQueueingTime += x
                '        Next
                '        avgProcedureQueueingTime = (avgProcedureQueueingTime / If(allProcedureQueueingTime.Count > 0, allProcedureQueueingTime.Count, 1))

                '        Dim avgProcedureRednderingTime As Long = 0
                '        For Each x As Long In allProcedureRednderingTime
                '            avgProcedureRednderingTime += x
                '        Next
                '        avgProcedureRednderingTime = (avgProcedureRednderingTime / If(allProcedureRednderingTime.Count > 0, allProcedureRednderingTime.Count, 1))
                '        .Add("AVERAGE TAT",
                '             avgRegistrationQueueingTime,
                '             avgRegistrationTransactionTime,
                '             avgPaymentTransactionTime,
                '             avgProcedureQueueingTime,
                '             avgProcedureRednderingTime,
                '             "NOT YET PROCESSED")
                '    End With
                '    Dim worksheet3 As ExcelWorksheet = epRadiology.Workbook.Worksheets.Add("XRAY JOURNEY TAT")
                '    worksheet3.Cells.LoadFromDataTable(dtXRayTimelineList, True)
                'End If

                epRadiology.SaveAs(radFile)
            End Using
            AppendLogs("[MANUAL][RAD FILE GENERATION][SUCCESS]: File generation success.")
            Return radFile
        Catch ex As Exception
            AppendLogs("[MANUAL][RAD FILE GENERATION][FAILED]: File generation failed. Error: " & ex.ToString)
            Return Nothing
        End Try
    End Function

    Private Sub getCounterSummary()
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim counteSummary As List(Of CounterSummary) = customerAssignCounterController.GetCounterSummaryByDate(dtpFrom.Value, dtpTo.Value)
        Dim PCCSummary As CounterSummary = customerAssignCounterController.GetPCCClinicCSummaryByDate(dtpFrom.Value, dtpTo.Value)
        Dim PCCHybridSummary As CounterSummary = customerAssignCounterController.GetPCCHybridClinicCSummaryByDate(dtpFrom.Value, dtpTo.Value)
        Dim MABHybridSummary As CounterSummary = customerAssignCounterController.GetMABHybridClinicCounterSummaryByDate(dtpFrom.Value, dtpTo.Value)
        Dim MABSummary As CounterSummary = customerAssignCounterController.GetMABClinicCSummaryByDate(dtpFrom.Value, dtpTo.Value)
        Dim reconSummary As PatientTATReconnReport = customerAssignCounterController.GetPCCTATReconData(dtpFrom.Value, dtpTo.Value)
        dvgCounterHistory.Rows.Clear()
        If counteSummary.Count > 0 Then
            Dim ctr As Long = 0
            tmpQueueCount = 0
            tmpServedCount = 0
            tmpHoldCount = 0
            tmpUnservedeCount = 0
            For Each counter As CounterSummary In counteSummary
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                tmpQueueCount += counter.QueuedCount
                tmpServedCount += counter.ServedCount
                tmpHoldCount += counter.HoldCount
                tmpUnservedeCount += counter.UnservedCount
                If counter.ServedCount > 0 Then
                    strServedPercent = (Format(((counter.ServedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.HoldCount > 0 Then
                    strHoldPercent = (Format(((counter.HoldCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((counter.UnservedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(counter.AverageTurnoverTime & " Minutes")).ToString
                ElseIf counter.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If counter.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(counter.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf counter.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dvgCounterHistory.Rows.Add(counter.Counter.Counter_ID, counter.Counter.Section.ToUpper, counter.QueuedCount, counter.ServedCount, counter.HoldCount, counter.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                dvgCounterHistory.Rows(ctr).Height = 30
                ctr += 1
            Next
        End If
        If Not IsNothing(PCCSummary) Then
            Dim strServedPercent As String = "0 %"
            Dim strUnservedPercent As String = "0 %"
            Dim strHoldPercent As String = "0 %"
            Dim strAveTimePercent As String = "0 %"
            Dim strAveWaitingTimePercent As String = "0 %"
            tmpQueueCount += PCCSummary.QueuedCount
            tmpServedCount += PCCSummary.ServedCount
            tmpHoldCount += PCCSummary.HoldCount
            tmpUnservedeCount += PCCSummary.UnservedCount
            If PCCSummary.ServedCount > 0 Then
                strServedPercent = (Format(((PCCSummary.ServedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCSummary.HoldCount > 0 Then
                strHoldPercent = (Format(((PCCSummary.HoldCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCSummary.UnservedCount > 0 Then
                strUnservedPercent = (Format(((PCCSummary.UnservedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCSummary.AverageTurnoverTime > 0 Then
                strAveTimePercent = (Format(PCCSummary.AverageTurnoverTime & " Minutes")).ToString
            ElseIf PCCSummary.AverageTurnoverTime < 0 Then
                strAveTimePercent = "0 %"
            Else
                strAveTimePercent = "Less than a Minute"
            End If
            If PCCSummary.AverageWaitingTurnoverTime > 0 Then
                strAveWaitingTimePercent = (Format(PCCSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            ElseIf PCCSummary.AverageWaitingTurnoverTime < 0 Then
                strAveWaitingTimePercent = "0 %"
            Else
                strAveWaitingTimePercent = "Less than a Minute"
            End If
            dvgCounterHistory.Rows.Add(PCCSummary.Counter.Counter_ID, PCCSummary.Counter.Section, PCCSummary.QueuedCount, PCCSummary.ServedCount, PCCSummary.HoldCount, PCCSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            dvgCounterHistory.Rows(dvgCounterHistory.Rows.Count - 1).Height = 30
        End If
        If Not IsNothing(PCCHybridSummary) Then
            Dim strServedPercent As String = "0 %"
            Dim strUnservedPercent As String = "0 %"
            Dim strHoldPercent As String = "0 %"
            Dim strAveTimePercent As String = "0 %"
            Dim strAveWaitingTimePercent As String = "0 %"
            tmpQueueCount += PCCHybridSummary.QueuedCount
            tmpServedCount += PCCHybridSummary.ServedCount
            tmpHoldCount += PCCHybridSummary.HoldCount
            tmpUnservedeCount += PCCHybridSummary.UnservedCount
            If PCCHybridSummary.ServedCount > 0 Then
                strServedPercent = (Format(((PCCHybridSummary.ServedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCHybridSummary.HoldCount > 0 Then
                strHoldPercent = (Format(((PCCHybridSummary.HoldCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCHybridSummary.UnservedCount > 0 Then
                strUnservedPercent = (Format(((PCCHybridSummary.UnservedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If PCCHybridSummary.AverageTurnoverTime > 0 Then
                strAveTimePercent = (Format(PCCHybridSummary.AverageTurnoverTime & " Minutes")).ToString
            ElseIf PCCHybridSummary.AverageTurnoverTime < 0 Then
                strAveTimePercent = "0 %"
            Else
                strAveTimePercent = "Less than a Minute"
            End If
            If PCCHybridSummary.AverageWaitingTurnoverTime > 0 Then
                strAveWaitingTimePercent = (Format(PCCHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            ElseIf PCCHybridSummary.AverageWaitingTurnoverTime < 0 Then
                strAveWaitingTimePercent = "0 %"
            Else
                strAveWaitingTimePercent = "Less than a Minute"
            End If
            dvgCounterHistory.Rows.Add(PCCHybridSummary.Counter.Counter_ID, PCCHybridSummary.Counter.Section, PCCHybridSummary.QueuedCount, PCCHybridSummary.ServedCount, PCCHybridSummary.HoldCount, PCCHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            dvgCounterHistory.Rows(dvgCounterHistory.Rows.Count - 1).Height = 30
        End If
        If Not IsNothing(MABHybridSummary) Then
            Dim strServedPercent As String = "0 %"
            Dim strUnservedPercent As String = "0 %"
            Dim strHoldPercent As String = "0 %"
            Dim strAveTimePercent As String = "0 %"
            Dim strAveWaitingTimePercent As String = "0 %"
            tmpQueueCount += MABHybridSummary.QueuedCount
            tmpServedCount += MABHybridSummary.ServedCount
            tmpHoldCount += MABHybridSummary.HoldCount
            tmpUnservedeCount += MABHybridSummary.UnservedCount
            If MABHybridSummary.ServedCount > 0 Then
                strServedPercent = (Format(((MABHybridSummary.ServedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABHybridSummary.HoldCount > 0 Then
                strHoldPercent = (Format(((MABHybridSummary.HoldCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABHybridSummary.UnservedCount > 0 Then
                strUnservedPercent = (Format(((MABHybridSummary.UnservedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABHybridSummary.AverageTurnoverTime > 0 Then
                strAveTimePercent = (Format(MABHybridSummary.AverageTurnoverTime & " Minutes")).ToString
            ElseIf MABHybridSummary.AverageTurnoverTime < 0 Then
                strAveTimePercent = "0 %"
            Else
                strAveTimePercent = "Less than a Minute"
            End If
            If MABHybridSummary.AverageWaitingTurnoverTime > 0 Then
                strAveWaitingTimePercent = (Format(MABHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            ElseIf MABHybridSummary.AverageWaitingTurnoverTime < 0 Then
                strAveWaitingTimePercent = "0 %"
            Else
                strAveWaitingTimePercent = "Less than a Minute"
            End If
            dvgCounterHistory.Rows.Add(MABHybridSummary.Counter.Counter_ID, MABHybridSummary.Counter.Section, MABHybridSummary.QueuedCount, MABHybridSummary.ServedCount, MABHybridSummary.HoldCount, MABHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            dvgCounterHistory.Rows(dvgCounterHistory.Rows.Count - 1).Height = 30
        End If
        If Not IsNothing(MABSummary) Then
            Dim strServedPercent As String = "0 %"
            Dim strUnservedPercent As String = "0 %"
            Dim strHoldPercent As String = "0 %"
            Dim strAveTimePercent As String = "0 %"
            Dim strAveWaitingTimePercent As String = "0 %"
            tmpQueueCount += MABSummary.QueuedCount
            tmpServedCount += MABSummary.ServedCount
            tmpHoldCount += MABSummary.HoldCount
            tmpUnservedeCount += MABSummary.UnservedCount
            If MABSummary.ServedCount > 0 Then
                strServedPercent = (Format(((MABSummary.ServedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABSummary.HoldCount > 0 Then
                strHoldPercent = (Format(((MABSummary.HoldCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABSummary.UnservedCount > 0 Then
                strUnservedPercent = (Format(((MABSummary.UnservedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            End If
            If MABSummary.AverageTurnoverTime > 0 Then
                strAveTimePercent = (Format(MABSummary.AverageTurnoverTime & " Minutes")).ToString
            ElseIf MABSummary.AverageTurnoverTime < 0 Then
                strAveTimePercent = "0 %"
            Else
                strAveTimePercent = "Less than a Minute"
            End If
            If MABSummary.AverageWaitingTurnoverTime > 0 Then
                strAveWaitingTimePercent = (Format(MABSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            ElseIf MABSummary.AverageWaitingTurnoverTime < 0 Then
                strAveWaitingTimePercent = "0 %"
            Else
                strAveWaitingTimePercent = "Less than a Minute"
            End If
            dvgCounterHistory.Rows.Add(MABSummary.Counter.Counter_ID, MABSummary.Counter.Section, MABSummary.QueuedCount, MABSummary.ServedCount, MABSummary.HoldCount, MABSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            dvgCounterHistory.Rows(dvgCounterHistory.Rows.Count - 1).Height = 30
        End If
        lblCounterCount.Text = dvgCounterHistory.Rows.Count
        lblTotalQueue.Text = tmpQueueCount
        lblTotalServed.Text = tmpServedCount
        lblTotalUnserved.Text = tmpUnservedeCount
    End Sub

    Private Sub getDoctorsSummary()
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim counteSummary As New List(Of DoctorSummary)
        If ComboBox1.SelectedIndex = 0 Then
            counteSummary = customerAssignCounterController.GetDoctorSummaryByDate(dtpFromDoctorCensus.Value, dtpToDoctorCensus.Value)
        ElseIf ComboBox1.SelectedIndex = 1 Then
            counteSummary = customerAssignCounterController.GetPCCClinicSummaryByDate(dtpFromDoctorCensus.Value, dtpToDoctorCensus.Value)
        ElseIf ComboBox1.SelectedIndex = 2 Then
            counteSummary = customerAssignCounterController.GetMABHybridClinicSummaryByDate(dtpFromDoctorCensus.Value, dtpToDoctorCensus.Value)
        ElseIf ComboBox1.SelectedIndex = 3 Then
            counteSummary = customerAssignCounterController.GetMABClinicSummaryByDate(dtpFromDoctorCensus.Value, dtpToDoctorCensus.Value)
        End If
        dgvDoctorSummary.Rows.Clear()
        If counteSummary.Count > 0 Then
            Dim ctr As Long = 0
            tmpQueuedPatientCount = 0
            tmpConsultedPatientCount = 0
            tmpHoldPatientCount = 0
            tmpUnconsultedPatientCount = 0
            For Each counter As DoctorSummary In counteSummary
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                tmpQueuedPatientCount += counter.QueuedCount
                tmpConsultedPatientCount += counter.ServedCount
                tmpHoldPatientCount += counter.HoldCount
                tmpUnconsultedPatientCount += counter.UnservedCount
                If counter.ServedCount > 0 Then
                    strServedPercent = (Format(((counter.ServedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.HoldCount > 0 Then
                    strHoldPercent = (Format(((counter.HoldCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((counter.UnservedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                End If
                If counter.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(counter.AverageTurnoverTime & " Minutes")).ToString
                ElseIf counter.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If counter.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(counter.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf counter.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dgvDoctorSummary.Rows.Add(counter.Counter.Counter_ID, counter.Doctor.FullName, counter.Counter.Department, counter.Counter.Section, counter.QueuedCount, counter.ServedCount, counter.HoldCount, counter.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                dgvDoctorSummary.Rows(ctr).Height = 30
                ctr += 1
            Next
            lblTotalClinics.Text = ctr
            lblQueuedPatient.Text = tmpQueuedPatientCount
            lblConsultedPatient.Text = tmpConsultedPatientCount
            lblUnconsultedPatient.Text = tmpUnconsultedPatientCount
        End If
    End Sub

    Private Sub getDoctorsPrescriptionReport()
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim counteSummary As List(Of DoctorSummary) = customerAssignCounterController.GetDoctorSummaryByDate(dtpFromDoctorCensus.Value, dtpToDoctorCensus.Value)
    End Sub

    Private Function SendEmailReport_Departamental(title As String, body As String, attachments As List(Of String), sendTo As List(Of String), sendCC As List(Of String), sendBCC As List(Of String))
        Try
            Dim e_mail As New MailMessage()
            e_mail.From = New MailAddress(EmailAddress)
            If Not IsNothing(sendTo) Then
                For Each item As String In sendTo
                    e_mail.To.Add(item)
                Next
            End If
            If Not IsNothing(sendCC) Then
                For Each item As String In sendCC
                    e_mail.CC.Add(item)
                Next
            End If
            If Not IsNothing(sendBCC) Then
                For Each item As String In sendBCC
                    e_mail.CC.Add(item)
                Next
            End If
            e_mail.Subject = title.Trim.ToUpper
            e_mail.IsBodyHtml = Convert.ToBoolean("True")
            e_mail.Body = "<html>
                                <body style=font-size:14px;font-family:Arial> 
                                    <p><b>" & title.Trim.ToUpper & "</b></p>
                                    <p>" & body.Trim & "</p>
                                    <p>Please see attached file.</p>
                                </body>
                            </html>"
            For Each item As String In attachments
                e_mail.Attachments.Add(New Attachment(item))
            Next
            Smtp_Server.Send(e_mail)
            AppendLogs("[MANUAL][" & title.Trim.ToUpper & "][SUCCESS]: Email was sent.")
            Return True
        Catch ex As Exception
            AppendLogs("[MANUAL][" & title.Trim.ToUpper & "][FAILED]: Email was not sent. With error: " + ex.Message + ".")
            Return False
        End Try
    End Function

    Private Function SendEmailReport_Official(fromData As Date, toData As Date, sendTo As List(Of String), sendCC As List(Of String), sendBCC As List(Of String))
        Try
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim counteSummary As List(Of CounterSummary) = customerAssignCounterController.GetCounterSummaryByDate(fromData, toData)
            Dim PCCSummary As CounterSummary = customerAssignCounterController.GetPCCClinicCSummaryByDate(fromData, toData)
            'Dim PCCHybridSummary As CounterSummary = customerAssignCounterController.GetPCCHybridClinicCSummaryByDate(fromData, toData)
            'Dim MABHybridSummary As CounterSummary = customerAssignCounterController.GetMABHybridClinicCounterSummaryByDate(fromData, toData)
            'Dim MABSummary As CounterSummary = customerAssignCounterController.GetMABClinicCSummaryByDate(fromData, toData)
            Dim reconSummary As PatientTATReconnReport = customerAssignCounterController.GetPCCTATReconData(fromData, toData)

            Dim itemCount As Long = 0
            Dim queuedCout As Long = 0
            Dim servedCount As Long = 0
            Dim unservedCount As Long = 0
            Dim holdCount As Long = 0
            Dim queuedCoutscreeningval As Long = 0
            Dim servedCountscreeningval As Long = 0
            Dim unservedCountscreeningval As Long = 0
            Dim holdCountscreeningval As Long = 0

            Dim triageConsultation As Long = 0
            Dim actualClinics As Long = 0
            'Dim mabHybridClinics As Long = 0
            Dim pccClinics As Long = 0
            Dim recon_consultation As Long = 0

            Dim triageDiagnostics As Long = 0
            Dim actualDiagnostics As Long = 0
            Dim recon_diagnostic_less As Long = 0
            Dim recon_diagnostic_more As Long = 0

            Dim triageClaimResult As Long = 0
            Dim total_queued As Long = 0
            Dim ScreenedPatient As Long = 0
            'Dim MabClinics As Long = 0
            Dim recon_nonepcc As Long = 0

            Dim dt As New DataTable
            With dt.Columns
                .Add("CounterName")
                .Add("QueuedPatient")
                .Add("ServedPatient")
                .Add("HoldPatient")
                .Add("UnservedPatient")
                .Add("ServedPercentage")
                .Add("HoldPercentage")
                .Add("UnservedPercentage")
                .Add("ServingTAT")
                .Add("waitingTAT")
                .Add("included")
            End With
            If counteSummary.Count > 0 Then
                For Each counter As CounterSummary In counteSummary
                    Dim strServedPercent As String = "0 %"
                    Dim strUnservedPercent As String = "0 %"
                    Dim strHoldPercent As String = "0 %"
                    Dim strAveTimePercent As String = "0 %"
                    Dim strAveWaitingTimePercent As String = "0 %"
                    queuedCout += counter.QueuedCount
                    servedCount += counter.ServedCount
                    holdCount += counter.HoldCount
                    unservedCount += counter.UnservedCount

                    If counter.Counter.AutoTransfer_Screening Then
                        queuedCoutscreeningval = counter.QueuedCount
                        servedCountscreeningval = counter.ServedCount
                        unservedCountscreeningval = counter.HoldCount
                        holdCountscreeningval = counter.UnservedCount
                    End If

                    If counter.ServedCount > 0 Then
                        strServedPercent = (Format(((counter.ServedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.UnservedCount > 0 Then
                        strUnservedPercent = (Format(((counter.UnservedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.HoldCount > 0 Then
                        strHoldPercent = (Format(((counter.HoldCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.AverageTurnoverTime > 0 Then
                        strAveTimePercent = (Format(counter.AverageTurnoverTime & " Minutes")).ToString
                    ElseIf counter.AverageTurnoverTime < 0 Then
                        strAveTimePercent = "0 %"
                    Else
                        strAveTimePercent = "Less than a Minute"
                    End If
                    If counter.AverageWaitingTurnoverTime > 0 Then
                        strAveWaitingTimePercent = (Format(counter.AverageWaitingTurnoverTime & " Minutes")).ToString
                    ElseIf counter.AverageWaitingTurnoverTime < 0 Then
                        strAveWaitingTimePercent = "0 %"
                    Else
                        strAveWaitingTimePercent = "Less than a Minute"
                    End If
                    dt.Rows.Add(counter.Counter.Section, counter.QueuedCount, counter.ServedCount, counter.HoldCount, counter.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent, If(counter.Counter.AutoTransfer_Screening, True, False))
                    itemCount += 1
                Next
            End If
            If Not IsNothing(PCCSummary) Then
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                queuedCout += PCCSummary.QueuedCount
                servedCount += PCCSummary.ServedCount
                holdCount += PCCSummary.HoldCount
                unservedCount += PCCSummary.UnservedCount

                If PCCSummary.ServedCount > 0 Then
                    strServedPercent = (Format(((PCCSummary.ServedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((PCCSummary.UnservedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.HoldCount > 0 Then
                    strHoldPercent = (Format(((PCCSummary.HoldCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(PCCSummary.AverageTurnoverTime & " Minutes")).ToString
                ElseIf PCCSummary.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If PCCSummary.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(PCCSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf PCCSummary.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dt.Rows.Add(PCCSummary.Counter.Section, PCCSummary.QueuedCount, PCCSummary.ServedCount, PCCSummary.HoldCount, PCCSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                itemCount += 1
            End If
            'If Not IsNothing(PCCHybridSummary) Then
            '    Dim strServedPercent As String = "0 %"
            '    Dim strUnservedPercent As String = "0 %"
            '    Dim strHoldPercent As String = "0 %"
            '    Dim strAveTimePercent As String = "0 %"
            '    Dim strAveWaitingTimePercent As String = "0 %"
            '    queuedCout += PCCHybridSummary.QueuedCount
            '    servedCount += PCCHybridSummary.ServedCount
            '    holdCount += PCCHybridSummary.HoldCount
            '    unservedCount += PCCHybridSummary.UnservedCount

            '    If PCCHybridSummary.ServedCount > 0 Then
            '        strServedPercent = (Format(((PCCHybridSummary.ServedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If PCCHybridSummary.UnservedCount > 0 Then
            '        strUnservedPercent = (Format(((PCCHybridSummary.UnservedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If PCCHybridSummary.HoldCount > 0 Then
            '        strHoldPercent = (Format(((PCCHybridSummary.HoldCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If PCCHybridSummary.AverageTurnoverTime > 0 Then
            '        strAveTimePercent = (Format(PCCHybridSummary.AverageTurnoverTime & " Minutes")).ToString
            '    ElseIf PCCHybridSummary.AverageTurnoverTime < 0 Then
            '        strAveTimePercent = "0 %"
            '    Else
            '        strAveTimePercent = "Less than a Minute"
            '    End If
            '    If PCCHybridSummary.AverageWaitingTurnoverTime > 0 Then
            '        strAveWaitingTimePercent = (Format(PCCHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            '    ElseIf PCCHybridSummary.AverageWaitingTurnoverTime < 0 Then
            '        strAveWaitingTimePercent = "0 %"
            '    Else
            '        strAveWaitingTimePercent = "Less than a Minute"
            '    End If
            '    dt.Rows.Add(PCCHybridSummary.Counter.Section, PCCHybridSummary.QueuedCount, PCCHybridSummary.ServedCount, PCCHybridSummary.HoldCount, PCCHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            '    itemCount += 1
            'End If
            'If Not IsNothing(MABSummary) Then
            '    Dim strServedPercent As String = "0 %"
            '    Dim strUnservedPercent As String = "0 %"
            '    Dim strHoldPercent As String = "0 %"
            '    Dim strAveTimePercent As String = "0 %"
            '    Dim strAveWaitingTimePercent As String = "0 %"
            '    queuedCout += MABSummary.QueuedCount
            '    servedCount += MABSummary.ServedCount
            '    holdCount += MABSummary.HoldCount
            '    unservedCount += MABSummary.UnservedCount

            '    If MABSummary.ServedCount > 0 Then
            '        strServedPercent = (Format(((MABSummary.ServedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABSummary.UnservedCount > 0 Then
            '        strUnservedPercent = (Format(((MABSummary.UnservedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABSummary.HoldCount > 0 Then
            '        strHoldPercent = (Format(((MABSummary.HoldCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABSummary.AverageTurnoverTime > 0 Then
            '        strAveTimePercent = (Format(MABSummary.AverageTurnoverTime & " Minutes")).ToString
            '    ElseIf MABSummary.AverageTurnoverTime < 0 Then
            '        strAveTimePercent = "0 %"
            '    Else
            '        strAveTimePercent = "Less than a Minute"
            '    End If
            '    If MABSummary.AverageWaitingTurnoverTime > 0 Then
            '        strAveWaitingTimePercent = (Format(MABSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            '    ElseIf MABSummary.AverageWaitingTurnoverTime < 0 Then
            '        strAveWaitingTimePercent = "0 %"
            '    Else
            '        strAveWaitingTimePercent = "Less than a Minute"
            '    End If
            '    dt.Rows.Add(MABSummary.Counter.Section, MABSummary.QueuedCount, MABSummary.ServedCount, MABSummary.HoldCount, MABSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            '    itemCount += 1
            'End If
            'If Not IsNothing(MABHybridSummary) Then
            '    Dim strServedPercent As String = "0 %"
            '    Dim strUnservedPercent As String = "0 %"
            '    Dim strHoldPercent As String = "0 %"
            '    Dim strAveTimePercent As String = "0 %"
            '    Dim strAveWaitingTimePercent As String = "0 %"
            '    queuedCout += MABHybridSummary.QueuedCount
            '    servedCount += MABHybridSummary.ServedCount
            '    holdCount += MABHybridSummary.HoldCount
            '    unservedCount += MABHybridSummary.UnservedCount

            '    If MABHybridSummary.ServedCount > 0 Then
            '        strServedPercent = (Format(((MABHybridSummary.ServedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABHybridSummary.UnservedCount > 0 Then
            '        strUnservedPercent = (Format(((MABHybridSummary.UnservedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABHybridSummary.HoldCount > 0 Then
            '        strHoldPercent = (Format(((MABHybridSummary.HoldCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
            '    End If
            '    If MABHybridSummary.AverageTurnoverTime > 0 Then
            '        strAveTimePercent = (Format(MABHybridSummary.AverageTurnoverTime & " Minutes")).ToString
            '    ElseIf MABHybridSummary.AverageTurnoverTime < 0 Then
            '        strAveTimePercent = "0 %"
            '    Else
            '        strAveTimePercent = "Less than a Minute"
            '    End If
            '    If MABHybridSummary.AverageWaitingTurnoverTime > 0 Then
            '        strAveWaitingTimePercent = (Format(MABHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
            '    ElseIf MABHybridSummary.AverageWaitingTurnoverTime < 0 Then
            '        strAveWaitingTimePercent = "0 %"
            '    Else
            '        strAveWaitingTimePercent = "Less than a Minute"
            '    End If
            '    dt.Rows.Add(MABHybridSummary.Counter.Section, MABHybridSummary.QueuedCount, MABHybridSummary.ServedCount, MABHybridSummary.HoldCount, MABHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
            '    itemCount += 1
            'End If
            If Not IsNothing(reconSummary) Then
                triageConsultation = reconSummary.TriageConsultation
                actualClinics = reconSummary.PCCMABHybridClinics
                triageDiagnostics = reconSummary.TriageDiagnostics
                actualDiagnostics = reconSummary.DiagosticDepartment
                triageClaimResult = reconSummary.TriageClaimResult
                ScreenedPatient = reconSummary.ScreenedPatient
                total_queued = reconSummary.TotalRegistered
                'MabClinics = reconSummary.MABClinics
                'mabHybridClinics = reconSummary.MABHybridClinics
                pccClinics = reconSummary.PCCClinics

                If triageConsultation > actualClinics Then
                    recon_consultation = triageConsultation - actualClinics
                End If
                If triageDiagnostics > actualDiagnostics Then
                    recon_diagnostic_less = triageDiagnostics - actualDiagnostics
                ElseIf triageDiagnostics < actualDiagnostics Then
                    recon_diagnostic_more = actualDiagnostics - triageDiagnostics
                End If

                If ScreenedPatient > (triageClaimResult + triageConsultation + triageDiagnostics) Then
                    recon_nonepcc = ScreenedPatient - (triageClaimResult + triageConsultation + triageDiagnostics + actualClinics)
                End If
            End If
            Dim strPCCTATReport As String = ""
            For Each row As DataRow In dt.Rows
                strPCCTATReport = strPCCTATReport + "<tr>
                                                        <td>" + row("CounterName").ToString.ToUpper + "</td>
                                                        <td>" + row("QueuedPatient") + "</td>
                                                        <td>" + row("ServedPatient") + "</td>
                                                        <td>" + row("HoldPatient") + "</td>
                                                        <td>" + row("UnservedPatient") + "</td>
                                                        <td>" + row("ServedPercentage") + "</td>
                                                        <td>" + row("HoldPercentage") + "</td>
                                                        <td>" + row("UnservedPercentage") + "</td>
                                                        <td>" + row("ServingTAT") + "</td>
                                                        <td>" + row("waitingTAT") + "</td>
                                                     </tr>"
            Next
            Dim e_mail As New MailMessage()
            e_mail.From = New MailAddress(EmailAddress)
            If Not IsNothing(sendTo) Then
                For Each item As String In sendTo
                    e_mail.To.Add(item)
                Next
            End If
            If Not IsNothing(sendCC) Then
                For Each item As String In sendCC
                    e_mail.CC.Add(item)
                Next
            End If
            If Not IsNothing(sendBCC) Then
                For Each item As String In sendBCC
                    e_mail.CC.Add(item)
                Next
            End If
            e_mail.Subject = "TAT REPORT"
            e_mail.IsBodyHtml = Convert.ToBoolean("True")
            e_mail.Body = "<html>
                                <body style=font-size:14px;font-family:Arial>
                                    <p>Sending to you the Report for Queueing and E-Clinic System</p>
                                    <p><b>OCC TAT REPORT</b></p>
                                    <p>As of " + fromData.ToLongDateString + " to " + toData.ToLongDateString + "</p>
                                    <table style='border: 1px solid;'>
                                        <tr style='border: 1px solid; color: #0d3491;'>
                                            <th>Counter</th>
                                            <th>Total Transaction</th>
                                            <th>Called & Served</th>
                                            <th>Called But Not Served</th>
                                            <th>Uncalled</th>
                                            <th>Called & Served %</th>
                                            <th>Called But Not Served %</th>
                                            <th>Uncalled %</th>
                                            <th>Serving TAT</th>
                                            <th>WAITING TAT</th>
                                        </tr>
                                        <tr style='border: 1px solid; color: #0d3491;'>
                                            <td><b>QUEUED AT ENTRANCE</b></td>
                                            <td><b>" + total_queued.ToString + "</b></td>
                                        </tr>
                                        " + strPCCTATReport + "
                                        <tr>
                                            <td>VISITORS/WATCHERS</td>
                                            <td>" + (Math.Abs(total_queued - queuedCout)).ToString + "</td>
                                        </tr>
                                    </table>
                                </body>
                            </html>"
            '<p>Total Screened Patient: " & ScreenedPatient.ToString & ", Triage, PCC MAB Hybrid, and MAB Clinics: " & (triageClaimResult + MabClinics + triageConsultation + triageDiagnostics + actualClinics).ToString & ".</p>
            '<p>" & recon_nonepcc.ToString & " were watchers and/or got queue number more than once.</p>
            Smtp_Server.Send(e_mail)
            AppendLogs("[MANUAL][OCC TAT REPORT][SUCCESS]: Email was sent.")
            Return True
        Catch ex As Exception
            AppendLogs("[MANUAL][OCC TAT REPORT][FAILED]: Email was not sent. With error: " + ex.Message + ".")
            Return False
        End Try
    End Function

    Private Function SendEmailReport_Test(fromData As Date, toData As Date, sendTo As List(Of String), sendCC As List(Of String), sendBCC As List(Of String), attachments As List(Of String))
        Try
            Dim customerAssignCounterController As New CustomerAssignCounterController
            Dim counteSummary As List(Of CounterSummary) = customerAssignCounterController.GetCounterSummaryByDate(fromData, toData)
            Dim PCCSummary As CounterSummary = customerAssignCounterController.GetPCCClinicCSummaryByDate(fromData, toData)
            Dim PCCHybridSummary As CounterSummary = customerAssignCounterController.GetPCCHybridClinicCSummaryByDate(fromData, toData)
            Dim MABHybridSummary As CounterSummary = customerAssignCounterController.GetMABHybridClinicCounterSummaryByDate(fromData, toData)
            Dim MABSummary As CounterSummary = customerAssignCounterController.GetMABClinicCSummaryByDate(fromData, toData)
            Dim reconSummary As PatientTATReconnReport = customerAssignCounterController.GetPCCTATReconData(fromData, toData)

            Dim itemCount As Long = 0
            Dim queuedCout As Long = 0
            Dim servedCount As Long = 0
            Dim unservedCount As Long = 0
            Dim holdCount As Long = 0
            Dim queuedCoutscreeningval As Long = 0
            Dim servedCountscreeningval As Long = 0
            Dim unservedCountscreeningval As Long = 0
            Dim holdCountscreeningval As Long = 0

            Dim triageConsultation As Long = 0
            Dim actualClinics As Long = 0
            Dim mabHybridClinics As Long = 0
            Dim pccClinics As Long = 0
            Dim recon_consultation As Long = 0

            Dim triageDiagnostics As Long = 0
            Dim actualDiagnostics As Long = 0
            Dim recon_diagnostic_less As Long = 0
            Dim recon_diagnostic_more As Long = 0

            Dim triageClaimResult As Long = 0
            Dim total_queued As Long = 0
            Dim ScreenedPatient As Long = 0
            Dim MabClinics As Long = 0
            Dim recon_nonepcc As Long = 0

            Dim dt As New DataTable
            With dt.Columns
                .Add("CounterName")
                .Add("QueuedPatient")
                .Add("ServedPatient")
                .Add("HoldPatient")
                .Add("UnservedPatient")
                .Add("ServedPercentage")
                .Add("HoldPercentage")
                .Add("UnservedPercentage")
                .Add("ServingTAT")
                .Add("waitingTAT")
                .Add("included")
            End With
            If counteSummary.Count > 0 Then
                For Each counter As CounterSummary In counteSummary
                    Dim strServedPercent As String = "0 %"
                    Dim strUnservedPercent As String = "0 %"
                    Dim strHoldPercent As String = "0 %"
                    Dim strAveTimePercent As String = "0 %"
                    Dim strAveWaitingTimePercent As String = "0 %"
                    queuedCout += counter.QueuedCount
                    servedCount += counter.ServedCount
                    holdCount += counter.HoldCount
                    unservedCount += counter.UnservedCount

                    If counter.Counter.AutoTransfer_Screening Then
                        queuedCoutscreeningval = counter.QueuedCount
                        servedCountscreeningval = counter.ServedCount
                        unservedCountscreeningval = counter.HoldCount
                        holdCountscreeningval = counter.UnservedCount
                    End If

                    If counter.ServedCount > 0 Then
                        strServedPercent = (Format(((counter.ServedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.UnservedCount > 0 Then
                        strUnservedPercent = (Format(((counter.UnservedCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.HoldCount > 0 Then
                        strHoldPercent = (Format(((counter.HoldCount / counter.QueuedCount) * 100), "0") & " %").ToString
                    End If
                    If counter.AverageTurnoverTime > 0 Then
                        strAveTimePercent = (Format(counter.AverageTurnoverTime & " Minutes")).ToString
                    ElseIf counter.AverageTurnoverTime < 0 Then
                        strAveTimePercent = "0 %"
                    Else
                        strAveTimePercent = "Less than a Minute"
                    End If
                    If counter.AverageWaitingTurnoverTime > 0 Then
                        strAveWaitingTimePercent = (Format(counter.AverageWaitingTurnoverTime & " Minutes")).ToString
                    ElseIf counter.AverageWaitingTurnoverTime < 0 Then
                        strAveWaitingTimePercent = "0 %"
                    Else
                        strAveWaitingTimePercent = "Less than a Minute"
                    End If
                    dt.Rows.Add(counter.Counter.Section, counter.QueuedCount, counter.ServedCount, counter.HoldCount, counter.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent, If(counter.Counter.AutoTransfer_Screening, True, False))
                    itemCount += 1
                Next
            End If
            If Not IsNothing(PCCSummary) Then
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                queuedCout += PCCSummary.QueuedCount
                servedCount += PCCSummary.ServedCount
                holdCount += PCCSummary.HoldCount
                unservedCount += PCCSummary.UnservedCount

                If PCCSummary.ServedCount > 0 Then
                    strServedPercent = (Format(((PCCSummary.ServedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((PCCSummary.UnservedCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.HoldCount > 0 Then
                    strHoldPercent = (Format(((PCCSummary.HoldCount / PCCSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCSummary.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(PCCSummary.AverageTurnoverTime & " Minutes")).ToString
                ElseIf PCCSummary.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If PCCSummary.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(PCCSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf PCCSummary.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dt.Rows.Add(PCCSummary.Counter.Section, PCCSummary.QueuedCount, PCCSummary.ServedCount, PCCSummary.HoldCount, PCCSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                itemCount += 1
            End If
            If Not IsNothing(PCCHybridSummary) Then
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                queuedCout += PCCHybridSummary.QueuedCount
                servedCount += PCCHybridSummary.ServedCount
                holdCount += PCCHybridSummary.HoldCount
                unservedCount += PCCHybridSummary.UnservedCount

                If PCCHybridSummary.ServedCount > 0 Then
                    strServedPercent = (Format(((PCCHybridSummary.ServedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCHybridSummary.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((PCCHybridSummary.UnservedCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCHybridSummary.HoldCount > 0 Then
                    strHoldPercent = (Format(((PCCHybridSummary.HoldCount / PCCHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If PCCHybridSummary.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(PCCHybridSummary.AverageTurnoverTime & " Minutes")).ToString
                ElseIf PCCHybridSummary.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If PCCHybridSummary.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(PCCHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf PCCHybridSummary.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dt.Rows.Add(PCCHybridSummary.Counter.Section, PCCHybridSummary.QueuedCount, PCCHybridSummary.ServedCount, PCCHybridSummary.HoldCount, PCCHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                itemCount += 1
            End If
            If Not IsNothing(MABSummary) Then
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                queuedCout += MABSummary.QueuedCount
                servedCount += MABSummary.ServedCount
                holdCount += MABSummary.HoldCount
                unservedCount += MABSummary.UnservedCount

                If MABSummary.ServedCount > 0 Then
                    strServedPercent = (Format(((MABSummary.ServedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABSummary.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((MABSummary.UnservedCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABSummary.HoldCount > 0 Then
                    strHoldPercent = (Format(((MABSummary.HoldCount / MABSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABSummary.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(MABSummary.AverageTurnoverTime & " Minutes")).ToString
                ElseIf MABSummary.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If MABSummary.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(MABSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf MABSummary.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dt.Rows.Add(MABSummary.Counter.Section, MABSummary.QueuedCount, MABSummary.ServedCount, MABSummary.HoldCount, MABSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                itemCount += 1
            End If
            If Not IsNothing(MABHybridSummary) Then
                Dim strServedPercent As String = "0 %"
                Dim strUnservedPercent As String = "0 %"
                Dim strHoldPercent As String = "0 %"
                Dim strAveTimePercent As String = "0 %"
                Dim strAveWaitingTimePercent As String = "0 %"
                queuedCout += MABHybridSummary.QueuedCount
                servedCount += MABHybridSummary.ServedCount
                holdCount += MABHybridSummary.HoldCount
                unservedCount += MABHybridSummary.UnservedCount

                If MABHybridSummary.ServedCount > 0 Then
                    strServedPercent = (Format(((MABHybridSummary.ServedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABHybridSummary.UnservedCount > 0 Then
                    strUnservedPercent = (Format(((MABHybridSummary.UnservedCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABHybridSummary.HoldCount > 0 Then
                    strHoldPercent = (Format(((MABHybridSummary.HoldCount / MABHybridSummary.QueuedCount) * 100), "0") & " %").ToString
                End If
                If MABHybridSummary.AverageTurnoverTime > 0 Then
                    strAveTimePercent = (Format(MABHybridSummary.AverageTurnoverTime & " Minutes")).ToString
                ElseIf MABHybridSummary.AverageTurnoverTime < 0 Then
                    strAveTimePercent = "0 %"
                Else
                    strAveTimePercent = "Less than a Minute"
                End If
                If MABHybridSummary.AverageWaitingTurnoverTime > 0 Then
                    strAveWaitingTimePercent = (Format(MABHybridSummary.AverageWaitingTurnoverTime & " Minutes")).ToString
                ElseIf MABHybridSummary.AverageWaitingTurnoverTime < 0 Then
                    strAveWaitingTimePercent = "0 %"
                Else
                    strAveWaitingTimePercent = "Less than a Minute"
                End If
                dt.Rows.Add(MABHybridSummary.Counter.Section, MABHybridSummary.QueuedCount, MABHybridSummary.ServedCount, MABHybridSummary.HoldCount, MABHybridSummary.UnservedCount, strServedPercent, strHoldPercent, strUnservedPercent, strAveTimePercent, strAveWaitingTimePercent)
                itemCount += 1
            End If
            If Not IsNothing(reconSummary) Then
                triageConsultation = reconSummary.TriageConsultation
                actualClinics = reconSummary.PCCMABHybridClinics
                triageDiagnostics = reconSummary.TriageDiagnostics
                actualDiagnostics = reconSummary.DiagosticDepartment
                triageClaimResult = reconSummary.TriageClaimResult
                ScreenedPatient = reconSummary.ScreenedPatient
                total_queued = reconSummary.TotalRegistered
                MabClinics = reconSummary.MABClinics
                mabHybridClinics = reconSummary.MABHybridClinics
                pccClinics = reconSummary.PCCClinics

                If triageConsultation > actualClinics Then
                    recon_consultation = triageConsultation - actualClinics
                End If
                If triageDiagnostics > actualDiagnostics Then
                    recon_diagnostic_less = triageDiagnostics - actualDiagnostics
                ElseIf triageDiagnostics < actualDiagnostics Then
                    recon_diagnostic_more = actualDiagnostics - triageDiagnostics
                End If

                If ScreenedPatient > (triageClaimResult + MabClinics + triageConsultation + triageDiagnostics) Then
                    recon_nonepcc = ScreenedPatient - (triageClaimResult + MabClinics + triageConsultation + triageDiagnostics + actualClinics)
                End If
            End If

            Dim strPCCTATReport As String = ""
            For Each row As DataRow In dt.Rows
                strPCCTATReport = strPCCTATReport + "<tr>
                                                        <td>" + row("CounterName").ToString.ToUpper + "</td>
                                                        <td>" + row("QueuedPatient") + "</td>
                                                        <td>" + row("ServedPatient") + "</td>
                                                        <td>" + row("HoldPatient") + "</td>
                                                        <td>" + row("UnservedPatient") + "</td>
                                                        <td>" + row("ServedPercentage") + "</td>
                                                        <td>" + row("HoldPercentage") + "</td>
                                                        <td>" + row("UnservedPercentage") + "</td>
                                                        <td>" + row("ServingTAT") + "</td>
                                                        <td>" + row("waitingTAT") + "</td>
                                                     </tr>"
            Next
            Dim e_mail As New MailMessage()
            e_mail.From = New MailAddress(EmailAddress)
            If Not IsNothing(sendTo) Then
                For Each item As String In sendTo
                    e_mail.To.Add(item)
                Next
            End If
            If Not IsNothing(sendCC) Then
                For Each item As String In sendCC
                    e_mail.CC.Add(item)
                Next
            End If
            If Not IsNothing(sendBCC) Then
                For Each item As String In sendBCC
                    e_mail.CC.Add(item)
                Next
            End If
            e_mail.Subject = "OCC TAT REPORT"
            e_mail.IsBodyHtml = Convert.ToBoolean("True")
            e_mail.Body = "<html>
                                <body style=font-size:14px;font-family:Arial>
                                    <p>Sending to you the Report for Queueing and E-Clinic System</p>
                                    <p><b>OCC TAT REPORT</b></p>
                                    <p>As of " + fromData.ToLongDateString + " to " + toData.ToLongDateString + "</p>
                                    <table style='border: 1px solid;'>
                                        <tr style='border: 1px solid; color: #0d3491;'>
                                            <th>Counter</th>
                                            <th>Total Transaction</th>
                                            <th>Called & Served</th>
                                            <th>Called But Not Served</th>
                                            <th>Uncalled</th>
                                            <th>Called & Served %</th>
                                            <th>Called But Not Served %</th>
                                            <th>Uncalled %</th>
                                            <th>Serving TAT</th>
                                            <th>WAITING TAT</th>
                                        </tr>
                                        <tr style='border: 1px solid; color: #0d3491;'>
                                            <td><b>QUEUED AT ENTRANCE</b></td>
                                            <td><b>" + total_queued.ToString + "</b></td>
                                        </tr>
                                        " + strPCCTATReport + "
                                        <tr>
                                            <td>VISITORS/WATCHERS</td>
                                            <td>" + (Math.Abs(total_queued - queuedCout)).ToString + "</td>
                                        </tr>
                                    </table>
                                    <p>&nbsp;</p>
                                    <h3>RECONCILIATION NOTES</h3>
                                    <hr />
                                    <p>Consultation (Triage 1 & Triage 2): " & triageConsultation.ToString & ", OCC and MAB Hybrid Clinics: " & actualClinics.ToString & ".</p>
                                    <p>" & recon_consultation.ToString & " patient for consultation were either requeued or did not proceed.</p>
                                    <p>Triage Diagnostics (Triage 3, Triage 4, & Triage 5): " & triageDiagnostics.ToString & ", Diagnostic Dept (Cardio, Chemo, Imaging, Lab, Rehab): " & actualDiagnostics.ToString & ".</p>
                                    <p>" & If(triageDiagnostics > actualDiagnostics, recon_diagnostic_less.ToString & " patient for diagnostic were either requeued or did not proceed", recon_diagnostic_more.ToString & " patient for diagnostic have more than 1 diagnostic transactions") & "</p>
                                    <p> NOTE: SCREENING WILL NOT BE INCLUDED ON THIS REPORT (Effective: Dec 15, 2022)</p>
                                    <hr/>
                                </body>
                            </html>"
            '<p>Total Screened Patient: " & ScreenedPatient.ToString & ", Triage, PCC MAB Hybrid, and MAB Clinics: " & (triageClaimResult + MabClinics + triageConsultation + triageDiagnostics + actualClinics).ToString & ".</p>
            '<p>" & recon_nonepcc.ToString & " were watchers and/or got queue number more than once.</p>
            For Each item As String In attachments
                e_mail.Attachments.Add(New Attachment(item))
            Next
            Smtp_Server.Send(e_mail)
            AppendLogs("[MANUAL][TEST SENDER][SUCCESS]: Email was sent.")
            Return True
        Catch ex As Exception
            AppendLogs("[MANUAL][TEST SENDER][FAILED]: Email was not sent. With error: " + ex.Message + ".")
            Return False
        End Try
    End Function

    Private Sub SendEmailReport_Tick(sender As Object, e As EventArgs)
        If Not _currentDate.Date.Day = Now.Date.Day Then
            If Now.TimeOfDay.Hours = 6 Then ' Send every 6am everyday
                Dim emailAddress As New List(Of String)
                Dim toEmail As New List(Of String)
                toEmail.Add("madimacutac@hhmh.ph")
                toEmail.Add("ipc@hhmh.ph")
sendPCCAgain:
                If SendEmailReport_Official(Today.AddDays(-1), Today.AddDays(-1), toEmail, Nothing, Nothing) Then
                    _tmpTrySendingLimit = 5
                    _currentDate = Now
                Else
                    _tmpTrySendingLimit = _tmpTrySendingLimit - 1
                    If _tmpTrySendingLimit > 0 Then
                        GoTo sendPCCAgain
                    End If
                End If
senderLabAgain:
                Dim toEmailLabs As New List(Of String)
                toEmailLabs.Add("laboratory@hhmh.ph")
                toEmailLabs.Add("rpillo@hhmh.ph")
                toEmailLabs.Add("ipc@hhmh.ph")
                Dim labTitle As String = "LABORATORY TAT REPORT"
                Dim labBody As String = "As of " + Today.AddDays(-1).ToLongDateString + " to " + Today.AddDays(-1).ToLongDateString
                Dim labAttachments As New List(Of String)
                Dim labFile As String = CustomExcelReport_GenerateLaboratory(Today.AddDays(-1), Today.AddDays(-1))
                If File.Exists(labFile) Then
                    labAttachments.Add(labFile)
                    If SendEmailReport_Departamental(labTitle, labBody, labAttachments, toEmailLabs, Nothing, Nothing) Then
                        _tmpTrySendingLimit = 5
                        _currentDate = Now
                    Else
                        _tmpTrySendingLimit = _tmpTrySendingLimit - 1
                        If _tmpTrySendingLimit > 0 Then
                            GoTo senderLabAgain
                        End If
                    End If
                End If
senderRadgain:
                Dim toEmailRads As New List(Of String)
                toEmailRads.Add("radiology@hhmh.ph")
                toEmailRads.Add("ipc@hhmh.ph")
                toEmailRads.Add("radiology.head@hhmh.ph")

                Dim radTitle As String = "RADIOLOGY TAT REPORT"
                Dim radBody As String = "As of " + Today.AddDays(-1).ToLongDateString + " to " + Today.AddDays(-1).ToLongDateString
                Dim radAttachments As New List(Of String)
                Dim radFile As String = CustomExcelReport_GenerateRadiology(Today.AddDays(-1), Today.AddDays(-1))
                If File.Exists(radFile) Then
                    radAttachments.Add(radFile)
                    If SendEmailReport_Departamental(radTitle, radBody, radAttachments, toEmailRads, Nothing, Nothing) Then
                        _tmpTrySendingLimit = 5
                        _currentDate = Now
                    Else
                        _tmpTrySendingLimit = _tmpTrySendingLimit - 1
                        If _tmpTrySendingLimit > 0 Then
                            GoTo senderLabAgain
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ToogleSendButton_Email(flag As Boolean)
        If Not flag Then
            Button18.BackColor = Color.Maroon
            Button18.Text = "STOP SENDER REPORT"
        Else
            Button18.BackColor = Color.FromArgb(13, 52, 145)
            Button18.Text = "RUN SENDER REPORT"
        End If
    End Sub

    Private Sub Reporting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _currentDate = DateAdd(DateInterval.Day, -1, Now)
        ComboBox1.SelectedIndex = 0
        dtpFrom.MaxDate = Today
        dtpTo.MaxDate = Today
        dtpFromDoctorCensus.MaxDate = Today
        dtpToDoctorCensus.MaxDate = Today
        GellAllCounterList()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        getCounterSummary()
    End Sub

    Private Sub txtTextFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTextFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dvgCounterHistory.Rows.Count - 1
                If dvgCounterHistory.Rows(x).Cells("counterName").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Then
                    dvgCounterHistory.Rows(x).Visible = True
                Else
                    dvgCounterHistory.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If (dvgCounterHistory.Rows.Count > 0) Then
                Dim frm As New frmPrinting
                Dim rpt As New printReport
                Dim dt As New DataTable
                With dt.Columns
                    .Add("counterName")
                    .Add("queuedNumbers")
                    .Add("servedNumbers")
                    .Add("holdNumbers")
                    .Add("unservedNumbers")
                    .Add("servedPercentage")
                    .Add("holdPercentage")
                    .Add("unservedPercentage")
                    .Add("avgTAT")
                    .Add("totalCounters")
                    .Add("totalQueued")
                    .Add("totalServed")
                    .Add("totalUnserved")
                    .Add("fromDate")
                    .Add("toDate")
                    .Add("waitTAT")
                End With
                For i As Integer = 0 To dvgCounterHistory.Rows.Count - 1
                    dt.Rows.Add(dvgCounterHistory.Rows(i).Cells("counterName").Value,
                                dvgCounterHistory.Rows(i).Cells("queuedCustomer").Value,
                                dvgCounterHistory.Rows(i).Cells("servedCustomer").Value,
                                dvgCounterHistory.Rows(i).Cells("holdCustomer").Value,
                                dvgCounterHistory.Rows(i).Cells("unservedCustomer").Value,
                                dvgCounterHistory.Rows(i).Cells("servedPercent").Value,
                                dvgCounterHistory.Rows(i).Cells("holdPercentage").Value,
                                dvgCounterHistory.Rows(i).Cells("unservedPercent").Value,
                                dvgCounterHistory.Rows(i).Cells("aveTime").Value,
                                lblCounterCount.Text,
                                lblTotalQueue.Text,
                                lblTotalServed.Text,
                                lblTotalUnserved.Text,
                                dtpFrom.Text,
                                dtpTo.Text,
                                dvgCounterHistory.Rows(i).Cells("waitTime").Value)
                Next
                rpt.SetDataSource(dt)
                With frm
                    .CrystalReportViewer1.ReportSource = rpt
                    .ShowDialog()
                End With
            Else
                MsgBox("No record in the list")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        getDoctorsSummary()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        getDoctorsSummary()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If (dgvDoctorSummary.Rows.Count > 0) Then
                Dim frm As New frmPrinting
                Dim rpt As New doctorCensus
                Dim dt As New DataTable
                With dt.Columns
                    .Add("clinic")
                    .Add("floor")
                    .Add("queuedNumbers")
                    .Add("servedNumbers")
                    .Add("unservedNumbers")
                    .Add("servedPercentage")
                    .Add("unservedPercentage")
                    .Add("avgTAT")
                    .Add("totalCounters")
                    .Add("totalQueued")
                    .Add("totalServed")
                    .Add("totalUnserved")
                    .Add("fromDate")
                    .Add("toDate")
                    .Add("physicianName")
                End With
                For i As Integer = 0 To dgvDoctorSummary.Rows.Count - 1
                    dt.Rows.Add(dgvDoctorSummary.Rows(i).Cells("dgv2Clinic").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2Floor").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2QueueNumber").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2ServedNo").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2UnservedNo").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgvSevedPerventage").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2UnservedPercentage").Value,
                                dgvDoctorSummary.Rows(i).Cells("dgv2AvgTat").Value,
                                lblTotalClinics.Text,
                                lblQueuedPatient.Text,
                                lblConsultedPatient.Text,
                                lblUnconsultedPatient.Text,
                                dtpFromDoctorCensus.Text,
                                dtpToDoctorCensus.Text,
                                dgvDoctorSummary.Rows(i).Cells("dgv2Physician").Value)
                Next
                rpt.SetDataSource(dt)
                With frm
                    .CrystalReportViewer1.ReportSource = rpt
                    .ShowDialog()
                End With
            Else
                MsgBox("No record in the list")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dgvDoctorSummary.Rows.Count - 1
                If dgvDoctorSummary.Rows(x).Cells("dgv2Physician").Value.ToString.ToLower.Contains(TextBox1.Text.ToLower) Or dgvDoctorSummary.Rows(x).Cells("dgv2Clinic").Value.ToString.ToLower.Contains(TextBox1.Text.ToLower) Then
                    dgvDoctorSummary.Rows(x).Visible = True
                Else
                    dgvDoctorSummary.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim frm As New frmDatePicker
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            Dim fromData As Date = frm.SelectedDateFrom
            Dim toData As Date = frm.SelectedDateTo
            Dim toEmail As New List(Of String)
            toEmail.Add("madimacutac@hhmh.ph")
            toEmail.Add("ipc@hhmh.ph")
            If SendEmailReport_Official(fromData, toData, toEmail, Nothing, Nothing) Then
                MessageBox.Show("Report was sent via email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to send email. Please see logs.", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If backRoundSender Then
            backroundSenderTimer.Stop()
        Else
            backroundSenderTimer.Start()
        End If
        ToogleSendButton_Email(backRoundSender)
        backRoundSender = Not backRoundSender
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ViewLogs()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim customerAssignCounterController As New CustomerAssignCounterController
        Dim dt1 As Date = DateTimePicker2.Value
        Dim dt2 As Date = DateTimePicker1.Value
        Dim totalPatient As Integer = 0
        Dim totalTransaction As Integer = 0
        If ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 1) Then
            If ComboBox3.SelectedIndex > -1 Then
                Dim index As Long = _MABClinic(ComboBox3.SelectedIndex).Counter_ID
                _customerSummary = customerAssignCounterController.GetAllPatientServedBy_Counter(dt1, dt2, index)
            End If
        ElseIf ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 2) Then
            If ComboBox3.SelectedIndex > -2 Then
                Dim index As Long = _PCCClinic(ComboBox3.SelectedIndex).Counter_ID
                _customerSummary = customerAssignCounterController.GetAllPatientServedBy_Counter(dt1, dt2, index)
            End If
        ElseIf ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 3) Then
            If ComboBox3.SelectedIndex > -3 Then
                Dim index As Long = _MABHybridClinic(ComboBox3.SelectedIndex).Counter_ID
                _customerSummary = customerAssignCounterController.GetAllPatientServedBy_Counter(dt1, dt2, index)
            End If
        ElseIf ComboBox2.SelectedIndex = 0 Then
            _customerSummary = customerAssignCounterController.GetAllPatientServedBy_Counter(dt1, dt2, 0)
        Else
            Dim index As Long = _PCCCounter(ComboBox2.SelectedIndex - 1).Counter_ID
            _customerSummary = customerAssignCounterController.GetAllPatientServedBy_Counter(dt1, dt2, index)
        End If
        DataGridView2.Rows.Clear()
        If Not IsNothing(_customerSummary) Then
            For Each summItem As CustomerQueuedSummary In _customerSummary
                DataGridView2.Rows.Add(summItem.CustomerInfo.Info_ID, summItem.CustomerInfo.Lastname & " " & summItem.CustomerInfo.FirstName & " " & summItem.CustomerInfo.Middlename, Format(summItem.CustomerInfo.BirthDate, "MMM dd, yyyy"))
                DataGridView2.Rows(DataGridView2.Rows.Count - 1).Height = 30
                If Not IsNothing(summItem.CustomerAssignCounters) Then
                    totalTransaction += summItem.CustomerAssignCounters.Count
                End If
            Next
            totalPatient = _customerSummary.Count
        Else
            totalPatient = 0
        End If
        Label24.Text = totalPatient
        Label20.Text = totalTransaction
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox3.Items.Clear()
        If ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 3) Then
            For Each counter As ServerAssignCounter In _MABHybridClinic
                ComboBox3.Items.Add(counter.Server.FullName + " - " + counter.Counter.ServiceDescription)
            Next
            ComboBox3.SelectedIndex = 0
            ComboBox3.Visible = True
        ElseIf ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 2) Then
            For Each counter As ServerAssignCounter In _PCCClinic
                ComboBox3.Items.Add(counter.Server.FullName + " - " + counter.Counter.ServiceDescription)
            Next
            ComboBox3.SelectedIndex = 0
            ComboBox3.Visible = True
        ElseIf ComboBox2.SelectedIndex = (ComboBox2.Items.Count - 1) Then
            For Each counter As ServerAssignCounter In _MABClinic
                ComboBox3.Items.Add(counter.Server.FullName + " - " + counter.Counter.ServiceDescription)
            Next
            ComboBox3.SelectedIndex = 0
            ComboBox3.Visible = True
        Else
            ComboBox3.Visible = False
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        DataGridView3.Rows.Clear()
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim selectedCustomer As CustomerQueuedSummary = Nothing
            Dim index As Long = DataGridView2.SelectedRows(0).Cells("DataGridViewTextBoxColumn2").Value
            For Each customer As CustomerQueuedSummary In _customerSummary
                If customer.CustomerInfo.Info_ID = index Then
                    selectedCustomer = customer
                    Exit For
                End If
            Next
            If Not IsNothing(selectedCustomer) Then
                For Each counters As CustomerAssignCounter In selectedCustomer.CustomerAssignCounters
                    Dim servedStart As String = "N/A"
                    Dim servedEnd As String = "N/A"
                    Dim servedBy As String = "N/A"
                    If Not IsNothing(counters.ServedCustomer) Then
                        servedStart = If(Not IsNothing(counters.ServedCustomer.DateTimeStart), Format(counters.ServedCustomer.DateTimeStart, "MMM dd h:mm tt"), "N/A")
                        servedEnd = If(Not IsNothing(counters.ServedCustomer.DateTimeEnd), Format(counters.ServedCustomer.DateTimeEnd, "MMM dd h:mm tt"), "N/A")
                        servedBy = If(Not IsNothing(counters.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), counters.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                    End If

                    If counters.Counter.CounterType > 0 Then
                        DataGridView3.Rows.Add(counters.CustomerAssignCounter_ID, counters.Counter.Department, counters.Counter.Section, counters.ProcessedQueueNumber, Format(counters.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"), servedStart, servedEnd, servedBy)
                    Else
                        DataGridView3.Rows.Add(counters.CustomerAssignCounter_ID, counters.Counter.Section, counters.Counter.ServiceDescription, counters.ProcessedQueueNumber, Format(counters.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt"), servedStart, servedEnd, servedBy)
                    End If
                    DataGridView3.Rows(DataGridView3.Rows.Count - 1).Height = 30
                Next
            End If
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        getCounterSummaryChart()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Try
            Dim dtChartVals As New DataTable
            With dtChartVals
                .Columns.Add("SectionName", GetType(String))
                .Columns.Add("TotalPatient", GetType(Long))
            End With
            Dim rpt As New exportChartRpt
            rpt.SetDataSource(dtChartVals)
            rpt.Refresh()
            Dim frm As New frmPrinting
            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim frm As New frmDatePicker
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            Dim fromData As Date = frm.SelectedDateFrom
            Dim toData As Date = frm.SelectedDateTo
            Dim sentToLab As Boolean = False
            Dim toEmailLabs As New List(Of String)
            toEmailLabs.Add("laboratory@hhmh.ph")
            toEmailLabs.Add("rpillo@hhmh.ph")
            toEmailLabs.Add("ipc@hhmh.ph")
            Dim labTitle As String = "LABORATORY TAT REPORT"
            Dim labBody As String = "As of " + fromData.ToLongDateString + " to " + toData.ToLongDateString
            Dim labAttachments As New List(Of String)
            Dim labFile As String = CustomExcelReport_GenerateLaboratory2(fromData, toData)
            If File.Exists(labFile) Then
                labAttachments.Add(labFile)
                sentToLab = SendEmailReport_Departamental(labTitle, labBody, labAttachments, toEmailLabs, Nothing, Nothing)
            End If
            If sentToLab Then
                MessageBox.Show("Report was sent via email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to send email. Please see logs.", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim frm As New frmDatePicker
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            Dim fromData As Date = frm.SelectedDateFrom
            Dim toData As Date = frm.SelectedDateTo
            Dim sentToBilling As Boolean = False
            Dim toEmailBilling As New List(Of String)
            toEmailBilling.Add("hisbidev@hhmh.phs")
            Dim billingTitle As String = "BILLING TAT REPORT"
            Dim billingBody As String = "As of " + fromData.ToLongDateString + " to " + toData.ToLongDateString
            Dim billingAttachments As New List(Of String)
            Dim billingFile As String = CustomExcelReport_GenerateBilling(fromData, toData)
            If File.Exists(billingFile) Then
                billingAttachments.Add(billingFile)
                sentToBilling = SendEmailReport_Departamental(billingTitle, billingBody, billingAttachments, toEmailBilling, Nothing, Nothing)
            End If
            If sentToBilling Then
                MessageBox.Show("Report was sent via email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to send email. Please see logs.", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim frm As New frmDatePicker
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            Dim fromData As Date = frm.SelectedDateFrom
            Dim toData As Date = frm.SelectedDateTo
            Dim sentToRad As Boolean = False
            Dim toEmailRads As New List(Of String)
            toEmailRads.Add("radiology@hhmh.ph")
            toEmailRads.Add("ipc@hhmh.ph")
            toEmailRads.Add("radiology.head@hhmh.ph")
            Dim radTitle As String = "RADIOLOGY TAT REPORT"
            Dim radBody As String = "As of " + fromData.ToLongDateString + " to " + toData.ToLongDateString
            Dim radAttachments As New List(Of String)
            Dim radFile As String = CustomExcelReport_GenerateRadiology(fromData, toData)
            If File.Exists(radFile) Then
                radAttachments.Add(radFile)
                sentToRad = SendEmailReport_Departamental(radTitle, radBody, radAttachments, toEmailRads, Nothing, Nothing)
            End If
            If sentToRad Then
                MessageBox.Show("Report was sent via email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to send email. Please see logs.", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ExportToExcel_BTN_Click(sender As Object, e As EventArgs) Handles ExportToExcel_BTN.Click
        Dim xls As New Microsoft.Office.Interop.Excel.Application
        Dim xlsWorkBook = xls.Workbooks.Add()
        Dim xlsWorkSheet As _Worksheet = xlsWorkBook.ActiveSheet()
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim Header As Object() = New Object(9) {}

        Try
            Header(0) = "PatientName"
            Header(1) = "Counter/Clinic"
            Header(2) = "Section"
            Header(3) = "Queue Number"
            Header(4) = "Date Queued"
            Header(5) = "Serve Start"
            Header(6) = "Serve End"
            Header(7) = "Serve By"
            Header(8) = "Time Elapsed"

            Dim HeaderRange As Range = xlsWorkSheet.Range((xlsWorkSheet.Cells(1, 1)), (xlsWorkSheet.Cells(1, 9)))
            HeaderRange.Value = Header
            HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            HeaderRange.Font.Bold = True

            Dim data As New Dictionary(Of String, List(Of PatientTAT))
            For Each xitem As DataGridViewRow In DataGridView2.Rows
                If Not data.ContainsKey(xitem.Cells().Item(1).Value) Then
                    data.Add(xitem.Cells().Item(1).Value, New List(Of PatientTAT))
                End If
                Dim selectedCustomer As CustomerQueuedSummary = Nothing
                Dim index As Long = xitem.Cells().Item(0).Value
                For Each customer As CustomerQueuedSummary In _customerSummary
                    If customer.CustomerInfo.Info_ID = index Then
                        selectedCustomer = customer
                        Exit For
                    End If
                Next
                If Not IsNothing(selectedCustomer) Then
                    For Each counters As CustomerAssignCounter In selectedCustomer.CustomerAssignCounters
                        Dim servedStart As String = "N/A"
                        Dim servedEnd As String = "N/A"
                        Dim servedBy As String = "N/A"
                        If Not IsNothing(counters.ServedCustomer) Then
                            servedStart = If(Not IsNothing(counters.ServedCustomer.DateTimeStart), Format(counters.ServedCustomer.DateTimeStart, "yyyy/MM/dd HH:mm:ss"), "N/A")
                            servedEnd = If(Not IsNothing(counters.ServedCustomer.DateTimeEnd), Format(counters.ServedCustomer.DateTimeEnd, "yyyy/MM/dd HH:mm:ss"), "N/A")
                            servedBy = If(Not IsNothing(counters.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName), counters.ServedCustomer.ServerTransaction.ServerAssignCounter.Server.FullName, "N/A")
                        End If

                        Dim patient = New PatientTAT
                        With patient
                            If counters.Counter.CounterType > 0 Then
                                .CounterClinic = counters.Counter.Department
                                .Section = counters.Counter.Section
                            Else
                                .CounterClinic = counters.Counter.Section
                                .Section = counters.Counter.ServiceDescription
                            End If
                            .QueueNumber = counters.ProcessedQueueNumber
                            .DateQueued = Format(counters.DateTimeQueued, "ddd MMM dd, yyyy h:mm tt")
                            .ServeStart = servedStart
                            .ServeEnd = servedEnd
                            .ServeBy = servedBy
                        End With
                        data(xitem.Cells().Item(1).Value).Add(patient)
                    Next
                End If
            Next
            Dim timeList As New List(Of TimeSpan)
            Dim i = 0
            For Each xitem In data
                xlsWorkSheet.Cells(i + 2, 1) = xitem.Key
                xlsWorkSheet.Range((xlsWorkSheet.Cells(i + 2, 1)), (xlsWorkSheet.Cells(i + 2, 9))).Interior.Color = ColorTranslator.ToOle(Color.LightGreen)
                xlsWorkSheet.Range((xlsWorkSheet.Cells(i + 2, 1)), (xlsWorkSheet.Cells(i + 2, 9))).Font.Bold = True
                i += 1
                For Each yitem In data(xitem.Key)
                    xlsWorkSheet.Cells(i + 2, 2) = yitem.CounterClinic
                    xlsWorkSheet.Cells(i + 2, 3) = yitem.Section
                    xlsWorkSheet.Cells(i + 2, 4) = yitem.QueueNumber
                    xlsWorkSheet.Cells(i + 2, 5) = yitem.DateQueued
                    If yitem.ServeStart IsNot "N/A" Then
                        xlsWorkSheet.Cells(i + 2, 6) = Date.Parse(yitem.ServeStart).ToString("MM/dd/yyyy HH:mm:ss")
                        xlsWorkSheet.Cells(i + 2, 6).NumberFormat = "MM/dd/yyyy HH:mm:ss"
                    Else
                        xlsWorkSheet.Cells(i + 2, 6) = yitem.ServeStart
                    End If
                    If yitem.ServeEnd IsNot "N/A" Then
                        xlsWorkSheet.Cells(i + 2, 7) = Date.Parse(yitem.ServeEnd).ToString("MM/dd/yyyy HH:mm:ss")
                        xlsWorkSheet.Cells(i + 2, 7).NumberFormat = "MM/dd/yyyy HH:mm:ss"
                    Else
                        xlsWorkSheet.Cells(i + 2, 7) = yitem.ServeEnd
                    End If
                    xlsWorkSheet.Cells(i + 2, 8) = yitem.ServeBy
                    If yitem.ServeStart IsNot "N/A" AndAlso yitem.ServeEnd IsNot "N/A" Then
                        timeList.Add(Date.Parse(yitem.ServeEnd).Subtract(Date.Parse(yitem.ServeStart)))
                        xlsWorkSheet.Cells(i + 2, 9) = Date.Parse(yitem.ServeEnd).Subtract(Date.Parse(yitem.ServeStart)).ToString
                        xlsWorkSheet.Cells(i + 2, 9).Font.Bold = True
                        xlsWorkSheet.Cells(i + 2, 9).Interior.Color = ColorTranslator.ToOle(Color.Orange)
                    Else
                        xlsWorkSheet.Cells(i + 2, 9) = ""
                        xlsWorkSheet.Cells(i + 2, 9).Interior.Color = ColorTranslator.ToOle(Color.Orange)
                    End If
                    i += 1
                Next
            Next

            xlsWorkSheet.Cells(i + 3, 8) = "Average TAT:"
            xlsWorkSheet.Cells(i + 3, 8).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            xlsWorkSheet.Cells(i + 3, 9) = TimeSpan.FromMinutes(timeList.Average(Function(x) x.Minutes)).ToString()
            xlsWorkSheet.Range((xlsWorkSheet.Cells(i + 3, 1)), (xlsWorkSheet.Cells(i + 3, 9))).Interior.Color = ColorTranslator.ToOle(Color.LightYellow)
            xlsWorkSheet.Range((xlsWorkSheet.Cells(i + 3, 1)), (xlsWorkSheet.Cells(i + 3, 9))).Font.Bold = True

            Dim filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Consolidated"
            If Not Directory.Exists(filePath) Then
                Directory.CreateDirectory(filePath)
            End If

            xlsWorkBook.SaveAs(filePath & "\QMS-PatTAT.xlsx", misValue)
            xls.Workbooks.Close()
            xls.Quit()

            ReleaseObject(xlsWorkSheet)
            ReleaseObject(xlsWorkBook)
            ReleaseObject(xls)

            MessageBox.Show("Done", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred. " + ex.ToString(), "Error")
            ReleaseObject(xlsWorkSheet)
            ReleaseObject(xlsWorkBook)
            ReleaseObject(xls)
        End Try


    End Sub

    Private Sub ReleaseObject(obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Unable to release the Object " + ex.ToString(), "Error")
        Finally
            GC.Collect()
        End Try
    End Sub
End Class
