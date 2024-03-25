<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCounterQueueBoard
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounterQueueBoard))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCounterName = New System.Windows.Forms.Label()
        Me.refreshDataIntertval = New System.Windows.Forms.Timer(Me.components)
        Me.imgicons = New System.Windows.Forms.ImageList(Me.components)
        Me.timerwelcome = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.flpCounterList = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.servingLbl1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.servingLbl2 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.servingLbl3 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.servingLbl4 = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.servingLbl5 = New System.Windows.Forms.Label()
        Me.flpServingList = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.counterlbl1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.counterlbl2 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.counterlbl3 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.counterlbl4 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.counterlbl5 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lbwelcome = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.flpCounterList.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.flpServingList.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.TabIndex = 4
        '
        'lblCounterName
        '
        Me.lblCounterName.BackColor = System.Drawing.Color.Transparent
        Me.lblCounterName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounterName.Font = New System.Drawing.Font("Arial", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterName.ForeColor = System.Drawing.Color.White
        Me.lblCounterName.Location = New System.Drawing.Point(0, 0)
        Me.lblCounterName.Name = "lblCounterName"
        Me.lblCounterName.Size = New System.Drawing.Size(1370, 84)
        Me.lblCounterName.TabIndex = 45
        Me.lblCounterName.Text = "DEPARTMENT BOARD"
        Me.lblCounterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'refreshDataIntertval
        '
        Me.refreshDataIntertval.Interval = 3000
        '
        'imgicons
        '
        Me.imgicons.ImageStream = CType(resources.GetObject("imgicons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgicons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgicons.Images.SetKeyName(0, "avatar blue.png")
        Me.imgicons.Images.SetKeyName(1, "avatar red.png")
        '
        'timerwelcome
        '
        Me.timerwelcome.Interval = 800
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1370, 100)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(413, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(508, 100)
        Me.Panel5.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(504, 96)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "COUNTER"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 100)
        Me.Panel4.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(411, 96)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "SERVING"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flpCounterList
        '
        Me.flpCounterList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flpCounterList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.flpCounterList.Controls.Add(Me.Panel6)
        Me.flpCounterList.Controls.Add(Me.Panel7)
        Me.flpCounterList.Controls.Add(Me.Panel8)
        Me.flpCounterList.Controls.Add(Me.Panel9)
        Me.flpCounterList.Controls.Add(Me.Panel19)
        Me.flpCounterList.Location = New System.Drawing.Point(0, 100)
        Me.flpCounterList.Name = "flpCounterList"
        Me.flpCounterList.Size = New System.Drawing.Size(413, 502)
        Me.flpCounterList.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.servingLbl1)
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(408, 93)
        Me.Panel6.TabIndex = 0
        '
        'servingLbl1
        '
        Me.servingLbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl1.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servingLbl1.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl1.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl1.Name = "servingLbl1"
        Me.servingLbl1.Size = New System.Drawing.Size(406, 91)
        Me.servingLbl1.TabIndex = 0
        Me.servingLbl1.Text = "NONE"
        Me.servingLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.servingLbl2)
        Me.Panel7.Location = New System.Drawing.Point(3, 102)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(408, 93)
        Me.Panel7.TabIndex = 1
        '
        'servingLbl2
        '
        Me.servingLbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl2.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.servingLbl2.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl2.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl2.Name = "servingLbl2"
        Me.servingLbl2.Size = New System.Drawing.Size(406, 91)
        Me.servingLbl2.TabIndex = 0
        Me.servingLbl2.Text = "NONE"
        Me.servingLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.servingLbl3)
        Me.Panel8.Location = New System.Drawing.Point(3, 201)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(408, 93)
        Me.Panel8.TabIndex = 2
        '
        'servingLbl3
        '
        Me.servingLbl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl3.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.servingLbl3.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl3.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl3.Name = "servingLbl3"
        Me.servingLbl3.Size = New System.Drawing.Size(406, 91)
        Me.servingLbl3.TabIndex = 0
        Me.servingLbl3.Text = "NONE"
        Me.servingLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Panel15)
        Me.Panel9.Controls.Add(Me.servingLbl4)
        Me.Panel9.Location = New System.Drawing.Point(3, 300)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(408, 93)
        Me.Panel9.TabIndex = 3
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.Label2)
        Me.Panel15.Location = New System.Drawing.Point(-1, 97)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(408, 93)
        Me.Panel15.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(406, 91)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "NONE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'servingLbl4
        '
        Me.servingLbl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl4.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.servingLbl4.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl4.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl4.Name = "servingLbl4"
        Me.servingLbl4.Size = New System.Drawing.Size(406, 91)
        Me.servingLbl4.TabIndex = 0
        Me.servingLbl4.Text = "NONE"
        Me.servingLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel19
        '
        Me.Panel19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel19.BackColor = System.Drawing.Color.Transparent
        Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel19.Controls.Add(Me.Panel20)
        Me.Panel19.Controls.Add(Me.servingLbl5)
        Me.Panel19.Location = New System.Drawing.Point(3, 399)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(408, 93)
        Me.Panel19.TabIndex = 5
        '
        'Panel20
        '
        Me.Panel20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel20.Controls.Add(Me.Label7)
        Me.Panel20.Location = New System.Drawing.Point(-1, 97)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(408, 93)
        Me.Panel20.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(406, 91)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "NONE"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'servingLbl5
        '
        Me.servingLbl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.servingLbl5.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.servingLbl5.ForeColor = System.Drawing.Color.DimGray
        Me.servingLbl5.Location = New System.Drawing.Point(0, 0)
        Me.servingLbl5.Name = "servingLbl5"
        Me.servingLbl5.Size = New System.Drawing.Size(406, 91)
        Me.servingLbl5.TabIndex = 0
        Me.servingLbl5.Text = "NONE"
        Me.servingLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flpServingList
        '
        Me.flpServingList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpServingList.Controls.Add(Me.Panel10)
        Me.flpServingList.Controls.Add(Me.Panel11)
        Me.flpServingList.Controls.Add(Me.Panel12)
        Me.flpServingList.Controls.Add(Me.Panel13)
        Me.flpServingList.Controls.Add(Me.Panel17)
        Me.flpServingList.Location = New System.Drawing.Point(412, 101)
        Me.flpServingList.Name = "flpServingList"
        Me.flpServingList.Size = New System.Drawing.Size(509, 501)
        Me.flpServingList.TabIndex = 2
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.counterlbl1)
        Me.Panel10.Location = New System.Drawing.Point(3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(504, 93)
        Me.Panel10.TabIndex = 1
        '
        'counterlbl1
        '
        Me.counterlbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl1.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.counterlbl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.counterlbl1.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl1.Name = "counterlbl1"
        Me.counterlbl1.Size = New System.Drawing.Size(502, 91)
        Me.counterlbl1.TabIndex = 0
        Me.counterlbl1.Text = "NONE"
        Me.counterlbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.counterlbl2)
        Me.Panel11.Location = New System.Drawing.Point(3, 102)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(501, 93)
        Me.Panel11.TabIndex = 2
        '
        'counterlbl2
        '
        Me.counterlbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl2.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.counterlbl2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.counterlbl2.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl2.Name = "counterlbl2"
        Me.counterlbl2.Size = New System.Drawing.Size(499, 91)
        Me.counterlbl2.TabIndex = 0
        Me.counterlbl2.Text = "NONE"
        Me.counterlbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.counterlbl3)
        Me.Panel12.Location = New System.Drawing.Point(3, 201)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(502, 93)
        Me.Panel12.TabIndex = 3
        '
        'counterlbl3
        '
        Me.counterlbl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl3.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.counterlbl3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.counterlbl3.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl3.Name = "counterlbl3"
        Me.counterlbl3.Size = New System.Drawing.Size(500, 91)
        Me.counterlbl3.TabIndex = 0
        Me.counterlbl3.Text = "NONE"
        Me.counterlbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.Panel16)
        Me.Panel13.Controls.Add(Me.counterlbl4)
        Me.Panel13.Location = New System.Drawing.Point(3, 300)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(501, 93)
        Me.Panel13.TabIndex = 4
        '
        'Panel16
        '
        Me.Panel16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.Label4)
        Me.Panel16.Location = New System.Drawing.Point(-1, 99)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(501, 93)
        Me.Panel16.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(499, 91)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "NONE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'counterlbl4
        '
        Me.counterlbl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl4.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.counterlbl4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.counterlbl4.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl4.Name = "counterlbl4"
        Me.counterlbl4.Size = New System.Drawing.Size(499, 91)
        Me.counterlbl4.TabIndex = 0
        Me.counterlbl4.Text = "NONE"
        Me.counterlbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel17.BackColor = System.Drawing.Color.Transparent
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.Panel18)
        Me.Panel17.Controls.Add(Me.counterlbl5)
        Me.Panel17.Location = New System.Drawing.Point(3, 399)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(501, 93)
        Me.Panel17.TabIndex = 6
        '
        'Panel18
        '
        Me.Panel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel18.BackColor = System.Drawing.Color.Transparent
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.Label5)
        Me.Panel18.Location = New System.Drawing.Point(-1, 99)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(501, 93)
        Me.Panel18.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(499, 91)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "NONE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'counterlbl5
        '
        Me.counterlbl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.counterlbl5.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.counterlbl5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.counterlbl5.Location = New System.Drawing.Point(0, 0)
        Me.counterlbl5.Name = "counterlbl5"
        Me.counterlbl5.Size = New System.Drawing.Size(499, 91)
        Me.counterlbl5.TabIndex = 0
        Me.counterlbl5.Text = "NONE"
        Me.counterlbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel14.Controls.Add(Me.lbwelcome)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel14.Location = New System.Drawing.Point(0, 498)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(1370, 159)
        Me.Panel14.TabIndex = 5
        '
        'lbwelcome
        '
        Me.lbwelcome.AutoSize = True
        Me.lbwelcome.Font = New System.Drawing.Font("Century Gothic", 50.25!, System.Drawing.FontStyle.Bold)
        Me.lbwelcome.ForeColor = System.Drawing.Color.White
        Me.lbwelcome.Location = New System.Drawing.Point(3, 31)
        Me.lbwelcome.Name = "lbwelcome"
        Me.lbwelcome.Size = New System.Drawing.Size(1580, 80)
        Me.lbwelcome.TabIndex = 0
        Me.lbwelcome.Text = "WELCOME TO WEST METRO MEDICAL CENTER       "
        Me.lbwelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Panel14)
        Me.Panel2.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.flpServingList)
        Me.Panel2.Controls.Add(Me.flpCounterList)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(0, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1370, 657)
        Me.Panel2.TabIndex = 5
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(927, 100)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(443, 460)
        Me.AxWindowsMediaPlayer1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(927, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(440, 96)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'frmCounterQueueBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 741)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounterQueueBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.flpCounterList.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.flpServingList.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCounterName As Label
    Friend WithEvents refreshDataIntertval As Timer
    Friend WithEvents imgicons As ImageList
    Friend WithEvents timerwelcome As Timer
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents flpCounterList As FlowLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents servingLbl1 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents servingLbl2 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents servingLbl3 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents servingLbl4 As Label
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents servingLbl5 As Label
    Friend WithEvents flpServingList As FlowLayoutPanel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents counterlbl1 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents counterlbl2 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents counterlbl3 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents counterlbl4 As Label
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents counterlbl5 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents lbwelcome As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
