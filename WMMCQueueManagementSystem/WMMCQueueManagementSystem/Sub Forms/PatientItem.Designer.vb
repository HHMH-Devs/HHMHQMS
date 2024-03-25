<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PatientItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientItem))
        Me.lblCustomerInfo = New System.Windows.Forms.Label()
        Me.lblGeneratedNumber = New System.Windows.Forms.Label()
        Me.pbDepartment = New System.Windows.Forms.PictureBox()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.pbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCustomerInfo
        '
        Me.lblCustomerInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCustomerInfo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerInfo.ForeColor = System.Drawing.Color.Black
        Me.lblCustomerInfo.Location = New System.Drawing.Point(80, 6)
        Me.lblCustomerInfo.Name = "lblCustomerInfo"
        Me.lblCustomerInfo.Size = New System.Drawing.Size(241, 46)
        Me.lblCustomerInfo.TabIndex = 4
        '
        'lblGeneratedNumber
        '
        Me.lblGeneratedNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGeneratedNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGeneratedNumber.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneratedNumber.ForeColor = System.Drawing.Color.Black
        Me.lblGeneratedNumber.Location = New System.Drawing.Point(80, 38)
        Me.lblGeneratedNumber.Name = "lblGeneratedNumber"
        Me.lblGeneratedNumber.Size = New System.Drawing.Size(241, 27)
        Me.lblGeneratedNumber.TabIndex = 5
        Me.lblGeneratedNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbDepartment
        '
        Me.pbDepartment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbDepartment.Location = New System.Drawing.Point(5, 3)
        Me.pbDepartment.Name = "pbDepartment"
        Me.pbDepartment.Size = New System.Drawing.Size(69, 61)
        Me.pbDepartment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDepartment.TabIndex = 6
        Me.pbDepartment.TabStop = False
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "man.png")
        Me.imgList.Images.SetKeyName(1, "woman.png")
        Me.imgList.Images.SetKeyName(2, "wait.png")
        Me.imgList.Images.SetKeyName(3, "onprocess.png")
        Me.imgList.Images.SetKeyName(4, "done.png")
        Me.imgList.Images.SetKeyName(5, "mwell consult")
        '
        'PatientItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.Controls.Add(Me.pbDepartment)
        Me.Controls.Add(Me.lblGeneratedNumber)
        Me.Controls.Add(Me.lblCustomerInfo)
        Me.Name = "PatientItem"
        Me.Size = New System.Drawing.Size(324, 67)
        CType(Me.pbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCustomerInfo As Label
    Friend WithEvents lblGeneratedNumber As Label
    Friend WithEvents pbDepartment As PictureBox
    Friend WithEvents imgList As ImageList
End Class
