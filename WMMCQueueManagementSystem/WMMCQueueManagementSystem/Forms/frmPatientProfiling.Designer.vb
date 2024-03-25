<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPatientProfiling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientProfiling))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbsex = New System.Windows.Forms.GroupBox()
        Me.sex_female = New System.Windows.Forms.RadioButton()
        Me.sex_male = New System.Windows.Forms.RadioButton()
        Me.gbcivilstatus = New System.Windows.Forms.GroupBox()
        Me.cs_widowed = New System.Windows.Forms.RadioButton()
        Me.cs_separated = New System.Windows.Forms.RadioButton()
        Me.cs_married = New System.Windows.Forms.RadioButton()
        Me.cs_single = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcontactno = New System.Windows.Forms.TextBox()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.ComboBox()
        Me.pnlOptionalSaving = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSkip = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlRequiredSaving = New System.Windows.Forms.Panel()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.btnSave2 = New System.Windows.Forms.Button()
        Me.lbnote = New System.Windows.Forms.Label()
        Me.txtbday_month = New System.Windows.Forms.TextBox()
        Me.txtbday_day = New System.Windows.Forms.TextBox()
        Me.txtbday_year = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtstreet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtbarangay = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcity = New System.Windows.Forms.TextBox()
        Me.pbProfilePicture = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.gbsex.SuspendLayout()
        Me.gbcivilstatus.SuspendLayout()
        Me.pnlOptionalSaving.SuspendLayout()
        Me.pnlRequiredSaving.SuspendLayout()
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1221, 60)
        Me.Panel1.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1221, 60)
        Me.lblTitle.TabIndex = 44
        Me.lblTitle.Text = "PLEASE ENTER PATIENT INFORMATION"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtmname
        '
        Me.txtmname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtmname.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtmname.Location = New System.Drawing.Point(292, 170)
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(270, 32)
        Me.txtmname.TabIndex = 3
        '
        'txtlname
        '
        Me.txtlname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtlname.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtlname.Location = New System.Drawing.Point(576, 170)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(272, 32)
        Me.txtlname.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(294, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "MIDDLE NAME"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(564, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 24)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "BIRTH DATE *"
        '
        'gbsex
        '
        Me.gbsex.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbsex.BackColor = System.Drawing.Color.Transparent
        Me.gbsex.Controls.Add(Me.sex_female)
        Me.gbsex.Controls.Add(Me.sex_male)
        Me.gbsex.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.gbsex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbsex.Location = New System.Drawing.Point(9, 231)
        Me.gbsex.Name = "gbsex"
        Me.gbsex.Size = New System.Drawing.Size(171, 158)
        Me.gbsex.TabIndex = 18
        Me.gbsex.TabStop = False
        Me.gbsex.Text = "SEX *"
        '
        'sex_female
        '
        Me.sex_female.AutoSize = True
        Me.sex_female.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.sex_female.Location = New System.Drawing.Point(31, 101)
        Me.sex_female.Name = "sex_female"
        Me.sex_female.Size = New System.Drawing.Size(114, 28)
        Me.sex_female.TabIndex = 7
        Me.sex_female.Text = "FEMALE"
        Me.sex_female.UseVisualStyleBackColor = True
        '
        'sex_male
        '
        Me.sex_male.AutoSize = True
        Me.sex_male.Checked = True
        Me.sex_male.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.sex_male.Location = New System.Drawing.Point(30, 38)
        Me.sex_male.Name = "sex_male"
        Me.sex_male.Size = New System.Drawing.Size(87, 28)
        Me.sex_male.TabIndex = 6
        Me.sex_male.TabStop = True
        Me.sex_male.Text = "MALE"
        Me.sex_male.UseVisualStyleBackColor = True
        '
        'gbcivilstatus
        '
        Me.gbcivilstatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbcivilstatus.BackColor = System.Drawing.Color.Transparent
        Me.gbcivilstatus.Controls.Add(Me.cs_widowed)
        Me.gbcivilstatus.Controls.Add(Me.cs_separated)
        Me.gbcivilstatus.Controls.Add(Me.cs_married)
        Me.gbcivilstatus.Controls.Add(Me.cs_single)
        Me.gbcivilstatus.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.gbcivilstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbcivilstatus.Location = New System.Drawing.Point(204, 234)
        Me.gbcivilstatus.Name = "gbcivilstatus"
        Me.gbcivilstatus.Size = New System.Drawing.Size(325, 155)
        Me.gbcivilstatus.TabIndex = 19
        Me.gbcivilstatus.TabStop = False
        Me.gbcivilstatus.Text = "CIVIL STATUS *"
        '
        'cs_widowed
        '
        Me.cs_widowed.AutoSize = True
        Me.cs_widowed.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.cs_widowed.Location = New System.Drawing.Point(166, 99)
        Me.cs_widowed.Name = "cs_widowed"
        Me.cs_widowed.Size = New System.Drawing.Size(135, 28)
        Me.cs_widowed.TabIndex = 5
        Me.cs_widowed.Text = "WIDOWED"
        Me.cs_widowed.UseVisualStyleBackColor = True
        '
        'cs_separated
        '
        Me.cs_separated.AutoSize = True
        Me.cs_separated.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.cs_separated.Location = New System.Drawing.Point(166, 36)
        Me.cs_separated.Name = "cs_separated"
        Me.cs_separated.Size = New System.Drawing.Size(153, 28)
        Me.cs_separated.TabIndex = 4
        Me.cs_separated.Text = "SEPARATED"
        Me.cs_separated.UseVisualStyleBackColor = True
        '
        'cs_married
        '
        Me.cs_married.AutoSize = True
        Me.cs_married.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.cs_married.Location = New System.Drawing.Point(19, 98)
        Me.cs_married.Name = "cs_married"
        Me.cs_married.Size = New System.Drawing.Size(124, 28)
        Me.cs_married.TabIndex = 3
        Me.cs_married.Text = "MARRIED"
        Me.cs_married.UseVisualStyleBackColor = True
        '
        'cs_single
        '
        Me.cs_single.AutoSize = True
        Me.cs_single.Checked = True
        Me.cs_single.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.cs_single.Location = New System.Drawing.Point(19, 35)
        Me.cs_single.Name = "cs_single"
        Me.cs_single.Size = New System.Drawing.Size(104, 28)
        Me.cs_single.TabIndex = 2
        Me.cs_single.TabStop = True
        Me.cs_single.Text = "SINGLE"
        Me.cs_single.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(565, 322)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 24)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "CONTACT NO."
        '
        'txtcontactno
        '
        Me.txtcontactno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcontactno.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtcontactno.Location = New System.Drawing.Point(562, 357)
        Me.txtcontactno.Name = "txtcontactno"
        Me.txtcontactno.Size = New System.Drawing.Size(416, 32)
        Me.txtcontactno.TabIndex = 21
        Me.txtcontactno.Text = "09"
        '
        'txtfname
        '
        Me.txtfname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtfname.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtfname.Location = New System.Drawing.Point(9, 170)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(270, 32)
        Me.txtfname.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "FIRST NAME *"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(578, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "LAST NAME *"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(869, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 24)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "SUFFIX"
        '
        'txtSuffix
        '
        Me.txtSuffix.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSuffix.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtSuffix.FormattingEnabled = True
        Me.txtSuffix.Items.AddRange(New Object() {"N/A", "SR", "JR", "I", "II", "III", "IV", "V", "VI"})
        Me.txtSuffix.Location = New System.Drawing.Point(866, 170)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(112, 32)
        Me.txtSuffix.TabIndex = 5
        '
        'pnlOptionalSaving
        '
        Me.pnlOptionalSaving.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlOptionalSaving.BackColor = System.Drawing.Color.Transparent
        Me.pnlOptionalSaving.Controls.Add(Me.btnCancel)
        Me.pnlOptionalSaving.Controls.Add(Me.btnSkip)
        Me.pnlOptionalSaving.Controls.Add(Me.btnSave)
        Me.pnlOptionalSaving.Location = New System.Drawing.Point(317, 498)
        Me.pnlOptionalSaving.Name = "pnlOptionalSaving"
        Me.pnlOptionalSaving.Size = New System.Drawing.Size(587, 112)
        Me.pnlOptionalSaving.TabIndex = 32
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Maroon
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(202, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(178, 40)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSkip
        '
        Me.btnSkip.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.btnSkip.FlatAppearance.BorderSize = 0
        Me.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSkip.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold)
        Me.btnSkip.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSkip.Location = New System.Drawing.Point(355, 9)
        Me.btnSkip.Name = "btnSkip"
        Me.btnSkip.Size = New System.Drawing.Size(186, 49)
        Me.btnSkip.TabIndex = 26
        Me.btnSkip.Text = "SKIP"
        Me.btnSkip.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(45, 9)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(304, 49)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "CONFIRM"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlRequiredSaving
        '
        Me.pnlRequiredSaving.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlRequiredSaving.BackColor = System.Drawing.Color.Transparent
        Me.pnlRequiredSaving.Controls.Add(Me.btnCancel2)
        Me.pnlRequiredSaving.Controls.Add(Me.btnSave2)
        Me.pnlRequiredSaving.Location = New System.Drawing.Point(317, 498)
        Me.pnlRequiredSaving.Name = "pnlRequiredSaving"
        Me.pnlRequiredSaving.Size = New System.Drawing.Size(587, 112)
        Me.pnlRequiredSaving.TabIndex = 33
        '
        'btnCancel2
        '
        Me.btnCancel2.BackColor = System.Drawing.Color.Maroon
        Me.btnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel2.Location = New System.Drawing.Point(157, 64)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(278, 40)
        Me.btnCancel2.TabIndex = 27
        Me.btnCancel2.Text = "CANCEL"
        Me.btnCancel2.UseVisualStyleBackColor = False
        '
        'btnSave2
        '
        Me.btnSave2.BackColor = System.Drawing.Color.Green
        Me.btnSave2.FlatAppearance.BorderSize = 0
        Me.btnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave2.Location = New System.Drawing.Point(157, 9)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(278, 49)
        Me.btnSave2.TabIndex = 25
        Me.btnSave2.Text = "CONFIRM"
        Me.btnSave2.UseVisualStyleBackColor = False
        '
        'lbnote
        '
        Me.lbnote.BackColor = System.Drawing.Color.Transparent
        Me.lbnote.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnote.ForeColor = System.Drawing.Color.Red
        Me.lbnote.Location = New System.Drawing.Point(9, 72)
        Me.lbnote.Name = "lbnote"
        Me.lbnote.Size = New System.Drawing.Size(731, 63)
        Me.lbnote.TabIndex = 34
        Me.lbnote.Text = "Note: Details that marked with * (asterisk) must be filled." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click any box or fie" &
    "ld to enter the details."
        '
        'txtbday_month
        '
        Me.txtbday_month.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbday_month.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtbday_month.Location = New System.Drawing.Point(562, 269)
        Me.txtbday_month.Name = "txtbday_month"
        Me.txtbday_month.ReadOnly = True
        Me.txtbday_month.Size = New System.Drawing.Size(194, 32)
        Me.txtbday_month.TabIndex = 35
        Me.txtbday_month.Text = "Click to Select"
        '
        'txtbday_day
        '
        Me.txtbday_day.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbday_day.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtbday_day.Location = New System.Drawing.Point(762, 268)
        Me.txtbday_day.Name = "txtbday_day"
        Me.txtbday_day.ReadOnly = True
        Me.txtbday_day.Size = New System.Drawing.Size(82, 32)
        Me.txtbday_day.TabIndex = 36
        Me.txtbday_day.Text = "Click to Select"
        '
        'txtbday_year
        '
        Me.txtbday_year.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbday_year.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtbday_year.Location = New System.Drawing.Point(850, 268)
        Me.txtbday_year.Name = "txtbday_year"
        Me.txtbday_year.ReadOnly = True
        Me.txtbday_year.Size = New System.Drawing.Size(128, 32)
        Me.txtbday_year.TabIndex = 37
        Me.txtbday_year.Text = "Click to Select"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(318, 407)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 24)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "STREET/DRIVE"
        '
        'txtstreet
        '
        Me.txtstreet.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtstreet.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtstreet.Location = New System.Drawing.Point(316, 442)
        Me.txtstreet.Name = "txtstreet"
        Me.txtstreet.Size = New System.Drawing.Size(301, 32)
        Me.txtstreet.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(626, 407)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 24)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "BARANGAY"
        '
        'txtbarangay
        '
        Me.txtbarangay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbarangay.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtbarangay.Location = New System.Drawing.Point(623, 442)
        Me.txtbarangay.Name = "txtbarangay"
        Me.txtbarangay.Size = New System.Drawing.Size(281, 32)
        Me.txtbarangay.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(913, 407)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(212, 24)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "CITY/MUNUCIPALITY"
        '
        'txtcity
        '
        Me.txtcity.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcity.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtcity.Location = New System.Drawing.Point(910, 442)
        Me.txtcity.Name = "txtcity"
        Me.txtcity.Size = New System.Drawing.Size(299, 32)
        Me.txtcity.TabIndex = 42
        '
        'pbProfilePicture
        '
        Me.pbProfilePicture.BackgroundImage = CType(resources.GetObject("pbProfilePicture.BackgroundImage"), System.Drawing.Image)
        Me.pbProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbProfilePicture.Location = New System.Drawing.Point(1008, 135)
        Me.pbProfilePicture.Name = "pbProfilePicture"
        Me.pbProfilePicture.Size = New System.Drawing.Size(201, 211)
        Me.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbProfilePicture.TabIndex = 44
        Me.pbProfilePicture.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1008, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 41)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "TAKE A PICTURE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.txtEmail.Location = New System.Drawing.Point(8, 442)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(302, 32)
        Me.txtEmail.TabIndex = 46
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(11, 407)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 24)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "EMAIL"
        '
        'frmPatientProfiling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1221, 615)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pbProfilePicture)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtcity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtbarangay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtstreet)
        Me.Controls.Add(Me.txtbday_year)
        Me.Controls.Add(Me.txtbday_day)
        Me.Controls.Add(Me.txtbday_month)
        Me.Controls.Add(Me.lbnote)
        Me.Controls.Add(Me.pnlRequiredSaving)
        Me.Controls.Add(Me.pnlOptionalSaving)
        Me.Controls.Add(Me.txtSuffix)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtcontactno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gbcivilstatus)
        Me.Controls.Add(Me.gbsex)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlname)
        Me.Controls.Add(Me.txtmname)
        Me.Controls.Add(Me.txtfname)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPatientProfiling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.gbsex.ResumeLayout(False)
        Me.gbsex.PerformLayout()
        Me.gbcivilstatus.ResumeLayout(False)
        Me.gbcivilstatus.PerformLayout()
        Me.pnlOptionalSaving.ResumeLayout(False)
        Me.pnlRequiredSaving.ResumeLayout(False)
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtmname As TextBox
    Friend WithEvents txtlname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents gbsex As GroupBox
    Friend WithEvents sex_male As RadioButton
    Friend WithEvents gbcivilstatus As GroupBox
    Friend WithEvents sex_female As RadioButton
    Friend WithEvents cs_married As RadioButton
    Friend WithEvents cs_single As RadioButton
    Friend WithEvents cs_widowed As RadioButton
    Friend WithEvents cs_separated As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcontactno As TextBox
    Friend WithEvents txtfname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSuffix As ComboBox
    Friend WithEvents pnlOptionalSaving As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSkip As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlRequiredSaving As Panel
    Friend WithEvents btnCancel2 As Button
    Friend WithEvents btnSave2 As Button
    Friend WithEvents lbnote As Label
    Friend WithEvents txtbday_month As TextBox
    Friend WithEvents txtbday_day As TextBox
    Friend WithEvents txtbday_year As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtstreet As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtbarangay As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcity As TextBox
    Friend WithEvents pbProfilePicture As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label10 As Label
End Class
