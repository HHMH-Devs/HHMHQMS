<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPass2 = New System.Windows.Forms.TextBox()
        Me.txtPass1 = New System.Windows.Forms.TextBox()
        Me.btnLoginAdmin = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(11, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Re-enter new Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(11, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Enter new Password"
        '
        'txtPass2
        '
        Me.txtPass2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass2.Location = New System.Drawing.Point(8, 95)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(248, 20)
        Me.txtPass2.TabIndex = 10
        '
        'txtPass1
        '
        Me.txtPass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass1.Location = New System.Drawing.Point(8, 41)
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass1.Size = New System.Drawing.Size(248, 20)
        Me.txtPass1.TabIndex = 9
        '
        'btnLoginAdmin
        '
        Me.btnLoginAdmin.BackColor = System.Drawing.Color.Green
        Me.btnLoginAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoginAdmin.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnLoginAdmin.FlatAppearance.BorderSize = 0
        Me.btnLoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoginAdmin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLoginAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnLoginAdmin.Location = New System.Drawing.Point(52, 136)
        Me.btnLoginAdmin.Name = "btnLoginAdmin"
        Me.btnLoginAdmin.Size = New System.Drawing.Size(161, 27)
        Me.btnLoginAdmin.TabIndex = 13
        Me.btnLoginAdmin.Text = "CONFIRM"
        Me.btnLoginAdmin.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(52, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 27)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "CHANGE LATER"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(265, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnLoginAdmin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPass2)
        Me.Controls.Add(Me.txtPass1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPass2 As TextBox
    Friend WithEvents txtPass1 As TextBox
    Friend WithEvents btnLoginAdmin As Button
    Friend WithEvents Button1 As Button
End Class
