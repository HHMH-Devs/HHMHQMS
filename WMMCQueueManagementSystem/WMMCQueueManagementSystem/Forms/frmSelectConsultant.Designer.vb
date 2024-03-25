<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectConsultant
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectConsultant))
        Me.pnlDoctors = New System.Windows.Forms.Panel()
        Me.txtFindDoctor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAvailabilityOfClinic = New System.Windows.Forms.ComboBox()
        Me.dgvDoctorsList = New System.Windows.Forms.DataGridView()
        Me.clinicCounterID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicDoctorAvailability = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicDoctorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicSpecialization = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicRoom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinicLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSelectedDept = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.pnlDoctors.SuspendLayout()
        CType(Me.dgvDoctorsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDoctors
        '
        Me.pnlDoctors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDoctors.Controls.Add(Me.txtFindDoctor)
        Me.pnlDoctors.Controls.Add(Me.Label1)
        Me.pnlDoctors.Controls.Add(Me.Label6)
        Me.pnlDoctors.Controls.Add(Me.cbAvailabilityOfClinic)
        Me.pnlDoctors.Controls.Add(Me.dgvDoctorsList)
        Me.pnlDoctors.Location = New System.Drawing.Point(12, 144)
        Me.pnlDoctors.Name = "pnlDoctors"
        Me.pnlDoctors.Size = New System.Drawing.Size(831, 452)
        Me.pnlDoctors.TabIndex = 37
        '
        'txtFindDoctor
        '
        Me.txtFindDoctor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFindDoctor.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtFindDoctor.Location = New System.Drawing.Point(574, 11)
        Me.txtFindDoctor.Name = "txtFindDoctor"
        Me.txtFindDoctor.Size = New System.Drawing.Size(252, 25)
        Me.txtFindDoctor.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
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
        Me.Label6.Location = New System.Drawing.Point(455, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
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
        Me.cbAvailabilityOfClinic.Location = New System.Drawing.Point(105, 10)
        Me.cbAvailabilityOfClinic.Name = "cbAvailabilityOfClinic"
        Me.cbAvailabilityOfClinic.Size = New System.Drawing.Size(207, 28)
        Me.cbAvailabilityOfClinic.TabIndex = 58
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDoctorsList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDoctorsList.Location = New System.Drawing.Point(3, 44)
        Me.dgvDoctorsList.Name = "dgvDoctorsList"
        Me.dgvDoctorsList.ReadOnly = True
        Me.dgvDoctorsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvDoctorsList.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.dgvDoctorsList.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDoctorsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDoctorsList.Size = New System.Drawing.Size(823, 405)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.txtSelectedDept)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 81)
        Me.Panel1.TabIndex = 38
        '
        'txtSelectedDept
        '
        Me.txtSelectedDept.BackColor = System.Drawing.Color.Transparent
        Me.txtSelectedDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSelectedDept.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedDept.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSelectedDept.Location = New System.Drawing.Point(192, 0)
        Me.txtSelectedDept.Name = "txtSelectedDept"
        Me.txtSelectedDept.Size = New System.Drawing.Size(662, 81)
        Me.txtSelectedDept.TabIndex = 5
        Me.txtSelectedDept.Text = "PLEASE SELECT A CONSULTANT"
        Me.txtSelectedDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 28)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "PHYSICIAN TYPE: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"PCC DOCTORS", "PCC HYBRID DOCTORS", "MAB DOCTORS", "MAB HYBRID DOCTORS", "eKonsulta DOCTORS", "ER PHYSICIANS"})
        Me.ComboBox1.Location = New System.Drawing.Point(159, 97)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(684, 28)
        Me.ComboBox1.TabIndex = 63
        '
        'frmSelectConsultant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(854, 601)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.pnlDoctors)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectConsultant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlDoctors.ResumeLayout(False)
        Me.pnlDoctors.PerformLayout()
        CType(Me.dgvDoctorsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDoctors As Panel
    Friend WithEvents txtFindDoctor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbAvailabilityOfClinic As ComboBox
    Friend WithEvents dgvDoctorsList As DataGridView
    Friend WithEvents clinicCounterID As DataGridViewTextBoxColumn
    Friend WithEvents clinicDoctorAvailability As DataGridViewTextBoxColumn
    Friend WithEvents clinicDoctorName As DataGridViewTextBoxColumn
    Friend WithEvents clinicSpecialization As DataGridViewTextBoxColumn
    Friend WithEvents clinicRoom As DataGridViewTextBoxColumn
    Friend WithEvents clinicLocation As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSelectedDept As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
