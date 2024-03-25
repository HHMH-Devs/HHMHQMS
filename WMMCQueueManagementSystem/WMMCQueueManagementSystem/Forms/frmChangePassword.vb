Public Class frmChangePassword
    Private _account As Server

    Public Property Account As Server
        Get
            Return _account
        End Get
        Private Set(value As Server)
            _account = value
        End Set
    End Property

    Sub New(account As Server)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Account = account
    End Sub
    Private Sub btnLoginAdmin_Click(sender As Object, e As EventArgs) Handles btnLoginAdmin.Click
        If Not txtPass1.Text.Trim.Length > 0 Then
            MessageBox.Show("Please enter a valid password ", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not txtPass1.Text = txtPass2.Text Then
            MessageBox.Show("Password not matched. Please re-enter the correct password", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim newPasswordAccount As New Server
            newPasswordAccount = Account
            newPasswordAccount.Pasaword = txtPass1.Text
            Dim serverController As New ServerController
            If serverController.ChangePassword(newPasswordAccount) Then
                MessageBox.Show("Your password is now updated.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.Yes
            Else
                MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class