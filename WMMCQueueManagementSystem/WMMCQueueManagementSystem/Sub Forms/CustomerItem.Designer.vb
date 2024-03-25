<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerItem
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerItem))
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.lblGeneratedNumber = New System.Windows.Forms.Label()
        Me.lblCustomerInfo = New System.Windows.Forms.Label()
        Me.pbStatus = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "smiling-face.png")
        Me.imgList.Images.SetKeyName(1, "sad.png")
        Me.imgList.Images.SetKeyName(2, "angry.png")
        Me.imgList.Images.SetKeyName(3, "mwell")
        '
        'lblGeneratedNumber
        '
        Me.lblGeneratedNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGeneratedNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGeneratedNumber.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneratedNumber.ForeColor = System.Drawing.Color.Black
        Me.lblGeneratedNumber.Location = New System.Drawing.Point(94, 63)
        Me.lblGeneratedNumber.Name = "lblGeneratedNumber"
        Me.lblGeneratedNumber.Size = New System.Drawing.Size(179, 27)
        Me.lblGeneratedNumber.TabIndex = 2
        Me.lblGeneratedNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomerInfo
        '
        Me.lblCustomerInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomerInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCustomerInfo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerInfo.ForeColor = System.Drawing.Color.Black
        Me.lblCustomerInfo.Location = New System.Drawing.Point(94, 8)
        Me.lblCustomerInfo.Name = "lblCustomerInfo"
        Me.lblCustomerInfo.Size = New System.Drawing.Size(218, 52)
        Me.lblCustomerInfo.TabIndex = 3
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbStatus.Location = New System.Drawing.Point(29, 19)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(50, 50)
        Me.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbStatus.TabIndex = 6
        Me.pbStatus.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(277, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'CustomerItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.lblCustomerInfo)
        Me.Controls.Add(Me.lblGeneratedNumber)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "CustomerItem"
        Me.Size = New System.Drawing.Size(315, 90)
        CType(Me.pbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imgList As ImageList
    Friend WithEvents lblGeneratedNumber As Label
    Friend WithEvents lblCustomerInfo As Label
    Friend WithEvents pbStatus As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
