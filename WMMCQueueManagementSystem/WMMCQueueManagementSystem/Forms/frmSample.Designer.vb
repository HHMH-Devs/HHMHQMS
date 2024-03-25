<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSample
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.sigImage = New System.Windows.Forms.PictureBox()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(114, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(284, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "READ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(22, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(468, 183)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(22, 230)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(468, 174)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(252, 410)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(227, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(22, 410)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(224, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "SAVE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(496, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 183)
        Me.Panel1.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(496, 201)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(173, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "SAVE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(686, 201)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(176, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Clear"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 457)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(397, 20)
        Me.TextBox1.TabIndex = 8
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(480, 455)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(284, 23)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "FIND"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'sigImage
        '
        Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sigImage.Location = New System.Drawing.Point(496, 230)
        Me.sigImage.Name = "sigImage"
        Me.sigImage.Size = New System.Drawing.Size(366, 174)
        Me.sigImage.TabIndex = 10
        Me.sigImage.TabStop = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(496, 410)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(366, 23)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "CAPTURE"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'frmSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 495)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.sigImage)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmSample"
        Me.Text = "frmSample"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents sigImage As PictureBox
    Friend WithEvents Button7 As Button
End Class
