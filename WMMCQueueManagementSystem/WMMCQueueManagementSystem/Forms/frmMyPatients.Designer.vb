<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMyPatients
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbNameSearch = New System.Windows.Forms.GroupBox()
        Me.txtKeyword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvCustomerFindList = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpfname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpmname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmplname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpgender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FK_emdPatient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnHideMoreInfo = New System.Windows.Forms.Button()
        Me.pnlMoreInfo = New System.Windows.Forms.Panel()
        Me.lbbday = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbsex = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnConfirmSelection = New System.Windows.Forms.Button()
        Me.lblname = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbmname = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbfname = New System.Windows.Forms.Label()
        Me.lbnote = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.gbNameSearch.SuspendLayout()
        CType(Me.dgvCustomerFindList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMoreInfo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 60)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(840, 60)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "FIND PATIENT FROM HISTORY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbNameSearch
        '
        Me.gbNameSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbNameSearch.Controls.Add(Me.txtKeyword)
        Me.gbNameSearch.Controls.Add(Me.Button1)
        Me.gbNameSearch.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNameSearch.ForeColor = System.Drawing.Color.Black
        Me.gbNameSearch.Location = New System.Drawing.Point(9, 66)
        Me.gbNameSearch.Name = "gbNameSearch"
        Me.gbNameSearch.Size = New System.Drawing.Size(822, 79)
        Me.gbNameSearch.TabIndex = 32
        Me.gbNameSearch.TabStop = False
        Me.gbNameSearch.Text = "Enter patient name"
        '
        'txtKeyword
        '
        Me.txtKeyword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKeyword.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyword.Location = New System.Drawing.Point(6, 30)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(645, 35)
        Me.txtKeyword.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(657, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 45)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "FIND"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvCustomerFindList
        '
        Me.dgvCustomerFindList.AllowUserToAddRows = False
        Me.dgvCustomerFindList.AllowUserToDeleteRows = False
        Me.dgvCustomerFindList.AllowUserToResizeRows = False
        Me.dgvCustomerFindList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerFindList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomerFindList.BackgroundColor = System.Drawing.Color.Honeydew
        Me.dgvCustomerFindList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(145, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerFindList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerFindList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerFindList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fullname, Me.bday, Me.tmpfname, Me.tmpmname, Me.tmplname, Me.tmpgender, Me.FK_emdPatient})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerFindList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomerFindList.Location = New System.Drawing.Point(9, 151)
        Me.dgvCustomerFindList.Name = "dgvCustomerFindList"
        Me.dgvCustomerFindList.ReadOnly = True
        Me.dgvCustomerFindList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvCustomerFindList.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dgvCustomerFindList.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomerFindList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomerFindList.Size = New System.Drawing.Size(822, 379)
        Me.dgvCustomerFindList.TabIndex = 33
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'fullname
        '
        Me.fullname.FillWeight = 150.0!
        Me.fullname.HeaderText = "Full Name"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        '
        'bday
        '
        Me.bday.HeaderText = "Birth Date"
        Me.bday.Name = "bday"
        Me.bday.ReadOnly = True
        '
        'tmpfname
        '
        Me.tmpfname.HeaderText = "first name"
        Me.tmpfname.Name = "tmpfname"
        Me.tmpfname.ReadOnly = True
        Me.tmpfname.Visible = False
        '
        'tmpmname
        '
        Me.tmpmname.HeaderText = "middle name"
        Me.tmpmname.Name = "tmpmname"
        Me.tmpmname.ReadOnly = True
        Me.tmpmname.Visible = False
        '
        'tmplname
        '
        Me.tmplname.HeaderText = "last name"
        Me.tmplname.Name = "tmplname"
        Me.tmplname.ReadOnly = True
        Me.tmplname.Visible = False
        '
        'tmpgender
        '
        Me.tmpgender.HeaderText = "sex"
        Me.tmpgender.Name = "tmpgender"
        Me.tmpgender.ReadOnly = True
        Me.tmpgender.Visible = False
        '
        'FK_emdPatient
        '
        Me.FK_emdPatient.HeaderText = "FK_emdPatient"
        Me.FK_emdPatient.Name = "FK_emdPatient"
        Me.FK_emdPatient.ReadOnly = True
        Me.FK_emdPatient.Visible = False
        '
        'btnHideMoreInfo
        '
        Me.btnHideMoreInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnHideMoreInfo.BackColor = System.Drawing.Color.Maroon
        Me.btnHideMoreInfo.FlatAppearance.BorderSize = 0
        Me.btnHideMoreInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHideMoreInfo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHideMoreInfo.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnHideMoreInfo.Location = New System.Drawing.Point(283, 541)
        Me.btnHideMoreInfo.Name = "btnHideMoreInfo"
        Me.btnHideMoreInfo.Size = New System.Drawing.Size(274, 46)
        Me.btnHideMoreInfo.TabIndex = 45
        Me.btnHideMoreInfo.Text = "CANCEL"
        Me.btnHideMoreInfo.UseVisualStyleBackColor = False
        '
        'pnlMoreInfo
        '
        Me.pnlMoreInfo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlMoreInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMoreInfo.Controls.Add(Me.lbbday)
        Me.pnlMoreInfo.Controls.Add(Me.Label8)
        Me.pnlMoreInfo.Controls.Add(Me.lbsex)
        Me.pnlMoreInfo.Controls.Add(Me.Label5)
        Me.pnlMoreInfo.Controls.Add(Me.Button2)
        Me.pnlMoreInfo.Controls.Add(Me.btnConfirmSelection)
        Me.pnlMoreInfo.Controls.Add(Me.lblname)
        Me.pnlMoreInfo.Controls.Add(Me.Label6)
        Me.pnlMoreInfo.Controls.Add(Me.lbmname)
        Me.pnlMoreInfo.Controls.Add(Me.Label4)
        Me.pnlMoreInfo.Controls.Add(Me.lbfname)
        Me.pnlMoreInfo.Controls.Add(Me.lbnote)
        Me.pnlMoreInfo.Controls.Add(Me.Panel3)
        Me.pnlMoreInfo.Location = New System.Drawing.Point(9, 3)
        Me.pnlMoreInfo.Name = "pnlMoreInfo"
        Me.pnlMoreInfo.Size = New System.Drawing.Size(822, 584)
        Me.pnlMoreInfo.TabIndex = 46
        Me.pnlMoreInfo.Visible = False
        '
        'lbbday
        '
        Me.lbbday.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbbday.BackColor = System.Drawing.Color.Transparent
        Me.lbbday.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbbday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbbday.Location = New System.Drawing.Point(309, 372)
        Me.lbbday.Name = "lbbday"
        Me.lbbday.Size = New System.Drawing.Size(484, 40)
        Me.lbbday.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(15, 372)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(288, 40)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "BIRTH DATE:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbsex
        '
        Me.lbsex.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbsex.BackColor = System.Drawing.Color.Transparent
        Me.lbsex.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbsex.Location = New System.Drawing.Point(309, 315)
        Me.lbsex.Name = "lbsex"
        Me.lbsex.Size = New System.Drawing.Size(484, 40)
        Me.lbsex.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(15, 315)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 40)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "GENDER:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Maroon
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(70, 499)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(331, 65)
        Me.Button2.TabIndex = 44
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnConfirmSelection
        '
        Me.btnConfirmSelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmSelection.BackColor = System.Drawing.Color.Green
        Me.btnConfirmSelection.FlatAppearance.BorderSize = 0
        Me.btnConfirmSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmSelection.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmSelection.ForeColor = System.Drawing.Color.White
        Me.btnConfirmSelection.Location = New System.Drawing.Point(420, 499)
        Me.btnConfirmSelection.Name = "btnConfirmSelection"
        Me.btnConfirmSelection.Size = New System.Drawing.Size(331, 65)
        Me.btnConfirmSelection.TabIndex = 34
        Me.btnConfirmSelection.Text = "CONFIRM"
        Me.btnConfirmSelection.UseVisualStyleBackColor = False
        '
        'lblname
        '
        Me.lblname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(309, 225)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(484, 40)
        Me.lblname.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(288, 40)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "LAST NAME:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbmname
        '
        Me.lbmname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbmname.BackColor = System.Drawing.Color.Transparent
        Me.lbmname.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbmname.Location = New System.Drawing.Point(309, 172)
        Me.lbmname.Name = "lbmname"
        Me.lbmname.Size = New System.Drawing.Size(484, 40)
        Me.lbmname.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(288, 40)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "MIDDLE NAME:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbfname
        '
        Me.lbfname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbfname.BackColor = System.Drawing.Color.Transparent
        Me.lbfname.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbfname.Location = New System.Drawing.Point(309, 120)
        Me.lbfname.Name = "lbfname"
        Me.lbfname.Size = New System.Drawing.Size(484, 40)
        Me.lbfname.TabIndex = 37
        '
        'lbnote
        '
        Me.lbnote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbnote.BackColor = System.Drawing.Color.Transparent
        Me.lbnote.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbnote.Location = New System.Drawing.Point(15, 120)
        Me.lbnote.Name = "lbnote"
        Me.lbnote.Size = New System.Drawing.Size(288, 40)
        Me.lbnote.TabIndex = 36
        Me.lbnote.Text = "FIRST NAME:"
        Me.lbnote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(820, 75)
        Me.Panel3.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(820, 75)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "VERIFY PATIENT INFORMATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMyPatients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(840, 594)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMoreInfo)
        Me.Controls.Add(Me.btnHideMoreInfo)
        Me.Controls.Add(Me.dgvCustomerFindList)
        Me.Controls.Add(Me.gbNameSearch)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMyPatients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.gbNameSearch.ResumeLayout(False)
        Me.gbNameSearch.PerformLayout()
        CType(Me.dgvCustomerFindList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMoreInfo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents gbNameSearch As GroupBox
    Friend WithEvents txtKeyword As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents dgvCustomerFindList As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fullname As DataGridViewTextBoxColumn
    Friend WithEvents bday As DataGridViewTextBoxColumn
    Friend WithEvents tmpfname As DataGridViewTextBoxColumn
    Friend WithEvents tmpmname As DataGridViewTextBoxColumn
    Friend WithEvents tmplname As DataGridViewTextBoxColumn
    Friend WithEvents tmpgender As DataGridViewTextBoxColumn
    Friend WithEvents FK_emdPatient As DataGridViewTextBoxColumn
    Friend WithEvents btnHideMoreInfo As Button
    Friend WithEvents pnlMoreInfo As Panel
    Friend WithEvents lbbday As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbsex As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnConfirmSelection As Button
    Friend WithEvents lblname As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbmname As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbfname As Label
    Friend WithEvents lbnote As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
End Class
