<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateMedicalCertificate
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cbSex = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCompleteAddress = New System.Windows.Forms.RichTextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtImpresion = New System.Windows.Forms.RichTextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpIssuedDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPTRNo = New System.Windows.Forms.TextBox()
        Me.txtPRCNo = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtPhysicianName = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.pdfViewer.TabIndex = 13
        Me.pdfViewer.Text = "PdfDocumentViewer1"
        Me.pdfViewer.Threshold = 60
        Me.pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Honeydew
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox6)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox10)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox9)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox7)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(367, 585)
        Me.FlowLayoutPanel1.TabIndex = 53
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.txtFullName)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox6.TabIndex = 101
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "FULL NAME (LN, FN, MN)"
        '
        'txtFullName
        '
        Me.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFullName.Location = New System.Drawing.Point(3, 18)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(338, 22)
        Me.txtFullName.TabIndex = 1
        '
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.BackColor = System.Drawing.Color.White
        Me.GroupBox10.Controls.Add(Me.cbSex)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox10.Location = New System.Drawing.Point(3, 55)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox10.TabIndex = 119
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "SEX"
        '
        'cbSex
        '
        Me.cbSex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbSex.FormattingEnabled = True
        Me.cbSex.Items.AddRange(New Object() {"MALE", "FEMALE"})
        Me.cbSex.Location = New System.Drawing.Point(3, 18)
        Me.cbSex.Name = "cbSex"
        Me.cbSex.Size = New System.Drawing.Size(338, 24)
        Me.cbSex.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.BackColor = System.Drawing.Color.White
        Me.GroupBox9.Controls.Add(Me.dtpBirthDate)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox9.Location = New System.Drawing.Point(3, 107)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox9.TabIndex = 120
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "BIRTH DATE"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBirthDate.Location = New System.Drawing.Point(3, 18)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(338, 22)
        Me.dtpBirthDate.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtCompleteAddress)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 159)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 106)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ADDRESS (St/Dr, Brgy, City)"
        '
        'txtCompleteAddress
        '
        Me.txtCompleteAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCompleteAddress.Location = New System.Drawing.Point(3, 18)
        Me.txtCompleteAddress.Name = "txtCompleteAddress"
        Me.txtCompleteAddress.Size = New System.Drawing.Size(338, 85)
        Me.txtCompleteAddress.TabIndex = 14
        Me.txtCompleteAddress.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.txtImpresion)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 271)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(344, 106)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "IMPRESSION"
        '
        'txtImpresion
        '
        Me.txtImpresion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtImpresion.Location = New System.Drawing.Point(3, 18)
        Me.txtImpresion.Name = "txtImpresion"
        Me.txtImpresion.Size = New System.Drawing.Size(338, 85)
        Me.txtImpresion.TabIndex = 15
        Me.txtImpresion.Text = ""
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.BackColor = System.Drawing.Color.White
        Me.GroupBox7.Controls.Add(Me.txtRemarks)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox7.Location = New System.Drawing.Point(3, 383)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(344, 106)
        Me.GroupBox7.TabIndex = 125
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "REMARKS"
        '
        'txtRemarks
        '
        Me.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemarks.Location = New System.Drawing.Point(3, 18)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(338, 85)
        Me.txtRemarks.TabIndex = 15
        Me.txtRemarks.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.dtpIssuedDate)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 495)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 45)
        Me.GroupBox3.TabIndex = 126
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ISSUED DATE"
        '
        'dtpIssuedDate
        '
        Me.dtpIssuedDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIssuedDate.Location = New System.Drawing.Point(3, 18)
        Me.dtpIssuedDate.Name = "dtpIssuedDate"
        Me.dtpIssuedDate.Size = New System.Drawing.Size(338, 22)
        Me.dtpIssuedDate.TabIndex = 14
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.BackColor = System.Drawing.Color.White
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.txtPTRNo)
        Me.GroupBox8.Controls.Add(Me.txtPRCNo)
        Me.GroupBox8.Controls.Add(Me.Button4)
        Me.GroupBox8.Controls.Add(Me.txtPhysicianName)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox8.Location = New System.Drawing.Point(3, 546)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(344, 155)
        Me.GroupBox8.TabIndex = 127
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "ATTENDING PHYSICIAN"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "PTR # :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "PRC # :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PHYSICIAN :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPTRNo
        '
        Me.txtPTRNo.Location = New System.Drawing.Point(102, 80)
        Me.txtPTRNo.Name = "txtPTRNo"
        Me.txtPTRNo.Size = New System.Drawing.Size(239, 22)
        Me.txtPTRNo.TabIndex = 112
        '
        'txtPRCNo
        '
        Me.txtPRCNo.Location = New System.Drawing.Point(102, 49)
        Me.txtPRCNo.Name = "txtPRCNo"
        Me.txtPRCNo.Size = New System.Drawing.Size(239, 22)
        Me.txtPRCNo.TabIndex = 111
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button4.BackColor = System.Drawing.Color.Gray
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button4.Location = New System.Drawing.Point(66, 117)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(213, 28)
        Me.Button4.TabIndex = 110
        Me.Button4.Text = "FIND PHYSICIAN"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtPhysicianName
        '
        Me.txtPhysicianName.Location = New System.Drawing.Point(102, 18)
        Me.txtPhysicianName.Name = "txtPhysicianName"
        Me.txtPhysicianName.Size = New System.Drawing.Size(239, 22)
        Me.txtPhysicianName.TabIndex = 1
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
        Me.Button2.Location = New System.Drawing.Point(3, 707)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(344, 43)
        Me.Button2.TabIndex = 128
        Me.Button2.Text = "PREVIEW"
        Me.Button2.UseVisualStyleBackColor = False
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
        Me.Button3.Location = New System.Drawing.Point(7, 640)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(351, 43)
        Me.Button3.TabIndex = 57
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = False
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
        Me.Button1.Location = New System.Drawing.Point(7, 591)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(351, 43)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "PRINT ER TRIAGE FORM"
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.Panel1.TabIndex = 57
        '
        'frmGenerateMedicalCertificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(1231, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pdfViewer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmGenerateMedicalCertificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfViewer As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents cbSex As ComboBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCompleteAddress As RichTextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtImpresion As RichTextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtRemarks As RichTextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpIssuedDate As DateTimePicker
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPTRNo As TextBox
    Friend WithEvents txtPRCNo As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents txtPhysicianName As TextBox
    Friend WithEvents Button2 As Button
End Class
