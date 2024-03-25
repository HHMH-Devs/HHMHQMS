Imports System.Speech.Synthesis
Public Class frmCountersQueueBoardRoomStandalone
    Private Counter As Counter
    Private callString As String = ""
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()
    Private id1 As Long = 0, id2 As Long = 0, id3 As Long = 0, id4 As Long = 0, id5 As Long = 0, id6 As Long = 0
    Private counter1 As String = "", counter2 As String = "", counter3 As String = "", counter4 As String = "", counter5 As String = "", counter6 As String = ""

    Sub showHelp()
        MessageBox.Show("Note: [F1: Show Help] [F11: toogle fullscreen] [All informations viewed on the Billing Status are managable using the third party application called 'Billing Status Management System'].", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub New(counter As Counter)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Counter = counter

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

    Private Sub counterlbl1_Click(sender As Object, e As EventArgs) Handles counterlbl1.Click

    End Sub

    Private Function marqueeText(ByVal data As String)
        Dim s1 As String = data.Remove(0, 1)
        Dim s2 As String = data(0)
        Return s1 & s2
    End Function

    Private Sub CLOCK_Tick(sender As Object, e As EventArgs) Handles CLOCK.Tick
        txtclock.Text = TimeOfDay.ToShortTimeString
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

    Private Sub CallNumber(str As String)
        Try
            queuingSpeaker.SpeakAsyncCancelAll()
            My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
            queuingSpeaker.SpeakAsync(str)
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mghList_Tick(sender As Object, e As EventArgs) Handles mghList.Tick
        Dim admissioncontroller As New administratoraccountcontroller
        Dim mghList As List(Of mghroomstatus) = admissioncontroller.GetMghRooms
        If Not IsNothing(mghList) Then
            If mghList.Count > 0 Then
                lblRoom1.Text = mghList(0).Bed_No
                lblStatus1.Text = mghList(0).Status
            Else
                lblRoom1.Text = ""
                lblStatus1.Text = ""

                lblRoom2.Text = ""
                lblStatus2.Text = ""

                lblRoom3.Text = ""
                lblStatus3.Text = ""

                lblRoom4.Text = ""
                lblStatus4.Text = ""

                lblRoom5.Text = ""
                lblStatus5.Text = ""

                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 1 Then
                lblRoom2.Text = mghList(1).Bed_No
                lblStatus2.Text = mghList(1).Status
            Else
                lblRoom2.Text = ""
                lblStatus2.Text = ""

                lblRoom3.Text = ""
                lblStatus3.Text = ""

                lblRoom4.Text = ""
                lblStatus4.Text = ""

                lblRoom5.Text = ""
                lblStatus5.Text = ""

                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 2 Then
                lblRoom3.Text = mghList(2).Bed_No
                lblStatus3.Text = mghList(2).Status
            Else
                lblRoom3.Text = ""
                lblStatus3.Text = ""

                lblRoom4.Text = ""
                lblStatus4.Text = ""

                lblRoom5.Text = ""
                lblStatus5.Text = ""

                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 3 Then
                lblRoom4.Text = mghList(3).Bed_No
                lblStatus4.Text = mghList(3).Status
            Else
                lblRoom4.Text = ""
                lblStatus4.Text = ""

                lblRoom5.Text = ""
                lblStatus5.Text = ""

                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 4 Then
                lblRoom5.Text = mghList(4).Bed_No
                lblStatus5.Text = mghList(4).Status
            Else
                lblRoom5.Text = ""
                lblStatus5.Text = ""

                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 5 Then
                lblRoom6.Text = mghList(5).Bed_No
                lblStatus6.Text = mghList(5).Status
            Else
                lblRoom6.Text = ""
                lblStatus6.Text = ""

                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 6 Then
                lblRoom7.Text = mghList(6).Bed_No
                lblStatus7.Text = mghList(6).Status
            Else
                lblRoom7.Text = ""
                lblStatus7.Text = ""

                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 7 Then
                lblRoom8.Text = mghList(7).Bed_No
                lblStatus8.Text = mghList(7).Status
            Else
                lblRoom8.Text = ""
                lblStatus8.Text = ""

                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 8 Then
                lblRoom9.Text = mghList(8).Bed_No
                lblStatus9.Text = mghList(8).Status
            Else
                lblRoom9.Text = ""
                lblStatus9.Text = ""

                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 9 Then
                lblRoom10.Text = mghList(9).Bed_No
                lblStatus10.Text = mghList(9).Status
            Else
                lblRoom10.Text = ""
                lblStatus10.Text = ""

                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 10 Then
                lblRoom11.Text = mghList(10).Bed_No
                lblStatus11.Text = mghList(10).Status
            Else
                lblRoom11.Text = ""
                lblStatus11.Text = ""

                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 11 Then
                lblRoom12.Text = mghList(11).Bed_No
                lblStatus12.Text = mghList(11).Status
            Else
                lblRoom12.Text = ""
                lblStatus12.Text = ""

                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 12 Then
                lblRoom13.Text = mghList(12).Bed_No
                lblStatus13.Text = mghList(12).Status
            Else
                lblRoom13.Text = ""
                lblStatus13.Text = ""

                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 13 Then
                lblRoom14.Text = mghList(13).Bed_No
                lblStatus14.Text = mghList(13).Status
            Else
                lblRoom14.Text = ""
                lblStatus14.Text = ""

                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 14 Then
                lblRoom15.Text = mghList(14).Bed_No
                lblStatus15.Text = mghList(14).Status
            Else
                lblRoom15.Text = ""
                lblStatus15.Text = ""

                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 15 Then
                lblRoom16.Text = mghList(15).Bed_No
                lblStatus16.Text = mghList(15).Status
            Else
                lblRoom16.Text = ""
                lblStatus16.Text = ""

                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 16 Then
                lblRoom17.Text = mghList(16).Bed_No
                lblStatus17.Text = mghList(16).Status
            Else
                lblRoom17.Text = ""
                lblStatus17.Text = ""

                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 17 Then
                lblRoom18.Text = mghList(17).Bed_No
                lblStatus18.Text = mghList(17).Status
            Else
                lblRoom18.Text = ""
                lblStatus18.Text = ""

                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 18 Then
                lblRoom19.Text = mghList(18).Bed_No
                lblStatus19.Text = mghList(18).Status
            Else
                lblRoom19.Text = ""
                lblStatus19.Text = ""

                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 19 Then
                lblRoom20.Text = mghList(19).Bed_No
                lblStatus20.Text = mghList(19).Status
            Else
                lblRoom20.Text = ""
                lblStatus20.Text = ""

                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 20 Then
                lblRoom21.Text = mghList(20).Bed_No
                lblStatus21.Text = mghList(20).Status
            Else
                lblRoom21.Text = ""
                lblStatus21.Text = ""

                lblRoom22.Text = ""
                lblStatus22.Text = ""
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 21 Then
                lblRoom22.Text = mghList(21).Bed_No
                lblStatus22.Text = mghList(21).Status
            Else
                lblRoom22.Text = ""
                lblStatus22.Text = ""

                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 22 Then
                lblRoom23.Text = mghList(22).Bed_No
                lblStatus23.Text = mghList(22).Status
            Else
                lblRoom23.Text = ""
                lblStatus23.Text = ""

                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 23 Then
                lblRoom24.Text = mghList(23).Bed_No
                lblStatus24.Text = mghList(23).Status
            Else
                lblRoom24.Text = ""
                lblStatus24.Text = ""

                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 24 Then
                lblRoom25.Text = mghList(24).Bed_No
                lblStatus25.Text = mghList(24).Status
            Else
                lblRoom25.Text = ""
                lblStatus25.Text = ""

                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 25 Then
                lblRoom26.Text = mghList(25).Bed_No
                lblStatus26.Text = mghList(25).Status
            Else
                lblRoom26.Text = ""
                lblStatus26.Text = ""

                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 26 Then
                lblRoom27.Text = mghList(26).Bed_No
                lblStatus27.Text = mghList(26).Status
            Else
                lblRoom27.Text = ""
                lblStatus27.Text = ""

                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 27 Then
                lblRoom28.Text = mghList(27).Bed_No
                lblStatus28.Text = mghList(27).Status
            Else
                lblRoom28.Text = ""
                lblStatus28.Text = ""

                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 28 Then
                lblRoom29.Text = mghList(28).Bed_No
                lblStatus29.Text = mghList(28).Status
            Else
                lblRoom29.Text = ""
                lblStatus29.Text = ""

                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 29 Then
                lblRoom30.Text = mghList(29).Bed_No
                lblStatus30.Text = mghList(29).Status
            Else
                lblRoom30.Text = ""
                lblStatus30.Text = ""

                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 30 Then
                lblRoom31.Text = mghList(30).Bed_No
                lblStatus31.Text = mghList(30).Status
            Else
                lblRoom31.Text = ""
                lblStatus31.Text = ""

                lblRoom32.Text = ""
                lblStatus32.Text = ""
                GoTo SKIP
            End If

            If mghList.Count > 31 Then
                lblRoom32.Text = mghList(31).Bed_No
                lblStatus32.Text = mghList(31).Status
            Else
                lblRoom32.Text = ""
                lblStatus32.Text = ""
            End If
        Else
            lblRoom1.Text = ""
            lblStatus1.Text = ""

            lblRoom2.Text = ""
            lblStatus2.Text = ""

            lblRoom3.Text = ""
            lblStatus3.Text = ""

            lblRoom4.Text = ""
            lblStatus4.Text = ""

            lblRoom5.Text = ""
            lblStatus5.Text = ""

            lblRoom6.Text = ""
            lblStatus6.Text = ""

            lblRoom7.Text = ""
            lblStatus7.Text = ""

            lblRoom8.Text = ""
            lblStatus8.Text = ""

            lblRoom9.Text = ""
            lblStatus9.Text = ""

            lblRoom10.Text = ""
            lblStatus10.Text = ""

            lblRoom11.Text = ""
            lblStatus11.Text = ""

            lblRoom12.Text = ""
            lblStatus12.Text = ""

            lblRoom13.Text = ""
            lblStatus13.Text = ""

            lblRoom14.Text = ""
            lblStatus14.Text = ""

            lblRoom15.Text = ""
            lblStatus15.Text = ""

            lblRoom16.Text = ""
            lblStatus16.Text = ""

            lblRoom17.Text = ""
            lblStatus17.Text = ""

            lblRoom18.Text = ""
            lblStatus18.Text = ""

            lblRoom19.Text = ""
            lblStatus19.Text = ""

            lblRoom20.Text = ""
            lblStatus20.Text = ""

            lblRoom21.Text = ""
            lblStatus21.Text = ""

            lblRoom22.Text = ""
            lblStatus22.Text = ""

            lblRoom23.Text = ""
            lblStatus23.Text = ""

            lblRoom24.Text = ""
            lblStatus24.Text = ""

            lblRoom25.Text = ""
            lblStatus25.Text = ""

            lblRoom26.Text = ""
            lblStatus26.Text = ""

            lblRoom27.Text = ""
            lblStatus27.Text = ""

            lblRoom28.Text = ""
            lblStatus28.Text = ""

            lblRoom29.Text = ""
            lblStatus29.Text = ""

            lblRoom30.Text = ""
            lblStatus30.Text = ""

            lblRoom31.Text = ""
            lblStatus31.Text = ""

            lblRoom32.Text = ""
            lblStatus32.Text = ""
        End If
SKIP:
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

    Private Sub frmCountersQueueBoardRoomStandalone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtclock.Text = TimeOfDay.ToShortTimeString
        lblCounterName.Text = Counter.Section.ToUpper + "   "
        SetPagingConfig()
        showHelp()
        refreshDataIntertval.Start()
        mghList.Start()
        CLOCK.Start()
    End Sub

    Private Sub frmCountersQueueBoardRoomStandalone_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F11 Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Maximized
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            showHelp()
        End If
    End Sub

    Private Sub frmCountersQueueBoardRoomStandalone_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        refreshDataIntertval.Stop()
    End Sub
End Class