Imports System.IO
Imports System.Speech.Synthesis
Imports AxWMPLib

Public Class frmCounterQueuingBoardADsStandalone
    Private Counter As Counter
    Private callString As String = ""
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = ""
    Private AxWindowsMediaPlayer1 As New AxWindowsMediaPlayer

    Public Sub SetPagingConfig()
        Dim voiceModel As VoiceModel = VoiceSetting
        If voiceModel.VoiceGenderMale Then
            queuingSpeaker.SelectVoiceByHints(VoiceGender.Male)
        Else
            queuingSpeaker.SelectVoiceByHints(VoiceGender.Female)
        End If
        queuingSpeaker.Volume = If(voiceModel.VoiceVolume > 100 Or voiceModel.VoiceVolume < 0, 50, voiceModel.VoiceVolume)
        queuingSpeaker.Rate = voiceModel.VoiceSpeed
    End Sub

    Private Sub CallNumber(str As String)
        Try
            queuingSpeaker.SpeakAsyncCancelAll()
            My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
            queuingSpeaker.SpeakAsync(str)
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckIfServingChange(tmpServingCustomerOfServers As GetServingCustomerOfServer)
        If id1 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter1.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If
        If id2 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter2.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If
        If id3 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter3.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If

        If id4 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter4.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If
        If id5 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter5.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If
        If id6 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter6.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
            End If
        End If
    End Sub

    Private Sub counterlbl6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                counterlbl1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), tmpServingCustomerOfServers(0).serverTransaction.CounterName, "")
                id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(0))
                End If
            Else
                servingLbl1.ForeColor = Color.DimGray
                counterlbl1.Text = ""
                servingLbl1.Text = ""

                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = ""
                servingLbl2.Text = ""

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = ""
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = ""
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 1 Then
                counterlbl2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), tmpServingCustomerOfServers(1).serverTransaction.CounterName, "")
                id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(1))
                End If
            Else
                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = ""
                servingLbl2.Text = ""

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = ""
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = ""
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 2 Then
                counterlbl3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), tmpServingCustomerOfServers(2).serverTransaction.CounterName, "")
                id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(2))
                End If
            Else
                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = ""
                servingLbl3.Text = ""

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = ""
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 3 Then
                counterlbl4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), tmpServingCustomerOfServers(3).serverTransaction.CounterName, "")
                id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(3))
                End If
            Else
                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = ""
                servingLbl4.Text = ""

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 4 Then
                counterlbl5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), tmpServingCustomerOfServers(4).serverTransaction.CounterName, "")
                id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(4))
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If

        End If
SKIP:
        counter1 = If(tmpServingCustomerOfServers.Count > 0, If(Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter), tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter2 = If(tmpServingCustomerOfServers.Count > 1, If(Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter), tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter3 = If(tmpServingCustomerOfServers.Count > 2, If(Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter), tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter4 = If(tmpServingCustomerOfServers.Count > 3, If(Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter), tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter5 = If(tmpServingCustomerOfServers.Count > 4, If(Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter), tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber, ""), "")
        If callString.Count > 0 Then
            CallNumber("Now Serving, Numbers, " & callString & " please proceed to your designated counters.")
            callString = ""
        End If
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
    End Sub

    Sub New(counter As Counter)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Counter = counter
    End Sub

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Sub browseVideo()
        Dim dialog As New OpenFileDialog
        dialog.Multiselect = True
        dialog.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV"
        Try
            If dialog.ShowDialog = DialogResult.OK Then
                AxWindowsMediaPlayer1.settings.setMode("loop", True)
                AxWindowsMediaPlayer1.currentPlaylist.clear()
                For Each files As String In dialog.FileNames
                    AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(files))
                    AxWindowsMediaPlayer1.Ctlcontrols.play()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("File selected cannot be played", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [F12: browse audio/video]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub playVideo()
        Try
            Dim vidpath As New List(Of String)
            AxWindowsMediaPlayer1.currentPlaylist.clear()
            Dim adController As New adscontroller
            Dim viewableAds As List(Of ViewableAds) = adController.GetViewableADS
            If Not IsNothing(viewableAds) Then
                For Each ad As ViewableAds In viewableAds
                    AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(ad.Ads.ADSLocation))
                Next
            Else
                vidpath.Add(Path.Combine(Application.StartupPath, "wmmc.mp4"))
                vidpath.Add(Path.Combine(Application.StartupPath, "wmmc2.mp4"))
                File.WriteAllBytes(vidpath(0), My.Resources.wmmc)
                File.WriteAllBytes(vidpath(1), My.Resources.wmmc2)
                AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(0)))
                AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(1)))
            End If
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            AxWindowsMediaPlayer1.settings.setMode("loop", True)
        Catch ex As Exception
            MessageBox.Show("Default video file can't be found. Browse some video by pressing [Ctrl + F12] to play some video", "Default video not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub frmCounterQueuingBoardADsStandalone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPagingConfig()
        txtclock.Text = TimeOfDay.ToShortTimeString
        lblCounterName.Text = Counter.Section.ToUpper + "   "
        Panel5.Controls.Add(AxWindowsMediaPlayer1)
        AxWindowsMediaPlayer1.Dock = DockStyle.Fill
        AxWindowsMediaPlayer1.uiMode = "NONE"
        showHelp()
        playVideo()
        refreshDataIntertval.Start()
        CLOCK.Start()
    End Sub

    Private Sub frmCounterQueuingBoardADsStandalone_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Maximized
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            browseVideo()
        ElseIf e.KeyCode = Keys.F1 Then
            showHelp()
        End If
    End Sub

    Private Sub frmCounterQueuingBoardADsStandalone_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class