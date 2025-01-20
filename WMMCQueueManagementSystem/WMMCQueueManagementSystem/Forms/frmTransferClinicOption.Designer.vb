<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferClinicOption
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
        Me.btnTranferToClinic = New System.Windows.Forms.Button()
        Me.btnTranferAndHold = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnTranferToClinic
        '
        Me.btnTranferToClinic.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTranferToClinic.BackColor = System.Drawing.Color.LimeGreen
        Me.btnTranferToClinic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnTranferToClinic.FlatAppearance.BorderSize = 0
        Me.btnTranferToClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTranferToClinic.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTranferToClinic.ForeColor = System.Drawing.Color.White
        Me.btnTranferToClinic.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnTranferToClinic.Location = New System.Drawing.Point(92, 137)
        Me.btnTranferToClinic.Name = "btnTranferToClinic"
        Me.btnTranferToClinic.Size = New System.Drawing.Size(217, 40)
        Me.btnTranferToClinic.TabIndex = 2
        Me.btnTranferToClinic.Text = "TRANSFER TO CLINIC"
        Me.btnTranferToClinic.UseVisualStyleBackColor = False
        '
        'btnTranferAndHold
        '
        Me.btnTranferAndHold.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTranferAndHold.BackColor = System.Drawing.Color.Maroon
        Me.btnTranferAndHold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnTranferAndHold.FlatAppearance.BorderSize = 0
        Me.btnTranferAndHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTranferAndHold.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTranferAndHold.ForeColor = System.Drawing.Color.White
        Me.btnTranferAndHold.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnTranferAndHold.Location = New System.Drawing.Point(92, 194)
        Me.btnTranferAndHold.Name = "btnTranferAndHold"
        Me.btnTranferAndHold.Size = New System.Drawing.Size(217, 40)
        Me.btnTranferAndHold.TabIndex = 5
        Me.btnTranferAndHold.Text = "TRANSFER AND HOLD"
        Me.btnTranferAndHold.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 64)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "If the doctor is not yet present at his/her clinic" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select ""TRANSFER AND HOLD""," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "else" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select ""TRANSFER TO CLINIC""."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.UseMnemonic = False
        '
        'frmTransferClinicOption
        '
        Me.AcceptButton = Me.btnTranferToClinic
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnTranferAndHold
        Me.ClientSize = New System.Drawing.Size(400, 259)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTranferAndHold)
        Me.Controls.Add(Me.btnTranferToClinic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTransferClinicOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer Clinic Option"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTranferToClinic As Button
    Friend WithEvents btnTranferAndHold As Button
    Friend WithEvents Label1 As Label
End Class
