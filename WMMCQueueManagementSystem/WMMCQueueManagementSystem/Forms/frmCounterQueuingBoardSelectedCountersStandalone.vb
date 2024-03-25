Imports System.IO
Imports System.Speech.Synthesis
Imports AxWMPLib

Public Class frmCounterQueuingBoardSelectedCountersStandalone
    Private Counters As List(Of Counter)
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private callString As String = "", highlightNumber As String = ""
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0, id7 As Long = 0, id8 As Long = 0, id9 As Long = 0, id10 As Long = 0
    Private id11 As Long = 0, id12 As Long = 0, id13 As Long = 0, id14 As Long = 0, id15 As Long = 0, id16 As Long = 0, id17 As Long = 0, id18 As Long = 0, id19 As Long = 0, id20 As Long = 0
    Private id21 As Long = 0, id22 As Long = 0, id23 As Long = 0, id24 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = "", counter7 As String = "", counter8 As String = "", counter9 As String = "", counter10 As String = ""
    Private counter11 As String = "", counter12 As String = "", counter13 As String = "", counter14 As String = "", counter15 As String = "", counter16 As String = "", counter17 As String = "", counter18 As String = "", counter19 As String = "", counter20 As String = ""
    Private counter21 As String = "", counter22 As String = "", counter23 As String = "", counter24 As String = ""
    Private timer1 As New Timer
    Private timer2 As New Timer

    Private Sub TableLayoutPanel2_SizeChanged(sender As Object, e As EventArgs) Handles TableLayoutPanel2.SizeChanged
        TableLayoutPanel2.Width = Me.Width / 2
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private AxWindowsMediaPlayer1 As New AxWindowsMediaPlayer

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim frm As New frmCounterSelection
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes And Not IsNothing(frm.SelectedCounter) Then
            Dim exist As Boolean = False
            Me.Counters = frm.SelectedCounter
        End If
        timer1.Interval = 5000
        timer2.Interval = 150
        AddHandler timer1.Tick, Sub() timer1_Tick()
        AddHandler timer2.Tick, Sub() timer2_Tick()
    End Sub

    Private Sub timer1_Tick()
        lblHighlightServing.Hide()
        timer1.Stop()
        timer2.Stop()
    End Sub

    Private Sub timer2_Tick()
        Highlight()
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
            lblHighlightServing.Text = highlightNumber.Trim.ToUpper
            lblHighlightServing.Show()
            timer1.Start()
            timer2.Start()
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckIfServingChange(tmpServingCustomerOfServers As GetServingCustomerOfServer)
        If id1 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter1.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id2 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter2.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id3 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter3.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id4 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter4.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id5 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter5.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id6 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter6.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id7 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter7.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id8 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter8.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id9 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter9.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id10 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter10.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id11 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter11.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id12 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter12.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id13 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter13.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id14 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter14.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id15 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter15.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id16 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter16.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id17 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter17.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id18 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter18.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id19 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter19.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id20 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter20.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id21 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter21.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id22 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter22.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        ElseIf id23 = tmpServingCustomerOfServers.serverTransaction.ServerTransaction_ID Then
            If counter23.ToLower <> tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber.ToLower Then
                callString = callString & tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber & ", "
                highlightNumber = tmpServingCustomerOfServers.customerAssigncounter.ProcessedQueueNumber
            End If
        End If
    End Sub

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

    Private Sub SetCounters()
        Dim tmpStr As String = "Viewable Counters: "
        For Each counter As Counter In Counters
            tmpStr = tmpStr & "(" & counter.Section & ")    "
        Next
        lblCounters.Text = tmpStr
    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [F12: browse audio/video]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub playVideo()
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


    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Private Sub Highlight()
        If lblHighlightServing.BackColor = Color.LimeGreen Then
            lblHighlightServing.BackColor = Color.Aqua
            lblHighlightServing.ForeColor = Color.Black
        ElseIf lblHighlightServing.BackColor = Color.Aqua Then
            lblHighlightServing.BackColor = Color.LimeGreen
            lblHighlightServing.ForeColor = Color.White
        End If
    End Sub
    Dim int = 0
    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToString("hh:mm:ss tt")
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lbwelcome.Text = marqueeText(lbwelcome.Text)
        lblCounters.Text = marqueeText(lblCounters.Text)
    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetMultipleDepartmentServingQueue(Me.Counters)
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                lblCounter1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), tmpServingCustomerOfServers(0).serverTransaction.CounterName, "")
                If Not id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID Then
                    lbserving1.Text = ""
                End If
                id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    lbserving1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        lbserving1.ForeColor = Color.IndianRed
                    Else
                        lbserving1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(0))
                End If
            Else
                lbserving1.ForeColor = Color.DimGray
                lblCounter1.Text = ""
                lbserving1.Text = ""
                id1 = 0

                lbserving2.ForeColor = Color.DimGray
                lblCounter2.Text = ""
                lbserving2.Text = ""
                id2 = 0

                lbserving3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0

                lbserving4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0

                lbserving5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0

                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 1 Then
                lblCounter2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), tmpServingCustomerOfServers(1).serverTransaction.CounterName, "")
                If Not id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID Then
                    lbserving2.Text = ""
                End If
                id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    lbserving2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        lbserving2.ForeColor = Color.IndianRed
                    Else
                        lbserving2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(1))
                End If
            Else
                lbserving2.ForeColor = Color.DimGray
                lblCounter2.Text = ""
                lbserving2.Text = ""
                id2 = 0

                lbserving3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0

                lbserving4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0

                lbserving5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0

                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 2 Then
                lblCounter3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), tmpServingCustomerOfServers(2).serverTransaction.CounterName, "")
                If Not id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID Then
                    lbserving3.Text = ""
                End If
                id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    lbserving3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        lbserving3.ForeColor = Color.IndianRed
                    Else
                        lbserving3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(2))
                End If
            Else

                lbserving3.ForeColor = Color.DimGray
                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0

                lbserving4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0

                lbserving5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0

                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 3 Then
                lblCounter4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), tmpServingCustomerOfServers(3).serverTransaction.CounterName, "")
                If Not id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID Then
                    lbserving4.Text = ""
                End If
                id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    lbserving4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        lbserving4.ForeColor = Color.IndianRed
                    Else
                        lbserving4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(3))
                End If
            Else
                lbserving4.ForeColor = Color.DimGray
                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0

                lbserving5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0

                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 4 Then
                lblCounter5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), tmpServingCustomerOfServers(4).serverTransaction.CounterName, "")
                If Not id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID Then
                    lbserving5.Text = ""
                End If
                id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    lbserving5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        lbserving5.ForeColor = Color.IndianRed
                    Else
                        lbserving5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(4))
                End If
            Else
                lbserving5.ForeColor = Color.DimGray
                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0

                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 5 Then
                lblCounter6.Text = If(Not IsNothing(tmpServingCustomerOfServers(5).serverTransaction), tmpServingCustomerOfServers(5).serverTransaction.CounterName, "")
                If Not id6 = tmpServingCustomerOfServers(5).serverTransaction.ServerTransaction_ID Then
                    lbserving6.Text = ""
                End If
                id6 = tmpServingCustomerOfServers(5).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter) Then
                    lbserving6.Text = tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(5).customerAssigncounter.Priority > 0 Then
                        lbserving6.ForeColor = Color.IndianRed
                    Else
                        lbserving6.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(5))
                End If
            Else
                lbserving6.ForeColor = Color.DimGray
                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0

                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 6 Then
                lblCounter7.Text = If(Not IsNothing(tmpServingCustomerOfServers(6).serverTransaction), tmpServingCustomerOfServers(6).serverTransaction.CounterName, "")
                If Not id7 = tmpServingCustomerOfServers(6).serverTransaction.ServerTransaction_ID Then
                    lbserving7.Text = ""
                End If
                id7 = tmpServingCustomerOfServers(6).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(6).customerAssigncounter) Then
                    lbserving7.Text = tmpServingCustomerOfServers(6).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(6).customerAssigncounter.Priority > 0 Then
                        lbserving7.ForeColor = Color.IndianRed
                    Else
                        lbserving7.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(6))
                End If
            Else
                lbserving7.ForeColor = Color.DimGray
                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0

                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 7 Then
                lblCounter8.Text = If(Not IsNothing(tmpServingCustomerOfServers(7).serverTransaction), tmpServingCustomerOfServers(7).serverTransaction.CounterName, "")
                If Not id8 = tmpServingCustomerOfServers(7).serverTransaction.ServerTransaction_ID Then
                    lbserving8.Text = ""
                End If
                id8 = tmpServingCustomerOfServers(7).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(7).customerAssigncounter) Then
                    lbserving8.Text = tmpServingCustomerOfServers(7).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(7).customerAssigncounter.Priority > 0 Then
                        lbserving8.ForeColor = Color.IndianRed
                    Else
                        lbserving8.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(7))
                End If
            Else
                lbserving8.ForeColor = Color.DimGray
                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0

                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 8 Then
                lblCounter9.Text = If(Not IsNothing(tmpServingCustomerOfServers(8).serverTransaction), tmpServingCustomerOfServers(8).serverTransaction.CounterName, "")
                If Not id9 = tmpServingCustomerOfServers(8).serverTransaction.ServerTransaction_ID Then
                    lbserving9.Text = ""
                End If
                id9 = tmpServingCustomerOfServers(8).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(8).customerAssigncounter) Then
                    lbserving9.Text = tmpServingCustomerOfServers(8).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(8).customerAssigncounter.Priority > 0 Then
                        lbserving9.ForeColor = Color.IndianRed
                    Else
                        lbserving9.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(8))
                End If
            Else
                lbserving9.ForeColor = Color.DimGray
                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0

                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0

                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 9 Then
                lblCounter10.Text = If(Not IsNothing(tmpServingCustomerOfServers(9).serverTransaction), tmpServingCustomerOfServers(9).serverTransaction.CounterName, "")
                If Not id10 = tmpServingCustomerOfServers(9).serverTransaction.ServerTransaction_ID Then
                    lbserving10.Text = ""
                End If
                id10 = tmpServingCustomerOfServers(9).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(9).customerAssigncounter) Then
                    lbserving10.Text = tmpServingCustomerOfServers(9).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(9).customerAssigncounter.Priority > 0 Then
                        lbserving10.ForeColor = Color.IndianRed
                    Else
                        lbserving10.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(9))
                End If
            Else
                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving12.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 10 Then
                lblCounter11.Text = If(Not IsNothing(tmpServingCustomerOfServers(10).serverTransaction), tmpServingCustomerOfServers(10).serverTransaction.CounterName, "")
                If Not id11 = tmpServingCustomerOfServers(10).serverTransaction.ServerTransaction_ID Then
                    lbserving11.Text = ""
                End If
                id11 = tmpServingCustomerOfServers(10).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(10).customerAssigncounter) Then
                    lbserving11.Text = tmpServingCustomerOfServers(10).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(10).customerAssigncounter.Priority > 0 Then
                        lbserving11.ForeColor = Color.IndianRed
                    Else
                        lbserving11.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(10))
                End If
            Else

                lbserving11.ForeColor = Color.DimGray
                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0

                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 11 Then
                lblCounter12.Text = If(Not IsNothing(tmpServingCustomerOfServers(11).serverTransaction), tmpServingCustomerOfServers(11).serverTransaction.CounterName, "")
                If Not id12 = tmpServingCustomerOfServers(11).serverTransaction.ServerTransaction_ID Then
                    lbserving12.Text = ""
                End If
                id12 = tmpServingCustomerOfServers(11).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(11).customerAssigncounter) Then
                    lbserving12.Text = tmpServingCustomerOfServers(11).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(11).customerAssigncounter.Priority > 0 Then
                        lbserving12.ForeColor = Color.IndianRed
                    Else
                        lbserving12.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(11))
                End If
            Else
                lbserving12.ForeColor = Color.DimGray
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0

                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 12 Then
                lblCounter13.Text = If(Not IsNothing(tmpServingCustomerOfServers(12).serverTransaction), tmpServingCustomerOfServers(12).serverTransaction.CounterName, "")
                If Not id13 = tmpServingCustomerOfServers(12).serverTransaction.ServerTransaction_ID Then
                    lbserving13.Text = ""
                End If
                id13 = tmpServingCustomerOfServers(12).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(12).customerAssigncounter) Then
                    lbserving13.Text = tmpServingCustomerOfServers(12).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(12).customerAssigncounter.Priority > 0 Then
                        lbserving13.ForeColor = Color.IndianRed
                    Else
                        lbserving13.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(12))
                End If
            Else
                lbserving13.ForeColor = Color.DimGray
                lblCounter13.Text = ""
                lbserving13.Text = ""
                id13 = 0

                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 13 Then
                lblCounter14.Text = If(Not IsNothing(tmpServingCustomerOfServers(13).serverTransaction), tmpServingCustomerOfServers(13).serverTransaction.CounterName, "")
                If Not id14 = tmpServingCustomerOfServers(13).serverTransaction.ServerTransaction_ID Then
                    lbserving14.Text = ""
                End If
                id14 = tmpServingCustomerOfServers(13).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(13).customerAssigncounter) Then
                    lbserving14.Text = tmpServingCustomerOfServers(13).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(13).customerAssigncounter.Priority > 0 Then
                        lbserving14.ForeColor = Color.IndianRed
                    Else
                        lbserving14.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(13))
                End If
            Else
                lbserving14.ForeColor = Color.DimGray
                lblCounter14.Text = ""
                lbserving14.Text = ""
                id14 = 0

                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 14 Then
                lblCounter15.Text = If(Not IsNothing(tmpServingCustomerOfServers(14).serverTransaction), tmpServingCustomerOfServers(14).serverTransaction.CounterName, "")
                If Not id15 = tmpServingCustomerOfServers(14).serverTransaction.ServerTransaction_ID Then
                    lbserving15.Text = ""
                End If
                id15 = tmpServingCustomerOfServers(14).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(14).customerAssigncounter) Then
                    lbserving15.Text = tmpServingCustomerOfServers(14).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(14).customerAssigncounter.Priority > 0 Then
                        lbserving15.ForeColor = Color.IndianRed
                    Else
                        lbserving15.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(14))
                End If
            Else
                lbserving15.ForeColor = Color.DimGray
                lblCounter15.Text = ""
                lbserving15.Text = ""
                id15 = 0

                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 15 Then
                lblCounter16.Text = If(Not IsNothing(tmpServingCustomerOfServers(15).serverTransaction), tmpServingCustomerOfServers(15).serverTransaction.CounterName, "")
                If Not id16 = tmpServingCustomerOfServers(15).serverTransaction.ServerTransaction_ID Then
                    lbserving16.Text = ""
                End If
                id16 = tmpServingCustomerOfServers(15).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(15).customerAssigncounter) Then
                    lbserving16.Text = tmpServingCustomerOfServers(15).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(15).customerAssigncounter.Priority > 0 Then
                        lbserving16.ForeColor = Color.IndianRed
                    Else
                        lbserving16.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(15))
                End If
            Else
                lbserving16.ForeColor = Color.DimGray
                lblCounter16.Text = ""
                lbserving16.Text = ""
                id16 = 0

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 16 Then
                lblCounter17.Text = If(Not IsNothing(tmpServingCustomerOfServers(16).serverTransaction), tmpServingCustomerOfServers(16).serverTransaction.CounterName, "")
                If Not id17 = tmpServingCustomerOfServers(16).serverTransaction.ServerTransaction_ID Then
                    lbserving17.Text = ""
                End If
                id17 = tmpServingCustomerOfServers(16).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(16).customerAssigncounter) Then
                    lbserving17.Text = tmpServingCustomerOfServers(16).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(16).customerAssigncounter.Priority > 0 Then
                        lbserving17.ForeColor = Color.IndianRed
                    Else
                        lbserving17.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(16))
                End If
            Else

                lbserving17.ForeColor = Color.DimGray
                lblCounter17.Text = ""
                lbserving17.Text = ""
                id17 = 0

                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 17 Then
                lblCounter18.Text = If(Not IsNothing(tmpServingCustomerOfServers(17).serverTransaction), tmpServingCustomerOfServers(17).serverTransaction.CounterName, "")
                If Not id18 = tmpServingCustomerOfServers(17).serverTransaction.ServerTransaction_ID Then
                    lbserving18.Text = ""
                End If
                id18 = tmpServingCustomerOfServers(17).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(17).customerAssigncounter) Then
                    lbserving18.Text = tmpServingCustomerOfServers(17).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(17).customerAssigncounter.Priority > 0 Then
                        lbserving18.ForeColor = Color.IndianRed
                    Else
                        lbserving18.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(17))
                End If
            Else
                lbserving18.ForeColor = Color.DimGray
                lblCounter18.Text = ""
                lbserving18.Text = ""
                id18 = 0

                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 18 Then
                lblCounter19.Text = If(Not IsNothing(tmpServingCustomerOfServers(18).serverTransaction), tmpServingCustomerOfServers(18).serverTransaction.CounterName, "")
                If Not id19 = tmpServingCustomerOfServers(18).serverTransaction.ServerTransaction_ID Then
                    lbserving19.Text = ""
                End If
                id19 = tmpServingCustomerOfServers(18).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(18).customerAssigncounter) Then
                    lbserving19.Text = tmpServingCustomerOfServers(18).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(18).customerAssigncounter.Priority > 0 Then
                        lbserving19.ForeColor = Color.IndianRed
                    Else
                        lbserving19.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(18))
                End If
            Else
                lbserving19.ForeColor = Color.DimGray
                lblCounter19.Text = ""
                lbserving19.Text = ""
                id19 = 0

                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 19 Then
                lblCounter20.Text = If(Not IsNothing(tmpServingCustomerOfServers(19).serverTransaction), tmpServingCustomerOfServers(19).serverTransaction.CounterName, "")
                If Not id20 = tmpServingCustomerOfServers(19).serverTransaction.ServerTransaction_ID Then
                    lbserving20.Text = ""
                End If
                id20 = tmpServingCustomerOfServers(19).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(19).customerAssigncounter) Then
                    lbserving20.Text = tmpServingCustomerOfServers(19).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(19).customerAssigncounter.Priority > 0 Then
                        lbserving20.ForeColor = Color.IndianRed
                    Else
                        lbserving20.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(19))
                End If
            Else
                lbserving20.ForeColor = Color.DimGray
                lblCounter20.Text = ""
                lbserving20.Text = ""
                id20 = 0

                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 20 Then
                lblCounter21.Text = If(Not IsNothing(tmpServingCustomerOfServers(20).serverTransaction), tmpServingCustomerOfServers(20).serverTransaction.CounterName, "")
                If Not id21 = tmpServingCustomerOfServers(20).serverTransaction.ServerTransaction_ID Then
                    lbserving21.Text = ""
                End If
                id21 = tmpServingCustomerOfServers(20).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(20).customerAssigncounter) Then
                    lbserving21.Text = tmpServingCustomerOfServers(20).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(20).customerAssigncounter.Priority > 0 Then
                        lbserving21.ForeColor = Color.IndianRed
                    Else
                        lbserving21.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(20))
                End If
            Else
                lbserving21.ForeColor = Color.DimGray
                lblCounter21.Text = ""
                lbserving21.Text = ""
                id21 = 0

                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 21 Then
                lblCounter22.Text = If(Not IsNothing(tmpServingCustomerOfServers(21).serverTransaction), tmpServingCustomerOfServers(21).serverTransaction.CounterName, "")
                If Not id22 = tmpServingCustomerOfServers(21).serverTransaction.ServerTransaction_ID Then
                    lbserving22.Text = ""
                End If
                id22 = tmpServingCustomerOfServers(21).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(21).customerAssigncounter) Then
                    lbserving22.Text = tmpServingCustomerOfServers(21).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(21).customerAssigncounter.Priority > 0 Then
                        lbserving22.ForeColor = Color.IndianRed
                    Else
                        lbserving22.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(21))
                End If
            Else
                lbserving22.ForeColor = Color.DimGray
                lblCounter22.Text = ""
                lbserving22.Text = ""
                id22 = 0

                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 22 Then
                lblCounter23.Text = If(Not IsNothing(tmpServingCustomerOfServers(22).serverTransaction), tmpServingCustomerOfServers(22).serverTransaction.CounterName, "")
                If Not id23 = tmpServingCustomerOfServers(22).serverTransaction.ServerTransaction_ID Then
                    lbserving23.Text = ""
                End If
                id23 = tmpServingCustomerOfServers(22).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(22).customerAssigncounter) Then
                    lbserving23.Text = tmpServingCustomerOfServers(22).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(22).customerAssigncounter.Priority > 0 Then
                        lbserving23.ForeColor = Color.IndianRed
                    Else
                        lbserving23.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(22))
                End If
            Else
                lbserving23.ForeColor = Color.DimGray
                lblCounter23.Text = ""
                lbserving23.Text = ""
                id23 = 0

                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 23 Then
                lblCounter24.Text = If(Not IsNothing(tmpServingCustomerOfServers(23).serverTransaction), tmpServingCustomerOfServers(23).serverTransaction.CounterName, "")
                If Not id24 = tmpServingCustomerOfServers(23).serverTransaction.ServerTransaction_ID Then
                    lbserving24.Text = ""
                End If
                id24 = tmpServingCustomerOfServers(23).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(23).customerAssigncounter) Then
                    lbserving24.Text = tmpServingCustomerOfServers(23).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(23).customerAssigncounter.Priority > 0 Then
                        lbserving24.ForeColor = Color.IndianRed
                    Else
                        lbserving24.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                    CheckIfServingChange(tmpServingCustomerOfServers(23))
                End If
            Else
                lbserving24.ForeColor = Color.DimGray
                lblCounter24.Text = ""
                lbserving24.Text = ""
                id24 = 0
                GoTo SKIP
            End If
        End If
SKIP:
        counter1 = If(lbserving1.Text.ToLower <> "", lbserving1.Text, "")
        counter2 = If(lbserving2.Text.ToLower <> "", lbserving2.Text, "")
        counter3 = If(lbserving3.Text.ToLower <> "", lbserving3.Text, "")
        counter4 = If(lbserving4.Text.ToLower <> "", lbserving4.Text, "")
        counter5 = If(lbserving5.Text.ToLower <> "", lbserving5.Text, "")
        counter6 = If(lbserving6.Text.ToLower <> "", lbserving6.Text, "")
        counter7 = If(lbserving7.Text.ToLower <> "", lbserving7.Text, "")
        counter8 = If(lbserving8.Text.ToLower <> "", lbserving8.Text, "")
        counter9 = If(lbserving9.Text.ToLower <> "", lbserving9.Text, "")
        counter10 = If(lbserving10.Text.ToLower <> "", lbserving10.Text, "")
        counter11 = If(lbserving11.Text.ToLower <> "", lbserving11.Text, "")
        counter12 = If(lbserving12.Text.ToLower <> "", lbserving12.Text, "")
        counter13 = If(lbserving13.Text.ToLower <> "", lbserving13.Text, "")
        counter14 = If(lbserving14.Text.ToLower <> "", lbserving14.Text, "")
        counter15 = If(lbserving15.Text.ToLower <> "", lbserving15.Text, "")
        counter16 = If(lbserving16.Text.ToLower <> "", lbserving16.Text, "")
        counter17 = If(lbserving17.Text.ToLower <> "", lbserving17.Text, "")
        counter18 = If(lbserving18.Text.ToLower <> "", lbserving18.Text, "")
        counter19 = If(lbserving19.Text.ToLower <> "", lbserving19.Text, "")
        counter20 = If(lbserving20.Text.ToLower <> "", lbserving20.Text, "")
        counter21 = If(lbserving21.Text.ToLower <> "", lbserving21.Text, "")
        counter22 = If(lbserving22.Text.ToLower <> "", lbserving22.Text, "")
        counter23 = If(lbserving23.Text.ToLower <> "", lbserving23.Text, "")
        counter24 = If(lbserving24.Text.ToLower <> "", lbserving24.Text, "")


        If callString.Count > 0 Then
            CallNumber("Now Serving, Numbers, " & callString & " please proceed to your designated counters.")
            callString = ""
        End If
    End Sub

    Private Sub frmCounterQueuingBoardSelectedCountersStandalone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(Me.Counters) Then
            TableLayoutPanel2.Width = Me.Width / 2
            SetPagingConfig()
            txtclock.Text = TimeOfDay.ToString("hh:mm:ss tt")
            SetCounters()
            showHelp()
            'Panel8.Controls.Add(AxWindowsMediaPlayer1)
            'AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            'AxWindowsMediaPlayer1.uiMode = "NONE"
            'playVideo()
            refreshDataIntertval.Start()
            CLOCK.Start()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub frmCounterQueuingBoardSelectedCountersStandalone_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmCounterQueuingBoardSelectedCountersStandalone_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class