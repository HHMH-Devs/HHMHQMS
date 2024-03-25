Public Class frmFoundPatientList_Touch
    Private selectedItem As DataGridViewRow = Nothing
    Private _selectedCustomer As CustomerInfo

    Public Property SelectedCustomer As CustomerInfo
        Get
            Return _selectedCustomer
        End Get
        Private Set(value As CustomerInfo)
            _selectedCustomer = value
        End Set
    End Property

    Sub New(data As List(Of CustomerInfo))
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        ' Add any initialization after the InitializeComponent() call
        If Not IsNothing(data) Then
            For Each row As CustomerInfo In data
                Dim imgIco As Image = Nothing
                If Not IsNothing(row.Sex) Then
                    If row.Sex.Trim.ToUpper = "MALE" Then
                        imgIco = CustomImageIconsLg.Images(11)
                    Else
                        imgIco = CustomImageIconsLg.Images(12)
                    End If
                End If
                dgvCustomerFindList.Rows.Add(
                    imgIco, If(Not IsNothing(row.Info_ID), row.Info_ID, 0),
                    If(Not IsNothing(row.Lastname), row.Lastname.Trim.ToUpper & " ", "") & If(Not IsNothing(row.FirstName), row.FirstName.Trim.ToUpper & " ", "") & If(Not IsNothing(row.Middlename), row.Middlename.Trim.ToUpper, ""),
                    If(Not IsNothing(row.BirthDate), CDate(row.BirthDate).ToLongDateString, ""),
                    If(Not IsNothing(row.FirstName), row.FirstName.ToString.ToUpper, ""),
                    If(Not IsNothing(row.Middlename), row.Middlename.ToString.ToUpper, ""),
                    If(Not IsNothing(row.Lastname), row.Lastname.ToString.ToUpper, ""),
                    If(Not IsNothing(row.Sex), row.Sex.ToString.ToUpper, ""),
                    If(Not IsNothing(row.FK_emdPatients), row.FK_emdPatients, 0)
                )
                dgvCustomerFindList.Rows(dgvCustomerFindList.Rows.Count - 1).Height = 60
            Next
            lblInstruction.Text = data.Count & " RESULT MATCHES. PLEASE CLICK THE INFORMATION ON THE LIST THAT IDENTIFIES YOU."
        End If
    End Sub

    Sub New(data As DataTable)
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        ' Add any initialization after the InitializeComponent() call
        If Not IsNothing(data) Then
            For Each row As DataRow In data.Rows
                Dim imgIco As Image = Nothing
                If Not IsNothing(row("gender")) Then
                    If row("gender").Trim.ToUpper = "MALE" Then
                        imgIco = CustomImageIconsLg.Images(11)
                    Else
                        imgIco = CustomImageIconsLg.Images(12)
                    End If
                End If
                dgvCustomerFindList.Rows.Add(
                    imgIco, 0,
                    If(Not IsDBNull(row("fullname")), row("fullname").ToString.ToUpper, ""),
                    If(Not IsDBNull(row("birthdate")), CDate(row("birthdate")).ToLongDateString, ""),
                    If(Not IsDBNull(row("firstname")), row("firstname").ToString.ToUpper, ""),
                    If(Not IsDBNull(row("middlename")), row("middlename").ToString.ToUpper, ""),
                    If(Not IsDBNull(row("lastname")), row("lastname").ToString.ToUpper, ""),
                    If(Not IsDBNull(row("gender")), row("gender").ToString.ToUpper, ""),
                    If(Not IsDBNull(row("PK_psPersonalData")), row("PK_psPersonalData").ToString.ToUpper, 0)
                )
                dgvCustomerFindList.Rows(dgvCustomerFindList.Rows.Count - 1).Height = 60
            Next
            lblInstruction.Text = data.Rows.Count & " RESULT MATCHES. PLEASE CLICK THE INFORMATION ON THE LIST THAT IDENTIFIES YOU."
        End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnlMoreInfo.Hide()
    End Sub

    Private Sub btnHideMoreInfo_Click(sender As Object, e As EventArgs) Handles btnHideMoreInfo.Click
        pnlRegisterAlert.Show()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.No
    End Sub

    Private Sub frmFoundPatientList_Touch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCustomerFindList.ClearSelection()
    End Sub

    Private Sub dgvCustomerFindList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerFindList.CellContentClick

    End Sub
End Class