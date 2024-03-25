Public Class frmConsultation
    Private ServingCustomer As ServedCustomer
    Private Consultation As CustomerConsultation

    Sub New(servingCustomer As ServedCustomer, consultType As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.ServingCustomer = servingCustomer
        btnEditAndClose.Hide()
        btnSaveAndClose.Show()
        btnCancel.BackColor = Color.Maroon
        btnCancel.Text = "CANCEL"
        lblCreatedName.Text = LoggedServer.ServerAssignCounter.Server.FullName
        lblCreatedDate.Text = Now.ToLongDateString & ", " & Now.ToShortTimeString
        If consultType = 0 Then
            lbcountername.Text = "ENTER CONSULTATION AND VITALS"
        ElseIf consultType = 1 Then
            lbcountername.Text = "ENTER VITALS"
        ElseIf consultType = 2 Then
            lbcountername.Text = "ENTER CONSULTATION"
        End If
    End Sub

    Sub New(servingCustomer As ServedCustomer, consultation As CustomerConsultation)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.ServingCustomer = servingCustomer
        Me.Consultation = consultation
        nubweight.Value = consultation.Weight
        cbWeight.SelectedItem = consultation.WeightUnit.Trim
        nubheight.Value = consultation.Height
        cbHeight.SelectedItem = consultation.HeightUnit.Trim
        nupbpsys.Value = consultation.Systolic
        nupbpdia.Value = consultation.Diastolic
        nuptemp.Value = consultation.Temperature
        nuppr.Value = consultation.PulseRate
        nuprr.Value = consultation.RespiratoryRate
        nupo2.Value = consultation.Oxygen
        txtChiefComplaint.Text = consultation.ChiefComplaint
        txtHistoryOfPresentIllness.Text = consultation.IllnessHistory
        txtDiagnosis.Text = consultation.Diagnosis
        txtDoctorsOrder.Text = consultation.DoctorsOrder
        btnSaveAndClose.Hide()
        btnEditAndClose.Show()
        btnCancel.BackColor = Color.Maroon
        btnCancel.Text = "CANCEL"
        lblCreatedName.Text = LoggedServer.ServerAssignCounter.Server.FullName
        lblCreatedDate.Text = Now.ToLongDateString & ", " & Now.ToShortTimeString
    End Sub

    Sub New(consultation As CustomerConsultation)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Consultation = consultation
        nubweight.Value = consultation.Weight
        cbWeight.SelectedItem = consultation.WeightUnit.Trim
        nubheight.Value = consultation.Height
        cbHeight.SelectedItem = consultation.HeightUnit.Trim
        nupbpsys.Value = consultation.Systolic
        nupbpdia.Value = consultation.Diastolic
        nuptemp.Value = consultation.Temperature
        nuppr.Value = consultation.PulseRate
        nuprr.Value = consultation.RespiratoryRate
        nupo2.Value = consultation.Oxygen
        txtChiefComplaint.Text = consultation.ChiefComplaint
        txtHistoryOfPresentIllness.Text = consultation.IllnessHistory
        txtDiagnosis.Text = consultation.Diagnosis
        txtDoctorsOrder.Text = consultation.DoctorsOrder
        btnSaveAndClose.Hide()
        btnEditAndClose.Hide()
        btnCancel.BackColor = Color.Gray
        btnCancel.Text = "CLOSE"
        lblCreatedName.Text = consultation.ServerTransaction.ServerAssignCounter.Server.FullName
        lblCreatedDate.Text = consultation.DateCreated.ToLongDateString & ", " & consultation.DateCreated.ToShortTimeString
    End Sub

    Private Sub frmConsultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSaveAndClose_Click(sender As Object, e As EventArgs) Handles btnSaveAndClose.Click
        If nubheight.Value > 0 Or nubweight.Value > 0 Or nupbpsys.Value > 0 Or nupbpdia.Value > 0 Or nuptemp.Value > 0 Or nuppr.Value > 0 Or nuprr.Value > 0 Or nupo2.Value > 0 Or txtChiefComplaint.Text.Length > 0 Or txtHistoryOfPresentIllness.Text.Length > 0 Or txtDiagnosis.Text.Length > 0 Or txtDoctorsOrder.Text.Length > 0 Then
            If nubheight.Value > 0 And cbHeight.SelectedIndex < 0 Then
                MessageBox.Show("No selected unit for height. Please select the unit for the height", "No Value for height", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf nubweight.Value > 0 And cbWeight.SelectedIndex < 0 Then
                MessageBox.Show("No selected unit for weight. Please select the unit for the weight", "No Value for weight", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (nupbpsys.Value > 0 And nupbpdia.Value <= 0) Or (nupbpdia.Value > 0 And nupbpsys.Value <= 0) Then
                MessageBox.Show("One of the values for blood pressure is empty. Blood pressure values must be both filled", "No Value for Blood Pressure", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf MessageBox.Show("Do you want to save this consultation?", "Save Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim consultation As New CustomerConsultation
                Dim consultationController As New CustomerConsultationController
                consultation.Weight = nubweight.Value
                consultation.WeightUnit = If(Not IsNothing(cbWeight.SelectedItem), cbWeight.SelectedItem.ToString.Trim, "")
                consultation.Height = nubheight.Value
                consultation.HeightUnit = If(Not IsNothing(cbHeight.SelectedItem), cbHeight.SelectedItem.ToString.Trim, "")
                consultation.Systolic = nupbpsys.Value
                consultation.Diastolic = nupbpdia.Value
                consultation.Temperature = nuptemp.Value
                consultation.PulseRate = nuppr.Value
                consultation.RespiratoryRate = nuprr.Value
                consultation.Oxygen = nupo2.Value
                consultation.ChiefComplaint = txtChiefComplaint.Text.Trim
                consultation.IllnessHistory = txtHistoryOfPresentIllness.Text.Trim
                consultation.Diagnosis = txtDiagnosis.Text.Trim
                consultation.DoctorsOrder = txtDoctorsOrder.Text.Trim
                consultation.FK_emdPatients = Me.ServingCustomer.CustomerAssignCounter.Customer.FK_emdPatients
                consultation.ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                consultation.Info_ID = Me.ServingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID
                If consultationController.NewConsultation(consultation) Then
                    MessageBox.Show("New consultation saved successfully", "Consultation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
                Else
            MessageBox.Show("None of the items were filled. Please fill up a value to atleast one of the field", "No items were filled", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnEditAndClose_Click(sender As Object, e As EventArgs) Handles btnEditAndClose.Click
        If nubheight.Value > 0 Or nubweight.Value > 0 Or nupbpsys.Value > 0 Or nupbpdia.Value > 0 Or nuptemp.Value > 0 Or nuppr.Value > 0 Or nuprr.Value > 0 Or nupo2.Value > 0 Or txtChiefComplaint.Text.Length > 0 Or txtHistoryOfPresentIllness.Text.Length > 0 Or txtDiagnosis.Text.Length > 0 Or txtDoctorsOrder.Text.Length > 0 Then
            If nubheight.Value > 0 And cbHeight.SelectedIndex < 0 Then
                MessageBox.Show("No selected unit for height. Please select the unit for the height", "No Value for height", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf nubweight.Value > 0 And cbWeight.SelectedIndex < 0 Then
                MessageBox.Show("No selected unit for weight. Please select the unit for the weight", "No Value for weight", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (nupbpsys.Value > 0 And nupbpdia.Value <= 0) Or (nupbpdia.Value > 0 And nupbpsys.Value <= 0) Then
                MessageBox.Show("One of the values for blood pressure is empty. Blood pressure values must be both filled", "No Value for Blood Pressure", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf MessageBox.Show("Do you want to save the changes made for this consultation?", "Save Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim consultation As New CustomerConsultation
                Dim consultationController As New CustomerConsultationController
                consultation.Consultation_ID = Me.Consultation.Consultation_ID
                consultation.Weight = nubweight.Value
                consultation.WeightUnit = If(Not IsNothing(cbWeight.SelectedItem), cbWeight.SelectedItem.ToString.Trim, "")
                consultation.Height = nubheight.Value
                consultation.HeightUnit = If(Not IsNothing(cbHeight.SelectedItem), cbHeight.SelectedItem.ToString.Trim, "")
                consultation.Systolic = nupbpsys.Value
                consultation.Diastolic = nupbpdia.Value
                consultation.Temperature = nuptemp.Value
                consultation.PulseRate = nuppr.Value
                consultation.RespiratoryRate = nuprr.Value
                consultation.Oxygen = nupo2.Value
                consultation.ChiefComplaint = txtChiefComplaint.Text.Trim
                consultation.IllnessHistory = txtHistoryOfPresentIllness.Text.Trim
                consultation.Diagnosis = txtDiagnosis.Text.Trim
                consultation.DoctorsOrder = txtDoctorsOrder.Text.Trim
                consultation.ServerTransaction_ID = LoggedServer.ServerTransaction_ID
                If consultationController.EditConsultation(consultation) Then
                    MessageBox.Show("Consultation edited successfully", "Consultation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("None of the items were filled. Please fill up a value to atleast one of the field", "No items were filled", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class