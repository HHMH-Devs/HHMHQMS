<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnlogin = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnLoginAdmin = New System.Windows.Forms.Button()
        Me.CounterIconsLg = New System.Windows.Forms.ImageList(Me.components)
        Me.CounterIconsMd = New System.Windows.Forms.ImageList(Me.components)
        Me.CounterIconsSm = New System.Windows.Forms.ImageList(Me.components)
        Me.CounterIconsExLg = New System.Windows.Forms.ImageList(Me.components)
        Me.CounterIconsXXL = New System.Windows.Forms.ImageList(Me.components)
        Me.CustomIconsXXL = New System.Windows.Forms.ImageList(Me.components)
        Me.CustomIconsLg = New System.Windows.Forms.ImageList(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtuser
        '
        Me.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtuser.Location = New System.Drawing.Point(217, 94)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(248, 20)
        Me.txtuser.TabIndex = 0
        '
        'txtpass
        '
        Me.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpass.Location = New System.Drawing.Point(217, 153)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(248, 20)
        Me.txtpass.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(27, 58)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(176, 132)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.LimeGreen
        Me.btnlogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnlogin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnlogin.FlatAppearance.BorderSize = 0
        Me.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogin.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnlogin.Location = New System.Drawing.Point(258, 227)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(119, 27)
        Me.btnlogin.TabIndex = 4
        Me.btnlogin.Text = "Login"
        Me.btnlogin.UseVisualStyleBackColor = False
        Me.btnlogin.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(383, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 27)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(202, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 58)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "QUEUEING AND E-CLINIC SYSTEM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(220, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Username"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(220, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Password"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblVersion)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Location = New System.Drawing.Point(-15, -15)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(218, 283)
        Me.Panel1.TabIndex = 9
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(16, 207)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(199, 62)
        Me.lblVersion.TabIndex = 11
        Me.lblVersion.Text = "VERSION"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnLoginAdmin
        '
        Me.btnLoginAdmin.BackColor = System.Drawing.Color.LimeGreen
        Me.btnLoginAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoginAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnLoginAdmin.FlatAppearance.BorderSize = 0
        Me.btnLoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoginAdmin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoginAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnLoginAdmin.Location = New System.Drawing.Point(218, 227)
        Me.btnLoginAdmin.Name = "btnLoginAdmin"
        Me.btnLoginAdmin.Size = New System.Drawing.Size(159, 27)
        Me.btnLoginAdmin.TabIndex = 10
        Me.btnLoginAdmin.Text = "Login as Admin"
        Me.btnLoginAdmin.UseVisualStyleBackColor = False
        Me.btnLoginAdmin.Visible = False
        '
        'CounterIconsLg
        '
        Me.CounterIconsLg.ImageStream = CType(resources.GetObject("CounterIconsLg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CounterIconsLg.TransparentColor = System.Drawing.Color.Transparent
        Me.CounterIconsLg.Images.SetKeyName(0, "default.png")
        Me.CounterIconsLg.Images.SetKeyName(1, "OPD TELLER.png")
        Me.CounterIconsLg.Images.SetKeyName(2, "car.png")
        Me.CounterIconsLg.Images.SetKeyName(3, "consultation-logo.png")
        Me.CounterIconsLg.Images.SetKeyName(4, "hims.png")
        Me.CounterIconsLg.Images.SetKeyName(5, "HMO.png")
        Me.CounterIconsLg.Images.SetKeyName(6, "lab.results.png")
        Me.CounterIconsLg.Images.SetKeyName(7, "med.png")
        Me.CounterIconsLg.Images.SetKeyName(8, "PHIC.png")
        Me.CounterIconsLg.Images.SetKeyName(9, "rad.png")
        Me.CounterIconsLg.Images.SetKeyName(10, "soc.png")
        Me.CounterIconsLg.Images.SetKeyName(11, "triage.png")
        Me.CounterIconsLg.Images.SetKeyName(12, "self-service.png")
        Me.CounterIconsLg.Images.SetKeyName(13, "lab.extraction.png")
        Me.CounterIconsLg.Images.SetKeyName(14, "adm.png")
        Me.CounterIconsLg.Images.SetKeyName(15, "opd.png")
        Me.CounterIconsLg.Images.SetKeyName(16, "ani.png")
        Me.CounterIconsLg.Images.SetKeyName(17, "chemo.png")
        Me.CounterIconsLg.Images.SetKeyName(18, "cli.png")
        Me.CounterIconsLg.Images.SetKeyName(19, "ct.png")
        Me.CounterIconsLg.Images.SetKeyName(20, "nut.png")
        Me.CounterIconsLg.Images.SetKeyName(21, "rehab.png")
        Me.CounterIconsLg.Images.SetKeyName(22, "ultra.png")
        Me.CounterIconsLg.Images.SetKeyName(23, "xray.png")
        Me.CounterIconsLg.Images.SetKeyName(24, "lab.clerk.png")
        Me.CounterIconsLg.Images.SetKeyName(25, "lab.clerk6.png")
        Me.CounterIconsLg.Images.SetKeyName(26, "clinic1.png")
        Me.CounterIconsLg.Images.SetKeyName(27, "clinic2.png")
        Me.CounterIconsLg.Images.SetKeyName(28, "clinic3.png")
        Me.CounterIconsLg.Images.SetKeyName(29, "claimresult.png")
        Me.CounterIconsLg.Images.SetKeyName(30, "clinic4.png")
        Me.CounterIconsLg.Images.SetKeyName(31, "clinic5.png")
        Me.CounterIconsLg.Images.SetKeyName(32, "clinic6.png")
        Me.CounterIconsLg.Images.SetKeyName(33, "diagnostic & checkup.png")
        Me.CounterIconsLg.Images.SetKeyName(34, "information (1).png")
        Me.CounterIconsLg.Images.SetKeyName(35, "medex.jpg")
        Me.CounterIconsLg.Images.SetKeyName(36, "emergency (1).png")
        Me.CounterIconsLg.Images.SetKeyName(37, "emergency.png")
        Me.CounterIconsLg.Images.SetKeyName(38, "Screening.png")
        Me.CounterIconsLg.Images.SetKeyName(39, "IPD TELLER.png")
        Me.CounterIconsLg.Images.SetKeyName(40, "rehab.png")
        Me.CounterIconsLg.Images.SetKeyName(41, "REQUEUING STATION.png")
        Me.CounterIconsLg.Images.SetKeyName(42, "ertriage")
        Me.CounterIconsLg.Images.SetKeyName(43, "SOLO QUEUE.png")
        Me.CounterIconsLg.Images.SetKeyName(44, "physics - ICO.png")
        Me.CounterIconsLg.Images.SetKeyName(45, "pharmacy - ICO.png")
        Me.CounterIconsLg.Images.SetKeyName(46, "Assistive Technology.png")
        Me.CounterIconsLg.Images.SetKeyName(47, "Priority Lane.jpg")
        '
        'CounterIconsMd
        '
        Me.CounterIconsMd.ImageStream = CType(resources.GetObject("CounterIconsMd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CounterIconsMd.TransparentColor = System.Drawing.Color.Transparent
        Me.CounterIconsMd.Images.SetKeyName(0, "default.png")
        Me.CounterIconsMd.Images.SetKeyName(1, "OPD TELLER.png")
        Me.CounterIconsMd.Images.SetKeyName(2, "car.png")
        Me.CounterIconsMd.Images.SetKeyName(3, "consultation-logo.png")
        Me.CounterIconsMd.Images.SetKeyName(4, "hims.png")
        Me.CounterIconsMd.Images.SetKeyName(5, "HMO.png")
        Me.CounterIconsMd.Images.SetKeyName(6, "lab.results.png")
        Me.CounterIconsMd.Images.SetKeyName(7, "med.png")
        Me.CounterIconsMd.Images.SetKeyName(8, "PHIC.png")
        Me.CounterIconsMd.Images.SetKeyName(9, "rad.png")
        Me.CounterIconsMd.Images.SetKeyName(10, "soc.png")
        Me.CounterIconsMd.Images.SetKeyName(11, "triage.png")
        Me.CounterIconsMd.Images.SetKeyName(12, "self-service.png")
        Me.CounterIconsMd.Images.SetKeyName(13, "lab.extraction.png")
        Me.CounterIconsMd.Images.SetKeyName(14, "adm.png")
        Me.CounterIconsMd.Images.SetKeyName(15, "opd.png")
        Me.CounterIconsMd.Images.SetKeyName(16, "ani.png")
        Me.CounterIconsMd.Images.SetKeyName(17, "chemo.png")
        Me.CounterIconsMd.Images.SetKeyName(18, "cli.png")
        Me.CounterIconsMd.Images.SetKeyName(19, "ct.png")
        Me.CounterIconsMd.Images.SetKeyName(20, "nut.png")
        Me.CounterIconsMd.Images.SetKeyName(21, "rehab.png")
        Me.CounterIconsMd.Images.SetKeyName(22, "ultra.png")
        Me.CounterIconsMd.Images.SetKeyName(23, "xray.png")
        Me.CounterIconsMd.Images.SetKeyName(24, "lab.clerk.png")
        Me.CounterIconsMd.Images.SetKeyName(25, "lab.clerk6.png")
        Me.CounterIconsMd.Images.SetKeyName(26, "clinic1.png")
        Me.CounterIconsMd.Images.SetKeyName(27, "clinic2.png")
        Me.CounterIconsMd.Images.SetKeyName(28, "clinic3.png")
        Me.CounterIconsMd.Images.SetKeyName(29, "claimresult.png")
        Me.CounterIconsMd.Images.SetKeyName(30, "clinic4.png")
        Me.CounterIconsMd.Images.SetKeyName(31, "clinic5.png")
        Me.CounterIconsMd.Images.SetKeyName(32, "clinic6.png")
        Me.CounterIconsMd.Images.SetKeyName(33, "diagnostic & checkup.png")
        Me.CounterIconsMd.Images.SetKeyName(34, "information (1).png")
        Me.CounterIconsMd.Images.SetKeyName(35, "medex.jpg")
        Me.CounterIconsMd.Images.SetKeyName(36, "emergency (1).png")
        Me.CounterIconsMd.Images.SetKeyName(37, "emergency.png")
        Me.CounterIconsMd.Images.SetKeyName(38, "Screening.png")
        Me.CounterIconsMd.Images.SetKeyName(39, "IPD TELLER.png")
        Me.CounterIconsMd.Images.SetKeyName(40, "rehab.png")
        Me.CounterIconsMd.Images.SetKeyName(41, "REQUEUING STATION.png")
        Me.CounterIconsMd.Images.SetKeyName(42, "ertriage")
        Me.CounterIconsMd.Images.SetKeyName(43, "SOLO QUEUE.png")
        Me.CounterIconsMd.Images.SetKeyName(44, "physicalexam")
        Me.CounterIconsMd.Images.SetKeyName(45, "pharma")
        Me.CounterIconsMd.Images.SetKeyName(46, "Assistive Technology.png")
        Me.CounterIconsMd.Images.SetKeyName(47, "Priority Lane.jpg")
        '
        'CounterIconsSm
        '
        Me.CounterIconsSm.ImageStream = CType(resources.GetObject("CounterIconsSm.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CounterIconsSm.TransparentColor = System.Drawing.Color.Transparent
        Me.CounterIconsSm.Images.SetKeyName(0, "default.png")
        Me.CounterIconsSm.Images.SetKeyName(1, "OPD TELLER.png")
        Me.CounterIconsSm.Images.SetKeyName(2, "car.png")
        Me.CounterIconsSm.Images.SetKeyName(3, "consultation-logo.png")
        Me.CounterIconsSm.Images.SetKeyName(4, "hims.png")
        Me.CounterIconsSm.Images.SetKeyName(5, "HMO.png")
        Me.CounterIconsSm.Images.SetKeyName(6, "lab.results.png")
        Me.CounterIconsSm.Images.SetKeyName(7, "med.png")
        Me.CounterIconsSm.Images.SetKeyName(8, "PHIC.png")
        Me.CounterIconsSm.Images.SetKeyName(9, "rad.png")
        Me.CounterIconsSm.Images.SetKeyName(10, "soc.png")
        Me.CounterIconsSm.Images.SetKeyName(11, "triage.png")
        Me.CounterIconsSm.Images.SetKeyName(12, "self-service.png")
        Me.CounterIconsSm.Images.SetKeyName(13, "lab.extraction.png")
        Me.CounterIconsSm.Images.SetKeyName(14, "adm.png")
        Me.CounterIconsSm.Images.SetKeyName(15, "opd.png")
        Me.CounterIconsSm.Images.SetKeyName(16, "ani.png")
        Me.CounterIconsSm.Images.SetKeyName(17, "chemo.png")
        Me.CounterIconsSm.Images.SetKeyName(18, "cli.png")
        Me.CounterIconsSm.Images.SetKeyName(19, "ct.png")
        Me.CounterIconsSm.Images.SetKeyName(20, "nut.png")
        Me.CounterIconsSm.Images.SetKeyName(21, "rehab.png")
        Me.CounterIconsSm.Images.SetKeyName(22, "ultra.png")
        Me.CounterIconsSm.Images.SetKeyName(23, "xray.png")
        Me.CounterIconsSm.Images.SetKeyName(24, "lab.clerk.png")
        Me.CounterIconsSm.Images.SetKeyName(25, "lab.clerk6.png")
        Me.CounterIconsSm.Images.SetKeyName(26, "clinic1.png")
        Me.CounterIconsSm.Images.SetKeyName(27, "clinic2.png")
        Me.CounterIconsSm.Images.SetKeyName(28, "clinic3.png")
        Me.CounterIconsSm.Images.SetKeyName(29, "claimresult.png")
        Me.CounterIconsSm.Images.SetKeyName(30, "clinic4.png")
        Me.CounterIconsSm.Images.SetKeyName(31, "clinic5.png")
        Me.CounterIconsSm.Images.SetKeyName(32, "clinic6.png")
        Me.CounterIconsSm.Images.SetKeyName(33, "diagnostic & checkup.png")
        Me.CounterIconsSm.Images.SetKeyName(34, "information (1).png")
        Me.CounterIconsSm.Images.SetKeyName(35, "medex.jpg")
        Me.CounterIconsSm.Images.SetKeyName(36, "emergency (1).png")
        Me.CounterIconsSm.Images.SetKeyName(37, "emergency.png")
        Me.CounterIconsSm.Images.SetKeyName(38, "Screening.png")
        Me.CounterIconsSm.Images.SetKeyName(39, "IPD TELLER.png")
        Me.CounterIconsSm.Images.SetKeyName(40, "rehab.png")
        Me.CounterIconsSm.Images.SetKeyName(41, "REQUEUING STATION.png")
        Me.CounterIconsSm.Images.SetKeyName(42, "ertriage")
        Me.CounterIconsSm.Images.SetKeyName(43, "SOLO QUEUE.png")
        Me.CounterIconsSm.Images.SetKeyName(44, "physicalexam")
        Me.CounterIconsSm.Images.SetKeyName(45, "pharma")
        Me.CounterIconsSm.Images.SetKeyName(46, "Assistive Technology.png")
        Me.CounterIconsSm.Images.SetKeyName(47, "Priority Lane.jpg")
        '
        'CounterIconsExLg
        '
        Me.CounterIconsExLg.ImageStream = CType(resources.GetObject("CounterIconsExLg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CounterIconsExLg.TransparentColor = System.Drawing.Color.Transparent
        Me.CounterIconsExLg.Images.SetKeyName(0, "default.png")
        Me.CounterIconsExLg.Images.SetKeyName(1, "OPD TELLER.png")
        Me.CounterIconsExLg.Images.SetKeyName(2, "car.png")
        Me.CounterIconsExLg.Images.SetKeyName(3, "consultation-logo.png")
        Me.CounterIconsExLg.Images.SetKeyName(4, "hims.png")
        Me.CounterIconsExLg.Images.SetKeyName(5, "HMO.png")
        Me.CounterIconsExLg.Images.SetKeyName(6, "lab.results.png")
        Me.CounterIconsExLg.Images.SetKeyName(7, "med.png")
        Me.CounterIconsExLg.Images.SetKeyName(8, "PHIC.png")
        Me.CounterIconsExLg.Images.SetKeyName(9, "rad.png")
        Me.CounterIconsExLg.Images.SetKeyName(10, "soc.png")
        Me.CounterIconsExLg.Images.SetKeyName(11, "triage.png")
        Me.CounterIconsExLg.Images.SetKeyName(12, "self-service.png")
        Me.CounterIconsExLg.Images.SetKeyName(13, "lab.extraction.png")
        Me.CounterIconsExLg.Images.SetKeyName(14, "adm.png")
        Me.CounterIconsExLg.Images.SetKeyName(15, "opd.png")
        Me.CounterIconsExLg.Images.SetKeyName(16, "ani.png")
        Me.CounterIconsExLg.Images.SetKeyName(17, "chemo.png")
        Me.CounterIconsExLg.Images.SetKeyName(18, "cli.png")
        Me.CounterIconsExLg.Images.SetKeyName(19, "ct.png")
        Me.CounterIconsExLg.Images.SetKeyName(20, "nut.png")
        Me.CounterIconsExLg.Images.SetKeyName(21, "rehab.png")
        Me.CounterIconsExLg.Images.SetKeyName(22, "ultra.png")
        Me.CounterIconsExLg.Images.SetKeyName(23, "xray.png")
        Me.CounterIconsExLg.Images.SetKeyName(24, "lab.clerk.png")
        Me.CounterIconsExLg.Images.SetKeyName(25, "lab.clerk6.png")
        Me.CounterIconsExLg.Images.SetKeyName(26, "clinic1.png")
        Me.CounterIconsExLg.Images.SetKeyName(27, "clinic2.png")
        Me.CounterIconsExLg.Images.SetKeyName(28, "clinic3.png")
        Me.CounterIconsExLg.Images.SetKeyName(29, "claimresult.png")
        Me.CounterIconsExLg.Images.SetKeyName(30, "clinic4.png")
        Me.CounterIconsExLg.Images.SetKeyName(31, "clinic5.png")
        Me.CounterIconsExLg.Images.SetKeyName(32, "clinic6.png")
        Me.CounterIconsExLg.Images.SetKeyName(33, "diagnostic & checkup.png")
        Me.CounterIconsExLg.Images.SetKeyName(34, "information (1).png")
        Me.CounterIconsExLg.Images.SetKeyName(35, "medex.jpg")
        Me.CounterIconsExLg.Images.SetKeyName(36, "emergency (1).png")
        Me.CounterIconsExLg.Images.SetKeyName(37, "emergency.png")
        Me.CounterIconsExLg.Images.SetKeyName(38, "Screening.png")
        Me.CounterIconsExLg.Images.SetKeyName(39, "IPD TELLER.png")
        Me.CounterIconsExLg.Images.SetKeyName(40, "rehab.png")
        Me.CounterIconsExLg.Images.SetKeyName(41, "REQUEUING STATION.png")
        Me.CounterIconsExLg.Images.SetKeyName(42, "ertriage")
        Me.CounterIconsExLg.Images.SetKeyName(43, "SOLO QUEUE.png")
        Me.CounterIconsExLg.Images.SetKeyName(44, "physicalexam")
        Me.CounterIconsExLg.Images.SetKeyName(45, "pharma")
        Me.CounterIconsExLg.Images.SetKeyName(46, "Assistive Technology.png")
        Me.CounterIconsExLg.Images.SetKeyName(47, "Priority Lane.jpg")
        '
        'CounterIconsXXL
        '
        Me.CounterIconsXXL.ImageStream = CType(resources.GetObject("CounterIconsXXL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CounterIconsXXL.TransparentColor = System.Drawing.Color.Transparent
        Me.CounterIconsXXL.Images.SetKeyName(0, "default.png")
        Me.CounterIconsXXL.Images.SetKeyName(1, "OPD TELLER.png")
        Me.CounterIconsXXL.Images.SetKeyName(2, "car.png")
        Me.CounterIconsXXL.Images.SetKeyName(3, "consultation.png")
        Me.CounterIconsXXL.Images.SetKeyName(4, "hims.png")
        Me.CounterIconsXXL.Images.SetKeyName(5, "HMO.png")
        Me.CounterIconsXXL.Images.SetKeyName(6, "lab.results.png")
        Me.CounterIconsXXL.Images.SetKeyName(7, "med.png")
        Me.CounterIconsXXL.Images.SetKeyName(8, "PHIC.png")
        Me.CounterIconsXXL.Images.SetKeyName(9, "rad.png")
        Me.CounterIconsXXL.Images.SetKeyName(10, "soc.png")
        Me.CounterIconsXXL.Images.SetKeyName(11, "triage.png")
        Me.CounterIconsXXL.Images.SetKeyName(12, "self-service.png")
        Me.CounterIconsXXL.Images.SetKeyName(13, "lab.extraction.png")
        Me.CounterIconsXXL.Images.SetKeyName(14, "adm.png")
        Me.CounterIconsXXL.Images.SetKeyName(15, "opd.png")
        Me.CounterIconsXXL.Images.SetKeyName(16, "ani.png")
        Me.CounterIconsXXL.Images.SetKeyName(17, "chemo.png")
        Me.CounterIconsXXL.Images.SetKeyName(18, "cli.png")
        Me.CounterIconsXXL.Images.SetKeyName(19, "ct.png")
        Me.CounterIconsXXL.Images.SetKeyName(20, "nut.png")
        Me.CounterIconsXXL.Images.SetKeyName(21, "rehab.png")
        Me.CounterIconsXXL.Images.SetKeyName(22, "ultra.png")
        Me.CounterIconsXXL.Images.SetKeyName(23, "xray.png")
        Me.CounterIconsXXL.Images.SetKeyName(24, "lab.clerk.png")
        Me.CounterIconsXXL.Images.SetKeyName(25, "lab.clerk6.png")
        Me.CounterIconsXXL.Images.SetKeyName(26, "clinic1.png")
        Me.CounterIconsXXL.Images.SetKeyName(27, "clinic2.png")
        Me.CounterIconsXXL.Images.SetKeyName(28, "clinic3.png")
        Me.CounterIconsXXL.Images.SetKeyName(29, "claimresult.png")
        Me.CounterIconsXXL.Images.SetKeyName(30, "clinic4.png")
        Me.CounterIconsXXL.Images.SetKeyName(31, "clinic5.png")
        Me.CounterIconsXXL.Images.SetKeyName(32, "clinic6.png")
        Me.CounterIconsXXL.Images.SetKeyName(33, "diagnostic & checkup.png")
        Me.CounterIconsXXL.Images.SetKeyName(34, "information (1).png")
        Me.CounterIconsXXL.Images.SetKeyName(35, "medex.jpg")
        Me.CounterIconsXXL.Images.SetKeyName(36, "emergency (1).png")
        Me.CounterIconsXXL.Images.SetKeyName(37, "emergency.png")
        Me.CounterIconsXXL.Images.SetKeyName(38, "Screening.png")
        Me.CounterIconsXXL.Images.SetKeyName(39, "IPD TELLER.png")
        Me.CounterIconsXXL.Images.SetKeyName(40, "rehab.png")
        Me.CounterIconsXXL.Images.SetKeyName(41, "REQUEUING STATION.png")
        Me.CounterIconsXXL.Images.SetKeyName(42, "ertriage")
        Me.CounterIconsXXL.Images.SetKeyName(43, "SOLO QUEUE.png")
        Me.CounterIconsXXL.Images.SetKeyName(44, "physics.png")
        Me.CounterIconsXXL.Images.SetKeyName(45, "pharmacy.png")
        Me.CounterIconsXXL.Images.SetKeyName(46, "Assistive Technology.png")
        Me.CounterIconsXXL.Images.SetKeyName(47, "Priority Lane.jpg")
        '
        'CustomIconsXXL
        '
        Me.CustomIconsXXL.ImageStream = CType(resources.GetObject("CustomIconsXXL.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CustomIconsXXL.TransparentColor = System.Drawing.Color.Transparent
        Me.CustomIconsXXL.Images.SetKeyName(0, "CLINIC APPOINTMENT.png")
        Me.CustomIconsXXL.Images.SetKeyName(1, "doctorFemale.png")
        Me.CustomIconsXXL.Images.SetKeyName(2, "doctorMale.png")
        Me.CustomIconsXXL.Images.SetKeyName(3, "doctorGroup.png")
        Me.CustomIconsXXL.Images.SetKeyName(4, "PCC.png")
        Me.CustomIconsXXL.Images.SetKeyName(5, "MAB.png")
        Me.CustomIconsXXL.Images.SetKeyName(6, "MAB HYBRID.png")
        Me.CustomIconsXXL.Images.SetKeyName(7, "passwordhide")
        Me.CustomIconsXXL.Images.SetKeyName(8, "passwordshow")
        Me.CustomIconsXXL.Images.SetKeyName(9, "PCC HYBRID.png")
        Me.CustomIconsXXL.Images.SetKeyName(10, "ER")
        Me.CustomIconsXXL.Images.SetKeyName(11, "man.png")
        Me.CustomIconsXXL.Images.SetKeyName(12, "woman.png")
        Me.CustomIconsXXL.Images.SetKeyName(13, "mwell consult.png")
        Me.CustomIconsXXL.Images.SetKeyName(14, "visitor.png")
        Me.CustomIconsXXL.Images.SetKeyName(15, "scan qr.png")
        Me.CustomIconsXXL.Images.SetKeyName(16, "Assistive Technology.png")
        Me.CustomIconsXXL.Images.SetKeyName(17, "Priority Lane.jpg")
        '
        'CustomIconsLg
        '
        Me.CustomIconsLg.ImageStream = CType(resources.GetObject("CustomIconsLg.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.CustomIconsLg.TransparentColor = System.Drawing.Color.Transparent
        Me.CustomIconsLg.Images.SetKeyName(0, "clinic.png")
        Me.CustomIconsLg.Images.SetKeyName(1, "doctorFemale.png")
        Me.CustomIconsLg.Images.SetKeyName(2, "doctorMale.png")
        Me.CustomIconsLg.Images.SetKeyName(3, "doctorGroup.png")
        Me.CustomIconsLg.Images.SetKeyName(4, "PCC.png")
        Me.CustomIconsLg.Images.SetKeyName(5, "MAB.png")
        Me.CustomIconsLg.Images.SetKeyName(6, "MAB HYBRID.png")
        Me.CustomIconsLg.Images.SetKeyName(7, "passwordhide.png")
        Me.CustomIconsLg.Images.SetKeyName(8, "passwordshow.png")
        Me.CustomIconsLg.Images.SetKeyName(9, "PCC HYBRID.png")
        Me.CustomIconsLg.Images.SetKeyName(10, "ER")
        Me.CustomIconsLg.Images.SetKeyName(11, "man.png")
        Me.CustomIconsLg.Images.SetKeyName(12, "woman.png")
        Me.CustomIconsLg.Images.SetKeyName(13, "mwell consult.png")
        Me.CustomIconsLg.Images.SetKeyName(14, "visitor.png")
        Me.CustomIconsLg.Images.SetKeyName(15, "scan qr.png")
        Me.CustomIconsLg.Images.SetKeyName(16, "Assistive Technology.png")
        Me.CustomIconsLg.Images.SetKeyName(17, "Priority Lane.jpg")
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.LimeGreen
        Me.LinkLabel1.Location = New System.Drawing.Point(217, 181)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(248, 15)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Show password"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(483, 260)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnLoginAdmin)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtuser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmLogin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtpass As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnlogin As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLoginAdmin As Button
    Friend WithEvents CounterIconsLg As ImageList
    Friend WithEvents CounterIconsMd As ImageList
    Friend WithEvents CounterIconsSm As ImageList
    Friend WithEvents CounterIconsExLg As ImageList
    Friend WithEvents CounterIconsXXL As ImageList
    Friend WithEvents CustomIconsXXL As ImageList
    Friend WithEvents CustomIconsLg As ImageList
    Friend WithEvents lblVersion As Label
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
