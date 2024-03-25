Public Class frmMyPatients
    Private _selectedCustomer As CustomerInfo
    Private selectedItem As DataGridViewRow = Nothing
    Private DoctorsClinic As ServerAssignCounter


    Public Property SelectedCustomer As CustomerInfo
        Get
            Return _selectedCustomer
        End Get
        Private Set(value As CustomerInfo)
            _selectedCustomer = value
        End Set
    End Property

    Sub New(doctorsClinic As ServerAssignCounter)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.DoctorsClinic = doctorsClinic
    End Sub


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.DoctorsClinic = Nothing
    End Sub

    Private Sub FindMyPatient()
        If txtKeyword.Text.Count > 0 Then
            Dim apiController As New APIController
            Dim patients As New List(Of CustomerInfo)
            If Not IsNothing(Me.DoctorsClinic) Then
                patients = apiController.FindRecordPatientByKeyword_MyPatient(txtKeyword.Text.Trim, DoctorsClinic)
            Else
                patients = apiController.FindRecordPatientByKeyword_PCCPatients(txtKeyword.Text.Trim)
            End If
            dgvCustomerFindList.Rows.Clear()
            If Not IsNothing(patients) Then
                For Each row As CustomerInfo In patients
                    dgvCustomerFindList.Rows.Add(
                            If(Not IsNothing(row.Info_ID), row.Info_ID, 0),
                            If(Not IsNothing(row.Lastname), row.Lastname.Trim.ToUpper & " ", "") & If(Not IsNothing(row.FirstName), row.FirstName.Trim.ToUpper & " ", "") & If(Not IsNothing(row.Middlename), row.Middlename.Trim.ToUpper, ""),
                            If(Not IsNothing(row.BirthDate), CDate(row.BirthDate).ToLongDateString, ""),
                            If(Not IsNothing(row.FirstName), row.FirstName.ToString.ToUpper, ""),
                            If(Not IsNothing(row.Middlename), row.Middlename.ToString.ToUpper, ""),
                            If(Not IsNothing(row.Lastname), row.Lastname.ToString.ToUpper, ""),
                            If(Not IsNothing(row.Sex), row.Sex.ToString.ToUpper, ""),
                            If(Not IsNothing(row.FK_emdPatients), row.FK_emdPatients, 0)
                        )
                    dgvCustomerFindList.Rows(dgvCustomerFindList.Rows.Count - 1).Height = 50
                Next
                dgvCustomerFindList.ClearSelection()
                txtKeyword.Focus()
            End If
        Else
            MessageBox.Show("Please enter the name of patient", "Empty Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub FindPCCPatient()
        Dim apiController As New APIController
        Dim patients As List(Of CustomerInfo) = apiController.FindRecordPatientByKeyword_MyPatient(txtKeyword.Text.Trim, DoctorsClinic)
        dgvCustomerFindList.Rows.Clear()
        If Not IsNothing(patients) Then
            For Each row As CustomerInfo In patients
                dgvCustomerFindList.Rows.Add(
                        If(Not IsNothing(row.Info_ID), row.Info_ID, 0),
                        If(Not IsNothing(row.Lastname), row.Lastname.Trim.ToUpper & " ", "") & If(Not IsNothing(row.FirstName), row.FirstName.Trim.ToUpper & " ", "") & If(Not IsNothing(row.Middlename), row.Middlename.Trim.ToUpper, ""),
                        If(Not IsNothing(row.BirthDate), CDate(row.BirthDate).ToLongDateString, ""),
                        If(Not IsNothing(row.FirstName), row.FirstName.ToString.ToUpper, ""),
                        If(Not IsNothing(row.Middlename), row.Middlename.ToString.ToUpper, ""),
                        If(Not IsNothing(row.Lastname), row.Lastname.ToString.ToUpper, ""),
                        If(Not IsNothing(row.Sex), row.Sex.ToString.ToUpper, ""),
                        If(Not IsNothing(row.FK_emdPatients), row.FK_emdPatients, 0)
                    )
                dgvCustomerFindList.Rows(dgvCustomerFindList.Rows.Count - 1).Height = 50
            Next
            dgvCustomerFindList.ClearSelection()
            txtKeyword.Focus()
        End If
    End Sub

    Private Sub frmMyPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCustomerFindList.Rows.Clear()
        txtKeyword.Clear()
        pnlMoreInfo.Hide()
        txtKeyword.Select()
    End Sub

    Private Sub btnHideMoreInfo_Click(sender As Object, e As EventArgs) Handles btnHideMoreInfo.Click
        SelectedCustomer = Nothing
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FindMyPatient()
    End Sub

    Private Sub dgvCustomerFindList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerFindList.CellClick
        If dgvCustomerFindList.SelectedRows.Count > 0 Then
            selectedItem = dgvCustomerFindList.SelectedRows(0)
            lbfname.Text = selectedItem.Cells("tmpfname").Value
            lbmname.Text = selectedItem.Cells("tmpmname").Value
            lblname.Text = selectedItem.Cells("tmplname").Value
            lbbday.Text = selectedItem.Cells("bday").Value
            lbsex.Text = selectedItem.Cells("tmpgender").Value
            pnlMoreInfo.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlMoreInfo.Hide()
        selectedItem = Nothing
    End Sub

    Private Sub btnConfirmSelection_Click(sender As Object, e As EventArgs) Handles btnConfirmSelection.Click
        If Not IsNothing(selectedItem) Then
            Dim id As Long = selectedItem.Cells("id").Value()
            Dim Fk_ID As Long = selectedItem.Cells("FK_emdPatient").Value()
            Dim customerInfo As CustomerInfo
            If id > 0 Then
                Dim apiCon As New APIController
                customerInfo = apiCon.GetCertainPatientByInfoID(id)
            Else
                Dim apiCon As New APIController
                customerInfo = apiCon.GetCertainPatientByFK_emdPatient(Fk_ID)
            End If
            If Not IsNothing(customerInfo) Then
                SelectedCustomer = customerInfo
                Me.DialogResult = DialogResult.Yes
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class