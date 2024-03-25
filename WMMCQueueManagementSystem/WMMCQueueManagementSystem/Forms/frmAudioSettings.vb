Imports System.Speech.Synthesis
Public Class frmAudioSettings
    Private queuingSpeaker As New System.Speech.Synthesis.SpeechSynthesizer()

    Private Sub TestCall()
        Try
            If rbBeepVoice.Checked Then
                queuingSpeaker.SpeakAsyncCancelAll()
                If rbMale.Checked Then
                    queuingSpeaker.SelectVoiceByHints(VoiceGender.Male)
                Else
                    queuingSpeaker.SelectVoiceByHints(VoiceGender.Female)
                End If
                queuingSpeaker.Volume = tbVolume.Value
                queuingSpeaker.Rate = tbSpeed.Value
                My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
                queuingSpeaker.SpeakAsync("Hello there! If you like my voice, please click save changes.")

            Else
                My.Computer.Audio.Play(My.Resources.beep, AudioPlayMode.WaitToComplete)
            End If
        Catch ex As Exception
            MessageBox.Show("Audio device error. Please check if your audio is connected properly", "Audio device error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rbBeepVoice.Checked = False
            rbBeep.Checked = True
        End Try
    End Sub

    Private Sub BeepType(flag As Boolean)
        tbVolume.Enabled = flag
        tbSpeed.Enabled = flag
        gbGender.Enabled = flag
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim voiceModel As VoiceModel = VoiceSetting
        voiceModel.VoiceVolume = tbVolume.Value
        voiceModel.VoiceSpeed = tbSpeed.Value
        If rbMale.Checked Then
            voiceModel.VoiceGenderMale = True
        Else
            voiceModel.VoiceGenderMale = False
        End If
        If rbBeepVoice.Checked Then
            voiceModel.BeepAndVoice = True
        Else
            voiceModel.BeepAndVoice = False
        End If
        VoiceSetting() = voiceModel
        MessageBox.Show("Settings saved successful", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub rbBeep_CheckedChanged(sender As Object, e As EventArgs) Handles rbBeep.CheckedChanged
        If rbBeep.Checked Then
            BeepType(False)
        End If
    End Sub

    Private Sub frmAudioSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim voiceModel As VoiceModel = VoiceSetting
        tbVolume.Value = voiceModel.VoiceVolume
        tbSpeed.Value = voiceModel.VoiceSpeed
        If voiceModel.VoiceGenderMale Then
            rbFemale.Checked = False
            rbMale.Checked = True
        Else
            rbMale.Checked = False
            rbFemale.Checked = True
        End If
        If voiceModel.BeepAndVoice Then
            rbBeep.Checked = False
            rbBeepVoice.Checked = True
        Else
            rbBeepVoice.Checked = False
            rbBeep.Checked = True
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        TestCall()
    End Sub

    Private Sub rbBeepVoice_CheckedChanged(sender As Object, e As EventArgs) Handles rbBeepVoice.CheckedChanged
        If rbBeepVoice.Checked Then
            BeepType(True)
        End If
    End Sub

    Private Sub frmAudioSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        queuingSpeaker.SpeakAsyncCancelAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class