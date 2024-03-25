Imports System.ComponentModel
Imports System.Web
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Aztec

Public Class frmScanQRCode
    Private _fetchedPatientRecord As PatientHealthCheckData = Nothing
    Private timeOfTimer As Double = 0
    Private WebCamDevices As FilterInfoCollection
    Private WebCam As New VideoCaptureDevice
    Private capturedImage As Bitmap = Nothing

    Public Property FetchedRecord As PatientHealthCheckData
        Get
            Return _fetchedPatientRecord
        End Get
        Private Set(value As PatientHealthCheckData)
            _fetchedPatientRecord = value
        End Set
    End Property

    Private Sub WebCamCapture(sender As Object, e As NewFrameEventArgs)
        capturedImage = DirectCast(e.Frame.Clone(), Image)
        pbWebCamImg.Image = DirectCast(e.Frame.Clone(), Image)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Trim.Count >= 32 Then
            If TextBox1.Text.Trim.Contains("westmetro.com.ph") Then
                Dim someAddress As String = TextBox1.Text.Trim
                Dim myUri = New Uri(someAddress)
                Dim params = HttpUtility.ParseQueryString(myUri.Query).Get("tid")
                If Not IsNothing(params) Then
                    Dim patientHCController As New PatientHealthCheckController
                    Dim patientHealthCheck As PatientHealthCheckData = patientHCController.GetPatientHealthCheckData(params.Trim)
                    If Not IsNothing(patientHealthCheck) Then
                        FetchedRecord = patientHealthCheck
                        Me.DialogResult = DialogResult.Yes
                    Else
                        lblScanErr.Text = "Please use a valid Q.R Code"
                        TextBox1.Text = ""
                    End If
                Else
                    lblScanErr.Text = "Please use a valid Q.R Code"
                    TextBox1.Text = ""
                End If
            Else
                Dim patientHCController As New PatientHealthCheckController
                Dim patientHealthCheck As PatientHealthCheckData = patientHCController.GetPatientHealthCheckData(TextBox1.Text.Trim)
                If Not IsNothing(patientHealthCheck) Then
                    FetchedRecord = patientHealthCheck
                    Me.DialogResult = DialogResult.Yes
                Else
                    lblScanErr.Text = "Please use a valid Q.R Code"
                    TextBox1.Text = ""
                End If
            End If
        ElseIf TextBox1.Text.Trim.Count > 0 Then
            lblScanErr.Text = "Please use a valid Q.R Code"
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub frmScanQRCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        capturedImage = Nothing
        cbInputDevice.Items.Add("Q.R SCANNER DEVICE (DEFAULT)")
        WebCamDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each device As FilterInfo In WebCamDevices
            cbInputDevice.Items.Add(device.Name)
        Next
        Try
            cbInputDevice.SelectedIndex = QRInputDevice
        Catch ex As Exception
            QRInputDevice = 0
            cbInputDevice.SelectedIndex = 0
        End Try
        TextBox1.Text = ""
        TextBox1.Focus()
        lblScanErr.Text = "Waiting for the Q.R Code to be scanned"
    End Sub

    Private Sub lbnote_Click(sender As Object, e As EventArgs) Handles lbnote.Click

    End Sub

    Private Sub lblScanErr_Click(sender As Object, e As EventArgs) Handles lblScanErr.Click

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmScanQRCode_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        WebCam.Stop()
        captureTimer.Stop()
    End Sub

    Private Sub cbInputDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInputDevice.SelectedIndexChanged
        If Not (cbInputDevice.SelectedIndex = 0) Then
            WebCam.Stop()
            WebCam = New VideoCaptureDevice(WebCamDevices(cbInputDevice.SelectedIndex - 1).MonikerString)
            AddHandler WebCam.NewFrame, New NewFrameEventHandler(AddressOf WebCamCapture)
            pbDefaultImg.Hide()
            pbWebCamImg.Show()
            WebCam.Start()
            captureTimer.Start()
        Else
            pbWebCamImg.Hide()
            pbDefaultImg.Show()
            WebCam.Stop()
            captureTimer.Stop()
        End If
    End Sub

    Private Sub btnSaveInputDevice_Click(sender As Object, e As EventArgs) Handles btnSaveInputDevice.Click
        QRInputDevice = cbInputDevice.SelectedIndex
        pnlInputDeviceSelector.Hide()
        If cbInputDevice.SelectedIndex = 0 Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub captureTimer_Tick(sender As Object, e As EventArgs) Handles captureTimer.Tick
        timeOfTimer += 1
        If timeOfTimer >= 30 Then
            Me.Close()
        Else
            Dim reader As New BarcodeReader
            If Not IsNothing(capturedImage) Then
                Dim result As Result = reader.Decode(capturedImage)
                Try
                    Dim decodedQR As String = result.ToString().Trim()
                    If decodedQR.Count > 0 Then
                        TextBox1.Text = decodedQR
                    End If
                Catch ex As Exception
                    TextBox1.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub frmScanQRCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            pnlInputDeviceSelector.Show()
        End If
    End Sub

    Private Sub pnlInputDeviceSelector_Paint(sender As Object, e As PaintEventArgs) Handles pnlInputDeviceSelector.Paint

    End Sub
End Class