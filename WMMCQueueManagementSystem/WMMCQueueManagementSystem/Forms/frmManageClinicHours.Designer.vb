<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageClinicHours
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"MONDAY", "9:30 AM - 12:45 PM"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"TUESDAY", "9AM - 12PM"}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"WEDNESDAY", "9AM - 12PM"}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"THURSDAY", "9AM - 12PM"}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"FRIDAY", "9AM - 12PM"}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"SATURDAY", "9AM - 12PM"}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"SUNDAY", "9AM - 12PM"}, -1)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvSchedule = New System.Windows.Forms.ListView()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.From_CMB = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.To_CMB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSaveSched = New System.Windows.Forms.Button()
        Me.btnClearSched = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SchedDay_CMB = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddSched = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(351, 51)
        Me.Panel3.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 51)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "MANAGE CLINIC HOURS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvSchedule
        '
        Me.lvSchedule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader1})
        Me.lvSchedule.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSchedule.FullRowSelect = True
        Me.lvSchedule.HideSelection = False
        Me.lvSchedule.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7})
        Me.lvSchedule.Location = New System.Drawing.Point(7, 212)
        Me.lvSchedule.Name = "lvSchedule"
        Me.lvSchedule.Size = New System.Drawing.Size(331, 223)
        Me.lvSchedule.TabIndex = 98
        Me.lvSchedule.UseCompatibleStateImageBehavior = False
        Me.lvSchedule.View = System.Windows.Forms.View.Details
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.From_CMB)
        Me.Panel16.Controls.Add(Me.Label16)
        Me.Panel16.Location = New System.Drawing.Point(8, 94)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(331, 29)
        Me.Panel16.TabIndex = 99
        '
        'From_CMB
        '
        Me.From_CMB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.From_CMB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.From_CMB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.From_CMB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_CMB.FormattingEnabled = True
        Me.From_CMB.Items.AddRange(New Object() {"12:00 AM", "12:15 AM", "12:30 AM", "12:45 AM", "1:00 AM", "1:15 AM", "1:30 AM", "1:45 AM", "2:00 AM", "2:15 AM", "2:30 AM", "2:45 AM", "3:00 AM", "3:15 AM", "3:30 AM", "3:45 AM", "4:00 AM", "4:15 AM", "4:30 AM", "4:45 AM", "5:00 AM", "5:15 AM", "5:30 AM", "5:45 AM", "6:00 AM", "6:15 AM", "6:30 AM", "6:45 AM", "7:00 AM", "7:15 AM", "7:30 AM", "7:45 AM", "8:00 AM", "8:15 AM", "8:30 AM", "8:45 AM", "9:00 AM", "9:15 AM", "9:30 AM", "9:45 AM", "10:00 AM", "10:15 AM", "10:30 AM", "10:45 AM", "11:00 AM", "11:15 AM", "11:30 AM", "11:45 AM", "12:00 PM", "12:15 PM", "12:30 PM", "12:45 PM", "1:00 PM", "1:15 PM", "1:30 PM", "1:45 PM", "2:00 PM", "2:15 PM", "2:30 PM", "2:45 PM", "3:00 PM", "3:15 PM", "3:30 PM", "3:45 PM", "4:00 PM", "4:15 PM", "4:30 PM", "4:45 PM", "5:00 PM", "5:15 PM", "5:30 PM", "5:45 PM", "6:00 PM", "6:15 PM", "6:30 PM", "6:45 PM", "7:00 PM", "7:15 PM", "7:30 PM", "7:45 PM", "8:00 PM", "8:15 PM", "8:30 PM", "8:45 PM", "9:00 PM", "9:15 PM", "9:30 PM", "9:45 PM", "10:00 PM", "10:15 PM", "10:30 PM", "10:45 PM", "11:00 PM", "11:15 PM", "11:30 PM", "11:45 PM"})
        Me.From_CMB.Location = New System.Drawing.Point(48, 0)
        Me.From_CMB.Name = "From_CMB"
        Me.From_CMB.Size = New System.Drawing.Size(281, 27)
        Me.From_CMB.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Honeydew
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 27)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "FROM:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.To_CMB)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(8, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 29)
        Me.Panel1.TabIndex = 100
        '
        'To_CMB
        '
        Me.To_CMB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.To_CMB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.To_CMB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.To_CMB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_CMB.FormattingEnabled = True
        Me.To_CMB.Items.AddRange(New Object() {"12:00 AM", "12:15 AM", "12:30 AM", "12:45 AM", "1:00 AM", "1:15 AM", "1:30 AM", "1:45 AM", "2:00 AM", "2:15 AM", "2:30 AM", "2:45 AM", "3:00 AM", "3:15 AM", "3:30 AM", "3:45 AM", "4:00 AM", "4:15 AM", "4:30 AM", "4:45 AM", "5:00 AM", "5:15 AM", "5:30 AM", "5:45 AM", "6:00 AM", "6:15 AM", "6:30 AM", "6:45 AM", "7:00 AM", "7:15 AM", "7:30 AM", "7:45 AM", "8:00 AM", "8:15 AM", "8:30 AM", "8:45 AM", "9:00 AM", "9:15 AM", "9:30 AM", "9:45 AM", "10:00 AM", "10:15 AM", "10:30 AM", "10:45 AM", "11:00 AM", "11:15 AM", "11:30 AM", "11:45 AM", "12:00 PM", "12:15 PM", "12:30 PM", "12:45 PM", "1:00 PM", "1:15 PM", "1:30 PM", "1:45 PM", "2:00 PM", "2:15 PM", "2:30 PM", "2:45 PM", "3:00 PM", "3:15 PM", "3:30 PM", "3:45 PM", "4:00 PM", "4:15 PM", "4:30 PM", "4:45 PM", "5:00 PM", "5:15 PM", "5:30 PM", "5:45 PM", "6:00 PM", "6:15 PM", "6:30 PM", "6:45 PM", "7:00 PM", "7:15 PM", "7:30 PM", "7:45 PM", "8:00 PM", "8:15 PM", "8:30 PM", "8:45 PM", "9:00 PM", "9:15 PM", "9:30 PM", "9:45 PM", "10:00 PM", "10:15 PM", "10:30 PM", "10:45 PM", "11:00 PM", "11:15 PM", "11:30 PM", "11:45 PM"})
        Me.To_CMB.Location = New System.Drawing.Point(48, 0)
        Me.To_CMB.Name = "To_CMB"
        Me.To_CMB.Size = New System.Drawing.Size(281, 27)
        Me.To_CMB.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Honeydew
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 27)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "TO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSaveSched
        '
        Me.btnSaveSched.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSaveSched.BackColor = System.Drawing.Color.LimeGreen
        Me.btnSaveSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSched.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveSched.ForeColor = System.Drawing.Color.White
        Me.btnSaveSched.Location = New System.Drawing.Point(18, 442)
        Me.btnSaveSched.Name = "btnSaveSched"
        Me.btnSaveSched.Size = New System.Drawing.Size(153, 42)
        Me.btnSaveSched.TabIndex = 101
        Me.btnSaveSched.Text = "SAVE SCHEDULE"
        Me.btnSaveSched.UseVisualStyleBackColor = False
        '
        'btnClearSched
        '
        Me.btnClearSched.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClearSched.BackColor = System.Drawing.Color.Maroon
        Me.btnClearSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSched.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearSched.ForeColor = System.Drawing.Color.White
        Me.btnClearSched.Location = New System.Drawing.Point(174, 442)
        Me.btnClearSched.Name = "btnClearSched"
        Me.btnClearSched.Size = New System.Drawing.Size(153, 42)
        Me.btnClearSched.TabIndex = 102
        Me.btnClearSched.Text = "CLEAR SCHEDULE"
        Me.btnClearSched.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.SchedDay_CMB)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(8, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 29)
        Me.Panel2.TabIndex = 103
        '
        'SchedDay_CMB
        '
        Me.SchedDay_CMB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.SchedDay_CMB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SchedDay_CMB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedDay_CMB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchedDay_CMB.FormattingEnabled = True
        Me.SchedDay_CMB.Items.AddRange(New Object() {"MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY"})
        Me.SchedDay_CMB.Location = New System.Drawing.Point(48, 0)
        Me.SchedDay_CMB.Name = "SchedDay_CMB"
        Me.SchedDay_CMB.Size = New System.Drawing.Size(281, 27)
        Me.SchedDay_CMB.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Honeydew
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 27)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "DAY:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "DAY"
        Me.ColumnHeader8.Width = 134
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 169
        '
        'btnAddSched
        '
        Me.btnAddSched.BackColor = System.Drawing.Color.LimeGreen
        Me.btnAddSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSched.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddSched.ForeColor = System.Drawing.Color.White
        Me.btnAddSched.Location = New System.Drawing.Point(8, 164)
        Me.btnAddSched.Name = "btnAddSched"
        Me.btnAddSched.Size = New System.Drawing.Size(330, 42)
        Me.btnAddSched.TabIndex = 104
        Me.btnAddSched.Text = "ADD"
        Me.btnAddSched.UseVisualStyleBackColor = False
        '
        'frmManageClinicHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(351, 495)
        Me.Controls.Add(Me.btnAddSched)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnClearSched)
        Me.Controls.Add(Me.btnSaveSched)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.lvSchedule)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageClinicHours"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel3.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lvSchedule As ListView
    Friend WithEvents Panel16 As Panel
    Friend WithEvents From_CMB As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents To_CMB As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSaveSched As Button
    Friend WithEvents btnClearSched As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SchedDay_CMB As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents btnAddSched As Button
End Class
