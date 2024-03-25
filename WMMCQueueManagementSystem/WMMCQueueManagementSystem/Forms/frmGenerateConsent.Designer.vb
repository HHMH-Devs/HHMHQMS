<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGenerateConsent
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
        Me.pdfViewer1 = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlOPDConsentFields = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbOPDConsent_WitnessRelationShip = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOPDConsent_Witness = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtOPDConsent_EmployeeName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOPDConsent_EmployeeSignature = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOPDConsent_WitnessSignature = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOPDConsent_PatientSignature = New System.Windows.Forms.Button()
        Me.btnOPDConsent_Preview = New System.Windows.Forms.Button()
        Me.btnOPDConsent_Done = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.pdfViewer2 = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.pnlOPDConsentFields.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pdfViewer1
        '
        Me.pdfViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pdfViewer1.BackColor = System.Drawing.Color.White
        Me.pdfViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pdfViewer1.Location = New System.Drawing.Point(12, 12)
        Me.pdfViewer1.MultiPagesThreshold = 60
        Me.pdfViewer1.Name = "pdfViewer1"
        Me.pdfViewer1.Size = New System.Drawing.Size(965, 599)
        Me.pdfViewer1.TabIndex = 12
        Me.pdfViewer1.Text = "PdfDocumentViewer1"
        Me.pdfViewer1.Threshold = 60
        Me.pdfViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button3.Location = New System.Drawing.Point(986, 617)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(351, 43)
        Me.Button3.TabIndex = 54
        Me.Button3.Text = "CANCEL CONSENT"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'pnlOPDConsentFields
        '
        Me.pnlOPDConsentFields.AutoScroll = True
        Me.pnlOPDConsentFields.Controls.Add(Me.GroupBox4)
        Me.pnlOPDConsentFields.Controls.Add(Me.GroupBox1)
        Me.pnlOPDConsentFields.Controls.Add(Me.GroupBox3)
        Me.pnlOPDConsentFields.Controls.Add(Me.btnOPDConsent_Preview)
        Me.pnlOPDConsentFields.Controls.Add(Me.btnOPDConsent_Done)
        Me.pnlOPDConsentFields.Location = New System.Drawing.Point(986, 12)
        Me.pnlOPDConsentFields.Name = "pnlOPDConsentFields"
        Me.pnlOPDConsentFields.Size = New System.Drawing.Size(351, 599)
        Me.pnlOPDConsentFields.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.cbOPDConsent_WitnessRelationShip)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtOPDConsent_Witness)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(324, 196)
        Me.GroupBox4.TabIndex = 55
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "WITNESS (if patient is underage)"
        '
        'cbOPDConsent_WitnessRelationShip
        '
        Me.cbOPDConsent_WitnessRelationShip.BackColor = System.Drawing.Color.Ivory
        Me.cbOPDConsent_WitnessRelationShip.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbOPDConsent_WitnessRelationShip.FormattingEnabled = True
        Me.cbOPDConsent_WitnessRelationShip.Items.AddRange(New Object() {"NONE", "FATHER", "MOTHER", "SIBLINGS", "FAMILY RELATED", "OTHERS"})
        Me.cbOPDConsent_WitnessRelationShip.Location = New System.Drawing.Point(13, 146)
        Me.cbOPDConsent_WitnessRelationShip.Name = "cbOPDConsent_WitnessRelationShip"
        Me.cbOPDConsent_WitnessRelationShip.Size = New System.Drawing.Size(298, 26)
        Me.cbOPDConsent_WitnessRelationShip.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(10, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(209, 20)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "RELATIONSHIP TO THE PATIENT"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOPDConsent_Witness
        '
        Me.txtOPDConsent_Witness.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOPDConsent_Witness.BackColor = System.Drawing.Color.Ivory
        Me.txtOPDConsent_Witness.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOPDConsent_Witness.Location = New System.Drawing.Point(14, 69)
        Me.txtOPDConsent_Witness.Name = "txtOPDConsent_Witness"
        Me.txtOPDConsent_Witness.Size = New System.Drawing.Size(297, 26)
        Me.txtOPDConsent_Witness.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(10, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 20)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "WITNESS FULL NAME"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtOPDConsent_EmployeeName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 205)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 127)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EMPLOYEE"
        '
        'txtOPDConsent_EmployeeName
        '
        Me.txtOPDConsent_EmployeeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOPDConsent_EmployeeName.BackColor = System.Drawing.Color.Ivory
        Me.txtOPDConsent_EmployeeName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOPDConsent_EmployeeName.Location = New System.Drawing.Point(14, 69)
        Me.txtOPDConsent_EmployeeName.Name = "txtOPDConsent_EmployeeName"
        Me.txtOPDConsent_EmployeeName.Size = New System.Drawing.Size(297, 26)
        Me.txtOPDConsent_EmployeeName.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "EMPLOYEE NAME"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btnOPDConsent_EmployeeSignature)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btnOPDConsent_WitnessSignature)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btnOPDConsent_PatientSignature)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 338)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 251)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SIGNATURE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(17, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "EMPLOYEE SIGNATURE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOPDConsent_EmployeeSignature
        '
        Me.btnOPDConsent_EmployeeSignature.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOPDConsent_EmployeeSignature.BackColor = System.Drawing.Color.Gray
        Me.btnOPDConsent_EmployeeSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOPDConsent_EmployeeSignature.FlatAppearance.BorderSize = 0
        Me.btnOPDConsent_EmployeeSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsent_EmployeeSignature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOPDConsent_EmployeeSignature.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOPDConsent_EmployeeSignature.Location = New System.Drawing.Point(14, 203)
        Me.btnOPDConsent_EmployeeSignature.Name = "btnOPDConsent_EmployeeSignature"
        Me.btnOPDConsent_EmployeeSignature.Size = New System.Drawing.Size(297, 31)
        Me.btnOPDConsent_EmployeeSignature.TabIndex = 55
        Me.btnOPDConsent_EmployeeSignature.Text = "CLICK TO ADD SIGNATURE"
        Me.btnOPDConsent_EmployeeSignature.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 20)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "WITNESS SIGNATURE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOPDConsent_WitnessSignature
        '
        Me.btnOPDConsent_WitnessSignature.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOPDConsent_WitnessSignature.BackColor = System.Drawing.Color.Gray
        Me.btnOPDConsent_WitnessSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOPDConsent_WitnessSignature.FlatAppearance.BorderSize = 0
        Me.btnOPDConsent_WitnessSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsent_WitnessSignature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOPDConsent_WitnessSignature.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOPDConsent_WitnessSignature.Location = New System.Drawing.Point(14, 128)
        Me.btnOPDConsent_WitnessSignature.Name = "btnOPDConsent_WitnessSignature"
        Me.btnOPDConsent_WitnessSignature.Size = New System.Drawing.Size(297, 31)
        Me.btnOPDConsent_WitnessSignature.TabIndex = 53
        Me.btnOPDConsent_WitnessSignature.Text = "CLICK TO ADD SIGNATURE"
        Me.btnOPDConsent_WitnessSignature.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 20)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "PATIENT SIGNATURE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.btnOPDConsent_PatientSignature.Location = New System.Drawing.Point(14, 58)
        Me.btnOPDConsent_PatientSignature.Name = "btnOPDConsent_PatientSignature"
        Me.btnOPDConsent_PatientSignature.Size = New System.Drawing.Size(297, 31)
        Me.btnOPDConsent_PatientSignature.TabIndex = 3
        Me.btnOPDConsent_PatientSignature.Text = "CLICK TO ADD SIGNATURE"
        Me.btnOPDConsent_PatientSignature.UseVisualStyleBackColor = False
        '
        'btnOPDConsent_Preview
        '
        Me.btnOPDConsent_Preview.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOPDConsent_Preview.BackColor = System.Drawing.Color.LimeGreen
        Me.btnOPDConsent_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOPDConsent_Preview.FlatAppearance.BorderSize = 0
        Me.btnOPDConsent_Preview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsent_Preview.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOPDConsent_Preview.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOPDConsent_Preview.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOPDConsent_Preview.Location = New System.Drawing.Point(3, 595)
        Me.btnOPDConsent_Preview.Name = "btnOPDConsent_Preview"
        Me.btnOPDConsent_Preview.Size = New System.Drawing.Size(324, 41)
        Me.btnOPDConsent_Preview.TabIndex = 60
        Me.btnOPDConsent_Preview.Text = "PREVIEW"
        Me.btnOPDConsent_Preview.UseVisualStyleBackColor = False
        '
        'btnOPDConsent_Done
        '
        Me.btnOPDConsent_Done.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOPDConsent_Done.BackColor = System.Drawing.Color.Green
        Me.btnOPDConsent_Done.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnOPDConsent_Done.FlatAppearance.BorderSize = 0
        Me.btnOPDConsent_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsent_Done.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOPDConsent_Done.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOPDConsent_Done.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOPDConsent_Done.Location = New System.Drawing.Point(3, 642)
        Me.btnOPDConsent_Done.Name = "btnOPDConsent_Done"
        Me.btnOPDConsent_Done.Size = New System.Drawing.Size(324, 43)
        Me.btnOPDConsent_Done.TabIndex = 61
        Me.btnOPDConsent_Done.Text = "DONE"
        Me.btnOPDConsent_Done.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(375, 619)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 41)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "NEXT PAGE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblPage
        '
        Me.lblPage.BackColor = System.Drawing.Color.Transparent
        Me.lblPage.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblPage.Location = New System.Drawing.Point(54, 619)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(282, 41)
        Me.lblPage.TabIndex = 58
        Me.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pdfViewer2
        '
        Me.pdfViewer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pdfViewer2.BackColor = System.Drawing.Color.White
        Me.pdfViewer2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pdfViewer2.Location = New System.Drawing.Point(12, 12)
        Me.pdfViewer2.MultiPagesThreshold = 60
        Me.pdfViewer2.Name = "pdfViewer2"
        Me.pdfViewer2.Size = New System.Drawing.Size(965, 599)
        Me.pdfViewer2.TabIndex = 13
        Me.pdfViewer2.Text = "PdfDocumentViewer1"
        Me.pdfViewer2.Threshold = 60
        Me.pdfViewer2.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'frmGenerateConsent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(1346, 671)
        Me.Controls.Add(Me.pdfViewer2)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.pdfViewer1)
        Me.Controls.Add(Me.pnlOPDConsentFields)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGenerateConsent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlOPDConsentFields.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pdfViewer1 As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents Button3 As Button
    Friend WithEvents pnlOPDConsentFields As FlowLayoutPanel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOPDConsent_Witness As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOPDConsent_WitnessRelationShip As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lblPage As Label
    Friend WithEvents pdfViewer2 As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtOPDConsent_EmployeeName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOPDConsent_WitnessSignature As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOPDConsent_PatientSignature As Button
    Friend WithEvents btnOPDConsent_Preview As Button
    Friend WithEvents btnOPDConsent_Done As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOPDConsent_EmployeeSignature As Button
End Class
