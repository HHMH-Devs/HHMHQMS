<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDoleNonDole
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbcountername = New System.Windows.Forms.Label()
        Me.btnDolePatient = New System.Windows.Forms.Button()
        Me.btnNonDolePatient = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(494, 33)
        Me.Panel1.TabIndex = 10
        '
        'lbcountername
        '
        Me.lbcountername.BackColor = System.Drawing.Color.PaleGreen
        Me.lbcountername.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbcountername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcountername.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcountername.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbcountername.Location = New System.Drawing.Point(0, 0)
        Me.lbcountername.Name = "lbcountername"
        Me.lbcountername.Size = New System.Drawing.Size(494, 33)
        Me.lbcountername.TabIndex = 0
        Me.lbcountername.Text = "PLEASE SELECT A TRANSACTION TYPE"
        Me.lbcountername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDolePatient
        '
        Me.btnDolePatient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDolePatient.BackColor = System.Drawing.Color.LimeGreen
        Me.btnDolePatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDolePatient.FlatAppearance.BorderSize = 0
        Me.btnDolePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDolePatient.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDolePatient.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDolePatient.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDolePatient.Location = New System.Drawing.Point(12, 39)
        Me.btnDolePatient.Name = "btnDolePatient"
        Me.btnDolePatient.Size = New System.Drawing.Size(470, 84)
        Me.btnDolePatient.TabIndex = 59
        Me.btnDolePatient.Text = "DOLE PATIENT"
        Me.btnDolePatient.UseVisualStyleBackColor = False
        '
        'btnNonDolePatient
        '
        Me.btnNonDolePatient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNonDolePatient.BackColor = System.Drawing.Color.LimeGreen
        Me.btnNonDolePatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNonDolePatient.FlatAppearance.BorderSize = 0
        Me.btnNonDolePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNonDolePatient.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNonDolePatient.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNonDolePatient.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnNonDolePatient.Location = New System.Drawing.Point(12, 129)
        Me.btnNonDolePatient.Name = "btnNonDolePatient"
        Me.btnNonDolePatient.Size = New System.Drawing.Size(470, 84)
        Me.btnNonDolePatient.TabIndex = 60
        Me.btnNonDolePatient.Text = "NON-DOLE PATIENT"
        Me.btnNonDolePatient.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Maroon
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(105, 222)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(282, 33)
        Me.btnCancel.TabIndex = 61
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmSelectDoleNonDole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(494, 263)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNonDolePatient)
        Me.Controls.Add(Me.btnDolePatient)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectDoleNonDole"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbcountername As Label
    Friend WithEvents btnDolePatient As Button
    Friend WithEvents btnNonDolePatient As Button
    Friend WithEvents btnCancel As Button
End Class
