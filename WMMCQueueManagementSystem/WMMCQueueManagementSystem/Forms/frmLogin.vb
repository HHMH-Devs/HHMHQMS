Public Class frmLogin
    Private _isAdminLogin As Boolean = False
    Private _isPCCLogin As Boolean = False
    Private _isMabClinicLogin As Boolean = False
    Private _loggedUser As Server
    Private loggedAdmin As administratoraccount
    Private showPassword As Boolean = False
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
    End Sub
    Public Property AdminLogin As Boolean
        Get
            Return _isAdminLogin
        End Get
        Private Set(value As Boolean)
            _isAdminLogin = value
        End Set
    End Property

    Public Property PCCLogin As Boolean
        Get
            Return _isPCCLogin
        End Get
        Private Set(value As Boolean)
            _isPCCLogin = value
        End Set
    End Property

    Public Property MABLogin As Boolean
        Get
            Return _isMabClinicLogin
        End Get
        Private Set(value As Boolean)
            _isMabClinicLogin = value
        End Set
    End Property

    Public Property LoggedUser As Server
        Get
            Return _loggedUser
        End Get
        Private Set(value As Server)
            _loggedUser = value
        End Set
    End Property

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

    Private Sub setThisFormLoginType()
        If AdminLogin Then
            btnlogin.Hide()
            btnLoginAdmin.Show()
            Me.AcceptButton = btnLoginAdmin
        Else
            btnLoginAdmin.Hide()
            btnlogin.Show()
            Me.AcceptButton = btnlogin
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtuser.Clear()
        txtpass.Clear()
        Me.Close()
    End Sub

    Private Sub frmLogin_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.F12 Then
            If AdminLogin Then
                AdminLogin = False
            Else
                AdminLogin = True
            End If
            setThisFormLoginType()
        ElseIf e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.F11 Then
            Dim frm As New frmConnection
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.Yes Then
                Dim dbType As String = ""
                Dim sysVersion As String = SystemVersion
                If SystemIsLive Then
                    DbType = "Live"
                Else
                    DbType = "Training"
                End If
                lblVersion.Text = DbType & vbCrLf & "ver: " & sysVersion
            End If
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CounterImageIconsXXLg = CounterIconsXXL
        CounterImageIconsExLg = CounterIconsExLg
        CounterImageIconsLg = CounterIconsLg
        CounterImageIconsMd = CounterIconsMd
        CounterImageIconsSm = CounterIconsSm
        CustomImageIconsXXLg = CustomIconsXXL
        CustomImageIconsLg = CustomIconsLg
        setThisFormLoginType()
        Dim dbType As String = ""
        Dim sysVersion As String = SystemVersion
        If SystemIsLive Then
            dbType = "Live"
        Else
            dbType = "Training"
        End If
        lblVersion.Text = dbType & vbCrLf & "ver: " & sysVersion
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim server As New Server
        server.Username = txtuser.Text
        server.Pasaword = txtpass.Text
        Dim serverController As New ServerController
        server = serverController.LoginReturnUserInformation(server)
        If Not IsNothing(server) Then
            If server.Pasaword.ToLower = "westmetro2022" Or server.Pasaword = "1" Then
                MessageBox.Show("This is a newly made account. Please change your password.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim frm As New frmChangePassword(server)
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.Yes Then
                    server = frm.Account
                End If
            End If
            LoggedUser = server
            Me.DialogResult = DialogResult.Yes
        Else
            MessageBox.Show("Username or password incorrect.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Clear()
        End If
    End Sub

    Private Sub btnLoginAdmin_Click(sender As Object, e As EventArgs) Handles btnLoginAdmin.Click
        Dim adminaccount As New administratoraccount
        adminaccount.adminusername = txtuser.Text
        adminaccount.adminpassword = txtpass.Text
        Dim admincontroller As New administratoraccountcontroller
        If admincontroller.AdminLogin(adminaccount) Then
            Me.DialogResult = DialogResult.Yes
        Else
            MessageBox.Show("Username or password incorrect.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtpass.Clear()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        showPassword = Not showPassword
        If showPassword Then
            LinkLabel1.Text = "Hide Password"
            txtpass.PasswordChar = ""
        Else
            LinkLabel1.Text = "Show Password"
            txtpass.PasswordChar = "*"
        End If
    End Sub
End Class