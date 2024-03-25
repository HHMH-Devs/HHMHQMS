<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatePicker
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
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblGeneratedNumber = New System.Windows.Forms.Label()
        Me.btnSelectDate = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(18, 79)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(300, 29)
        Me.dtpDateFrom.TabIndex = 0
        '
        'lblGeneratedNumber
        '
        Me.lblGeneratedNumber.BackColor = System.Drawing.Color.PaleGreen
        Me.lblGeneratedNumber.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGeneratedNumber.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneratedNumber.ForeColor = System.Drawing.Color.White
        Me.lblGeneratedNumber.Location = New System.Drawing.Point(0, 0)
        Me.lblGeneratedNumber.Name = "lblGeneratedNumber"
        Me.lblGeneratedNumber.Size = New System.Drawing.Size(639, 36)
        Me.lblGeneratedNumber.TabIndex = 1
        Me.lblGeneratedNumber.Text = "SELECT A DATE"
        Me.lblGeneratedNumber.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnSelectDate
        '
        Me.btnSelectDate.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSelectDate.FlatAppearance.BorderSize = 0
        Me.btnSelectDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectDate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSelectDate.Location = New System.Drawing.Point(321, 120)
        Me.btnSelectDate.Name = "btnSelectDate"
        Me.btnSelectDate.Size = New System.Drawing.Size(303, 29)
        Me.btnSelectDate.TabIndex = 3
        Me.btnSelectDate.Text = "OK"
        Me.btnSelectDate.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(18, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(300, 29)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(324, 79)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(300, 29)
        Me.dtpDateTo.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(21, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 22)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "FROM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(327, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 22)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "TO"
        '
        'frmDatePicker
        '
        Me.AcceptButton = Me.btnSelectDate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(639, 158)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpDateTo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSelectDate)
        Me.Controls.Add(Me.lblGeneratedNumber)
        Me.Controls.Add(Me.dtpDateFrom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDatePicker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents lblGeneratedNumber As Label
    Friend WithEvents btnSelectDate As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
End Class
