Public Class frmTransferNo
    Private QueuingCounters As List(Of Counter)
    Private DoctorsClinic As List(Of ServerAssignCounter)
    Private CustomerAssignCounter As CustomerAssignCounter
    Private transferedCtr As Boolean = False
    Private transferLimit As Integer = 5
    Private _definePriotiry As Integer = -1

    Sub New(customerAssignCounter As CustomerAssignCounter)
        InitializeComponent()
        Me.CustomerAssignCounter = customerAssignCounter
    End Sub

    Sub New(customerAssignCounter As CustomerAssignCounter, definePriority As Long)
        InitializeComponent()
        _definePriotiry = definePriority
        Me.CustomerAssignCounter = customerAssignCounter
    End Sub

    Private Sub getAllCounters()
        Dim counterController As New CounterController
        QueuingCounters = counterController.GetAllQueuingCountersForTransferring()
        ListView1.Items.Clear()
        For Each counter In QueuingCounters
            ListView1.Items.Add("", If(counter.Icon > CounterImageIconsLg.Images.Count, 0, counter.Icon))
        Next
        ListView1.Items.Add("", ListView1.LargeImageList.Images.Count - 2)
        ListView1.Items.Add("", ListView1.LargeImageList.Images.Count - 1)
    End Sub

    Private Sub getMABClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllMABClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    'Private Sub getERPhysicians()
    '    Dim counterController As New CounterController
    '    DoctorsClinic = counterController.GetAllERPhysicianQueuingCounters()
    '    dgvDoctorsList.Rows.Clear()
    '    If Not IsNothing(DoctorsClinic) Then
    '        If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
    '            For Each doctor In DoctorsClinic
    '                If Not doctor.isAvailable Then
    '                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
    '                End If
    '            Next
    '        ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
    '            For Each doctor In DoctorsClinic
    '                If doctor.isAvailable Then
    '                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
    '                End If
    '            Next
    '        Else 'ALL
    '            For Each doctor In DoctorsClinic
    '                dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
    '                dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
    '                If doctor.isAvailable Then
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
    '                Else
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
    '                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub

    Private Sub getPCCClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllPCCClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TransferCustomerToClinic()
        If transferLimit > 0 Then
            If dgvDoctorsList.SelectedRows.Count > 0 Then
                Dim index As Integer = dgvDoctorsList.SelectedRows(0).Cells("clinicCounterID").Value
                Dim selectedCounter As Counter = Nothing
                For Each clinicCounter In DoctorsClinic
                    If clinicCounter.Counter.Counter_ID = index Then
                        selectedCounter = clinicCounter.Counter
                    End If
                Next
                Dim frmChoice As New frmSelectToGenerate
                If Not _definePriotiry > -1 Then
                    frmChoice.ShowDialog(Me)
                Else
                    frmChoice.DialogResult = DialogResult.Yes
                End If
                If frmChoice.DialogResult = DialogResult.Yes Then
                    Dim priority = If(_definePriotiry > -1, _definePriotiry, frmChoice.Priority)
                    If MessageBox.Show("Do you want to transfer this patient to clinic " + selectedCounter.Section.ToUpper.Trim + "?", "Transfer Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim customerAssignCounterController As New CustomerAssignCounterController
                        Dim transferedCustomerAssignCounter As New CustomerAssignCounter
                        transferedCustomerAssignCounter.Counter = selectedCounter
                        transferedCustomerAssignCounter.Customer = CustomerAssignCounter.Customer
                        transferedCustomerAssignCounter.Priority = priority
                        If selectedCounter.canHavePaymentMethod Then
                            Dim frmPaymentMethod As New frmPaymentMethod()
                            frmPaymentMethod.ShowDialog()
                            transferedCustomerAssignCounter.Notes = frmPaymentMethod.NotesAndRemaks
                            transferedCustomerAssignCounter.PaymentMethod = frmPaymentMethod.PaymentMethod
                            transferedCustomerAssignCounter.NoteDepartment = ""
                            transferedCustomerAssignCounter.NoteSection = ""
                        Else
                            transferedCustomerAssignCounter.Notes = Nothing
                            transferedCustomerAssignCounter.PaymentMethod = -1
                            transferedCustomerAssignCounter.NoteDepartment = Nothing
                            transferedCustomerAssignCounter.NoteSection = Nothing
                        End If
                        Dim generatedNumber As String = customerAssignCounterController.TransferCustomerGenerateQueueNumber(transferedCustomerAssignCounter)
                        If Not IsNothing(generatedNumber) Or generatedNumber.Trim <> "" Then
                            transferLimit -= 1
                            lblAllowedTranser.Text = transferLimit
                            Dim patientName As String = transferedCustomerAssignCounter.Customer.FullName
                            Dim counter As String = ("PLEASE GO TO " & transferedCustomerAssignCounter.Counter.ServiceDescription).Trim.ToUpper
                            Dim notes As String = ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper
                            Dim frm As New frmNoGenerated(generatedNumber, patientName, counter, notes, transferedCustomerAssignCounter.Customer.FK_emdPatients)
                            frm.ShowDialog()
                            If transferLimit > 0 Then
                                If MessageBox.Show("Do you want to another transfer of " + Me.CustomerAssignCounter.ProcessedQueueNumber + "? [YES: Select Another Counter to Transfer] [NO: Close Transfer]", "Transfer Another", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    transferedCtr = True
                                Else
                                    Me.DialogResult = DialogResult.Yes
                                End If
                            Else
                                Me.DialogResult = DialogResult.Yes
                            End If
                        Else
                            MessageBox.Show("Something went on the process. Please try again", "Transfer error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Please select a counter", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("You reached the maximum amount of transfers allowed", "Maximu Reached", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TransferCustomer()
        If transferLimit > 0 Then
            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.SelectedIndices(0) = ListView1.Items.Count - 2 Then 'PCC CLINICS
                    getPCCClinics()
                    ListView1.Hide()
                    pnlDoctors.Show()
                ElseIf ListView1.SelectedIndices(0) = ListView1.Items.Count - 1 Then 'MAB CLINIC
                    getMABClinics()
                    ListView1.Hide()
                    pnlDoctors.Show()
                Else
                    Dim index As Integer = ListView1.SelectedIndices(0)
                    Dim frmChoice As New frmSelectToGenerate
                    If Not _definePriotiry > -1 Then
                        frmChoice.ShowDialog(Me)
                    Else
                        frmChoice.DialogResult = DialogResult.Yes
                    End If
                    If frmChoice.DialogResult = DialogResult.Yes Then
                        Dim priority = If(_definePriotiry > -1, _definePriotiry, frmChoice.Priority)
                        If MessageBox.Show("Do you want to transfer this patient to counter " + QueuingCounters(index).Section.ToUpper.Trim + "?", "Transfer Patient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim customerAssignCounterController As New CustomerAssignCounterController
                            Dim transferedCustomerAssignCounter As New CustomerAssignCounter
                            transferedCustomerAssignCounter.Counter = QueuingCounters(index)
                            transferedCustomerAssignCounter.Customer = CustomerAssignCounter.Customer
                            transferedCustomerAssignCounter.Priority = priority
                            If QueuingCounters(index).canHavePaymentMethod Then
                                Dim frmPaymentMethod As New frmPaymentMethod()
                                frmPaymentMethod.ShowDialog()
                                transferedCustomerAssignCounter.Notes = frmPaymentMethod.NotesAndRemaks
                                transferedCustomerAssignCounter.PaymentMethod = frmPaymentMethod.PaymentMethod
                                transferedCustomerAssignCounter.NoteDepartment = ""
                                transferedCustomerAssignCounter.NoteSection = ""
                            Else
                                transferedCustomerAssignCounter.Notes = Nothing
                                transferedCustomerAssignCounter.PaymentMethod = -1
                                transferedCustomerAssignCounter.NoteDepartment = Nothing
                                transferedCustomerAssignCounter.NoteSection = Nothing
                            End If
                            Dim generatedNumber As String = customerAssignCounterController.TransferCustomerGenerateQueueNumber(transferedCustomerAssignCounter)
                            If Not IsNothing(generatedNumber) Or generatedNumber.Trim <> "" Then
                                ListView1.Items.RemoveAt(index)
                                QueuingCounters.RemoveAt(index)
                                transferLimit -= 1
                                lblAllowedTranser.Text = transferLimit
                                Dim patientName As String = transferedCustomerAssignCounter.Customer.FullName
                                Dim counter As String = ("PLEASE GO TO " & transferedCustomerAssignCounter.Counter.ServiceDescription).Trim.ToUpper
                                If transferedCustomerAssignCounter.Counter.AutoTransfer_Payment = 1 Then
                                    counter = "PLEASE GO TO CASHIER 1"
                                End If
                                Dim notes As String = ("PLEASE WAIT FOR YOUR NUMBER TO BE CALLED. THANK YOU").Trim.ToUpper
                                Dim frm As New frmNoGenerated(generatedNumber, patientName, counter, notes, transferedCustomerAssignCounter.Customer.FK_emdPatients)
                                frm.ShowDialog(Me)
                                If transferLimit > 0 Then
                                    If MessageBox.Show("Do you want to another transfer of " + Me.CustomerAssignCounter.ProcessedQueueNumber + "? [YES: Select Another Counter to Transfer] [NO: Close Transfer]", "Transfer Another", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        transferedCtr = True
                                    Else
                                        Me.DialogResult = DialogResult.Yes
                                    End If
                                Else
                                    Me.DialogResult = DialogResult.Yes
                                End If
                            Else
                                MessageBox.Show("Something went on the process. Please try again", "Transfer error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Please select a counter", "No Selected Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("You reached the maximum amount of transfers allowed", "Maximu Reached", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmTransferNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imgs As New ImageList
        For Each img As Image In CounterImageIconsLg.Images
            imgs.Images.Add(img)
        Next
        imgs.Images.Add(CustomImageIconsLg.Images(4))
        imgs.Images.Add(CustomImageIconsLg.Images(5))
        imgs.ColorDepth = CounterImageIconsLg.ColorDepth
        imgs.ImageSize = New Size(CounterImageIconsLg.ImageSize)
        lblAllowedTranser.Text = transferLimit
        ListView1.LargeImageList = imgs
        lblAllowedTranser.Text = transferLimit
        getAllCounters()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            If ListView1.SelectedIndices(0) = ListView1.Items.Count - 1 Then
                txtSelectedDept.Text = "PRIVATE CLINIC"
            ElseIf ListView1.SelectedIndices(0) = ListView1.Items.Count - 2 Then
                txtSelectedDept.Text = "PCC CLINIC"
            Else
                Dim index As Integer = ListView1.SelectedIndices(0).ToString
                txtSelectedDept.Text = Me.QueuingCounters(index).Section.Trim.ToUpper
            End If
        Else
            txtSelectedDept.Text = "Please Select a Department to Transfer"
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        TransferCustomer()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TransferCustomer()
        End If

    End Sub

    Private Sub frmTransferNo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If transferedCtr Then
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlDoctors.Hide()
        ListView1.Show()
    End Sub

    Private Sub dgvDoctorsList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctorsList.CellDoubleClick
        If dgvDoctorsList.SelectedRows.Count > 0 Then
            TransferCustomerToClinic()
        End If
    End Sub
    Private Sub txtFindDoctor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFindDoctor.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dgvDoctorsList.Rows.Count - 1
                If dgvDoctorsList.Rows(x).Cells("clinicDoctorName").Value.ToString.ToLower.Contains(txtFindDoctor.Text.ToLower) Or dgvDoctorsList.Rows(x).Cells("clinicRoom").Value.ToString.ToLower.Contains(txtFindDoctor.Text.ToLower) Then
                    dgvDoctorsList.Rows(x).Visible = True
                Else
                    dgvDoctorsList.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub cbAvailabilityOfClinic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAvailabilityOfClinic.SelectedIndexChanged
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtFindDoctor_TextChanged(sender As Object, e As EventArgs) Handles txtFindDoctor.TextChanged

    End Sub

    Private Sub dgvDoctorsList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctorsList.CellContentClick

    End Sub

    Private Sub pnlDoctors_Paint(sender As Object, e As PaintEventArgs) Handles pnlDoctors.Paint

    End Sub
End Class