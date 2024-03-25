<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFollowUpConsultationSchedule
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
        Me.dgvDiagnosticRequestItems = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblFFConsultationInfo = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnApplyFilters = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDiagnosticRequestItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDiagnosticRequestItems
        '
        Me.dgvDiagnosticRequestItems.AllowUserToAddRows = False
        Me.dgvDiagnosticRequestItems.AllowUserToDeleteRows = False
        Me.dgvDiagnosticRequestItems.AllowUserToResizeRows = False
        Me.dgvDiagnosticRequestItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDiagnosticRequestItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvDiagnosticRequestItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosticRequestItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnosticRequestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiagnosticRequestItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Column3, Me.Column2})
        Me.dgvDiagnosticRequestItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvDiagnosticRequestItems.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDiagnosticRequestItems.Location = New System.Drawing.Point(0, 249)
        Me.dgvDiagnosticRequestItems.MultiSelect = False
        Me.dgvDiagnosticRequestItems.Name = "dgvDiagnosticRequestItems"
        Me.dgvDiagnosticRequestItems.ReadOnly = True
        Me.dgvDiagnosticRequestItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvDiagnosticRequestItems.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.dgvDiagnosticRequestItems.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDiagnosticRequestItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiagnosticRequestItems.Size = New System.Drawing.Size(891, 273)
        Me.dgvDiagnosticRequestItems.TabIndex = 94
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(891, 51)
        Me.Panel3.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(891, 51)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "VERIFY FOLLOW-UP CONSULTATION SCHEDULE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel11)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 127)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FOLLOW-UP CHECK UP INFORMATION"
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.lblFFConsultationInfo)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 18)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(868, 106)
        Me.Panel11.TabIndex = 30
        '
        'lblFFConsultationInfo
        '
        Me.lblFFConsultationInfo.BackColor = System.Drawing.Color.White
        Me.lblFFConsultationInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFFConsultationInfo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFFConsultationInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblFFConsultationInfo.Location = New System.Drawing.Point(235, 0)
        Me.lblFFConsultationInfo.Name = "lblFFConsultationInfo"
        Me.lblFFConsultationInfo.Size = New System.Drawing.Size(631, 104)
        Me.lblFFConsultationInfo.TabIndex = 30
        Me.lblFFConsultationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(235, 104)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "NAME OF PHYSICIAN :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SPECIALIZATION :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DATE OF FOLLOW-UP :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LOCATION OF FOLLOW-UP" &
    " :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LAST CONSULTATION :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnApplyFilters
        '
        Me.btnApplyFilters.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnApplyFilters.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnApplyFilters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnApplyFilters.FlatAppearance.BorderSize = 0
        Me.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyFilters.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApplyFilters.ForeColor = System.Drawing.Color.White
        Me.btnApplyFilters.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnApplyFilters.Location = New System.Drawing.Point(643, 57)
        Me.btnApplyFilters.Name = "btnApplyFilters"
        Me.btnApplyFilters.Size = New System.Drawing.Size(239, 52)
        Me.btnApplyFilters.TabIndex = 101
        Me.btnApplyFilters.Text = "FIND FOLLOW-UP CHECK UP"
        Me.btnApplyFilters.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 57)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(306, 53)
        Me.GroupBox5.TabIndex = 102
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DATE FROM"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDateFrom.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.dtpDateFrom.Location = New System.Drawing.Point(3, 18)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(300, 22)
        Me.dtpDateFrom.TabIndex = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.dtpDateTo)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(325, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(306, 53)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATE TO"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDateTo.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.dtpDateTo.Location = New System.Drawing.Point(3, 18)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(300, 22)
        Me.dtpDateTo.TabIndex = 101
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "PHYSICIAN"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "FOLLOW-UP CONSULATION DATE"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'frmFollowUpConsultationSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(891, 522)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnApplyFilters)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dgvDiagnosticRequestItems)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFollowUpConsultationSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvDiagnosticRequestItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDiagnosticRequestItems As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblFFConsultationInfo As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
