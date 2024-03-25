<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaymentMethod
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbcountername = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtNotesAndRemarks = New System.Windows.Forms.RichTextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gbPayMethod = New System.Windows.Forms.GroupBox()
        Me.cbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbPayMethod.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(497, 46)
        Me.Panel1.TabIndex = 10
        '
        'lbcountername
        '
        Me.lbcountername.BackColor = System.Drawing.Color.PaleGreen
        Me.lbcountername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lbcountername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcountername.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcountername.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbcountername.Location = New System.Drawing.Point(0, 0)
        Me.lbcountername.Name = "lbcountername"
        Me.lbcountername.Size = New System.Drawing.Size(497, 46)
        Me.lbcountername.TabIndex = 0
        Me.lbcountername.Text = "SELECT A PAYMENT METHOD"
        Me.lbcountername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.txtNotesAndRemarks)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 106)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(479, 152)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NOTES/REMARKS (Enter your notes here)"
        '
        'txtNotesAndRemarks
        '
        Me.txtNotesAndRemarks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtNotesAndRemarks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotesAndRemarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotesAndRemarks.Location = New System.Drawing.Point(3, 17)
        Me.txtNotesAndRemarks.Name = "txtNotesAndRemarks"
        Me.txtNotesAndRemarks.Size = New System.Drawing.Size(473, 132)
        Me.txtNotesAndRemarks.TabIndex = 0
        Me.txtNotesAndRemarks.Text = "" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Location = New System.Drawing.Point(111, 264)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(274, 38)
        Me.btnSave.TabIndex = 41
        Me.btnSave.Text = "CONFIRM "
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'gbPayMethod
        '
        Me.gbPayMethod.BackColor = System.Drawing.Color.White
        Me.gbPayMethod.Controls.Add(Me.cbPaymentMethod)
        Me.gbPayMethod.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.gbPayMethod.Location = New System.Drawing.Point(9, 52)
        Me.gbPayMethod.Name = "gbPayMethod"
        Me.gbPayMethod.Size = New System.Drawing.Size(479, 49)
        Me.gbPayMethod.TabIndex = 38
        Me.gbPayMethod.TabStop = False
        Me.gbPayMethod.Text = "PAYMENT METHOD"
        '
        'cbPaymentMethod
        '
        Me.cbPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentMethod.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaymentMethod.FormattingEnabled = True
        Me.cbPaymentMethod.Items.AddRange(New Object() {"CASH", "DEBIT/CREDIT CARD", "HMO", "PHILHEALTH"})
        Me.cbPaymentMethod.Location = New System.Drawing.Point(3, 17)
        Me.cbPaymentMethod.Name = "cbPaymentMethod"
        Me.cbPaymentMethod.Size = New System.Drawing.Size(473, 27)
        Me.cbPaymentMethod.TabIndex = 24
        '
        'frmPaymentMethod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(497, 314)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbPayMethod)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPaymentMethod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmPaymentMethod"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.gbPayMethod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbcountername As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtNotesAndRemarks As RichTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents gbPayMethod As GroupBox
    Friend WithEvents cbPaymentMethod As ComboBox
End Class
