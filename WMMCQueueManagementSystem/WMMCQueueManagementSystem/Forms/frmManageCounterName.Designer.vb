<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageCounterName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageCounterName))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnconfirm = New System.Windows.Forms.Button()
        Me.txtCounterCode = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnConfirmCounterBoard = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleGreen
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 44)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "SELECT A COUNTER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnconfirm
        '
        Me.btnconfirm.BackColor = System.Drawing.Color.LimeGreen
        Me.btnconfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnconfirm.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnconfirm.FlatAppearance.BorderSize = 0
        Me.btnconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconfirm.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirm.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnconfirm.Location = New System.Drawing.Point(59, 97)
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.Size = New System.Drawing.Size(214, 33)
        Me.btnconfirm.TabIndex = 19
        Me.btnconfirm.Text = "SAVED"
        Me.btnconfirm.UseVisualStyleBackColor = False
        '
        'txtCounterCode
        '
        Me.txtCounterCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCounterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCounterCode.FormattingEnabled = True
        Me.txtCounterCode.Location = New System.Drawing.Point(12, 63)
        Me.txtCounterCode.Name = "txtCounterCode"
        Me.txtCounterCode.Size = New System.Drawing.Size(308, 28)
        Me.txtCounterCode.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(98, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 25)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnConfirmCounterBoard
        '
        Me.btnConfirmCounterBoard.BackColor = System.Drawing.Color.LimeGreen
        Me.btnConfirmCounterBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfirmCounterBoard.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConfirmCounterBoard.FlatAppearance.BorderSize = 0
        Me.btnConfirmCounterBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmCounterBoard.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmCounterBoard.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnConfirmCounterBoard.Location = New System.Drawing.Point(59, 97)
        Me.btnConfirmCounterBoard.Name = "btnConfirmCounterBoard"
        Me.btnConfirmCounterBoard.Size = New System.Drawing.Size(214, 33)
        Me.btnConfirmCounterBoard.TabIndex = 24
        Me.btnConfirmCounterBoard.Text = "SAVED"
        Me.btnConfirmCounterBoard.UseVisualStyleBackColor = False
        '
        'frmManageCounterName
        '
        Me.AcceptButton = Me.btnconfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(332, 169)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnConfirmCounterBoard)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCounterCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnconfirm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageCounterName"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnconfirm As Button
    Friend WithEvents txtCounterCode As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnConfirmCounterBoard As Button
End Class
