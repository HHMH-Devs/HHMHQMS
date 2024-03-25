<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserAccount
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserAccount))
        Me.dgvServer = New System.Windows.Forms.DataGridView()
        Me.serverid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employeeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assigndeparment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accounttype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTextFilter = New System.Windows.Forms.TextBox()
        Me.UserAccountStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageAssignedCountesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnManageCounter = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.dgvServer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.UserAccountStrip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgvServer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serverid, Me.employeeid, Me.fullname, Me.assigndeparment, Me.accounttype})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvServer.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvServer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvServer.Location = New System.Drawing.Point(0, 109)
        Me.dgvServer.Name = "dgvServer"
        Me.dgvServer.ReadOnly = True
        Me.dgvServer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvServer.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.dgvServer.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvServer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServer.Size = New System.Drawing.Size(939, 450)
        Me.dgvServer.TabIndex = 13
        '
        'serverid
        '
        Me.serverid.HeaderText = ""
        Me.serverid.Name = "serverid"
        Me.serverid.ReadOnly = True
        Me.serverid.Visible = False
        '
        'employeeid
        '
        Me.employeeid.FillWeight = 50.0!
        Me.employeeid.HeaderText = "ID Number"
        Me.employeeid.Name = "employeeid"
        Me.employeeid.ReadOnly = True
        '
        'fullname
        '
        Me.fullname.HeaderText = "Full Name"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        '
        'assigndeparment
        '
        Me.assigndeparment.HeaderText = "Department/Section"
        Me.assigndeparment.Name = "assigndeparment"
        Me.assigndeparment.ReadOnly = True
        '
        'accounttype
        '
        Me.accounttype.HeaderText = "Account Type"
        Me.accounttype.Name = "accounttype"
        Me.accounttype.ReadOnly = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.LimeGreen
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(10, 51)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(126, 52)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "NEW"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.LimeGreen
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(274, 51)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(126, 52)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(142, 51)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(126, 52)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "UPDATE "
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtTextFilter)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(677, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 52)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SEARCH"
        '
        'txtTextFilter
        '
        Me.txtTextFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTextFilter.Location = New System.Drawing.Point(3, 19)
        Me.txtTextFilter.Name = "txtTextFilter"
        Me.txtTextFilter.Size = New System.Drawing.Size(253, 23)
        Me.txtTextFilter.TabIndex = 18
        '
        'UserAccountStrip
        '
        Me.UserAccountStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewUserToolStripMenuItem, Me.UpdateUserToolStripMenuItem, Me.DeleteUserToolStripMenuItem, Me.ManageAssignedCountesToolStripMenuItem})
        Me.UserAccountStrip.Name = "UserAccountStrip"
        Me.UserAccountStrip.Size = New System.Drawing.Size(220, 92)
        '
        'NewUserToolStripMenuItem
        '
        Me.NewUserToolStripMenuItem.Name = "NewUserToolStripMenuItem"
        Me.NewUserToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.NewUserToolStripMenuItem.Text = "New User"
        '
        'UpdateUserToolStripMenuItem
        '
        Me.UpdateUserToolStripMenuItem.Name = "UpdateUserToolStripMenuItem"
        Me.UpdateUserToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.UpdateUserToolStripMenuItem.Text = "Update User"
        '
        'DeleteUserToolStripMenuItem
        '
        Me.DeleteUserToolStripMenuItem.Name = "DeleteUserToolStripMenuItem"
        Me.DeleteUserToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.DeleteUserToolStripMenuItem.Text = "Delete User"
        '
        'ManageAssignedCountesToolStripMenuItem
        '
        Me.ManageAssignedCountesToolStripMenuItem.Name = "ManageAssignedCountesToolStripMenuItem"
        Me.ManageAssignedCountesToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ManageAssignedCountesToolStripMenuItem.Text = "Manage Assigned Counters"
        '
        'btnManageCounter
        '
        Me.btnManageCounter.BackColor = System.Drawing.Color.LimeGreen
        Me.btnManageCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageCounter.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageCounter.ForeColor = System.Drawing.Color.White
        Me.btnManageCounter.Location = New System.Drawing.Point(406, 51)
        Me.btnManageCounter.Name = "btnManageCounter"
        Me.btnManageCounter.Size = New System.Drawing.Size(153, 52)
        Me.btnManageCounter.TabIndex = 20
        Me.btnManageCounter.Text = "COUNTERS"
        Me.btnManageCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnManageCounter.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(11, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 48)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(143, 53)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(275, 53)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(407, 53)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox4.TabIndex = 24
        Me.PictureBox4.TabStop = False
        '
        'UserAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnManageCounter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.dgvServer)
        Me.DoubleBuffered = True
        Me.Name = "UserAccount"
        Me.Size = New System.Drawing.Size(939, 559)
        CType(Me.dgvServer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.UserAccountStrip.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvServer As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtTextFilter As TextBox
    Friend WithEvents UserAccountStrip As ContextMenuStrip
    Friend WithEvents DeleteUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageAssignedCountesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnManageCounter As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents serverid As DataGridViewTextBoxColumn
    Friend WithEvents employeeid As DataGridViewTextBoxColumn
    Friend WithEvents fullname As DataGridViewTextBoxColumn
    Friend WithEvents assigndeparment As DataGridViewTextBoxColumn
    Friend WithEvents accounttype As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox4 As PictureBox
End Class
