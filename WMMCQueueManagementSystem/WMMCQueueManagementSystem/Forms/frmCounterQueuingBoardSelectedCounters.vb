Imports System.IO
Imports AxWMPLib

Public Class frmCounterQueuingBoardSelectedCounters
    Private Counters As List(Of Counter)
    Private includesPCCClinics As Boolean = False
    Private includesMABClinics As Boolean = False
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0, id7 As Long = 0, id8 As Long = 0, id9 As Long = 0, id10 As Long = 0
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
            includesPCCClinics = frm.PCCSelected
            includesMABClinics = frm.MABSelected
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

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Private Sub SetCounters()
        Dim tmpStr As String = "Viewable Counters: "
        For Each counter As Counter In Counters
            tmpStr = tmpStr & "(" & counter.Section & ")    "
        Next
        lblCounters.Text = tmpStr
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [F12: browse audio/video]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub frmCounterQueuingBoardSelectedCounters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(Me.Counters) Then
            txtclock.Text = TimeOfDay.ToShortTimeString
            SetCounters()
            Panel8.Controls.Add(AxWindowsMediaPlayer1)
            AxWindowsMediaPlayer1.Dock = DockStyle.Fill
            AxWindowsMediaPlayer1.uiMode = "NONE"
            showHelp()
            playVideo()
            refreshDataIntertval.Start()
            CLOCK.Start()
        Else
            Me.Dispose()
        End If
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

    Private Sub lblCounter5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
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
                End If
            Else
                lbserving10.ForeColor = Color.DimGray
                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0
                GoTo SKIP
            End If
        End If
SKIP:
    End Sub

    Private Sub frmCounterQueuingBoardSelectedCounters_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmCounterQueuingBoardSelectedCounters_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class