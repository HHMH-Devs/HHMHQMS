<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCounterQueuingBoardSelectedCountersStandalone
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounterQueuingBoardSelectedCountersStandalone))
        Me.lblHighlightServing = New System.Windows.Forms.Label()
        Me.lblCounters = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.timerwelcome = New System.Windows.Forms.Timer(Me.components)
        Me.refreshDataIntertval = New System.Windows.Forms.Timer(Me.components)
        Me.CLOCK = New System.Windows.Forms.Timer(Me.components)
        Me.txtclock = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbwelcome = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label200 = New System.Windows.Forms.Label()
        Me.Label300 = New System.Windows.Forms.Label()
        Me.Label400 = New System.Windows.Forms.Label()
        Me.lblCounter1 = New System.Windows.Forms.Label()
        Me.lbserving1 = New System.Windows.Forms.Label()
        Me.lblCounter10 = New System.Windows.Forms.Label()
        Me.lbserving10 = New System.Windows.Forms.Label()
        Me.lblCounter2 = New System.Windows.Forms.Label()
        Me.lbserving2 = New System.Windows.Forms.Label()
        Me.lblCounter11 = New System.Windows.Forms.Label()
        Me.lbserving11 = New System.Windows.Forms.Label()
        Me.lblCounter3 = New System.Windows.Forms.Label()
        Me.lbserving3 = New System.Windows.Forms.Label()
        Me.lblCounter12 = New System.Windows.Forms.Label()
        Me.lbserving12 = New System.Windows.Forms.Label()
        Me.lblCounter4 = New System.Windows.Forms.Label()
        Me.lbserving4 = New System.Windows.Forms.Label()
        Me.lblCounter13 = New System.Windows.Forms.Label()
        Me.lbserving13 = New System.Windows.Forms.Label()
        Me.lblCounter5 = New System.Windows.Forms.Label()
        Me.lbserving5 = New System.Windows.Forms.Label()
        Me.lblCounter14 = New System.Windows.Forms.Label()
        Me.lbserving14 = New System.Windows.Forms.Label()
        Me.lblCounter6 = New System.Windows.Forms.Label()
        Me.lbserving6 = New System.Windows.Forms.Label()
        Me.lblCounter15 = New System.Windows.Forms.Label()
        Me.lbserving15 = New System.Windows.Forms.Label()
        Me.lblCounter7 = New System.Windows.Forms.Label()
        Me.lbserving7 = New System.Windows.Forms.Label()
        Me.lblCounter16 = New System.Windows.Forms.Label()
        Me.lbserving16 = New System.Windows.Forms.Label()
        Me.lblCounter8 = New System.Windows.Forms.Label()
        Me.lbserving8 = New System.Windows.Forms.Label()
        Me.lblCounter17 = New System.Windows.Forms.Label()
        Me.lbserving17 = New System.Windows.Forms.Label()
        Me.lblCounter9 = New System.Windows.Forms.Label()
        Me.lbserving9 = New System.Windows.Forms.Label()
        Me.lblCounter18 = New System.Windows.Forms.Label()
        Me.lbserving18 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHighlightServing
        '
        Me.lblHighlightServing.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHighlightServing.BackColor = System.Drawing.Color.LimeGreen
        Me.lblHighlightServing.Font = New System.Drawing.Font("Arial", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighlightServing.ForeColor = System.Drawing.Color.White
        Me.lblHighlightServing.Location = New System.Drawing.Point(275, 301)
        Me.lblHighlightServing.Name = "lblHighlightServing"
        Me.lblHighlightServing.Size = New System.Drawing.Size(885, 458)
        Me.lblHighlightServing.TabIndex = 0
        Me.lblHighlightServing.Text = "Counter Number"
        Me.lblHighlightServing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHighlightServing.Visible = False
        '
        'lblCounters
        '
        Me.lblCounters.BackColor = System.Drawing.Color.LimeGreen
        Me.lblCounters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounters.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounters.ForeColor = System.Drawing.Color.White
        Me.lblCounters.Location = New System.Drawing.Point(0, 0)
        Me.lblCounters.Name = "lblCounters"
        Me.lblCounters.Size = New System.Drawing.Size(1435, 63)
        Me.lblCounters.TabIndex = 47
        Me.lblCounters.Text = "COUNTER NAME"
        Me.lblCounters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel5.Controls.Add(Me.lblCounters)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 998)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1435, 63)
        Me.Panel5.TabIndex = 46
        '
        'timerwelcome
        '
        Me.timerwelcome.Enabled = True
        Me.timerwelcome.Interval = 500
        '
        'refreshDataIntertval
        '
        Me.refreshDataIntertval.Interval = 6000
        '
        'CLOCK
        '
        Me.CLOCK.Interval = 1000
        '
        'txtclock
        '
        Me.txtclock.BackColor = System.Drawing.Color.Transparent
        Me.txtclock.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtclock.Font = New System.Drawing.Font("Arial Narrow", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclock.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtclock.Location = New System.Drawing.Point(1115, 0)
        Me.txtclock.Name = "txtclock"
        Me.txtclock.Size = New System.Drawing.Size(320, 78)
        Me.txtclock.TabIndex = 2
        Me.txtclock.Text = "04:00:00 PM"
        Me.txtclock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel1.Controls.Add(Me.lbwelcome)
        Me.Panel1.Controls.Add(Me.txtclock)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1435, 78)
        Me.Panel1.TabIndex = 44
        '
        'lbwelcome
        '
        Me.lbwelcome.BackColor = System.Drawing.Color.Transparent
        Me.lbwelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbwelcome.Font = New System.Drawing.Font("Arial Narrow", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbwelcome.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbwelcome.Location = New System.Drawing.Point(0, 0)
        Me.lbwelcome.Margin = New System.Windows.Forms.Padding(0)
        Me.lbwelcome.Name = "lbwelcome"
        Me.lbwelcome.Size = New System.Drawing.Size(1115, 78)
        Me.lbwelcome.TabIndex = 3
        Me.lbwelcome.Text = "WELCOME TO HOWARD HUBBARD MEMORIAL HOSPITAL "
        Me.lbwelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label100, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving18, 3, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter18, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving9, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter9, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving17, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter17, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving8, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter8, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving16, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter16, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving7, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter7, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving15, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter15, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving6, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter6, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving14, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter14, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving5, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter5, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving13, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter13, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving4, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving12, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter12, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving3, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving11, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter11, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving10, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter10, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbserving1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCounter1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label400, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label300, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label200, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 78)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1435, 920)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'Label200
        '
        Me.Label200.BackColor = System.Drawing.Color.LimeGreen
        Me.Label200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label200.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label200.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label200.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label200.Location = New System.Drawing.Point(358, 0)
        Me.Label200.Margin = New System.Windows.Forms.Padding(0)
        Me.Label200.Name = "Label200"
        Me.Label200.Size = New System.Drawing.Size(358, 92)
        Me.Label200.TabIndex = 1
        Me.Label200.Text = "SERVING"
        Me.Label200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label300
        '
        Me.Label300.BackColor = System.Drawing.Color.LimeGreen
        Me.Label300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label300.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label300.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label300.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label300.Location = New System.Drawing.Point(716, 0)
        Me.Label300.Margin = New System.Windows.Forms.Padding(0)
        Me.Label300.Name = "Label300"
        Me.Label300.Size = New System.Drawing.Size(358, 92)
        Me.Label300.TabIndex = 2
        Me.Label300.Text = "COUNTER"
        Me.Label300.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label400
        '
        Me.Label400.BackColor = System.Drawing.Color.LimeGreen
        Me.Label400.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label400.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label400.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label400.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label400.Location = New System.Drawing.Point(1074, 0)
        Me.Label400.Margin = New System.Windows.Forms.Padding(0)
        Me.Label400.Name = "Label400"
        Me.Label400.Size = New System.Drawing.Size(361, 92)
        Me.Label400.TabIndex = 3
        Me.Label400.Text = "SERVING"
        Me.Label400.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter1
        '
        Me.lblCounter1.BackColor = System.Drawing.Color.White
        Me.lblCounter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter1.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter1.Location = New System.Drawing.Point(0, 93)
        Me.lblCounter1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter1.Name = "lblCounter1"
        Me.lblCounter1.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter1.TabIndex = 4
        Me.lblCounter1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving1
        '
        Me.lbserving1.BackColor = System.Drawing.Color.White
        Me.lbserving1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving1.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving1.Location = New System.Drawing.Point(358, 93)
        Me.lbserving1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving1.Name = "lbserving1"
        Me.lbserving1.Size = New System.Drawing.Size(358, 90)
        Me.lbserving1.TabIndex = 5
        Me.lbserving1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter10
        '
        Me.lblCounter10.BackColor = System.Drawing.Color.White
        Me.lblCounter10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter10.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter10.Location = New System.Drawing.Point(716, 93)
        Me.lblCounter10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter10.Name = "lblCounter10"
        Me.lblCounter10.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter10.TabIndex = 6
        Me.lblCounter10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving10
        '
        Me.lbserving10.BackColor = System.Drawing.Color.White
        Me.lbserving10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving10.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving10.Location = New System.Drawing.Point(1074, 93)
        Me.lbserving10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving10.Name = "lbserving10"
        Me.lbserving10.Size = New System.Drawing.Size(361, 90)
        Me.lbserving10.TabIndex = 7
        Me.lbserving10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter2
        '
        Me.lblCounter2.BackColor = System.Drawing.Color.White
        Me.lblCounter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter2.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter2.Location = New System.Drawing.Point(0, 185)
        Me.lblCounter2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter2.Name = "lblCounter2"
        Me.lblCounter2.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter2.TabIndex = 8
        Me.lblCounter2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving2
        '
        Me.lbserving2.BackColor = System.Drawing.Color.White
        Me.lbserving2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving2.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving2.Location = New System.Drawing.Point(358, 185)
        Me.lbserving2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving2.Name = "lbserving2"
        Me.lbserving2.Size = New System.Drawing.Size(358, 90)
        Me.lbserving2.TabIndex = 9
        Me.lbserving2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter11
        '
        Me.lblCounter11.BackColor = System.Drawing.Color.White
        Me.lblCounter11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter11.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter11.Location = New System.Drawing.Point(716, 185)
        Me.lblCounter11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter11.Name = "lblCounter11"
        Me.lblCounter11.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter11.TabIndex = 10
        Me.lblCounter11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving11
        '
        Me.lbserving11.BackColor = System.Drawing.Color.White
        Me.lbserving11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving11.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving11.Location = New System.Drawing.Point(1074, 185)
        Me.lbserving11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving11.Name = "lbserving11"
        Me.lbserving11.Size = New System.Drawing.Size(361, 90)
        Me.lbserving11.TabIndex = 11
        Me.lbserving11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter3
        '
        Me.lblCounter3.BackColor = System.Drawing.Color.White
        Me.lblCounter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter3.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter3.Location = New System.Drawing.Point(0, 277)
        Me.lblCounter3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter3.Name = "lblCounter3"
        Me.lblCounter3.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter3.TabIndex = 12
        Me.lblCounter3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving3
        '
        Me.lbserving3.BackColor = System.Drawing.Color.White
        Me.lbserving3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving3.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving3.Location = New System.Drawing.Point(358, 277)
        Me.lbserving3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving3.Name = "lbserving3"
        Me.lbserving3.Size = New System.Drawing.Size(358, 90)
        Me.lbserving3.TabIndex = 13
        Me.lbserving3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter12
        '
        Me.lblCounter12.BackColor = System.Drawing.Color.White
        Me.lblCounter12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter12.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter12.Location = New System.Drawing.Point(716, 277)
        Me.lblCounter12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter12.Name = "lblCounter12"
        Me.lblCounter12.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter12.TabIndex = 14
        Me.lblCounter12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving12
        '
        Me.lbserving12.BackColor = System.Drawing.Color.White
        Me.lbserving12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving12.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving12.Location = New System.Drawing.Point(1074, 277)
        Me.lbserving12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving12.Name = "lbserving12"
        Me.lbserving12.Size = New System.Drawing.Size(361, 90)
        Me.lbserving12.TabIndex = 15
        Me.lbserving12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter4
        '
        Me.lblCounter4.BackColor = System.Drawing.Color.White
        Me.lblCounter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter4.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter4.Location = New System.Drawing.Point(0, 369)
        Me.lblCounter4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter4.Name = "lblCounter4"
        Me.lblCounter4.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter4.TabIndex = 16
        Me.lblCounter4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving4
        '
        Me.lbserving4.BackColor = System.Drawing.Color.White
        Me.lbserving4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving4.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving4.Location = New System.Drawing.Point(358, 369)
        Me.lbserving4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving4.Name = "lbserving4"
        Me.lbserving4.Size = New System.Drawing.Size(358, 90)
        Me.lbserving4.TabIndex = 17
        Me.lbserving4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter13
        '
        Me.lblCounter13.BackColor = System.Drawing.Color.White
        Me.lblCounter13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter13.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter13.Location = New System.Drawing.Point(716, 369)
        Me.lblCounter13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter13.Name = "lblCounter13"
        Me.lblCounter13.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter13.TabIndex = 18
        Me.lblCounter13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving13
        '
        Me.lbserving13.BackColor = System.Drawing.Color.White
        Me.lbserving13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving13.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving13.Location = New System.Drawing.Point(1074, 369)
        Me.lbserving13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving13.Name = "lbserving13"
        Me.lbserving13.Size = New System.Drawing.Size(361, 90)
        Me.lbserving13.TabIndex = 19
        Me.lbserving13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter5
        '
        Me.lblCounter5.BackColor = System.Drawing.Color.White
        Me.lblCounter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter5.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter5.Location = New System.Drawing.Point(0, 461)
        Me.lblCounter5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter5.Name = "lblCounter5"
        Me.lblCounter5.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter5.TabIndex = 20
        Me.lblCounter5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving5
        '
        Me.lbserving5.BackColor = System.Drawing.Color.White
        Me.lbserving5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving5.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving5.Location = New System.Drawing.Point(358, 461)
        Me.lbserving5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving5.Name = "lbserving5"
        Me.lbserving5.Size = New System.Drawing.Size(358, 90)
        Me.lbserving5.TabIndex = 21
        Me.lbserving5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter14
        '
        Me.lblCounter14.BackColor = System.Drawing.Color.White
        Me.lblCounter14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter14.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter14.Location = New System.Drawing.Point(716, 461)
        Me.lblCounter14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter14.Name = "lblCounter14"
        Me.lblCounter14.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter14.TabIndex = 22
        Me.lblCounter14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving14
        '
        Me.lbserving14.BackColor = System.Drawing.Color.White
        Me.lbserving14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving14.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving14.Location = New System.Drawing.Point(1074, 461)
        Me.lbserving14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving14.Name = "lbserving14"
        Me.lbserving14.Size = New System.Drawing.Size(361, 90)
        Me.lbserving14.TabIndex = 23
        Me.lbserving14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter6
        '
        Me.lblCounter6.BackColor = System.Drawing.Color.White
        Me.lblCounter6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter6.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter6.Location = New System.Drawing.Point(0, 553)
        Me.lblCounter6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter6.Name = "lblCounter6"
        Me.lblCounter6.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter6.TabIndex = 24
        Me.lblCounter6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving6
        '
        Me.lbserving6.BackColor = System.Drawing.Color.White
        Me.lbserving6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving6.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving6.Location = New System.Drawing.Point(358, 553)
        Me.lbserving6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving6.Name = "lbserving6"
        Me.lbserving6.Size = New System.Drawing.Size(358, 90)
        Me.lbserving6.TabIndex = 25
        Me.lbserving6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter15
        '
        Me.lblCounter15.BackColor = System.Drawing.Color.White
        Me.lblCounter15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter15.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter15.Location = New System.Drawing.Point(716, 553)
        Me.lblCounter15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter15.Name = "lblCounter15"
        Me.lblCounter15.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter15.TabIndex = 26
        Me.lblCounter15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving15
        '
        Me.lbserving15.BackColor = System.Drawing.Color.White
        Me.lbserving15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving15.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving15.Location = New System.Drawing.Point(1074, 553)
        Me.lbserving15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving15.Name = "lbserving15"
        Me.lbserving15.Size = New System.Drawing.Size(361, 90)
        Me.lbserving15.TabIndex = 27
        Me.lbserving15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter7
        '
        Me.lblCounter7.BackColor = System.Drawing.Color.White
        Me.lblCounter7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter7.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter7.Location = New System.Drawing.Point(0, 645)
        Me.lblCounter7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter7.Name = "lblCounter7"
        Me.lblCounter7.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter7.TabIndex = 28
        Me.lblCounter7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving7
        '
        Me.lbserving7.BackColor = System.Drawing.Color.White
        Me.lbserving7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving7.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving7.Location = New System.Drawing.Point(358, 645)
        Me.lbserving7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving7.Name = "lbserving7"
        Me.lbserving7.Size = New System.Drawing.Size(358, 90)
        Me.lbserving7.TabIndex = 29
        Me.lbserving7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter16
        '
        Me.lblCounter16.BackColor = System.Drawing.Color.White
        Me.lblCounter16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter16.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter16.Location = New System.Drawing.Point(716, 645)
        Me.lblCounter16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter16.Name = "lblCounter16"
        Me.lblCounter16.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter16.TabIndex = 30
        Me.lblCounter16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving16
        '
        Me.lbserving16.BackColor = System.Drawing.Color.White
        Me.lbserving16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving16.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving16.Location = New System.Drawing.Point(1074, 645)
        Me.lbserving16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving16.Name = "lbserving16"
        Me.lbserving16.Size = New System.Drawing.Size(361, 90)
        Me.lbserving16.TabIndex = 31
        Me.lbserving16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter8
        '
        Me.lblCounter8.BackColor = System.Drawing.Color.White
        Me.lblCounter8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter8.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter8.Location = New System.Drawing.Point(0, 737)
        Me.lblCounter8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter8.Name = "lblCounter8"
        Me.lblCounter8.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter8.TabIndex = 32
        Me.lblCounter8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving8
        '
        Me.lbserving8.BackColor = System.Drawing.Color.White
        Me.lbserving8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving8.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving8.Location = New System.Drawing.Point(358, 737)
        Me.lbserving8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving8.Name = "lbserving8"
        Me.lbserving8.Size = New System.Drawing.Size(358, 90)
        Me.lbserving8.TabIndex = 33
        Me.lbserving8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter17
        '
        Me.lblCounter17.BackColor = System.Drawing.Color.White
        Me.lblCounter17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter17.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter17.Location = New System.Drawing.Point(716, 737)
        Me.lblCounter17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter17.Name = "lblCounter17"
        Me.lblCounter17.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter17.TabIndex = 34
        Me.lblCounter17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving17
        '
        Me.lbserving17.BackColor = System.Drawing.Color.White
        Me.lbserving17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving17.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving17.Location = New System.Drawing.Point(1074, 737)
        Me.lbserving17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving17.Name = "lbserving17"
        Me.lbserving17.Size = New System.Drawing.Size(361, 90)
        Me.lbserving17.TabIndex = 35
        Me.lbserving17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter9
        '
        Me.lblCounter9.BackColor = System.Drawing.Color.White
        Me.lblCounter9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter9.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter9.Location = New System.Drawing.Point(0, 829)
        Me.lblCounter9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter9.Name = "lblCounter9"
        Me.lblCounter9.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter9.TabIndex = 36
        Me.lblCounter9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving9
        '
        Me.lbserving9.BackColor = System.Drawing.Color.White
        Me.lbserving9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving9.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving9.Location = New System.Drawing.Point(358, 829)
        Me.lbserving9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving9.Name = "lbserving9"
        Me.lbserving9.Size = New System.Drawing.Size(358, 90)
        Me.lbserving9.TabIndex = 37
        Me.lbserving9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounter18
        '
        Me.lblCounter18.BackColor = System.Drawing.Color.White
        Me.lblCounter18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCounter18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCounter18.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounter18.Location = New System.Drawing.Point(716, 829)
        Me.lblCounter18.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lblCounter18.Name = "lblCounter18"
        Me.lblCounter18.Size = New System.Drawing.Size(358, 90)
        Me.lblCounter18.TabIndex = 38
        Me.lblCounter18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbserving18
        '
        Me.lbserving18.BackColor = System.Drawing.Color.White
        Me.lbserving18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbserving18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbserving18.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbserving18.Location = New System.Drawing.Point(1074, 829)
        Me.lbserving18.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lbserving18.Name = "lbserving18"
        Me.lbserving18.Size = New System.Drawing.Size(361, 90)
        Me.lbserving18.TabIndex = 39
        Me.lbserving18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.LimeGreen
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label100.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label100.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label100.Location = New System.Drawing.Point(0, 0)
        Me.Label100.Margin = New System.Windows.Forms.Padding(0)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(358, 92)
        Me.Label100.TabIndex = 40
        Me.Label100.Text = "COUNTER"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCounterQueuingBoardSelectedCountersStandalone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 1061)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblHighlightServing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounterQueuingBoardSelectedCountersStandalone"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblHighlightServing As Label
    Friend WithEvents lblCounters As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents timerwelcome As Timer
    Friend WithEvents refreshDataIntertval As Timer
    Friend WithEvents CLOCK As Timer
    Friend WithEvents txtclock As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbwelcome As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lbserving18 As Label
    Friend WithEvents lblCounter18 As Label
    Friend WithEvents lbserving9 As Label
    Friend WithEvents lblCounter9 As Label
    Friend WithEvents lbserving17 As Label
    Friend WithEvents lblCounter17 As Label
    Friend WithEvents lbserving8 As Label
    Friend WithEvents lblCounter8 As Label
    Friend WithEvents lbserving16 As Label
    Friend WithEvents lblCounter16 As Label
    Friend WithEvents lbserving7 As Label
    Friend WithEvents lblCounter7 As Label
    Friend WithEvents lbserving15 As Label
    Friend WithEvents lblCounter15 As Label
    Friend WithEvents lbserving6 As Label
    Friend WithEvents lblCounter6 As Label
    Friend WithEvents lbserving14 As Label
    Friend WithEvents lblCounter14 As Label
    Friend WithEvents lbserving5 As Label
    Friend WithEvents lblCounter5 As Label
    Friend WithEvents lbserving13 As Label
    Friend WithEvents lblCounter13 As Label
    Friend WithEvents lbserving4 As Label
    Friend WithEvents lblCounter4 As Label
    Friend WithEvents lbserving12 As Label
    Friend WithEvents lblCounter12 As Label
    Friend WithEvents lbserving3 As Label
    Friend WithEvents lblCounter3 As Label
    Friend WithEvents lbserving11 As Label
    Friend WithEvents lblCounter11 As Label
    Friend WithEvents lbserving2 As Label
    Friend WithEvents lblCounter2 As Label
    Friend WithEvents lbserving10 As Label
    Friend WithEvents lblCounter10 As Label
    Friend WithEvents lbserving1 As Label
    Friend WithEvents lblCounter1 As Label
    Friend WithEvents Label400 As Label
    Friend WithEvents Label300 As Label
    Friend WithEvents Label200 As Label
    Friend WithEvents Label100 As Label
End Class
