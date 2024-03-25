Imports System.Speech.Synthesis
Public Class frmCounterQueuingBoard_ClinicPCC
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private callString As String = "", highlightNumber As String = ""
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0, id7 As Long = 0, id8 As Long = 0, id9 As Long = 0, id10 As Long = 0, id11 As Long = 0, id12 As Long = 0, id13 As Long = 0, id14 As Long = 0, id15 As Long = 0, id16 As Long = 0, id17 As Long = 0, id18 As Long = 0, id19 As Long = 0, id20 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = "", counter7 As String = "", counter8 As String = "", counter9 As String = "", counter10 As String = "", counter11 As String = "", counter12 As String = "", counter13 As String = "", counter14 As String = "", counter15 As String = "", counter16 As String = "", counter17 As String = "", counter18 As String = "", counter19 As String = "", counter20 As String = ""

    Private QueueListTimer As Timer = Nothing

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If lblHighlightServing.BackColor = Color.LimeGreen Then
            lblHighlightServing.BackColor = Color.Aqua
        ElseIf lblHighlightServing.BackColor = Color.Aqua Then
            lblHighlightServing.BackColor = Color.LimeGreen
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pnlHighlightServing.Hide()
        Timer1.Stop()
        Timer2.Stop()
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
            pnlHighlightServing.Show()
            Timer1.Start()
            Timer2.Start()
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCounterQueuingBoard_ClinicPCC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPagingConfig()
        If IsNothing(QueueListTimer) Then
            QueueListTimer = New Timer()
            QueueListTimer.Interval = 10000
            QueueListTimer.Start()
        Else
            QueueListTimer = Nothing
            QueueListTimer = New Timer()
            QueueListTimer.Interval = 10000
            QueueListTimer.Start()
        End If

        AddHandler QueueListTimer.Tick, AddressOf QueueListTimer_Tick
    End Sub

    Private Sub frmCounterQueuingBoard_ClinicPCC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
                Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Else
                Me.WindowState = FormWindowState.Maximized
                Me.FormBorderStyle = FormBorderStyle.None
            End If
        End If
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
        End If
    End Sub

    Private Sub QueueListTimer_Tick(sender As Object, e As EventArgs)
        Dim servedCustomerController As New ServedCustomerController
        Dim tmpServingCustomerOfServers As List(Of GetServingCustomerOfServer) = servedCustomerController.GetPCCClinicAndPaymentServingQueue()
        If Not IsNothing(tmpServingCustomerOfServers) Then
            If tmpServingCustomerOfServers.Count > 0 Then
                lblCounter1.Text = If(Not IsNothing(tmpServingCustomerOfServers(0).serverTransaction), tmpServingCustomerOfServers(0).serverTransaction.CounterName, "")
                If Not id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID Then
                    lbserving1.Text = tmpServingCustomerOfServers(0).TemporaryQueueNumber
                End If
                id1 = tmpServingCustomerOfServers(0).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(0).customerAssigncounter.Priority = 2 Then
                        lbserving1.Text = tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(0).customerAssigncounter.Priority = 1 Then
                            lbserving1.ForeColor = Color.IndianRed
                        Else
                            lbserving1.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(0))
                    End If
                End If
            Else
                lblCounter1.Text = ""
                lbserving1.Text = ""
                id1 = 0

                lblCounter2.Text = ""
                lbserving2.Text = ""
                id2 = 0


                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0


                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0


                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0


                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 1 Then
                lblCounter2.Text = If(Not IsNothing(tmpServingCustomerOfServers(1).serverTransaction), tmpServingCustomerOfServers(1).serverTransaction.CounterName, "")
                If Not id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID Then
                    lbserving2.Text = tmpServingCustomerOfServers(1).TemporaryQueueNumber
                End If
                id2 = tmpServingCustomerOfServers(1).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(1).customerAssigncounter.Priority = 2 Then
                        lbserving2.Text = tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(1).customerAssigncounter.Priority > 0 Then
                            lbserving2.ForeColor = Color.IndianRed
                        Else
                            lbserving2.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(1))
                    End If
                End If
            Else
                lblCounter2.Text = ""
                lbserving2.Text = ""
                id2 = 0


                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0


                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0


                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0


                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 2 Then
                lblCounter3.Text = If(Not IsNothing(tmpServingCustomerOfServers(2).serverTransaction), tmpServingCustomerOfServers(2).serverTransaction.CounterName, "")
                If Not id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID Then
                    lbserving3.Text = tmpServingCustomerOfServers(2).TemporaryQueueNumber
                End If
                id3 = tmpServingCustomerOfServers(2).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(2).customerAssigncounter.Priority = 2 Then
                        lbserving3.Text = tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(2).customerAssigncounter.Priority > 0 Then
                            lbserving3.ForeColor = Color.IndianRed
                        Else
                            lbserving3.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(2))
                    End If
                End If
            Else

                lblCounter3.Text = ""
                lbserving3.Text = ""
                id3 = 0


                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0


                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0


                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 3 Then
                lblCounter4.Text = If(Not IsNothing(tmpServingCustomerOfServers(3).serverTransaction), tmpServingCustomerOfServers(3).serverTransaction.CounterName, "")
                If Not id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID Then
                    lbserving4.Text = tmpServingCustomerOfServers(3).TemporaryQueueNumber
                End If
                id4 = tmpServingCustomerOfServers(3).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(3).customerAssigncounter.Priority = 2 Then
                        lbserving4.Text = tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(3).customerAssigncounter.Priority > 0 Then
                            lbserving4.ForeColor = Color.IndianRed
                        Else
                            lbserving4.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(3))
                    End If
                End If
            Else

                lblCounter4.Text = ""
                lbserving4.Text = ""
                id4 = 0


                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0


                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 4 Then
                lblCounter5.Text = If(Not IsNothing(tmpServingCustomerOfServers(4).serverTransaction), tmpServingCustomerOfServers(4).serverTransaction.CounterName, "")
                If Not id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID Then
                    lbserving5.Text = tmpServingCustomerOfServers(4).TemporaryQueueNumber
                End If
                id5 = tmpServingCustomerOfServers(4).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(4).customerAssigncounter.Priority = 2 Then
                        lbserving5.Text = tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(4).customerAssigncounter.Priority > 0 Then
                            lbserving5.ForeColor = Color.IndianRed
                        Else
                            lbserving5.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(4))
                    End If
                End If
            Else

                lblCounter5.Text = ""
                lbserving5.Text = ""
                id5 = 0


                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 5 Then
                lblCounter6.Text = If(Not IsNothing(tmpServingCustomerOfServers(5).serverTransaction), tmpServingCustomerOfServers(5).serverTransaction.CounterName, "")
                If Not id6 = tmpServingCustomerOfServers(5).serverTransaction.ServerTransaction_ID Then
                    lbserving6.Text = tmpServingCustomerOfServers(5).TemporaryQueueNumber
                End If
                id6 = tmpServingCustomerOfServers(5).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(5).customerAssigncounter.Priority = 2 Then
                        lbserving6.Text = tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(5).customerAssigncounter.Priority > 0 Then
                            lbserving6.ForeColor = Color.IndianRed
                        Else
                            lbserving6.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(5))
                    End If
                End If
            Else

                lblCounter6.Text = ""
                lbserving6.Text = ""
                id6 = 0


                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 6 Then
                lblCounter7.Text = If(Not IsNothing(tmpServingCustomerOfServers(6).serverTransaction), tmpServingCustomerOfServers(6).serverTransaction.CounterName, "")
                If Not id7 = tmpServingCustomerOfServers(6).serverTransaction.ServerTransaction_ID Then
                    lbserving7.Text = tmpServingCustomerOfServers(6).TemporaryQueueNumber
                End If
                id7 = tmpServingCustomerOfServers(6).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(6).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(6).customerAssigncounter.Priority = 2 Then
                        lbserving7.Text = tmpServingCustomerOfServers(6).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(6).customerAssigncounter.Priority > 0 Then
                            lbserving7.ForeColor = Color.IndianRed
                        Else
                            lbserving7.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(6))
                    End If
                End If
            Else

                lblCounter7.Text = ""
                lbserving7.Text = ""
                id7 = 0


                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 7 Then
                lblCounter8.Text = If(Not IsNothing(tmpServingCustomerOfServers(7).serverTransaction), tmpServingCustomerOfServers(7).serverTransaction.CounterName, "")
                If Not id8 = tmpServingCustomerOfServers(7).serverTransaction.ServerTransaction_ID Then
                    lbserving8.Text = tmpServingCustomerOfServers(7).TemporaryQueueNumber
                End If
                id8 = tmpServingCustomerOfServers(7).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(7).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(7).customerAssigncounter.Priority = 2 Then
                        lbserving8.Text = tmpServingCustomerOfServers(7).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(7).customerAssigncounter.Priority > 0 Then
                            lbserving8.ForeColor = Color.IndianRed
                        Else
                            lbserving8.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(7))
                    End If
                End If
            Else

                lblCounter8.Text = ""
                lbserving8.Text = ""
                id8 = 0


                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 8 Then
                lblCounter9.Text = If(Not IsNothing(tmpServingCustomerOfServers(8).serverTransaction), tmpServingCustomerOfServers(8).serverTransaction.CounterName, "")
                If Not id9 = tmpServingCustomerOfServers(8).serverTransaction.ServerTransaction_ID Then
                    lbserving9.Text = tmpServingCustomerOfServers(8).TemporaryQueueNumber
                End If
                id9 = tmpServingCustomerOfServers(8).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(8).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(8).customerAssigncounter.Priority = 2 Then
                        lbserving9.Text = tmpServingCustomerOfServers(8).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(8).customerAssigncounter.Priority > 0 Then
                            lbserving9.ForeColor = Color.IndianRed
                        Else
                            lbserving9.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(8))
                    End If
                End If
            Else

                lblCounter9.Text = ""
                lbserving9.Text = ""
                id9 = 0


                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 9 Then
                lblCounter10.Text = If(Not IsNothing(tmpServingCustomerOfServers(9).serverTransaction), tmpServingCustomerOfServers(9).serverTransaction.CounterName, "")
                If Not id10 = tmpServingCustomerOfServers(9).serverTransaction.ServerTransaction_ID Then
                    lbserving10.Text = tmpServingCustomerOfServers(9).TemporaryQueueNumber
                End If
                id10 = tmpServingCustomerOfServers(9).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(9).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(9).customerAssigncounter.Priority = 2 Then
                        lbserving10.Text = tmpServingCustomerOfServers(9).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(9).customerAssigncounter.Priority > 0 Then
                            lbserving10.ForeColor = Color.IndianRed
                        Else
                            lbserving10.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(9))
                    End If
                End If
            Else

                lblCounter10.Text = ""
                lbserving10.Text = ""
                id10 = 0


                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0


                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 10 Then
                lblCounter11.Text = If(Not IsNothing(tmpServingCustomerOfServers(10).serverTransaction), tmpServingCustomerOfServers(10).serverTransaction.CounterName, "")
                If Not id11 = tmpServingCustomerOfServers(10).serverTransaction.ServerTransaction_ID Then
                    lbserving11.Text = tmpServingCustomerOfServers(10).TemporaryQueueNumber
                End If
                id11 = tmpServingCustomerOfServers(10).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(10).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(10).customerAssigncounter.Priority = 2 Then
                        lbserving11.Text = tmpServingCustomerOfServers(10).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(10).customerAssigncounter.Priority > 0 Then
                            lbserving11.ForeColor = Color.IndianRed
                        Else
                            lbserving11.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(10))
                    End If
                End If
            Else

                lblCounter11.Text = ""
                lbserving11.Text = ""
                id11 = 0

                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
            If tmpServingCustomerOfServers.Count > 11 Then
                lblCounter12.Text = If(Not IsNothing(tmpServingCustomerOfServers(11).serverTransaction), tmpServingCustomerOfServers(11).serverTransaction.CounterName, "")
                If Not id12 = tmpServingCustomerOfServers(11).serverTransaction.ServerTransaction_ID Then
                    lbserving12.Text = tmpServingCustomerOfServers(11).TemporaryQueueNumber
                End If
                id12 = tmpServingCustomerOfServers(11).serverTransaction.ServerTransaction_ID
                If Not IsNothing(tmpServingCustomerOfServers(11).customerAssigncounter) Then
                    If Not tmpServingCustomerOfServers(11).customerAssigncounter.Priority = 2 Then
                        lbserving12.Text = tmpServingCustomerOfServers(11).customerAssigncounter.ProcessedQueueNumber
                        If tmpServingCustomerOfServers(11).customerAssigncounter.Priority > 0 Then
                            lbserving12.ForeColor = Color.IndianRed
                        Else
                            lbserving12.ForeColor = Color.LimeGreen
                        End If
                        CheckIfServingChange(tmpServingCustomerOfServers(11))
                    End If
                End If
            Else
                lblCounter12.Text = ""
                lbserving12.Text = ""
                id12 = 0
                GoTo SKIP
            End If
        End If
SKIP:
        counter1 = If(tmpServingCustomerOfServers.Count > 0, If(Not IsNothing(tmpServingCustomerOfServers(0).customerAssigncounter), tmpServingCustomerOfServers(0).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter2 = If(tmpServingCustomerOfServers.Count > 1, If(Not IsNothing(tmpServingCustomerOfServers(1).customerAssigncounter), tmpServingCustomerOfServers(1).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter3 = If(tmpServingCustomerOfServers.Count > 2, If(Not IsNothing(tmpServingCustomerOfServers(2).customerAssigncounter), tmpServingCustomerOfServers(2).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter4 = If(tmpServingCustomerOfServers.Count > 3, If(Not IsNothing(tmpServingCustomerOfServers(3).customerAssigncounter), tmpServingCustomerOfServers(3).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter5 = If(tmpServingCustomerOfServers.Count > 4, If(Not IsNothing(tmpServingCustomerOfServers(4).customerAssigncounter), tmpServingCustomerOfServers(4).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter6 = If(tmpServingCustomerOfServers.Count > 5, If(Not IsNothing(tmpServingCustomerOfServers(5).customerAssigncounter), tmpServingCustomerOfServers(5).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter7 = If(tmpServingCustomerOfServers.Count > 6, If(Not IsNothing(tmpServingCustomerOfServers(6).customerAssigncounter), tmpServingCustomerOfServers(6).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter8 = If(tmpServingCustomerOfServers.Count > 7, If(Not IsNothing(tmpServingCustomerOfServers(7).customerAssigncounter), tmpServingCustomerOfServers(7).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter9 = If(tmpServingCustomerOfServers.Count > 8, If(Not IsNothing(tmpServingCustomerOfServers(8).customerAssigncounter), tmpServingCustomerOfServers(8).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter10 = If(tmpServingCustomerOfServers.Count > 9, If(Not IsNothing(tmpServingCustomerOfServers(9).customerAssigncounter), tmpServingCustomerOfServers(9).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter11 = If(tmpServingCustomerOfServers.Count > 10, If(Not IsNothing(tmpServingCustomerOfServers(10).customerAssigncounter), tmpServingCustomerOfServers(10).customerAssigncounter.ProcessedQueueNumber, ""), "")
        counter12 = If(tmpServingCustomerOfServers.Count > 11, If(Not IsNothing(tmpServingCustomerOfServers(11).customerAssigncounter), tmpServingCustomerOfServers(11).customerAssigncounter.ProcessedQueueNumber, ""), "")
        If callString.Count > 0 Then
            CallNumber("Now Serving, Numbers, " & callString & " please proceed to your designated counters.")
            callString = ""
        End If
    End Sub

    Private Sub frmCounterQueuingBoard_ClinicPCC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        QueueListTimer.Stop()
    End Sub
End Class