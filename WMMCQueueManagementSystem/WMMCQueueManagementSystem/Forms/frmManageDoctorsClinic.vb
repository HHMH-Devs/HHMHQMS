Public Class frmManageDoctorsClinic
    Private forEditing As Boolean = False
    Private enableClinicSelection As Boolean = True
    Private listOfClinics As List(Of Counter) = Nothing
    Private forModificationClinic As Counter = Nothing


    Public Property DoctorInfo As Server = Nothing

    Sub New(server As Server)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.DoctorInfo = server
    End Sub

    Private Sub GetAssignedClinics()
        dgvClinicList.Rows.Clear()
        Dim counterController As New CounterController
        listOfClinics = counterController.GetCertainDoctorAssignedClinic(DoctorInfo.Server_ID)
        If Not IsNothing(listOfClinics) Then
            For Each clinic As Counter In listOfClinics
                Dim clinicType As String = ""
                If clinic.CounterType = 1 Then
                    clinicType = "MAB CLINIC"
                ElseIf clinic.CounterType = 2 Then
                    clinicType = "PCC CLINIC"
                ElseIf clinic.CounterType = 3 Then
                    clinicType = "MAB HYBRID CLINIC"
                ElseIf clinic.CounterType = 4 Then
                    clinicType = "PCC HYBRID CLINIC"
                ElseIf clinic.CounterType = 5 Then
                    clinicType = "ER PHYSICIAN"
                End If
                dgvClinicList.Rows.Add(clinic.Counter_ID, clinic.Department, clinic.Section, clinicType)
            Next
        End If
    End Sub

    Private Sub frmManageDoctorsClinic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAssignedClinics()
    End Sub

    Private Sub dgvClinicList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClinicList.CellContentClick

    End Sub

    Private Sub dgvClinicList_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClinicList.SelectionChanged
        If enableClinicSelection Then
            If dgvClinicList.SelectedRows.Count > 0 Then
                Dim id As Long = dgvClinicList.SelectedRows(0).Cells("id").Value
                Dim selectedClinic As Counter = Nothing
                For Each clinic As Counter In Me.listOfClinics
                    If clinic.Counter_ID = id Then
                        selectedClinic = clinic
                    End If
                Next
                If Not IsNothing(selectedClinic) Then
                    txtClinicNo.Text = selectedClinic.Department
                    cbFloor.Text = selectedClinic.Section
                    txtClinicDesc.Text = selectedClinic.ServiceDescription
                    txtCounterPrefix.Text = selectedClinic.CounterPrefix
                    cbCanEKonsulta.Checked = selectedClinic.canEKonsulta
                    If selectedClinic.CounterType = 1 Then
                        rbMABClinic.Checked = True
                    ElseIf selectedClinic.CounterType = 2 Then
                        rbPccClinic.Checked = True
                    ElseIf selectedClinic.CounterType = 5 Then
                        rbERClinics.Checked = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnNewClinic_Click(sender As Object, e As EventArgs) Handles btnNewClinic.Click
        forModificationClinic = Nothing

        forEditing = False
        enableClinicSelection = False

        txtClinicNo.Enabled = True
        txtClinicDesc.Enabled = True
        cbFloor.Enabled = True
        txtCounterPrefix.Enabled = True

        rbPccClinic.Enabled = True
        rbMABClinic.Enabled = True
        rbERClinics.Enabled = True
        cbCanEKonsulta.Enabled = True

        btnUpdateClinic.Enabled = False
        btnDeleteClinic.Enabled = False

        txtClinicNo.Text = ""
        txtClinicDesc.Text = ""
        cbFloor.Text = ""
        txtCounterPrefix.Text = ""
        cbCanEKonsulta.Checked = False

        btnNewClinic.Hide()
        btnSaveClinic.Show()
        btnCancel.Show()
    End Sub

    Private Sub btnUpdateClinic_Click(sender As Object, e As EventArgs) Handles btnUpdateClinic.Click
        forModificationClinic = Nothing

        forEditing = True
        enableClinicSelection = False

        txtClinicNo.Enabled = True
        txtClinicDesc.Enabled = True
        cbFloor.Enabled = True
        txtCounterPrefix.Enabled = True
        btnUpdateClinic.Enabled = False
        btnDeleteClinic.Enabled = False

        rbPccClinic.Enabled = True
        rbMABClinic.Enabled = True
        rbERClinics.Enabled = True
        cbCanEKonsulta.Enabled = True

        txtClinicNo.Text = ""
        txtClinicDesc.Text = ""
        cbFloor.Text = ""
        txtCounterPrefix.Text = ""

        btnNewClinic.Hide()
        btnSaveClinic.Show()
        btnCancel.Show()

        If dgvClinicList.SelectedRows.Count > 0 Then
            Dim id As Long = dgvClinicList.SelectedRows(0).Cells("id").Value
            For Each clinic As Counter In Me.listOfClinics
                If clinic.Counter_ID = id Then
                    forModificationClinic = clinic
                End If
            Next
            If Not IsNothing(forModificationClinic) Then
                txtClinicNo.Text = forModificationClinic.Department
                cbFloor.Text = forModificationClinic.Section
                txtClinicDesc.Text = forModificationClinic.ServiceDescription
                txtCounterPrefix.Text = forModificationClinic.CounterPrefix
                cbCanEKonsulta.Checked = forModificationClinic.canEKonsulta
                If forModificationClinic.CounterType = 1 Then
                    rbMABClinic.Checked = True
                ElseIf forModificationClinic.CounterType = 2 Then
                    rbPccClinic.Checked = True
                ElseIf forModificationClinic.CounterType = 5 Then
                    rbERClinics.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        forModificationClinic = Nothing

        enableClinicSelection = True

        txtClinicNo.Enabled = False
        txtClinicDesc.Enabled = False
        cbFloor.Enabled = False
        txtCounterPrefix.Enabled = False
        btnUpdateClinic.Enabled = True
        btnDeleteClinic.Enabled = True

        rbPccClinic.Enabled = False
        rbMABClinic.Enabled = False
        rbERClinics.Enabled = False
        cbCanEKonsulta.Enabled = False

        txtClinicNo.Text = ""
        txtClinicDesc.Text = ""
        cbFloor.Text = ""
        txtCounterPrefix.Text = ""

        btnNewClinic.Show()
        btnSaveClinic.Hide()
        btnCancel.Hide()
    End Sub

    Private Sub btnSaveClinic_Click(sender As Object, e As EventArgs) Handles btnSaveClinic.Click
        If forEditing Then
            If MessageBox.Show("Are you sure to modify the clinic?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                If Not IsNothing(forModificationClinic) Then
                    Dim updateClinic As New Counter
                    updateClinic.Counter_ID = forModificationClinic.Counter_ID
                    updateClinic.Department = txtClinicNo.Text
                    updateClinic.Section = cbFloor.Text
                    updateClinic.ServiceDescription = txtClinicDesc.Text
                    updateClinic.CounterPrefix = txtCounterPrefix.Text.Trim.Replace(" ", "").ToUpper
                    updateClinic.CounterCode = ""
                    updateClinic.Icon = 0
                    updateClinic.isQueueingCounter = 1
                    If rbMABClinic.Checked Then
                        updateClinic.showOnMainCounter = True
                        updateClinic.CounterType = 1
                    End If
                    If rbPccClinic.Checked Then
                        updateClinic.showOnMainCounter = False
                        updateClinic.CounterType = 2
                    End If
                    If rbERClinics.Checked Then
                        updateClinic.showOnMainCounter = False
                        updateClinic.CounterType = 5
                    End If
                    updateClinic.canEKonsulta = cbCanEKonsulta.Checked
                    updateClinic.allowedTurnaroundTime = 30
                    updateClinic.consultationView = True
                    updateClinic.consultationAddEdit = True
                    updateClinic.diagnosticView = True
                    updateClinic.diagnosticAddEdit = True
                    updateClinic.eprescriptionView = True
                    updateClinic.eprescriptionAddEdit = True
                    Dim counterController As New CounterController
                    Dim updateDoctorClinic As New ServerAssignCounter
                    updateDoctorClinic.Server_ID = Me.DoctorInfo.Server_ID
                    updateDoctorClinic.Counter_ID = updateClinic.Counter_ID
                    updateDoctorClinic.Server = Me.DoctorInfo
                    updateDoctorClinic.Counter = updateClinic
                    If counterController.UpdateDoctorClinic(updateDoctorClinic) Then
                        GetAssignedClinics()
                        btnCancel.PerformClick()
                        MessageBox.Show("Clinic modified", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Else
            If MessageBox.Show("Do you want to make this new clinic?", "Save Clinic", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim newClinic As New Counter
                newClinic.Department = txtClinicNo.Text
                newClinic.Section = cbFloor.Text
                newClinic.ServiceDescription = txtClinicDesc.Text
                newClinic.CounterPrefix = txtCounterPrefix.Text.Trim.Replace(" ", "").ToUpper
                newClinic.CounterCode = ""
                newClinic.Icon = 0
                newClinic.isQueueingCounter = 1
                If rbMABClinic.Checked Then
                    newClinic.showOnMainCounter = True
                    newClinic.CounterType = 1
                End If
                If rbPccClinic.Checked Then
                    newClinic.showOnMainCounter = False
                    newClinic.CounterType = 2
                End If
                If rbERClinics.Checked Then
                    newClinic.showOnMainCounter = False
                    newClinic.CounterType = 5
                End If
                newClinic.canEKonsulta = cbCanEKonsulta.Checked
                newClinic.allowedTurnaroundTime = 30
                newClinic.consultationView = True
                newClinic.consultationAddEdit = True
                newClinic.diagnosticView = True
                newClinic.diagnosticAddEdit = True
                newClinic.eprescriptionView = True
                newClinic.eprescriptionAddEdit = True
                Dim counterController As New CounterController
                Dim newDoctorClinic As New ServerAssignCounter
                newDoctorClinic.Server_ID = Me.DoctorInfo.Server_ID
                newDoctorClinic.Counter_ID = 0
                newDoctorClinic.Server = Me.DoctorInfo
                newDoctorClinic.Counter = newClinic
                If counterController.NewDoctorClinic(newDoctorClinic) Then
                    GetAssignedClinics()
                    btnCancel.PerformClick()
                    MessageBox.Show("Clinic created", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteClinic_Click(sender As Object, e As EventArgs) Handles btnDeleteClinic.Click
        forModificationClinic = Nothing
        If dgvClinicList.SelectedRows.Count > 0 Then
            Dim id As Long = dgvClinicList.SelectedRows(0).Cells("id").Value
            For Each clinic As Counter In Me.listOfClinics
                If clinic.Counter_ID = id Then
                    forModificationClinic = clinic
                End If
            Next
            If Not IsNothing(forModificationClinic) Then
                txtClinicNo.Text = forModificationClinic.Department
                cbFloor.Text = forModificationClinic.Section
                txtClinicDesc.Text = forModificationClinic.ServiceDescription
                txtCounterPrefix.Text = forModificationClinic.CounterPrefix
                cbCanEKonsulta.Checked = forModificationClinic.canEKonsulta
                If forModificationClinic.CounterType = 1 Then
                    rbMABClinic.Checked = True
                ElseIf forModificationClinic.CounterType = 2 Then
                    rbPccClinic.Checked = True
                ElseIf forModificationClinic.CounterType = 5 Then
                    rbERClinics.Checked = True
                End If
                MessageBox.Show("Please be noted that deleting this clinic will cause all data used on this clinic will be lost", "Delete Clinic", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Are you sure to delete this clinic", "Delete Clinic", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim counterController As New CounterController
                    If counterController.DeleteCounter(forModificationClinic) Then
                        GetAssignedClinics()
                        btnCancel.PerformClick()
                        MessageBox.Show("Clinic Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub
End Class