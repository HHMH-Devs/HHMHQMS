Imports System.IO
Imports AxWMPLib

Public Class frmCounterQueueBoard
    Private Counter As Counter
    Private servingCustomerOfServers As List(Of GetServingCustomerOfServer) = Nothing


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
            File.WriteAllBytes(vidpath(3), My.Resources.wmmc2)

            AxWindowsMediaPlayer1.currentPlaylist.clear()
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(0)))
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(AxWindowsMediaPlayer1.newMedia(vidpath(1)))

            AxWindowsMediaPlayer1.Ctlcontrols.play()
            AxWindowsMediaPlayer1.settings.setMode("loop", True)
        Catch ex As Exception
            MessageBox.Show("Default video file can't be found. Browse some video by pressing [Ctrl + F12] to play some video", "Default video not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [F12: browse audio/video]", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub New(counter As Counter)
        InitializeComponent()
        Me.Counter = counter
    End Sub

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Private Function CheckIfSameQueue(item1 As List(Of GetServingCustomerOfServer), item2 As List(Of GetServingCustomerOfServer)) As Boolean
        Return True
    End Function

    Private Function LoadThisQueuingView()
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)

        If Not IsNothing(tmpServingCustomerOfServers) Then
            servingCustomerOfServers = tmpServingCustomerOfServers
            flpCounterList.Controls.Clear()
            flpServingList.Controls.Clear()
            Dim ctr As Integer = servingCustomerOfServers.Count

            For Each servingCustomerOfServer As GetServingCustomerOfServer In servingCustomerOfServers
                Dim pn1 As New Panel
                Dim pn2 As New Panel
                Dim imgBx As New PictureBox
                Dim lbl1 As New Label
                Dim lbl2 As New Label

                If Not IsNothing(servingCustomerOfServer.customerAssigncounter) Then
                    pn1.Size = New Size(681, 133)
                    pn1.BackColor = Color.White
                    pn1.BorderStyle = BorderStyle.FixedSingle
                    imgBx.Image = If(servingCustomerOfServer.customerAssigncounter.Priority > 0, imgicons.Images.Item(1), imgicons.Images.Item(0))
                    imgBx.Dock = DockStyle.Fill
                    imgBx.SizeMode = PictureBoxSizeMode.StretchImage
                    imgBx.BorderStyle = BorderStyle.FixedSingle
                    lbl1.AutoSize = False
                    lbl1.Dock = DockStyle.Right
                    lbl1.Text = servingCustomerOfServer.customerAssigncounter.ProcessedQueueNumber
                    lbl1.Size = New Size(535, 133)
                    lbl1.TextAlign = ContentAlignment.MiddleCenter
                    lbl1.ForeColor = If(servingCustomerOfServer.customerAssigncounter.Priority > 0, Color.IndianRed, Color.FromArgb(13, 52, 145))
                    lbl1.Font = New Font("Century Gothic", 60, FontStyle.Bold)
                    pn1.Controls.Add(imgBx)
                    pn1.Controls.Add(lbl1)

                    pn2.Size = New Size(681, 133)
                    pn2.BackColor = Color.White
                    pn2.BorderStyle = BorderStyle.FixedSingle
                    lbl2.AutoSize = False
                    lbl2.Dock = DockStyle.Fill
                    lbl2.Text = servingCustomerOfServer.serverTransaction.CounterName
                    lbl2.TextAlign = ContentAlignment.MiddleCenter
                    lbl2.ForeColor = Color.Navy
                    lbl2.Font = New Font("Century Gothic", 50, FontStyle.Bold)

                    pn2.Controls.Add(lbl2)
                Else
                    pn1.Size = New Size(681, 133)
                    pn1.BackColor = Color.White
                    pn1.BorderStyle = BorderStyle.FixedSingle
                    imgBx.Image = Nothing
                    imgBx.Dock = DockStyle.Fill
                    imgBx.SizeMode = PictureBoxSizeMode.StretchImage
                    imgBx.BorderStyle = BorderStyle.FixedSingle
                    lbl1.AutoSize = False
                    lbl1.Dock = DockStyle.Right
                    lbl1.Text = "NONE"
                    lbl1.Size = New Size(535, 133)
                    lbl1.TextAlign = ContentAlignment.MiddleCenter
                    lbl1.ForeColor = Color.DimGray
                    lbl1.Font = New Font("Century Gothic", 60, FontStyle.Bold)
                    pn1.Controls.Add(imgBx)
                    pn1.Controls.Add(lbl1)

                    pn2.Size = New Size(681, 133)
                    pn2.BackColor = Color.White
                    pn2.BorderStyle = BorderStyle.FixedSingle
                    lbl2.AutoSize = False
                    lbl2.Dock = DockStyle.Fill
                    lbl2.Text = servingCustomerOfServer.serverTransaction.CounterName
                    lbl2.TextAlign = ContentAlignment.MiddleCenter
                    lbl2.ForeColor = Color.Navy
                    lbl2.Font = New Font("Century Gothic", 50, FontStyle.Bold)

                    pn2.Controls.Add(lbl2)
                End If
                flpCounterList.Controls.Add(pn1)
                flpServingList.Controls.Add(pn2)
            Next
        End If
        Return True
    End Function

    Private Sub frmCounterQueueBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showHelp()
        lblCounterName.Text = Me.Counter.Section
        refreshDataIntertval.Start()

        timerwelcome.Start()
        AxWindowsMediaPlayer1.uiMode = "full"

        playVideo()
    End Sub

    Private Sub frmCounterQueueBoard_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub refreshDataIntertval_Tick(sender As Object, e As EventArgs) Handles refreshDataIntertval.Tick
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetCertainDepartmentServingQueue(Counter)

        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                counterlbl1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), tmpServingCustomerOfServers(0).serverTransaction.CounterName, "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    servingLbl1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(0).customerAssigncounter.Priority > 0 Then
                        servingLbl1.ForeColor = Color.IndianRed
                    Else
                        servingLbl1.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 1 Then
                counterlbl2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), tmpServingCustomerOfServers(1).serverTransaction.CounterName, "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    servingLbl2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                        servingLbl2.ForeColor = Color.IndianRed
                    Else
                        servingLbl2.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 2 Then
                counterlbl3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), tmpServingCustomerOfServers(2).serverTransaction.CounterName, "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    servingLbl3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                        servingLbl3.ForeColor = Color.IndianRed
                    Else
                        servingLbl3.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
                GoTo SKIP
            End If

            If tmpServingCustomerOfServers.Count > 3 Then
                counterlbl4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), tmpServingCustomerOfServers(3).serverTransaction.CounterName, "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    servingLbl4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                        servingLbl4.ForeColor = Color.IndianRed
                    Else
                        servingLbl4.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
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
            End If

            If tmpServingCustomerOfServers.Count > 4 Then
                counterlbl5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), tmpServingCustomerOfServers(5).serverTransaction.CounterName, "NONE")
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    servingLbl5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                    If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                        servingLbl5.ForeColor = Color.IndianRed
                    Else
                        servingLbl5.ForeColor = Color.FromArgb(13, 52, 145)
                    End If
                Else
                    servingLbl5.ForeColor = Color.DimGray
                    servingLbl5.Text = "NONE"
                End If
            Else
                servingLbl5.ForeColor = Color.DimGray
                counterlbl5.Text = "NONE"
                servingLbl5.Text = "NONE"
            End If
        End If
SKIP:
    End Sub

    Private Sub timerwelcome_Tick(sender As Object, e As EventArgs) Handles timerwelcome.Tick
        lbwelcome.Text = marqueeText(lbwelcome.Text)
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class