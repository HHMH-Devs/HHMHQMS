<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSignaturePad
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbcountername = New System.Windows.Forms.Label()
        Me.btnClearSignature = New System.Windows.Forms.Button()
        Me.pnlMouseSignaturePad = New System.Windows.Forms.Panel()
        Me.btnSaveSignature = New System.Windows.Forms.Button()
        Me.pnlSignature = New System.Windows.Forms.Panel()
        Me.pnlWacomSignaturePad = New System.Windows.Forms.Panel()
        Me.btnStartSignatureWacom = New System.Windows.Forms.Button()
        Me.sigImage = New System.Windows.Forms.PictureBox()
        Me.pnlInputDeviceSelector = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSaveInputDevice = New System.Windows.Forms.Button()
        Me.cbInputDevice = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlMouseSignaturePad.SuspendLayout()
        Me.pnlWacomSignaturePad.SuspendLayout()
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInputDeviceSelector.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lbcountername)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 34)
        Me.Panel1.TabIndex = 10
        '
        'lbcountername
        '
        Me.lbcountername.BackColor = System.Drawing.Color.PaleGreen
        Me.lbcountername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lbcountername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcountername.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbcountername.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbcountername.Location = New System.Drawing.Point(0, 0)
        Me.lbcountername.Name = "lbcountername"
        Me.lbcountername.Size = New System.Drawing.Size(463, 34)
        Me.lbcountername.TabIndex = 0
        Me.lbcountername.Text = "SIGNATURE PAD"
        Me.lbcountername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClearSignature
        '
        Me.btnClearSignature.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClearSignature.BackColor = System.Drawing.Color.Gray
        Me.btnClearSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClearSignature.FlatAppearance.BorderSize = 0
        Me.btnClearSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSignature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearSignature.ForeColor = System.Drawing.Color.White
        Me.btnClearSignature.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnClearSignature.Location = New System.Drawing.Point(235, 254)
        Me.btnClearSignature.Name = "btnClearSignature"
        Me.btnClearSignature.Size = New System.Drawing.Size(210, 34)
        Me.btnClearSignature.TabIndex = 33
        Me.btnClearSignature.Text = "CLEAR SIGNATURE"
        Me.btnClearSignature.UseVisualStyleBackColor = False
        '
        'pnlMouseSignaturePad
        '
        Me.pnlMouseSignaturePad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMouseSignaturePad.Controls.Add(Me.btnSaveSignature)
        Me.pnlMouseSignaturePad.Controls.Add(Me.pnlSignature)
        Me.pnlMouseSignaturePad.Controls.Add(Me.btnClearSignature)
        Me.pnlMouseSignaturePad.Location = New System.Drawing.Point(1, 36)
        Me.pnlMouseSignaturePad.Name = "pnlMouseSignaturePad"
        Me.pnlMouseSignaturePad.Size = New System.Drawing.Size(459, 294)
        Me.pnlMouseSignaturePad.TabIndex = 34
        '
        'btnSaveSignature
        '
        Me.btnSaveSignature.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSaveSignature.BackColor = System.Drawing.Color.Green
        Me.btnSaveSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSaveSignature.FlatAppearance.BorderSize = 0
        Me.btnSaveSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSignature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveSignature.ForeColor = System.Drawing.Color.White
        Me.btnSaveSignature.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSaveSignature.Location = New System.Drawing.Point(14, 254)
        Me.btnSaveSignature.Name = "btnSaveSignature"
        Me.btnSaveSignature.Size = New System.Drawing.Size(210, 34)
        Me.btnSaveSignature.TabIndex = 34
        Me.btnSaveSignature.Text = "SAVE SIGNATURE"
        Me.btnSaveSignature.UseVisualStyleBackColor = False
        '
        'pnlSignature
        '
        Me.pnlSignature.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSignature.BackColor = System.Drawing.Color.White
        Me.pnlSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSignature.Location = New System.Drawing.Point(14, 3)
        Me.pnlSignature.Name = "pnlSignature"
        Me.pnlSignature.Size = New System.Drawing.Size(431, 245)
        Me.pnlSignature.TabIndex = 12
        '
        'pnlWacomSignaturePad
        '
        Me.pnlWacomSignaturePad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWacomSignaturePad.Controls.Add(Me.btnStartSignatureWacom)
        Me.pnlWacomSignaturePad.Controls.Add(Me.sigImage)
        Me.pnlWacomSignaturePad.Location = New System.Drawing.Point(2, 36)
        Me.pnlWacomSignaturePad.Name = "pnlWacomSignaturePad"
        Me.pnlWacomSignaturePad.Size = New System.Drawing.Size(459, 294)
        Me.pnlWacomSignaturePad.TabIndex = 35
        '
        'btnStartSignatureWacom
        '
        Me.btnStartSignatureWacom.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnStartSignatureWacom.BackColor = System.Drawing.Color.Green
        Me.btnStartSignatureWacom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnStartSignatureWacom.FlatAppearance.BorderSize = 0
        Me.btnStartSignatureWacom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartSignatureWacom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnStartSignatureWacom.ForeColor = System.Drawing.Color.White
        Me.btnStartSignatureWacom.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnStartSignatureWacom.Location = New System.Drawing.Point(13, 252)
        Me.btnStartSignatureWacom.Name = "btnStartSignatureWacom"
        Me.btnStartSignatureWacom.Size = New System.Drawing.Size(431, 34)
        Me.btnStartSignatureWacom.TabIndex = 36
        Me.btnStartSignatureWacom.Text = "START SIGNING"
        Me.btnStartSignatureWacom.UseVisualStyleBackColor = False
        '
        'sigImage
        '
        Me.sigImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sigImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.sigImage.Location = New System.Drawing.Point(13, 3)
        Me.sigImage.Name = "sigImage"
        Me.sigImage.Size = New System.Drawing.Size(431, 240)
        Me.sigImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sigImage.TabIndex = 35
        Me.sigImage.TabStop = False
        '
        'pnlInputDeviceSelector
        '
        Me.pnlInputDeviceSelector.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlInputDeviceSelector.BackColor = System.Drawing.Color.Honeydew
        Me.pnlInputDeviceSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInputDeviceSelector.Controls.Add(Me.Label1)
        Me.pnlInputDeviceSelector.Controls.Add(Me.btnSaveInputDevice)
        Me.pnlInputDeviceSelector.Controls.Add(Me.cbInputDevice)
        Me.pnlInputDeviceSelector.Location = New System.Drawing.Point(36, 79)
        Me.pnlInputDeviceSelector.Name = "pnlInputDeviceSelector"
        Me.pnlInputDeviceSelector.Size = New System.Drawing.Size(391, 157)
        Me.pnlInputDeviceSelector.TabIndex = 62
        Me.pnlInputDeviceSelector.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(373, 53)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Please select a Signature Pad"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSaveInputDevice
        '
        Me.btnSaveInputDevice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSaveInputDevice.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSaveInputDevice.FlatAppearance.BorderSize = 0
        Me.btnSaveInputDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveInputDevice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSaveInputDevice.ForeColor = System.Drawing.Color.White
        Me.btnSaveInputDevice.Location = New System.Drawing.Point(79, 118)
        Me.btnSaveInputDevice.Name = "btnSaveInputDevice"
        Me.btnSaveInputDevice.Size = New System.Drawing.Size(228, 31)
        Me.btnSaveInputDevice.TabIndex = 60
        Me.btnSaveInputDevice.Text = "SAVE"
        Me.btnSaveInputDevice.UseVisualStyleBackColor = False
        '
        'cbInputDevice
        '
        Me.cbInputDevice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbInputDevice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbInputDevice.FormattingEnabled = True
        Me.cbInputDevice.Location = New System.Drawing.Point(27, 67)
        Me.cbInputDevice.Name = "cbInputDevice"
        Me.cbInputDevice.Size = New System.Drawing.Size(334, 26)
        Me.cbInputDevice.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(116, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(228, 31)
        Me.Button1.TabIndex = 62
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmSignaturePad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(463, 372)
        Me.Controls.Add(Me.pnlInputDeviceSelector)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pnlMouseSignaturePad)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlWacomSignaturePad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmSignaturePad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.pnlMouseSignaturePad.ResumeLayout(False)
        Me.pnlWacomSignaturePad.ResumeLayout(False)
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInputDeviceSelector.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbcountername As Label
    Friend WithEvents btnClearSignature As Button
    Friend WithEvents pnlMouseSignaturePad As Panel
    Friend WithEvents pnlSignature As Panel
    Friend WithEvents btnSaveSignature As Button
    Friend WithEvents pnlWacomSignaturePad As Panel
    Friend WithEvents sigImage As PictureBox
    Friend WithEvents pnlInputDeviceSelector As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveInputDevice As Button
    Friend WithEvents cbInputDevice As ComboBox
    Friend WithEvents btnStartSignatureWacom As Button
    Friend WithEvents Button1 As Button
End Class
