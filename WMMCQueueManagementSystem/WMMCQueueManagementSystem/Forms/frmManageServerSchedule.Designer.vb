<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageServerSchedule
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
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.dgvServer = New System.Windows.Forms.DataGridView()
        Me.DayColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AvailabilityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EditSchedule_BTN = New System.Windows.Forms.Button()
        Me.AddNewSched_BTN = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dgvServer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTittle.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(871, 58)
        Me.lblTittle.TabIndex = 1
        Me.lblTittle.Text = "Manage Clinic Schedule"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvServer
        '
        Me.dgvServer.AllowUserToAddRows = False
        Me.dgvServer.AllowUserToDeleteRows = False
        Me.dgvServer.AllowUserToResizeRows = False
        Me.dgvServer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvServer.BackgroundColor = System.Drawing.Color.Honeydew
        Me.dgvServer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvServer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvServer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DayColumn, Me.AvailabilityColumn})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvServer.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvServer.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvServer.Location = New System.Drawing.Point(0, 101)
        Me.dgvServer.Name = "dgvServer"
        Me.dgvServer.ReadOnly = True
        Me.dgvServer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvServer.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.dgvServer.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvServer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServer.Size = New System.Drawing.Size(871, 347)
        Me.dgvServer.TabIndex = 14
        '
        'DayColumn
        '
        Me.DayColumn.HeaderText = "Day"
        Me.DayColumn.Name = "DayColumn"
        Me.DayColumn.ReadOnly = True
        '
        'AvailabilityColumn
        '
        Me.AvailabilityColumn.HeaderText = "Availability"
        Me.AvailabilityColumn.Name = "AvailabilityColumn"
        Me.AvailabilityColumn.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.EditSchedule_BTN)
        Me.Panel1.Controls.Add(Me.AddNewSched_BTN)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(871, 43)
        Me.Panel1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(460, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(411, 43)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "FIRST NAME"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EditSchedule_BTN
        '
        Me.EditSchedule_BTN.BackColor = System.Drawing.Color.LimeGreen
        Me.EditSchedule_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.EditSchedule_BTN.FlatAppearance.BorderSize = 0
        Me.EditSchedule_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditSchedule_BTN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditSchedule_BTN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.EditSchedule_BTN.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.EditSchedule_BTN.Location = New System.Drawing.Point(214, 6)
        Me.EditSchedule_BTN.Name = "EditSchedule_BTN"
        Me.EditSchedule_BTN.Size = New System.Drawing.Size(203, 30)
        Me.EditSchedule_BTN.TabIndex = 50
        Me.EditSchedule_BTN.Text = "&Edit Availability"
        Me.EditSchedule_BTN.UseVisualStyleBackColor = False
        '
        'AddNewSched_BTN
        '
        Me.AddNewSched_BTN.BackColor = System.Drawing.Color.LimeGreen
        Me.AddNewSched_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.AddNewSched_BTN.FlatAppearance.BorderSize = 0
        Me.AddNewSched_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddNewSched_BTN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewSched_BTN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.AddNewSched_BTN.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.AddNewSched_BTN.Location = New System.Drawing.Point(5, 6)
        Me.AddNewSched_BTN.Name = "AddNewSched_BTN"
        Me.AddNewSched_BTN.Size = New System.Drawing.Size(203, 30)
        Me.AddNewSched_BTN.TabIndex = 49
        Me.AddNewSched_BTN.Text = "&Add New"
        Me.AddNewSched_BTN.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(295, 454)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 30)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Maroon
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button2.Location = New System.Drawing.Point(438, 454)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 30)
        Me.Button2.TabIndex = 52
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmManageServerSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(871, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvServer)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTittle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageServerSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvServer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTittle As Label
    Friend WithEvents dgvServer As DataGridView
    Friend WithEvents DayColumn As DataGridViewTextBoxColumn
    Friend WithEvents AvailabilityColumn As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EditSchedule_BTN As Button
    Friend WithEvents AddNewSched_BTN As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
