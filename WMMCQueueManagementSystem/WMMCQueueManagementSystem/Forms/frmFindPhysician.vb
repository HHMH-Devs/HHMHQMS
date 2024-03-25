Public Class frmFindPhysician
    Private _selectedPhysician As ReferringConsultant
    Private selectedItem As DataGridViewRow = Nothing

    Public Property SelectedPhysician As ReferringConsultant
        Get
            Return _selectedPhysician
        End Get
        Private Set(value As ReferringConsultant)
            _selectedPhysician = value
        End Set
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        ' Add any initialization after the InitializeComponent() call.
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

    Private Sub FindDoctor()
        If txtKeyword.Text.Trim.Length > 0 Then
            Dim apiController As New APIController
            Dim physicians As List(Of ReferringConsultant) = apiController.FindDoctor_ByKeyWord(txtKeyword.Text.Trim)
            dgvCustomerFindList.Rows.Clear()
            If Not IsNothing(physicians) Then
                For Each row As ReferringConsultant In physicians
                    dgvCustomerFindList.Rows.Add(
                        If(Not IsNothing(row.ID), row.ID, 0),
                        If(Not IsNothing(row.LastName), row.LastName.Trim.ToUpper & " ", "") & If(Not IsNothing(row.FirstName), row.FirstName.Trim.ToUpper & " ", "") & If(Not IsNothing(row.MiddleName), row.MiddleName.Trim.ToUpper, ""),
                        If(Not IsNothing(row.Specialization), row.Specialization.ToString.ToUpper, ""),
                        If(Not IsNothing(row.FirstName), row.FirstName.ToString.ToUpper, ""),
                        If(Not IsNothing(row.MiddleName), row.MiddleName.ToString.ToUpper, ""),
                        If(Not IsNothing(row.LastName), row.LastName.ToString.ToUpper, ""),
                        If(Not IsNothing(row.PrimaryMobile), row.PrimaryMobile.ToString.ToUpper, ""),
                        If(Not IsNothing(row.SecondaryMobile), row.SecondaryMobile.ToString.ToUpper, "")
                    )
                    dgvCustomerFindList.Rows(dgvCustomerFindList.Rows.Count - 1).Height = 50
                Next
                dgvCustomerFindList.ClearSelection()
                txtKeyword.Focus()
            End If
        Else
            dgvCustomerFindList.Rows.Clear()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmFindPhysician_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCustomerFindList.Rows.Clear()
        txtKeyword.Clear()
        pnlMoreInfo.Hide()
        txtKeyword.Select()
    End Sub

    Private Sub btnHideMoreInfo_Click(sender As Object, e As EventArgs) Handles btnHideMoreInfo.Click
        pnlMoreInfo.Hide()
        selectedItem = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FindDoctor()
    End Sub

    Private Sub txtKeyword_TextChanged(sender As Object, e As EventArgs) Handles txtKeyword.TextChanged

    End Sub

    Private Sub txtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub dgvCustomerFindList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerFindList.CellContentClick

    End Sub

    Private Sub dgvCustomerFindList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomerFindList.CellClick
        If dgvCustomerFindList.SelectedRows.Count > 0 Then
            selectedItem = dgvCustomerFindList.SelectedRows(0)
            lbfname.Text = selectedItem.Cells("tmpfname").Value
            lbmname.Text = selectedItem.Cells("tmpmname").Value
            lblname.Text = selectedItem.Cells("tmplname").Value
            lbSpecialization.Text = selectedItem.Cells("specialization").Value
            lblPrimaryContact.Text = selectedItem.Cells("tmpprimaryContact").Value
            lblSecondaryContact.Text = selectedItem.Cells("tmpsecondaryContact").Value
            pnlMoreInfo.Show()
        End If
    End Sub

    Private Sub btnConfirmSelection_Click(sender As Object, e As EventArgs) Handles btnConfirmSelection.Click
        If Not IsNothing(selectedItem) Then
            Dim id As Long = selectedItem.Cells("id").Value()
            Dim apiCon As New APIController
            Dim physicianInfo As ReferringConsultant = apiCon.FindCertainDoctor(id)
            If Not IsNothing(physicianInfo) Then
                SelectedPhysician = physicianInfo
                Me.DialogResult = DialogResult.Yes
            End If
        End If
    End Sub
End Class