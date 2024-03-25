Public Class frmPrescription_Clinic

    Dim apiController As New APIController
    Private tmpSelectedMedicineName As RichTextBox
    Private tmpSelectedGenericName As RichTextBox
    Private tmpSelectedCode As TextBox
    Private SelectedMeds As Prescription = Nothing
    Private ServingPatient As ServedCustomer = Nothing
    Private ActiveConsultation As CustomerConsultation = Nothing
    Private eKonsultaMedsOnly As Boolean = False
    Dim productCode1 As New TextBox
    Dim productCode2 As New TextBox
    Dim productCode3 As New TextBox
    Dim productCode4 As New TextBox
    Dim productCode5 As New TextBox
    Dim productCode6 As New TextBox
    Dim productCode7 As New TextBox
    Dim productCode8 As New TextBox

    Sub New(patient As ServedCustomer, consultation As CustomerConsultation)
        Me.ServingPatient = patient
        ActiveConsultation = consultation
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        If ActiveConsultation.isEConsulta Then
            eKonsultaMedsOnly = True
            btnAllMeds.Show()
            btneKonsultaMeds.Show()
        Else
            eKonsultaMedsOnly = False
            btnAllMeds.Show()
            btneKonsultaMeds.Hide()
        End If
        MedicineType()
        Dim customerName As String = ""
        Dim customerAge As String = 0
        Dim customerSex As String = ""
        Dim customerBDay As String = ""
        If IsNothing(patient.CustomerAssignCounter.Customer.CustomerInfo.FirstName) And IsNothing(patient.CustomerAssignCounter.Customer.CustomerInfo.Lastname) Then
            customerName = "N/A"
        ElseIf (Not patient.CustomerAssignCounter.Customer.CustomerInfo.FirstName.Trim.Length > 0) And (Not patient.CustomerAssignCounter.Customer.CustomerInfo.Lastname.Trim.Length > 0) Then
            customerName = "N/A"
        Else
            customerName = patient.CustomerAssignCounter.Customer.CustomerInfo.Lastname.ToUpper & ", " & patient.CustomerAssignCounter.Customer.CustomerInfo.FirstName & " " & patient.CustomerAssignCounter.Customer.CustomerInfo.Middlename
        End If
        If IsNothing(patient.CustomerAssignCounter.Customer.CustomerInfo.Sex) Then
            customerSex = "N/A"
        ElseIf Not patient.CustomerAssignCounter.Customer.CustomerInfo.Sex.Trim.Length > 0 Then
            customerSex = "N/A"
        Else
            customerSex = patient.CustomerAssignCounter.Customer.CustomerInfo.Sex
        End If
        If Not IsNothing(patient.CustomerAssignCounter.Customer.CustomerInfo.BirthDate) Then
            customerBDay = patient.CustomerAssignCounter.Customer.CustomerInfo.BirthDate.ToShortDateString
        End If
        customerAge = DateDiff(DateInterval.Year, patient.CustomerAssignCounter.Customer.CustomerInfo.BirthDate, patient.CustomerAssignCounter.Customer.DateOfVisit).ToString
        lblPatientInfo.Text = customerName & Environment.NewLine & customerAge & "|" & customerSex & Environment.NewLine & customerBDay
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub txtMedicine1_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine1.TextChanged
        If txtMedicine1.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine1
            tmpSelectedGenericName = txtGeneric1
            tmpSelectedCode = productCode1
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine1.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine1.Location.X + 10, pnlMedicine1.Location.Y + 220)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric1.Enabled = True
            pnlBreakfastBefore1.Enabled = True
            pnlBreakfastAfter1.Enabled = True
            pnlLunchBefore1.Enabled = True
            pnlLunchAfter1.Enabled = True
            pnlDinnerBefore1.Enabled = True
            pnlDinnerAfter1.Enabled = True
            pnlAtBedtime1.Enabled = True
            pnQty1.Enabled = True
            pnlPreparation1.Enabled = True
            txtInstruction1.Enabled = True
            pnlS2Med1.Enabled = True
        Else
            txtGeneric1.Text = ""
            nubBreakfastBefore1.Value = 0
            nubBreakfastAfter1.Value = 0
            nubLunchBefore1.Value = 0
            nubLunchAfter1.Value = 0
            nubDinnerBefore1.Value = 0
            nubDinnerAfter1.Value = 0
            cbAtBedtime1.Checked = False
            nubQty1.Value = 0
            cbPreparation1.SelectedIndex = 0
            txtInstruction1.Text = ""
            cbS2Med1.Checked = False
            txtGeneric1.Enabled = False
            pnlBreakfastBefore1.Enabled = False
            pnlBreakfastAfter1.Enabled = False
            pnlLunchBefore1.Enabled = False
            pnlLunchAfter1.Enabled = False
            pnlDinnerBefore1.Enabled = False
            pnlDinnerAfter1.Enabled = False
            pnlAtBedtime1.Enabled = False
            pnQty1.Enabled = False
            pnlPreparation1.Enabled = False
            txtInstruction1.Enabled = False
            pnlS2Med1.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine2_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine2.TextChanged
        If txtMedicine2.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine2
            tmpSelectedGenericName = txtGeneric2
            tmpSelectedCode = productCode2
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine2.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine2.Location.X + 10, pnlMedicine2.Location.Y + 220)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric2.Enabled = True
            pnlBreakfastBefore2.Enabled = True
            pnlBreakfastAfter2.Enabled = True
            pnlLunchBefore2.Enabled = True
            pnlLunchAfter2.Enabled = True
            pnlDinnerBefore2.Enabled = True
            pnlDinnerAfter2.Enabled = True
            pnlAtBedtime2.Enabled = True
            pnQty2.Enabled = True
            pnlPreparation2.Enabled = True
            txtInstruction2.Enabled = True
            pnlS2Med2.Enabled = True
        Else
            txtGeneric2.Text = ""
            nubBreakfastBefore2.Value = 0
            nubBreakfastAfter2.Value = 0
            nubLunchBefore2.Value = 0
            nubLunchAfter2.Value = 0
            nubDinnerBefore2.Value = 0
            nubDinnerAfter2.Value = 0
            cbAtBedtime2.Checked = False
            nubQty2.Value = 0
            cbPreparation2.SelectedIndex = 0
            txtInstruction2.Text = ""
            cbS2Med2.Checked = False
            txtGeneric2.Enabled = False
            pnlBreakfastBefore2.Enabled = False
            pnlBreakfastAfter2.Enabled = False
            pnlLunchBefore2.Enabled = False
            pnlLunchAfter2.Enabled = False
            pnlDinnerBefore2.Enabled = False
            pnlDinnerAfter2.Enabled = False
            pnlAtBedtime2.Enabled = False
            pnQty2.Enabled = False
            pnlPreparation2.Enabled = False
            txtInstruction2.Enabled = False
            pnlS2Med2.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine3_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine3.TextChanged
        If txtMedicine3.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine3
            tmpSelectedGenericName = txtGeneric3
            tmpSelectedCode = productCode3
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine3.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine3.Location.X + 10, pnlMedicine3.Location.Y + 220)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric3.Enabled = True
            pnlBreakfastBefore3.Enabled = True
            pnlBreakfastAfter3.Enabled = True
            pnlLunchBefore3.Enabled = True
            pnlLunchAfter3.Enabled = True
            pnlDinnerBefore3.Enabled = True
            pnlDinnerAfter3.Enabled = True
            pnlAtBedtime3.Enabled = True
            pnQty3.Enabled = True
            pnlPreparation3.Enabled = True
            txtInstruction3.Enabled = True
            pnlS2Med3.Enabled = True
        Else
            txtGeneric3.Text = ""
            nubBreakfastBefore3.Value = 0
            nubBreakfastAfter3.Value = 0
            nubLunchBefore3.Value = 0
            nubLunchAfter3.Value = 0
            nubDinnerBefore3.Value = 0
            nubDinnerAfter3.Value = 0
            cbAtBedtime3.Checked = False
            nubQty3.Value = 0
            cbPreparation3.SelectedIndex = 0
            txtInstruction3.Text = ""
            cbS2Med3.Checked = False
            txtGeneric3.Enabled = False
            pnlBreakfastBefore3.Enabled = False
            pnlBreakfastAfter3.Enabled = False
            pnlLunchBefore3.Enabled = False
            pnlLunchAfter3.Enabled = False
            pnlDinnerBefore3.Enabled = False
            pnlDinnerAfter3.Enabled = False
            pnlAtBedtime3.Enabled = False
            pnQty3.Enabled = False
            pnlPreparation3.Enabled = False
            txtInstruction3.Enabled = False
            pnlS2Med3.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine4_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine4.TextChanged
        If txtMedicine4.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine4
            tmpSelectedGenericName = txtGeneric4
            tmpSelectedCode = productCode4
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine4.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine4.Location.X + 10, pnlMedicine4.Location.Y + 220)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric4.Enabled = True
            pnlBreakfastBefore4.Enabled = True
            pnlBreakfastAfter4.Enabled = True
            pnlLunchBefore4.Enabled = True
            pnlLunchAfter4.Enabled = True
            pnlDinnerBefore4.Enabled = True
            pnlDinnerAfter4.Enabled = True
            pnlAtBedtime4.Enabled = True
            pnQty4.Enabled = True
            pnlPreparation4.Enabled = True
            txtInstruction4.Enabled = True
            pnlS2Med4.Enabled = True
        Else
            txtGeneric4.Text = ""
            nubBreakfastBefore4.Value = 0
            nubBreakfastAfter4.Value = 0
            nubLunchBefore4.Value = 0
            nubLunchAfter4.Value = 0
            nubDinnerBefore4.Value = 0
            nubDinnerAfter4.Value = 0
            cbAtBedtime4.Checked = False
            nubQty4.Value = 0
            cbPreparation4.SelectedIndex = 0
            txtInstruction4.Text = ""
            cbS2Med4.Checked = False
            txtGeneric4.Enabled = False
            pnlBreakfastBefore4.Enabled = False
            pnlBreakfastAfter4.Enabled = False
            pnlLunchBefore4.Enabled = False
            pnlLunchAfter4.Enabled = False
            pnlDinnerBefore4.Enabled = False
            pnlDinnerAfter4.Enabled = False
            pnlAtBedtime4.Enabled = False
            pnQty4.Enabled = False
            pnlPreparation4.Enabled = False
            txtInstruction4.Enabled = False
            pnlS2Med4.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine5_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine5.TextChanged
        If txtMedicine5.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine5
            tmpSelectedGenericName = txtGeneric5
            tmpSelectedCode = productCode5
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine5.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine5.Location.X + 10, pnlMedicine5.Location.Y - 40)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric5.Enabled = True
            pnlBreakfastBefore5.Enabled = True
            pnlBreakfastAfter5.Enabled = True
            pnlLunchBefore5.Enabled = True
            pnlLunchAfter5.Enabled = True
            pnlDinnerBefore5.Enabled = True
            pnlDinnerAfter5.Enabled = True
            pnlAtBedtime5.Enabled = True
            pnQty5.Enabled = True
            pnlPreparation5.Enabled = True
            txtInstruction5.Enabled = True
            pnlS2Med5.Enabled = True
        Else
            txtGeneric5.Text = ""
            nubBreakfastBefore5.Value = 0
            nubBreakfastAfter5.Value = 0
            nubLunchBefore5.Value = 0
            nubLunchAfter5.Value = 0
            nubDinnerBefore5.Value = 0
            nubDinnerAfter5.Value = 0
            cbAtBedtime5.Checked = False
            nubQty5.Value = 0
            cbPreparation5.SelectedIndex = 0
            txtInstruction5.Text = ""
            cbS2Med5.Checked = False
            txtGeneric5.Enabled = False
            pnlBreakfastBefore5.Enabled = False
            pnlBreakfastAfter5.Enabled = False
            pnlLunchBefore5.Enabled = False
            pnlLunchAfter5.Enabled = False
            pnlDinnerBefore5.Enabled = False
            pnlDinnerAfter5.Enabled = False
            pnlAtBedtime5.Enabled = False
            pnQty5.Enabled = False
            pnlPreparation5.Enabled = False
            txtInstruction5.Enabled = False
            pnlS2Med5.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine6_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine6.TextChanged
        If txtMedicine6.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine6
            tmpSelectedGenericName = txtGeneric6
            tmpSelectedCode = productCode6
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine6.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine6.Location.X + 10, pnlMedicine6.Location.Y - 40)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric6.Enabled = True
            pnlBreakfastBefore6.Enabled = True
            pnlBreakfastAfter6.Enabled = True
            pnlLunchBefore6.Enabled = True
            pnlLunchAfter6.Enabled = True
            pnlDinnerBefore6.Enabled = True
            pnlDinnerAfter6.Enabled = True
            pnlAtBedtime6.Enabled = True
            pnQty6.Enabled = True
            pnlPreparation6.Enabled = True
            txtInstruction6.Enabled = True
            pnlS2Med6.Enabled = True
        Else
            txtGeneric6.Text = ""
            nubBreakfastBefore6.Value = 0
            nubBreakfastAfter6.Value = 0
            nubLunchBefore6.Value = 0
            nubLunchAfter6.Value = 0
            nubDinnerBefore6.Value = 0
            nubDinnerAfter6.Value = 0
            cbAtBedtime6.Checked = False
            nubQty6.Value = 0
            cbPreparation6.SelectedIndex = 0
            txtInstruction6.Text = ""
            cbS2Med6.Enabled = True
            txtGeneric6.Enabled = False
            pnlBreakfastBefore6.Enabled = False
            pnlBreakfastAfter6.Enabled = False
            pnlLunchBefore6.Enabled = False
            pnlLunchAfter6.Enabled = False
            pnlDinnerBefore6.Enabled = False
            pnlDinnerAfter6.Enabled = False
            pnlAtBedtime6.Enabled = False
            pnQty6.Enabled = False
            pnlPreparation6.Enabled = False
            txtInstruction6.Enabled = False
            pnlS2Med6.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine7_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine7.TextChanged
        If txtMedicine7.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine7
            tmpSelectedGenericName = txtGeneric7
            tmpSelectedCode = productCode7
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine7.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine7.Location.X + 10, pnlMedicine7.Location.Y - 40)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric7.Enabled = True
            pnlBreakfastBefore7.Enabled = True
            pnlBreakfastAfter7.Enabled = True
            pnlLunchBefore7.Enabled = True
            pnlLunchAfter7.Enabled = True
            pnlDinnerBefore7.Enabled = True
            pnlDinnerAfter7.Enabled = True
            pnlAtBedtime7.Enabled = True
            pnQty7.Enabled = True
            pnlPreparation7.Enabled = True
            txtInstruction7.Enabled = True
            pnlS2Med7.Enabled = True
        Else
            txtGeneric7.Text = ""
            nubBreakfastBefore7.Value = 0
            nubBreakfastAfter7.Value = 0
            nubLunchBefore7.Value = 0
            nubLunchAfter7.Value = 0
            nubDinnerBefore7.Value = 0
            nubDinnerAfter7.Value = 0
            cbAtBedtime7.Checked = False
            nubQty7.Value = 0
            cbPreparation7.SelectedIndex = 0
            txtInstruction7.Text = ""
            cbS2Med7.Enabled = True
            txtGeneric7.Enabled = False
            pnlBreakfastBefore7.Enabled = False
            pnlBreakfastAfter7.Enabled = False
            pnlLunchBefore7.Enabled = False
            pnlLunchAfter7.Enabled = False
            pnlDinnerBefore7.Enabled = False
            pnlDinnerAfter7.Enabled = False
            pnlAtBedtime7.Enabled = False
            pnQty7.Enabled = False
            pnlPreparation7.Enabled = False
            txtInstruction7.Enabled = False
            pnlS2Med7.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub txtMedicine8_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine8.TextChanged
        If txtMedicine8.Text.Trim.Length > 0 Then
            tmpSelectedMedicineName = txtMedicine8
            tmpSelectedGenericName = txtGeneric8
            tmpSelectedCode = productCode8
            Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData(txtMedicine8.Text.Trim)
            dgvFindMedicine.DataSource = searchedMeds
            If dgvFindMedicine.Rows.Count > 0 Then
                dgvFindMedicine.Columns("ID").Visible = False
                dgvFindMedicine.Columns("ProdID").Visible = False
                pnlPrescription.Location() = New Point(pnlMedicine8.Location.X + 10, pnlMedicine8.Location.Y - 40)
                pnlPrescription.Show()
            Else
                pnlPrescription.Hide()
            End If
            txtGeneric8.Enabled = True
            pnlBreakfastBefore8.Enabled = True
            pnlBreakfastAfter8.Enabled = True
            pnlLunchBefore8.Enabled = True
            pnlLunchAfter8.Enabled = True
            pnlDinnerBefore8.Enabled = True
            pnlDinnerAfter8.Enabled = True
            pnlAtBedtime8.Enabled = True
            pnQty8.Enabled = True
            pnlPreparation8.Enabled = True
            txtInstruction8.Enabled = True
            pnlS2Med8.Enabled = True
        Else
            txtGeneric8.Text = ""
            nubBreakfastBefore8.Value = 0
            nubBreakfastAfter8.Value = 0
            nubLunchBefore8.Value = 0
            nubLunchAfter8.Value = 0
            nubDinnerBefore8.Value = 0
            nubDinnerAfter8.Value = 0
            cbAtBedtime8.Checked = False
            nubQty8.Value = 0
            cbPreparation8.SelectedIndex = 0
            txtInstruction8.Text = ""
            cbS2Med8.Enabled = True
            txtGeneric8.Enabled = False
            pnlBreakfastBefore8.Enabled = False
            pnlBreakfastAfter8.Enabled = False
            pnlLunchBefore8.Enabled = False
            pnlLunchAfter8.Enabled = False
            pnlDinnerBefore8.Enabled = False
            pnlDinnerAfter8.Enabled = False
            pnlAtBedtime8.Enabled = False
            pnQty8.Enabled = False
            pnlPreparation8.Enabled = False
            txtInstruction8.Enabled = False
            pnlS2Med8.Enabled = False
            pnlPrescription.Hide()
        End If
    End Sub

    Private Sub btnSave_Consultation_Click(sender As Object, e As EventArgs) Handles btnSave_Consultation.Click
        Dim listOfPrescriptions As New List(Of Prescription)
        If txtMedicine1.Text.Trim.Length > 0 Then
            If txtMedicine1.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine1)
                End With
                Exit Sub
            ElseIf Not nubQty1.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty1)
                End With
                Exit Sub
            ElseIf Not cbPreparation1.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation1)
                End With
                Exit Sub
            Else
                Dim prescription1 As New Prescription
                With prescription1
                    .ProductCode = If(productCode1.Text.Trim.Length > 0, productCode1.Text, 0)
                    .ProductDescription = txtMedicine1.Text.Trim.ToUpper
                    .GenericName = txtGeneric1.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med1.Checked
                    .Instruction = txtInstruction1.Text.Trim
                    .Qty = nubQty1.Value
                    .BeforeBreakfast = nubBreakfastBefore1.Value
                    .AfterBreakfast = nubBreakfastAfter1.Value
                    .BeforeLunch = nubLunchBefore1.Value
                    .AfterLunch = nubLunchAfter1.Value
                    .BeforeDinner = nubDinnerBefore1.Value
                    .AfterDinner = nubDinnerAfter1.Value
                    .AtBedTime = cbAtBedtime1.Checked
                    .Preparation = cbPreparation1.Text
                    .DaysOfIntake = nubQty1.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription1)
            End If
        End If

        If txtMedicine2.Text.Trim.Length > 0 Then
            If txtMedicine2.Text.Trim.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine2)
                End With
                Exit Sub
            ElseIf Not nubQty2.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty2)
                End With
                Exit Sub
            ElseIf Not cbPreparation2.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation2)
                End With
                Exit Sub
            Else
                Dim prescription2 As New Prescription
                With prescription2
                    .ProductCode = If(productCode2.Text.Trim.Length > 0, productCode2.Text, 0)
                    .ProductDescription = txtMedicine2.Text.Trim.ToUpper
                    .GenericName = txtGeneric2.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med2.Checked
                    .Instruction = txtInstruction2.Text.Trim
                    .Qty = nubQty2.Value
                    .BeforeBreakfast = nubBreakfastBefore2.Value
                    .AfterBreakfast = nubBreakfastAfter2.Value
                    .BeforeLunch = nubLunchBefore2.Value
                    .AfterLunch = nubLunchAfter2.Value
                    .BeforeDinner = nubDinnerBefore2.Value
                    .AfterDinner = nubDinnerAfter2.Value
                    .AtBedTime = cbAtBedtime2.Checked
                    .Preparation = cbPreparation2.Text
                    .DaysOfIntake = nubQty2.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription2)
            End If
        End If
        If txtMedicine3.Text.Trim.Length > 0 Then
            If txtMedicine3.Text.Trim.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine3)
                End With
                Exit Sub
            ElseIf Not nubQty3.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty3)
                End With
                Exit Sub
            ElseIf Not cbPreparation3.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation3)
                End With
                Exit Sub
            Else
                Dim prescription3 As New Prescription
                With prescription3
                    .ProductCode = If(productCode3.Text.Trim.Length > 0, productCode3.Text, 0)
                    .ProductDescription = txtMedicine3.Text.Trim.ToUpper
                    .GenericName = txtGeneric3.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med3.Checked
                    .Instruction = txtInstruction3.Text.Trim
                    .Qty = nubQty3.Value
                    .BeforeBreakfast = nubBreakfastBefore3.Value
                    .AfterBreakfast = nubBreakfastAfter3.Value
                    .BeforeLunch = nubLunchBefore3.Value
                    .AfterLunch = nubLunchAfter3.Value
                    .BeforeDinner = nubDinnerBefore3.Value
                    .AfterDinner = nubDinnerAfter3.Value
                    .AtBedTime = cbAtBedtime3.Checked
                    .Preparation = cbPreparation3.Text
                    .DaysOfIntake = nubQty3.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription3)
            End If
        End If

        If txtMedicine4.Text.Trim.Length > 0 Then
            If txtMedicine4.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine4)
                End With
                Exit Sub
            ElseIf Not nubQty4.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty4)
                End With
                Exit Sub
            ElseIf Not cbPreparation4.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation4)
                End With
                Exit Sub
            Else
                Dim prescription4 As New Prescription
                With prescription4
                    .ProductCode = If(productCode4.Text.Trim.Length > 0, productCode4.Text, 0)
                    .ProductDescription = txtMedicine4.Text.Trim.ToUpper
                    .GenericName = txtGeneric4.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med4.Checked
                    .Instruction = txtInstruction4.Text.Trim
                    .Qty = nubQty4.Value
                    .BeforeBreakfast = nubBreakfastBefore4.Value
                    .AfterBreakfast = nubBreakfastAfter4.Value
                    .BeforeLunch = nubLunchBefore4.Value
                    .AfterLunch = nubLunchAfter4.Value
                    .BeforeDinner = nubDinnerBefore4.Value
                    .AfterDinner = nubDinnerAfter4.Value
                    .AtBedTime = cbAtBedtime4.Checked
                    .Preparation = cbPreparation4.Text
                    .DaysOfIntake = nubQty4.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription4)
            End If
        End If

        If txtMedicine5.Text.Trim.Length > 0 Then
            If txtMedicine5.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine5)
                End With
                Exit Sub
            ElseIf Not nubQty5.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty5)
                End With
                Exit Sub
            ElseIf Not cbPreparation5.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation5)
                End With
                Exit Sub
            Else
                Dim prescription5 As New Prescription
                With prescription5
                    .ProductCode = If(productCode5.Text.Trim.Length > 0, productCode5.Text, 0)
                    .ProductDescription = txtMedicine5.Text.Trim.ToUpper
                    .GenericName = txtGeneric5.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med5.Checked
                    .Instruction = txtInstruction5.Text.Trim
                    .Qty = nubQty5.Value
                    .BeforeBreakfast = nubBreakfastBefore5.Value
                    .AfterBreakfast = nubBreakfastAfter5.Value
                    .BeforeLunch = nubLunchBefore5.Value
                    .AfterLunch = nubLunchAfter5.Value
                    .BeforeDinner = nubDinnerBefore5.Value
                    .AfterDinner = nubDinnerAfter5.Value
                    .AtBedTime = cbAtBedtime5.Checked
                    .Preparation = cbPreparation5.Text
                    .DaysOfIntake = nubQty5.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription5)
            End If
        End If

        If txtMedicine6.Text.Trim.Length > 0 Then
            If txtMedicine6.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine6)
                End With
                Exit Sub
            ElseIf Not nubQty6.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty6)
                End With
                Exit Sub
            ElseIf Not cbPreparation6.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation6)
                End With
                Exit Sub
            Else
                Dim prescription6 As New Prescription
                With prescription6
                    .ProductCode = If(productCode6.Text.Trim.Length > 0, productCode6.Text, 0)
                    .ProductDescription = txtMedicine6.Text.Trim.ToUpper
                    .GenericName = txtGeneric6.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med6.Checked
                    .Instruction = txtInstruction6.Text.Trim
                    .Qty = nubQty6.Value
                    .BeforeBreakfast = nubBreakfastBefore6.Value
                    .AfterBreakfast = nubBreakfastAfter6.Value
                    .BeforeLunch = nubLunchBefore6.Value
                    .AfterLunch = nubLunchAfter6.Value
                    .BeforeDinner = nubDinnerBefore6.Value
                    .AfterDinner = nubDinnerAfter6.Value
                    .AtBedTime = cbAtBedtime6.Checked
                    .Preparation = cbPreparation6.Text
                    .DaysOfIntake = nubQty6.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription6)
            End If
        End If

        If txtMedicine7.Text.Trim.Length > 0 Then
            If txtMedicine7.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine7)
                End With
                Exit Sub
            ElseIf Not nubQty7.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty7)
                End With
                Exit Sub
            ElseIf Not cbPreparation7.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation7)
                End With
                Exit Sub
            Else
                Dim prescription7 As New Prescription
                With prescription7
                    .ProductCode = If(productCode7.Text.Trim.Length > 0, productCode7.Text, 0)
                    .ProductDescription = txtMedicine7.Text.Trim.ToUpper
                    .GenericName = txtGeneric7.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med7.Checked
                    .Instruction = txtInstruction7.Text.Trim
                    .Qty = nubQty7.Value
                    .BeforeBreakfast = nubBreakfastBefore7.Value
                    .AfterBreakfast = nubBreakfastAfter7.Value
                    .BeforeLunch = nubLunchBefore7.Value
                    .AfterLunch = nubLunchAfter7.Value
                    .BeforeDinner = nubDinnerBefore7.Value
                    .AfterDinner = nubDinnerAfter7.Value
                    .AtBedTime = cbAtBedtime7.Checked
                    .Preparation = cbPreparation7.Text
                    .DaysOfIntake = nubQty7.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription7)
            End If
        End If

        If txtMedicine8.Text.Trim.Length > 0 Then
            If txtMedicine8.Text.Trim.Count > 50 Then
                MessageBox.Show("Medicine name must not exceed 50 leters", "Max Letter Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please decrease the number of letters", Me.pnlMedicine8)
                End With
                Exit Sub
            ElseIf Not nubQty8.Value > 0 Then
                MessageBox.Show("Please indicate the amount of the item", "No Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnQty8)
                End With
                Exit Sub
            ElseIf Not cbPreparation8.SelectedIndex > 0 Then
                MessageBox.Show("Please indicate the preparation of the item", "No Preparation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim _tooltip As New ToolTip
                With _tooltip
                    .AutomaticDelay = 100
                    .AutoPopDelay = 500
                    .InitialDelay = 50
                    .ReshowDelay = 20
                    .Show("Please indicate the amount of the item", Me.pnlPreparation8)
                End With
                Exit Sub
            Else
                Dim prescription8 As New Prescription
                With prescription8
                    .ProductCode = If(productCode8.Text.Trim.Length > 0, productCode8.Text, 0)
                    .ProductDescription = txtMedicine8.Text.Trim.ToUpper
                    .GenericName = txtGeneric8.Text.Trim.ToUpper
                    .UnitPrice = 0
                    .isS2Meds = cbS2Med8.Checked
                    .Instruction = txtInstruction8.Text.Trim
                    .Qty = nubQty8.Value
                    .BeforeBreakfast = nubBreakfastBefore8.Value
                    .AfterBreakfast = nubBreakfastAfter8.Value
                    .BeforeLunch = nubLunchBefore8.Value
                    .AfterLunch = nubLunchAfter8.Value
                    .BeforeDinner = nubDinnerBefore8.Value
                    .AfterDinner = nubDinnerAfter8.Value
                    .AtBedTime = cbAtBedtime8.Checked
                    .Preparation = cbPreparation8.Text
                    .DaysOfIntake = nubQty8.Value
                    .FK_emdPatients = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.FK_emdPatients
                    .ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                    .Info_ID = ServingPatient.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                    .Consultation_ID = ActiveConsultation.Consultation_ID
                End With
                listOfPrescriptions.Add(prescription8)
            End If
        End If
        If listOfPrescriptions.Count > 0 Then
            If MessageBox.Show("Do you want to prescribe this list medicine?", "Prescribe Now", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim prescriptionController As New PrescriptionController
                If prescriptionController.NewPrescriptions_Consultation(listOfPrescriptions) Then
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Prescription is empty. Please enter your prescription", "Empty Prescription", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmPrescription_Clinic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbPreparation1.SelectedIndex = 0
        cbPreparation2.SelectedIndex = 0
        cbPreparation3.SelectedIndex = 0
        cbPreparation4.SelectedIndex = 0
        cbPreparation5.SelectedIndex = 0
        cbPreparation6.SelectedIndex = 0
        cbPreparation7.SelectedIndex = 0
        cbPreparation8.SelectedIndex = 0
    End Sub

    Private Sub dgvFindMedicine_DoubleClick(sender As Object, e As EventArgs) Handles dgvFindMedicine.DoubleClick
        If dgvFindMedicine.SelectedRows.Count > 0 Then
            Dim index As Long = dgvFindMedicine.SelectedRows(0).Cells("ID").Value
            SelectedMeds = apiController.GetCertainMedExpressMedDetail(index)
            If Not IsNothing(SelectedMeds) Then
                tmpSelectedMedicineName.Text = SelectedMeds.ProductDescription
                tmpSelectedGenericName.Text = SelectedMeds.GenericName
                tmpSelectedCode.Text = SelectedMeds.ProductCode
                pnlPrescription.Hide()
            End If
        End If
    End Sub

    Private Sub MedicineType()
        If eKonsultaMedsOnly Then
            btneKonsultaMeds.BackColor = Color.Green
            btnAllMeds.BackColor = Color.RoyalBlue
        Else
            btneKonsultaMeds.BackColor = Color.RoyalBlue
            btnAllMeds.BackColor = Color.Green
        End If
    End Sub

    Private Sub btnAllMeds_Click(sender As Object, e As EventArgs) Handles btnAllMeds.Click
        eKonsultaMedsOnly = False
        tmpSelectedMedicineName = txtMedicine1
        tmpSelectedGenericName = txtGeneric1
        tmpSelectedCode = productCode1
        Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData_eKonsultaSort(txtMedicine1.Text.Trim, eKonsultaMedsOnly)
        dgvFindMedicine.DataSource = searchedMeds
        If dgvFindMedicine.Rows.Count > 0 Then
            dgvFindMedicine.Columns("ID").Visible = False
            dgvFindMedicine.Columns("ProdID").Visible = False
            pnlPrescription.Location() = New Point(pnlMedicine1.Location.X + 10, pnlMedicine1.Location.Y + 220)
            pnlPrescription.Show()
        Else
            pnlPrescription.Hide()
        End If
        MedicineType()
    End Sub

    Private Sub btneKonsultaMeds_Click(sender As Object, e As EventArgs) Handles btneKonsultaMeds.Click
        eKonsultaMedsOnly = True
        tmpSelectedMedicineName = txtMedicine1
        tmpSelectedGenericName = txtGeneric1
        tmpSelectedCode = productCode1
        Dim searchedMeds As DataTable = apiController.GetMedExpressInventoryData_eKonsultaSort(txtMedicine1.Text.Trim, eKonsultaMedsOnly)
        dgvFindMedicine.DataSource = searchedMeds
        If dgvFindMedicine.Rows.Count > 0 Then
            dgvFindMedicine.Columns("ID").Visible = False
            dgvFindMedicine.Columns("ProdID").Visible = False
            pnlPrescription.Location() = New Point(pnlMedicine1.Location.X + 10, pnlMedicine1.Location.Y + 220)
            pnlPrescription.Show()
        Else
            pnlPrescription.Hide()
        End If
        MedicineType()
    End Sub
End Class