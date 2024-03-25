<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFindPatient_Touch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindPatient_Touch))
        Me.pnlRegisterAlert = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.btnConfirmSelection = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nubYear = New System.Windows.Forms.NumericUpDown()
        Me.cbDay = New System.Windows.Forms.ComboBox()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlRegisterAlert.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.nubYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRegisterAlert
        '
        Me.pnlRegisterAlert.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlRegisterAlert.BackColor = System.Drawing.Color.Honeydew
        Me.pnlRegisterAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRegisterAlert.Controls.Add(Me.PictureBox1)
        Me.pnlRegisterAlert.Controls.Add(Me.Button3)
        Me.pnlRegisterAlert.Controls.Add(Me.Button2)
        Me.pnlRegisterAlert.Controls.Add(Me.lblWarning)
        Me.pnlRegisterAlert.Location = New System.Drawing.Point(2, 3)
        Me.pnlRegisterAlert.Name = "pnlRegisterAlert"
        Me.pnlRegisterAlert.Size = New System.Drawing.Size(845, 541)
        Me.pnlRegisterAlert.TabIndex = 64
        Me.pnlRegisterAlert.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(336, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Location = New System.Drawing.Point(78, 445)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(331, 80)
        Me.Button3.TabIndex = 50
        Me.Button3.Text = "NO"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Location = New System.Drawing.Point(432, 445)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(331, 80)
        Me.Button2.TabIndex = 48
        Me.Button2.Text = "YES"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'lblWarning
        '
        Me.lblWarning.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblWarning.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Maroon
        Me.lblWarning.Location = New System.Drawing.Point(29, 173)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(789, 248)
        Me.lblWarning.TabIndex = 49
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConfirmSelection
        '
        Me.btnConfirmSelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmSelection.BackColor = System.Drawing.Color.LimeGreen
        Me.btnConfirmSelection.FlatAppearance.BorderSize = 0
        Me.btnConfirmSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmSelection.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmSelection.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnConfirmSelection.Location = New System.Drawing.Point(436, 449)
        Me.btnConfirmSelection.Name = "btnConfirmSelection"
        Me.btnConfirmSelection.Size = New System.Drawing.Size(331, 71)
        Me.btnConfirmSelection.TabIndex = 6
        Me.btnConfirmSelection.Text = "SEARCH"
        Me.btnConfirmSelection.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Location = New System.Drawing.Point(81, 449)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(331, 71)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(31, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 27)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "BIRTH DATE"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(2, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(727, 83)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "NOTE: PLEASE ENTER THE FOLLOWING BY CLICKING THE BOX"
        '
        'txtFName
        '
        Me.txtFName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtFName.BackColor = System.Drawing.Color.Ivory
        Me.txtFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.Location = New System.Drawing.Point(27, 189)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(273, 38)
        Me.txtFName.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 57)
        Me.Panel2.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(850, 57)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "VERIFY YOUR INFORMATION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(63, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(647, 32)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "By clicking Search, you've agreed to our data policy."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold)
        Me.LinkLabel1.Location = New System.Drawing.Point(562, 392)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(212, 31)
        Me.LinkLabel1.TabIndex = 71
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "data privacy policy"
        '
        'txtMName
        '
        Me.txtMName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMName.BackColor = System.Drawing.Color.Ivory
        Me.txtMName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMName.Location = New System.Drawing.Point(307, 189)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(201, 38)
        Me.txtMName.TabIndex = 1
        '
        'txtLName
        '
        Me.txtLName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtLName.BackColor = System.Drawing.Color.Ivory
        Me.txtLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.Location = New System.Drawing.Point(514, 189)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(302, 38)
        Me.txtLName.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(30, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 27)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "FIRST NAME"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(310, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(174, 27)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "MIDDLE NAME"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(517, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 27)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "LAST NAME"
        '
        'nubYear
        '
        Me.nubYear.BackColor = System.Drawing.Color.Ivory
        Me.nubYear.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nubYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.nubYear.Location = New System.Drawing.Point(603, 325)
        Me.nubYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nubYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.nubYear.Name = "nubYear"
        Me.nubYear.Size = New System.Drawing.Size(213, 44)
        Me.nubYear.TabIndex = 5
        Me.nubYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nubYear.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'cbDay
        '
        Me.cbDay.BackColor = System.Drawing.Color.Ivory
        Me.cbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDay.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.cbDay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.cbDay.FormattingEnabled = True
        Me.cbDay.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cbDay.Location = New System.Drawing.Point(381, 324)
        Me.cbDay.Name = "cbDay"
        Me.cbDay.Size = New System.Drawing.Size(216, 45)
        Me.cbDay.TabIndex = 4
        '
        'cbMonth
        '
        Me.cbMonth.BackColor = System.Drawing.Color.Ivory
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.cbMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.cbMonth.Location = New System.Drawing.Point(27, 324)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(348, 45)
        Me.cbMonth.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(31, 286)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 27)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "MONTH"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(385, 286)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 27)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "DAY"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(607, 286)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 27)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "YEAR"
        '
        'frmFindPatient_Touch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(850, 546)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlRegisterAlert)
        Me.Controls.Add(Me.btnConfirmSelection)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtFName)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtMName)
        Me.Controls.Add(Me.txtLName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nubYear)
        Me.Controls.Add(Me.cbDay)
        Me.Controls.Add(Me.cbMonth)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindPatient_Touch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlRegisterAlert.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.nubYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlRegisterAlert As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents lblWarning As Label
    Friend WithEvents btnConfirmSelection As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFName As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtMName As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nubYear As NumericUpDown
    Friend WithEvents cbDay As ComboBox
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
