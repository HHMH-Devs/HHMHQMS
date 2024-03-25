<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DoctorItem))
        Me.lblDoctorName = New System.Windows.Forms.Label()
        Me.pbDoctorImage = New System.Windows.Forms.PictureBox()
        Me.lblDoctorBio = New System.Windows.Forms.Label()
        Me.lblIsActive = New System.Windows.Forms.Label()
        CType(Me.pbDoctorImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDoctorName
        '
        Me.lblDoctorName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoctorName.BackColor = System.Drawing.Color.White
        Me.lblDoctorName.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblDoctorName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblDoctorName.Location = New System.Drawing.Point(127, 5)
        Me.lblDoctorName.Name = "lblDoctorName"
        Me.lblDoctorName.Size = New System.Drawing.Size(255, 42)
        Me.lblDoctorName.TabIndex = 30
        Me.lblDoctorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbDoctorImage
        '
        Me.pbDoctorImage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pbDoctorImage.Image = CType(resources.GetObject("pbDoctorImage.Image"), System.Drawing.Image)
        Me.pbDoctorImage.Location = New System.Drawing.Point(4, 5)
        Me.pbDoctorImage.Name = "pbDoctorImage"
        Me.pbDoctorImage.Size = New System.Drawing.Size(117, 113)
        Me.pbDoctorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDoctorImage.TabIndex = 31
        Me.pbDoctorImage.TabStop = False
        '
        'lblDoctorBio
        '
        Me.lblDoctorBio.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoctorBio.BackColor = System.Drawing.Color.White
        Me.lblDoctorBio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblDoctorBio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblDoctorBio.Location = New System.Drawing.Point(127, 47)
        Me.lblDoctorBio.Name = "lblDoctorBio"
        Me.lblDoctorBio.Size = New System.Drawing.Size(255, 71)
        Me.lblDoctorBio.TabIndex = 32
        '
        'lblIsActive
        '
        Me.lblIsActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIsActive.BackColor = System.Drawing.Color.White
        Me.lblIsActive.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblIsActive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblIsActive.Location = New System.Drawing.Point(127, 92)
        Me.lblIsActive.Name = "lblIsActive"
        Me.lblIsActive.Size = New System.Drawing.Size(255, 26)
        Me.lblIsActive.TabIndex = 33
        Me.lblIsActive.Text = "ACTIVE"
        Me.lblIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblIsActive.Visible = False
        '
        'DoctorItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblDoctorBio)
        Me.Controls.Add(Me.pbDoctorImage)
        Me.Controls.Add(Me.lblDoctorName)
        Me.Controls.Add(Me.lblIsActive)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "DoctorItem"
        Me.Size = New System.Drawing.Size(385, 121)
        CType(Me.pbDoctorImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblDoctorName As Label
    Friend WithEvents pbDoctorImage As PictureBox
    Friend WithEvents lblDoctorBio As Label
    Friend WithEvents lblIsActive As Label
End Class
