Public Class frmManageAds
    Dim file As String = Nothing
    Const filePath As String = "\\10.5.19.237\qms_ads"

    Private Function checkFileType(ext As String) As Integer
        Dim imageFiles = New String() {"JPG", "BMP", "PNG"}
        Dim videoFiles = New String() {"MP4", "3GP"}
        For Each x As String In imageFiles
            If ext.ToUpper = x Then
                Return 1
            End If
        Next
        For Each x As String In videoFiles
            If ext.ToUpper = x Then
                Return 0
            End If
        Next
        Return 2
    End Function

    Private Sub frmManageAds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'wmpAds.uiMode = "NONE"
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim fd As New OpenFileDialog
        With fd
            .Title = "Select an Image or a Video"
            .InitialDirectory = "C:\"
            .Filter = "Media Files|*.jpg;*.png;*.bmp;*.mp4;*.3gp;*.MP4;*.3GP|Images|*.jpg;*.png;*.bmp|Videos|*.mp4;*.3gp;*.MP4;*.3GP"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        If fd.ShowDialog() = DialogResult.OK Then
            'wmpAds.settings.setMode("loop", True)
            'wmpAds.currentPlaylist.clear()
            txtFileName.Text = IO.Path.GetFileNameWithoutExtension(fd.FileName).ToUpper
            txtFileLocation.Text = IO.Path.GetFullPath(fd.FileName).ToUpper
            txtFileType.Text = IO.Path.GetExtension(fd.FileName).Replace(".", "").ToUpper
            txtFileName.ReadOnly = False
            file = fd.FileName
            'wmpAds.currentPlaylist.appendItem('wmpAds.newMedia(file))
            'wmpAds.Ctlcontrols.play()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to save this ad?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If Not IsNothing(file) Then
                    Dim newpath As String = filePath & "\" & txtFileName.Text & IO.Path.GetExtension(file)
                    IO.File.Copy(file, newpath)
                    Dim adController As New adscontroller
                    Dim ad As New ADS
                    ad.ADSName = txtFileName.Text
                    ad.ADSLocation = newpath
                    ad.ADSType = checkFileType(txtFileType.Text)
                    If adController.NewAds(ad) Then
                        MessageBox.Show("Ad saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.Yes
                    Else
                        MessageBox.Show("Something went wrong during the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("No image or video was selected", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub frmManageAds_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'wmpAds.Ctlcontrols.stop()
    End Sub
End Class