<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCounterQueuingBoardQueueListAll
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounterQueuingBoardQueueListAll))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCounterName = New System.Windows.Forms.Label()
        Me.timerwelcome = New System.Windows.Forms.Timer(Me.components)
        Me.refreshDataIntertval = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.servingLbl6 = New System.Windows.Forms.Label()
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
        Me.lstQueueList = New System.Windows.Forms.ListView()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblCounterName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 84)
        Me.Panel1.TabIndex = 22
        '
        'lblCounterName
        '
        Me.lblCounterName.AutoSize = True
        Me.lblCounterName.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.lblCounterName.ForeColor = System.Drawing.Color.White
        Me.lblCounterName.Location = New System.Drawing.Point(-4, -1)
        Me.lblCounterName.Name = "lblCounterName"
        Me.lblCounterName.Size = New System.Drawing.Size(1768, 80)
        Me.lblCounterName.TabIndex = 1
        Me.lblCounterName.Text = "LIST OF PATIENT IN QUEUE FOR ALL DEPARTMENT            "
        '
        'timerwelcome
        '
        Me.timerwelcome.Enabled = True
        Me.timerwelcome.Interval = 500
        '
        'refreshDataIntertval
        '
        Me.refreshDataIntertval.Interval = 6000
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel21)
        Me.Panel6.Controls.Add(Me.Panel20)
        Me.Panel6.Controls.Add(Me.Panel12)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 84)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(354, 645)
        Me.Panel6.TabIndex = 25
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.Transparent
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.servingLbl6)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel21.Location = New System.Drawing.Point(0, 600)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(354, 99)
        Me.Panel21.TabIndex = 16
        '
        'servingLbl6
        '
        Me.servingLbl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl6.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl6.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl6.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl6.Name = "servingLbl6"
        Me.servingLbl6.Size = New System.Drawing.Size(352, 97)
        Me.servingLbl6.TabIndex = 0
        Me.servingLbl6.Text = "NONE"
        Me.servingLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.servingLbl5)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 500)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(354, 100)
        Me.Panel20.TabIndex = 15
        '
        'servingLbl5
        '
        Me.servingLbl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl5.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold)
        Me.servingLbl5.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl5.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl5.Name = "servingLbl5"
        Me.servingLbl5.Size = New System.Drawing.Size(352, 98)
        Me.servingLbl5.TabIndex = 0
        Me.servingLbl5.Text = "NONE"
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
        Me.Panel12.Size = New System.Drawing.Size(354, 100)
        Me.Panel12.TabIndex = 14
        '
        'servingLbl4
        '
        Me.servingLbl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl4.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servingLbl4.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl4.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl4.Name = "servingLbl4"
        Me.servingLbl4.Size = New System.Drawing.Size(352, 98)
        Me.servingLbl4.TabIndex = 0
        Me.servingLbl4.Text = "NONE"
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
        Me.Panel11.Size = New System.Drawing.Size(354, 100)
        Me.Panel11.TabIndex = 13
        '
        'servingLbl3
        '
        Me.servingLbl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl3.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servingLbl3.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl3.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl3.Name = "servingLbl3"
        Me.servingLbl3.Size = New System.Drawing.Size(352, 98)
        Me.servingLbl3.TabIndex = 0
        Me.servingLbl3.Text = "NONE"
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
        Me.Panel10.Size = New System.Drawing.Size(354, 100)
        Me.Panel10.TabIndex = 12
        '
        'servingLbl2
        '
        Me.servingLbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl2.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servingLbl2.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl2.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl2.Name = "servingLbl2"
        Me.servingLbl2.Size = New System.Drawing.Size(352, 98)
        Me.servingLbl2.TabIndex = 0
        Me.servingLbl2.Text = "NONE"
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
        Me.Panel9.Size = New System.Drawing.Size(354, 100)
        Me.Panel9.TabIndex = 11
        '
        'servingLbl1
        '
        Me.servingLbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl1.Font = New System.Drawing.Font("Century Gothic", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servingLbl1.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl1.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl1.Name = "servingLbl1"
        Me.servingLbl1.Size = New System.Drawing.Size(352, 98)
        Me.servingLbl1.TabIndex = 0
        Me.servingLbl1.Text = "NONE"
        Me.servingLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(354, 100)
        Me.Panel2.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(354, 100)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "SERVING"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstQueueList
        '
        Me.lstQueueList.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstQueueList.BackColor = System.Drawing.Color.AliceBlue
        Me.lstQueueList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstQueueList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstQueueList.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstQueueList.HideSelection = False
        Me.lstQueueList.HotTracking = True
        Me.lstQueueList.HoverSelection = True
        Me.lstQueueList.LargeImageList = Me.imgList
        Me.lstQueueList.Location = New System.Drawing.Point(354, 84)
        Me.lstQueueList.Name = "lstQueueList"
        Me.lstQueueList.Size = New System.Drawing.Size(1016, 645)
        Me.lstQueueList.SmallImageList = Me.imgList
        Me.lstQueueList.TabIndex = 26
        Me.lstQueueList.UseCompatibleStateImageBehavior = False
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "avatar blue.png")
        Me.imgList.Images.SetKeyName(1, "avatar red.png")
        Me.imgList.Images.SetKeyName(2, "avatar_blue_result")
        Me.imgList.Images.SetKeyName(3, "avatar_red_result")
        Me.imgList.Images.SetKeyName(4, "avatar blue1.png")
        Me.imgList.Images.SetKeyName(5, "avatar blue2.png")
        Me.imgList.Images.SetKeyName(6, "avatar blue3.png")
        Me.imgList.Images.SetKeyName(7, "avatar red1.png")
        Me.imgList.Images.SetKeyName(8, "avatar red2.png")
        Me.imgList.Images.SetKeyName(9, "avatar red3.png")
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.ForeColor = System.Drawing.Color.White
        Me.Panel4.Location = New System.Drawing.Point(530, 284)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(705, 150)
        Me.Panel4.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(705, 150)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOTHING ON QUEUE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCounterQueuingBoardQueueListAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 729)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lstQueueList)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounterQueuingBoardQueueListAll"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCounterName As Label
    Friend WithEvents timerwelcome As Timer
    Friend WithEvents refreshDataIntertval As Timer
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel21 As Panel
    Friend WithEvents servingLbl6 As Label
    Friend WithEvents Panel20 As Panel
    Friend WithEvents servingLbl5 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents servingLbl4 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents servingLbl3 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents servingLbl2 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents servingLbl1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lstQueueList As ListView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents imgList As ImageList
End Class
