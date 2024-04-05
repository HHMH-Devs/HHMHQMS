<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchedulesAddEdit
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DayoftheWeek_CB = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.From_CB = New System.Windows.Forms.ComboBox()
        Me.To_CB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.SaveAvailability_BTN = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DayoftheWeek_CB)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 87)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Day of the Week"
        '
        'DayoftheWeek_CB
        '
        Me.DayoftheWeek_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DayoftheWeek_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DayoftheWeek_CB.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.DayoftheWeek_CB.FormattingEnabled = True
        Me.DayoftheWeek_CB.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"})
        Me.DayoftheWeek_CB.Location = New System.Drawing.Point(20, 31)
        Me.DayoftheWeek_CB.MaxDropDownItems = 15
        Me.DayoftheWeek_CB.Name = "DayoftheWeek_CB"
        Me.DayoftheWeek_CB.Size = New System.Drawing.Size(488, 37)
        Me.DayoftheWeek_CB.TabIndex = 60
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.To_CB)
        Me.GroupBox2.Controls.Add(Me.From_CB)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Availability"
        '
        'From_CB
        '
        Me.From_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.From_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.From_CB.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.From_CB.FormattingEnabled = True
        Me.From_CB.Items.AddRange(New Object() {"6 AM", "6:30 AM", "7 AM", "7:30 AM", "8 AM", "8:30 AM", "9 AM", "9:30 AM", "10 AM", "10:30 AM", "11 AM", "11:30 AM", "12 PM", "12:30 PM", "1 PM", "1:30 PM", "2 PM", "2:30 PM", "3 PM", "3:30 PM", "4 PM", "4:30 PM", "5 PM", "5:30 PM", "6 PM", "6:30 PM", "7 PM", "7:30 PM", "8 PM", "8:30 PM", "9 PM", "9:30 PM", "10 PM", "10:30 PM", "11 PM", "11:30 PM", "12 AM", "12:30 AM", "1 AM", "1:30 AM", "2 AM", "2:30 AM", "3 AM", "3:30 AM", "4 AM", "4:30 AM", "5 AM", "5:30 AM"})
        Me.From_CB.Location = New System.Drawing.Point(20, 33)
        Me.From_CB.MaxDropDownItems = 15
        Me.From_CB.Name = "From_CB"
        Me.From_CB.Size = New System.Drawing.Size(225, 37)
        Me.From_CB.TabIndex = 61
        '
        'To_CB
        '
        Me.To_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.To_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.To_CB.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.To_CB.FormattingEnabled = True
        Me.To_CB.Items.AddRange(New Object() {"6 AM", "6:30 AM", "7 AM", "7:30 AM", "8 AM", "8:30 AM", "9 AM", "9:30 AM", "10 AM", "10:30 AM", "11 AM", "11:30 AM", "12 PM", "12:30 PM", "1 PM", "1:30 PM", "2 PM", "2:30 PM", "3 PM", "3:30 PM", "4 PM", "4:30 PM", "5 PM", "5:30 PM", "6 PM", "6:30 PM", "7 PM", "7:30 PM", "8 PM", "8:30 PM", "9 PM", "9:30 PM", "10 PM", "10:30 PM", "11 PM", "11:30 PM", "12 AM", "12:30 AM", "1 AM", "1:30 AM", "2 AM", "2:30 AM", "3 AM", "3:30 AM", "4 AM", "4:30 AM", "5 AM", "5:30 AM"})
        Me.To_CB.Location = New System.Drawing.Point(277, 33)
        Me.To_CB.MaxDropDownItems = 15
        Me.To_CB.Name = "To_CB"
        Me.To_CB.Size = New System.Drawing.Size(231, 37)
        Me.To_CB.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "To"
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.BackColor = System.Drawing.Color.Maroon
        Me.Cancel_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cancel_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_BTN.FlatAppearance.BorderSize = 0
        Me.Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_BTN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_BTN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Cancel_BTN.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Cancel_BTN.Location = New System.Drawing.Point(279, 213)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(137, 30)
        Me.Cancel_BTN.TabIndex = 54
        Me.Cancel_BTN.Text = "&Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = False
        '
        'SaveAvailability_BTN
        '
        Me.SaveAvailability_BTN.BackColor = System.Drawing.Color.LimeGreen
        Me.SaveAvailability_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SaveAvailability_BTN.FlatAppearance.BorderSize = 0
        Me.SaveAvailability_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveAvailability_BTN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveAvailability_BTN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.SaveAvailability_BTN.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.SaveAvailability_BTN.Location = New System.Drawing.Point(136, 213)
        Me.SaveAvailability_BTN.Name = "SaveAvailability_BTN"
        Me.SaveAvailability_BTN.Size = New System.Drawing.Size(137, 30)
        Me.SaveAvailability_BTN.TabIndex = 53
        Me.SaveAvailability_BTN.Text = "&Save"
        Me.SaveAvailability_BTN.UseVisualStyleBackColor = False
        '
        'frmSchedulesAddEdit
        '
        Me.AcceptButton = Me.SaveAvailability_BTN
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Cancel_BTN
        Me.ClientSize = New System.Drawing.Size(553, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel_BTN)
        Me.Controls.Add(Me.SaveAvailability_BTN)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSchedulesAddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DayoftheWeek_CB As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents To_CB As ComboBox
    Friend WithEvents From_CB As ComboBox
    Friend WithEvents Cancel_BTN As Button
    Friend WithEvents SaveAvailability_BTN As Button
End Class
