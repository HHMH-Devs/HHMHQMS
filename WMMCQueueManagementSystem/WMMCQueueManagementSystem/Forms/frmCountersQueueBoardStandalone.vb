Imports System.IO
Imports AxWMPLib
Imports System.Speech.Synthesis
Public Class frmCountersQueueBoardStandalone
    Private Counter As Counter
    Private callString As String = ""
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = ""

    Sub New(counter As Counter)
        InitializeComponent()
        Me.Counter = counter
    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [F12: browse audio/video]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
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

    Sub playVideo()
        Try
            Dim vidpath As New List(Of String)
            vidpath.Add(Path.Combine(Application.StartupPath, "wmmc.mp4"))
            vidpath.Add(Path.Combine(Application.StartupPath, "wmmc2.mp4"))

            File.WriteAllBytes(vidpath(0), My.Resources.wmmc)
            File.WriteAllBytes(vidpath(1), My.Resources.wmmc2)

            AxWindowsMediaPlayer1.currentPlaylist.clear()
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(0)))
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(1)))

            AxWindowsMediaPlayer1.Ctlcontrols.play()
            AxWindowsMediaPlayer1.settings.setMode("loop", True)
        Catch ex As Exception
            MessageBox.Show("Default video file can't be found. Browse some video by pressing [Ctrl + F12] to play some video", "Default video not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub frmCounterQueueBoardStandalone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtclock.Text = TimeOfDay.ToShortTimeString
        lblCounterName.Text = Counter.Section.ToUpper + "   "
        showHelp()
        SetPagingConfig()
        refreshDataIntertval.Start()
        CLOCK.Start()
        playVideo()
    End Sub

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


    Private Sub frmCounterQueueBoardStandalone_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lbwelcome.Text = marqueeText(lbwelcome.Text)
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub
    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                counterlbl1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), If(tmpServingCustomerOfServers(0).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(0).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(0).serverTransaction.CounterName, tmpServingCustomerOfServers(0).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(0).serverTransaction.CounterName), "NONE")
                id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(0))
                Else
                    servingLbl1.ForeColor = Color.DimGray
                    servingLbl1.Text = "NONE"
                End If
            Else
                servingLbl1.ForeColor = Color.DimGray
                counterlbl1.Text = "NONE"
                servingLbl1.Text = "NONE"

                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = "NONE"
                servingLbl2.Text = "NONE"

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 1 Then
                counterlbl2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), If(tmpServingCustomerOfServers(1).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(1).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(1).serverTransaction.CounterName, tmpServingCustomerOfServers(1).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(1).serverTransaction.CounterName), "NONE")
                id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(1))
                Else
                    servingLbl2.ForeColor = Color.DimGray
                    servingLbl2.Text = "NONE"
                End If
            Else
                servingLbl2.ForeColor = Color.DimGray
                counterlbl2.Text = "NONE"
                servingLbl2.Text = "NONE"

                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 2 Then
                counterlbl3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), If(tmpServingCustomerOfServers(2).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(2).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(2).serverTransaction.CounterName, tmpServingCustomerOfServers(2).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(2).serverTransaction.CounterName), "NONE")
                id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(2))
                Else
                    servingLbl3.ForeColor = Color.DimGray
                    servingLbl3.Text = "NONE"
                End If
            Else
                servingLbl3.ForeColor = Color.DimGray
                counterlbl3.Text = "NONE"
                servingLbl3.Text = "NONE"

                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 3 Then
                counterlbl4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), If(tmpServingCustomerOfServers(3).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(3).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(3).serverTransaction.CounterName, tmpServingCustomerOfServers(3).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(3).serverTransaction.CounterName), "NONE")
                id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(3))
                Else
                    servingLbl4.ForeColor = Color.DimGray
                    servingLbl4.Text = "NONE"
                End If
            Else
                servingLbl4.ForeColor = Color.DimGray
                counterlbl4.Text = "NONE"
                servingLbl4.Text = "NONE"

                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 4 Then
                counterlbl5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), If(tmpServingCustomerOfServers(4).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(4).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(4).serverTransaction.CounterName, tmpServingCustomerOfServers(4).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(4).serverTransaction.CounterName), "NONE")
                id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(4))
                Else
                    servingLbl5.ForeColor = Color.DimGray
                    servingLbl5.Text = "NONE"
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"

                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 5 Then
                counterlbl6.Text = If(Not IsNothing(tmpServingCustomerOfServers(5).serverTransaction), If(tmpServingCustomerOfServers(5).serverTransaction.CounterName.Count > 12, Mid(tmpServingCustomerOfServers(5).serverTransaction.CounterName, 1, 10).ToString + " " + Mid(tmpServingCustomerOfServers(5).serverTransaction.CounterName, tmpServingCustomerOfServers(5).serverTransaction.CounterName.Count).ToString, tmpServingCustomerOfServers(5).serverTransaction.CounterName), "NONE")
                id6 = tmpServingCustomerOfServers(5).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter) Then
                    servingLbl6.Text = tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(5).customerAssigncounter.Priority > 0 Then
                        servingLbl6.ForeColor = Color.IndianRed
                    Else
                        servingLbl6.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(5))
                Else
                    servingLbl6.ForeColor = Color.DimGray
                    servingLbl6.Text = "NONE"
                End If
            Else
                servingLbl6.ForeColor = Color.DimGray
                counterlbl6.Text = "NONE"
                servingLbl6.Text = "NONE"
            End If
        End If
SKIP:
        counter1 = If(servingLbl1.Text.ToLower <> "none", servingLbl1.Text, "")
        counter2 = If(servingLbl2.Text.ToLower <> "none", servingLbl2.Text, "")
        counter3 = If(servingLbl3.Text.ToLower <> "none", servingLbl3.Text, "")
        counter4 = If(servingLbl4.Text.ToLower <> "none", servingLbl4.Text, "")
        counter5 = If(servingLbl5.Text.ToLower <> "none", servingLbl5.Text, "")
        counter6 = If(servingLbl6.Text.ToLower <> "none", servingLbl6.Text, "")

        If callString.Count > 0 Then
            CallNumber("Now Serving, Numbers, " & callString & " please proceed to your designated counters.")
            callString = ""
        End If
    End Sub
End Class