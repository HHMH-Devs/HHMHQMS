Imports AxWMPLib

Public Class frmCounterQueuingBoardADs
    Private Counter As Counter
    Private VideosAds As List(Of String)
    Private AxWindowsMediaPlayer1 As New AxWindowsMediaPlayer

    Dim filename As String
    Dim retVal As Integer
    Dim File As String
    Dim PPState As String = "Pause"
    Dim TmrNum As Integer = 1000

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
                vidpath.Add(System.IO.Path.Combine(Application.StartupPath, "wmmc.mp4"))
                vidpath.Add(System.IO.Path.Combine(Application.StartupPath, "wmmc2.mp4"))
                System.IO.File.WriteAllBytes(vidpath(0), My.Resources.wmmc)
                System.IO.File.WriteAllBytes(vidpath(1), My.Resources.wmmc2)
                AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(0)))
                AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(1)))
            End If
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            AxWindowsMediaPlayer1.settings.setMode("loop", True)
        Catch ex As Exception
            MessageBox.Show("Default video file can't be found. Browse some video by pressing [Ctrl + F12] to play some video", "Default video not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lblCounterName.Text = marqueeText(lblCounterName.Text)
    End Sub

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                counterlbl1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), tmpServingCustomerOfServers(0).serverTransaction.CounterName, "")
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = ""
                servingLbl5.Text = ""
                GoTo SKIP
            End If
        End If
SKIP:
    End Sub

    Private Sub frmCounterQueuingBoardADs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtclock.Text = TimeOfDay.ToShortTimeString
        lblCounterName.Text = Counter.Section.ToUpper + "   "
        showHelp()
        Panel5.Controls.Add(AxWindowsMediaPlayer1)
        AxWindowsMediaPlayer1.Dock = DockStyle.Fill
        AxWindowsMediaPlayer1.uiMode = "NONE"
        playVideo()
        refreshDataIntertval.Start()
        CLOCK.Start()
    End Sub

    Private Sub frmCounterQueuingBoardADs_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub counterlbl1_Click(sender As Object, e As EventArgs) Handles counterlbl1.Click

    End Sub

    Private Sub lblCounterName_Click(sender As Object, e As EventArgs) Handles lblCounterName.Click

    End Sub

    Private Sub servingLbl1_Click(sender As Object, e As EventArgs) Handles servingLbl1.Click

    End Sub

    Private Sub servingLbl2_Click(sender As Object, e As EventArgs) Handles servingLbl2.Click

    End Sub

    Private Sub servingLbl3_Click(sender As Object, e As EventArgs) Handles servingLbl3.Click

    End Sub

    Private Sub servingLbl4_Click(sender As Object, e As EventArgs) Handles servingLbl4.Click

    End Sub

    Private Sub frmCounterQueuingBoardADs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class