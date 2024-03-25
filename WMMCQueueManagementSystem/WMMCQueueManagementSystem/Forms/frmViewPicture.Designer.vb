<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewPicture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewPicture))
        Me.pbProfilePicture = New System.Windows.Forms.PictureBox()
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbProfilePicture
        '
        Me.pbProfilePicture.BackgroundImage = CType(resources.GetObject("pbProfilePicture.BackgroundImage"), System.Drawing.Image)
        Me.pbProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbProfilePicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbProfilePicture.Location = New System.Drawing.Point(0, 0)
        Me.pbProfilePicture.Name = "pbProfilePicture"
        Me.pbProfilePicture.Size = New System.Drawing.Size(364, 361)
        Me.pbProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbProfilePicture.TabIndex = 46
        Me.pbProfilePicture.TabStop = False
        '
        'frmViewPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(364, 361)
        Me.Controls.Add(Me.pbProfilePicture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewPicture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.pbProfilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbProfilePicture As PictureBox
End Class
