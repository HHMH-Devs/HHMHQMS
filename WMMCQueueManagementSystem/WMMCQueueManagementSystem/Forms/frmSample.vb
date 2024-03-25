Imports BarcodeLib.BarcodeReader
Imports FLSIGCTLLib
Imports FlSigCaptLib
Imports System.IO
Public Class frmSample
    Dim draw As Boolean
    Dim drawColor As Color = Color.Black
    Dim drawSize As Integer = 3
    Dim bmp As Bitmap


    Dim pointX As Single = 0
    Dim pointY As Single = 0

    Dim lastX As Single = 0
    Dim lastY As Single = 0

    Private Sub frmSample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fd As New OpenFileDialog
        fd.Filter = "IMG|*.jpg;*.jpeg;*.png"
        If fd.ShowDialog() = DialogResult.OK Then
            Dim datas() As String = BarcodeReader.read(fd.FileName, BarcodeReader.QRCODE)
        End If
    End Sub

    Private Sub PaintBrush(x As Integer, y As Integer)
        Using g As Graphics = Graphics.FromImage(PictureBox1.Image)
            g.FillRectangle(New SolidBrush(drawColor), New Rectangle(x, y, drawSize, drawSize))
        End Using
        PictureBox1.Refresh()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        draw = True
        PaintBrush(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If draw Then
            PaintBrush(e.X, e.Y)
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        draw = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = Panel1.CreateGraphics()
        g.DrawLine(Pens.Black, pointX, pointY, lastX, lastY)
        lastX = pointX
        lastY = pointY
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        lastX = e.X
        lastY = e.Y
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
            pointX = e.X
            pointY = e.Y
            Panel1_Paint(Me, Nothing)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Controls.Clear()
        Panel1.Refresh()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim patientHCController As New PatientHealthCheckController
        Dim patientHealthCheck As PatientHealthCheckData = patientHCController.GetPatientHealthCheckData(TextBox1.Text.Trim)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Print("btnSign clicked")

        Dim sigCtl As New SigCtl
        Dim dc As New DynamicCapture
        Dim res As DynamicCaptureResult
        Dim renderOK As Boolean
        sigCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA"

        res = dc.Capture(sigCtl, "who", "why", vbNull, vbNull)
        If (res = DynamicCaptureResult.DynCaptOK) Then
            Print("signature captured successfully")
            Dim sigObj As SigObj
            sigObj = sigCtl.Signature
            sigObj.ExtraData("AdditionalData") = "VB test: Additional data"
            Dim filename As New String("sig1.png")
            renderOK = False
            Try
                sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5F, &HFF0000, &HFFFFFF, 10.0F, 10.0F,
                                       RBFlags.RenderOutputFilename Or RBFlags.RenderColor32BPP Or RBFlags.RenderEncodeData)
                renderOK = True
            Catch RenderError As System.ArgumentException
                Print("Argument error when rendering bitmap")
            End Try
            If (renderOK = True) Then
                Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
                sigImage.Image = System.Drawing.Image.FromStream(fs)
                fs.Close()
                fs.Dispose()
            End If
        Else
            Print("Signature capture error res=" & res)
            Select Case res
                Case DynamicCaptureResult.DynCaptCancel
                    Print("signature cancelled")
                Case DynamicCaptureResult.DynCaptError
                    Print("no capture service available")
                Case DynamicCaptureResult.DynCaptPadError
                    Print("signing device error")
                Case Else
                    Print("Unexpected error code ")
            End Select
        End If
    End Sub

    Private Sub print(ByVal txt)
        MessageBox.Show(txt)
    End Sub
End Class