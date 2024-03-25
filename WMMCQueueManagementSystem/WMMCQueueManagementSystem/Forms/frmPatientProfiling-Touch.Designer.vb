<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPatientProfiling_Touch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientProfiling_Touch))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.txtbday = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbsex = New System.Windows.Forms.GroupBox()
        Me.lblSelectedGender = New System.Windows.Forms.Label()
        Me.pbFemale = New System.Windows.Forms.PictureBox()
        Me.pbMale = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlConfirmation = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlNewProfile = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtSuffix = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnWidowed = New System.Windows.Forms.Button()
        Me.btnSeparated = New System.Windows.Forms.Button()
        Me.btnMarried = New System.Windows.Forms.Button()
        Me.btnSingle = New System.Windows.Forms.Button()
        Me.lblSelectedCivilStatus = New System.Windows.Forms.Label()
        Me.txtcontactno = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcountryofbirth = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnationality = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtidnum = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtidvaliduntil = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtidtype = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtstreet = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtbarangay = New System.Windows.Forms.TextBox()
        Me.txtprovince = New System.Windows.Forms.TextBox()
        Me.txtcitymun = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.gbsex.SuspendLayout()
        CType(Me.pbFemale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbMale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConfirmation.SuspendLayout()
        Me.pnlNewProfile.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(965, 60)
        Me.Panel1.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(965, 60)
        Me.lblTitle.TabIndex = 44
        Me.lblTitle.Text = "ENTER YOUR PERSONAL INFORMATION"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(543, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "LAST NAME"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(311, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 24)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "MIDDLE NAME"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "FIRST NAME"
        '
        'txtlname
        '
        Me.txtlname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtlname.BackColor = System.Drawing.Color.Ivory
        Me.txtlname.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtlname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtlname.Location = New System.Drawing.Point(543, 104)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(260, 35)
        Me.txtlname.TabIndex = 10
        '
        'txtmname
        '
        Me.txtmname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtmname.BackColor = System.Drawing.Color.Ivory
        Me.txtmname.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtmname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtmname.Location = New System.Drawing.Point(311, 104)
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(226, 35)
        Me.txtmname.TabIndex = 9
        '
        'txtfname
        '
        Me.txtfname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtfname.BackColor = System.Drawing.Color.Ivory
        Me.txtfname.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtfname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtfname.Location = New System.Drawing.Point(12, 104)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(293, 35)
        Me.txtfname.TabIndex = 8
        '
        'txtbday
        '
        Me.txtbday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbday.BackColor = System.Drawing.Color.Ivory
        Me.txtbday.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtbday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtbday.Location = New System.Drawing.Point(12, 183)
        Me.txtbday.Name = "txtbday"
        Me.txtbday.ReadOnly = True
        Me.txtbday.Size = New System.Drawing.Size(293, 35)
        Me.txtbday.TabIndex = 39
        Me.txtbday.Text = "Click to Select"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(12, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 24)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "BIRTH DATE"
        '
        'gbsex
        '
        Me.gbsex.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbsex.BackColor = System.Drawing.Color.Transparent
        Me.gbsex.Controls.Add(Me.lblSelectedGender)
        Me.gbsex.Controls.Add(Me.pbFemale)
        Me.gbsex.Controls.Add(Me.pbMale)
        Me.gbsex.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.gbsex.ForeColor = System.Drawing.Color.Gray
        Me.gbsex.Location = New System.Drawing.Point(313, 382)
        Me.gbsex.Name = "gbsex"
        Me.gbsex.Size = New System.Drawing.Size(228, 182)
        Me.gbsex.TabIndex = 40
        Me.gbsex.TabStop = False
        Me.gbsex.Text = "GENDER"
        '
        'lblSelectedGender
        '
        Me.lblSelectedGender.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedGender.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSelectedGender.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedGender.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblSelectedGender.Location = New System.Drawing.Point(3, 126)
        Me.lblSelectedGender.Name = "lblSelectedGender"
        Me.lblSelectedGender.Size = New System.Drawing.Size(222, 53)
        Me.lblSelectedGender.TabIndex = 45
        Me.lblSelectedGender.Text = "CLICK ABOVE TO SELECT"
        Me.lblSelectedGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbFemale
        '
        Me.pbFemale.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbFemale.BackColor = System.Drawing.Color.DarkGray
        Me.pbFemale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbFemale.Image = CType(resources.GetObject("pbFemale.Image"), System.Drawing.Image)
        Me.pbFemale.Location = New System.Drawing.Point(117, 34)
        Me.pbFemale.Name = "pbFemale"
        Me.pbFemale.Size = New System.Drawing.Size(68, 68)
        Me.pbFemale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFemale.TabIndex = 1
        Me.pbFemale.TabStop = False
        '
        'pbMale
        '
        Me.pbMale.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbMale.BackColor = System.Drawing.Color.DarkGray
        Me.pbMale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbMale.Image = CType(resources.GetObject("pbMale.Image"), System.Drawing.Image)
        Me.pbMale.Location = New System.Drawing.Point(43, 34)
        Me.pbMale.Name = "pbMale"
        Me.pbMale.Size = New System.Drawing.Size(68, 68)
        Me.pbMale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbMale.TabIndex = 0
        Me.pbMale.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(12, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 24)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "CONTACT NO."
        '
        'pnlConfirmation
        '
        Me.pnlConfirmation.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlConfirmation.Controls.Add(Me.Button1)
        Me.pnlConfirmation.Location = New System.Drawing.Point(223, 573)
        Me.pnlConfirmation.Name = "pnlConfirmation"
        Me.pnlConfirmation.Size = New System.Drawing.Size(518, 84)
        Me.pnlConfirmation.TabIndex = 45
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(90, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(339, 60)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "CONFIRM"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pnlNewProfile
        '
        Me.pnlNewProfile.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNewProfile.Controls.Add(Me.Button3)
        Me.pnlNewProfile.Controls.Add(Me.Button2)
        Me.pnlNewProfile.Location = New System.Drawing.Point(223, 573)
        Me.pnlNewProfile.Name = "pnlNewProfile"
        Me.pnlNewProfile.Size = New System.Drawing.Size(518, 84)
        Me.pnlNewProfile.TabIndex = 49
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(23, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(229, 60)
        Me.Button3.TabIndex = 45
        Me.Button3.Text = "CANCEL"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Location = New System.Drawing.Point(267, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(229, 60)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "CONFIRM"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtSuffix
        '
        Me.txtSuffix.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSuffix.BackColor = System.Drawing.Color.Ivory
        Me.txtSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtSuffix.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtSuffix.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtSuffix.FormattingEnabled = True
        Me.txtSuffix.Items.AddRange(New Object() {"N/A", "SR", "JR", "I", "II", "III", "IV", "V", "VI"})
        Me.txtSuffix.Location = New System.Drawing.Point(809, 104)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(144, 37)
        Me.txtSuffix.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(809, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 24)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "SUFFIX"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnWidowed)
        Me.GroupBox1.Controls.Add(Me.btnSeparated)
        Me.GroupBox1.Controls.Add(Me.btnMarried)
        Me.GroupBox1.Controls.Add(Me.btnSingle)
        Me.GroupBox1.Controls.Add(Me.lblSelectedCivilStatus)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gray
        Me.GroupBox1.Location = New System.Drawing.Point(12, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 182)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CIVIL STATUS"
        '
        'btnWidowed
        '
        Me.btnWidowed.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnWidowed.BackColor = System.Drawing.Color.DarkGray
        Me.btnWidowed.FlatAppearance.BorderSize = 0
        Me.btnWidowed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWidowed.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWidowed.ForeColor = System.Drawing.Color.White
        Me.btnWidowed.Location = New System.Drawing.Point(143, 89)
        Me.btnWidowed.Name = "btnWidowed"
        Me.btnWidowed.Size = New System.Drawing.Size(119, 39)
        Me.btnWidowed.TabIndex = 49
        Me.btnWidowed.Text = "WIDOWED"
        Me.btnWidowed.UseVisualStyleBackColor = False
        '
        'btnSeparated
        '
        Me.btnSeparated.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSeparated.BackColor = System.Drawing.Color.DarkGray
        Me.btnSeparated.FlatAppearance.BorderSize = 0
        Me.btnSeparated.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeparated.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeparated.ForeColor = System.Drawing.Color.White
        Me.btnSeparated.Location = New System.Drawing.Point(31, 89)
        Me.btnSeparated.Name = "btnSeparated"
        Me.btnSeparated.Size = New System.Drawing.Size(108, 39)
        Me.btnSeparated.TabIndex = 48
        Me.btnSeparated.Text = "SEPARATED"
        Me.btnSeparated.UseVisualStyleBackColor = False
        '
        'btnMarried
        '
        Me.btnMarried.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnMarried.BackColor = System.Drawing.Color.DarkGray
        Me.btnMarried.FlatAppearance.BorderSize = 0
        Me.btnMarried.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarried.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarried.ForeColor = System.Drawing.Color.White
        Me.btnMarried.Location = New System.Drawing.Point(143, 44)
        Me.btnMarried.Name = "btnMarried"
        Me.btnMarried.Size = New System.Drawing.Size(119, 39)
        Me.btnMarried.TabIndex = 47
        Me.btnMarried.Text = "MARRIED"
        Me.btnMarried.UseVisualStyleBackColor = False
        '
        'btnSingle
        '
        Me.btnSingle.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSingle.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSingle.FlatAppearance.BorderSize = 0
        Me.btnSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSingle.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSingle.ForeColor = System.Drawing.Color.White
        Me.btnSingle.Location = New System.Drawing.Point(31, 44)
        Me.btnSingle.Name = "btnSingle"
        Me.btnSingle.Size = New System.Drawing.Size(108, 39)
        Me.btnSingle.TabIndex = 46
        Me.btnSingle.Text = "SINGLE"
        Me.btnSingle.UseVisualStyleBackColor = False
        '
        'lblSelectedCivilStatus
        '
        Me.lblSelectedCivilStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedCivilStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSelectedCivilStatus.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedCivilStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblSelectedCivilStatus.Location = New System.Drawing.Point(3, 126)
        Me.lblSelectedCivilStatus.Name = "lblSelectedCivilStatus"
        Me.lblSelectedCivilStatus.Size = New System.Drawing.Size(287, 53)
        Me.lblSelectedCivilStatus.TabIndex = 45
        Me.lblSelectedCivilStatus.Text = "CLICK ABOVE TO SELECT"
        Me.lblSelectedCivilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontactno
        '
        Me.txtcontactno.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcontactno.BackColor = System.Drawing.Color.Ivory
        Me.txtcontactno.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtcontactno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtcontactno.Location = New System.Drawing.Point(12, 262)
        Me.txtcontactno.Name = "txtcontactno"
        Me.txtcontactno.Size = New System.Drawing.Size(293, 35)
        Me.txtcontactno.TabIndex = 44
        Me.txtcontactno.Text = "09"
        '
        'txtemail
        '
        Me.txtemail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtemail.BackColor = System.Drawing.Color.Ivory
        Me.txtemail.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtemail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtemail.Location = New System.Drawing.Point(12, 341)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(293, 35)
        Me.txtemail.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(12, 307)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 24)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "EMAIL"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(311, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(212, 24)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "COUNTRY OF BIRTH"
        '
        'txtcountryofbirth
        '
        Me.txtcountryofbirth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcountryofbirth.BackColor = System.Drawing.Color.Ivory
        Me.txtcountryofbirth.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtcountryofbirth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtcountryofbirth.Location = New System.Drawing.Point(311, 183)
        Me.txtcountryofbirth.Name = "txtcountryofbirth"
        Me.txtcountryofbirth.Size = New System.Drawing.Size(288, 35)
        Me.txtcountryofbirth.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(311, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 24)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "PROVINCE"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(311, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(196, 24)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "CITY/MINICIPALITY"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(609, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 24)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "NATIONALITY"
        '
        'txtnationality
        '
        Me.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtnationality.BackColor = System.Drawing.Color.Ivory
        Me.txtnationality.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtnationality.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtnationality.Location = New System.Drawing.Point(609, 183)
        Me.txtnationality.Name = "txtnationality"
        Me.txtnationality.Size = New System.Drawing.Size(344, 35)
        Me.txtnationality.TabIndex = 58
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtidnum)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtidvaliduntil)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtidtype)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gray
        Me.GroupBox2.Location = New System.Drawing.Point(547, 382)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 182)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IDENTIFICATION"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label14.ForeColor = System.Drawing.Color.Gray
        Me.Label14.Location = New System.Drawing.Point(202, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 24)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "ID NUMBER"
        '
        'txtidnum
        '
        Me.txtidnum.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtidnum.BackColor = System.Drawing.Color.Ivory
        Me.txtidnum.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtidnum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtidnum.Location = New System.Drawing.Point(202, 65)
        Me.txtidnum.Name = "txtidnum"
        Me.txtidnum.Size = New System.Drawing.Size(184, 35)
        Me.txtidnum.TabIndex = 60
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label13.ForeColor = System.Drawing.Color.Gray
        Me.Label13.Location = New System.Drawing.Point(12, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 24)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "VALID UNTIL"
        '
        'txtidvaliduntil
        '
        Me.txtidvaliduntil.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtidvaliduntil.BackColor = System.Drawing.Color.Ivory
        Me.txtidvaliduntil.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtidvaliduntil.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtidvaliduntil.Location = New System.Drawing.Point(12, 140)
        Me.txtidvaliduntil.Name = "txtidvaliduntil"
        Me.txtidvaliduntil.Size = New System.Drawing.Size(184, 35)
        Me.txtidvaliduntil.TabIndex = 58
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label12.ForeColor = System.Drawing.Color.Gray
        Me.Label12.Location = New System.Drawing.Point(12, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 24)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "ID TYPE"
        '
        'txtidtype
        '
        Me.txtidtype.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtidtype.BackColor = System.Drawing.Color.Ivory
        Me.txtidtype.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtidtype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtidtype.Location = New System.Drawing.Point(12, 65)
        Me.txtidtype.Name = "txtidtype"
        Me.txtidtype.Size = New System.Drawing.Size(184, 35)
        Me.txtidtype.TabIndex = 56
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(609, 230)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 24)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "BARANGAY"
        '
        'txtstreet
        '
        Me.txtstreet.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtstreet.BackColor = System.Drawing.Color.Ivory
        Me.txtstreet.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtstreet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtstreet.Location = New System.Drawing.Point(609, 341)
        Me.txtstreet.Name = "txtstreet"
        Me.txtstreet.Size = New System.Drawing.Size(344, 35)
        Me.txtstreet.TabIndex = 64
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Label16.ForeColor = System.Drawing.Color.Gray
        Me.Label16.Location = New System.Drawing.Point(609, 307)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(293, 24)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "PUROK/STREET/LOT/BLOCK"
        '
        'txtbarangay
        '
        Me.txtbarangay.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtbarangay.BackColor = System.Drawing.Color.Ivory
        Me.txtbarangay.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtbarangay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtbarangay.Location = New System.Drawing.Point(609, 262)
        Me.txtbarangay.Name = "txtbarangay"
        Me.txtbarangay.Size = New System.Drawing.Size(344, 35)
        Me.txtbarangay.TabIndex = 66
        '
        'txtprovince
        '
        Me.txtprovince.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtprovince.BackColor = System.Drawing.Color.Ivory
        Me.txtprovince.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtprovince.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtprovince.Location = New System.Drawing.Point(311, 262)
        Me.txtprovince.Name = "txtprovince"
        Me.txtprovince.Size = New System.Drawing.Size(288, 35)
        Me.txtprovince.TabIndex = 67
        '
        'txtcitymun
        '
        Me.txtcitymun.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtcitymun.BackColor = System.Drawing.Color.Ivory
        Me.txtcitymun.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtcitymun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.txtcitymun.Location = New System.Drawing.Point(311, 341)
        Me.txtcitymun.Name = "txtcitymun"
        Me.txtcitymun.Size = New System.Drawing.Size(288, 35)
        Me.txtcitymun.TabIndex = 68
        '
        'frmPatientProfiling_Touch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(965, 669)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtcitymun)
        Me.Controls.Add(Me.txtprovince)
        Me.Controls.Add(Me.txtbarangay)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtstreet)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtnationality)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gbsex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcountryofbirth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlNewProfile)
        Me.Controls.Add(Me.txtSuffix)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pnlConfirmation)
        Me.Controls.Add(Me.txtcontactno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtbday)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlname)
        Me.Controls.Add(Me.txtmname)
        Me.Controls.Add(Me.txtfname)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPatientProfiling_Touch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.gbsex.ResumeLayout(False)
        CType(Me.pbFemale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbMale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConfirmation.ResumeLayout(False)
        Me.pnlNewProfile.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtlname As TextBox
    Friend WithEvents txtmname As TextBox
    Friend WithEvents txtfname As TextBox
    Friend WithEvents txtbday As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents gbsex As GroupBox
    Friend WithEvents pbFemale As PictureBox
    Friend WithEvents pbMale As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSelectedGender As Label
    Friend WithEvents pnlConfirmation As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents txtSuffix As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlNewProfile As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSelectedCivilStatus As Label
    Friend WithEvents btnWidowed As Button
    Friend WithEvents btnSeparated As Button
    Friend WithEvents btnMarried As Button
    Friend WithEvents btnSingle As Button
    Friend WithEvents txtcontactno As TextBox
    Friend WithEvents txtemail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtcountryofbirth As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtnationality As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtidnum As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtidvaliduntil As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtidtype As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtstreet As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtbarangay As TextBox
    Friend WithEvents txtprovince As TextBox
    Friend WithEvents txtcitymun As TextBox
End Class
