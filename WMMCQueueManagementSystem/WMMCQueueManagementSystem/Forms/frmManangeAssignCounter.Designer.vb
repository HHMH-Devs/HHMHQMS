<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageServerAssignCounter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageServerAssignCounter))
        Me.lstCounters = New System.Windows.Forms.ListView()
        Me.lstAssignedCounters = New System.Windows.Forms.ListView()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.btnUnassign = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCounterName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCounters
        '
        Me.lstCounters.BackColor = System.Drawing.Color.Honeydew
        Me.lstCounters.HideSelection = False
        Me.lstCounters.Location = New System.Drawing.Point(8, 66)
        Me.lstCounters.Name = "lstCounters"
        Me.lstCounters.Size = New System.Drawing.Size(473, 369)
        Me.lstCounters.TabIndex = 0
        Me.lstCounters.UseCompatibleStateImageBehavior = False
        '
        'lstAssignedCounters
        '
        Me.lstAssignedCounters.BackColor = System.Drawing.Color.Honeydew
        Me.lstAssignedCounters.HideSelection = False
        Me.lstAssignedCounters.Location = New System.Drawing.Point(6, 66)
        Me.lstAssignedCounters.Name = "lstAssignedCounters"
        Me.lstAssignedCounters.Size = New System.Drawing.Size(474, 369)
        Me.lstAssignedCounters.TabIndex = 1
        Me.lstAssignedCounters.UseCompatibleStateImageBehavior = False
        '
        'btnAssign
        '
        Me.btnAssign.BackColor = System.Drawing.Color.LimeGreen
        Me.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssign.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssign.ForeColor = System.Drawing.Color.White
        Me.btnAssign.Location = New System.Drawing.Point(338, 19)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(143, 41)
        Me.btnAssign.TabIndex = 4
        Me.btnAssign.Text = "ADD"
        Me.btnAssign.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAssign.UseVisualStyleBackColor = False
        '
        'btnUnassign
        '
        Me.btnUnassign.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUnassign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnassign.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnassign.ForeColor = System.Drawing.Color.White
        Me.btnUnassign.Location = New System.Drawing.Point(332, 19)
        Me.btnUnassign.Name = "btnUnassign"
        Me.btnUnassign.Size = New System.Drawing.Size(148, 41)
        Me.btnUnassign.TabIndex = 5
        Me.btnUnassign.Text = "REMOVE"
        Me.btnUnassign.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnassign.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.Controls.Add(Me.lblCounterName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 515)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 89)
        Me.Panel1.TabIndex = 6
        '
        'lblCounterName
        '
        Me.lblCounterName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounterName.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterName.ForeColor = System.Drawing.Color.White
        Me.lblCounterName.Location = New System.Drawing.Point(0, 0)
        Me.lblCounterName.Name = "lblCounterName"
        Me.lblCounterName.Size = New System.Drawing.Size(989, 89)
        Me.lblCounterName.TabIndex = 0
        Me.lblCounterName.Text = "NO SELECTED COUNTER"
        Me.lblCounterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.lstCounters)
        Me.GroupBox1.Controls.Add(Me.btnAssign)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 441)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Available Counter"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(342, 23)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 33)
        Me.PictureBox4.TabIndex = 25
        Me.PictureBox4.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.btnUnassign)
        Me.GroupBox2.Controls.Add(Me.lstAssignedCounters)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(497, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(487, 441)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Assigned Counter"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LimeGreen
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(337, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 33)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel2.Controls.Add(Me.lblTittle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(989, 51)
        Me.Panel2.TabIndex = 18
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(989, 51)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "Manage Assigned Counters"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmManageServerAssignCounter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(989, 604)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageServerAssignCounter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstCounters As ListView
    Friend WithEvents lstAssignedCounters As ListView
    Friend WithEvents btnAssign As Button
    Friend WithEvents btnUnassign As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCounterName As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTittle As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
