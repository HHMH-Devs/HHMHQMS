<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageDoctorsClinic
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbMAB = New System.Windows.Forms.GroupBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.cbFloor = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.txtCounterPrefix = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.txtClinicDesc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.txtClinicNo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlTableMode = New System.Windows.Forms.Panel()
        Me.dgvClinicList = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.roomNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbeKonsulta = New System.Windows.Forms.GroupBox()
        Me.cbCanEKonsulta = New System.Windows.Forms.CheckBox()
        Me.btnUpdateClinic = New System.Windows.Forms.Button()
        Me.btnDeleteClinic = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbERClinics = New System.Windows.Forms.RadioButton()
        Me.rbPccClinic = New System.Windows.Forms.RadioButton()
        Me.rbMABClinic = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNewClinic = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveClinic = New System.Windows.Forms.Button()
        Me.ManageClinicHours_Btn = New System.Windows.Forms.Button()
        Me.gbMAB.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.pnlTableMode.SuspendLayout()
        CType(Me.dgvClinicList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbeKonsulta.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMAB
        '
        Me.gbMAB.BackColor = System.Drawing.Color.Transparent
        Me.gbMAB.Controls.Add(Me.Panel16)
        Me.gbMAB.Controls.Add(Me.Panel15)
        Me.gbMAB.Controls.Add(Me.Panel14)
        Me.gbMAB.Controls.Add(Me.Panel13)
        Me.gbMAB.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.gbMAB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbMAB.Location = New System.Drawing.Point(15, 100)
        Me.gbMAB.Name = "gbMAB"
        Me.gbMAB.Size = New System.Drawing.Size(852, 117)
        Me.gbMAB.TabIndex = 49
        Me.gbMAB.TabStop = False
        Me.gbMAB.Text = "CLINIC INFORMATION"
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.cbFloor)
        Me.Panel16.Controls.Add(Me.Label16)
        Me.Panel16.Location = New System.Drawing.Point(443, 32)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(398, 30)
        Me.Panel16.TabIndex = 46
        '
        'cbFloor
        '
        Me.cbFloor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFloor.Enabled = False
        Me.cbFloor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFloor.FormattingEnabled = True
        Me.cbFloor.Items.AddRange(New Object() {"GROUND FLOOR", "2ND FLOOR", "3RD FLOOR", "4TH FLOOR"})
        Me.cbFloor.Location = New System.Drawing.Point(142, 0)
        Me.cbFloor.Name = "cbFloor"
        Me.cbFloor.Size = New System.Drawing.Size(254, 27)
        Me.cbFloor.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Honeydew
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(142, 28)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "FLOOR"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel15
        '
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.txtCounterPrefix)
        Me.Panel15.Controls.Add(Me.Label15)
        Me.Panel15.Location = New System.Drawing.Point(443, 68)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(398, 30)
        Me.Panel15.TabIndex = 44
        '
        'txtCounterPrefix
        '
        Me.txtCounterPrefix.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCounterPrefix.Enabled = False
        Me.txtCounterPrefix.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounterPrefix.Location = New System.Drawing.Point(142, 0)
        Me.txtCounterPrefix.Mask = "A A A A"
        Me.txtCounterPrefix.Name = "txtCounterPrefix"
        Me.txtCounterPrefix.Size = New System.Drawing.Size(254, 29)
        Me.txtCounterPrefix.TabIndex = 29
        Me.txtCounterPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Honeydew
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(142, 28)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "CLINIC PREFIX"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel14
        '
        Me.Panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel14.Controls.Add(Me.txtClinicDesc)
        Me.Panel14.Controls.Add(Me.Label14)
        Me.Panel14.Location = New System.Drawing.Point(11, 68)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(418, 30)
        Me.Panel14.TabIndex = 44
        '
        'txtClinicDesc
        '
        Me.txtClinicDesc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClinicDesc.Enabled = False
        Me.txtClinicDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtClinicDesc.Location = New System.Drawing.Point(142, 0)
        Me.txtClinicDesc.Multiline = True
        Me.txtClinicDesc.Name = "txtClinicDesc"
        Me.txtClinicDesc.Size = New System.Drawing.Size(274, 28)
        Me.txtClinicDesc.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Honeydew
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(142, 28)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "CLINIC DESCRIPTION"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.txtClinicNo)
        Me.Panel13.Controls.Add(Me.Label13)
        Me.Panel13.Location = New System.Drawing.Point(11, 32)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(418, 30)
        Me.Panel13.TabIndex = 43
        '
        'txtClinicNo
        '
        Me.txtClinicNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClinicNo.Enabled = False
        Me.txtClinicNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtClinicNo.Location = New System.Drawing.Point(142, 0)
        Me.txtClinicNo.Multiline = True
        Me.txtClinicNo.Name = "txtClinicNo"
        Me.txtClinicNo.Size = New System.Drawing.Size(274, 28)
        Me.txtClinicNo.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Honeydew
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 28)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "CLINIC NUMBER"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTableMode
        '
        Me.pnlTableMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTableMode.Controls.Add(Me.dgvClinicList)
        Me.pnlTableMode.Location = New System.Drawing.Point(223, 282)
        Me.pnlTableMode.Name = "pnlTableMode"
        Me.pnlTableMode.Size = New System.Drawing.Size(645, 175)
        Me.pnlTableMode.TabIndex = 50
        '
        'dgvClinicList
        '
        Me.dgvClinicList.AllowUserToAddRows = False
        Me.dgvClinicList.AllowUserToDeleteRows = False
        Me.dgvClinicList.AllowUserToResizeRows = False
        Me.dgvClinicList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClinicList.BackgroundColor = System.Drawing.Color.Honeydew
        Me.dgvClinicList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClinicList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClinicList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClinicList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.roomNo, Me.location, Me.type})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClinicList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClinicList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClinicList.Location = New System.Drawing.Point(0, 0)
        Me.dgvClinicList.MultiSelect = False
        Me.dgvClinicList.Name = "dgvClinicList"
        Me.dgvClinicList.ReadOnly = True
        Me.dgvClinicList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvClinicList.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvClinicList.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvClinicList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClinicList.Size = New System.Drawing.Size(643, 173)
        Me.dgvClinicList.TabIndex = 34
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'roomNo
        '
        Me.roomNo.HeaderText = "Room No"
        Me.roomNo.Name = "roomNo"
        Me.roomNo.ReadOnly = True
        '
        'location
        '
        Me.location.HeaderText = "Floor"
        Me.location.Name = "location"
        Me.location.ReadOnly = True
        '
        'type
        '
        Me.type.HeaderText = "Account Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'gbeKonsulta
        '
        Me.gbeKonsulta.BackColor = System.Drawing.Color.Transparent
        Me.gbeKonsulta.Controls.Add(Me.cbCanEKonsulta)
        Me.gbeKonsulta.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.gbeKonsulta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbeKonsulta.Location = New System.Drawing.Point(17, 223)
        Me.gbeKonsulta.Name = "gbeKonsulta"
        Me.gbeKonsulta.Size = New System.Drawing.Size(290, 53)
        Me.gbeKonsulta.TabIndex = 51
        Me.gbeKonsulta.TabStop = False
        Me.gbeKonsulta.Text = "eKonsulta (for PCC Clinics only)"
        '
        'cbCanEKonsulta
        '
        Me.cbCanEKonsulta.AutoSize = True
        Me.cbCanEKonsulta.Enabled = False
        Me.cbCanEKonsulta.Location = New System.Drawing.Point(10, 21)
        Me.cbCanEKonsulta.Name = "cbCanEKonsulta"
        Me.cbCanEKonsulta.Size = New System.Drawing.Size(270, 20)
        Me.cbCanEKonsulta.TabIndex = 0
        Me.cbCanEKonsulta.Text = "This Doctor Can Handle eKonsulta Patient"
        Me.cbCanEKonsulta.UseVisualStyleBackColor = True
        '
        'btnUpdateClinic
        '
        Me.btnUpdateClinic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnUpdateClinic.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUpdateClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateClinic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdateClinic.ForeColor = System.Drawing.Color.White
        Me.btnUpdateClinic.Location = New System.Drawing.Point(526, 223)
        Me.btnUpdateClinic.Name = "btnUpdateClinic"
        Me.btnUpdateClinic.Size = New System.Drawing.Size(168, 53)
        Me.btnUpdateClinic.TabIndex = 52
        Me.btnUpdateClinic.Text = "EDIT CLINIC"
        Me.btnUpdateClinic.UseVisualStyleBackColor = False
        '
        'btnDeleteClinic
        '
        Me.btnDeleteClinic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDeleteClinic.BackColor = System.Drawing.Color.Maroon
        Me.btnDeleteClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteClinic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteClinic.ForeColor = System.Drawing.Color.White
        Me.btnDeleteClinic.Location = New System.Drawing.Point(700, 223)
        Me.btnDeleteClinic.Name = "btnDeleteClinic"
        Me.btnDeleteClinic.Size = New System.Drawing.Size(168, 53)
        Me.btnDeleteClinic.TabIndex = 53
        Me.btnDeleteClinic.Text = "DELETE CLINIC"
        Me.btnDeleteClinic.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rbERClinics)
        Me.GroupBox3.Controls.Add(Me.rbPccClinic)
        Me.GroupBox3.Controls.Add(Me.rbMABClinic)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(17, 282)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 114)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DESIGNATION/CLINIC"
        '
        'rbERClinics
        '
        Me.rbERClinics.AutoSize = True
        Me.rbERClinics.Enabled = False
        Me.rbERClinics.Location = New System.Drawing.Point(24, 72)
        Me.rbERClinics.Name = "rbERClinics"
        Me.rbERClinics.Size = New System.Drawing.Size(104, 20)
        Me.rbERClinics.TabIndex = 6
        Me.rbERClinics.Text = "ER Physician"
        Me.rbERClinics.UseVisualStyleBackColor = True
        '
        'rbPccClinic
        '
        Me.rbPccClinic.AutoSize = True
        Me.rbPccClinic.Enabled = False
        Me.rbPccClinic.Location = New System.Drawing.Point(24, 27)
        Me.rbPccClinic.Name = "rbPccClinic"
        Me.rbPccClinic.Size = New System.Drawing.Size(88, 20)
        Me.rbPccClinic.TabIndex = 3
        Me.rbPccClinic.Text = "PCC Clinic"
        Me.rbPccClinic.UseVisualStyleBackColor = True
        '
        'rbMABClinic
        '
        Me.rbMABClinic.AutoSize = True
        Me.rbMABClinic.Enabled = False
        Me.rbMABClinic.Location = New System.Drawing.Point(24, 49)
        Me.rbMABClinic.Name = "rbMABClinic"
        Me.rbMABClinic.Size = New System.Drawing.Size(100, 20)
        Me.rbMABClinic.TabIndex = 1
        Me.rbMABClinic.Text = "Private Clinic"
        Me.rbMABClinic.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(878, 51)
        Me.Panel3.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(878, 51)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "MANAGE DOCTOR'S CLINIC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNewClinic
        '
        Me.btnNewClinic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNewClinic.BackColor = System.Drawing.Color.LimeGreen
        Me.btnNewClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewClinic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNewClinic.ForeColor = System.Drawing.Color.White
        Me.btnNewClinic.Location = New System.Drawing.Point(15, 57)
        Me.btnNewClinic.Name = "btnNewClinic"
        Me.btnNewClinic.Size = New System.Drawing.Size(178, 37)
        Me.btnNewClinic.TabIndex = 97
        Me.btnNewClinic.Text = "NEW CLINIC"
        Me.btnNewClinic.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.BackColor = System.Drawing.Color.Maroon
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(199, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(178, 37)
        Me.btnCancel.TabIndex = 98
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'btnSaveClinic
        '
        Me.btnSaveClinic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSaveClinic.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSaveClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveClinic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveClinic.ForeColor = System.Drawing.Color.White
        Me.btnSaveClinic.Location = New System.Drawing.Point(15, 57)
        Me.btnSaveClinic.Name = "btnSaveClinic"
        Me.btnSaveClinic.Size = New System.Drawing.Size(178, 37)
        Me.btnSaveClinic.TabIndex = 99
        Me.btnSaveClinic.Text = "SAVE CLINIC"
        Me.btnSaveClinic.UseVisualStyleBackColor = False
        Me.btnSaveClinic.Visible = False
        '
        'ManageClinicHours_Btn
        '
        Me.ManageClinicHours_Btn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ManageClinicHours_Btn.BackColor = System.Drawing.Color.LimeGreen
        Me.ManageClinicHours_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ManageClinicHours_Btn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ManageClinicHours_Btn.ForeColor = System.Drawing.Color.White
        Me.ManageClinicHours_Btn.Location = New System.Drawing.Point(352, 223)
        Me.ManageClinicHours_Btn.Name = "ManageClinicHours_Btn"
        Me.ManageClinicHours_Btn.Size = New System.Drawing.Size(168, 53)
        Me.ManageClinicHours_Btn.TabIndex = 100
        Me.ManageClinicHours_Btn.Text = "MANAGE CLINIC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HOURS"
        Me.ManageClinicHours_Btn.UseVisualStyleBackColor = False
        '
        'frmManageDoctorsClinic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 462)
        Me.Controls.Add(Me.ManageClinicHours_Btn)
        Me.Controls.Add(Me.btnSaveClinic)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNewClinic)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnDeleteClinic)
        Me.Controls.Add(Me.btnUpdateClinic)
        Me.Controls.Add(Me.gbeKonsulta)
        Me.Controls.Add(Me.pnlTableMode)
        Me.Controls.Add(Me.gbMAB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageDoctorsClinic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.gbMAB.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.pnlTableMode.ResumeLayout(False)
        CType(Me.dgvClinicList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbeKonsulta.ResumeLayout(False)
        Me.gbeKonsulta.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbMAB As GroupBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents cbFloor As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents txtCounterPrefix As MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents txtClinicNo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents pnlTableMode As Panel
    Friend WithEvents dgvClinicList As DataGridView
    Friend WithEvents gbeKonsulta As GroupBox
    Friend WithEvents cbCanEKonsulta As CheckBox
    Friend WithEvents btnUpdateClinic As Button
    Friend WithEvents btnDeleteClinic As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbPccClinic As RadioButton
    Friend WithEvents rbMABClinic As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNewClinic As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents roomNo As DataGridViewTextBoxColumn
    Friend WithEvents location As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents btnSaveClinic As Button
    Friend WithEvents txtClinicDesc As TextBox
    Friend WithEvents rbERClinics As RadioButton
    Friend WithEvents ManageClinicHours_Btn As Button
End Class
