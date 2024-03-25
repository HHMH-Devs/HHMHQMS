<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageCounters
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageCounters))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.ComboBox()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.txtServiceDescription = New System.Windows.Forms.RichTextBox()
        Me.txtCounterCode = New System.Windows.Forms.TextBox()
        Me.txtCounterPrefix = New System.Windows.Forms.MaskedTextBox()
        Me.btnBrowseIcon = New System.Windows.Forms.Button()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbSoloQueue = New System.Windows.Forms.CheckBox()
        Me.cbForTransferOnly = New System.Windows.Forms.CheckBox()
        Me.rbQueueCounter = New System.Windows.Forms.RadioButton()
        Me.rbMainCounter = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClearIcon = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lblBestVal = New System.Windows.Forms.Label()
        Me.lblMidVal = New System.Windows.Forms.Label()
        Me.lblWorstVal = New System.Windows.Forms.Label()
        Me.nudAllowableTurnarroundTime = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbERConsultation = New System.Windows.Forms.CheckBox()
        Me.cbMakeInitialConsultation = New System.Windows.Forms.CheckBox()
        Me.cbManageConsultation = New System.Windows.Forms.CheckBox()
        Me.cbViewConsultation = New System.Windows.Forms.CheckBox()
        Me.cbViewPrescription = New System.Windows.Forms.CheckBox()
        Me.cbManagePrescription = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbSyncProfileWithBizbox = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbAutoAncillaryLab = New System.Windows.Forms.CheckBox()
        Me.cbAutoCashierPhic = New System.Windows.Forms.CheckBox()
        Me.cbAutoHMO = New System.Windows.Forms.CheckBox()
        Me.cbAutoCashier = New System.Windows.Forms.CheckBox()
        Me.cbAutoPrescription = New System.Windows.Forms.CheckBox()
        Me.cbAutoDiagnostics = New System.Windows.Forms.CheckBox()
        Me.cbAutoScreening = New System.Windows.Forms.CheckBox()
        Me.cbViewDiagnostics = New System.Windows.Forms.CheckBox()
        Me.cbManageDiagnostics = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.cbManageHealthcheck = New System.Windows.Forms.CheckBox()
        Me.cbViewHealthcheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cbHealee = New System.Windows.Forms.CheckBox()
        Me.cbEkonsulta = New System.Windows.Forms.CheckBox()
        Me.cbAutoAncillaryRad = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAllowableTurnarroundTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdate.Location = New System.Drawing.Point(13, 655)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(756, 54)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "SAVE CHANGES"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lblTittle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 59)
        Me.Panel1.TabIndex = 16
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(784, 59)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "Manage Counter"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDepartment
        '
        Me.txtDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.FormattingEnabled = True
        Me.txtDepartment.Location = New System.Drawing.Point(12, 93)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(178, 24)
        Me.txtDepartment.TabIndex = 0
        '
        'txtSection
        '
        Me.txtSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSection.Location = New System.Drawing.Point(196, 95)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(189, 22)
        Me.txtSection.TabIndex = 1
        '
        'txtServiceDescription
        '
        Me.txtServiceDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceDescription.Location = New System.Drawing.Point(12, 146)
        Me.txtServiceDescription.Name = "txtServiceDescription"
        Me.txtServiceDescription.Size = New System.Drawing.Size(373, 54)
        Me.txtServiceDescription.TabIndex = 2
        Me.txtServiceDescription.Text = ""
        '
        'txtCounterCode
        '
        Me.txtCounterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounterCode.Location = New System.Drawing.Point(391, 95)
        Me.txtCounterCode.MaxLength = 5
        Me.txtCounterCode.Name = "txtCounterCode"
        Me.txtCounterCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCounterCode.Size = New System.Drawing.Size(157, 22)
        Me.txtCounterCode.TabIndex = 4
        Me.txtCounterCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCounterPrefix
        '
        Me.txtCounterPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounterPrefix.Location = New System.Drawing.Point(391, 144)
        Me.txtCounterPrefix.Mask = "A A A A"
        Me.txtCounterPrefix.Name = "txtCounterPrefix"
        Me.txtCounterPrefix.Size = New System.Drawing.Size(157, 22)
        Me.txtCounterPrefix.TabIndex = 3
        Me.txtCounterPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBrowseIcon
        '
        Me.btnBrowseIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseIcon.BackColor = System.Drawing.Color.LimeGreen
        Me.btnBrowseIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseIcon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseIcon.ForeColor = System.Drawing.Color.White
        Me.btnBrowseIcon.Location = New System.Drawing.Point(565, 240)
        Me.btnBrowseIcon.Name = "btnBrowseIcon"
        Me.btnBrowseIcon.Padding = New System.Windows.Forms.Padding(70, 0, 0, 0)
        Me.btnBrowseIcon.Size = New System.Drawing.Size(207, 44)
        Me.btnBrowseIcon.TabIndex = 6
        Me.btnBrowseIcon.Text = "Browse"
        Me.btnBrowseIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBrowseIcon.UseVisualStyleBackColor = False
        '
        'pbIcon
        '
        Me.pbIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbIcon.Location = New System.Drawing.Point(565, 71)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(207, 163)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIcon.TabIndex = 24
        Me.pbIcon.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cbSoloQueue)
        Me.GroupBox1.Controls.Add(Me.cbForTransferOnly)
        Me.GroupBox1.Controls.Add(Me.rbQueueCounter)
        Me.GroupBox1.Controls.Add(Me.rbMainCounter)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 144)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "COUNTER TYPE"
        '
        'cbSoloQueue
        '
        Me.cbSoloQueue.ForeColor = System.Drawing.Color.Black
        Me.cbSoloQueue.Location = New System.Drawing.Point(8, 85)
        Me.cbSoloQueue.Name = "cbSoloQueue"
        Me.cbSoloQueue.Size = New System.Drawing.Size(167, 25)
        Me.cbSoloQueue.TabIndex = 37
        Me.cbSoloQueue.Text = "Solo Queue Counter"
        Me.cbSoloQueue.UseVisualStyleBackColor = True
        '
        'cbForTransferOnly
        '
        Me.cbForTransferOnly.ForeColor = System.Drawing.Color.Red
        Me.cbForTransferOnly.Location = New System.Drawing.Point(8, 115)
        Me.cbForTransferOnly.Name = "cbForTransferOnly"
        Me.cbForTransferOnly.Size = New System.Drawing.Size(170, 25)
        Me.cbForTransferOnly.TabIndex = 36
        Me.cbForTransferOnly.Text = "Don't Display on Patient"
        Me.cbForTransferOnly.UseVisualStyleBackColor = True
        '
        'rbQueueCounter
        '
        Me.rbQueueCounter.Checked = True
        Me.rbQueueCounter.ForeColor = System.Drawing.Color.Black
        Me.rbQueueCounter.Location = New System.Drawing.Point(8, 50)
        Me.rbQueueCounter.Name = "rbQueueCounter"
        Me.rbQueueCounter.Size = New System.Drawing.Size(167, 20)
        Me.rbQueueCounter.TabIndex = 1
        Me.rbQueueCounter.TabStop = True
        Me.rbQueueCounter.Text = "Service Counters" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rbQueueCounter.UseVisualStyleBackColor = True
        '
        'rbMainCounter
        '
        Me.rbMainCounter.ForeColor = System.Drawing.Color.Black
        Me.rbMainCounter.Location = New System.Drawing.Point(8, 23)
        Me.rbMainCounter.Name = "rbMainCounter"
        Me.rbMainCounter.Size = New System.Drawing.Size(167, 20)
        Me.rbMainCounter.TabIndex = 0
        Me.rbMainCounter.Text = "Self Service Counter"
        Me.rbMainCounter.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(12, 655)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(757, 54)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClearIcon
        '
        Me.btnClearIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearIcon.BackColor = System.Drawing.Color.Maroon
        Me.btnClearIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearIcon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearIcon.ForeColor = System.Drawing.Color.White
        Me.btnClearIcon.Location = New System.Drawing.Point(565, 285)
        Me.btnClearIcon.Name = "btnClearIcon"
        Me.btnClearIcon.Padding = New System.Windows.Forms.Padding(70, 0, 0, 0)
        Me.btnClearIcon.Size = New System.Drawing.Size(207, 44)
        Me.btnClearIcon.TabIndex = 26
        Me.btnClearIcon.Text = "Clear Icon"
        Me.btnClearIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearIcon.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "DEFAULT COUNTER NAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(200, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "SECTION"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "DEPARTMENT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(394, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "PREFIX"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(394, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "COUNTER PASSWORD"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(574, 290)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox3.TabIndex = 32
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(574, 245)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBox2.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(18, 659)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(47, 45)
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(565, 335)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(46, 42)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 1
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(565, 383)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(46, 42)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 2
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(565, 431)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(46, 42)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 3
        Me.PictureBox6.TabStop = False
        '
        'lblBestVal
        '
        Me.lblBestVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBestVal.BackColor = System.Drawing.Color.Transparent
        Me.lblBestVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBestVal.Location = New System.Drawing.Point(617, 335)
        Me.lblBestVal.Name = "lblBestVal"
        Me.lblBestVal.Size = New System.Drawing.Size(152, 42)
        Me.lblBestVal.TabIndex = 32
        Me.lblBestVal.Text = "Mins"
        Me.lblBestVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMidVal
        '
        Me.lblMidVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMidVal.BackColor = System.Drawing.Color.Transparent
        Me.lblMidVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMidVal.Location = New System.Drawing.Point(617, 383)
        Me.lblMidVal.Name = "lblMidVal"
        Me.lblMidVal.Size = New System.Drawing.Size(152, 42)
        Me.lblMidVal.TabIndex = 36
        Me.lblMidVal.Text = "Min/s"
        Me.lblMidVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorstVal
        '
        Me.lblWorstVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWorstVal.BackColor = System.Drawing.Color.Transparent
        Me.lblWorstVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorstVal.Location = New System.Drawing.Point(617, 431)
        Me.lblWorstVal.Name = "lblWorstVal"
        Me.lblWorstVal.Size = New System.Drawing.Size(152, 42)
        Me.lblWorstVal.TabIndex = 37
        Me.lblWorstVal.Text = "Min/s"
        Me.lblWorstVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudAllowableTurnarroundTime
        '
        Me.nudAllowableTurnarroundTime.Dock = System.Windows.Forms.DockStyle.Left
        Me.nudAllowableTurnarroundTime.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudAllowableTurnarroundTime.Location = New System.Drawing.Point(3, 18)
        Me.nudAllowableTurnarroundTime.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudAllowableTurnarroundTime.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudAllowableTurnarroundTime.Name = "nudAllowableTurnarroundTime"
        Me.nudAllowableTurnarroundTime.Size = New System.Drawing.Size(208, 22)
        Me.nudAllowableTurnarroundTime.TabIndex = 0
        Me.nudAllowableTurnarroundTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudAllowableTurnarroundTime.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(217, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Min/s"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.nudAllowableTurnarroundTime)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 359)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 54)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TURNAROUND TIME"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.cbERConsultation)
        Me.GroupBox5.Controls.Add(Me.cbMakeInitialConsultation)
        Me.GroupBox5.Controls.Add(Me.cbManageConsultation)
        Me.GroupBox5.Controls.Add(Me.cbViewConsultation)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(13, 419)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(247, 159)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CONSULTATION"
        '
        'cbERConsultation
        '
        Me.cbERConsultation.ForeColor = System.Drawing.Color.Black
        Me.cbERConsultation.Location = New System.Drawing.Point(9, 120)
        Me.cbERConsultation.Name = "cbERConsultation"
        Me.cbERConsultation.Size = New System.Drawing.Size(223, 27)
        Me.cbERConsultation.TabIndex = 40
        Me.cbERConsultation.Text = "ER Consultation"
        Me.cbERConsultation.UseVisualStyleBackColor = True
        '
        'cbMakeInitialConsultation
        '
        Me.cbMakeInitialConsultation.ForeColor = System.Drawing.Color.Black
        Me.cbMakeInitialConsultation.Location = New System.Drawing.Point(9, 87)
        Me.cbMakeInitialConsultation.Name = "cbMakeInitialConsultation"
        Me.cbMakeInitialConsultation.Size = New System.Drawing.Size(223, 27)
        Me.cbMakeInitialConsultation.TabIndex = 39
        Me.cbMakeInitialConsultation.Text = "Make Initial Consultation"
        Me.cbMakeInitialConsultation.UseVisualStyleBackColor = True
        '
        'cbManageConsultation
        '
        Me.cbManageConsultation.ForeColor = System.Drawing.Color.Black
        Me.cbManageConsultation.Location = New System.Drawing.Point(9, 54)
        Me.cbManageConsultation.Name = "cbManageConsultation"
        Me.cbManageConsultation.Size = New System.Drawing.Size(223, 27)
        Me.cbManageConsultation.TabIndex = 38
        Me.cbManageConsultation.Text = "Create/Edit Consultation"
        Me.cbManageConsultation.UseVisualStyleBackColor = True
        '
        'cbViewConsultation
        '
        Me.cbViewConsultation.ForeColor = System.Drawing.Color.Black
        Me.cbViewConsultation.Location = New System.Drawing.Point(9, 21)
        Me.cbViewConsultation.Name = "cbViewConsultation"
        Me.cbViewConsultation.Size = New System.Drawing.Size(223, 27)
        Me.cbViewConsultation.TabIndex = 37
        Me.cbViewConsultation.Text = "View Consultation"
        Me.cbViewConsultation.UseVisualStyleBackColor = True
        '
        'cbViewPrescription
        '
        Me.cbViewPrescription.ForeColor = System.Drawing.Color.Black
        Me.cbViewPrescription.Location = New System.Drawing.Point(9, 21)
        Me.cbViewPrescription.Name = "cbViewPrescription"
        Me.cbViewPrescription.Size = New System.Drawing.Size(256, 27)
        Me.cbViewPrescription.TabIndex = 37
        Me.cbViewPrescription.Text = "View Prescription"
        Me.cbViewPrescription.UseVisualStyleBackColor = True
        '
        'cbManagePrescription
        '
        Me.cbManagePrescription.ForeColor = System.Drawing.Color.Black
        Me.cbManagePrescription.Location = New System.Drawing.Point(9, 54)
        Me.cbManagePrescription.Name = "cbManagePrescription"
        Me.cbManagePrescription.Size = New System.Drawing.Size(256, 27)
        Me.cbManagePrescription.TabIndex = 38
        Me.cbManagePrescription.Text = "Create/Edit Prescription"
        Me.cbManagePrescription.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cbManagePrescription)
        Me.GroupBox4.Controls.Add(Me.cbViewPrescription)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(270, 562)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(278, 87)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "E-PRESCRIPTION"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cbSyncProfileWithBizbox)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(12, 584)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 65)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PROFILE MANAGEMENT"
        '
        'cbSyncProfileWithBizbox
        '
        Me.cbSyncProfileWithBizbox.ForeColor = System.Drawing.Color.Black
        Me.cbSyncProfileWithBizbox.Location = New System.Drawing.Point(10, 24)
        Me.cbSyncProfileWithBizbox.Name = "cbSyncProfileWithBizbox"
        Me.cbSyncProfileWithBizbox.Size = New System.Drawing.Size(202, 27)
        Me.cbSyncProfileWithBizbox.TabIndex = 38
        Me.cbSyncProfileWithBizbox.Text = "Sync Profile with Bizbox"
        Me.cbSyncProfileWithBizbox.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.cbAutoAncillaryRad)
        Me.GroupBox7.Controls.Add(Me.cbAutoAncillaryLab)
        Me.GroupBox7.Controls.Add(Me.cbAutoCashierPhic)
        Me.GroupBox7.Controls.Add(Me.cbAutoHMO)
        Me.GroupBox7.Controls.Add(Me.cbAutoCashier)
        Me.GroupBox7.Controls.Add(Me.cbAutoPrescription)
        Me.GroupBox7.Controls.Add(Me.cbAutoDiagnostics)
        Me.GroupBox7.Controls.Add(Me.cbAutoScreening)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(193, 209)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(366, 144)
        Me.GroupBox7.TabIndex = 37
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Auto-Generate Queue"
        '
        'cbAutoAncillaryLab
        '
        Me.cbAutoAncillaryLab.ForeColor = System.Drawing.Color.Black
        Me.cbAutoAncillaryLab.Location = New System.Drawing.Point(5, 107)
        Me.cbAutoAncillaryLab.Name = "cbAutoAncillaryLab"
        Me.cbAutoAncillaryLab.Size = New System.Drawing.Size(106, 27)
        Me.cbAutoAncillaryLab.TabIndex = 51
        Me.cbAutoAncillaryLab.Text = "Laboratory"
        Me.cbAutoAncillaryLab.UseVisualStyleBackColor = True
        '
        'cbAutoCashierPhic
        '
        Me.cbAutoCashierPhic.ForeColor = System.Drawing.Color.Black
        Me.cbAutoCashierPhic.Location = New System.Drawing.Point(140, 78)
        Me.cbAutoCashierPhic.Name = "cbAutoCashierPhic"
        Me.cbAutoCashierPhic.Size = New System.Drawing.Size(96, 27)
        Me.cbAutoCashierPhic.TabIndex = 48
        Me.cbAutoCashierPhic.Text = "Philhealth"
        Me.cbAutoCashierPhic.UseVisualStyleBackColor = True
        '
        'cbAutoHMO
        '
        Me.cbAutoHMO.ForeColor = System.Drawing.Color.Black
        Me.cbAutoHMO.Location = New System.Drawing.Point(139, 47)
        Me.cbAutoHMO.Name = "cbAutoHMO"
        Me.cbAutoHMO.Size = New System.Drawing.Size(96, 27)
        Me.cbAutoHMO.TabIndex = 47
        Me.cbAutoHMO.Text = "HMO"
        Me.cbAutoHMO.UseVisualStyleBackColor = True
        '
        'cbAutoCashier
        '
        Me.cbAutoCashier.ForeColor = System.Drawing.Color.Black
        Me.cbAutoCashier.Location = New System.Drawing.Point(139, 18)
        Me.cbAutoCashier.Name = "cbAutoCashier"
        Me.cbAutoCashier.Size = New System.Drawing.Size(96, 27)
        Me.cbAutoCashier.TabIndex = 46
        Me.cbAutoCashier.Text = "Cashier"
        Me.cbAutoCashier.UseVisualStyleBackColor = True
        '
        'cbAutoPrescription
        '
        Me.cbAutoPrescription.ForeColor = System.Drawing.Color.Black
        Me.cbAutoPrescription.Location = New System.Drawing.Point(5, 78)
        Me.cbAutoPrescription.Name = "cbAutoPrescription"
        Me.cbAutoPrescription.Size = New System.Drawing.Size(136, 27)
        Me.cbAutoPrescription.TabIndex = 45
        Me.cbAutoPrescription.Text = "Prescription Queue"
        Me.cbAutoPrescription.UseVisualStyleBackColor = True
        '
        'cbAutoDiagnostics
        '
        Me.cbAutoDiagnostics.ForeColor = System.Drawing.Color.Black
        Me.cbAutoDiagnostics.Location = New System.Drawing.Point(4, 47)
        Me.cbAutoDiagnostics.Name = "cbAutoDiagnostics"
        Me.cbAutoDiagnostics.Size = New System.Drawing.Size(136, 27)
        Me.cbAutoDiagnostics.TabIndex = 44
        Me.cbAutoDiagnostics.Text = "Diagnostic Queue"
        Me.cbAutoDiagnostics.UseVisualStyleBackColor = True
        '
        'cbAutoScreening
        '
        Me.cbAutoScreening.ForeColor = System.Drawing.Color.Black
        Me.cbAutoScreening.Location = New System.Drawing.Point(4, 18)
        Me.cbAutoScreening.Name = "cbAutoScreening"
        Me.cbAutoScreening.Size = New System.Drawing.Size(136, 27)
        Me.cbAutoScreening.TabIndex = 43
        Me.cbAutoScreening.Text = "Screening Queue"
        Me.cbAutoScreening.UseVisualStyleBackColor = True
        '
        'cbViewDiagnostics
        '
        Me.cbViewDiagnostics.ForeColor = System.Drawing.Color.Black
        Me.cbViewDiagnostics.Location = New System.Drawing.Point(9, 21)
        Me.cbViewDiagnostics.Name = "cbViewDiagnostics"
        Me.cbViewDiagnostics.Size = New System.Drawing.Size(263, 27)
        Me.cbViewDiagnostics.TabIndex = 37
        Me.cbViewDiagnostics.Text = "View Diagnostics"
        Me.cbViewDiagnostics.UseVisualStyleBackColor = True
        '
        'cbManageDiagnostics
        '
        Me.cbManageDiagnostics.ForeColor = System.Drawing.Color.Black
        Me.cbManageDiagnostics.Location = New System.Drawing.Point(9, 54)
        Me.cbManageDiagnostics.Name = "cbManageDiagnostics"
        Me.cbManageDiagnostics.Size = New System.Drawing.Size(263, 27)
        Me.cbManageDiagnostics.TabIndex = 38
        Me.cbManageDiagnostics.Text = "Create/Edit Diagnostics"
        Me.cbManageDiagnostics.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.cbManageDiagnostics)
        Me.GroupBox6.Controls.Add(Me.cbViewDiagnostics)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(270, 467)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(289, 89)
        Me.GroupBox6.TabIndex = 42
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "DIAGNOSTICS"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.cbManageHealthcheck)
        Me.GroupBox8.Controls.Add(Me.cbViewHealthcheck)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(325, 359)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(234, 102)
        Me.GroupBox8.TabIndex = 43
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "HEALTH CHECK"
        '
        'cbManageHealthcheck
        '
        Me.cbManageHealthcheck.ForeColor = System.Drawing.Color.Black
        Me.cbManageHealthcheck.Location = New System.Drawing.Point(10, 59)
        Me.cbManageHealthcheck.Name = "cbManageHealthcheck"
        Me.cbManageHealthcheck.Size = New System.Drawing.Size(207, 37)
        Me.cbManageHealthcheck.TabIndex = 38
        Me.cbManageHealthcheck.Text = "Create/Edit Health Check"
        Me.cbManageHealthcheck.UseVisualStyleBackColor = True
        '
        'cbViewHealthcheck
        '
        Me.cbViewHealthcheck.ForeColor = System.Drawing.Color.Black
        Me.cbViewHealthcheck.Location = New System.Drawing.Point(10, 26)
        Me.cbViewHealthcheck.Name = "cbViewHealthcheck"
        Me.cbViewHealthcheck.Size = New System.Drawing.Size(207, 27)
        Me.cbViewHealthcheck.TabIndex = 37
        Me.cbViewHealthcheck.Text = "View Health Check"
        Me.cbViewHealthcheck.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.cbHealee)
        Me.GroupBox9.Controls.Add(Me.cbEkonsulta)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(561, 479)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(207, 89)
        Me.GroupBox9.TabIndex = 43
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "SUB COUNTER"
        '
        'cbHealee
        '
        Me.cbHealee.ForeColor = System.Drawing.Color.Black
        Me.cbHealee.Location = New System.Drawing.Point(9, 54)
        Me.cbHealee.Name = "cbHealee"
        Me.cbHealee.Size = New System.Drawing.Size(192, 27)
        Me.cbHealee.TabIndex = 38
        Me.cbHealee.Text = "MWell Consultation"
        Me.cbHealee.UseVisualStyleBackColor = True
        '
        'cbEkonsulta
        '
        Me.cbEkonsulta.ForeColor = System.Drawing.Color.Black
        Me.cbEkonsulta.Location = New System.Drawing.Point(9, 21)
        Me.cbEkonsulta.Name = "cbEkonsulta"
        Me.cbEkonsulta.Size = New System.Drawing.Size(192, 27)
        Me.cbEkonsulta.TabIndex = 37
        Me.cbEkonsulta.Text = "eKonsulta"
        Me.cbEkonsulta.UseVisualStyleBackColor = True
        '
        'cbAutoAncillaryRad
        '
        Me.cbAutoAncillaryRad.ForeColor = System.Drawing.Color.Black
        Me.cbAutoAncillaryRad.Location = New System.Drawing.Point(139, 107)
        Me.cbAutoAncillaryRad.Name = "cbAutoAncillaryRad"
        Me.cbAutoAncillaryRad.Size = New System.Drawing.Size(106, 27)
        Me.cbAutoAncillaryRad.TabIndex = 52
        Me.cbAutoAncillaryRad.Text = "Radiology"
        Me.cbAutoAncillaryRad.UseVisualStyleBackColor = True
        '
        'frmManageCounters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(784, 714)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblWorstVal)
        Me.Controls.Add(Me.lblMidVal)
        Me.Controls.Add(Me.lblBestVal)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClearIcon)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbIcon)
        Me.Controls.Add(Me.btnBrowseIcon)
        Me.Controls.Add(Me.txtCounterPrefix)
        Me.Controls.Add(Me.txtCounterCode)
        Me.Controls.Add(Me.txtServiceDescription)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageCounters"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAllowableTurnarroundTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnUpdate As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTittle As Label
    Friend WithEvents txtDepartment As ComboBox
    Friend WithEvents txtSection As TextBox
    Friend WithEvents txtServiceDescription As RichTextBox
    Friend WithEvents txtCounterCode As TextBox
    Friend WithEvents txtCounterPrefix As MaskedTextBox
    Friend WithEvents btnBrowseIcon As Button
    Friend WithEvents pbIcon As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbQueueCounter As RadioButton
    Friend WithEvents rbMainCounter As RadioButton
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClearIcon As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents cbForTransferOnly As CheckBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblBestVal As Label
    Friend WithEvents lblMidVal As Label
    Friend WithEvents lblWorstVal As Label
    Friend WithEvents nudAllowableTurnarroundTime As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cbManageConsultation As CheckBox
    Friend WithEvents cbViewConsultation As CheckBox
    Friend WithEvents cbViewPrescription As CheckBox
    Friend WithEvents cbManagePrescription As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbSyncProfileWithBizbox As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents cbAutoDiagnostics As CheckBox
    Friend WithEvents cbAutoScreening As CheckBox
    Friend WithEvents cbAutoPrescription As CheckBox
    Friend WithEvents cbAutoCashierPhic As CheckBox
    Friend WithEvents cbAutoHMO As CheckBox
    Friend WithEvents cbAutoCashier As CheckBox
    Friend WithEvents cbMakeInitialConsultation As CheckBox
    Friend WithEvents cbERConsultation As CheckBox
    Friend WithEvents cbViewDiagnostics As CheckBox
    Friend WithEvents cbManageDiagnostics As CheckBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents cbManageHealthcheck As CheckBox
    Friend WithEvents cbViewHealthcheck As CheckBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents cbHealee As CheckBox
    Friend WithEvents cbEkonsulta As CheckBox
    Friend WithEvents cbSoloQueue As CheckBox
    Friend WithEvents cbAutoAncillaryLab As CheckBox
    Friend WithEvents cbAutoAncillaryRad As CheckBox
End Class
