<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHomeMainCounterForTouch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHomeMainCounterForTouch))
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.printProgress = New System.Windows.Forms.ProgressBar()
        Me.progressText = New System.Windows.Forms.Label()
        Me.pnlProgress = New System.Windows.Forms.Panel()
        Me.pnlDoctorsDirectory = New System.Windows.Forms.Panel()
        Me.lblSort = New System.Windows.Forms.Label()
        Me.flpDoctorsList = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbNameFilter = New System.Windows.Forms.ComboBox()
        Me.pnlNoDoctorAlert = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.btnToogleLanguage = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlQRCodeAlertBox = New System.Windows.Forms.Panel()
        Me.pbGeneralError = New System.Windows.Forms.PictureBox()
        Me.pbSick = New System.Windows.Forms.PictureBox()
        Me.pbInvalidQR = New System.Windows.Forms.PictureBox()
        Me.msgQRAlert = New System.Windows.Forms.Label()
        Me.lstCustomCounter = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlProgress.SuspendLayout()
        Me.pnlDoctorsDirectory.SuspendLayout()
        Me.pnlNoDoctorAlert.SuspendLayout()
        Me.pnlQRCodeAlertBox.SuspendLayout()
        CType(Me.pbGeneralError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSick, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInvalidQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.lbl)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1368, 81)
        Me.Panel1.TabIndex = 4
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
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(275, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
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
        Me.lstFetchCounter.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFetchCounter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lstFetchCounter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstFetchCounter.HideSelection = False
        Me.lstFetchCounter.Location = New System.Drawing.Point(84, 250)
        Me.lstFetchCounter.MultiSelect = False
        Me.lstFetchCounter.Name = "lstFetchCounter"
        Me.lstFetchCounter.Size = New System.Drawing.Size(1200, 285)
        Me.lstFetchCounter.TabIndex = 50
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
        Me.ToolStrip1.TabIndex = 54
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
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem1.Text = "Settings"
        '
        'QueuingBoardsToolStripMenuItem
        '
        Me.QueuingBoardsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassicQueuingBoardToolStripMenuItem, Me.SelfAlarmQueuingBoardToolStripMenuItem, Me.MonitoringBoardToolStripMenuItem, Me.TestQueueBoardToolStripMenuItem})
        Me.QueuingBoardsToolStripMenuItem.Name = "QueuingBoardsToolStripMenuItem"
        Me.QueuingBoardsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.TestQueueBoardToolStripMenuItem.Text = "OCC Queue Board"
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
        Me.MinimizeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MinimizeToolStripMenuItem.Text = "Minimize/Hide"
        '
        'ChangeCounterToolStripMenuItem
        '
        Me.ChangeCounterToolStripMenuItem.Name = "ChangeCounterToolStripMenuItem"
        Me.ChangeCounterToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ChangeCounterToolStripMenuItem.Text = "Change Counter"
        '
        'tsLogout
        '
        Me.tsLogout.Name = "tsLogout"
        Me.tsLogout.Size = New System.Drawing.Size(180, 22)
        Me.tsLogout.Text = "Logout"
        '
        'tsExit
        '
        Me.tsExit.Name = "tsExit"
        Me.tsExit.Size = New System.Drawing.Size(180, 22)
        Me.tsExit.Text = "Exit Program"
        '
        'Timer1
        '
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
        'pnlProgress
        '
        Me.pnlProgress.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlProgress.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProgress.Controls.Add(Me.progressText)
        Me.pnlProgress.Controls.Add(Me.printProgress)
        Me.pnlProgress.Location = New System.Drawing.Point(402, 296)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(548, 182)
        Me.pnlProgress.TabIndex = 51
        Me.pnlProgress.Visible = False
        '
        'pnlDoctorsDirectory
        '
        Me.pnlDoctorsDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.pnlDoctorsDirectory.BackColor = System.Drawing.Color.White
        Me.pnlDoctorsDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDoctorsDirectory.Controls.Add(Me.lblSort)
        Me.pnlDoctorsDirectory.Controls.Add(Me.flpDoctorsList)
        Me.pnlDoctorsDirectory.Controls.Add(Me.cbNameFilter)
        Me.pnlDoctorsDirectory.Controls.Add(Me.pnlNoDoctorAlert)
        Me.pnlDoctorsDirectory.Controls.Add(Me.Button3)
        Me.pnlDoctorsDirectory.Location = New System.Drawing.Point(52, 87)
        Me.pnlDoctorsDirectory.Name = "pnlDoctorsDirectory"
        Me.pnlDoctorsDirectory.Size = New System.Drawing.Size(1265, 666)
        Me.pnlDoctorsDirectory.TabIndex = 55
        Me.pnlDoctorsDirectory.Visible = False
        '
        'lblSort
        '
        Me.lblSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSort.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblSort.ForeColor = System.Drawing.Color.Gray
        Me.lblSort.Location = New System.Drawing.Point(63, 16)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(842, 29)
        Me.lblSort.TabIndex = 2
        Me.lblSort.Text = "SORT DOCTOR'S NAME"
        Me.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpDoctorsList
        '
        Me.flpDoctorsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpDoctorsList.AutoScroll = True
        Me.flpDoctorsList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.flpDoctorsList.Location = New System.Drawing.Point(16, 56)
        Me.flpDoctorsList.Name = "flpDoctorsList"
        Me.flpDoctorsList.Size = New System.Drawing.Size(1234, 538)
        Me.flpDoctorsList.TabIndex = 28
        '
        'cbNameFilter
        '
        Me.cbNameFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbNameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNameFilter.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cbNameFilter.FormattingEnabled = True
        Me.cbNameFilter.Items.AddRange(New Object() {"-ALL NAME-", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"})
        Me.cbNameFilter.Location = New System.Drawing.Point(911, 13)
        Me.cbNameFilter.MaxDropDownItems = 15
        Me.cbNameFilter.Name = "cbNameFilter"
        Me.cbNameFilter.Size = New System.Drawing.Size(339, 37)
        Me.cbNameFilter.TabIndex = 59
        '
        'pnlNoDoctorAlert
        '
        Me.pnlNoDoctorAlert.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlNoDoctorAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNoDoctorAlert.Controls.Add(Me.Label1)
        Me.pnlNoDoctorAlert.Location = New System.Drawing.Point(44, 111)
        Me.pnlNoDoctorAlert.Name = "pnlNoDoctorAlert"
        Me.pnlNoDoctorAlert.Size = New System.Drawing.Size(1034, 117)
        Me.pnlNoDoctorAlert.TabIndex = 57
        Me.pnlNoDoctorAlert.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1032, 115)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "UNFORTUNATELY, NO AVAILABLE DOCTOR AT THE MOMENT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Location = New System.Drawing.Point(508, 600)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(247, 56)
        Me.Button3.TabIndex = 56
        Me.Button3.Text = "BACK"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblHelp
        '
        Me.lblHelp.BackColor = System.Drawing.Color.Transparent
        Me.lblHelp.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.Gray
        Me.lblHelp.Location = New System.Drawing.Point(28, 85)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(1313, 53)
        Me.lblHelp.TabIndex = 56
        Me.lblHelp.Text = "ANONG GUSTO MONG GAWIN?"
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
        Me.btnToogleLanguage.Location = New System.Drawing.Point(23, 700)
        Me.btnToogleLanguage.Name = "btnToogleLanguage"
        Me.btnToogleLanguage.Size = New System.Drawing.Size(214, 44)
        Me.btnToogleLanguage.TabIndex = 57
        Me.btnToogleLanguage.Text = "ENGLISH"
        Me.btnToogleLanguage.UseVisualStyleBackColor = False
        Me.btnToogleLanguage.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(220, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 56)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.pnlQRCodeAlertBox.Location = New System.Drawing.Point(340, 123)
        Me.pnlQRCodeAlertBox.Name = "pnlQRCodeAlertBox"
        Me.pnlQRCodeAlertBox.Size = New System.Drawing.Size(689, 550)
        Me.pnlQRCodeAlertBox.TabIndex = 59
        Me.pnlQRCodeAlertBox.Visible = False
        '
        'pbGeneralError
        '
        Me.pbGeneralError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbGeneralError.Image = CType(resources.GetObject("pbGeneralError.Image"), System.Drawing.Image)
        Me.pbGeneralError.Location = New System.Drawing.Point(234, 13)
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
        Me.pbSick.Location = New System.Drawing.Point(234, 13)
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
        Me.pbInvalidQR.Location = New System.Drawing.Point(234, 13)
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
        Me.msgQRAlert.Location = New System.Drawing.Point(10, 232)
        Me.msgQRAlert.Name = "msgQRAlert"
        Me.msgQRAlert.Size = New System.Drawing.Size(666, 230)
        Me.msgQRAlert.TabIndex = 58
        Me.msgQRAlert.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lstCustomCounter
        '
        Me.lstCustomCounter.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstCustomCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCustomCounter.BackColor = System.Drawing.Color.White
        Me.lstCustomCounter.BackgroundImageTiled = True
        Me.lstCustomCounter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCustomCounter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCustomCounter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lstCustomCounter.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstCustomCounter.HideSelection = False
        Me.lstCustomCounter.Location = New System.Drawing.Point(1035, 557)
        Me.lstCustomCounter.MultiSelect = False
        Me.lstCustomCounter.Name = "lstCustomCounter"
        Me.lstCustomCounter.Size = New System.Drawing.Size(321, 180)
        Me.lstCustomCounter.TabIndex = 61
        Me.lstCustomCounter.UseCompatibleStateImageBehavior = False
        '
        'frmHomeMainCounterForTouch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1368, 788)
        Me.Controls.Add(Me.pnlQRCodeAlertBox)
        Me.Controls.Add(Me.pnlProgress)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlDoctorsDirectory)
        Me.Controls.Add(Me.lstCustomCounter)
        Me.Controls.Add(Me.lstFetchCounter)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.btnToogleLanguage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmHomeMainCounterForTouch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlProgress.ResumeLayout(False)
        Me.pnlProgress.PerformLayout()
        Me.pnlDoctorsDirectory.ResumeLayout(False)
        Me.pnlNoDoctorAlert.ResumeLayout(False)
        Me.pnlQRCodeAlertBox.ResumeLayout(False)
        CType(Me.pbGeneralError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInvalidQR, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents MinimizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsLogout As ToolStripMenuItem
    Friend WithEvents tsExit As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents printProgress As ProgressBar
    Friend WithEvents progressText As Label
    Friend WithEvents pnlProgress As Panel
    Friend WithEvents MonitoringBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ThisDepartmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllDepartmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DepartmentSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeCounterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlDoctorsDirectory As Panel
    Friend WithEvents flpDoctorsList As FlowLayoutPanel
    Friend WithEvents Button3 As Button
    Friend WithEvents pnlNoDoctorAlert As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblHelp As Label
    Friend WithEvents cbNameFilter As ComboBox
    Friend WithEvents btnToogleLanguage As Button
    Friend WithEvents lblSort As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlQRCodeAlertBox As Panel
    Friend WithEvents msgQRAlert As Label
    Friend WithEvents pbInvalidQR As PictureBox
    Friend WithEvents pbSick As PictureBox
    Friend WithEvents TestQueueBoardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllCounterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllCounterAlertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClinicCounterAlertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lstCustomCounter As ListView
    Friend WithEvents pbGeneralError As PictureBox
End Class
