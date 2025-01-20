Imports System.IO
Imports FlSigCaptLib
Imports FLSIGCTLLib

Public Class frmSignaturePad
    Dim pointX As Single = 0
    Dim pointY As Single = 0
    Dim lastX As Single = 0
    Dim lastY As Single = 0
    Private _PatientName As String = ""
    Private _PatientPurpose As String = ""
    Private _signatureImg As Image = Nothing
    Private _signatureBmp As Bitmap = Nothing

    Public Property SignatureImg As Image
        Get
            Return _signatureImg
        End Get
        Private Set(value As Image)
            _signatureImg = value
        End Set
    End Property

    Public Property SignatureBmp As Bitmap
        Get
            Return _signatureBmp
        End Get
        Private Set(value As Bitmap)
            _signatureBmp = value
        End Set
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        roundCorners(Me)
    End Sub

    Sub New(PatientName As String, PatientPurpose As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        roundCorners(Me)
        _PatientName = PatientName
        _PatientPurpose = PatientPurpose
    End Sub

    Private Sub roundCorners(obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None
        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()
        'top left corner
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)
        'top right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)
        'buttom right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
        'buttom left corner
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        DGP.CloseFigure()
        obj.Region = New Region(DGP)
    End Sub

    Private Function CaptureSignature()
        Dim sigCtl As New SigCtl
        Dim dc As New DynamicCapture
        Dim res As DynamicCaptureResult
        Dim renderOK As Boolean
        sigCtl.Licence = SignatureLicense
        res = dc.Capture(sigCtl, If(_PatientName.Trim.Length > 0, _PatientName.ToUpper.Trim, "PATIENT NAME"), If(_PatientPurpose.Trim.Length > 0, _PatientPurpose.ToUpper.Trim, "PATIENT SIGNATURE"), vbNull, vbNull)
        If (res = DynamicCaptureResult.DynCaptOK) Then
            Dim sigObj As SigObj
            sigObj = sigCtl.Signature
            Dim filename As New String("Signature.png")
            renderOK = False
            Try
                sigObj.RenderBitmap(filename, 200, 200, "image/png", 2, 0, &HFFFFFF, 0, 0,
                                       RBFlags.RenderOutputFilename Or RBFlags.RenderColor32BPP Or RBFlags.RenderEncodeData)
                renderOK = True
            Catch RenderError As System.ArgumentException
                MessageBox.Show("Something went wrong during the process. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If (renderOK = True) Then
                Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
                sigImage.Image = System.Drawing.Image.FromStream(fs)
                fs.Close()
                fs.Dispose()
                Return True
            End If
        Else
            MessageBox.Show("Signature capture error res=" & res)
            Select Case res
                Case DynamicCaptureResult.DynCaptCancel
                    MessageBox.Show("signature cancelled")
                Case DynamicCaptureResult.DynCaptError
                    MessageBox.Show("No available signature pad. Please connect the signature pad and try again", "No Device", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case DynamicCaptureResult.DynCaptPadError
                    MessageBox.Show("Device was not configured correctly. Please call the IT Department for support", "Re-Configure Device", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Else
                    MessageBox.Show("Something went wrong during the process. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        End If
        Return False
    End Function

    Private Sub frmSignaturePad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbInputDevice.Items.Add("MOUSE SIGNATURE PAD")
        cbInputDevice.Items.Add("WACOM SIGNATURE PAD")
        Try
            cbInputDevice.SelectedIndex = SignatureDevice
        Catch ex As Exception
            QRInputDevice = 0
            cbInputDevice.SelectedIndex = 0
        End Try
    End Sub

    Private Sub pnlSignature_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlSignature.MouseDown
        lastX = e.X
        lastY = e.Y
    End Sub

    Private Sub pnlSignature_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlSignature.MouseMove
        If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
            pointX = e.X
            pointY = e.Y
            pnlSignature_Paint(Me, Nothing)
        End If
    End Sub

    Private Sub btnClearSignature_Click(sender As Object, e As EventArgs) Handles btnClearSignature.Click
        pnlSignature.Controls.Clear()
        pnlSignature.Refresh()
    End Sub

    Private Sub pnlSignature_Paint(sender As Object, e As PaintEventArgs) Handles pnlSignature.Paint
        Dim g As Graphics = pnlSignature.CreateGraphics()
        Dim pen As New Pen(Color.Black)
        pen.Width = 5
        g.DrawLine(pen, pointX, pointY, lastX, lastY)
        lastX = pointX
        lastY = pointY
    End Sub
    Private Sub btnSaveSignature_Click(sender As Object, e As EventArgs) Handles btnSaveSignature.Click
        Dim tmpImg As New Bitmap(pnlSignature.Width, pnlSignature.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(pnlSignature.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(pnlSignature.Width, pnlSignature.Height))
        End Using
        SignatureImg = tmpImg
        SignatureBmp = tmpImg
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim tmpImg As New Bitmap(pnlSignature.Width, pnlSignature.Height)
        tmpImg = sigImage.Image
        SignatureImg = tmpImg
        SignatureBmp = tmpImg
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub frmSignaturePad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            pnlInputDeviceSelector.Show()
        End If
    End Sub

    Private Sub btnSaveInputDevice_Click(sender As Object, e As EventArgs) Handles btnSaveInputDevice.Click
        SignatureDevice = cbInputDevice.SelectedIndex
        pnlInputDeviceSelector.Hide()
    End Sub

    Private Sub cbInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInputDevice.SelectedIndexChanged
        If cbInputDevice.SelectedIndex = 0 Then
            pnlWacomSignaturePad.Hide()
            pnlMouseSignaturePad.Show()
        ElseIf cbInputDevice.SelectedIndex = 1 Then
            pnlMouseSignaturePad.Hide()
            pnlWacomSignaturePad.Show()
            Me.btnStartSignatureWacom_Click(sender, e)
        End If
    End Sub

    Private Sub btnStartSignatureWacom_Click(sender As Object, e As EventArgs) Handles btnStartSignatureWacom.Click
        If CaptureSignature() Then
            Dim tmpImg As New Bitmap(pnlSignature.Width, pnlSignature.Height)
            tmpImg = sigImage.Image
            SignatureImg = tmpImg
            SignatureBmp = tmpImg
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class