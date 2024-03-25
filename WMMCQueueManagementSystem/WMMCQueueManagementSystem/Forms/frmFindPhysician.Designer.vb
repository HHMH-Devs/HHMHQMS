<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindPhysician
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTittle = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvCustomerFindList = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.specialization = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpfname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpmname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmplname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpprimaryContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmpsecondaryContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbNameSearch = New System.Windows.Forms.GroupBox()
        Me.txtKeyword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblCantFindAlert = New System.Windows.Forms.Label()
        Me.pnlMoreInfo = New System.Windows.Forms.Panel()
        Me.lblSecondaryContact = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPrimaryContact = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbSpecialization = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnHideMoreInfo = New System.Windows.Forms.Button()
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
        CType(Me.dgvCustomerFindList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNameSearch.SuspendLayout()
        Me.pnlMoreInfo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lblTittle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(846, 73)
        Me.Panel1.TabIndex = 19
        '
        'lblTittle
        '
        Me.lblTittle.BackColor = System.Drawing.Color.PaleGreen
        Me.lblTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTittle.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTittle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTittle.Location = New System.Drawing.Point(0, 0)
        Me.lblTittle.Name = "lblTittle"
        Me.lblTittle.Size = New System.Drawing.Size(846, 73)
        Me.lblTittle.TabIndex = 0
        Me.lblTittle.Text = "PLEASE SELECT THE DOCTOR"
        Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.BackColor = System.Drawing.Color.Maroon
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(619, 556)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(219, 66)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dgvCustomerFindList
        '
        Me.dgvCustomerFindList.AllowUserToAddRows = False
        Me.dgvCustomerFindList.AllowUserToDeleteRows = False
        Me.dgvCustomerFindList.AllowUserToResizeRows = False
        Me.dgvCustomerFindList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCustomerFindList.BackgroundColor = System.Drawing.Color.Honeydew
        Me.dgvCustomerFindList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGreen
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerFindList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCustomerFindList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCustomerFindList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fullname, Me.specialization, Me.tmpfname, Me.tmpmname, Me.tmplname, Me.tmpprimaryContact, Me.tmpsecondaryContact})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerFindList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCustomerFindList.Location = New System.Drawing.Point(9, 168)
        Me.dgvCustomerFindList.Name = "dgvCustomerFindList"
        Me.dgvCustomerFindList.ReadOnly = True
        Me.dgvCustomerFindList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvCustomerFindList.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold)
        Me.dgvCustomerFindList.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCustomerFindList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCustomerFindList.Size = New System.Drawing.Size(829, 371)
        Me.dgvCustomerFindList.TabIndex = 34
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
        'specialization
        '
        Me.specialization.HeaderText = "Specialization"
        Me.specialization.Name = "specialization"
        Me.specialization.ReadOnly = True
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
        'tmpprimaryContact
        '
        Me.tmpprimaryContact.HeaderText = "Contact 1"
        Me.tmpprimaryContact.Name = "tmpprimaryContact"
        Me.tmpprimaryContact.ReadOnly = True
        Me.tmpprimaryContact.Visible = False
        '
        'tmpsecondaryContact
        '
        Me.tmpsecondaryContact.HeaderText = "Contact 2"
        Me.tmpsecondaryContact.Name = "tmpsecondaryContact"
        Me.tmpsecondaryContact.ReadOnly = True
        Me.tmpsecondaryContact.Visible = False
        '
        'gbNameSearch
        '
        Me.gbNameSearch.Controls.Add(Me.txtKeyword)
        Me.gbNameSearch.Controls.Add(Me.Button1)
        Me.gbNameSearch.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNameSearch.ForeColor = System.Drawing.Color.Black
        Me.gbNameSearch.Location = New System.Drawing.Point(9, 83)
        Me.gbNameSearch.Name = "gbNameSearch"
        Me.gbNameSearch.Size = New System.Drawing.Size(829, 79)
        Me.gbNameSearch.TabIndex = 33
        Me.gbNameSearch.TabStop = False
        Me.gbNameSearch.Text = "Enter doctor's name"
        '
        'txtKeyword
        '
        Me.txtKeyword.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyword.Location = New System.Drawing.Point(6, 30)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(634, 38)
        Me.txtKeyword.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Location = New System.Drawing.Point(649, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 45)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "FIND"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblCantFindAlert
        '
        Me.lblCantFindAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCantFindAlert.BackColor = System.Drawing.Color.Transparent
        Me.lblCantFindAlert.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantFindAlert.ForeColor = System.Drawing.Color.Maroon
        Me.lblCantFindAlert.Location = New System.Drawing.Point(5, 556)
        Me.lblCantFindAlert.Name = "lblCantFindAlert"
        Me.lblCantFindAlert.Size = New System.Drawing.Size(608, 66)
        Me.lblCantFindAlert.TabIndex = 35
        Me.lblCantFindAlert.Text = "DOUBLE CLICK THE ITEM TO SELECT THE DOCTOR"
        Me.lblCantFindAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMoreInfo
        '
        Me.pnlMoreInfo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlMoreInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMoreInfo.Controls.Add(Me.lblSecondaryContact)
        Me.pnlMoreInfo.Controls.Add(Me.Label8)
        Me.pnlMoreInfo.Controls.Add(Me.lblPrimaryContact)
        Me.pnlMoreInfo.Controls.Add(Me.Label3)
        Me.pnlMoreInfo.Controls.Add(Me.lbSpecialization)
        Me.pnlMoreInfo.Controls.Add(Me.Label5)
        Me.pnlMoreInfo.Controls.Add(Me.btnHideMoreInfo)
        Me.pnlMoreInfo.Controls.Add(Me.btnConfirmSelection)
        Me.pnlMoreInfo.Controls.Add(Me.lblname)
        Me.pnlMoreInfo.Controls.Add(Me.Label6)
        Me.pnlMoreInfo.Controls.Add(Me.lbmname)
        Me.pnlMoreInfo.Controls.Add(Me.Label4)
        Me.pnlMoreInfo.Controls.Add(Me.lbfname)
        Me.pnlMoreInfo.Controls.Add(Me.lbnote)
        Me.pnlMoreInfo.Controls.Add(Me.Panel3)
        Me.pnlMoreInfo.Location = New System.Drawing.Point(4, 5)
        Me.pnlMoreInfo.Name = "pnlMoreInfo"
        Me.pnlMoreInfo.Size = New System.Drawing.Size(838, 617)
        Me.pnlMoreInfo.TabIndex = 37
        Me.pnlMoreInfo.Visible = False
        '
        'lblSecondaryContact
        '
        Me.lblSecondaryContact.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSecondaryContact.BackColor = System.Drawing.Color.Transparent
        Me.lblSecondaryContact.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondaryContact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblSecondaryContact.Location = New System.Drawing.Point(317, 410)
        Me.lblSecondaryContact.Name = "lblSecondaryContact"
        Me.lblSecondaryContact.Size = New System.Drawing.Size(484, 40)
        Me.lblSecondaryContact.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(23, 410)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(288, 40)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "CONTACT NO 2:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrimaryContact
        '
        Me.lblPrimaryContact.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPrimaryContact.BackColor = System.Drawing.Color.Transparent
        Me.lblPrimaryContact.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrimaryContact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblPrimaryContact.Location = New System.Drawing.Point(317, 360)
        Me.lblPrimaryContact.Name = "lblPrimaryContact"
        Me.lblPrimaryContact.Size = New System.Drawing.Size(484, 40)
        Me.lblPrimaryContact.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(23, 360)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(288, 40)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "CONTACT NO 1:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSpecialization
        '
        Me.lbSpecialization.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbSpecialization.BackColor = System.Drawing.Color.Transparent
        Me.lbSpecialization.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSpecialization.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbSpecialization.Location = New System.Drawing.Point(317, 288)
        Me.lbSpecialization.Name = "lbSpecialization"
        Me.lbSpecialization.Size = New System.Drawing.Size(484, 40)
        Me.lbSpecialization.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(23, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 40)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "SPECIALIZATION:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnHideMoreInfo
        '
        Me.btnHideMoreInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnHideMoreInfo.BackColor = System.Drawing.Color.Maroon
        Me.btnHideMoreInfo.FlatAppearance.BorderSize = 0
        Me.btnHideMoreInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHideMoreInfo.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHideMoreInfo.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnHideMoreInfo.Location = New System.Drawing.Point(78, 532)
        Me.btnHideMoreInfo.Name = "btnHideMoreInfo"
        Me.btnHideMoreInfo.Size = New System.Drawing.Size(331, 65)
        Me.btnHideMoreInfo.TabIndex = 44
        Me.btnHideMoreInfo.Text = "CANCEL"
        Me.btnHideMoreInfo.UseVisualStyleBackColor = False
        '
        'btnConfirmSelection
        '
        Me.btnConfirmSelection.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmSelection.BackColor = System.Drawing.Color.Green
        Me.btnConfirmSelection.FlatAppearance.BorderSize = 0
        Me.btnConfirmSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmSelection.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmSelection.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btnConfirmSelection.Location = New System.Drawing.Point(428, 532)
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
        Me.lblname.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblname.Location = New System.Drawing.Point(317, 220)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(484, 40)
        Me.lblname.TabIndex = 41
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(23, 220)
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
        Me.lbmname.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbmname.Location = New System.Drawing.Point(317, 167)
        Me.lbmname.Name = "lbmname"
        Me.lbmname.Size = New System.Drawing.Size(484, 40)
        Me.lbmname.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(23, 167)
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
        Me.lbfname.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbfname.Location = New System.Drawing.Point(317, 115)
        Me.lbfname.Name = "lbfname"
        Me.lbfname.Size = New System.Drawing.Size(484, 40)
        Me.lbfname.TabIndex = 37
        '
        'lbnote
        '
        Me.lbnote.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbnote.BackColor = System.Drawing.Color.Transparent
        Me.lbnote.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lbnote.Location = New System.Drawing.Point(23, 115)
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
        Me.Panel3.Size = New System.Drawing.Size(836, 75)
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
        Me.Label1.Size = New System.Drawing.Size(836, 75)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "VERIFY DOCTOR INFORMATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmFindPhysician
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(846, 629)
        Me.Controls.Add(Me.pnlMoreInfo)
        Me.Controls.Add(Me.lblCantFindAlert)
        Me.Controls.Add(Me.dgvCustomerFindList)
        Me.Controls.Add(Me.gbNameSearch)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindPhysician"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCustomerFindList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNameSearch.ResumeLayout(False)
        Me.gbNameSearch.PerformLayout()
        Me.pnlMoreInfo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTittle As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents dgvCustomerFindList As DataGridView
    Friend WithEvents gbNameSearch As GroupBox
    Friend WithEvents txtKeyword As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lblCantFindAlert As Label
    Friend WithEvents pnlMoreInfo As Panel
    Friend WithEvents btnHideMoreInfo As Button
    Friend WithEvents btnConfirmSelection As Button
    Friend WithEvents lblname As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbmname As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbfname As Label
    Friend WithEvents lbnote As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSecondaryContact As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPrimaryContact As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbSpecialization As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fullname As DataGridViewTextBoxColumn
    Friend WithEvents specialization As DataGridViewTextBoxColumn
    Friend WithEvents tmpfname As DataGridViewTextBoxColumn
    Friend WithEvents tmpmname As DataGridViewTextBoxColumn
    Friend WithEvents tmplname As DataGridViewTextBoxColumn
    Friend WithEvents tmpprimaryContact As DataGridViewTextBoxColumn
    Friend WithEvents tmpsecondaryContact As DataGridViewTextBoxColumn
End Class
