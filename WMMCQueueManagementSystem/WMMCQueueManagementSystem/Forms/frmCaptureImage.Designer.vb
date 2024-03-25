<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaptureImage
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlInputDeviceSelector = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSaveInputDevice = New System.Windows.Forms.Button()
        Me.cbInputDevice = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInputDeviceSelector.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(311, 301)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(67, 321)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 41)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "CAPTURE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pnlInputDeviceSelector
        '
        Me.pnlInputDeviceSelector.Controls.Add(Me.Label1)
        Me.pnlInputDeviceSelector.Controls.Add(Me.btnSaveInputDevice)
        Me.pnlInputDeviceSelector.Controls.Add(Me.cbInputDevice)
        Me.pnlInputDeviceSelector.Location = New System.Drawing.Point(19, 81)
        Me.pnlInputDeviceSelector.Name = "pnlInputDeviceSelector"
        Me.pnlInputDeviceSelector.Size = New System.Drawing.Size(294, 150)
        Me.pnlInputDeviceSelector.TabIndex = 60
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
        Me.Label1.Size = New System.Drawing.Size(278, 53)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Please select a Camera"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSaveInputDevice
        '
        Me.btnSaveInputDevice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSaveInputDevice.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSaveInputDevice.FlatAppearance.BorderSize = 0
        Me.btnSaveInputDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveInputDevice.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveInputDevice.ForeColor = System.Drawing.Color.White
        Me.btnSaveInputDevice.Location = New System.Drawing.Point(32, 113)
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
        Me.cbInputDevice.Location = New System.Drawing.Point(27, 67)
        Me.cbInputDevice.Name = "cbInputDevice"
        Me.cbInputDevice.Size = New System.Drawing.Size(239, 26)
        Me.cbInputDevice.TabIndex = 1
        '
        'frmCaptureImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 369)
        Me.Controls.Add(Me.pnlInputDeviceSelector)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmCaptureImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInputDeviceSelector.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents pnlInputDeviceSelector As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveInputDevice As Button
    Friend WithEvents cbInputDevice As ComboBox
End Class
