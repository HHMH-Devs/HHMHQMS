<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNoGenerated
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoGenerated))
        Me.lblGeneratedNumber = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblGeneratedNumber
        '
        Me.lblGeneratedNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblGeneratedNumber.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGeneratedNumber.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneratedNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblGeneratedNumber.Location = New System.Drawing.Point(0, 0)
        Me.lblGeneratedNumber.Name = "lblGeneratedNumber"
        Me.lblGeneratedNumber.Size = New System.Drawing.Size(235, 106)
        Me.lblGeneratedNumber.TabIndex = 0
        Me.lblGeneratedNumber.Text = "LAB001"
        Me.lblGeneratedNumber.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Brown
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(65, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 25)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "CLOSE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkGray
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(51, 127)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 29)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "PRINT"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmNoGenerated
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(235, 199)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblGeneratedNumber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNoGenerated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNoGenerated"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblGeneratedNumber As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
