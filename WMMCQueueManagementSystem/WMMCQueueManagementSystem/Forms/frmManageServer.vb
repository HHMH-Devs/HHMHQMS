Public Class frmManageServer
    Private Server As Server
    Private ClinicCounter As Counter = Nothing
    Private physicianID As String = ""
    Private specialization As String = ""
    Private prc As String = ""
    Private ptr As String = ""
    Private s2 As String = ""
    Private imgPasswordHide As Image = Nothing
    Private imgPasswordShow As Image = Nothing
    Private showPassword As Boolean = False
    Sub New()
        InitializeComponent()
        btnSave.Visible = True
        btnUpdate.Visible = False
        Me.AcceptButton = btnSave
    End Sub

    Sub New(server As Server)
        InitializeComponent()
        Me.Server = server
        physicianID = server.PhysicianID
        If physicianID.Length > 0 Then
            lblPhysicianID.Text = physicianID
        End If
        txtEmpID.Text = server.EmmployeeID
        txtFirstName.Text = server.FirstName
        txtMiddleInit.Text = server.MiddleName
        txtLastName.Text = server.LastName
        txtAssignDept.Text = server.AssignDepartment
        lblSpecialization.Text = server.Specialization
        lblPRC.Text = server.PRC
        lblPTR.Text = server.PTR
        txts2.Text = server.S2No
        'txtContactNo.Text = server.ContactNo
        'txtSecretaryContactNo.Text = server.SecondaryContactNo
        Me.specialization = server.Specialization
        Me.prc = server.PRC
        Me.ptr = server.PTR
        Me.s2 = server.S2No
        Me.physicianID = server.PhysicianID
        txtUname.Text = server.Username
        txtPass.Text = server.Pasaword
        If server.AccountType = 1 Then
            rbDoctor.Checked = True
        ElseIf server.AccountType = 0 Then
            rbPccAccount.Checked = True
        End If
        txtEmpID.ReadOnly = True
        txtUname.ReadOnly = True
        btnSave.Visible = False
        btnUpdate.Visible = True
        Me.AcceptButton = btnUpdate
    End Sub

    Private Function isDataComplete() As Boolean
        If txtEmpID.Text.Trim = "" Then
            MessageBox.Show("Employee ID is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtLastName.Text.Trim = "" And txtFirstName.Text.Trim = "" Then
            MessageBox.Show("User's FullName is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtAssignDept.Text.Trim = "" Then
            MessageBox.Show("Assigned Department is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtUname.Text.Trim = "" Then
            MessageBox.Show("Username is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf txtPass.Text.Trim = "" Then
            MessageBox.Show("User's Password is a required field", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        ElseIf rbDoctor.Checked And (Me.physicianID = "" Or Me.specialization = "" Or Me.prc = "") Then
            MessageBox.Show("Doctor's account should contains the following field" & vbCrLf & vbCrLf & " -Bizbox ID" & vbCrLf & " -Specialization" & vbCrLf & " -PRC Numbeer", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Return True
        End If
    End Function


    Private Sub frmManageServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imgPasswordHide = CustomImageIconsLg.Images(7)
        imgPasswordShow = CustomImageIconsLg.Images(8)
        If showPassword Then
            PictureBox1.Image = imgPasswordHide
        Else
            PictureBox1.Image = imgPasswordShow
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If isDataComplete() Then
            If MessageBox.Show("Do you want to save this new user?", "New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim server As New Server
                server.EmmployeeID = txtEmpID.Text
                server.FullName = txtLastName.Text.ToUpper.Trim & ", " & txtFirstName.Text.ToUpper.Trim
                server.FirstName = txtFirstName.Text.ToUpper.Trim
                server.MiddleName = txtMiddleInit.Text.ToUpper.Trim
                server.LastName = txtLastName.Text.ToUpper.Trim
                server.AssignDepartment = txtAssignDept.Text.ToUpper.Trim
                server.Specialization = Me.specialization.ToUpper.Trim
                server.PRC = Me.prc.ToUpper.Trim
                server.PTR = Me.ptr.ToUpper.Trim
                server.S2No = Me.s2.ToUpper.Trim
                'server.ContactNo = txtContactNo.Text.Trim
                'server.SecondaryContactNo = "" 'txtSecretaryContactNo.Text.Trim
                server.PhysicianID = Me.physicianID
                server.Username = txtUname.Text
                server.Pasaword = txtPass.Text
                If rbDoctor.Checked Then
                    server.AccountType = 1
                Else
                    server.AccountType = 0
                End If
                Dim serverController As New ServerController
                If ServerController.NewServer(server) Then
                    MessageBox.Show("New account created successfully", "New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("There was an error during the process.", "New Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If isDataComplete() Then
            If MessageBox.Show("Do you want to update this user?", "New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim server As New Server
                server.Server_ID = Me.Server.Server_ID
                server.EmmployeeID = txtEmpID.Text
                server.FullName = txtLastName.Text.ToUpper.Trim & ", " & txtFirstName.Text.ToUpper.Trim
                server.FirstName = txtFirstName.Text.ToUpper.Trim
                server.MiddleName = txtMiddleInit.Text.ToUpper.Trim
                server.LastName = txtLastName.Text.ToUpper.Trim
                server.AssignDepartment = txtAssignDept.Text.ToUpper.Trim
                server.Specialization = Me.specialization.ToUpper.Trim
                server.PRC = Me.prc.ToUpper.Trim
                server.PTR = Me.ptr.ToUpper.Trim
                server.S2No = Me.s2.ToUpper.Trim
                'server.ContactNo = txtContactNo.Text.Trim
                'server.SecondaryContactNo = txtSecretaryContactNo.Text.Trim
                server.PhysicianID = Me.physicianID
                server.Username = txtUname.Text
                server.Pasaword = txtPass.Text
                If rbDoctor.Checked Then
                    server.AccountType = 1
                Else
                    server.AccountType = 0
                End If
                Dim serverController As New ServerController
                If serverController.UpdateServer(server) Then
                    MessageBox.Show("User account updated successfully", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.Yes
                Else
                    MessageBox.Show("There was an error during the process.", "New User Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub txtEmpID_TextChanged(sender As Object, e As EventArgs) Handles txtEmpID.TextChanged
        txtUname.Text = txtEmpID.Text
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtUname_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        Dim frm As New frmFindDoctor
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            If Not IsNothing(frm.FoundDoctor) Then
                Me.physicianID = frm.FoundDoctor.PhysicianID
                Me.specialization = frm.FoundDoctor.Specialization
                Me.prc = frm.FoundDoctor.PRC
                Me.ptr = ""
                Me.s2 = ""
                txtEmpID.Text = frm.FoundDoctor.PRC
                txtFirstName.Text = frm.FoundDoctor.FirstName
                txtMiddleInit.Text = frm.FoundDoctor.MiddleName
                txtLastName.Text = frm.FoundDoctor.LastName
                txtUname.Text = frm.FoundDoctor.PRC
                lblPhysicianID.Text = frm.FoundDoctor.PhysicianID
                lblSpecialization.Text = frm.FoundDoctor.Specialization
                lblPRC.Text = frm.FoundDoctor.PRC.Trim
                lblPTR.Text = frm.FoundDoctor.PTR.Trim
                txts2.Text = frm.FoundDoctor.S2No.Trim
                'txtContactNo.Text = frm.FoundDoctor.ContactNo.Trim
                'txtSecretaryContactNo.Text = frm.FoundDoctor.SecondaryContactNo.Trim
            End If
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        showPassword = Not showPassword
        If showPassword Then
            PictureBox1.Image = imgPasswordHide
            txtPass.PasswordChar = ""
        Else
            PictureBox1.Image = imgPasswordShow
            txtPass.PasswordChar = "*"
        End If
    End Sub

    Private Sub rbDoctor_CheckedChanged(sender As Object, e As EventArgs) Handles rbDoctor.CheckedChanged

    End Sub

    Private Sub rbPccAccount_CheckedChanged(sender As Object, e As EventArgs) Handles rbPccAccount.CheckedChanged

    End Sub

    Private Sub lblPTR_TextChanged(sender As Object, e As EventArgs) Handles lblPTR.TextChanged
        If Not Me.ptr = lblPTR.Text Then
            Me.ptr = lblPTR.Text
        End If
    End Sub

    Private Sub txts2_TextChanged(sender As Object, e As EventArgs) Handles txts2.TextChanged
        If Not Me.s2 = txts2.Text Then
            Me.s2 = txts2.Text
        End If
    End Sub

    Private Sub gbDoctors_Enter(sender As Object, e As EventArgs) Handles gbDoctors.Enter

    End Sub
End Class