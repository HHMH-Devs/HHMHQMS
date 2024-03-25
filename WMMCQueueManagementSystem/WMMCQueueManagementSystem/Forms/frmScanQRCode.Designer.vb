<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScanQRCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScanQRCode))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbDefaultImg = New System.Windows.Forms.PictureBox()
        Me.lbnote = New System.Windows.Forms.Label()
        Me.lblScanErr = New System.Windows.Forms.Label()
        Me.captureTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlInputDeviceSelector = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSaveInputDevice = New System.Windows.Forms.Button()
        Me.cbInputDevice = New System.Windows.Forms.ComboBox()
        Me.pbWebCamImg = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbDefaultImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInputDeviceSelector.SuspendLayout()
        CType(Me.pbWebCamImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(18, 69)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(375, 26)
        Me.TextBox1.TabIndex = 39
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 56)
        Me.Panel1.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(467, 56)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "SCAN Q.R CODE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbDefaultImg
        '
        Me.pbDefaultImg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbDefaultImg.Image = CType(resources.GetObject("pbDefaultImg.Image"), System.Drawing.Image)
        Me.pbDefaultImg.Location = New System.Drawing.Point(10, 119)
        Me.pbDefaultImg.Name = "pbDefaultImg"
        Me.pbDefaultImg.Size = New System.Drawing.Size(447, 358)
        Me.pbDefaultImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDefaultImg.TabIndex = 47
        Me.pbDefaultImg.TabStop = False
        Me.pbDefaultImg.Visible = False
        '
        'lbnote
        '
        Me.lbnote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbnote.BackColor = System.Drawing.Color.Transparent
        Me.lbnote.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnote.ForeColor = System.Drawing.Color.Red
        Me.lbnote.Location = New System.Drawing.Point(4, 59)
        Me.lbnote.Name = "lbnote"
        Me.lbnote.Size = New System.Drawing.Size(463, 57)
        Me.lbnote.TabIndex = 48
        Me.lbnote.Text = "Place the Q.R CODE in front of the QR SCANNER or CAMERA to scan."
        Me.lbnote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScanErr
        '
        Me.lblScanErr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblScanErr.BackColor = System.Drawing.Color.Transparent
        Me.lblScanErr.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanErr.ForeColor = System.Drawing.Color.Red
        Me.lblScanErr.Location = New System.Drawing.Point(0, 480)
        Me.lblScanErr.Name = "lblScanErr"
        Me.lblScanErr.Size = New System.Drawing.Size(467, 62)
        Me.lblScanErr.TabIndex = 49
        Me.lblScanErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'captureTimer
        '
        Me.captureTimer.Interval = 1000
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(108, 545)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 37)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "BACK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pnlInputDeviceSelector
        '
        Me.pnlInputDeviceSelector.Controls.Add(Me.Label1)
        Me.pnlInputDeviceSelector.Controls.Add(Me.btnSaveInputDevice)
        Me.pnlInputDeviceSelector.Controls.Add(Me.cbInputDevice)
        Me.pnlInputDeviceSelector.Location = New System.Drawing.Point(57, 198)
        Me.pnlInputDeviceSelector.Name = "pnlInputDeviceSelector"
        Me.pnlInputDeviceSelector.Size = New System.Drawing.Size(353, 150)
        Me.pnlInputDeviceSelector.TabIndex = 59
        Me.pnlInputDeviceSelector.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 53)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Please select a Scanning Device"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSaveInputDevice
        '
        Me.btnSaveInputDevice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSaveInputDevice.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSaveInputDevice.FlatAppearance.BorderSize = 0
        Me.btnSaveInputDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveInputDevice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveInputDevice.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnSaveInputDevice.Location = New System.Drawing.Point(62, 113)
        Me.btnSaveInputDevice.Name = "btnSaveInputDevice"
        Me.btnSaveInputDevice.Size = New System.Drawing.Size(228, 31)
        Me.btnSaveInputDevice.TabIndex = 60
        Me.btnSaveInputDevice.Text = "SAVE"
        Me.btnSaveInputDevice.UseVisualStyleBackColor = False
        '
        'cbInputDevice
        '
        Me.cbInputDevice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbInputDevice.FormattingEnabled = True
        Me.cbInputDevice.Location = New System.Drawing.Point(22, 67)
        Me.cbInputDevice.Name = "cbInputDevice"
        Me.cbInputDevice.Size = New System.Drawing.Size(309, 26)
        Me.cbInputDevice.TabIndex = 1
        '
        'pbWebCamImg
        '
        Me.pbWebCamImg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbWebCamImg.Location = New System.Drawing.Point(10, 119)
        Me.pbWebCamImg.Name = "pbWebCamImg"
        Me.pbWebCamImg.Size = New System.Drawing.Size(447, 358)
        Me.pbWebCamImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbWebCamImg.TabIndex = 60
        Me.pbWebCamImg.TabStop = False
        Me.pbWebCamImg.Visible = False
        '
        'frmScanQRCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(467, 587)
        Me.Controls.Add(Me.pnlInputDeviceSelector)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblScanErr)
        Me.Controls.Add(Me.lbnote)
        Me.Controls.Add(Me.pbDefaultImg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.pbWebCamImg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmScanQRCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbDefaultImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInputDeviceSelector.ResumeLayout(False)
        CType(Me.pbWebCamImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents pbDefaultImg As PictureBox
    Friend WithEvents lbnote As Label
    Friend WithEvents lblScanErr As Label
    Friend WithEvents captureTimer As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlInputDeviceSelector As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbInputDevice As ComboBox
    Friend WithEvents pbWebCamImg As PictureBox
    Friend WithEvents btnSaveInputDevice As Button
End Class
