Imports System.ComponentModel
Public Class frmFindPatient
    Private _selectedCustomer As CustomerInfo
    Private selectedItem As DataGridViewRow = Nothing
    Private SyncFunction As Boolean

    Public Property SelectedCustomer As CustomerInfo
        Get
            Return _selectedCustomer
        End Get
        Private Set(value As CustomerInfo)
            _selectedCustomer = value
        End Set
    End Property

    Sub New(isSyncing As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        ' Add any initialization after the InitializeComponent() call.
        Me.SyncFunction = isSyncing
    End Sub

    Private Sub roundCorners(obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None
        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()
        'top left corner
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)
        'top right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)
        'buttom right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
        'buttom left corner
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        DGP.CloseFigure()
        obj.Region = New Region(DGP)
    End Sub

    Private Sub FindPatient()
        If Me.SyncFunction Then
            Dim apiController As New APIController
            Dim patients As List(Of CustomerInfo) = apiController.FindRecordPatientByKeyword_BizboxOnly(txtKeyword.Text.Trim)
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
            Dim apiController As New APIController
            Dim patients As List(Of CustomerInfo) = apiController.FindRecordPatientByKeyword(txtKeyword.Text.Trim)
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
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub txtmname_TextChanged(sender As Object, e As EventArgs) Handles txtKeyword.TextChanged

    End Sub

    Private Sub txtmname_Click(sender As Object, e As EventArgs) Handles txtKeyword.Click
        pnlMoreInfo.Hide()
    End Sub


    Private Sub frmFindCustomer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        CloseOnScreenKeyboard()
    End Sub

    Private Sub frmFindCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCustomerFindList.Rows.Clear()
        txtKeyword.Clear()
        pnlMoreInfo.Hide()
        txtKeyword.Select()
        If Me.SyncFunction Then
            btnCantFindName.Hide()
        Else
            btnCantFindName.Show()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        pnlMoreInfo.Hide()
        If txtKeyword.TextLength > 0 Then
            FindPatient()
            CloseOnScreenKeyboard()
        Else
            MessageBox.Show("Please enter the patient's name", "No Name to Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub dgvCustomerFindList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerFindList.CellContentClick

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnHideMoreInfo.Click
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

    Private Sub btnCantFindName_Click(sender As Object, e As EventArgs) Handles btnCantFindName.Click
        SelectedCustomer = Nothing
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs)
        pnlMoreInfo.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SelectedCustomer = Nothing
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
End Class