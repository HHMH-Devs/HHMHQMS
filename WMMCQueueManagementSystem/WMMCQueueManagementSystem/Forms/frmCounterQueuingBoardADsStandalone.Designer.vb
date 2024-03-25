<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCounterQueuingBoardADsStandalone
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounterQueuingBoardADsStandalone))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtclock = New System.Windows.Forms.Label()
        Me.lblCounterName = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.servingLbl5 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.servingLbl4 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.servingLbl3 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.servingLbl2 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.servingLbl1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.counterlbl5 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.counterlbl4 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.counterlbl3 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.counterlbl2 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.counterlbl1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.refreshDataIntertval = New System.Windows.Forms.Timer(Me.components)
        Me.timerwelcome = New System.Windows.Forms.Timer(Me.components)
        Me.CLOCK = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtclock)
        Me.Panel1.Controls.Add(Me.lblCounterName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 84)
        Me.Panel1.TabIndex = 20
        '
        'txtclock
        '
        Me.txtclock.BackColor = System.Drawing.Color.LimeGreen
        Me.txtclock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtclock.Font = New System.Drawing.Font("Arial Narrow", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclock.ForeColor = System.Drawing.Color.White
        Me.txtclock.Location = New System.Drawing.Point(1019, 0)
        Me.txtclock.Name = "txtclock"
        Me.txtclock.Size = New System.Drawing.Size(351, 84)
        Me.txtclock.TabIndex = 46
        Me.txtclock.Text = "TIME"
        Me.txtclock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounterName
        '
        Me.lblCounterName.BackColor = System.Drawing.Color.LimeGreen
        Me.lblCounterName.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblCounterName.Font = New System.Drawing.Font("Arial", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterName.ForeColor = System.Drawing.Color.White
        Me.lblCounterName.Location = New System.Drawing.Point(0, 0)
        Me.lblCounterName.Name = "lblCounterName"
        Me.lblCounterName.Size = New System.Drawing.Size(1019, 84)
        Me.lblCounterName.TabIndex = 45
        Me.lblCounterName.Text = "DEPARTMENT BOARD"
        Me.lblCounterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel20)
        Me.Panel6.Controls.Add(Me.Panel12)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Location = New System.Drawing.Point(515, 84)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(382, 600)
        Me.Panel6.TabIndex = 23
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.servingLbl5)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 500)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(382, 100)
        Me.Panel20.TabIndex = 15
        '
        'servingLbl5
        '
        Me.servingLbl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl5.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl5.ForeColor = System.Drawing.Color.LimeGreen
        Me.servingLbl5.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl5.Name = "servingLbl5"
        Me.servingLbl5.Size = New System.Drawing.Size(380, 98)
        Me.servingLbl5.TabIndex = 0
        Me.servingLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.servingLbl4)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 400)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(382, 100)
        Me.Panel12.TabIndex = 14
        '
        'servingLbl4
        '
        Me.servingLbl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl4.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl4.ForeColor = System.Drawing.Color.LimeGreen
        Me.servingLbl4.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl4.Name = "servingLbl4"
        Me.servingLbl4.Size = New System.Drawing.Size(380, 98)
        Me.servingLbl4.TabIndex = 0
        Me.servingLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.servingLbl3)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 300)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(382, 100)
        Me.Panel11.TabIndex = 13
        '
        'servingLbl3
        '
        Me.servingLbl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl3.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl3.ForeColor = System.Drawing.Color.LimeGreen
        Me.servingLbl3.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl3.Name = "servingLbl3"
        Me.servingLbl3.Size = New System.Drawing.Size(380, 98)
        Me.servingLbl3.TabIndex = 0
        Me.servingLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.servingLbl2)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 200)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(382, 100)
        Me.Panel10.TabIndex = 12
        '
        'servingLbl2
        '
        Me.servingLbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl2.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl2.ForeColor = System.Drawing.Color.LimeGreen
        Me.servingLbl2.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl2.Name = "servingLbl2"
        Me.servingLbl2.Size = New System.Drawing.Size(380, 98)
        Me.servingLbl2.TabIndex = 0
        Me.servingLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.servingLbl1)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 100)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(382, 100)
        Me.Panel9.TabIndex = 11
        '
        'servingLbl1
        '
        Me.servingLbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl1.ForeColor = System.Drawing.Color.LimeGreen
        Me.servingLbl1.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl1.Name = "servingLbl1"
        Me.servingLbl1.Size = New System.Drawing.Size(380, 98)
        Me.servingLbl1.TabIndex = 0
        Me.servingLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(382, 100)
        Me.Panel2.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LimeGreen
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(382, 100)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "SERVING"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel18)
        Me.Panel7.Controls.Add(Me.Panel17)
        Me.Panel7.Controls.Add(Me.Panel16)
        Me.Panel7.Controls.Add(Me.Panel15)
        Me.Panel7.Controls.Add(Me.Panel13)
        Me.Panel7.Controls.Add(Me.Panel4)
        Me.Panel7.Location = New System.Drawing.Point(0, 84)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(515, 600)
        Me.Panel7.TabIndex = 24
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.Transparent
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.counterlbl5)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 500)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(515, 100)
        Me.Panel18.TabIndex = 14
        '
        'counterlbl5
        '
        Me.counterlbl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl5.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.counterlbl5.ForeColor = System.Drawing.Color.LimeGreen
        Me.counterlbl5.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl5.Name = "counterlbl5"
        Me.counterlbl5.Size = New System.Drawing.Size(513, 98)
        Me.counterlbl5.TabIndex = 0
        Me.counterlbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Transparent
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.counterlbl4)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(0, 400)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(515, 100)
        Me.Panel17.TabIndex = 13
        '
        'counterlbl4
        '
        Me.counterlbl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl4.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.counterlbl4.ForeColor = System.Drawing.Color.LimeGreen
        Me.counterlbl4.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl4.Name = "counterlbl4"
        Me.counterlbl4.Size = New System.Drawing.Size(513, 98)
        Me.counterlbl4.TabIndex = 0
        Me.counterlbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.counterlbl3)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 300)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(515, 100)
        Me.Panel16.TabIndex = 12
        '
        'counterlbl3
        '
        Me.counterlbl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl3.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.counterlbl3.ForeColor = System.Drawing.Color.LimeGreen
        Me.counterlbl3.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl3.Name = "counterlbl3"
        Me.counterlbl3.Size = New System.Drawing.Size(513, 98)
        Me.counterlbl3.TabIndex = 0
        Me.counterlbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.counterlbl2)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(0, 200)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(515, 100)
        Me.Panel15.TabIndex = 11
        '
        'counterlbl2
        '
        Me.counterlbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl2.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.counterlbl2.ForeColor = System.Drawing.Color.LimeGreen
        Me.counterlbl2.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl2.Name = "counterlbl2"
        Me.counterlbl2.Size = New System.Drawing.Size(513, 98)
        Me.counterlbl2.TabIndex = 0
        Me.counterlbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.counterlbl1)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 100)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(515, 100)
        Me.Panel13.TabIndex = 10
        '
        'counterlbl1
        '
        Me.counterlbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold)
        Me.counterlbl1.ForeColor = System.Drawing.Color.LimeGreen
        Me.counterlbl1.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl1.Name = "counterlbl1"
        Me.counterlbl1.Size = New System.Drawing.Size(513, 98)
        Me.counterlbl1.TabIndex = 0
        Me.counterlbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(515, 100)
        Me.Panel4.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LimeGreen
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(515, 100)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "COUNTER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'refreshDataIntertval
        '
        Me.refreshDataIntertval.Interval = 6000
        '
        'timerwelcome
        '
        Me.timerwelcome.Enabled = True
        Me.timerwelcome.Interval = 500
        '
        'CLOCK
        '
        Me.CLOCK.Interval = 30000
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel3.Location = New System.Drawing.Point(0, 685)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1370, 76)
        Me.Panel3.TabIndex = 30
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(898, 86)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(471, 598)
        Me.Panel5.TabIndex = 31
        '
        'frmCounterQueuingBoardADsStandalone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 741)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounterQueuingBoardADsStandalone"
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtclock As Label
    Friend WithEvents lblCounterName As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents counterlbl1 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents counterlbl2 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents counterlbl3 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents counterlbl4 As Label
    Friend WithEvents Panel18 As Panel
    Friend WithEvents counterlbl5 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents servingLbl1 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents servingLbl2 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents servingLbl3 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents servingLbl4 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents servingLbl5 As Label
    Friend WithEvents refreshDataIntertval As Timer
    Friend WithEvents timerwelcome As Timer
    Friend WithEvents CLOCK As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
End Class
