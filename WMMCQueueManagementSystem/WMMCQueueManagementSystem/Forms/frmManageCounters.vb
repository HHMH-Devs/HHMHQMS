Public Class frmManageCounters
    Private Counter As Counter
    Private selectedImageIndex As Integer = 0
    Private _listOfCounter As List(Of Counter)

    Sub New()
        InitializeComponent()
        btnSave.Visible = True
        btnUpdate.Visible = False
        Me.AcceptButton = btnSave
        lblTittle.Text = "New Counter"
    End Sub

    Sub New(counter As Counter)
        InitializeComponent()
        Me.Counter = counter
        txtDepartment.Text = counter.Department
        txtSection.Text = counter.Section
        txtServiceDescription.Text = counter.ServiceDescription
        txtCounterPrefix.Text = counter.CounterPrefix
        txtCounterCode.Text = counter.CounterCode
        pbIcon.Image = CounterImageIconsLg.Images.Item(counter.Icon)
        selectedImageIndex = counter.Icon
        nudAllowableTurnarroundTime.Value = counter.allowedTurnaroundTime
        If counter.isQueueingCounter Then
            rbQueueCounter.Checked = True
        Else
            rbMainCounter.Checked = True
        End If
        cbAutoDiagnostics.Checked = counter.AutoTransfer_Diagnostics
        cbAutoPrescription.Checked = counter.AutoTransfer_Prescriptions
        cbAutoScreening.Checked = counter.AutoTransfer_Screening
        If counter.AutoTransfer_Payment = 1 Then
            cbAutoCashier.Checked = True
        End If
        If counter.AutoTransfer_Payment = 2 Then
            cbAutoHMO.Checked = True
        End If
        If counter.AutoTransfer_Payment = 3 Then
            cbAutoCashierPhic.Checked = True
        End If
        If counter.AutoTransfer_Ancillary = 1 Then
            cbAutoAncillaryLab.Checked = True
        ElseIf counter.AutoTransfer_Ancillary = 2 Then
            cbAutoAncillaryRad.Checked = True
        End If
        cbSoloQueue.Checked = counter.isSoloCounter
        cbForTransferOnly.Checked = counter.showOnMainCounter
        cbSyncProfileWithBizbox.Checked = counter.SyncDetail
        cbViewHealthcheck.Checked = counter.healthcheckView
        cbManageHealthcheck.Checked = counter.healthcheckAddEdit
        cbViewConsultation.Checked = counter.consultationView
        cbManageConsultation.Checked = counter.consultationAddEdit
        cbMakeInitialConsultation.Checked = counter.initialconsultation
        cbERConsultation.Checked = counter.erconsultation
        cbViewDiagnostics.Checked = counter.diagnosticView
        cbManageDiagnostics.Checked = counter.diagnosticAddEdit
        cbViewPrescription.Checked = counter.eprescriptionView
        cbManagePrescription.Checked = counter.eprescriptionAddEdit
        cbHealee.Checked = counter.canHelee
        cbEkonsulta.Checked = counter.canEKonsulta
        btnSave.Visible = False
        btnUpdate.Visible = True
        Me.AcceptButton = btnUpdate
        lblTittle.Text = "Update Counter"
    End Sub

    Private Sub CalculateTimeOfStatus(val As Long)
        Dim worstval As Long = val
        Dim midVal As Long = val / 2
        lblBestVal.Text = "0 - " & (midVal - 1).ToString & " Mins"
        lblMidVal.Text = midVal.ToString & " - " & (worstval - 1).ToString & " Mins"
        lblWorstVal.Text = worstval.ToString & " Mins and Above"
    End Sub

    Private Function isValidationPassed() As Boolean
        If txtDepartment.Text.Trim = "" Then
            MessageBox.Show("Department is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtSection.Text.Trim = "" Then
            MessageBox.Show("Section is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtServiceDescription.Text.Trim = "" Then
            MessageBox.Show("Service Description is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtCounterPrefix.Text.Trim = "" Then
            MessageBox.Show("Counter Prefix is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub GetListofDepartment()
        Dim counterController As New CounterController
        Dim counters As List(Of Counter) = counterController.GetAllCounters
        If Not IsNothing(counters) Then
            _listOfCounter = counters
            For Each counter As Counter In counters
                txtDepartment.Items.Add(counter.Department)
                txtDepartment.DisplayMember = "Department"
            Next
        End If
    End Sub

    Private Sub frmManageCounters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetListofDepartment()
    End Sub

    Private Sub btnserve_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If isValidationPassed() Then
            If MessageBox.Show("Do you want to update this counter?", "Update Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim counter As New Counter
                Dim counterController As New CounterController
                counter.Department = txtDepartment.Text
                counter.Section = txtSection.Text
                counter.ServiceDescription = txtServiceDescription.Text
                counter.CounterPrefix = txtCounterPrefix.Text.Trim.Replace(" ", "").ToUpper
                counter.CounterCode = txtCounterCode.Text
                counter.Icon = Me.selectedImageIndex
                counter.isQueueingCounter = If(rbQueueCounter.Checked, 1, 0)
                counter.CounterType = 0
                counter.AutoTransfer_Diagnostics = cbAutoDiagnostics.Checked
                counter.AutoTransfer_Prescriptions = cbAutoPrescription.Checked
                counter.AutoTransfer_Screening = cbAutoScreening.Checked
                counter.AutoTransfer_GCBER = False
                counter.AutoTransfer_RespiER = False
                If cbAutoCashier.Checked Then
                    counter.AutoTransfer_Payment = 1
                    counter.canHavePaymentMethod = True
                ElseIf cbAutoHMO.Checked Then
                    counter.AutoTransfer_Payment = 2
                    counter.canHavePaymentMethod = True
                ElseIf cbAutoCashierPhic.Checked Then
                    counter.AutoTransfer_Payment = 3
                    counter.canHavePaymentMethod = True
                Else
                    counter.AutoTransfer_Payment = 0
                    counter.canHavePaymentMethod = False
                End If
                If cbAutoAncillaryLab.Checked Then
                    counter.AutoTransfer_Ancillary = 1
                ElseIf cbAutoAncillaryRad.Checked Then
                    counter.AutoTransfer_Ancillary = 2
                Else
                    counter.AutoTransfer_Ancillary = 0
                End If
                counter.isSoloCounter = cbSoloQueue.Checked
                counter.showOnMainCounter = cbForTransferOnly.Checked
                counter.Counter_ID = Me.Counter.Counter_ID
                counter.allowedTurnaroundTime = nudAllowableTurnarroundTime.Value
                counter.healthcheckView = cbViewHealthcheck.Checked
                counter.healthcheckAddEdit = cbManageHealthcheck.Checked
                counter.consultationView = cbViewConsultation.Checked
                counter.consultationAddEdit = cbManageConsultation.Checked
                counter.initialconsultation = cbMakeInitialConsultation.Checked
                counter.erconsultation = cbERConsultation.Checked
                counter.diagnosticView = cbViewDiagnostics.Checked
                counter.diagnosticAddEdit = cbManageDiagnostics.Checked
                counter.eprescriptionView = cbViewPrescription.Checked
                counter.eprescriptionAddEdit = cbManagePrescription.Checked
                counter.SyncDetail = cbSyncProfileWithBizbox.Checked
                counter.canEKonsulta = cbEkonsulta.Checked
                counter.canHelee = cbHealee.Checked
                If counterController.UpdateCounter(counter) Then
                    MessageBox.Show("Counter updated successfuly", "Update Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("Something went wrong during process.", "Update Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub txtCounterPrefix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCounterPrefix.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCounterPrefix_TextChanged(sender As Object, e As EventArgs) Handles txtCounterPrefix.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBrowseIcon.Click
        Dim frm As New frmBrowseLogo(CounterImageIconsLg)
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            selectedImageIndex = frm.SelectedIcons
            pbIcon.Image = CounterImageIconsLg.Images.Item(frm.SelectedIcons)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbIcon.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If isValidationPassed() Then
            If MessageBox.Show("Do you want to create a new counter?", "Add Counter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim counter As New Counter
                Dim counterController As New CounterController
                counter.Department = txtDepartment.Text
                counter.Section = txtSection.Text
                counter.ServiceDescription = txtServiceDescription.Text
                counter.CounterPrefix = txtCounterPrefix.Text.Trim.Replace(" ", "").ToUpper
                counter.CounterCode = txtCounterCode.Text
                counter.Icon = Me.selectedImageIndex
                counter.isQueueingCounter = If(rbQueueCounter.Checked, 1, 0)
                counter.CounterType = 0
                counter.AutoTransfer_Diagnostics = cbAutoDiagnostics.Checked
                counter.AutoTransfer_Prescriptions = cbAutoPrescription.Checked
                counter.AutoTransfer_Screening = cbAutoScreening.Checked
                counter.AutoTransfer_GCBER = False
                counter.AutoTransfer_RespiER = False
                If cbAutoCashier.Checked Then
                    counter.AutoTransfer_Payment = 1
                    counter.canHavePaymentMethod = True
                ElseIf cbAutoHMO.Checked Then
                    counter.AutoTransfer_Payment = 2
                    counter.canHavePaymentMethod = True
                ElseIf cbAutoCashierPhic.Checked Then
                    counter.AutoTransfer_Payment = 3
                    counter.canHavePaymentMethod = True
                Else
                    counter.AutoTransfer_Payment = 0
                    counter.canHavePaymentMethod = False
                End If
                If cbAutoAncillaryLab.Checked Then
                    counter.AutoTransfer_Ancillary = 1
                ElseIf cbAutoAncillaryRad.Checked Then
                    counter.AutoTransfer_Ancillary = 2
                Else
                    counter.AutoTransfer_Ancillary = 0
                End If
                counter.isSoloCounter = cbSoloQueue.Checked
                counter.showOnMainCounter = cbForTransferOnly.Checked
                counter.allowedTurnaroundTime = nudAllowableTurnarroundTime.Value
                counter.healthcheckView = cbViewHealthcheck.Checked
                counter.healthcheckAddEdit = cbManageHealthcheck.Checked
                counter.consultationView = cbViewConsultation.Checked
                counter.consultationAddEdit = cbManageConsultation.Checked
                counter.initialconsultation = cbMakeInitialConsultation.Checked
                counter.erconsultation = cbERConsultation.Checked
                counter.diagnosticView = cbViewDiagnostics.Checked
                counter.diagnosticAddEdit = cbManageDiagnostics.Checked
                counter.eprescriptionView = cbViewPrescription.Checked
                counter.eprescriptionAddEdit = cbManagePrescription.Checked
                counter.SyncDetail = cbSyncProfileWithBizbox.Checked
                counter.canEKonsulta = cbEkonsulta.Checked
                counter.canHelee = cbHealee.Checked
                If counterController.NewCounter(counter) Then
                    MessageBox.Show("New counter created successfuly", "New Counter", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("Something went wrong during process.", "New Counter", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btnClearIcon_Click(sender As Object, e As EventArgs) Handles btnClearIcon.Click
        selectedImageIndex = 0
        pbIcon.Image = Nothing
    End Sub

    Private Sub txtDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDepartment.SelectedIndexChanged
        If Not IsNothing(txtDepartment.SelectedIndex) Then
            txtSection.Text = _listOfCounter(txtDepartment.SelectedIndex).Section
        End If
    End Sub

    Private Sub rbQueueCounter_CheckedChanged(sender As Object, e As EventArgs) Handles rbQueueCounter.CheckedChanged
        If rbQueueCounter.Checked Then
            cbForTransferOnly.Enabled = True
        Else
            cbForTransferOnly.Checked = False
            cbForTransferOnly.Enabled = False
        End If
    End Sub

    Private Sub nudAllowableTurnarroundTime_ValueChanged(sender As Object, e As EventArgs) Handles nudAllowableTurnarroundTime.ValueChanged
        CalculateTimeOfStatus(nudAllowableTurnarroundTime.Value)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub rbMainCounter_CheckedChanged(sender As Object, e As EventArgs) Handles rbMainCounter.CheckedChanged

    End Sub
End Class