<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPDFResultViewer
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
        Me.pdfViewer = New Spire.PdfViewer.Forms.PdfDocumentViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbcountername = New System.Windows.Forms.Label()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pdfViewer
        '
        Me.pdfViewer.BackColor = System.Drawing.Color.White
        Me.pdfViewer.Location = New System.Drawing.Point(0, 42)
        Me.pdfViewer.MultiPagesThreshold = 60
        Me.pdfViewer.Name = "pdfViewer"
        Me.pdfViewer.Size = New System.Drawing.Size(957, 593)
        Me.pdfViewer.TabIndex = 0
        Me.pdfViewer.Text = "PdfDocumentViewer1"
        Me.pdfViewer.Threshold = 60
        Me.pdfViewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.[Default]
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.lbcountername)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(957, 42)
        Me.Panel1.TabIndex = 10
        '
        'lbcountername
        '
        Me.lbcountername.BackColor = System.Drawing.Color.PaleGreen
        Me.lbcountername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lbcountername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbcountername.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcountername.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbcountername.Location = New System.Drawing.Point(0, 0)
        Me.lbcountername.Name = "lbcountername"
        Me.lbcountername.Size = New System.Drawing.Size(957, 42)
        Me.lbcountername.TabIndex = 0
        Me.lbcountername.Text = "VIEW RESULT"
        Me.lbcountername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPage
        '
        Me.lblPage.BackColor = System.Drawing.Color.Transparent
        Me.lblPage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblPage.Location = New System.Drawing.Point(45, 647)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(268, 41)
        Me.lblPage.TabIndex = 59
        Me.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button1.BackColor = System.Drawing.Color.LimeGreen
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(358, 647)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 41)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "NEXT PAGE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmPDFResultViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(957, 697)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.pdfViewer)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPDFResultViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pdfViewer As Spire.PdfViewer.Forms.PdfDocumentViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbcountername As Label
    Friend WithEvents lblPage As Label
    Friend WithEvents Button1 As Button
End Class
