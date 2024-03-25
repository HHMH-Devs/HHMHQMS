<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateERTriageForm
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
        Me.pdfViewer = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.dtpBirthDate = New System.Windows.Forms.TextBox()
        Me.txtSex = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtAddress = New System.Windows.Forms.RichTextBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.txtOtherReligion = New System.Windows.Forms.TextBox()
        Me.cbOtheReligion = New System.Windows.Forms.RadioButton()
        Me.cbINC = New System.Windows.Forms.RadioButton()
        Me.cbSDA = New System.Windows.Forms.RadioButton()
        Me.cbProtestant = New System.Windows.Forms.RadioButton()
        Me.cbIslam = New System.Windows.Forms.RadioButton()
        Me.cbRomanCatholic = New System.Windows.Forms.RadioButton()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.cbChild = New System.Windows.Forms.RadioButton()
        Me.cbWidowed = New System.Windows.Forms.RadioButton()
        Me.cbSeparated = New System.Windows.Forms.RadioButton()
        Me.cbMarried = New System.Windows.Forms.RadioButton()
        Me.cbSingle = New System.Windows.Forms.RadioButton()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.txtContact_Watchers = New System.Windows.Forms.TextBox()
        Me.txtPatientNo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtCaseno = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtBedNo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbCaseType_RESPI = New System.Windows.Forms.RadioButton()
        Me.cbCaseType_GCB = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtp_ModeOfArrivalTimeOfDispatched = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp_ModeOfArrivalTimeOfCall = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmbulance = New System.Windows.Forms.TextBox()
        Me.cbModeOfArrival_AmbulanceCall = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_Ambulance = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_Barangay = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_Police = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_Public = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_Personal = New System.Windows.Forms.RadioButton()
        Me.cbModeOfArrival_WalkIn = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbLevelOfConsiousness_Unconscious = New System.Windows.Forms.RadioButton()
        Me.cbLevelOfConsiousness_Stuporous = New System.Windows.Forms.RadioButton()
        Me.cbLevelOfConsiousness_Lethargic = New System.Windows.Forms.RadioButton()
        Me.cbLevelOfConsiousness_Conscious = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpTimeEndorseUnit = New System.Windows.Forms.DateTimePicker()
        Me.dtpTimeSeenROD = New System.Windows.Forms.DateTimePicker()
        Me.dtpTimeEndorseROD = New System.Windows.Forms.DateTimePicker()
        Me.dtpTimeOfArrival = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cbClass_NonUrgent = New System.Windows.Forms.RadioButton()
        Me.cbClass_Urgent = New System.Windows.Forms.RadioButton()
        Me.cbClass_Critical = New System.Windows.Forms.RadioButton()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtVaccine_Booster = New System.Windows.Forms.TextBox()
        Me.txtVaccine_Dose2 = New System.Windows.Forms.TextBox()
        Me.txtVaccine_Dose1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtTravelHistory = New System.Windows.Forms.RichTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDuty_Carried = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTimpStamp_ROD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDuty_Nurse = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MySqlDataAdapter1 = New MySql.Data.MySqlClient.MySqlDataAdapter()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pdfViewer
        '
        Me.pdfViewer.BackColor = System.Drawing.Color.White
        Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pdfViewer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pdfViewer.Location = New System.Drawing.Point(0, 0)
        Me.pdfViewer.MultiPagesThreshold = 60
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.Size = New System.Drawing.Size(864, 690)
        Me.pdfViewer.TabIndex = 14
        Me.pdfViewer.Text = "PdfDocumentViewer1"
        Me.pdfViewer.Threshold = 60
        Me.pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(864, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(367, 690)
        Me.Panel1.TabIndex = 58
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox12)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox13)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox15)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox16)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox14)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox10)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox6)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox7)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox9)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox11)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(367, 585)
        Me.FlowLayoutPanel1.TabIndex = 53
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox12.BackColor = System.Drawing.Color.White
        Me.GroupBox12.Controls.Add(Me.dtpBirthDate)
        Me.GroupBox12.Controls.Add(Me.txtSex)
        Me.GroupBox12.Controls.Add(Me.Label17)
        Me.GroupBox12.Controls.Add(Me.Label16)
        Me.GroupBox12.Controls.Add(Me.txtLastName)
        Me.GroupBox12.Controls.Add(Me.txtMiddleName)
        Me.GroupBox12.Controls.Add(Me.txtFirstName)
        Me.GroupBox12.Controls.Add(Me.Label10)
        Me.GroupBox12.Controls.Add(Me.Label14)
        Me.GroupBox12.Controls.Add(Me.Label15)
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox12.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(344, 173)
        Me.GroupBox12.TabIndex = 173
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "PATIENT PROFILE (NOT EDITABLE)"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.dtpBirthDate.Location = New System.Drawing.Point(154, 114)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ReadOnly = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(187, 22)
        Me.dtpBirthDate.TabIndex = 71
        '
        'txtSex
        '
        Me.txtSex.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtSex.Location = New System.Drawing.Point(154, 141)
        Me.txtSex.Name = "txtSex"
        Me.txtSex.ReadOnly = True
        Me.txtSex.Size = New System.Drawing.Size(187, 22)
        Me.txtSex.TabIndex = 70
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 16)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "SEX: "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(6, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 16)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "BIRTHDAY: "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtLastName.Location = New System.Drawing.Point(154, 80)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.Size = New System.Drawing.Size(187, 22)
        Me.txtLastName.TabIndex = 65
        '
        'txtMiddleName
        '
        Me.txtMiddleName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtMiddleName.Location = New System.Drawing.Point(154, 52)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.ReadOnly = True
        Me.txtMiddleName.Size = New System.Drawing.Size(187, 22)
        Me.txtMiddleName.TabIndex = 64
        '
        'txtFirstName
        '
        Me.txtFirstName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtFirstName.Location = New System.Drawing.Point(154, 24)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.Size = New System.Drawing.Size(187, 22)
        Me.txtFirstName.TabIndex = 63
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 16)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "LAST NAME: "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 16)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "MIDDLE NAME: "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(6, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 16)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "FIRST NAME: "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox13
        '
        Me.GroupBox13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox13.BackColor = System.Drawing.Color.White
        Me.GroupBox13.Controls.Add(Me.txtAddress)
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox13.Location = New System.Drawing.Point(3, 182)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(344, 85)
        Me.GroupBox13.TabIndex = 174
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "ADDRESS (NOT EDITABLE)"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAddress.Location = New System.Drawing.Point(3, 18)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(338, 64)
        Me.txtAddress.TabIndex = 3
        Me.txtAddress.Text = ""
        '
        'GroupBox15
        '
        Me.GroupBox15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox15.BackColor = System.Drawing.Color.White
        Me.GroupBox15.Controls.Add(Me.txtOtherReligion)
        Me.GroupBox15.Controls.Add(Me.cbOtheReligion)
        Me.GroupBox15.Controls.Add(Me.cbINC)
        Me.GroupBox15.Controls.Add(Me.cbSDA)
        Me.GroupBox15.Controls.Add(Me.cbProtestant)
        Me.GroupBox15.Controls.Add(Me.cbIslam)
        Me.GroupBox15.Controls.Add(Me.cbRomanCatholic)
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox15.Location = New System.Drawing.Point(3, 273)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(344, 213)
        Me.GroupBox15.TabIndex = 176
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "RELIGION"
        '
        'txtOtherReligion
        '
        Me.txtOtherReligion.BackColor = System.Drawing.Color.Ivory
        Me.txtOtherReligion.Location = New System.Drawing.Point(165, 173)
        Me.txtOtherReligion.Name = "txtOtherReligion"
        Me.txtOtherReligion.Size = New System.Drawing.Size(173, 22)
        Me.txtOtherReligion.TabIndex = 65
        '
        'cbOtheReligion
        '
        Me.cbOtheReligion.Location = New System.Drawing.Point(24, 174)
        Me.cbOtheReligion.Name = "cbOtheReligion"
        Me.cbOtheReligion.Size = New System.Drawing.Size(135, 20)
        Me.cbOtheReligion.TabIndex = 7
        Me.cbOtheReligion.TabStop = True
        Me.cbOtheReligion.Text = "OTHERS"
        Me.cbOtheReligion.UseVisualStyleBackColor = True
        '
        'cbINC
        '
        Me.cbINC.Location = New System.Drawing.Point(24, 145)
        Me.cbINC.Name = "cbINC"
        Me.cbINC.Size = New System.Drawing.Size(297, 20)
        Me.cbINC.TabIndex = 6
        Me.cbINC.TabStop = True
        Me.cbINC.Text = "INC"
        Me.cbINC.UseVisualStyleBackColor = True
        '
        'cbSDA
        '
        Me.cbSDA.Location = New System.Drawing.Point(24, 116)
        Me.cbSDA.Name = "cbSDA"
        Me.cbSDA.Size = New System.Drawing.Size(297, 20)
        Me.cbSDA.TabIndex = 5
        Me.cbSDA.TabStop = True
        Me.cbSDA.Text = "SDA"
        Me.cbSDA.UseVisualStyleBackColor = True
        '
        'cbProtestant
        '
        Me.cbProtestant.Location = New System.Drawing.Point(24, 87)
        Me.cbProtestant.Name = "cbProtestant"
        Me.cbProtestant.Size = New System.Drawing.Size(297, 20)
        Me.cbProtestant.TabIndex = 4
        Me.cbProtestant.TabStop = True
        Me.cbProtestant.Text = "PROTENSTANT"
        Me.cbProtestant.UseVisualStyleBackColor = True
        '
        'cbIslam
        '
        Me.cbIslam.Location = New System.Drawing.Point(24, 58)
        Me.cbIslam.Name = "cbIslam"
        Me.cbIslam.Size = New System.Drawing.Size(297, 20)
        Me.cbIslam.TabIndex = 3
        Me.cbIslam.TabStop = True
        Me.cbIslam.Text = "ISLAM"
        Me.cbIslam.UseVisualStyleBackColor = True
        '
        'cbRomanCatholic
        '
        Me.cbRomanCatholic.Location = New System.Drawing.Point(24, 29)
        Me.cbRomanCatholic.Name = "cbRomanCatholic"
        Me.cbRomanCatholic.Size = New System.Drawing.Size(297, 20)
        Me.cbRomanCatholic.TabIndex = 2
        Me.cbRomanCatholic.TabStop = True
        Me.cbRomanCatholic.Text = "ROMAN CATHOLIC"
        Me.cbRomanCatholic.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox16.BackColor = System.Drawing.Color.White
        Me.GroupBox16.Controls.Add(Me.cbChild)
        Me.GroupBox16.Controls.Add(Me.cbWidowed)
        Me.GroupBox16.Controls.Add(Me.cbSeparated)
        Me.GroupBox16.Controls.Add(Me.cbMarried)
        Me.GroupBox16.Controls.Add(Me.cbSingle)
        Me.GroupBox16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox16.Location = New System.Drawing.Point(3, 492)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(344, 178)
        Me.GroupBox16.TabIndex = 177
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Tag = " "
        Me.GroupBox16.Text = "CIVIL STATUS (NOT EDITABLE)"
        '
        'cbChild
        '
        Me.cbChild.Enabled = False
        Me.cbChild.Location = New System.Drawing.Point(24, 145)
        Me.cbChild.Name = "cbChild"
        Me.cbChild.Size = New System.Drawing.Size(297, 20)
        Me.cbChild.TabIndex = 6
        Me.cbChild.TabStop = True
        Me.cbChild.Text = "CHILD"
        Me.cbChild.UseVisualStyleBackColor = True
        '
        'cbWidowed
        '
        Me.cbWidowed.Enabled = False
        Me.cbWidowed.Location = New System.Drawing.Point(24, 116)
        Me.cbWidowed.Name = "cbWidowed"
        Me.cbWidowed.Size = New System.Drawing.Size(297, 20)
        Me.cbWidowed.TabIndex = 5
        Me.cbWidowed.TabStop = True
        Me.cbWidowed.Text = "WIDOWED"
        Me.cbWidowed.UseVisualStyleBackColor = True
        '
        'cbSeparated
        '
        Me.cbSeparated.Enabled = False
        Me.cbSeparated.Location = New System.Drawing.Point(24, 87)
        Me.cbSeparated.Name = "cbSeparated"
        Me.cbSeparated.Size = New System.Drawing.Size(297, 20)
        Me.cbSeparated.TabIndex = 4
        Me.cbSeparated.TabStop = True
        Me.cbSeparated.Text = "SEPARATED/DIVORSED"
        Me.cbSeparated.UseVisualStyleBackColor = True
        '
        'cbMarried
        '
        Me.cbMarried.Enabled = False
        Me.cbMarried.Location = New System.Drawing.Point(24, 58)
        Me.cbMarried.Name = "cbMarried"
        Me.cbMarried.Size = New System.Drawing.Size(297, 20)
        Me.cbMarried.TabIndex = 3
        Me.cbMarried.TabStop = True
        Me.cbMarried.Text = "MARIED"
        Me.cbMarried.UseVisualStyleBackColor = True
        '
        'cbSingle
        '
        Me.cbSingle.Enabled = False
        Me.cbSingle.Location = New System.Drawing.Point(24, 29)
        Me.cbSingle.Name = "cbSingle"
        Me.cbSingle.Size = New System.Drawing.Size(297, 20)
        Me.cbSingle.TabIndex = 2
        Me.cbSingle.TabStop = True
        Me.cbSingle.Text = "SINGLE"
        Me.cbSingle.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox14.BackColor = System.Drawing.Color.White
        Me.GroupBox14.Controls.Add(Me.txtContact_Watchers)
        Me.GroupBox14.Controls.Add(Me.txtPatientNo)
        Me.GroupBox14.Controls.Add(Me.Label21)
        Me.GroupBox14.Controls.Add(Me.Label22)
        Me.GroupBox14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox14.Location = New System.Drawing.Point(3, 676)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(344, 86)
        Me.GroupBox14.TabIndex = 178
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "CONTACTS"
        '
        'txtContact_Watchers
        '
        Me.txtContact_Watchers.BackColor = System.Drawing.Color.Ivory
        Me.txtContact_Watchers.Location = New System.Drawing.Point(165, 52)
        Me.txtContact_Watchers.Name = "txtContact_Watchers"
        Me.txtContact_Watchers.Size = New System.Drawing.Size(176, 22)
        Me.txtContact_Watchers.TabIndex = 64
        '
        'txtPatientNo
        '
        Me.txtPatientNo.BackColor = System.Drawing.Color.Ivory
        Me.txtPatientNo.Enabled = False
        Me.txtPatientNo.Location = New System.Drawing.Point(165, 24)
        Me.txtPatientNo.Name = "txtPatientNo"
        Me.txtPatientNo.Size = New System.Drawing.Size(176, 22)
        Me.txtPatientNo.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 61
        Me.Label21.Text = "WATCHER'S NO.: "
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(6, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(152, 16)
        Me.Label22.TabIndex = 59
        Me.Label22.Text = "PATIENT NO.: "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(3, 768)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(344, 10)
        Me.Panel2.TabIndex = 191
        '
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.BackColor = System.Drawing.Color.White
        Me.GroupBox10.Controls.Add(Me.txtCaseno)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox10.Location = New System.Drawing.Point(3, 784)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox10.TabIndex = 192
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "CASE NO."
        '
        'txtCaseno
        '
        Me.txtCaseno.BackColor = System.Drawing.Color.Ivory
        Me.txtCaseno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCaseno.Location = New System.Drawing.Point(3, 18)
        Me.txtCaseno.Name = "txtCaseno"
        Me.txtCaseno.Size = New System.Drawing.Size(338, 22)
        Me.txtCaseno.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.txtBedNo)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 836)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox6.TabIndex = 193
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BED NO."
        '
        'txtBedNo
        '
        Me.txtBedNo.BackColor = System.Drawing.Color.Ivory
        Me.txtBedNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBedNo.Location = New System.Drawing.Point(3, 18)
        Me.txtBedNo.Name = "txtBedNo"
        Me.txtBedNo.Size = New System.Drawing.Size(338, 22)
        Me.txtBedNo.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.cbCaseType_RESPI)
        Me.GroupBox2.Controls.Add(Me.cbCaseType_GCB)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 888)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 56)
        Me.GroupBox2.TabIndex = 194
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CASE TYPE"
        '
        'cbCaseType_RESPI
        '
        Me.cbCaseType_RESPI.AutoSize = True
        Me.cbCaseType_RESPI.Location = New System.Drawing.Point(183, 25)
        Me.cbCaseType_RESPI.Name = "cbCaseType_RESPI"
        Me.cbCaseType_RESPI.Size = New System.Drawing.Size(87, 20)
        Me.cbCaseType_RESPI.TabIndex = 1
        Me.cbCaseType_RESPI.TabStop = True
        Me.cbCaseType_RESPI.Text = "RESPI ER"
        Me.cbCaseType_RESPI.UseVisualStyleBackColor = True
        '
        'cbCaseType_GCB
        '
        Me.cbCaseType_GCB.AutoSize = True
        Me.cbCaseType_GCB.Location = New System.Drawing.Point(65, 25)
        Me.cbCaseType_GCB.Name = "cbCaseType_GCB"
        Me.cbCaseType_GCB.Size = New System.Drawing.Size(76, 20)
        Me.cbCaseType_GCB.TabIndex = 0
        Me.cbCaseType_GCB.TabStop = True
        Me.cbCaseType_GCB.Text = "GCB ER"
        Me.cbCaseType_GCB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.dtp_ModeOfArrivalTimeOfDispatched)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtp_ModeOfArrivalTimeOfCall)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAmbulance)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_AmbulanceCall)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_Ambulance)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_Barangay)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_Police)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_Public)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_Personal)
        Me.GroupBox1.Controls.Add(Me.cbModeOfArrival_WalkIn)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 950)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 300)
        Me.GroupBox1.TabIndex = 195
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MODE OF ARRIVAL"
        '
        'dtp_ModeOfArrivalTimeOfDispatched
        '
        Me.dtp_ModeOfArrivalTimeOfDispatched.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_ModeOfArrivalTimeOfDispatched.Location = New System.Drawing.Point(183, 264)
        Me.dtp_ModeOfArrivalTimeOfDispatched.Name = "dtp_ModeOfArrivalTimeOfDispatched"
        Me.dtp_ModeOfArrivalTimeOfDispatched.ShowUpDown = True
        Me.dtp_ModeOfArrivalTimeOfDispatched.Size = New System.Drawing.Size(155, 22)
        Me.dtp_ModeOfArrivalTimeOfDispatched.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(167, 22)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "TIME DISPATCHED: "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtp_ModeOfArrivalTimeOfCall
        '
        Me.dtp_ModeOfArrivalTimeOfCall.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_ModeOfArrivalTimeOfCall.Location = New System.Drawing.Point(183, 232)
        Me.dtp_ModeOfArrivalTimeOfCall.Name = "dtp_ModeOfArrivalTimeOfCall"
        Me.dtp_ModeOfArrivalTimeOfCall.ShowUpDown = True
        Me.dtp_ModeOfArrivalTimeOfCall.Size = New System.Drawing.Size(155, 22)
        Me.dtp_ModeOfArrivalTimeOfCall.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 22)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "TIME OF CALL: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAmbulance
        '
        Me.txtAmbulance.BackColor = System.Drawing.Color.Ivory
        Me.txtAmbulance.Location = New System.Drawing.Point(183, 174)
        Me.txtAmbulance.Name = "txtAmbulance"
        Me.txtAmbulance.Size = New System.Drawing.Size(155, 22)
        Me.txtAmbulance.TabIndex = 9
        '
        'cbModeOfArrival_AmbulanceCall
        '
        Me.cbModeOfArrival_AmbulanceCall.Location = New System.Drawing.Point(9, 205)
        Me.cbModeOfArrival_AmbulanceCall.Name = "cbModeOfArrival_AmbulanceCall"
        Me.cbModeOfArrival_AmbulanceCall.Size = New System.Drawing.Size(164, 20)
        Me.cbModeOfArrival_AmbulanceCall.TabIndex = 8
        Me.cbModeOfArrival_AmbulanceCall.TabStop = True
        Me.cbModeOfArrival_AmbulanceCall.Text = "AMBULANCE CALL"
        Me.cbModeOfArrival_AmbulanceCall.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_Ambulance
        '
        Me.cbModeOfArrival_Ambulance.Location = New System.Drawing.Point(9, 175)
        Me.cbModeOfArrival_Ambulance.Name = "cbModeOfArrival_Ambulance"
        Me.cbModeOfArrival_Ambulance.Size = New System.Drawing.Size(149, 20)
        Me.cbModeOfArrival_Ambulance.TabIndex = 7
        Me.cbModeOfArrival_Ambulance.TabStop = True
        Me.cbModeOfArrival_Ambulance.Text = "AMBULANCE"
        Me.cbModeOfArrival_Ambulance.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_Barangay
        '
        Me.cbModeOfArrival_Barangay.Location = New System.Drawing.Point(9, 145)
        Me.cbModeOfArrival_Barangay.Name = "cbModeOfArrival_Barangay"
        Me.cbModeOfArrival_Barangay.Size = New System.Drawing.Size(261, 20)
        Me.cbModeOfArrival_Barangay.TabIndex = 6
        Me.cbModeOfArrival_Barangay.TabStop = True
        Me.cbModeOfArrival_Barangay.Text = "BARANGAY SERVICE"
        Me.cbModeOfArrival_Barangay.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_Police
        '
        Me.cbModeOfArrival_Police.Location = New System.Drawing.Point(9, 116)
        Me.cbModeOfArrival_Police.Name = "cbModeOfArrival_Police"
        Me.cbModeOfArrival_Police.Size = New System.Drawing.Size(261, 20)
        Me.cbModeOfArrival_Police.TabIndex = 5
        Me.cbModeOfArrival_Police.TabStop = True
        Me.cbModeOfArrival_Police.Text = "POLICE SERVICE"
        Me.cbModeOfArrival_Police.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_Public
        '
        Me.cbModeOfArrival_Public.Location = New System.Drawing.Point(9, 87)
        Me.cbModeOfArrival_Public.Name = "cbModeOfArrival_Public"
        Me.cbModeOfArrival_Public.Size = New System.Drawing.Size(261, 20)
        Me.cbModeOfArrival_Public.TabIndex = 4
        Me.cbModeOfArrival_Public.TabStop = True
        Me.cbModeOfArrival_Public.Text = "PUBLIC SERVICE"
        Me.cbModeOfArrival_Public.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_Personal
        '
        Me.cbModeOfArrival_Personal.Location = New System.Drawing.Point(9, 58)
        Me.cbModeOfArrival_Personal.Name = "cbModeOfArrival_Personal"
        Me.cbModeOfArrival_Personal.Size = New System.Drawing.Size(261, 20)
        Me.cbModeOfArrival_Personal.TabIndex = 3
        Me.cbModeOfArrival_Personal.TabStop = True
        Me.cbModeOfArrival_Personal.Text = "PERSONAL SERVICE"
        Me.cbModeOfArrival_Personal.UseVisualStyleBackColor = True
        '
        'cbModeOfArrival_WalkIn
        '
        Me.cbModeOfArrival_WalkIn.Location = New System.Drawing.Point(9, 29)
        Me.cbModeOfArrival_WalkIn.Name = "cbModeOfArrival_WalkIn"
        Me.cbModeOfArrival_WalkIn.Size = New System.Drawing.Size(261, 20)
        Me.cbModeOfArrival_WalkIn.TabIndex = 2
        Me.cbModeOfArrival_WalkIn.TabStop = True
        Me.cbModeOfArrival_WalkIn.Text = "WALK-IN"
        Me.cbModeOfArrival_WalkIn.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.cbLevelOfConsiousness_Unconscious)
        Me.GroupBox3.Controls.Add(Me.cbLevelOfConsiousness_Stuporous)
        Me.GroupBox3.Controls.Add(Me.cbLevelOfConsiousness_Lethargic)
        Me.GroupBox3.Controls.Add(Me.cbLevelOfConsiousness_Conscious)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 1256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 154)
        Me.GroupBox3.TabIndex = 196
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "LEVEL OF CONSCIOUSNESS"
        '
        'cbLevelOfConsiousness_Unconscious
        '
        Me.cbLevelOfConsiousness_Unconscious.Location = New System.Drawing.Point(38, 116)
        Me.cbLevelOfConsiousness_Unconscious.Name = "cbLevelOfConsiousness_Unconscious"
        Me.cbLevelOfConsiousness_Unconscious.Size = New System.Drawing.Size(283, 20)
        Me.cbLevelOfConsiousness_Unconscious.TabIndex = 5
        Me.cbLevelOfConsiousness_Unconscious.TabStop = True
        Me.cbLevelOfConsiousness_Unconscious.Text = "UNCONSIOUS/UNRESPONSIVE"
        Me.cbLevelOfConsiousness_Unconscious.UseVisualStyleBackColor = True
        '
        'cbLevelOfConsiousness_Stuporous
        '
        Me.cbLevelOfConsiousness_Stuporous.Location = New System.Drawing.Point(38, 87)
        Me.cbLevelOfConsiousness_Stuporous.Name = "cbLevelOfConsiousness_Stuporous"
        Me.cbLevelOfConsiousness_Stuporous.Size = New System.Drawing.Size(283, 20)
        Me.cbLevelOfConsiousness_Stuporous.TabIndex = 4
        Me.cbLevelOfConsiousness_Stuporous.TabStop = True
        Me.cbLevelOfConsiousness_Stuporous.Text = "STUPOROUS"
        Me.cbLevelOfConsiousness_Stuporous.UseVisualStyleBackColor = True
        '
        'cbLevelOfConsiousness_Lethargic
        '
        Me.cbLevelOfConsiousness_Lethargic.Location = New System.Drawing.Point(38, 58)
        Me.cbLevelOfConsiousness_Lethargic.Name = "cbLevelOfConsiousness_Lethargic"
        Me.cbLevelOfConsiousness_Lethargic.Size = New System.Drawing.Size(283, 20)
        Me.cbLevelOfConsiousness_Lethargic.TabIndex = 3
        Me.cbLevelOfConsiousness_Lethargic.TabStop = True
        Me.cbLevelOfConsiousness_Lethargic.Text = "LETHARGIC"
        Me.cbLevelOfConsiousness_Lethargic.UseVisualStyleBackColor = True
        '
        'cbLevelOfConsiousness_Conscious
        '
        Me.cbLevelOfConsiousness_Conscious.Location = New System.Drawing.Point(38, 29)
        Me.cbLevelOfConsiousness_Conscious.Name = "cbLevelOfConsiousness_Conscious"
        Me.cbLevelOfConsiousness_Conscious.Size = New System.Drawing.Size(283, 20)
        Me.cbLevelOfConsiousness_Conscious.TabIndex = 2
        Me.cbLevelOfConsiousness_Conscious.TabStop = True
        Me.cbLevelOfConsiousness_Conscious.Text = "CONSCIOUS"
        Me.cbLevelOfConsiousness_Conscious.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.dtpTimeEndorseUnit)
        Me.GroupBox4.Controls.Add(Me.dtpTimeSeenROD)
        Me.GroupBox4.Controls.Add(Me.dtpTimeEndorseROD)
        Me.GroupBox4.Controls.Add(Me.dtpTimeOfArrival)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 1416)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(344, 142)
        Me.GroupBox4.TabIndex = 197
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "TIMESTAMPS"
        '
        'dtpTimeEndorseUnit
        '
        Me.dtpTimeEndorseUnit.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTimeEndorseUnit.Location = New System.Drawing.Point(208, 105)
        Me.dtpTimeEndorseUnit.Name = "dtpTimeEndorseUnit"
        Me.dtpTimeEndorseUnit.ShowUpDown = True
        Me.dtpTimeEndorseUnit.Size = New System.Drawing.Size(132, 22)
        Me.dtpTimeEndorseUnit.TabIndex = 67
        '
        'dtpTimeSeenROD
        '
        Me.dtpTimeSeenROD.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTimeSeenROD.Location = New System.Drawing.Point(208, 77)
        Me.dtpTimeSeenROD.Name = "dtpTimeSeenROD"
        Me.dtpTimeSeenROD.ShowUpDown = True
        Me.dtpTimeSeenROD.Size = New System.Drawing.Size(132, 22)
        Me.dtpTimeSeenROD.TabIndex = 66
        '
        'dtpTimeEndorseROD
        '
        Me.dtpTimeEndorseROD.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTimeEndorseROD.Location = New System.Drawing.Point(208, 49)
        Me.dtpTimeEndorseROD.Name = "dtpTimeEndorseROD"
        Me.dtpTimeEndorseROD.ShowUpDown = True
        Me.dtpTimeEndorseROD.Size = New System.Drawing.Size(132, 22)
        Me.dtpTimeEndorseROD.TabIndex = 65
        '
        'dtpTimeOfArrival
        '
        Me.dtpTimeOfArrival.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTimeOfArrival.Location = New System.Drawing.Point(208, 22)
        Me.dtpTimeOfArrival.Name = "dtpTimeOfArrival"
        Me.dtpTimeOfArrival.ShowUpDown = True
        Me.dtpTimeOfArrival.Size = New System.Drawing.Size(132, 22)
        Me.dtpTimeOfArrival.TabIndex = 64
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(196, 16)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "TIME ENDORSE TO UNIT: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "TIME SEEN BY ROD: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "TIME ENDORSED TO ROD: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "TIME OF ARRIVAL: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.BackColor = System.Drawing.Color.White
        Me.GroupBox7.Controls.Add(Me.cbClass_NonUrgent)
        Me.GroupBox7.Controls.Add(Me.cbClass_Urgent)
        Me.GroupBox7.Controls.Add(Me.cbClass_Critical)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox7.Location = New System.Drawing.Point(3, 1564)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(344, 118)
        Me.GroupBox7.TabIndex = 198
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "CLASSIFICATION"
        '
        'cbClass_NonUrgent
        '
        Me.cbClass_NonUrgent.Location = New System.Drawing.Point(38, 87)
        Me.cbClass_NonUrgent.Name = "cbClass_NonUrgent"
        Me.cbClass_NonUrgent.Size = New System.Drawing.Size(283, 20)
        Me.cbClass_NonUrgent.TabIndex = 4
        Me.cbClass_NonUrgent.TabStop = True
        Me.cbClass_NonUrgent.Text = "NON-URGENT"
        Me.cbClass_NonUrgent.UseVisualStyleBackColor = True
        '
        'cbClass_Urgent
        '
        Me.cbClass_Urgent.Location = New System.Drawing.Point(38, 58)
        Me.cbClass_Urgent.Name = "cbClass_Urgent"
        Me.cbClass_Urgent.Size = New System.Drawing.Size(283, 20)
        Me.cbClass_Urgent.TabIndex = 3
        Me.cbClass_Urgent.TabStop = True
        Me.cbClass_Urgent.Text = "URGENT"
        Me.cbClass_Urgent.UseVisualStyleBackColor = True
        '
        'cbClass_Critical
        '
        Me.cbClass_Critical.Location = New System.Drawing.Point(38, 29)
        Me.cbClass_Critical.Name = "cbClass_Critical"
        Me.cbClass_Critical.Size = New System.Drawing.Size(283, 20)
        Me.cbClass_Critical.TabIndex = 2
        Me.cbClass_Critical.TabStop = True
        Me.cbClass_Critical.Text = "CRITICAL"
        Me.cbClass_Critical.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.BackColor = System.Drawing.Color.White
        Me.GroupBox9.Controls.Add(Me.txtVaccine_Booster)
        Me.GroupBox9.Controls.Add(Me.txtVaccine_Dose2)
        Me.GroupBox9.Controls.Add(Me.txtVaccine_Dose1)
        Me.GroupBox9.Controls.Add(Me.Label11)
        Me.GroupBox9.Controls.Add(Me.Label12)
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox9.Location = New System.Drawing.Point(3, 1688)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(344, 114)
        Me.GroupBox9.TabIndex = 199
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "VACCINATION"
        '
        'txtVaccine_Booster
        '
        Me.txtVaccine_Booster.BackColor = System.Drawing.Color.Ivory
        Me.txtVaccine_Booster.Location = New System.Drawing.Point(137, 80)
        Me.txtVaccine_Booster.Name = "txtVaccine_Booster"
        Me.txtVaccine_Booster.Size = New System.Drawing.Size(204, 22)
        Me.txtVaccine_Booster.TabIndex = 65
        '
        'txtVaccine_Dose2
        '
        Me.txtVaccine_Dose2.BackColor = System.Drawing.Color.Ivory
        Me.txtVaccine_Dose2.Location = New System.Drawing.Point(137, 52)
        Me.txtVaccine_Dose2.Name = "txtVaccine_Dose2"
        Me.txtVaccine_Dose2.Size = New System.Drawing.Size(204, 22)
        Me.txtVaccine_Dose2.TabIndex = 64
        '
        'txtVaccine_Dose1
        '
        Me.txtVaccine_Dose1.BackColor = System.Drawing.Color.Ivory
        Me.txtVaccine_Dose1.Location = New System.Drawing.Point(137, 24)
        Me.txtVaccine_Dose1.Name = "txtVaccine_Dose1"
        Me.txtVaccine_Dose1.Size = New System.Drawing.Size(204, 22)
        Me.txtVaccine_Dose1.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 16)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "BOOSTER"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 16)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "2nd DOSE"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 16)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "1st DOSE"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox11
        '
        Me.GroupBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox11.BackColor = System.Drawing.Color.White
        Me.GroupBox11.Controls.Add(Me.txtTravelHistory)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox11.Location = New System.Drawing.Point(3, 1808)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(344, 71)
        Me.GroupBox11.TabIndex = 200
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "TRAVEL HISTORY"
        '
        'txtTravelHistory
        '
        Me.txtTravelHistory.BackColor = System.Drawing.Color.Ivory
        Me.txtTravelHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTravelHistory.Enabled = False
        Me.txtTravelHistory.Location = New System.Drawing.Point(3, 18)
        Me.txtTravelHistory.Name = "txtTravelHistory"
        Me.txtTravelHistory.Size = New System.Drawing.Size(338, 50)
        Me.txtTravelHistory.TabIndex = 3
        Me.txtTravelHistory.Text = ""
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtDuty_Carried)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtTimpStamp_ROD)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtDuty_Nurse)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(3, 1885)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(344, 221)
        Me.GroupBox5.TabIndex = 201
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "NURESE/ROD ON DUTY"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(3, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(338, 25)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "CARRIED OUT BY"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDuty_Carried
        '
        Me.txtDuty_Carried.BackColor = System.Drawing.Color.Ivory
        Me.txtDuty_Carried.Location = New System.Drawing.Point(3, 154)
        Me.txtDuty_Carried.Name = "txtDuty_Carried"
        Me.txtDuty_Carried.Size = New System.Drawing.Size(338, 22)
        Me.txtDuty_Carried.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(3, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(338, 25)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "RESIDENT PHYSICIAN ON DUTY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTimpStamp_ROD
        '
        Me.txtTimpStamp_ROD.BackColor = System.Drawing.Color.Ivory
        Me.txtTimpStamp_ROD.Location = New System.Drawing.Point(3, 86)
        Me.txtTimpStamp_ROD.Name = "txtTimpStamp_ROD"
        Me.txtTimpStamp_ROD.Size = New System.Drawing.Size(338, 22)
        Me.txtTimpStamp_ROD.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(3, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(338, 25)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "TRIAGE NURSE ON DUTY"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDuty_Nurse
        '
        Me.txtDuty_Nurse.BackColor = System.Drawing.Color.Ivory
        Me.txtDuty_Nurse.Location = New System.Drawing.Point(3, 21)
        Me.txtDuty_Nurse.Name = "txtDuty_Nurse"
        Me.txtDuty_Nurse.Size = New System.Drawing.Size(338, 22)
        Me.txtDuty_Nurse.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button2.Location = New System.Drawing.Point(3, 2112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(344, 43)
        Me.Button2.TabIndex = 202
        Me.Button2.Text = "SAVE / PREVIEW"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(9, 595)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(351, 43)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "PRINT MEDICAL CERTIFICATE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(9, 644)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(351, 43)
        Me.Button3.TabIndex = 57
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'MySqlDataAdapter1
        '
        Me.MySqlDataAdapter1.DeleteCommand = Nothing
        Me.MySqlDataAdapter1.InsertCommand = Nothing
        Me.MySqlDataAdapter1.SelectCommand = Nothing
        Me.MySqlDataAdapter1.UpdateCommand = Nothing
        '
        'frmGenerateERTriageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1231, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pdfViewer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateERTriageForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfViewer As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents MySqlDataAdapter1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents txtSex As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents txtAddress As RichTextBox
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents txtOtherReligion As TextBox
    Friend WithEvents cbOtheReligion As RadioButton
    Friend WithEvents cbINC As RadioButton
    Friend WithEvents cbSDA As RadioButton
    Friend WithEvents cbProtestant As RadioButton
    Friend WithEvents cbIslam As RadioButton
    Friend WithEvents cbRomanCatholic As RadioButton
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents cbChild As RadioButton
    Friend WithEvents cbWidowed As RadioButton
    Friend WithEvents cbSeparated As RadioButton
    Friend WithEvents cbMarried As RadioButton
    Friend WithEvents cbSingle As RadioButton
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents txtContact_Watchers As TextBox
    Friend WithEvents txtPatientNo As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents txtCaseno As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtBedNo As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbCaseType_RESPI As RadioButton
    Friend WithEvents cbCaseType_GCB As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtp_ModeOfArrivalTimeOfDispatched As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents dtp_ModeOfArrivalTimeOfCall As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAmbulance As TextBox
    Friend WithEvents cbModeOfArrival_AmbulanceCall As RadioButton
    Friend WithEvents cbModeOfArrival_Ambulance As RadioButton
    Friend WithEvents cbModeOfArrival_Barangay As RadioButton
    Friend WithEvents cbModeOfArrival_Police As RadioButton
    Friend WithEvents cbModeOfArrival_Public As RadioButton
    Friend WithEvents cbModeOfArrival_Personal As RadioButton
    Friend WithEvents cbModeOfArrival_WalkIn As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbLevelOfConsiousness_Unconscious As RadioButton
    Friend WithEvents cbLevelOfConsiousness_Stuporous As RadioButton
    Friend WithEvents cbLevelOfConsiousness_Lethargic As RadioButton
    Friend WithEvents cbLevelOfConsiousness_Conscious As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtpTimeEndorseUnit As DateTimePicker
    Friend WithEvents dtpTimeSeenROD As DateTimePicker
    Friend WithEvents dtpTimeEndorseROD As DateTimePicker
    Friend WithEvents dtpTimeOfArrival As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents cbClass_NonUrgent As RadioButton
    Friend WithEvents cbClass_Urgent As RadioButton
    Friend WithEvents cbClass_Critical As RadioButton
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents txtVaccine_Booster As TextBox
    Friend WithEvents txtVaccine_Dose2 As TextBox
    Friend WithEvents txtVaccine_Dose1 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents txtTravelHistory As RichTextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDuty_Carried As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTimpStamp_ROD As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDuty_Nurse As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents dtpBirthDate As TextBox
End Class
