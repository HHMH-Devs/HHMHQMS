<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHomeCounterSolo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHomeCounterSolo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lstFetchCounter = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsDate = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tsTime = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassicQueuingBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardADSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardLABRESULTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardSELECTEDCOUNTERSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelfAlarmQueuingBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardADSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardLABRESULTSToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueuingBoardALLCOUNTERSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonitoringBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThisDepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllDepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestQueueBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllCounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllCounterAlertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClinicCounterAlertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeCounterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.btnToogleLanguage = New System.Windows.Forms.Button()
        Me.pnlQRCodeAlertBox = New System.Windows.Forms.Panel()
        Me.pbGeneralError = New System.Windows.Forms.PictureBox()
        Me.pbSick = New System.Windows.Forms.PictureBox()
        Me.pbInvalidQR = New System.Windows.Forms.PictureBox()
        Me.msgQRAlert = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlProgress = New System.Windows.Forms.Panel()
        Me.progressText = New System.Windows.Forms.Label()
        Me.printProgress = New System.Windows.Forms.ProgressBar()
        Me.pnlConfirmGenerateNumber = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlQRCodeAlertBox.SuspendLayout()
        CType(Me.pbGeneralError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInvalidQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProgress.SuspendLayout()
        Me.pnlConfirmGenerateNumber.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.lbl)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1368, 81)
        Me.Panel1.TabIndex = 5
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl.Font = New System.Drawing.Font("Arial Narrow", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.White
        Me.lbl.Location = New System.Drawing.Point(275, 0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(1093, 81)
        Me.lbl.TabIndex = 44
        Me.lbl.Text = "PATIENT SELF-SERVICE QUEUE"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(275, 81)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lstFetchCounter
        '
        Me.lstFetchCounter.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstFetchCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lstFetchCounter.BackColor = System.Drawing.Color.White
        Me.lstFetchCounter.BackgroundImageTiled = True
        Me.lstFetchCounter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstFetchCounter.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFetchCounter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lstFetchCounter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstFetchCounter.HideSelection = False
        Me.lstFetchCounter.HotTracking = True
        Me.lstFetchCounter.HoverSelection = True
        Me.lstFetchCounter.Location = New System.Drawing.Point(522, 242)
        Me.lstFetchCounter.MultiSelect = False
        Me.lstFetchCounter.Name = "lstFetchCounter"
        Me.lstFetchCounter.Size = New System.Drawing.Size(325, 325)
        Me.lstFetchCounter.TabIndex = 51
        Me.lstFetchCounter.UseCompatibleStateImageBehavior = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.White
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDate, Me.ToolStripLabel3, Me.tsTime, Me.ToolStripDropDownButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 756)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1368, 32)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 55
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsDate
        '
        Me.tsDate.BackColor = System.Drawing.Color.White
        Me.tsDate.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.tsDate.ForeColor = System.Drawing.Color.Black
        Me.tsDate.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsDate.Name = "tsDate"
        Me.tsDate.Size = New System.Drawing.Size(66, 29)
        Me.tsDate.Text = "DATE"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(0, 29)
        Me.ToolStripLabel3.Text = "ToolStripLabel1"
        '
        'tsTime
        '
        Me.tsTime.BackColor = System.Drawing.Color.White
        Me.tsTime.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.tsTime.ForeColor = System.Drawing.Color.Black
        Me.tsTime.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tsTime.Name = "tsTime"
        Me.tsTime.Size = New System.Drawing.Size(59, 29)
        Me.tsTime.Text = "TIME"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ChangeCounterToolStripMenuItem, Me.tsLogout, Me.tsExit})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(13, 29)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueuingBoardsToolStripMenuItem, Me.MinimizeToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(161, 22)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'QueuingBoardsToolStripMenuItem
        '
        Me.QueuingBoardsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassicQueuingBoardToolStripMenuItem, Me.SelfAlarmQueuingBoardToolStripMenuItem, Me.MonitoringBoardToolStripMenuItem, Me.TestQueueBoardToolStripMenuItem})
        Me.QueuingBoardsToolStripMenuItem.Name = "QueuingBoardsToolStripMenuItem"
        Me.QueuingBoardsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.QueuingBoardsToolStripMenuItem.Text = "Queuing Boards"
        '
        'ClassicQueuingBoardToolStripMenuItem
        '
        Me.ClassicQueuingBoardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueuingBoardADSToolStripMenuItem, Me.QueuingBoardBILLINGSATUSToolStripMenuItem, Me.QueuingBoardLABRESULTSToolStripMenuItem, Me.ToolStripMenuItem5, Me.QueuingBoardSELECTEDCOUNTERSToolStripMenuItem})
        Me.ClassicQueuingBoardToolStripMenuItem.Name = "ClassicQueuingBoardToolStripMenuItem"
        Me.ClassicQueuingBoardToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ClassicQueuingBoardToolStripMenuItem.Text = "Classic Queuing Board"
        '
        'QueuingBoardADSToolStripMenuItem
        '
        Me.QueuingBoardADSToolStripMenuItem.Name = "QueuingBoardADSToolStripMenuItem"
        Me.QueuingBoardADSToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardADSToolStripMenuItem.Text = "Queuing Board (ADS)"
        '
        'QueuingBoardBILLINGSATUSToolStripMenuItem
        '
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem.Name = "QueuingBoardBILLINGSATUSToolStripMenuItem"
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem.Text = "Queuing Board (BILLING SATUS)"
        '
        'QueuingBoardLABRESULTSToolStripMenuItem
        '
        Me.QueuingBoardLABRESULTSToolStripMenuItem.Name = "QueuingBoardLABRESULTSToolStripMenuItem"
        Me.QueuingBoardLABRESULTSToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardLABRESULTSToolStripMenuItem.Text = "Queuing Board (LAB RESULTS)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem5.Text = "Queuing Board (SELECTED COUNTERS)"
        '
        'QueuingBoardSELECTEDCOUNTERSToolStripMenuItem
        '
        Me.QueuingBoardSELECTEDCOUNTERSToolStripMenuItem.Name = "QueuingBoardSELECTEDCOUNTERSToolStripMenuItem"
        Me.QueuingBoardSELECTEDCOUNTERSToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardSELECTEDCOUNTERSToolStripMenuItem.Text = "Queuing Board (ALL COUNTERS)"
        '
        'SelfAlarmQueuingBoardToolStripMenuItem
        '
        Me.SelfAlarmQueuingBoardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueuingBoardADSToolStripMenuItem1, Me.QueuingBoardBILLINGSATUSToolStripMenuItem1, Me.QueuingBoardLABRESULTSToolStripMenuItem1, Me.ToolStripMenuItem6, Me.QueuingBoardALLCOUNTERSToolStripMenuItem})
        Me.SelfAlarmQueuingBoardToolStripMenuItem.Name = "SelfAlarmQueuingBoardToolStripMenuItem"
        Me.SelfAlarmQueuingBoardToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SelfAlarmQueuingBoardToolStripMenuItem.Text = "Self Alarm Queuing Board"
        '
        'QueuingBoardADSToolStripMenuItem1
        '
        Me.QueuingBoardADSToolStripMenuItem1.Name = "QueuingBoardADSToolStripMenuItem1"
        Me.QueuingBoardADSToolStripMenuItem1.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardADSToolStripMenuItem1.Text = "Queuing Board (ADS)"
        '
        'QueuingBoardBILLINGSATUSToolStripMenuItem1
        '
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem1.Name = "QueuingBoardBILLINGSATUSToolStripMenuItem1"
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem1.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardBILLINGSATUSToolStripMenuItem1.Text = "Queuing Board (BILLING SATUS)"
        '
        'QueuingBoardLABRESULTSToolStripMenuItem1
        '
        Me.QueuingBoardLABRESULTSToolStripMenuItem1.Name = "QueuingBoardLABRESULTSToolStripMenuItem1"
        Me.QueuingBoardLABRESULTSToolStripMenuItem1.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardLABRESULTSToolStripMenuItem1.Text = "Queuing Board (LAB RESULTS)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(279, 22)
        Me.ToolStripMenuItem6.Text = "Queuing Board (SELECTED COUNTERS)"
        '
        'QueuingBoardALLCOUNTERSToolStripMenuItem
        '
        Me.QueuingBoardALLCOUNTERSToolStripMenuItem.Name = "QueuingBoardALLCOUNTERSToolStripMenuItem"
        Me.QueuingBoardALLCOUNTERSToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.QueuingBoardALLCOUNTERSToolStripMenuItem.Text = "Queuing Board (ALL COUNTERS)"
        '
        'MonitoringBoardToolStripMenuItem
        '
        Me.MonitoringBoardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThisDepartmentToolStripMenuItem, Me.AllDepartmentToolStripMenuItem, Me.DepartmentSummaryToolStripMenuItem})
        Me.MonitoringBoardToolStripMenuItem.Name = "MonitoringBoardToolStripMenuItem"
        Me.MonitoringBoardToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.MonitoringBoardToolStripMenuItem.Text = "Monitoring Board"
        '
        'ThisDepartmentToolStripMenuItem
        '
        Me.ThisDepartmentToolStripMenuItem.Name = "ThisDepartmentToolStripMenuItem"
        Me.ThisDepartmentToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ThisDepartmentToolStripMenuItem.Text = "This Department"
        '
        'AllDepartmentToolStripMenuItem
        '
        Me.AllDepartmentToolStripMenuItem.Name = "AllDepartmentToolStripMenuItem"
        Me.AllDepartmentToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AllDepartmentToolStripMenuItem.Text = "All Department"
        '
        'DepartmentSummaryToolStripMenuItem
        '
        Me.DepartmentSummaryToolStripMenuItem.Name = "DepartmentSummaryToolStripMenuItem"
        Me.DepartmentSummaryToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.DepartmentSummaryToolStripMenuItem.Text = "Department Summary"
        '
        'TestQueueBoardToolStripMenuItem
        '
        Me.TestQueueBoardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllCounterToolStripMenuItem, Me.AllCounterAlertToolStripMenuItem, Me.ClinicCounterAlertToolStripMenuItem})
        Me.TestQueueBoardToolStripMenuItem.Name = "TestQueueBoardToolStripMenuItem"
        Me.TestQueueBoardToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.TestQueueBoardToolStripMenuItem.Text = "Test Queue Board"
        '
        'AllCounterToolStripMenuItem
        '
        Me.AllCounterToolStripMenuItem.Name = "AllCounterToolStripMenuItem"
        Me.AllCounterToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AllCounterToolStripMenuItem.Text = "All Counter"
        '
        'AllCounterAlertToolStripMenuItem
        '
        Me.AllCounterAlertToolStripMenuItem.Name = "AllCounterAlertToolStripMenuItem"
        Me.AllCounterAlertToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AllCounterAlertToolStripMenuItem.Text = "All Counter - Alert"
        '
        'ClinicCounterAlertToolStripMenuItem
        '
        Me.ClinicCounterAlertToolStripMenuItem.Name = "ClinicCounterAlertToolStripMenuItem"
        Me.ClinicCounterAlertToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ClinicCounterAlertToolStripMenuItem.Text = "Clinic Counter - Alert"
        '
        'MinimizeToolStripMenuItem
        '
        Me.MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem"
        Me.MinimizeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.MinimizeToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.MinimizeToolStripMenuItem.Text = "Minimize/Hide"
        '
        'ChangeCounterToolStripMenuItem
        '
        Me.ChangeCounterToolStripMenuItem.Name = "ChangeCounterToolStripMenuItem"
        Me.ChangeCounterToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ChangeCounterToolStripMenuItem.Text = "Change Counter"
        '
        'tsLogout
        '
        Me.tsLogout.Name = "tsLogout"
        Me.tsLogout.Size = New System.Drawing.Size(161, 22)
        Me.tsLogout.Text = "Logout"
        '
        'tsExit
        '
        Me.tsExit.Name = "tsExit"
        Me.tsExit.Size = New System.Drawing.Size(161, 22)
        Me.tsExit.Text = "Exit Program"
        '
        'lblHelp
        '
        Me.lblHelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHelp.BackColor = System.Drawing.Color.Transparent
        Me.lblHelp.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.Gray
        Me.lblHelp.Location = New System.Drawing.Point(21, 86)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(1326, 74)
        Me.lblHelp.TabIndex = 57
        Me.lblHelp.Text = "PLEASE CLICK THE ICON TO GENERATE A NUMBER"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnToogleLanguage
        '
        Me.btnToogleLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnToogleLanguage.BackColor = System.Drawing.Color.Gray
        Me.btnToogleLanguage.FlatAppearance.BorderSize = 0
        Me.btnToogleLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToogleLanguage.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToogleLanguage.ForeColor = System.Drawing.Color.White
        Me.btnToogleLanguage.Location = New System.Drawing.Point(23, 706)
        Me.btnToogleLanguage.Name = "btnToogleLanguage"
        Me.btnToogleLanguage.Size = New System.Drawing.Size(214, 44)
        Me.btnToogleLanguage.TabIndex = 58
        Me.btnToogleLanguage.Text = "ENGLISH"
        Me.btnToogleLanguage.UseVisualStyleBackColor = False
        Me.btnToogleLanguage.Visible = False
        '
        'pnlQRCodeAlertBox
        '
        Me.pnlQRCodeAlertBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlQRCodeAlertBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlQRCodeAlertBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQRCodeAlertBox.Controls.Add(Me.pbGeneralError)
        Me.pnlQRCodeAlertBox.Controls.Add(Me.pbSick)
        Me.pnlQRCodeAlertBox.Controls.Add(Me.pbInvalidQR)
        Me.pnlQRCodeAlertBox.Controls.Add(Me.msgQRAlert)
        Me.pnlQRCodeAlertBox.Controls.Add(Me.Button1)
        Me.pnlQRCodeAlertBox.Location = New System.Drawing.Point(340, 122)
        Me.pnlQRCodeAlertBox.Name = "pnlQRCodeAlertBox"
        Me.pnlQRCodeAlertBox.Size = New System.Drawing.Size(689, 531)
        Me.pnlQRCodeAlertBox.TabIndex = 60
        Me.pnlQRCodeAlertBox.Visible = False
        '
        'pbGeneralError
        '
        Me.pbGeneralError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbGeneralError.Image = CType(resources.GetObject("pbGeneralError.Image"), System.Drawing.Image)
        Me.pbGeneralError.Location = New System.Drawing.Point(241, 13)
        Me.pbGeneralError.Name = "pbGeneralError"
        Me.pbGeneralError.Size = New System.Drawing.Size(204, 199)
        Me.pbGeneralError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGeneralError.TabIndex = 61
        Me.pbGeneralError.TabStop = False
        Me.pbGeneralError.Visible = False
        '
        'pbSick
        '
        Me.pbSick.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbSick.Image = CType(resources.GetObject("pbSick.Image"), System.Drawing.Image)
        Me.pbSick.Location = New System.Drawing.Point(241, 13)
        Me.pbSick.Name = "pbSick"
        Me.pbSick.Size = New System.Drawing.Size(204, 199)
        Me.pbSick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSick.TabIndex = 60
        Me.pbSick.TabStop = False
        Me.pbSick.Visible = False
        '
        'pbInvalidQR
        '
        Me.pbInvalidQR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbInvalidQR.Image = CType(resources.GetObject("pbInvalidQR.Image"), System.Drawing.Image)
        Me.pbInvalidQR.Location = New System.Drawing.Point(241, 13)
        Me.pbInvalidQR.Name = "pbInvalidQR"
        Me.pbInvalidQR.Size = New System.Drawing.Size(204, 199)
        Me.pbInvalidQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbInvalidQR.TabIndex = 59
        Me.pbInvalidQR.TabStop = False
        Me.pbInvalidQR.Visible = False
        Me.pbInvalidQR.WaitOnLoad = True
        '
        'msgQRAlert
        '
        Me.msgQRAlert.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.msgQRAlert.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.msgQRAlert.ForeColor = System.Drawing.Color.Maroon
        Me.msgQRAlert.Location = New System.Drawing.Point(10, 230)
        Me.msgQRAlert.Name = "msgQRAlert"
        Me.msgQRAlert.Size = New System.Drawing.Size(666, 231)
        Me.msgQRAlert.TabIndex = 58
        Me.msgQRAlert.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(220, 464)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 56)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'pnlProgress
        '
        Me.pnlProgress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlProgress.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProgress.Controls.Add(Me.progressText)
        Me.pnlProgress.Controls.Add(Me.printProgress)
        Me.pnlProgress.Location = New System.Drawing.Point(410, 303)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(548, 182)
        Me.pnlProgress.TabIndex = 61
        Me.pnlProgress.Visible = False
        '
        'progressText
        '
        Me.progressText.AutoSize = True
        Me.progressText.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.progressText.ForeColor = System.Drawing.Color.Gray
        Me.progressText.Location = New System.Drawing.Point(29, 47)
        Me.progressText.Name = "progressText"
        Me.progressText.Size = New System.Drawing.Size(268, 29)
        Me.progressText.TabIndex = 1
        Me.progressText.Text = "PRINTING, PLEASE WAIT...."
        '
        'printProgress
        '
        Me.printProgress.Location = New System.Drawing.Point(18, 102)
        Me.printProgress.Minimum = 1
        Me.printProgress.Name = "printProgress"
        Me.printProgress.Size = New System.Drawing.Size(513, 23)
        Me.printProgress.Step = 100
        Me.printProgress.TabIndex = 0
        Me.printProgress.Value = 1
        '
        'pnlConfirmGenerateNumber
        '
        Me.pnlConfirmGenerateNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlConfirmGenerateNumber.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlConfirmGenerateNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlConfirmGenerateNumber.Controls.Add(Me.PictureBox3)
        Me.pnlConfirmGenerateNumber.Controls.Add(Me.Button3)
        Me.pnlConfirmGenerateNumber.Controls.Add(Me.PictureBox4)
        Me.pnlConfirmGenerateNumber.Controls.Add(Me.Label1)
        Me.pnlConfirmGenerateNumber.Controls.Add(Me.Button2)
        Me.pnlConfirmGenerateNumber.Location = New System.Drawing.Point(340, 194)
        Me.pnlConfirmGenerateNumber.Name = "pnlConfirmGenerateNumber"
        Me.pnlConfirmGenerateNumber.Size = New System.Drawing.Size(689, 416)
        Me.pnlConfirmGenerateNumber.TabIndex = 63
        Me.pnlConfirmGenerateNumber.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(86, 349)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(247, 56)
        Me.Button3.TabIndex = 61
        Me.Button3.Text = "CANCEL"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(241, 13)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(204, 199)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 60
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(241, 13)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(204, 199)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 59
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        Me.PictureBox4.WaitOnLoad = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(10, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(666, 105)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "DO YOU WANT TO GENERATE A QUEUE NUMBER?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(354, 349)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(247, 56)
        Me.Button2.TabIndex = 57
        Me.Button2.Text = "PROCEED"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmHomeCounterSolo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1368, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlProgress)
        Me.Controls.Add(Me.pnlQRCodeAlertBox)
        Me.Controls.Add(Me.btnToogleLanguage)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlConfirmGenerateNumber)
        Me.Controls.Add(Me.lstFetchCounter)
        Me.Controls.Add(Me.lblHelp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHomeCounterSolo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlQRCodeAlertBox.ResumeLayout(False)
        CType(Me.pbGeneralError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInvalidQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProgress.ResumeLayout(False)
        Me.pnlProgress.PerformLayout()
        Me.pnlConfirmGenerateNumber.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lstFetchCounter As ListView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsDate As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents tsTime As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents QueuingBoardsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassicQueuingBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueuingBoardADSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueuingBoardBILLINGSATUSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueuingBoardLABRESULTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents QueuingBoardSELECTEDCOUNTERSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelfAlarmQueuingBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueuingBoardADSToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents QueuingBoardBILLINGSATUSToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents QueuingBoardLABRESULTSToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents QueuingBoardALLCOUNTERSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonitoringBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ThisDepartmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllDepartmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartmentSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestQueueBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllCounterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllCounterAlertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClinicCounterAlertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MinimizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeCounterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsLogout As ToolStripMenuItem
    Friend WithEvents tsExit As ToolStripMenuItem
    Friend WithEvents lblHelp As Label
    Friend WithEvents btnToogleLanguage As Button
    Friend WithEvents pnlQRCodeAlertBox As Panel
    Friend WithEvents pbGeneralError As PictureBox
    Friend WithEvents pbSick As PictureBox
    Friend WithEvents pbInvalidQR As PictureBox
    Friend WithEvents msgQRAlert As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pnlProgress As Panel
    Friend WithEvents progressText As Label
    Friend WithEvents printProgress As ProgressBar
    Friend WithEvents pnlConfirmGenerateNumber As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
End Class
