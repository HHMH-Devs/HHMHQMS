Imports System.ComponentModel
Imports AForge.Video
Imports AForge.Video.DirectShow

Public Class frmCaptureImage
    Private WebCamDevices As FilterInfoCollection
    Private WebCam As New VideoCaptureDevice

    Public Property CapturedImage As Bitmap = Nothing

    Private Sub WebCamCapture(sender As Object, e As NewFrameEventArgs)
        CapturedImage = DirectCast(e.Frame.Clone(), Image)
        PictureBox1.Image = DirectCast(e.Frame.Clone(), Image)
    End Sub

    Private Sub frmCaptureImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CapturedImage = Nothing
        WebCamDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each device As FilterInfo In WebCamDevices
            cbInputDevice.Items.Add(device.Name)
        Next
        Try
            cbInputDevice.SelectedIndex = WebCamDevice
        Catch ex As Exception
            QRInputDevice = -1
            cbInputDevice.SelectedIndex = -1
        End Try
    End Sub

    Private Sub cbInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInputDevice.SelectedIndexChanged
        If cbInputDevice.SelectedIndex > -1 Then
            WebCam.Stop()
            WebCam = New VideoCaptureDevice(WebCamDevices(cbInputDevice.SelectedIndex).MonikerString)
            AddHandler WebCam.NewFrame, New NewFrameEventHandler(AddressOf WebCamCapture)
            PictureBox1.Show()
            WebCam.Start()
        End If
    End Sub

    Private Sub frmCaptureImage_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            pnlInputDeviceSelector.Show()
        End If
    End Sub

    Private Sub btnSaveInputDevice_Click(sender As Object, e As EventArgs) Handles btnSaveInputDevice.Click
        WebCamDevice = cbInputDevice.SelectedIndex
        pnlInputDeviceSelector.Hide()
    End Sub

    Private Sub frmCaptureImage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        WebCam.Stop()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CapturedImage = PictureBox1.Image
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class