<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectToGenerate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectToGenerate))
        Me.btnGenerateNormalNumber = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGenerateSilentNumber = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGenerateNormalNumber
        '
        Me.btnGenerateNormalNumber.BackColor = System.Drawing.Color.LimeGreen
        Me.btnGenerateNormalNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateNormalNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateNormalNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateNormalNumber.Location = New System.Drawing.Point(10, 12)
        Me.btnGenerateNormalNumber.Name = "btnGenerateNormalNumber"
        Me.btnGenerateNormalNumber.Size = New System.Drawing.Size(387, 116)
        Me.btnGenerateNormalNumber.TabIndex = 2
        Me.btnGenerateNormalNumber.Text = "NORMAL NUMBER" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(NORMAL QUEUEING, ALL PATIENT QUEUING)"
        Me.btnGenerateNormalNumber.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Maroon
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(10, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(387, 45)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnGenerateSilentNumber
        '
        Me.btnGenerateSilentNumber.BackColor = System.Drawing.Color.SlateGray
        Me.btnGenerateSilentNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateSilentNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateSilentNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGenerateSilentNumber.Location = New System.Drawing.Point(10, 134)
        Me.btnGenerateSilentNumber.Name = "btnGenerateSilentNumber"
        Me.btnGenerateSilentNumber.Size = New System.Drawing.Size(387, 69)
        Me.btnGenerateSilentNumber.TabIndex = 45
        Me.btnGenerateSilentNumber.Text = "HIDDEN NUMBER" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(WILL NOT PROMPT OR ALARM ON BOARD)"
        Me.btnGenerateSilentNumber.UseVisualStyleBackColor = False
        '
        'frmSelectToGenerate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(408, 268)
        Me.Controls.Add(Me.btnGenerateSilentNumber)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGenerateNormalNumber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectToGenerate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSelectToGenerate"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGenerateNormalNumber As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnGenerateSilentNumber As Button
End Class
