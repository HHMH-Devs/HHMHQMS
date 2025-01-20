<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransferNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferNo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSelectedDept = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblAllowedTranser = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.pnlDoctors = New System.Windows.Forms.Panel()
        Me.txtFindDoctor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAvailabilityOfClinic = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvDoctorsList = New System.Windows.Forms.DataGridView()
        Me.clinicCounterID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicDoctorAvailability = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicDoctorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicSpecialization = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicRoom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlDoctors.SuspendLayout()
        CType(Me.dgvDoctorsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.txtSelectedDept)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 81)
        Me.Panel1.TabIndex = 10
        '
        'txtSelectedDept
        '
        Me.txtSelectedDept.BackColor = System.Drawing.Color.Transparent
        Me.txtSelectedDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSelectedDept.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedDept.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSelectedDept.Location = New System.Drawing.Point(0, 0)
        Me.txtSelectedDept.Name = "txtSelectedDept"
        Me.txtSelectedDept.Size = New System.Drawing.Size(855, 81)
        Me.txtSelectedDept.TabIndex = 5
        Me.txtSelectedDept.Text = "SELECT A COUNTER OR DOCTOR TO TRANSFER OR REFER"
        Me.txtSelectedDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(1301, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 60)
        Me.Button3.TabIndex = 4
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.HideSelection = False
        Me.ListView1.HotTracking = True
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(12, 98)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(831, 449)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblAllowedTranser, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 560)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(855, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblAllowedTranser
        '
        Me.lblAllowedTranser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblAllowedTranser.Name = "lblAllowedTranser"
        Me.lblAllowedTranser.Size = New System.Drawing.Size(13, 22)
        Me.lblAllowedTranser.Text = "0"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        Me.ToolStripLabel1.Text = "ToolStripLabel1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripLabel2.Text = "Remaining Transfer:"
        '
        'pnlDoctors
        '
        Me.pnlDoctors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDoctors.Controls.Add(Me.dgvDoctorsList)
        Me.pnlDoctors.Controls.Add(Me.txtFindDoctor)
        Me.pnlDoctors.Controls.Add(Me.Label1)
        Me.pnlDoctors.Controls.Add(Me.Label6)
        Me.pnlDoctors.Controls.Add(Me.cbAvailabilityOfClinic)
        Me.pnlDoctors.Controls.Add(Me.Button1)
        Me.pnlDoctors.Location = New System.Drawing.Point(12, 98)
        Me.pnlDoctors.Name = "pnlDoctors"
        Me.pnlDoctors.Size = New System.Drawing.Size(831, 449)
        Me.pnlDoctors.TabIndex = 36
        Me.pnlDoctors.Visible = False
        '
        'txtFindDoctor
        '
        Me.txtFindDoctor.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtFindDoctor.Location = New System.Drawing.Point(574, 11)
        Me.txtFindDoctor.Name = "txtFindDoctor"
        Me.txtFindDoctor.Size = New System.Drawing.Size(252, 25)
        Me.txtFindDoctor.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "AVAILABILITY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(467, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "FIND PHYSICIAN"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAvailabilityOfClinic
        '
        Me.cbAvailabilityOfClinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAvailabilityOfClinic.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAvailabilityOfClinic.FormattingEnabled = True
        Me.cbAvailabilityOfClinic.Items.AddRange(New Object() {"ALL", "ONLINE", "OFFLINE"})
        Me.cbAvailabilityOfClinic.Location = New System.Drawing.Point(96, 10)
        Me.cbAvailabilityOfClinic.Name = "cbAvailabilityOfClinic"
        Me.cbAvailabilityOfClinic.Size = New System.Drawing.Size(187, 28)
        Me.cbAvailabilityOfClinic.TabIndex = 58
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(335, 401)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 40)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "BACK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvDoctorsList
        '
        Me.dgvDoctorsList.AllowUserToAddRows = False
        Me.dgvDoctorsList.AllowUserToDeleteRows = False
        Me.dgvDoctorsList.AllowUserToResizeRows = False
        Me.dgvDoctorsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDoctorsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDoctorsList.BackgroundColor = System.Drawing.Color.Honeydew
        Me.dgvDoctorsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDoctorsList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDoctorsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDoctorsList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clinicCounterID, Me.clinicDoctorAvailability, Me.clinicDoctorName, Me.clinicSpecialization, Me.clinicRoom, Me.clinicLocation})
        Me.dgvDoctorsList.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDoctorsList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDoctorsList.Location = New System.Drawing.Point(0, 44)
        Me.dgvDoctorsList.Name = "dgvDoctorsList"
        Me.dgvDoctorsList.ReadOnly = True
        Me.dgvDoctorsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvDoctorsList.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvDoctorsList.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDoctorsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDoctorsList.Size = New System.Drawing.Size(831, 351)
        Me.dgvDoctorsList.TabIndex = 36
        '
        'clinicCounterID
        '
        Me.clinicCounterID.HeaderText = "id"
        Me.clinicCounterID.Name = "clinicCounterID"
        Me.clinicCounterID.ReadOnly = True
        Me.clinicCounterID.Visible = False
        '
        'clinicDoctorAvailability
        '
        Me.clinicDoctorAvailability.FillWeight = 40.0!
        Me.clinicDoctorAvailability.HeaderText = "STATUS"
        Me.clinicDoctorAvailability.Name = "clinicDoctorAvailability"
        Me.clinicDoctorAvailability.ReadOnly = True
        '
        'clinicDoctorName
        '
        Me.clinicDoctorName.FillWeight = 93.27411!
        Me.clinicDoctorName.HeaderText = "PHYSICIAN"
        Me.clinicDoctorName.Name = "clinicDoctorName"
        Me.clinicDoctorName.ReadOnly = True
        '
        'clinicSpecialization
        '
        Me.clinicSpecialization.FillWeight = 93.27411!
        Me.clinicSpecialization.HeaderText = "SPECIALIZATION"
        Me.clinicSpecialization.Name = "clinicSpecialization"
        Me.clinicSpecialization.ReadOnly = True
        '
        'clinicRoom
        '
        Me.clinicRoom.FillWeight = 93.27411!
        Me.clinicRoom.HeaderText = "CLINIC"
        Me.clinicRoom.Name = "clinicRoom"
        Me.clinicRoom.ReadOnly = True
        '
        'clinicLocation
        '
        Me.clinicLocation.FillWeight = 93.27411!
        Me.clinicLocation.HeaderText = "FLOOR"
        Me.clinicLocation.Name = "clinicLocation"
        Me.clinicLocation.ReadOnly = True
        '
        'frmTransferNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(855, 585)
        Me.Controls.Add(Me.pnlDoctors)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferNo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlDoctors.ResumeLayout(False)
        Me.pnlDoctors.PerformLayout()
        CType(Me.dgvDoctorsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSelectedDept As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents lblAllowedTranser As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents pnlDoctors As Panel
    Friend WithEvents dgvDoctorsList As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents clinicCounterID As DataGridViewTextBoxColumn
    Friend WithEvents clinicDoctorAvailability As DataGridViewTextBoxColumn
    Friend WithEvents clinicDoctorName As DataGridViewTextBoxColumn
    Friend WithEvents clinicSpecialization As DataGridViewTextBoxColumn
    Friend WithEvents clinicRoom As DataGridViewTextBoxColumn
    Friend WithEvents clinicLocation As DataGridViewTextBoxColumn
    Friend WithEvents cbAvailabilityOfClinic As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFindDoctor As TextBox
End Class
