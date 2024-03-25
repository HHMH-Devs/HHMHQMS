<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectCounterLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectCounterLogin))
        Me.btnconfirm = New System.Windows.Forms.Button()
        Me.txtCounterName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnconfirm
        '
        Me.btnconfirm.BackColor = System.Drawing.Color.LimeGreen
        Me.btnconfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnconfirm.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnconfirm.FlatAppearance.BorderSize = 0
        Me.btnconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconfirm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnconfirm.Location = New System.Drawing.Point(95, 96)
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.Size = New System.Drawing.Size(136, 36)
        Me.btnconfirm.TabIndex = 15
        Me.btnconfirm.Text = "CONFIRM"
        Me.btnconfirm.UseVisualStyleBackColor = False
        '
        'txtCounterName
        '
        Me.txtCounterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounterName.Location = New System.Drawing.Point(12, 64)
        Me.txtCounterName.Name = "txtCounterName"
        Me.txtCounterName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCounterName.Size = New System.Drawing.Size(303, 26)
        Me.txtCounterName.TabIndex = 14
        Me.txtCounterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(95, 138)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 24)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lblTittle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(327, 46)
        Me.Panel1.TabIndex = 19
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(327, 46)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "ENTER THE COUNTER PASSWORD"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSelectCounterLogin
        '
        Me.AcceptButton = Me.btnconfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(327, 169)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnconfirm)
        Me.Controls.Add(Me.txtCounterName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectCounterLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnconfirm As Button
    Friend WithEvents txtCounterName As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTittle As Label
End Class
