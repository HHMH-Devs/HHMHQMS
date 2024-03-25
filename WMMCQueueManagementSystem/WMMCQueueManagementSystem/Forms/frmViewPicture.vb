Public Class frmViewPicture
    Sub New(imgLink As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If imgLink.Length > 0 Then
            Try
                pbProfilePicture.Image = Image.FromFile(imgLink)
            Catch ex As Exception
                pbProfilePicture.Image = Nothing
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Sub New(img As Image)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pbProfilePicture.Image = img
    End Sub

    Private Sub frmViewPicture_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class