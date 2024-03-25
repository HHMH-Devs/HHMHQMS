<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageNurseNotes
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTableMode = New System.Windows.Forms.Panel()
        Me.dgvClinicList = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.focus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.pnlTableMode.SuspendLayout()
        CType(Me.dgvClinicList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(915, 51)
        Me.Panel3.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(915, 51)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "MANAGE NURSES NOTES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTableMode
        '
        Me.pnlTableMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTableMode.Controls.Add(Me.dgvClinicList)
        Me.pnlTableMode.Location = New System.Drawing.Point(8, 103)
        Me.pnlTableMode.Name = "pnlTableMode"
        Me.pnlTableMode.Size = New System.Drawing.Size(898, 400)
        Me.pnlTableMode.TabIndex = 100
        '
        'dgvClinicList
        '
        Me.dgvClinicList.AllowUserToResizeRows = False
        Me.dgvClinicList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClinicList.BackgroundColor = System.Drawing.Color.White
        Me.dgvClinicList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClinicList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvClinicList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClinicList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.dateShift, Me.focus, Me.dataaction})
        Me.dgvClinicList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClinicList.Location = New System.Drawing.Point(0, 0)
        Me.dgvClinicList.MultiSelect = False
        Me.dgvClinicList.Name = "dgvClinicList"
        Me.dgvClinicList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvClinicList.RowHeadersVisible = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgvClinicList.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvClinicList.RowTemplate.Height = 35
        Me.dgvClinicList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClinicList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvClinicList.Size = New System.Drawing.Size(896, 398)
        Me.dgvClinicList.TabIndex = 34
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'dateShift
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dateShift.DefaultCellStyle = DataGridViewCellStyle7
        Me.dateShift.FillWeight = 40.0!
        Me.dateShift.HeaderText = "DATE/TIME SHIFT"
        Me.dateShift.Name = "dateShift"
        Me.dateShift.ReadOnly = True
        Me.dateShift.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'focus
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.focus.DefaultCellStyle = DataGridViewCellStyle8
        Me.focus.FillWeight = 50.0!
        Me.focus.HeaderText = "FOCUS"
        Me.focus.Name = "focus"
        Me.focus.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'dataaction
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.dataaction.DefaultCellStyle = DataGridViewCellStyle9
        Me.dataaction.HeaderText = "DATA. ACTION, RESPONSE"
        Me.dataaction.Name = "dataaction"
        Me.dataaction.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button2.Location = New System.Drawing.Point(319, 509)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(276, 43)
        Me.Button2.TabIndex = 215
        Me.Button2.Text = "SAVE CHANGES"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(319, 558)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(276, 40)
        Me.Button3.TabIndex = 216
        Me.Button3.Text = "CANCEL"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(677, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(228, 40)
        Me.Button1.TabIndex = 217
        Me.Button1.Text = "REMOVE NURSE NOTE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.White
        Me.Label29.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(12, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(659, 38)
        Me.Label29.TabIndex = 218
        Me.Label29.Text = "CLICK TO FILL UP EACH ITEM"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmManageNurseNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(915, 604)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pnlTableMode)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageNurseNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel3.ResumeLayout(False)
        Me.pnlTableMode.ResumeLayout(False)
        CType(Me.dgvClinicList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlTableMode As Panel
    Friend WithEvents dgvClinicList As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents dateShift As DataGridViewTextBoxColumn
    Friend WithEvents focus As DataGridViewTextBoxColumn
    Friend WithEvents dataaction As DataGridViewTextBoxColumn
End Class
