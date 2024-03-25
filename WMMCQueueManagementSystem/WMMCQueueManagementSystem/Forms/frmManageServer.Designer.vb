<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageServer))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtUname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtEmpID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtAssignDept = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtMiddleInit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.gbDoctors = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbDoctor = New System.Windows.Forms.RadioButton()
        Me.rbPccAccount = New System.Windows.Forms.RadioButton()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.txts2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSync = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblPhysicianID = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblPTR = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblPRC = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblSpecialization = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbDoctors.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lblTittle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(871, 51)
        Me.Panel1.TabIndex = 17
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(871, 51)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "Manage Users"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Panel8)
        Me.GroupBox1.Controls.Add(Me.Panel7)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(852, 69)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Information"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(812, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.txtPass)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Location = New System.Drawing.Point(416, 23)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(390, 30)
        Me.Panel8.TabIndex = 43
        '
        'txtPass
        '
        Me.txtPass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtPass.Location = New System.Drawing.Point(115, 0)
        Me.txtPass.Multiline = True
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(273, 28)
        Me.txtPass.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Honeydew
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 28)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "PASSWORD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.txtUname)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Location = New System.Drawing.Point(10, 23)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(400, 30)
        Me.Panel7.TabIndex = 42
        '
        'txtUname
        '
        Me.txtUname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtUname.Location = New System.Drawing.Point(97, 0)
        Me.txtUname.Multiline = True
        Me.txtUname.Name = "txtUname"
        Me.txtUname.Size = New System.Drawing.Size(301, 28)
        Me.txtUname.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Honeydew
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 28)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "USER NAME"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.txtEmpID)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Location = New System.Drawing.Point(10, 26)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(350, 30)
        Me.Panel5.TabIndex = 41
        '
        'txtEmpID
        '
        Me.txtEmpID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmpID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpID.Location = New System.Drawing.Point(92, 0)
        Me.txtEmpID.Multiline = True
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Size = New System.Drawing.Size(256, 28)
        Me.txtEmpID.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Honeydew
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 28)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "USER ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtAssignDept)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(366, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(480, 30)
        Me.Panel2.TabIndex = 42
        '
        'txtAssignDept
        '
        Me.txtAssignDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAssignDept.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtAssignDept.Location = New System.Drawing.Point(155, 0)
        Me.txtAssignDept.Multiline = True
        Me.txtAssignDept.Name = "txtAssignDept"
        Me.txtAssignDept.Size = New System.Drawing.Size(323, 28)
        Me.txtAssignDept.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Honeydew
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 28)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "ASSIGN DEPARTMENT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtLastName)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(10, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(320, 30)
        Me.Panel3.TabIndex = 43
        '
        'txtLastName
        '
        Me.txtLastName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtLastName.Location = New System.Drawing.Point(92, 0)
        Me.txtLastName.Multiline = True
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(226, 28)
        Me.txtLastName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Honeydew
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 28)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "LAST NAME"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtFirstName)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(336, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(287, 30)
        Me.Panel4.TabIndex = 44
        '
        'txtFirstName
        '
        Me.txtFirstName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtFirstName.Location = New System.Drawing.Point(92, 0)
        Me.txtFirstName.Multiline = True
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(193, 28)
        Me.txtFirstName.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Honeydew
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 28)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "FIRST NAME"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.txtMiddleInit)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Location = New System.Drawing.Point(629, 62)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(217, 30)
        Me.Panel6.TabIndex = 45
        '
        'txtMiddleInit
        '
        Me.txtMiddleInit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMiddleInit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtMiddleInit.Location = New System.Drawing.Point(111, 0)
        Me.txtMiddleInit.Multiline = True
        Me.txtMiddleInit.Name = "txtMiddleInit"
        Me.txtMiddleInit.Size = New System.Drawing.Size(104, 28)
        Me.txtMiddleInit.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Honeydew
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 28)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "MIDDLE NAME"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(852, 110)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "User's Information"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Maroon
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(438, 451)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(178, 37)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'gbDoctors
        '
        Me.gbDoctors.BackColor = System.Drawing.Color.Transparent
        Me.gbDoctors.Controls.Add(Me.GroupBox3)
        Me.gbDoctors.Controls.Add(Me.Panel13)
        Me.gbDoctors.Controls.Add(Me.btnSync)
        Me.gbDoctors.Controls.Add(Me.Panel12)
        Me.gbDoctors.Controls.Add(Me.Panel11)
        Me.gbDoctors.Controls.Add(Me.Panel9)
        Me.gbDoctors.Controls.Add(Me.Panel10)
        Me.gbDoctors.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.gbDoctors.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbDoctors.Location = New System.Drawing.Point(9, 248)
        Me.gbDoctors.Name = "gbDoctors"
        Me.gbDoctors.Size = New System.Drawing.Size(852, 190)
        Me.gbDoctors.TabIndex = 44
        Me.gbDoctors.TabStop = False
        Me.gbDoctors.Text = "Doctor's Detail (Only for Doctors)"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rbDoctor)
        Me.GroupBox3.Controls.Add(Me.rbPccAccount)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(185, 102)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account Type"
        '
        'rbDoctor
        '
        Me.rbDoctor.AutoSize = True
        Me.rbDoctor.Location = New System.Drawing.Point(15, 59)
        Me.rbDoctor.Name = "rbDoctor"
        Me.rbDoctor.Size = New System.Drawing.Size(130, 20)
        Me.rbDoctor.TabIndex = 3
        Me.rbDoctor.Text = "Doctor/Consultant"
        Me.rbDoctor.UseVisualStyleBackColor = True
        '
        'rbPccAccount
        '
        Me.rbPccAccount.AutoSize = True
        Me.rbPccAccount.Checked = True
        Me.rbPccAccount.Location = New System.Drawing.Point(15, 28)
        Me.rbPccAccount.Name = "rbPccAccount"
        Me.rbPccAccount.Size = New System.Drawing.Size(148, 20)
        Me.rbPccAccount.TabIndex = 0
        Me.rbPccAccount.TabStop = True
        Me.rbPccAccount.Text = "PCC Service Counter"
        Me.rbPccAccount.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.txts2)
        Me.Panel13.Controls.Add(Me.Label12)
        Me.Panel13.Location = New System.Drawing.Point(211, 142)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(627, 30)
        Me.Panel13.TabIndex = 45
        '
        'txts2
        '
        Me.txts2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txts2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txts2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txts2.Location = New System.Drawing.Point(120, 0)
        Me.txts2.Multiline = True
        Me.txts2.Name = "txts2"
        Me.txts2.ReadOnly = True
        Me.txts2.Size = New System.Drawing.Size(505, 28)
        Me.txts2.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Honeydew
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 28)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "S2 LICENSE"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSync
        '
        Me.btnSync.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSync.FlatAppearance.BorderSize = 0
        Me.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSync.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSync.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSync.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSync.Location = New System.Drawing.Point(635, 34)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(203, 30)
        Me.btnSync.TabIndex = 46
        Me.btnSync.Text = "SYNC DATA FROM BIZBOX"
        Me.btnSync.UseVisualStyleBackColor = False
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.lblPhysicianID)
        Me.Panel12.Controls.Add(Me.Label10)
        Me.Panel12.Location = New System.Drawing.Point(211, 34)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(412, 30)
        Me.Panel12.TabIndex = 45
        '
        'lblPhysicianID
        '
        Me.lblPhysicianID.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPhysicianID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPhysicianID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPhysicianID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPhysicianID.ForeColor = System.Drawing.Color.Green
        Me.lblPhysicianID.Location = New System.Drawing.Point(206, 0)
        Me.lblPhysicianID.Name = "lblPhysicianID"
        Me.lblPhysicianID.Size = New System.Drawing.Size(206, 30)
        Me.lblPhysicianID.TabIndex = 29
        Me.lblPhysicianID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Honeydew
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(206, 30)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "PHYSICIAN ID FROM BIZBOX:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblPTR)
        Me.Panel11.Controls.Add(Me.Label9)
        Me.Panel11.Location = New System.Drawing.Point(509, 106)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(329, 30)
        Me.Panel11.TabIndex = 44
        '
        'lblPTR
        '
        Me.lblPTR.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPTR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPTR.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPTR.Location = New System.Drawing.Point(112, 0)
        Me.lblPTR.Multiline = True
        Me.lblPTR.Name = "lblPTR"
        Me.lblPTR.ReadOnly = True
        Me.lblPTR.Size = New System.Drawing.Size(215, 28)
        Me.lblPTR.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Honeydew
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 28)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "PTR NUMBER"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel9
        '
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.lblPRC)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Location = New System.Drawing.Point(211, 106)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(293, 30)
        Me.Panel9.TabIndex = 43
        '
        'lblPRC
        '
        Me.lblPRC.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPRC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPRC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPRC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPRC.ForeColor = System.Drawing.Color.Green
        Me.lblPRC.Location = New System.Drawing.Point(120, 0)
        Me.lblPRC.Name = "lblPRC"
        Me.lblPRC.Size = New System.Drawing.Size(171, 28)
        Me.lblPRC.TabIndex = 30
        Me.lblPRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Honeydew
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 28)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "PCR NUMBER"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.lblSpecialization)
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Location = New System.Drawing.Point(211, 70)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(412, 30)
        Me.Panel10.TabIndex = 42
        '
        'lblSpecialization
        '
        Me.lblSpecialization.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblSpecialization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpecialization.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSpecialization.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblSpecialization.ForeColor = System.Drawing.Color.Green
        Me.lblSpecialization.Location = New System.Drawing.Point(120, 0)
        Me.lblSpecialization.Name = "lblSpecialization"
        Me.lblSpecialization.Size = New System.Drawing.Size(290, 28)
        Me.lblSpecialization.TabIndex = 30
        Me.lblSpecialization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Honeydew
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 28)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "SPECIALIZATION"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(252, 451)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(178, 37)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnUpdate.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(254, 451)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(178, 37)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "SAVE CHANGES"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'frmManageServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(871, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbDoctors)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.gbDoctors.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTittle As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtUname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtEmpID As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtAssignDept As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtMiddleInit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents gbDoctors As GroupBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSync As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents lblPhysicianID As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSpecialization As Label
    Friend WithEvents lblPRC As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbPccAccount As RadioButton
    Friend WithEvents btnSave As Button
    Friend WithEvents rbDoctor As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblPTR As TextBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents txts2 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnUpdate As Button
End Class
