<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCounterSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounterSelection))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSelectedDept = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblSelectableCounter = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnUnassign = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(656, 77)
        Me.Panel1.TabIndex = 11
        '
        'txtSelectedDept
        '
        Me.txtSelectedDept.BackColor = System.Drawing.Color.Transparent
        Me.txtSelectedDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSelectedDept.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedDept.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSelectedDept.Location = New System.Drawing.Point(0, 0)
        Me.txtSelectedDept.Name = "txtSelectedDept"
        Me.txtSelectedDept.Size = New System.Drawing.Size(656, 77)
        Me.txtSelectedDept.TabIndex = 5
        Me.txtSelectedDept.Text = "Please Select a Counter"
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
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSelectableCounter, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 591)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(656, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblSelectableCounter
        '
        Me.lblSelectableCounter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSelectableCounter.Name = "lblSelectableCounter"
        Me.lblSelectableCounter.Size = New System.Drawing.Size(13, 22)
        Me.lblSelectableCounter.Text = "0"
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
        Me.ToolStripLabel2.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel2.Text = "Selectable Counter:"
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.White
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.CheckBoxes = True
        Me.ListView1.HideSelection = False
        Me.ListView1.HotTracking = True
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(12, 83)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(632, 458)
        Me.ListView1.TabIndex = 14
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'btnUnassign
        '
        Me.btnUnassign.BackColor = System.Drawing.Color.LimeGreen
        Me.btnUnassign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnassign.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnassign.ForeColor = System.Drawing.Color.White
        Me.btnUnassign.Location = New System.Drawing.Point(252, 547)
        Me.btnUnassign.Name = "btnUnassign"
        Me.btnUnassign.Size = New System.Drawing.Size(152, 41)
        Me.btnUnassign.TabIndex = 27
        Me.btnUnassign.Text = "SELECT"
        Me.btnUnassign.UseVisualStyleBackColor = False
        '
        'frmCounterSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(656, 616)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnUnassign)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounterSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSelectedDept As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lblSelectableCounter As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents btnUnassign As Button
End Class
