<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAudioSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAudioSettings))
        Me.tbVolume = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.gbGender = New System.Windows.Forms.GroupBox()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.gbType = New System.Windows.Forms.GroupBox()
        Me.rbBeepVoice = New System.Windows.Forms.RadioButton()
        Me.rbBeep = New System.Windows.Forms.RadioButton()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGender.SuspendLayout()
        Me.gbType.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbVolume
        '
        Me.tbVolume.BackColor = System.Drawing.Color.White
        Me.tbVolume.Location = New System.Drawing.Point(12, 72)
        Me.tbVolume.Maximum = 100
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(289, 45)
        Me.tbVolume.SmallChange = 5
        Me.tbVolume.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "VOICE VOLUME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "VOICE SPEED"
        '
        'tbSpeed
        '
        Me.tbSpeed.BackColor = System.Drawing.Color.White
        Me.tbSpeed.LargeChange = 1
        Me.tbSpeed.Location = New System.Drawing.Point(11, 146)
        Me.tbSpeed.Maximum = 5
        Me.tbSpeed.Minimum = -5
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(290, 45)
        Me.tbSpeed.TabIndex = 2
        '
        'gbGender
        '
        Me.gbGender.BackColor = System.Drawing.Color.Transparent
        Me.gbGender.Controls.Add(Me.rbFemale)
        Me.gbGender.Controls.Add(Me.rbMale)
        Me.gbGender.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbGender.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbGender.Location = New System.Drawing.Point(12, 197)
        Me.gbGender.Name = "gbGender"
        Me.gbGender.Size = New System.Drawing.Size(132, 97)
        Me.gbGender.TabIndex = 4
        Me.gbGender.TabStop = False
        Me.gbGender.Text = "Voice Gender"
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.Location = New System.Drawing.Point(20, 58)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(63, 20)
        Me.rbFemale.TabIndex = 1
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = True
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.Checked = True
        Me.rbMale.Location = New System.Drawing.Point(20, 28)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(50, 20)
        Me.rbMale.TabIndex = 0
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = True
        '
        'gbType
        '
        Me.gbType.BackColor = System.Drawing.Color.Transparent
        Me.gbType.Controls.Add(Me.rbBeepVoice)
        Me.gbType.Controls.Add(Me.rbBeep)
        Me.gbType.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.gbType.Location = New System.Drawing.Point(156, 197)
        Me.gbType.Name = "gbType"
        Me.gbType.Size = New System.Drawing.Size(145, 97)
        Me.gbType.TabIndex = 6
        Me.gbType.TabStop = False
        Me.gbType.Text = "Paging Type"
        '
        'rbBeepVoice
        '
        Me.rbBeepVoice.AutoSize = True
        Me.rbBeepVoice.BackColor = System.Drawing.Color.Transparent
        Me.rbBeepVoice.Location = New System.Drawing.Point(20, 58)
        Me.rbBeepVoice.Name = "rbBeepVoice"
        Me.rbBeepVoice.Size = New System.Drawing.Size(85, 20)
        Me.rbBeepVoice.TabIndex = 1
        Me.rbBeepVoice.Text = "Beep/Voice"
        Me.rbBeepVoice.UseVisualStyleBackColor = False
        '
        'rbBeep
        '
        Me.rbBeep.AutoSize = True
        Me.rbBeep.Checked = True
        Me.rbBeep.Location = New System.Drawing.Point(20, 28)
        Me.rbBeep.Name = "rbBeep"
        Me.rbBeep.Size = New System.Drawing.Size(53, 20)
        Me.rbBeep.TabIndex = 0
        Me.rbBeep.TabStop = True
        Me.rbBeep.Text = "Beep"
        Me.rbBeep.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTest.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTest.ForeColor = System.Drawing.Color.White
        Me.btnTest.Location = New System.Drawing.Point(12, 311)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(138, 31)
        Me.btnTest.TabIndex = 7
        Me.btnTest.Text = "TEST"
        Me.btnTest.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(156, 311)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 31)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "SAVE CHANGES"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lblTittle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 46)
        Me.Panel1.TabIndex = 10
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(314, 46)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "AUDIO SETTINGS"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(75, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 26)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmAudioSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(314, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.gbType)
        Me.Controls.Add(Me.gbGender)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbSpeed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbVolume)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAudioSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGender.ResumeLayout(False)
        Me.gbGender.PerformLayout()
        Me.gbType.ResumeLayout(False)
        Me.gbType.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbVolume As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbSpeed As TrackBar
    Friend WithEvents gbGender As GroupBox
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents gbType As GroupBox
    Friend WithEvents rbBeepVoice As RadioButton
    Friend WithEvents rbBeep As RadioButton
    Friend WithEvents btnTest As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTittle As Label
    Friend WithEvents Button1 As Button
End Class
