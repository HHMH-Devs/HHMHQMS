<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGenerateProcedureConsent
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
        Me.pdfViewer = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.nubConcernAge = New System.Windows.Forms.NumericUpDown()
        Me.cbOPDConsent_WitnessRelationShip = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPatientName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConcernSurname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConcernGivenName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtProcedureDetail = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtExplainedBy = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtWitnessAddress = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWitnessName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtInterpreterAddress = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInterpreterName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnOPDConsent_PatientSignature = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nubConcernAge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.pdfViewer.TabIndex = 15
        Me.pdfViewer.Text = "PdfDocumentViewer1"
        Me.pdfViewer.Threshold = 60
        Me.pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
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
        Me.Button1.Location = New System.Drawing.Point(870, 596)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(351, 43)
        Me.Button1.TabIndex = 60
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
        Me.Button3.Location = New System.Drawing.Point(869, 646)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(351, 43)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox11)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(864, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(367, 585)
        Me.FlowLayoutPanel1.TabIndex = 54
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.nubConcernAge)
        Me.GroupBox3.Controls.Add(Me.cbOPDConsent_WitnessRelationShip)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtPatientName)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtConcernSurname)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtConcernGivenName)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 184)
        Me.GroupBox3.TabIndex = 217
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "WHOM IT CONCERN"
        '
        'nubConcernAge
        '
        Me.nubConcernAge.BackColor = System.Drawing.Color.Ivory
        Me.nubConcernAge.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nubConcernAge.Location = New System.Drawing.Point(137, 80)
        Me.nubConcernAge.Name = "nubConcernAge"
        Me.nubConcernAge.Size = New System.Drawing.Size(204, 25)
        Me.nubConcernAge.TabIndex = 1
        Me.nubConcernAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbOPDConsent_WitnessRelationShip
        '
        Me.cbOPDConsent_WitnessRelationShip.BackColor = System.Drawing.Color.Ivory
        Me.cbOPDConsent_WitnessRelationShip.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbOPDConsent_WitnessRelationShip.FormattingEnabled = True
        Me.cbOPDConsent_WitnessRelationShip.Items.AddRange(New Object() {"NONE", "FATHER", "MOTHER", "SIBLINGS", "FAMILY RELATED", "OTHERS"})
        Me.cbOPDConsent_WitnessRelationShip.Location = New System.Drawing.Point(137, 110)
        Me.cbOPDConsent_WitnessRelationShip.Name = "cbOPDConsent_WitnessRelationShip"
        Me.cbOPDConsent_WitnessRelationShip.Size = New System.Drawing.Size(204, 26)
        Me.cbOPDConsent_WitnessRelationShip.TabIndex = 76
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(9, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 24)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "RELATIONSHIP: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPatientName
        '
        Me.txtPatientName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPatientName.Location = New System.Drawing.Point(137, 150)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.ReadOnly = True
        Me.txtPatientName.Size = New System.Drawing.Size(204, 22)
        Me.txtPatientName.TabIndex = 75
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(9, 153)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 16)
        Me.Label15.TabIndex = 74
        Me.Label15.Text = "PATIENT NAME: "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 16)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "AGE: "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConcernSurname
        '
        Me.txtConcernSurname.BackColor = System.Drawing.Color.Ivory
        Me.txtConcernSurname.Location = New System.Drawing.Point(137, 52)
        Me.txtConcernSurname.Name = "txtConcernSurname"
        Me.txtConcernSurname.Size = New System.Drawing.Size(204, 22)
        Me.txtConcernSurname.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "SURNAME: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConcernGivenName
        '
        Me.txtConcernGivenName.BackColor = System.Drawing.Color.Ivory
        Me.txtConcernGivenName.Location = New System.Drawing.Point(137, 24)
        Me.txtConcernGivenName.Name = "txtConcernGivenName"
        Me.txtConcernGivenName.Size = New System.Drawing.Size(204, 22)
        Me.txtConcernGivenName.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 16)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "GIVEN NAME: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox11
        '
        Me.GroupBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox11.BackColor = System.Drawing.Color.White
        Me.GroupBox11.Controls.Add(Me.txtProcedureDetail)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox11.Location = New System.Drawing.Point(3, 193)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(344, 169)
        Me.GroupBox11.TabIndex = 224
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "PROCEDURES/OPERATION/ANESTHESIA"
        '
        'txtProcedureDetail
        '
        Me.txtProcedureDetail.BackColor = System.Drawing.Color.Ivory
        Me.txtProcedureDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProcedureDetail.Location = New System.Drawing.Point(3, 18)
        Me.txtProcedureDetail.Name = "txtProcedureDetail"
        Me.txtProcedureDetail.Size = New System.Drawing.Size(338, 148)
        Me.txtProcedureDetail.TabIndex = 3
        Me.txtProcedureDetail.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtExplainedBy)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 368)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 91)
        Me.GroupBox1.TabIndex = 225
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EXPLAINED BY"
        '
        'txtExplainedBy
        '
        Me.txtExplainedBy.BackColor = System.Drawing.Color.Ivory
        Me.txtExplainedBy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExplainedBy.Location = New System.Drawing.Point(3, 18)
        Me.txtExplainedBy.Name = "txtExplainedBy"
        Me.txtExplainedBy.Size = New System.Drawing.Size(338, 70)
        Me.txtExplainedBy.TabIndex = 3
        Me.txtExplainedBy.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.txtWitnessAddress)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtWitnessName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 465)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 154)
        Me.GroupBox2.TabIndex = 229
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "WITNESS"
        '
        'txtWitnessAddress
        '
        Me.txtWitnessAddress.BackColor = System.Drawing.Color.Ivory
        Me.txtWitnessAddress.Location = New System.Drawing.Point(12, 85)
        Me.txtWitnessAddress.Name = "txtWitnessAddress"
        Me.txtWitnessAddress.Size = New System.Drawing.Size(329, 63)
        Me.txtWitnessAddress.TabIndex = 66
        Me.txtWitnessAddress.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 26)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "ADDRESS: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWitnessName
        '
        Me.txtWitnessName.BackColor = System.Drawing.Color.Ivory
        Me.txtWitnessName.Location = New System.Drawing.Point(110, 24)
        Me.txtWitnessName.Name = "txtWitnessName"
        Me.txtWitnessName.Size = New System.Drawing.Size(231, 22)
        Me.txtWitnessName.TabIndex = 63
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "WITNESS: "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.txtInterpreterAddress)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtInterpreterName)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(3, 625)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(344, 154)
        Me.GroupBox5.TabIndex = 231
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "INTERPRETER"
        '
        'txtInterpreterAddress
        '
        Me.txtInterpreterAddress.BackColor = System.Drawing.Color.Ivory
        Me.txtInterpreterAddress.Location = New System.Drawing.Point(12, 85)
        Me.txtInterpreterAddress.Name = "txtInterpreterAddress"
        Me.txtInterpreterAddress.Size = New System.Drawing.Size(329, 63)
        Me.txtInterpreterAddress.TabIndex = 66
        Me.txtInterpreterAddress.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(329, 26)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "ADDRESS: "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInterpreterName
        '
        Me.txtInterpreterName.BackColor = System.Drawing.Color.Ivory
        Me.txtInterpreterName.Location = New System.Drawing.Point(137, 24)
        Me.txtInterpreterName.Name = "txtInterpreterName"
        Me.txtInterpreterName.Size = New System.Drawing.Size(204, 22)
        Me.txtInterpreterName.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 16)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "INTERPRETER: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.btnOPDConsent_PatientSignature)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 785)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(344, 91)
        Me.GroupBox4.TabIndex = 234
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SIGNATURE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(27, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 20)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "PATIENT SIGNATURE"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOPDConsent_PatientSignature
        '
        Me.btnOPDConsent_PatientSignature.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOPDConsent_PatientSignature.BackColor = System.Drawing.Color.Gray
        Me.btnOPDConsent_PatientSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOPDConsent_PatientSignature.FlatAppearance.BorderSize = 0
        Me.btnOPDConsent_PatientSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsent_PatientSignature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOPDConsent_PatientSignature.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOPDConsent_PatientSignature.Location = New System.Drawing.Point(24, 52)
        Me.btnOPDConsent_PatientSignature.Name = "btnOPDConsent_PatientSignature"
        Me.btnOPDConsent_PatientSignature.Size = New System.Drawing.Size(297, 31)
        Me.btnOPDConsent_PatientSignature.TabIndex = 53
        Me.btnOPDConsent_PatientSignature.Text = "CLICK TO ADD SIGNATURE"
        Me.btnOPDConsent_PatientSignature.UseVisualStyleBackColor = False
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
        Me.Button2.Location = New System.Drawing.Point(3, 882)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(344, 43)
        Me.Button2.TabIndex = 235
        Me.Button2.Text = "SAVE / PREVIEW"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmGenerateProcedureConsent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.pdfViewer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateProcedureConsent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nubConcernAge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfViewer As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtConcernSurname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtConcernGivenName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents txtProcedureDetail As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtExplainedBy As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPatientName As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtWitnessAddress As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtWitnessName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbOPDConsent_WitnessRelationShip As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtInterpreterAddress As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInterpreterName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents nubConcernAge As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnOPDConsent_PatientSignature As Button
    Friend WithEvents Button2 As Button
End Class
