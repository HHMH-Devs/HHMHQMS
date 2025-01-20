<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.btnShowQueueHistory = New System.Windows.Forms.Button()
        Me.lblServedToday = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblCustomerToday = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnl = New System.Windows.Forms.Label()
        Me.btnShowAllQueueBoard = New System.Windows.Forms.Button()
        Me.pnlQueueBoardSelection = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnStatnaloneQueueBoard = New System.Windows.Forms.Button()
        Me.btnNormalQueueBoard = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DoctorSheds_lv = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblThisPcCounterName = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlQueueBoardSelection.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnShowQueueHistory
        '
        Me.btnShowQueueHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowQueueHistory.BackColor = System.Drawing.Color.SteelBlue
        Me.btnShowQueueHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowQueueHistory.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowQueueHistory.ForeColor = System.Drawing.Color.White
        Me.btnShowQueueHistory.Location = New System.Drawing.Point(1, 119)
        Me.btnShowQueueHistory.Name = "btnShowQueueHistory"
        Me.btnShowQueueHistory.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnShowQueueHistory.Size = New System.Drawing.Size(273, 61)
        Me.btnShowQueueHistory.TabIndex = 0
        Me.btnShowQueueHistory.Text = "Show Queue History"
        Me.btnShowQueueHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowQueueHistory.UseVisualStyleBackColor = False
        '
        'lblServedToday
        '
        Me.lblServedToday.BackColor = System.Drawing.Color.Transparent
        Me.lblServedToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblServedToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServedToday.ForeColor = System.Drawing.Color.Black
        Me.lblServedToday.Location = New System.Drawing.Point(85, 158)
        Me.lblServedToday.Name = "lblServedToday"
        Me.lblServedToday.Size = New System.Drawing.Size(109, 39)
        Me.lblServedToday.TabIndex = 6
        Me.lblServedToday.Text = "0"
        Me.lblServedToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(-1, 147)
        Me.Button5.Name = "Button5"
        Me.Button5.Padding = New System.Windows.Forms.Padding(30, 0, 0, 8)
        Me.Button5.Size = New System.Drawing.Size(283, 87)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "TOTAL TRANSACTIONS"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'lblCustomerToday
        '
        Me.lblCustomerToday.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCustomerToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerToday.ForeColor = System.Drawing.Color.Black
        Me.lblCustomerToday.Location = New System.Drawing.Point(84, 67)
        Me.lblCustomerToday.Name = "lblCustomerToday"
        Me.lblCustomerToday.Size = New System.Drawing.Size(109, 39)
        Me.lblCustomerToday.TabIndex = 4
        Me.lblCustomerToday.Text = "0"
        Me.lblCustomerToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Honeydew
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblCustomerToday)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblServedToday)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(651, 216)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(281, 239)
        Me.Panel1.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LimeGreen
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(-5, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 64)
        Me.Label8.TabIndex = 10
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LimeGreen
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-5, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 64)
        Me.Label3.TabIndex = 8
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(279, 49)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(279, 49)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "QUEUEING SUMMARY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(0, 55)
        Me.Button4.Name = "Button4"
        Me.Button4.Padding = New System.Windows.Forms.Padding(30, 0, 0, 8)
        Me.Button4.Size = New System.Drawing.Size(279, 87)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "TOTAL INDIVIDUAL PATIENT"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.btnShowQueueHistory)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.btnShowAllQueueBoard)
        Me.Panel3.Location = New System.Drawing.Point(651, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(281, 186)
        Me.Panel3.TabIndex = 6
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.SteelBlue
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(3, 121)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 57)
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Teal
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, 54)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 57)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel4.Controls.Add(Me.pnl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(279, 49)
        Me.Panel4.TabIndex = 0
        '
        'pnl
        '
        Me.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.pnl.ForeColor = System.Drawing.Color.White
        Me.pnl.Location = New System.Drawing.Point(0, 0)
        Me.pnl.Name = "pnl"
        Me.pnl.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.pnl.Size = New System.Drawing.Size(279, 49)
        Me.pnl.TabIndex = 0
        Me.pnl.Text = "QUEUING BOARDS"
        Me.pnl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnShowAllQueueBoard
        '
        Me.btnShowAllQueueBoard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowAllQueueBoard.BackColor = System.Drawing.Color.Teal
        Me.btnShowAllQueueBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowAllQueueBoard.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowAllQueueBoard.ForeColor = System.Drawing.Color.White
        Me.btnShowAllQueueBoard.Location = New System.Drawing.Point(3, 52)
        Me.btnShowAllQueueBoard.Name = "btnShowAllQueueBoard"
        Me.btnShowAllQueueBoard.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnShowAllQueueBoard.Size = New System.Drawing.Size(271, 61)
        Me.btnShowAllQueueBoard.TabIndex = 1
        Me.btnShowAllQueueBoard.Text = "Show All Queuing Board / Standalone"
        Me.btnShowAllQueueBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowAllQueueBoard.UseVisualStyleBackColor = False
        '
        'pnlQueueBoardSelection
        '
        Me.pnlQueueBoardSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlQueueBoardSelection.BackColor = System.Drawing.Color.White
        Me.pnlQueueBoardSelection.Controls.Add(Me.PictureBox4)
        Me.pnlQueueBoardSelection.Controls.Add(Me.PictureBox3)
        Me.pnlQueueBoardSelection.Controls.Add(Me.btnStatnaloneQueueBoard)
        Me.pnlQueueBoardSelection.Controls.Add(Me.btnNormalQueueBoard)
        Me.pnlQueueBoardSelection.Location = New System.Drawing.Point(654, 137)
        Me.pnlQueueBoardSelection.Name = "pnlQueueBoardSelection"
        Me.pnlQueueBoardSelection.Size = New System.Drawing.Size(272, 70)
        Me.pnlQueueBoardSelection.TabIndex = 8
        Me.pnlQueueBoardSelection.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.BackColor = System.Drawing.Color.Teal
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(2, 38)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox4.TabIndex = 9
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Teal
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(2, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'btnStatnaloneQueueBoard
        '
        Me.btnStatnaloneQueueBoard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStatnaloneQueueBoard.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnStatnaloneQueueBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatnaloneQueueBoard.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatnaloneQueueBoard.ForeColor = System.Drawing.Color.White
        Me.btnStatnaloneQueueBoard.Location = New System.Drawing.Point(1, 37)
        Me.btnStatnaloneQueueBoard.Name = "btnStatnaloneQueueBoard"
        Me.btnStatnaloneQueueBoard.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnStatnaloneQueueBoard.Size = New System.Drawing.Size(271, 36)
        Me.btnStatnaloneQueueBoard.TabIndex = 3
        Me.btnStatnaloneQueueBoard.Text = "Standalone Queuing Board"
        Me.btnStatnaloneQueueBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStatnaloneQueueBoard.UseVisualStyleBackColor = False
        '
        'btnNormalQueueBoard
        '
        Me.btnNormalQueueBoard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNormalQueueBoard.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnNormalQueueBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNormalQueueBoard.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNormalQueueBoard.ForeColor = System.Drawing.SystemColors.Window
        Me.btnNormalQueueBoard.Location = New System.Drawing.Point(1, 2)
        Me.btnNormalQueueBoard.Name = "btnNormalQueueBoard"
        Me.btnNormalQueueBoard.Padding = New System.Windows.Forms.Padding(60, 0, 0, 0)
        Me.btnNormalQueueBoard.Size = New System.Drawing.Size(271, 36)
        Me.btnNormalQueueBoard.TabIndex = 2
        Me.btnNormalQueueBoard.Text = "Normal Queuing Board"
        Me.btnNormalQueueBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNormalQueueBoard.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Honeydew
        Me.GroupBox3.Controls.Add(Me.TabControl1)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(629, 450)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 22)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(623, 425)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DoctorSheds_lv)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(615, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Doctors' Schedule"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DoctorSheds_lv
        '
        Me.DoctorSheds_lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.DoctorSheds_lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DoctorSheds_lv.FullRowSelect = True
        Me.DoctorSheds_lv.HideSelection = False
        Me.DoctorSheds_lv.Location = New System.Drawing.Point(3, 3)
        Me.DoctorSheds_lv.Name = "DoctorSheds_lv"
        Me.DoctorSheds_lv.Size = New System.Drawing.Size(609, 386)
        Me.DoctorSheds_lv.TabIndex = 0
        Me.DoctorSheds_lv.UseCompatibleStateImageBehavior = False
        Me.DoctorSheds_lv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Doctor's Name"
        Me.ColumnHeader1.Width = 235
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Moday"
        Me.ColumnHeader2.Width = 174
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Tuesday"
        Me.ColumnHeader3.Width = 160
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Wednesday"
        Me.ColumnHeader4.Width = 184
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Thursday"
        Me.ColumnHeader5.Width = 146
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Friday"
        Me.ColumnHeader6.Width = 141
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Saturday"
        Me.ColumnHeader7.Width = 159
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Sunday"
        Me.ColumnHeader8.Width = 186
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Honeydew
        Me.GroupBox1.Controls.Add(Me.lblThisPcCounterName)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 69)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "COMPUTER COUNTER NAME"
        '
        'lblThisPcCounterName
        '
        Me.lblThisPcCounterName.BackColor = System.Drawing.Color.Transparent
        Me.lblThisPcCounterName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblThisPcCounterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThisPcCounterName.ForeColor = System.Drawing.Color.Black
        Me.lblThisPcCounterName.Location = New System.Drawing.Point(18, 22)
        Me.lblThisPcCounterName.Name = "lblThisPcCounterName"
        Me.lblThisPcCounterName.Size = New System.Drawing.Size(467, 40)
        Me.lblThisPcCounterName.TabIndex = 11
        Me.lblThisPcCounterName.Text = "COUNTER NAME NOT SET"
        Me.lblThisPcCounterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.LimeGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(491, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(132, 45)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Rename Counter"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(651, 461)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(281, 88)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "OPEN QUEUING MONITORING SITE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.pnlQueueBoardSelection)
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.Name = "Dashboard"
        Me.Size = New System.Drawing.Size(939, 559)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.pnlQueueBoardSelection.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShowQueueHistory As Button
    Friend WithEvents lblCustomerToday As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents lblServedToday As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pnl As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnShowAllQueueBoard As Button
    Friend WithEvents pnlQueueBoardSelection As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnStatnaloneQueueBoard As Button
    Friend WithEvents btnNormalQueueBoard As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents lblThisPcCounterName As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DoctorSheds_lv As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
End Class
