<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGenerateNurseNotes
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtSex = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtHospitalNo = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtAttendingPhysician = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtWard = New System.Windows.Forms.TextBox()
        Me.txtRoomNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lblNurseOrderCount = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.pdfViewer.TabIndex = 60
        Me.pdfViewer.Text = "PdfDocumentViewer1"
        Me.pdfViewer.Threshold = 60
        Me.pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox12)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox10)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox6)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox9)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(864, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(367, 585)
        Me.FlowLayoutPanel1.TabIndex = 61
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox12.BackColor = System.Drawing.Color.White
        Me.GroupBox12.Controls.Add(Me.txtSex)
        Me.GroupBox12.Controls.Add(Me.Label17)
        Me.GroupBox12.Controls.Add(Me.dtpBirthDate)
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
        Me.GroupBox12.TabIndex = 174
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "PATIENT PROFILE (NOT EDITABLE)"
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
        'dtpBirthDate
        '
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBirthDate.Location = New System.Drawing.Point(154, 113)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(187, 22)
        Me.dtpBirthDate.TabIndex = 68
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
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.BackColor = System.Drawing.Color.White
        Me.GroupBox10.Controls.Add(Me.txtHospitalNo)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox10.Location = New System.Drawing.Point(3, 182)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox10.TabIndex = 205
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "HOSPITAL NO."
        '
        'txtHospitalNo
        '
        Me.txtHospitalNo.BackColor = System.Drawing.Color.Ivory
        Me.txtHospitalNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHospitalNo.Location = New System.Drawing.Point(3, 18)
        Me.txtHospitalNo.Name = "txtHospitalNo"
        Me.txtHospitalNo.Size = New System.Drawing.Size(338, 22)
        Me.txtHospitalNo.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.txtAttendingPhysician)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(3, 234)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(344, 46)
        Me.GroupBox6.TabIndex = 206
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ATTENDING PHYSICIAN (NOT EDITABLE)"
        '
        'txtAttendingPhysician
        '
        Me.txtAttendingPhysician.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtAttendingPhysician.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAttendingPhysician.Location = New System.Drawing.Point(3, 18)
        Me.txtAttendingPhysician.Name = "txtAttendingPhysician"
        Me.txtAttendingPhysician.ReadOnly = True
        Me.txtAttendingPhysician.Size = New System.Drawing.Size(338, 22)
        Me.txtAttendingPhysician.TabIndex = 2
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.BackColor = System.Drawing.Color.White
        Me.GroupBox9.Controls.Add(Me.txtWard)
        Me.GroupBox9.Controls.Add(Me.txtRoomNo)
        Me.GroupBox9.Controls.Add(Me.Label1)
        Me.GroupBox9.Controls.Add(Me.Label2)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox9.Location = New System.Drawing.Point(3, 286)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(344, 86)
        Me.GroupBox9.TabIndex = 208
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "ROOM INFO (NOT EDITABLE)"
        '
        'txtWard
        '
        Me.txtWard.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtWard.Location = New System.Drawing.Point(137, 52)
        Me.txtWard.Name = "txtWard"
        Me.txtWard.ReadOnly = True
        Me.txtWard.Size = New System.Drawing.Size(204, 22)
        Me.txtWard.TabIndex = 64
        '
        'txtRoomNo
        '
        Me.txtRoomNo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtRoomNo.Location = New System.Drawing.Point(137, 24)
        Me.txtRoomNo.Name = "txtRoomNo"
        Me.txtRoomNo.ReadOnly = True
        Me.txtRoomNo.Size = New System.Drawing.Size(204, 22)
        Me.txtRoomNo.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "WARD: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "ROOM NO.: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.lblNurseOrderCount)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 378)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 163)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NURSE NOTES"
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button4.BackColor = System.Drawing.Color.RoyalBlue
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button4.Location = New System.Drawing.Point(59, 121)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(227, 33)
        Me.Button4.TabIndex = 215
        Me.Button4.Text = "MANAGE NURSES NOTES"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'lblNurseOrderCount
        '
        Me.lblNurseOrderCount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNurseOrderCount.Location = New System.Drawing.Point(36, 32)
        Me.lblNurseOrderCount.Name = "lblNurseOrderCount"
        Me.lblNurseOrderCount.Size = New System.Drawing.Size(272, 67)
        Me.lblNurseOrderCount.TabIndex = 60
        Me.lblNurseOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Button2.Location = New System.Drawing.Point(3, 547)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(344, 43)
        Me.Button2.TabIndex = 214
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
        Me.Button1.Location = New System.Drawing.Point(871, 594)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(351, 43)
        Me.Button1.TabIndex = 63
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
        Me.Button3.Location = New System.Drawing.Point(871, 643)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(351, 43)
        Me.Button3.TabIndex = 62
        Me.Button3.Text = "CLOSE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frmGenerateNurseNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1231, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.pdfViewer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerateNurseNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfViewer As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents txtSex As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents dtpBirthDate As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents txtHospitalNo As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtAttendingPhysician As TextBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents txtWard As TextBox
    Friend WithEvents txtRoomNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents lblNurseOrderCount As Label
End Class
